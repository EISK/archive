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

namespace Eisk.Helpers
{
    public class UnityPerRequestLifetimeManager : Microsoft.Practices.Unity.LifetimeManager, IDisposable
    {
        private readonly IPerRequestStore contextStore;
        private readonly Guid key = Guid.NewGuid();

        /// <summary>
        /// Initializes a new instance of UnityPerRequestLifetimeManager with a per-request store.
        /// </summary>
        /// <param name="contextStore"></param>
        public UnityPerRequestLifetimeManager(IPerRequestStore contextStore)
        {
            this.contextStore = contextStore;
            this.contextStore.EndRequest += this.EndRequestHandler;
        }

        public override object GetValue()
        {
            return this.contextStore.GetValue(this.key);
        }

        public override void SetValue(object newValue)
        {
            this.contextStore.SetValue(this.key, newValue);
        }

        public override void RemoveValue()
        {
            var oldValue = this.contextStore.GetValue(this.key);
            this.contextStore.RemoveValue(this.key);

            var disposable = oldValue as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            this.RemoveValue();
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void EndRequestHandler(object sender, EventArgs e)
        {
            this.RemoveValue();
        }
    }
}