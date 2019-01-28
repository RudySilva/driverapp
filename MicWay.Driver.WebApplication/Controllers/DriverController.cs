using System;
using System.Collections.Generic;
<<<<<<< HEAD
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
=======
using System.Linq;
>>>>>>> 1018125f4e997d39e4bf3a495816a6e9f9ba813c
using System.Web;
using System.Web.Mvc;

namespace MicWay.Driver.WebApplication.Controllers
{
    public class DriverController : Controller
    {

        protected MicWay.Driver.Library.Service.BaseService<Library.Models.Driver> service = new Library.Service.BaseService<Library.Models.Driver>();
<<<<<<< HEAD
        string serviceUrl = ConfigurationManager.AppSettings["ServiceUrl"].ToString();

        // GET: Driver
        public async Task<ActionResult> Index()
        {
            var client = new HttpClient();
            var response = await client.GetAsync(serviceUrl + "/api/DriverAPI");
            var driver = await response.Content.ReadAsAsync<IEnumerable<Library.Models.Driver>>();
            return View(driver);
        }

        // GET: Driver/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var client = new HttpClient();
            var response = await client.GetAsync(serviceUrl + "/api/DriverAPI/" + id );
            var driver = await response.Content.ReadAsAsync<Library.Models.Driver>();
            return View(driver);
=======

        // GET: Driver
        public ActionResult Index()
        {
            return View(this.service.List());
        }

        // GET: Driver/Details/5
        public ActionResult Details(int id)
        {

            return View(this.service.Find(id));
>>>>>>> 1018125f4e997d39e4bf3a495816a6e9f9ba813c
        }

        // GET: Driver/Create
        public ActionResult Create()
        {
            return View();
        }

<<<<<<< HEAD
        
=======
>>>>>>> 1018125f4e997d39e4bf3a495816a6e9f9ba813c
        // POST: Driver/Create
        [HttpPost]
        public ActionResult Create(MicWay.Driver.Library.Models.Driver driver)
        {
<<<<<<< HEAD
            var client = new HttpClient();
            HttpResponseMessage response = client.PostAsJsonAsync(serviceUrl + "/api/DriverAPI", driver).Result;
            response.EnsureSuccessStatusCode();
            return RedirectToAction("Index");
=======
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
>>>>>>> 1018125f4e997d39e4bf3a495816a6e9f9ba813c
        }

        // GET: Driver/Edit/5
        public ActionResult Edit(int id)
        {
<<<<<<< HEAD
            var client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(serviceUrl + "/api/DriverAPI/" + id.ToString()).Result;
            response.EnsureSuccessStatusCode();

            Library.Models.Driver driver = response.Content.ReadAsAsync<Library.Models.Driver>().Result;
            return View(driver);

=======
            return View(this.service.Find(id));
>>>>>>> 1018125f4e997d39e4bf3a495816a6e9f9ba813c
        }

        // POST: Driver/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, MicWay.Driver.Library.Models.Driver driver)
        {
<<<<<<< HEAD
            var client = new HttpClient();
            HttpResponseMessage response = client.PutAsJsonAsync(serviceUrl + "/api/DriverAPI/" + id.ToString(), driver).Result;
            response.EnsureSuccessStatusCode();
            return RedirectToAction("Index");
        }

        // GET: Driver/Delete/5

        public ActionResult Delete(int id)
        {
            var client = new HttpClient();
            HttpResponseMessage response = client.DeleteAsync(serviceUrl + "/api/DriverAPI/" + id.ToString()).Result;
            response.EnsureSuccessStatusCode();
            return RedirectToAction("Index");
        }

=======
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
>>>>>>> 1018125f4e997d39e4bf3a495816a6e9f9ba813c
    }
}
