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
    public class tipos_documentoController : ApiController
    {
        private MYNEGOCIOEntities db = new MYNEGOCIOEntities();

        // GET: api/tipos_documento
        public IQueryable<tipos_documento> Gettipos_documento()
        {
            return db.tipos_documento;
        }

        // GET: api/tipos_documento/5
        [ResponseType(typeof(tipos_documento))]
        public IHttpActionResult Gettipos_documento(int id)
        {
            tipos_documento tipos_documento = db.tipos_documento.Find(id);
            if (tipos_documento == null)
            {
                return NotFound();
            }

            return Ok(tipos_documento);
        }

        // PUT: api/tipos_documento/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttipos_documento(int id, tipos_documento tipos_documento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipos_documento.id_TipoDocumento)
            {
                return BadRequest();
            }

            db.Entry(tipos_documento).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tipos_documentoExists(id))
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

        // POST: api/tipos_documento
        [ResponseType(typeof(tipos_documento))]
        public IHttpActionResult Posttipos_documento(tipos_documento tipos_documento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tipos_documento.Add(tipos_documento);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tipos_documento.id_TipoDocumento }, tipos_documento);
        }

        // DELETE: api/tipos_documento/5
        [ResponseType(typeof(tipos_documento))]
        public IHttpActionResult Deletetipos_documento(int id)
        {
            tipos_documento tipos_documento = db.tipos_documento.Find(id);
            if (tipos_documento == null)
            {
                return NotFound();
            }

            db.tipos_documento.Remove(tipos_documento);
            db.SaveChanges();

            return Ok(tipos_documento);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tipos_documentoExists(int id)
        {
            return db.tipos_documento.Count(e => e.id_TipoDocumento == id) > 0;
        }
    }
}