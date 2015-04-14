using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.WebPages;
using Eisk.DataAccess;
using Eisk.Helpers;
using Eisk.Models;
namespace Eisk.Global
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            InitializeDependencyInjectionContainer();
            InitializeDisplayMode();

            AreaRegistration.RegisterAllAreas();
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            if (HttpContext.Current.IsDebuggingEnabled)
                TestDataHelper.InitializeSchemaAndData(HttpContext.Current.Server.MapPath("~/App_Data/TestData.xml"));
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs
            Logger.LogError();
        }

        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {

            if (HttpContext.Current.User != null)
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {

                    if (HttpContext.Current.User.Identity.AuthenticationType != "Forms")
                        throw new InvalidOperationException("Only forms authentication is supported, not " +
                            HttpContext.Current.User.Identity.AuthenticationType);

                    System.Security.Principal.IIdentity userId = HttpContext.Current.User.Identity;

                    //if role info is already NOT loaded into cache, put the role info in cache
                    if (System.Web.HttpContext.Current.Cache[userId.Name] == null)
                    {
                        string[] roles = new string[1] { GetUserRoleByUserName(userId.Name) };

                        //1 hour sliding expiring time. Adding the roles in chache. This will be used in Application_AuthenticateRequest event located in Global.ascx.cs file to attach user Principal object.
                        System.Web.HttpContext.Current.Cache.Add(userId.Name, roles, null, DateTime.MaxValue, TimeSpan.FromHours(1), System.Web.Caching.CacheItemPriority.BelowNormal, null);
                    }

                    //now assign the user role in the current security context
                    HttpContext.Current.User = new System.Security.Principal.GenericPrincipal
                        (userId, (string[])System.Web.HttpContext.Current.Cache[userId.Name]);
                }
            }

        }

        public override void Init()
        {
            //this.PostAuthenticateRequest += this.PostAuthenticateRequestHandler;
            this.EndRequest += this.EndRequestHandler;

            base.Init();
        }

        private void EndRequestHandler(object sender, EventArgs e)
        {
            // This is a workaround since subscribing to HttpContext.Current.ApplicationInstance.EndRequest 
            // from HttpContext.Current.ApplicationInstance.BeginRequest does not work. 
            IEnumerable<UnityHttpContextPerRequestLifetimeManager> perRequestManagers =
                DependencyHelper.Container.Registrations
                    .Select(r => r.LifetimeManager)
                    .OfType<UnityHttpContextPerRequestLifetimeManager>()
                    .ToArray();

            foreach (var manager in perRequestManagers)
            {
                manager.Dispose();
            }
        }

        #region Utilities
        
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        void InitializeDisplayMode()
        {
            InsertDisplayMode("Mobile");
            InsertDisplayMode("iPhone");
            InsertDisplayMode("Tablet");
            InsertDisplayMode("AndroidTablet");
        }

        void InsertDisplayMode(string device)
        {
            //support for specific browser
            DisplayModeProvider.Instance.Modes.Insert(0, new DefaultDisplayMode(device)
            {
                ContextCondition = (context => context.GetOverriddenUserAgent().IndexOf
                    (device, StringComparison.OrdinalIgnoreCase) >= 0)
            });
        }

        //this info will typically be loaded from database
        string GetUserRoleByUserName(string userName)
        {
            UserInfo user = UserDataAccess.GetByUserName(userName);
            return userName == null ? string.Empty : user.UserRole;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability",
          "CA2000:Dispose objects before losing scope",
          Justification = "This should survive the lifetime of the application.")]
        private static void InitializeDependencyInjectionContainer()
        {
            DependencyHelper.Initialize();
        }

        #endregion
    }
}