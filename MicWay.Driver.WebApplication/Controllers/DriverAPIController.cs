using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MicWay.Driver.Library.Models;
using MicWay.Driver.Library.Repository;

namespace MicWay.Driver.WebApplication.Controllers
{
    public class DriverAPIController : ApiController
    {
        private DriverContext db = new DriverContext();



        // GET: api/DriverAPI
        public IQueryable<MicWay.Driver.Library.Models.Driver> GetDriver()
        {
            return db.Driver;
        }

        // GET: api/DriverAPI/5
        [ResponseType(typeof(MicWay.Driver.Library.Models.Driver))]
        public IHttpActionResult GetDriver(int id)
        {
            MicWay.Driver.Library.Models.Driver driver = db.Driver.Find(id);
            if (driver == null)
            {
                return NotFound();
            }

            return Ok(driver);
        }

        // PUT: api/DriverAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDriver(int id, MicWay.Driver.Library.Models.Driver driver)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != driver.Id)
            {
                return BadRequest();
            }

            db.Entry(driver).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DriverExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/DriverAPI
        [ResponseType(typeof(MicWay.Driver.Library.Models.Driver))]
        public IHttpActionResult PostDriver(MicWay.Driver.Library.Models.Driver driver)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Driver.Add(driver);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = driver.Id }, driver);
        }

        // DELETE: api/DriverAPI/5
        [ResponseType(typeof(MicWay.Driver.Library.Models.Driver))]
        public IHttpActionResult DeleteDriver(int id)
        {
            MicWay.Driver.Library.Models.Driver driver = db.Driver.Find(id);
            if (driver == null)
            {
                return NotFound();
            }

            db.Driver.Remove(driver);
            db.SaveChanges();

            return Ok(driver);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DriverExists(int id)
        {
            return db.Driver.Count(e => e.Id == id) > 0;
        }
    }
}