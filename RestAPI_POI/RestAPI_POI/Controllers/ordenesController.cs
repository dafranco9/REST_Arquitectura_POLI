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
    public class ordenesController : ApiController
    {
        private MYNEGOCIOEntities db = new MYNEGOCIOEntities();

        // GET: api/ordenes
        public IQueryable<ordenes> Getordenes()
        {
            return db.ordenes;
        }

        // GET: api/ordenes/5
        [ResponseType(typeof(ordenes))]
        public IHttpActionResult Getordenes(int id)
        {
            ordenes ordenes = db.ordenes.Find(id);
            if (ordenes == null)
            {
                return NotFound();
            }

            return Ok(ordenes);
        }

        // PUT: api/ordenes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putordenes(int id, ordenes ordenes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ordenes.id_Orden)
            {
                return BadRequest();
            }

            db.Entry(ordenes).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ordenesExists(id))
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

        // POST: api/ordenes
        [ResponseType(typeof(ordenes))]
        public IHttpActionResult Postordenes(ordenes ordenes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ordenes.Add(ordenes);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ordenes.id_Orden }, ordenes);
        }

        // DELETE: api/ordenes/5
        [ResponseType(typeof(ordenes))]
        public IHttpActionResult Deleteordenes(int id)
        {
            ordenes ordenes = db.ordenes.Find(id);
            if (ordenes == null)
            {
                return NotFound();
            }

            db.ordenes.Remove(ordenes);
            db.SaveChanges();

            return Ok(ordenes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ordenesExists(int id)
        {
            return db.ordenes.Count(e => e.id_Orden == id) > 0;
        }
    }
}