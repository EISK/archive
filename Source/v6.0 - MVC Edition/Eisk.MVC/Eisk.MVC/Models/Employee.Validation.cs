﻿/****************** Copyright Notice *****************
 
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
using Eisk.BusinessRules;

namespace Eisk.Models
{
    public partial class Employee : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield return EmployeeAddressMustBeUnique.Validate(this);
            yield return SupervisorCountryMustBeSame.Validate(this);
        }
    }
}