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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Eisk.DataAccess;
using Eisk.Helpers;

namespace Eisk.Models
{
    public class LookUpModelSet
    {
        public static IEnumerable<SelectListItem> SupervisorSelectList
        {
            get
            {
                IEnumerable<Employee> supervisors =
                    DependencyHelper.GetInstance<DatabaseContext>().EmployeeRepository.AsEnumerable();

                IEnumerable<SelectListItem> _supervisorSelectList =
                    supervisors.Select(option => new SelectListItem
                    {
                        Text = option.FirstName + " " + option.LastName,
                        Value = option.Id.ToString()
                    });

                return _supervisorSelectList;
            }
        }

        static SelectList _countrySelectList;
        public static SelectList CountrySelectList
        {
            get
            {
                if (_countrySelectList == null)
                    _countrySelectList = new SelectList(CountryList.Countries);

                return _countrySelectList;
            }
        }
    }
}