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
namespace Eisk.Controllers
{
    using System.Web.Mvc;
    using System.Web.Security;
    using Helpers;
    using Models;
    using DataAccess;


    public partial class SecurityDemoController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }

        [Authorize]
        public ViewResult Member()
        {
           return View();
        }

        [Authorize(Roles = "Administrator")]
        public ViewResult Admin()
        {
            return View();
        }

        public ViewResult LogOn()
        {
            if (Request.QueryString["ReturnUrl"] != null)
                this.ShowMessage("You need to log-on first with appropriate role to access the page you requested.", MessageType.Error, false);
            return View();
        }

        [HttpPost]
        public ActionResult LogOn(FormCollection fc)
        {
            UserInfo user = UserDataAccess.Validate(fc["userName"], fc["password"]);

            if (user != null)//if the log-in is successful
            {
                FormsAuthentication.RedirectFromLoginPage(user.UserName, fc["checkboxRemember"] == "on");

                if (Request.QueryString["ReturnUrl"] != null)
                    Response.Redirect(System.Web.HttpContext.Current.Request.QueryString["ReturnUrl"].ToString());
                else
                {
                    if (user.UserRole == UserRole.Administrator.ToString())
                        return RedirectToAction("Admin");
                    else
                        return RedirectToAction("Member");
                }
            }
            else
                this.ShowMessage("Invalid user name or password", MessageType.Error, false);

            return View();

        }

        public ViewResult LogOff()
        {
            FormsAuthentication.SignOut();
            System.Web.HttpContext.Current.User = null;
            this.ShowMessage("You have been signed out successfully", MessageType.Info, false);
            return View("Index");
        }

        public JsonResult GetAllUsers()
        {
            System.Threading.Thread.Sleep(2000);
            return new JsonResult
            {
                Data = UserDataAccess.GetAll(),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}

#region Demo Data


namespace Eisk.Models
{
    public class UserInfo
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UserRole { get; set; }
    }
}

namespace Eisk.DataAccess
{
    using System.Collections.Generic;
    using Eisk.Models;
    using System.Linq;

    public static class UserDataAccess
    {
        public static IEnumerable<UserInfo> GetAll()
        {
            return UserInMemoryDataSource.ToList();
        }

        public static UserInfo GetByUserName(string userName)
        {
            return UserInMemoryDataSource.FirstOrDefault(u => u.UserName == userName);
        }

        public static UserInfo Validate(string userName, string password)
        {
            return UserInMemoryDataSource.FirstOrDefault(u => u.UserName == userName && u.Password == password);
        }

        static List<UserInfo> _userInMemoryDataSource;
        static List<UserInfo> UserInMemoryDataSource
        {
            get
            {
                if (_userInMemoryDataSource == null)
                {
                    _userInMemoryDataSource = new List<UserInfo>();

                    //add members
                    for (int i = 0; i < 5; i++)
                        _userInMemoryDataSource.Add(
                            new UserInfo
                            {
                                UserName = "member" + (i + 1),
                                Password = "any"
                            });

                    //add administrators
                    for (int i = 0; i < 5; i++)
                        _userInMemoryDataSource.Add(
                            new UserInfo
                            {
                                UserRole = UserRole.Administrator.ToString(),
                                UserName = "admin" + (i + 1),
                                Password = "any"
                            });

                }

                return _userInMemoryDataSource;
            }
        }
    }
}

#endregion