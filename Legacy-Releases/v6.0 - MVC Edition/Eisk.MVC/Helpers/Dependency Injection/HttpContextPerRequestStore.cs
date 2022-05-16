//===================================================================================
// Microsoft patterns & practices
//===================================================================================
// Copyright (c) Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===================================================================================
// The example companies, organizations, products, domain names,
// e-mail addresses, logos, people, places, and events depicted
// herein are fictitious.  No association with any real company,
// organization, product, domain name, email address, logo, person,
// places, or events is intended or should be inferred.
//===================================================================================
using System;
using System.Web;

namespace Eisk.Helpers
{
    public class HttpContextPerRequestStore : IPerRequestStore
    {
        public HttpContextPerRequestStore()
        {
            if (HttpContext.Current.ApplicationInstance != null)
            {
                // Note: We'd like to do this, but you cannot sign up for the EndRequest from
                // from this application instance as it is actually different than the one the
                // the EndRequest handler is actually invoked from.
                //HttpContext.Current.ApplicationInstance.EndRequest += this.EndRequestHandler;
            }
        }

        public object GetValue(object key)
        {
            return HttpContext.Current.Items[key];
        }

        public void SetValue(object key, object value)
        {
            HttpContext.Current.Items[key] = value;
        }

        public void RemoveValue(object key)
        {
            HttpContext.Current.Items.Remove(key);
        }

        private void EndRequestHandler(object sender, EventArgs e)
        {
            EventHandler handler = this.EndRequest;
            if (handler != null) handler(this, e);
        }

        public event EventHandler EndRequest;
    }
}