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
namespace Eisk.Helpers
{
    /// <summary>
    /// The UnityHttpContextPerRequestLifetimeManager exists solely to make it easier
    /// to configure the per-request lifetime manager in a configuration file.
    /// </summary>
    /// <remarks>
    /// An alternative approach would be to use a type converter to convert the 
    /// configuration string and new up a <see cref="UnityPerRequestLifetimeManager"/>
    /// from this type converter.
    /// </remarks>
    public class UnityHttpContextPerRequestLifetimeManager : UnityPerRequestLifetimeManager
    {
        public UnityHttpContextPerRequestLifetimeManager() : base(new HttpContextPerRequestStore())
        {
        }
    }
}