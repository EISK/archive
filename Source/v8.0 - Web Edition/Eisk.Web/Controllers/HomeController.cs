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
using System.Web.Mvc;
using System.Web.WebPages;
using Eisk.Helpers;
namespace Eisk.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ViewResult About()
        {
            return View();
        }

        public ViewResult ExceptionDemo()
        {
            throw new InvalidOperationException("Invalid operation performed.");
        }

        public ActionResult ResetData()
        {
            try
            {
                TestDataHelper.InitializeSchemaAndData(System.Web.HttpContext.Current.Server.MapPath("~/App_Data/TestData.xml"));
                this.ShowMessage("Test data generated successfully", MessageType.Success);
            }
            catch (Exception ex)
            {
                this.ShowMessage("Error on test data generation with the following details " + ex.Message, MessageType.Error);
            }

            return RedirectToAction("Index");

        }

        public RedirectResult SwitchView(bool mobile, string returnUrl)
        {
            if (Request.Browser.IsMobileDevice == mobile)
                HttpContext.ClearOverriddenBrowser();
            else
                HttpContext.SetOverriddenBrowser(mobile ? BrowserOverride.Mobile : BrowserOverride.Desktop);

            return Redirect(returnUrl);
        }
    }
}
