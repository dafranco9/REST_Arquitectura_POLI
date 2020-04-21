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
using RestAPI_POI.Models;

namespace RestAPI_POI.Controllers
{
    public class formas_pagoController : ApiController
    {
        private MYNEGOCIOEntities db = new MYNEGOCIOEntities();

        // GET: api/formas_pago
        public IQueryable<formas_pago> Getformas_pago()
        {
            return db.formas_pago;
        }

        // GET: api/formas_pago/5
        [ResponseType(typeof(formas_pago))]
        public IHttpActionResult Getformas_pago(int id)
        {
            formas_pago formas_pago = db.formas_pago.Find(id);
            if (formas_pago == null)
            {
                return NotFound();
            }

            return Ok(formas_pago);
        }

        // PUT: api/formas_pago/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putformas_pago(int id, formas_pago formas_pago)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != formas_pago.id_Forma_pago)
            {
                return BadRequest();
            }

            db.Entry(formas_pago).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!formas_pagoExists(id))
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

        // POST: api/formas_pago
        [ResponseType(typeof(formas_pago))]
        public IHttpActionResult Postformas_pago(formas_pago formas_pago)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.formas_pago.Add(formas_pago);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = formas_pago.id_Forma_pago }, formas_pago);
        }

        // DELETE: api/formas_pago/5
        [ResponseType(typeof(formas_pago))]
        public IHttpActionResult Deleteformas_pago(int id)
        {
            formas_pago formas_pago = db.formas_pago.Find(id);
            if (formas_pago == null)
            {
                return NotFound();
            }

            db.formas_pago.Remove(formas_pago);
            db.SaveChanges();

            return Ok(formas_pago);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool formas_pagoExists(int id)
        {
            return db.formas_pago.Count(e => e.id_Forma_pago == id) > 0;
        }
    }
}