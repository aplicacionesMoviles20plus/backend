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
    public class zonasController : ApiController
    {
        private TrabajoMovilesEntities db = new TrabajoMovilesEntities();

        // GET: api/zonas
        public IEnumerable<zonaApp> Getzonas()
        {
            IEnumerable<zonaApp> zonas = from c in db.zonas
                                         select new zonaApp
                                         {
                                             idzona = c.idzona,
                                             zona1 = c.zona1
                                         };
            return zonas;
            
            //return Json(zonas.List());

        }
        // GET: api/zonas/5
        [ResponseType(typeof(zonaApp))]
        public IHttpActionResult Getzona(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            IEnumerable<zonaApp> card = from c in db.zonas
                                        where c.idzona == id
                                        select new zonaApp
                                        {
                                            idzona = c.idzona,
                                            zona1 = c.zona1
                                        };
            return Ok(card.FirstOrDefault());
        }

        // PUT: api/zonas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putzona(int id, zona zona)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != zona.idzona)
            {
                return BadRequest();
            }

            db.Entry(zona).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!zonaExists(id))
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

        // POST: api/zonas
        [ResponseType(typeof(zona))]
        public IHttpActionResult Postzona(zona zona)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.zonas.Add(zona);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = zona.idzona }, zona);
        }

        // DELETE: api/zonas/5
        [ResponseType(typeof(zona))]
        public IHttpActionResult Deletezona(int id)
        {
            zona zona = db.zonas.Find(id);
            if (zona == null)
            {
                return NotFound();
            }

            db.zonas.Remove(zona);
            db.SaveChanges();

            return Ok(zona);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool zonaExists(int id)
        {
            return db.zonas.Count(e => e.idzona == id) > 0;
        }
    }
}