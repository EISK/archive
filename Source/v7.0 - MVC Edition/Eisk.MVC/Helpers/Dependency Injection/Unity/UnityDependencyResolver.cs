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
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.Practices.Unity;

namespace Eisk.Helpers
{
    public class UnityDependencyResolver : IDependencyResolver
    {
        private readonly IUnityContainer unity;

        public UnityDependencyResolver(IUnityContainer unity)
        {
            this.unity = unity;
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return this.unity.Resolve(serviceType);
            }
            catch (ResolutionFailedException)
            {
                // By definition of IDependencyResolver contract, this should return null if it cannot be found.
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return this.unity.ResolveAll(serviceType);
            }
            catch (ResolutionFailedException)
            {
                // By definition of IDependencyResolver contract, this should return null if it cannot be found.
                return null;
            }
        }
    }
}