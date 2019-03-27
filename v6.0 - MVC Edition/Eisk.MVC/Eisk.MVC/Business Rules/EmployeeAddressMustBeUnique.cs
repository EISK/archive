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
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using Eisk.DataAccess;
using Eisk.Helpers;
using Eisk.Models;
namespace Eisk.BusinessRules
{
    public class EmployeeAddressMustBeUnique
    {
        public static ValidationResult Validate(Employee employee)
        {
            List<Employee> otherEmployeesHavingSameAddress =
                DependencyHelper.GetInstance<DatabaseContext>().
                EmployeeRepository.
                Where(e => (e.Address.AddressLine == employee.Address.AddressLine) && (e.Id != employee.Id)).
                ToList();

            if (otherEmployeesHavingSameAddress.Count > 0)
                return new ValidationResult(GetFormattedErrorMessage(employee), new string[] { string.Empty, "Address.AddressLine" });

            return ValidationResult.Success;
        }

        const string ERROR_MESSAGE = "Error for unique address occured. EmployeeId: {0}, EmployeeAddress: {1}";

        static string GetFormattedErrorMessage(Employee employee)
        {
            return string.Format(ERROR_MESSAGE, employee.Id, employee.Address.AddressLine);
        }

        public static bool IsErrorAvalilableIn(Controller controller, Employee employee)
        {
            return controller.IsErrorAvalilableIn(GetFormattedErrorMessage(employee));
        }
    }
}
