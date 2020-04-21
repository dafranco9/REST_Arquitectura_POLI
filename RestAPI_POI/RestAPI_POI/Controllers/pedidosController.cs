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
    public class pedidosController : ApiController
    {
        private MYNEGOCIOEntities db = new MYNEGOCIOEntities();

        // GET: api/pedidos
        public IQueryable<pedidos> Getpedidos()
        {
            return db.pedidos;
        }

        // GET: api/pedidos/5
        [ResponseType(typeof(pedidos))]
        public IHttpActionResult Getpedidos(int id)
        {
            pedidos pedidos = db.pedidos.Find(id);
            if (pedidos == null)
            {
                return NotFound();
            }

            return Ok(pedidos);
        }

        // PUT: api/pedidos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putpedidos(int id, pedidos pedidos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pedidos.id_Pedido)
            {
                return BadRequest();
            }

            db.Entry(pedidos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!pedidosExists(id))
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

        // POST: api/pedidos
        [ResponseType(typeof(pedidos))]
        public IHttpActionResult Postpedidos(pedidos pedidos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.pedidos.Add(pedidos);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pedidos.id_Pedido }, pedidos);
        }

        // DELETE: api/pedidos/5
        [ResponseType(typeof(pedidos))]
        public IHttpActionResult Deletepedidos(int id)
        {
            pedidos pedidos = db.pedidos.Find(id);
            if (pedidos == null)
            {
                return NotFound();
            }

            db.pedidos.Remove(pedidos);
            db.SaveChanges();

            return Ok(pedidos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool pedidosExists(int id)
        {
            return db.pedidos.Count(e => e.id_Pedido == id) > 0;
        }
    }
}