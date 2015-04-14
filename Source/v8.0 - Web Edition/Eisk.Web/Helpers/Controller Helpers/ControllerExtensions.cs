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
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eisk.Helpers
{
    public static class ControllerExtensions
    {
        //validation related extension

        public static List<ValidationResult> FireValidationForModel(this Controller controller, object @object)
        {
            var validationContext = new ValidationContext(@object, null, null);
            var validationResults = new List<ValidationResult>();

            Validator.TryValidateObject(@object, validationContext, validationResults, true);

            foreach (var validationResult in validationResults)
            {
                if (validationResult.MemberNames.Count() > 0)
                {
                    foreach (string memberName in validationResult.MemberNames)
                        controller.ModelState.AddModelError(memberName, validationResult.ErrorMessage);
                }
                else
                    controller.ModelState.AddModelError(string.Empty, validationResult.ErrorMessage);
            }

            return validationResults;
        }

        //messsage extensions

        public static void ShowMessage(this Controller controller, string message, MessageType messageType = MessageType.Info, bool showAfterRedirect = true)
        {
            var messageTypeKey = messageType.ToString();
            if (showAfterRedirect)
            {
                controller.TempData[messageTypeKey] = message;
            }
            else
            {
                controller.ViewData[messageTypeKey] = message;
            }
        }

        public static void ShowModelStateErrors(this Controller controller, bool showAfterRedirect = false)
        {
            foreach (ModelError error in controller.GetModelErrors())
            {
                controller.ShowMessage(error.ErrorMessage, MessageType.Error, showAfterRedirect);
            }
        }

        //error related extensions

        public static ModelErrorCollection GetModelErrors(this Controller controller)
        {
            ModelErrorCollection errors = new ModelErrorCollection();

            foreach (ModelState modelState in controller.ViewData.ModelState.Values)
            {
                foreach (ModelError error in modelState.Errors)
                {
                    errors.Add(error);
                }
            }

            return errors;
        }

        public static bool IsErrorAvalilableIn(this Controller controller, string errorMessage)
        {
            return IsErrorAvalilableIn(controller.GetModelErrors(), errorMessage);
        }

        static bool IsErrorAvalilableIn(ModelErrorCollection errors, string errorMessage)
        {
            foreach (var error in errors)
                if (error.ErrorMessage == errorMessage)
                    return true;
            return false;
        }
    }
}
