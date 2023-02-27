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
    public class tbl_User_MasterController : ApiController
    {
        private DB_EmployeeEntities db = new DB_EmployeeEntities();

        // GET: api/tbl_User_Master
        public IQueryable<tbl_User_Master> Gettbl_User_Master()
        {
            return db.tbl_User_Master;
        }

        // GET: api/tbl_User_Master/5
        [ResponseType(typeof(tbl_User_Master))]
        public IHttpActionResult Gettbl_User_Master(int id)
        {
            tbl_User_Master tbl_User_Master = db.tbl_User_Master.Find(id);
            if (tbl_User_Master == null)
            {
                return NotFound();
            }

            return Ok(tbl_User_Master);
        }

        // PUT: api/tbl_User_Master/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttbl_User_Master(int id, tbl_User_Master tbl_User_Master)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_User_Master.User_Id)
            {
                return BadRequest();
            }

            db.Entry(tbl_User_Master).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_User_MasterExists(id))
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

        // POST: api/tbl_User_Master
        [ResponseType(typeof(tbl_User_Master))]
        public IHttpActionResult Posttbl_User_Master(tbl_User_Master tbl_User_Master)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_User_Master.Add(tbl_User_Master);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_User_Master.User_Id }, tbl_User_Master);
        }

        // DELETE: api/tbl_User_Master/5
        [ResponseType(typeof(tbl_User_Master))]
        public IHttpActionResult Deletetbl_User_Master(int id)
        {
            tbl_User_Master tbl_User_Master = db.tbl_User_Master.Find(id);
            if (tbl_User_Master == null)
            {
                return NotFound();
            }

            db.tbl_User_Master.Remove(tbl_User_Master);
            db.SaveChanges();

            return Ok(tbl_User_Master);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_User_MasterExists(int id)
        {
            return db.tbl_User_Master.Count(e => e.User_Id == id) > 0;
        }
    }
}