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

namespace Eisk.TestHelpers
{
   /// <summary>
   /// Design and Architecture: Mohammad Ashraful Alam [http://www.ashraful.net]
   /// </summary>
    public abstract class DataAccessLayerBaseTest : TestBusinessLogicLayerFactory
    {
        [TestInitialize()]
        public void MyTestInitialize()
        {
            TransactionHelper.TransactionStart();
            TestHelpers.TestDataHelper.CleanTestData();
            TestHelpers.TestDataHelper.GenerateTestData();
        }

        [TestCleanup()]
        public void MyTestCleanup()
        {
            
            TransactionHelper.TransactionLeave();
            //Dispose() method is called automatically
        }

    }
}

