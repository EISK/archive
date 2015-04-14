using System;
using System.IO;
using System.Web.Mvc;

namespace Eisk.Helpers
{
    public class ControllerHelper
    {
        private readonly ControllerContext _controllerContext;
        private ViewContext _viewContext;
        private UrlHelper _url;
        private HtmlHelper _html;

        public ControllerHelper(Controller controller)
        {
            if (controller == null)
            {
                throw new ArgumentNullException("controller");
            }

            this._controllerContext = controller.ControllerContext;
        }

        public ViewContext ViewContext
        {
            get
            {
                if (_viewContext == null)
                {
                    _viewContext = new ViewContext(
                    _controllerContext,
                    new InternalView(),
                    _controllerContext.Controller.ViewData,
                    _controllerContext.Controller.TempData,
                    _controllerContext.HttpContext.Response.Output);
                }
                return _viewContext;
            }        
        }

        public UrlHelper Url
        {
            get
            {
                if (_url == null)
                {
                    _url = new UrlHelper(_controllerContext.RequestContext);
                }
                return _url;
            }
        }

        public HtmlHelper Html
        {
            get
            {
                if (_html == null)
                {
                    _html = new HtmlHelper(ViewContext, new InternalViewDataContainer(ViewContext.ViewData));
                }
                return _html;

            }
        }

        private class InternalView : IView
        {
            public void Render(ViewContext viewContext, TextWriter writer)
            {
            }
        }

        private class InternalViewDataContainer : IViewDataContainer
        {
            public InternalViewDataContainer(ViewDataDictionary viewData)
            {
                ViewData = viewData;
            }

            public ViewDataDictionary ViewData { get; set; }
        }
    }
}