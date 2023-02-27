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
    public class tbl_Error_LogController : ApiController
    {
        private DB_EmployeeEntities db = new DB_EmployeeEntities();

        // GET: api/tbl_Error_Log
        public IQueryable<tbl_Error_Log> Gettbl_Error_Log()
        {
            return db.tbl_Error_Log;
        }

        // GET: api/tbl_Error_Log/5
        [ResponseType(typeof(tbl_Error_Log))]
        public IHttpActionResult Gettbl_Error_Log(int id)
        {
            tbl_Error_Log tbl_Error_Log = db.tbl_Error_Log.Find(id);
            if (tbl_Error_Log == null)
            {
                return NotFound();
            }

            return Ok(tbl_Error_Log);
        }

        // PUT: api/tbl_Error_Log/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttbl_Error_Log(int id, tbl_Error_Log tbl_Error_Log)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_Error_Log.Error_Id)
            {
                return BadRequest();
            }

            db.Entry(tbl_Error_Log).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_Error_LogExists(id))
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

        // POST: api/tbl_Error_Log
        [ResponseType(typeof(tbl_Error_Log))]
        public IHttpActionResult Posttbl_Error_Log(tbl_Error_Log tbl_Error_Log)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_Error_Log.Add(tbl_Error_Log);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_Error_Log.Error_Id }, tbl_Error_Log);
        }

        // DELETE: api/tbl_Error_Log/5
        [ResponseType(typeof(tbl_Error_Log))]
        public IHttpActionResult Deletetbl_Error_Log(int id)
        {
            tbl_Error_Log tbl_Error_Log = db.tbl_Error_Log.Find(id);
            if (tbl_Error_Log == null)
            {
                return NotFound();
            }

            db.tbl_Error_Log.Remove(tbl_Error_Log);
            db.SaveChanges();

            return Ok(tbl_Error_Log);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_Error_LogExists(int id)
        {
            return db.tbl_Error_Log.Count(e => e.Error_Id == id) > 0;
        }
    }
}