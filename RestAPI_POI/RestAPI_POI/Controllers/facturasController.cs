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
    public class facturasController : ApiController
    {
        private MYNEGOCIOEntities db = new MYNEGOCIOEntities();

        // GET: api/facturas
        public IQueryable<facturas> Getfacturas()
        {
            return db.facturas;
        }

        // GET: api/facturas/5
        [ResponseType(typeof(facturas))]
        public IHttpActionResult Getfacturas(int id)
        {
            facturas facturas = db.facturas.Find(id);
            if (facturas == null)
            {
                return NotFound();
            }

            return Ok(facturas);
        }

        // PUT: api/facturas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putfacturas(int id, facturas facturas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != facturas.id_Facturas)
            {
                return BadRequest();
            }

            db.Entry(facturas).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!facturasExists(id))
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

        // POST: api/facturas
        [ResponseType(typeof(facturas))]
        public IHttpActionResult Postfacturas(facturas facturas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.facturas.Add(facturas);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = facturas.id_Facturas }, facturas);
        }

        // DELETE: api/facturas/5
        [ResponseType(typeof(facturas))]
        public IHttpActionResult Deletefacturas(int id)
        {
            facturas facturas = db.facturas.Find(id);
            if (facturas == null)
            {
                return NotFound();
            }

            db.facturas.Remove(facturas);
            db.SaveChanges();

            return Ok(facturas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool facturasExists(int id)
        {
            return db.facturas.Count(e => e.id_Facturas == id) > 0;
        }
    }
}