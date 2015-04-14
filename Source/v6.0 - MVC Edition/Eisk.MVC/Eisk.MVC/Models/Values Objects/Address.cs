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
using Eisk.Helpers;

namespace Eisk.Models
{
    public partial class Address
    {
        [StringLength(60)]
        [Required(ErrorMessage = "Address line required.")]
        [Display(Name = "Address line")]
        public string AddressLine { get; set; }

        [StringLength(15)]
        public string City { get; set; }

        [StringLength(15)]
        [RequiredIf("Country", "Canada, India, USA", ErrorMessage = "You must specify Region for the selected country.")]
        public string Region { get; set; }

        [StringLength(10)]
        [RegularExpression("\\d{1,10}", ErrorMessage = "Not a valid postal code. Please consider upto 10 digit for valid phone format.")]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Country required.")]
        [StringLength(15)]
        public string Country { get; set; }
                
    }
}