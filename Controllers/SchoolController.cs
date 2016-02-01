using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CySchool.Models;

namespace CySchool.Controllers
{
    public class SchoolController : Controller
    {
        //
        // GET: /School/
        #region Attribute
        ISchoolRepository _repository;
        #endregion

        #region Constructor

        public SchoolController() : this(new SchoolRepository()) { }

        public SchoolController(ISchoolRepository repository)
        {
            _repository = repository;
        }
        #endregion

        #region ActionMethods

        // Get Students
        public ActionResult Index(string Search)
        {
            ViewData["ControllerName"] = this.ToString();
            if (Search != null)
            {
                return View(_repository.GetStudentByName(Search));
            }
            return View("Index", _repository.GetAllStudent());
        }

        ////

        //// GET: /Employee/Details/5

        public ActionResult Details(int id = 0)
        {
            Student cnt = _repository.GetStudentById(id);
            return View("Details", cnt);
        }

        //

        // GET: /Employee/Create

        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student employeeToCreate)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repository.CreateNewStudent(employeeToCreate);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex);
                ViewData["CreateError"] = "Unable to create; view innerexception";
            }
            return View("Create");

        }

        public ActionResult Edit(int id = 0)
        {
            var employeeToEdit = _repository.GetStudentById(id);
            return View(employeeToEdit);

        }

        //

        // GET: /Employee/Edit/5

        [HttpPost]
        public ActionResult Edit(Student student)
        {
            Student cnt = _repository.GetStudentById(student.StudentID);
            try
            {
                if (TryUpdateModel(cnt))
                {
                    _repository.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    ViewData["EditError"] = ex.InnerException.ToString();
                else
                    ViewData["EditError"] = ex.ToString();
            }
#if DEBUG
            foreach (var modelState in ModelState.Values)
            {
                foreach (var error in modelState.Errors)
                {
                    if (error.Exception != null)
                    {
                        throw modelState.Errors[0].Exception;
                    }
                }
            }
#endif
            return View(cnt);
        }

        //

        // GET: /Employee/Delete/5
        public ActionResult Delete(int id)
        {
            var conToDel = _repository.GetStudentById(id);
            return View(conToDel);
        }

        //

        // POST: /Employee/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                _repository.DeleteStudent(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        #endregion

    }
}
