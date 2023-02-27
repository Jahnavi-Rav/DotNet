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
using ASPNET_WebAPI;

namespace ASPNET_WebAPI.Controllers
{
    public class tbl_Educational_DetailsController : ApiController
    {
        private DB_EmployeeEntities db = new DB_EmployeeEntities();

        // GET: api/tbl_Educational_Details
        public IQueryable<tbl_Educational_Details> Gettbl_Educational_Details()
        {
            return db.tbl_Educational_Details;
        }

        // GET: api/tbl_Educational_Details/5
        [ResponseType(typeof(tbl_Educational_Details))]
        public IHttpActionResult Gettbl_Educational_Details(int id)
        {
            tbl_Educational_Details tbl_Educational_Details = db.tbl_Educational_Details.Find(id);
            if (tbl_Educational_Details == null)
            {
                return NotFound();
            }

            return Ok(tbl_Educational_Details);
        }

        // PUT: api/tbl_Educational_Details/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttbl_Educational_Details(int id, tbl_Educational_Details tbl_Educational_Details)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_Educational_Details.Educational_Details_Id)
            {
                return BadRequest();
            }

            db.Entry(tbl_Educational_Details).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_Educational_DetailsExists(id))
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

        // POST: api/tbl_Educational_Details
        [ResponseType(typeof(tbl_Educational_Details))]
        public IHttpActionResult Posttbl_Educational_Details(tbl_Educational_Details tbl_Educational_Details)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_Educational_Details.Add(tbl_Educational_Details);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_Educational_Details.Educational_Details_Id }, tbl_Educational_Details);
        }

        // DELETE: api/tbl_Educational_Details/5
        [ResponseType(typeof(tbl_Educational_Details))]
        public IHttpActionResult Deletetbl_Educational_Details(int id)
        {
            tbl_Educational_Details tbl_Educational_Details = db.tbl_Educational_Details.Find(id);
            if (tbl_Educational_Details == null)
            {
                return NotFound();
            }

            db.tbl_Educational_Details.Remove(tbl_Educational_Details);
            db.SaveChanges();

            return Ok(tbl_Educational_Details);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_Educational_DetailsExists(int id)
        {
            return db.tbl_Educational_Details.Count(e => e.Educational_Details_Id == id) > 0;
        }
    }
}