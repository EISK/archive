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

using System;
using System.EnterpriseServices;

namespace Eisk.TestHelpers
{

    /// <summary>
    /// While doing test, you may want to generate the test schema and data prior to the test case execution, 
    /// let the test cases modify as required by them and finally turn the database back as it was before the test. 
    /// This is an excellent process to perform test operations on the live database without having any impact due to test executions. 
    /// This can be possible with very tiny effort by using COM+ Transaction, which has been implementing in TestHelperRoot.TransactionHelper class.
    /// </summary>
    public sealed class TransactionHelper
    {
        TransactionHelper() { }

        public static void TransactionStart()
        {
            // Enter a new transaction without inheriting from ServicedComponent
            Console.WriteLine("Attempting to enter a transactional context...");
            ServiceConfig config = new ServiceConfig();
            config.Transaction = TransactionOption.RequiresNew;
            ServiceDomain.Enter(config);
            Console.WriteLine("Attempt suceeded!");

        }

        public static void TransactionLeave()
        {
            Console.WriteLine("Attempting to Leave transactional context...");
            if (ContextUtil.IsInTransaction)
            {
                // Abort the running transaction
                ContextUtil.SetAbort();
            }
            ServiceDomain.Leave();
            Console.WriteLine("Left context!");
        }
    }

}