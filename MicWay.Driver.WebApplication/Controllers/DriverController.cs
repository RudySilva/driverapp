using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MicWay.Driver.WebApplication.Controllers
{
    public class DriverController : Controller
    {

        protected MicWay.Driver.Library.Service.BaseService<Library.Models.Driver> service = new Library.Service.BaseService<Library.Models.Driver>();
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
            var client = new HttpClient();
            HttpResponseMessage response = client.PostAsJsonAsync(serviceUrl + "/api/DriverAPI", driver).Result;
            response.EnsureSuccessStatusCode();
            return RedirectToAction("Index");
        }

        // GET: Driver/Edit/5
        public ActionResult Edit(int id)
        {
            var client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(serviceUrl + "/api/DriverAPI/" + id.ToString()).Result;
            response.EnsureSuccessStatusCode();

            Library.Models.Driver driver = response.Content.ReadAsAsync<Library.Models.Driver>().Result;
            return View(driver);

        }

        // POST: Driver/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, MicWay.Driver.Library.Models.Driver driver)
        {
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

    }
}
