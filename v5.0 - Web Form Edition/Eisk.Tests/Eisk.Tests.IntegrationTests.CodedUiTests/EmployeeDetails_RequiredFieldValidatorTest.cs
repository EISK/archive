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
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using Eisk.CodedUiTestHelpers;


namespace Eisk.Tests.IntegrationTests.CodedUiTests
{
    [CodedUITest]
    public class EmployeeDetails_RequiredFieldValidatorTest:CodedUiTestBase
    {
        public EmployeeDetails_RequiredFieldValidatorTest()
        {
        }

        [TestMethod]
        [DeploymentItem("..\\Eisk.Tests\\Eisk.Tests.IntegrationTests.CodedUiTests\\App_Data\\CodedUITestSettings.xml")]
        [DataSource("MyXmlDataSource")]
        public void RequiredFieldValidatorTest_NoDataProvidedForRequiredFields_ShouldFireClientSideRequiredMessage()
        {
            //Data setup for url
            this.UIMap.Action_GoToEmployeeListingPageParams.UIBlankPageWindowsInteWindowUrl = testContextInstance.DataRow["EmployeeListingPage"].ToString();

            //Actions

            this.UIMap.Action_OpenBrowser();
            this.UIMap.Action_GoToEmployeeListingPage();
            this.UIMap.Action_ClickAddEmployeeButton();
            this.UIMap.Action_RemoveTheRequiredDataFieldsFromEmployeeDetails();
            this.UIMap.Action_ClickSaveMethodOnEmployeeDetails();

            //Assertions
            this.UIMap.Assert_ShouldShowFirstNameAsRequiredForEmptyFirstNameValue();

            //Actions
            this.UIMap.Action_CloseBrowserWindow();
        }

    }
}
