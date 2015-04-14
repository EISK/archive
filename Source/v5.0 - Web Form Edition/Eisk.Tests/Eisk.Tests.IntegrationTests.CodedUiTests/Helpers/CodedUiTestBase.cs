/****************** Copyright Notice *****************
 
This code is licensed under Microsoft Public License (Ms-PL). 
You are free to use, modify and distribute any portion of this code. 
The only requirement to do that, you need to keep the developer name, as provided below to recognize and encourage original work:

=======================================================
   
Architecture Designed and Implemented By:
Mohammad Ashraful Alam
Microsoft Most Valuable Professional, ASP.NET 2007 – 2011
Twitter: http://twitter.com/AshrafulAlam | Blog: http://blog.ashraful.net | Portfolio: http://www.ashraful.net
   
*******************************************************/

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Eisk.Tests.IntegrationTests.CodedUiTests;

namespace Eisk.CodedUiTestHelpers
{
   /// <summary>
   /// Design and Architecture: Mohammad Ashraful Alam [http://www.ashraful.net]
   /// </summary>
    public abstract class CodedUiTestBase
    {
        public UIMap UIMap
        {
            get
            {
                if ((this.map == null))
                {
                    this.map = new UIMap();
                }

                return this.map;
            }
        }

        private UIMap map;

        protected TestContext testContextInstance;

        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        //Use TestInitialize to run code before running each test
        [TestInitialize()]
        public void MyTestInitialize()
        {
            //TransactionHelper.TransactionStart();
            TestHelpers.TestDataHelper.CleanTestData();
            TestHelpers.TestDataHelper.GenerateTestData();
        }

        //Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            //TransactionHelper.TransactionLeave();
        }

    }
}

