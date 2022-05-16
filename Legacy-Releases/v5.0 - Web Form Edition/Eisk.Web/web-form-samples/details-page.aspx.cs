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
using System.Web.UI.WebControls;
using Eisk.Helpers;
using Eisk.BusinessEntities;
using System.Web;

public partial class Details_Page : System.Web.UI.Page
{
    
    #region "Select handlers"

    protected void OdsEmployeeDetails_Selecting(object sender, ObjectDataSourceMethodEventArgs e)
    {
        string editMode = Page.RouteData.Values["edit_mode"] as string;

        if (editMode == "view")
            formViewEmployee.ChangeMode(FormViewMode.ReadOnly);
        else if (editMode == "edit")
            formViewEmployee.ChangeMode(FormViewMode.Edit);
        else if (editMode == "new")
            formViewEmployee.ChangeMode(FormViewMode.Insert);
        else
            throw new InvalidOperationException("Invalid Edit Mode.");

        if (formViewEmployee.CurrentMode == FormViewMode.Insert)
            e.Cancel = true;
        
    }

    #endregion

    #region "Basic Event Handlers"

    protected void formViewEmployee_DataBound(object sender, EventArgs e)
    {
        Page.Title = formViewEmployee.CurrentMode == FormViewMode.Insert ? "New Employee " : ((Employee)formViewEmployee.DataItem).FirstName + " " + ((Employee)formViewEmployee.DataItem).LastName;
    }

    protected void ButtonSave_Click(object sender, EventArgs e)
    {
        if (formViewEmployee.CurrentMode == FormViewMode.Insert)
        {
            formViewEmployee.InsertItem(true);
        }
        else
        {
            formViewEmployee.UpdateItem(true);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack && Session["ShowInsertSuccess"] != null)
        {
            ltlMessage.Text = MessageFormatter.GetFormattedSuccessMessage("Insert successful");
            Session["ShowInsertSuccess"] = null;
        }
    }
    
    #endregion

    #region "Insert handlers"

    protected void FormViewEmployee_ItemInserting(object sender, FormViewInsertEventArgs e)
    {
        if (!String.IsNullOrEmpty(((FileUpload)this.formViewEmployee.FindControl("fuPhotoUpload")).FileName))
            e.Values["photo"] = ((FileUpload)this.formViewEmployee.FindControl("fuPhotoUpload")).FileBytes;
    }

    protected void OdsEmployeeDetails_Inserted(object sender, System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs e)
    {
        int result = Convert.ToInt32(e.ReturnValue, System.Globalization.CultureInfo.CurrentCulture.NumberFormat);

        if (result != 0)
        {
            Session["ShowInsertSuccess"] = true;
            Response.RedirectToRoute(new { edit_mode = "edit", employee_id = result.ToString() });
        }
    }

    protected void formViewEmployee_ItemInserted(object sender, FormViewInsertedEventArgs e)
    {
        if (e.Exception != null)
        {
            // Display a user-friendly message 
            ltlMessage.Text = ExceptionManager.DoLogAndGetFriendlyMessageForException(e.Exception);
            // Indicate that the exception has been handled 
            e.ExceptionHandled = true;
            // Keep the row in edit mode 
            e.KeepInInsertMode = true;
        }
    }

    #endregion

    #region "Update handlers"

    protected void FormViewEmployee_ItemUpdating(object sender, FormViewUpdateEventArgs e)
    {

        if (!String.IsNullOrEmpty(((FileUpload)this.formViewEmployee.FindControl("fuPhotoUpload")).FileName))
            e.NewValues["photo"] = ((FileUpload)this.formViewEmployee.FindControl("fuPhotoUpload")).FileBytes;
        else
        {
            if ((this.formViewEmployee.FindControl("chkRemoveOldImage") as CheckBox).Checked)
                e.NewValues["photo"] = null;
            else
                e.NewValues["photo"] = new Eisk.BusinessLogicLayer.EmployeeBLL().GetEmployeeByEmployeeId(int.Parse(RouteData.Values["employee_id"].ToString())).Photo;
        }
    }

    protected void formViewEmployee_ItemUpdated(object sender, FormViewUpdatedEventArgs e)
    {
        if (e.Exception != null)
        {
            // Display a user-friendly message 
            ltlMessage.Text = ExceptionManager.DoLogAndGetFriendlyMessageForException(e.Exception);
            // Indicate that the exception has been handled 
            e.ExceptionHandled = true;
            // Keep the current UI in edit mode 
            e.KeepInEditMode = true;
        }
        else
            ltlMessage.Text = MessageFormatter.GetFormattedSuccessMessage("Update successful");
    }
    
    #endregion
   
}
