/****************** Copyright Notice *****************
 
This code is licensed under Microsoft Public License (Ms-PL). 
You are free to use, modify and distribute any portion of this code. 
The only requirement to do that, you need to keep the developer name, as provided below to recognize and encourage original work:

=======================================================
   
Architecture Designed and Implemented By:
Mohammad Ashraful Alam
Microsoft Most Valuable Professional, ASP.NET 2007 – 2011
Twitter: http://twitter.com/AshrafulAlam | Blog: http://blog.ashraful.net | Portfolio: http://www.ashraful.net
   
*******************************************************/
using System;
using Eisk.Helpers;
using System.Diagnostics;
namespace Eisk.BusinessEntities
{
    partial class Employee
    {
        //optional field
        partial void OnBirthDateChanged()
        {
            ValidateBirthDateAndHireDate();
        }

        //required field
        partial void OnHireDateChanged()
        {
            ValidateBirthDateAndHireDate();
        }

        /// <summary>
        /// validation method
        /// RULE: BirthDate should not be later than the HireDate
        /// </summary>
        void ValidateBirthDateAndHireDate()
        {
            //if BirthDate or HireDate is assigned and BirthDate is greater than HireDate, throw exception
            if ((BirthDate != null) && (!HireDate.IsEmpty()) && (DateTime.Compare((DateTime)BirthDate, HireDate) >= 0))
                throw new BusinessRuleViolationOnInMemoryException("Exception!!! BirthDate should be earlier than HireDate!");

            Console.WriteLine("CONSOLE: HireDate Value " + HireDate.ToString());

            Debug.WriteLine("DEBUG: HireDate Value " + HireDate.ToString());
            //Debug.Assert(BirthDate == null, "DEBUG: BirthDate is null");

            Trace.WriteLine("TRACE: HireDate Value " + HireDate.ToString());
            //Trace.Assert(BirthDate == null, "TRACE: BirthDate is null");
            Trace.TraceWarning("TRACE WARNING: HireDate Value " + HireDate.ToString());
        }
        
        //optional field - with default value. 
        //Please note that, default value concept may not work for a required value.
        //also, since we'll not allow empty value for required and optional value, we are considering only NULL value to set default value
        partial void OnExtensionChanged()
        {
            if (Extension.IsNull())
            {
                Extension = "n/a";
            }
        }
 
    }
}
