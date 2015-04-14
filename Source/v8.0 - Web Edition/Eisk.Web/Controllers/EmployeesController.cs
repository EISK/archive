using Eisk.DataAccess;
using Eisk.Helpers;
using Eisk.Models;
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
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eisk.Controllers
{
    public class EmployeesController : Controller
    {
        DatabaseContext _dbContext;

        public EmployeesController(DatabaseContext databaseContext)
        {
            _dbContext = databaseContext;
        }

        public ViewResult Index()
        {
            var employees = _dbContext.EmployeeRepository;

            return View(employees.ToArray());
        }

        public ViewResult Listing()
        {
            return View(new GridViewModel(this, _dbContext.EmployeeRepository.Count(), "GridData"));
        }

        public ActionResult Details(int id)
        {
            Employee employee = _dbContext.EmployeeRepository.Find(id);

            if (employee == null)
            {
                this.ShowMessage("Sorry no employee found with id: " + id
                    + ". You've been redirected to the default page instead.", MessageType.Error);

                return RedirectToAction("Index");
            }

            return View(new EmployeeViewModel(employee, this));
        }

        public ViewResult Create()
        {
            return View("Edit", new EmployeeEditorModel());
        }

        [HttpPost]
        public ActionResult Create(Employee newEmployee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    LoadEmployeeImageToObject(newEmployee);
                    _dbContext.EmployeeRepository.Add(newEmployee);
                    _dbContext.SaveChanges();
                    this.ShowMessage("Employee created successfully", MessageType.Success);
                    return RedirectToAction("Edit", new { Id = newEmployee.Id });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.ToString());
                }
            }
            return View("Edit", new EmployeeEditorModel(newEmployee));
        }

        public ActionResult Edit(int id)
        {
            Employee employee = _dbContext.EmployeeRepository.Find(id);

            if (employee == null)
            {
                this.ShowMessage("Sorry no employee found with id: " + id
                    + ". You've been redirected to the default page instead.", MessageType.Error);

                return RedirectToAction("Index");
            }

            return View(new EmployeeEditorModel(employee));
        }

        [HttpPost]
        public ActionResult Edit(Employee existingEmployee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    LoadEmployeeImageToObject(existingEmployee);
                    _dbContext.Entry(existingEmployee).State = EntityState.Modified;
                    _dbContext.SaveChanges();
                    this.ShowMessage("Employee saved successfully", MessageType.Success);
                    return RedirectToAction("Details", new { Id = existingEmployee.Id });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(
                        string.Empty, ExceptionDude.FormatMessage(ex, true));
                }
            }
            return View(new EmployeeEditorModel(existingEmployee));
        }

        public void Delete(int id)
        {
            Employee employee = _dbContext.EmployeeRepository.Find(id);
            _dbContext.EmployeeRepository.Remove(employee);
            _dbContext.SaveChanges();
        }

        public void DeleteSelected(int[] ids)
        {
            foreach (int id in ids)
            {
                Employee employee = _dbContext.EmployeeRepository.Find(id);
                _dbContext.EmployeeRepository.Remove(employee);
            }
            _dbContext.SaveChanges();

        }

        #region Image Upload Related Methods

        public FileContentResult RenderImage(byte[] image)
        {
            if (image == null)
            {
                Image img = Image.FromFile(Server.MapPath("~/Images/noimage.gif"));
                MemoryStream ms = new System.IO.MemoryStream();
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                image = ms.ToArray();
            }

            return File(image, "image/gif");
        }

        public FileContentResult EmployeeImageFile(int id)
        {
            byte[] byteArray;

            Employee employee = _dbContext.EmployeeRepository.Find(id);

            byteArray = (employee == null || employee.Id == 0 ? null : employee.Photo);

            return RenderImage(byteArray);

        }

        public FileContentResult AjaxImageUpload()
        {
            System.Threading.Thread.Sleep(2000);
            Session["AjaxPhoto"] = GetImageFromUpload();
            return RenderImage((byte[])Session["AjaxPhoto"]);
        }

        public FileContentResult DiscardUploadededImage(int id)
        {
            Session["AjaxPhoto"] = null;
            return EmployeeImageFile(id);
        }

        byte[] GetImageFromUpload()
        {
            HttpPostedFileBase postedFile = null;

            if (Request != null && Request.Files != null)
                postedFile = Request.Files["imageUpload"];

            if (postedFile == null || postedFile.FileName == string.Empty)
                return null;

            using (System.Drawing.Image img =
                   System.Drawing.Image.FromStream(postedFile.InputStream))
            {

                //--Initialise the size of the array
                byte[] file = new byte[postedFile.InputStream.Length];

                //--Create a new BinaryReader and set the InputStream
                //-- for the Images InputStream to the
                //--beginning, as we create the img using a stream.
                BinaryReader reader =
                         new BinaryReader(postedFile.InputStream);
                postedFile.InputStream.Seek(0, SeekOrigin.Begin);

                //--Load the image binary.
                file = reader.ReadBytes((int)postedFile.
                              InputStream.Length);
                return file;
            }
        }

        void LoadEmployeeImageToObject(Employee employee)
        {
            if (Request != null)
            {
                byte[] uploadedImageFromFileControl = GetImageFromUpload();
                bool removeImage = Request["removeImage"] == "on";

                //retrieving image file from ajax upload
                if (Session["AjaxPhoto"] != null)
                {
                    employee.Photo = (byte[])Session["AjaxPhoto"];
                    //Clear Employee Ajax Photo, so that it couldn't make any impact to other employee operation
                    Session["AjaxPhoto"] = null;
                }
                //if ajax upload is found null, try html file input if see ifwe got any content
                else if (uploadedImageFromFileControl != null)
                    employee.Photo = uploadedImageFromFileControl;
                //if RemoveImage is checked, set employee photo as null
                else if (removeImage)
                    employee.Photo = null;
                else if (employee.Id != 0)//load image from db
                {
                    Employee oldEmployeeData = _dbContext.EmployeeRepository.Find(employee.Id);
                    _dbContext.Entry(oldEmployeeData).State = EntityState.Detached;
                    employee.Photo = oldEmployeeData.Photo;
                }
            }

        }

        #endregion
    }
}