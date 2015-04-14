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
using System.Web.Mvc;
using Eisk.Helpers;

namespace Eisk.Models
{
    public class EmployeeEditorModel : Employee
    {
        public IEnumerable<SelectListItem> SupervisorSelectList
        {
            get
            {
                return LookUpModelSet.SupervisorSelectList;
            }
        }

        public SelectList CountrySelectList
        {
            get
            {
                return LookUpModelSet.CountrySelectList;
            }
        }

        public string PageTitle { get; private set; }
        public string EditorAction
        {
            get
            {
                return Id == 0 ? "Create" : "Edit";
            }
        }

        public EmployeeEditorModel()
        {
            PageTitle = "New Employee";
        }

        public EmployeeEditorModel(Employee employee)
        {
            PageTitle = StringHelper.ConnectStrings(" ", employee.TitleOfCourtesy, employee.FirstName, employee.LastName);
            ObjectHelper.CopyPropertiesValueFromBaseType(employee, this);
        }
    }
}