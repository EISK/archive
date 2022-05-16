/****************** Copyright Notice *****************
 
This code is licensed under Microsoft Public License (Ms-PL). 
You are free to use, modify and distribute any portion of this code. 
The only requirement to do that, you need to keep the developer name, as provided below to recognize and encourage original work:

=======================================================
   
Architecture Designed and Implemented By:
Mohammad Ashraful Alam
Microsoft Most Valuable Professional, ASP.NET 2007 – 2013
Twitter: http://twitter.com/AshrafulAlam | Blog: http://blog.ashraful.net | Portfolio: http://www.ashraful.net
   
*******************************************************/
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Eisk.DataAccess;
using Eisk.Helpers;
using Eisk.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Eisk.Tests
{
    /// <summary>
    /// Rule: The concept of aggregate child is, the entities in the system, which CRUD operation is performed via a agrregate root (i.e.parent foreign key) object.
    /// * There will be no direct connection between the context class and the aggregate child object.
    /// 
    /// Design: In a domain model, the following conditions can be considered to determine aggregate rool (technically, not conceptually):
    /// * The aggregate child has the parent foreign key as not nullable
    /// * All rows of the corresponding database table of aggregate child are not required to be accessed at the same time.
    /// * No aggregate child can be accessed without accessing aggregate root.
    /// </summary>
    [TestClass]
    public class AggregateChildTests:IntegrationTestBase
    {
        [TestMethod]
        public void InsertAggregateChildToNewAggregateRootObject()
        {

            Employee supervisorEmployee = TestDataHelper.CreateEmployeeWithValidData();

            Employee subordinateEmployee = TestDataHelper.CreateEmployeeWithValidData();

            supervisorEmployee.Subordinates = new List<Employee>();
            supervisorEmployee.Subordinates.Add(subordinateEmployee); //marking to add to database

            DatabaseContext ctx = new DatabaseContext();
            ctx.Entry(supervisorEmployee).State = EntityState.Added;
            ctx.SaveChanges();

            int actualCount = (from e in ctx.EmployeeRepository select e).ToList().Count;

            Assert.AreEqual(16, actualCount);

            supervisorEmployee = ctx.EmployeeRepository.Find(15);
            Assert.AreEqual(1, supervisorEmployee.Subordinates.Count);
        }

       [TestMethod]
        public void InsertAggregateChildToAggregateRoot(){

            DatabaseContext ctx = new DatabaseContext();

            Employee supervisorEmployee = ctx.EmployeeRepository.Find(1);
            
            Employee subordinateEmployee = TestDataHelper.CreateEmployeeWithValidData();

            supervisorEmployee.Subordinates.Add(subordinateEmployee); //marking to add to database

            ctx.SaveChanges();


            int actualCount = (from e in ctx.EmployeeRepository select e).ToList().Count;

            Assert.AreEqual(15, actualCount);
            Assert.AreEqual(11, supervisorEmployee.Subordinates.Count);
        }


        [TestMethod]
        public void ReadAggregateChildFromAggregateRoot()
        {

            DatabaseContext ctx = new DatabaseContext();

            Employee supervisorEmployee = ctx.EmployeeRepository.Find(1);

            Employee subordinateEmployee = supervisorEmployee.Subordinates.Find(e => e.Id == 3);

            Assert.AreEqual("Mostofa", subordinateEmployee.FirstName);
            
        }

        [TestMethod]
        public void UpdatedAggregateChildFromAggregateRoot()
        {

            DatabaseContext ctx = new DatabaseContext();

            Employee supervisorEmployee = ctx.EmployeeRepository.Find(1);

            Employee subordinateEmployee = supervisorEmployee.Subordinates.Find(e => e.Id == 3);

            subordinateEmployee.FirstName = "Md.";
             
            ctx.SaveChanges();

            Employee sub = ctx.EmployeeRepository.Find(3);

            Assert.AreEqual("Md.", sub.FirstName);

        }

        [TestMethod]
        public void UpdatedAggregateChildToAnotherAggregateRoot()
        {

            DatabaseContext ctx = new DatabaseContext();

            Employee supervisorEmployee = ctx.EmployeeRepository.Find(1);
            Employee supervisorEmployee2 = ctx.EmployeeRepository.Find(2);

            Employee subordinateEmployee = supervisorEmployee.Subordinates.Find(e => e.Id == 3);
            supervisorEmployee2.Subordinates.Add(subordinateEmployee);
            
            ctx.SaveChanges();
            
            int actualCount = (from e in ctx.EmployeeRepository select e).ToList().Count;

            Assert.AreEqual(14, actualCount);
            Assert.AreEqual(9, supervisorEmployee.Subordinates.Count);
            Assert.AreEqual(3, supervisorEmployee2.Subordinates.Count);

        }

        [TestMethod]
        public void UpdateAggregateChildToNullAggregateRoot()
        {

            DatabaseContext ctx = new DatabaseContext();

            Employee supervisorEmployee = ctx.EmployeeRepository.Find(1);

            Employee subordinateEmployee = supervisorEmployee.Subordinates.Find(e => e.Id == 3);

            supervisorEmployee.Subordinates.Remove(subordinateEmployee);//updates child's parent reference (foreign) to null
            
            ctx.SaveChanges();

            int actualCount = (from e in ctx.EmployeeRepository select e).ToList().Count;

            Assert.AreEqual(14, actualCount);

            Assert.AreEqual(9, supervisorEmployee.Subordinates.Count);

        }

        [TestMethod]
        public void DeleteAggregateChildFromAggregateRootAndDatabase()
        {

            DatabaseContext ctx = new DatabaseContext();

            Employee supervisorEmployee = ctx.EmployeeRepository.Find(1);

            Employee subordinateEmployee = supervisorEmployee.Subordinates.Find(e => e.Id == 3);

            /***********************************
             * If the foreign key was non-nullable, the following error will occur when the following line of code is executed:
             * The relationship could not be changed because one or more of the foreign-key properties is non-nullable. 
             * When a change is made to a relationship, the related foreign-key property is set to a null value. 
             * If the foreign-key does not support null values, a new relationship must be defined, the foreign-key property must be assigned another non-null value, or the unrelated object must be deleted.
             * 
             * NEED TO CHECK: For a composite child key, the corresponding row will be physically deleted!?
            *************************************/
            //supervisorEmployee.Subordinates.Remove(subordinateEmployee);
            
            ctx.Entry(subordinateEmployee).State = System.Data.EntityState.Deleted;

            ctx.SaveChanges();

            int actualCount = (from e in ctx.EmployeeRepository select e).ToList().Count;

            Assert.AreEqual(13, actualCount);

            Assert.AreEqual(9, supervisorEmployee.Subordinates.Count);

        }

        [TestMethod]
        public void DeleteAggregateRootWithAllAggregateChild()
        {

            DatabaseContext ctx = new DatabaseContext();

            Employee supervisorEmployee = ctx.EmployeeRepository.Find(1);

            List<Employee> subordinates = (
                    from employee in
                        ctx.EmployeeRepository
                    where employee.ReportsTo == 1
                    select employee
                    ).ToList();

            foreach (Employee sub in subordinates)
                ctx.EmployeeRepository.Remove(sub);
            
            ctx.Entry(supervisorEmployee).State = EntityState.Deleted;

            ctx.SaveChanges();

            int actualCount = (from e in ctx.EmployeeRepository select e).ToList().Count;

            Assert.AreEqual(3, actualCount);

        }
      
    }
}
