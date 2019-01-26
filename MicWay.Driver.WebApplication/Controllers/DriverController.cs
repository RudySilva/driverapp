using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MicWay.Driver.WebApplication.Controllers
{
    public class DriverController : Controller
    {

        protected MicWay.Driver.Library.Service.BaseService<Library.Models.Driver> service = new Library.Service.BaseService<Library.Models.Driver>();

        // GET: Driver
        public ActionResult Index()
        {
            return View(this.service.List());
        }

        // GET: Driver/Details/5
        public ActionResult Details(int id)
        {

            return View(this.service.Find(id));
        }

        // GET: Driver/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Driver/Create
        [HttpPost]
        public ActionResult Create(MicWay.Driver.Library.Models.Driver driver)
        {
            try
            {
                // TODO: Add insert logic here
                this.service.Add(driver);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Driver/Edit/5
        public ActionResult Edit(int id)
        {
            return View(this.service.Find(id));
        }

        // POST: Driver/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, MicWay.Driver.Library.Models.Driver driver)
        {
            try
            {
                // TODO: Add update logic here

                this.service.Edit(driver);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Driver/Delete/5
        public ActionResult Delete(int id)
        {
            this.service.Remove(id);

            return RedirectToAction("Index");
        }

        // POST: Driver/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
