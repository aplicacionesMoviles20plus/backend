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
    public class suscripcionsController : ApiController
    {
        private TrabajoMovilesEntities db = new TrabajoMovilesEntities();

        // GET: api/suscripcions
        public IEnumerable<suscripcionApp> Getsuscripcions()
        {
            IEnumerable<suscripcionApp> lista = from i in db.suscripcions

                                                select new suscripcionApp
                                                {
                                                    idsuscripcion = i.idsuscripcion,
                                                    fechainicio = i.fechainicio,
                                                    fechafin = i.fechafin,
                                                    id_profesor = i.id_profesor
                                                };
            return lista;
        }

        // GET: api/suscripcions/5
        [ResponseType(typeof(suscripcionApp))]
        public IHttpActionResult Getsuscripcion(int id)
        {
            var suscripcon = from i in db.suscripcions
                             where i.idsuscripcion == id
                             select new suscripcionApp
                             {
                                 idsuscripcion = i.idsuscripcion,
                                 fechainicio = i.fechainicio,
                                 fechafin = i.fechafin,
                                 id_profesor = i.id_profesor
                             };
            if (suscripcon == null)
            {
                return NotFound();
            }
            return Ok(suscripcon.ToList());
        }

        // PUT: api/suscripcions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putsuscripcion(int id, suscripcion suscripcion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != suscripcion.idsuscripcion)
            {
                return BadRequest();
            }

            db.Entry(suscripcion).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!suscripcionExists(id))
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

        // POST: api/suscripcions
        [ResponseType(typeof(suscripcion))]
        public IHttpActionResult Postsuscripcion(suscripcion suscripcion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.suscripcions.Add(suscripcion);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = suscripcion.idsuscripcion }, suscripcion);
        }

        // DELETE: api/suscripcions/5
        [ResponseType(typeof(suscripcion))]
        public IHttpActionResult Deletesuscripcion(int id)
        {
            suscripcion suscripcion = db.suscripcions.Find(id);
            if (suscripcion == null)
            {
                return NotFound();
            }

            db.suscripcions.Remove(suscripcion);
            db.SaveChanges();

            return Ok(suscripcion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool suscripcionExists(int id)
        {
            return db.suscripcions.Count(e => e.idsuscripcion == id) > 0;
        }
    }
}