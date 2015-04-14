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
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Routing;
using Eisk.Helpers;
using System.Web;

namespace Eisk.Models
{
    public class GridViewModel
    {
        ControllerHelper ControllerHelper { get; set; }
        string SingleItemDeleteAction { get; set; }
        public string GridBindingAction { get; set; }
        public int TotalRecords { get; private set; }

        public GridViewModel(Controller controller, int totalRecords, string gridBindingAction = "GridData", string singleItemDeleteAction = "Delete")
        {
            ControllerHelper = new ControllerHelper(controller);
            TotalRecords = totalRecords;
            GridBindingAction = gridBindingAction;
            SingleItemDeleteAction = singleItemDeleteAction;
        }

        public IHtmlString GridDatabind
        {
            get
            {
                return ControllerHelper.Html.Raw(ControllerHelper.Url.Action(GridBindingAction));
            }
        }

        public IHtmlString SingleItemDelete
        {
            get
            {
                return ControllerHelper.Html.Raw(ControllerHelper.Url.Action(SingleItemDeleteAction, new { id = "__ID__" }));
            }
        }


        public int TotalPages
        {
            get
            {
                return (TotalRecords - 1) / ItemsPerPage + 1;
            }
        }

        public int CurrentPage
        {
            get
            {
                return Start / ItemsPerPage + 1;
            }
        }

        List<int> _itemsPerPageOptions;
        public List<int> ItemsPerPageOptions
        {
            get
            {
                if (_itemsPerPageOptions == null)
                    _itemsPerPageOptions = new List<int> { 10, 20, 50, 100 };
                return _itemsPerPageOptions;
            }
        }

        public RouteValueDictionary CurrentRouteValues
        {
            get
            {
                RouteValueDictionary routeDictionary = new RouteValueDictionary();

                routeDictionary[ObjectHelper.GetName(() => Start)] = Start;
                routeDictionary[ObjectHelper.GetName(() => ItemsPerPage)] = ItemsPerPage;
                routeDictionary[ObjectHelper.GetName(() => OrderBy)] = OrderBy;
                routeDictionary[ObjectHelper.GetName(() => Desc)] = Desc;

                return routeDictionary;
            }
        }

        public int Start
        {
            get
            {
                return GetIntRequestObject(ObjectHelper.GetName(() => Start));
            }
        }

        public string OrderBy
        {
            get
            {
                object requestValue = GetRequestObject(ObjectHelper.GetName(() => OrderBy));
                if (requestValue != null)
                    return requestValue.ToString();

                return "Id";
            }
        }

        public bool Desc
        {
            get
            {
                bool value = false;
                object requestValue = GetRequestObject(ObjectHelper.GetName(() => Desc));
                if (requestValue != null)
                    bool.TryParse(requestValue.ToString(), out value);
                return value;
            }
        }

        public int ItemsPerPage
        {
            get
            {
                return GetIntRequestObject(ObjectHelper.GetName(() => ItemsPerPage), 10);
            }
        }

        protected object GetRequestObject(string key)
        {
            return ControllerHelper.ViewContext.HttpContext.Request[key];
        }

        protected int GetIntRequestObject(string key, int defaultValue = 0)
        {
            int value = defaultValue;
            object requestValue = GetRequestObject(key);
            if (requestValue != null)
                int.TryParse(requestValue.ToString(), out value);
            return value;
        }
    }
}