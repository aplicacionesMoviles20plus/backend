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
using NuevosAPI.Models;

namespace NuevosAPI.Controllers
{
    public class hijoesController : ApiController
    {
        private TrabajoMovilesEntities db = new TrabajoMovilesEntities();

        // GET: api/hijoes
        public IEnumerable<hijoApp> Gethijoes()
        {
            IEnumerable<hijoApp> lista = from i in db.hijoes

                                         select new hijoApp
                                         {
                                             idhijo = i.idhijo,
                                             id_padre = i.id_padre,
                                             id_tutoria=i.id_tutoria,
                                             nombre=i.nombre,
                                             descripcion=i.descripcion
                                            };
            return lista;
        }

        // GET: api/hijoes/5
        [ResponseType(typeof(hijoApp))]
        public IHttpActionResult Gethijo(int id)
        {
            var hijo = from i in db.hijoes
                          where i.idhijo == id
                          select new hijoApp
                          {
                              idhijo = i.idhijo,
                              id_padre = i.id_padre,
                              id_tutoria = i.id_tutoria,
                              nombre = i.nombre,
                              descripcion = i.descripcion
                          };
            if (hijo == null)
            {
                return NotFound();
            }
            return Ok(hijo.FirstOrDefault());
        }

        // PUT: api/hijoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puthijo(int id, hijo hijo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hijo.idhijo)
            {
                return BadRequest();
            }

            db.Entry(hijo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!hijoExists(id))
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

        // POST: api/hijoes
        [ResponseType(typeof(hijo))]
        public IHttpActionResult Posthijo(hijo hijo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.hijoes.Add(hijo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = hijo.idhijo }, hijo);
        }

        // DELETE: api/hijoes/5
        [ResponseType(typeof(hijo))]
        public IHttpActionResult Deletehijo(int id)
        {
            hijo hijo = db.hijoes.Find(id);
            if (hijo == null)
            {
                return NotFound();
            }

            db.hijoes.Remove(hijo);
            db.SaveChanges();

            return Ok(hijo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool hijoExists(int id)
        {
            return db.hijoes.Count(e => e.idhijo == id) > 0;
        }
    }
}