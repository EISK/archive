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
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Eisk.DataAccess;
using Eisk.Helpers;
using Eisk.Models;

namespace Eisk.BusinessRules
{
    public class SupervisorCountryMustBeSame
    {
        public static ValidationResult Validate(Employee employee)
        {
            if (employee.ReportsTo != null)
            {
                if (employee.Supervisor == null)
                    employee.Supervisor =
                        DependencyHelper.GetInstance<DatabaseContext>().
                        EmployeeRepository.
                        Find((int)employee.ReportsTo);

                if (employee.Address.Country != employee.Supervisor.Address.Country)
                    return new ValidationResult(ERROR_MESSAGE, new string[] { string.Empty, "Address.Country" });

            }

            return ValidationResult.Success;
        }

        const string ERROR_MESSAGE = "Supervisor country must be same as subordinate.";

        public static bool IsErrorAvalilableIn(Controller controller)
        {
            return controller.IsErrorAvalilableIn(ERROR_MESSAGE);
        }

    }
}

