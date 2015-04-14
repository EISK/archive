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
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Eisk.Helpers;

namespace Eisk.Models
{
    [Table("Employees")]
    public partial class Employee : Person
    {
        [StringLength(30)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Required")]
        [DateGreaterThanAttribute("BirthDate")]
        [Display(Name = "Hire Date")]
        public DateTime HireDate { get; set; }

        [Display(Name = "Supervisor")]
        public int? ReportsTo { get; set; }

        [ForeignKey("ReportsTo")]
        public virtual Employee Supervisor { get; set; }

        public virtual List<Employee> Subordinates { get; set; }

    }
}