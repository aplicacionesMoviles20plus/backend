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
    public class serviciosController : ApiController
    {
        private TrabajoMovilesEntities db = new TrabajoMovilesEntities();

        // GET: api/servicios
        public IEnumerable<servicioApp> Getservicios()
        {
            IEnumerable<servicioApp> lista = from i in db.servicios

                                             select new servicioApp
                                             {
                                                 idservicio = i.idservicio,
                                                 tipodepago = i.tipodepago,
                                               fecha = i.fecha
                                           };
            return lista;
        }

        // GET: api/servicios/5
        [ResponseType(typeof(servicioApp))]
        public IHttpActionResult Getservicio(int id)
        {
            var servicioactual = from i in db.servicios
                                 where i.idservicio == id
                                    select new servicioApp
                                    {
                                        idservicio = i.idservicio,
                                        tipodepago = i.tipodepago,
                                        fecha = i.fecha
                                    };
            if (servicioactual == null)
            {
                return NotFound();
            }
            return Ok(servicioactual.ToList());
        }

        // PUT: api/servicios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putservicio(int id, servicio servicio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != servicio.idservicio)
            {
                return BadRequest();
            }

            db.Entry(servicio).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!servicioExists(id))
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

        // POST: api/servicios
        [ResponseType(typeof(servicio))]
        public IHttpActionResult Postservicio(servicio servicio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.servicios.Add(servicio);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = servicio.idservicio }, servicio);
        }

        // DELETE: api/servicios/5
        [ResponseType(typeof(servicio))]
        public IHttpActionResult Deleteservicio(int id)
        {
            servicio servicio = db.servicios.Find(id);
            if (servicio == null)
            {
                return NotFound();
            }

            db.servicios.Remove(servicio);
            db.SaveChanges();

            return Ok(servicio);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool servicioExists(int id)
        {
            return db.servicios.Count(e => e.idservicio == id) > 0;
        }
    }
}