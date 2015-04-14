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
using Eisk.BusinessLogicLayer;

namespace Eisk.TestHelpers
{
    /// <summary>
    /// Dispose method will be called for each test cases, for the test class members that inherits this class
    /// </summary>
    public class TestBusinessLogicLayerFactory:IDisposable
    {
        EmployeeBLL _employeeBLL;
        public EmployeeBLL EmployeeBLL
        {
            get
            {
                if (_employeeBLL == null)
                    _employeeBLL = new EmployeeBLL();
                return _employeeBLL;
            }
        }

        public void Dispose()
        {
            if (_employeeBLL != null)
              _employeeBLL.Dispose();
        }

    }

}