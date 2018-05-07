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
using APIS.Models;

namespace APIS.Controllers
{
    public class avancesController : ApiController
    {
        private TrabajoMovilesEntities db = new TrabajoMovilesEntities();

        // GET: api/avances
        public IEnumerable<avanceApp> Getavances()
        {
            IEnumerable <avanceApp> lista = from i in db.avances
                                     
                                     select new avanceApp
                                     {
                                         idavance = i.idavance,
                                         id_tutoria = i.id_tutoria,
                                         descripcion = i.descripcion,
                                         fecha = i.fecha
                                     };
            return lista;
        }

        // GET: api/avances/5
        [ResponseType(typeof(avance))]
        public IHttpActionResult Getavance(int id)
        {
            var avanceCurrentUser = from i in db.avances
                                    where i.idavance == id
                                    select new avanceApp
                                    {
                                        idavance = i.idavance,
                                        id_tutoria = i.id_tutoria,
                                        descripcion = i.descripcion,
                                        fecha = i.fecha
                                    };
            if (avanceCurrentUser == null)
            {
                return NotFound();
            }
            return Ok(avanceCurrentUser.ToList());
                                
        }

        // PUT: api/avances/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putavance(int id,avance avance)
        {
            db.Configuration.ProxyCreationEnabled = false;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != avance.idavance)
            {
                return BadRequest();
            }

            db.Entry(avance).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!avanceExists(id))
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

        // POST: api/avances
        [ResponseType(typeof(avance))]
        public IHttpActionResult Postavance(avance avance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.avances.Add(avance);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = avance.idavance }, avance);
        }

        // DELETE: api/avances/5
        [ResponseType(typeof(avance))]
        public IHttpActionResult Deleteavance(int id)
        {
            avance avance = db.avances.Find(id);
            if (avance == null)
            {
                return NotFound();
            }

            db.avances.Remove(avance);
            db.SaveChanges();

            return Ok(avance);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool avanceExists(int id)
        {
            return db.avances.Count(e => e.idavance == id) > 0;
        }
    }
}