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
    public class profesor_gradoescolarController : ApiController
    {
        private TrabajoMovilesEntities db = new TrabajoMovilesEntities();

        // GET: api/profesor_gradoescolar
        public IEnumerable<profesor_gradoescolarApp> Getprofesor_gradoescolar()
        {
            IEnumerable<profesor_gradoescolarApp> lista = from i in db.profesor_gradoescolar

                                                          select new profesor_gradoescolarApp
                                                          {
                                                       id = i.id,
                                                       id_grado = i.id_grado,
                                                       id_profesor = i.id_profesor
                                                   };
            return lista;
        }

        // GET: api/profesor_gradoescolar/5
        [ResponseType(typeof(profesor_gradoescolar))]
        public IHttpActionResult Getprofesor_gradoescolar(int id)
        {
            var profesor_gradoescolar = from i in db.profesor_gradoescolar
                                 where i.id == id
                                 select new profesor_gradoescolarApp
                                 {
                                     id = i.id,
                                     id_grado = i.id_grado,
                                     id_profesor = i.id_profesor
                                 };
            if (profesor_gradoescolar == null)
            {
                return NotFound();
            }
            return Ok(profesor_gradoescolar.ToList());
        }

        // PUT: api/profesor_gradoescolar/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putprofesor_gradoescolar(int id, profesor_gradoescolar profesor_gradoescolar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != profesor_gradoescolar.id)
            {
                return BadRequest();
            }

            db.Entry(profesor_gradoescolar).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!profesor_gradoescolarExists(id))
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

        // POST: api/profesor_gradoescolar
        [ResponseType(typeof(profesor_gradoescolar))]
        public IHttpActionResult Postprofesor_gradoescolar(profesor_gradoescolar profesor_gradoescolar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.profesor_gradoescolar.Add(profesor_gradoescolar);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = profesor_gradoescolar.id }, profesor_gradoescolar);
        }

        // DELETE: api/profesor_gradoescolar/5
        [ResponseType(typeof(profesor_gradoescolar))]
        public IHttpActionResult Deleteprofesor_gradoescolar(int id)
        {
            profesor_gradoescolar profesor_gradoescolar = db.profesor_gradoescolar.Find(id);
            if (profesor_gradoescolar == null)
            {
                return NotFound();
            }

            db.profesor_gradoescolar.Remove(profesor_gradoescolar);
            db.SaveChanges();

            return Ok(profesor_gradoescolar);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool profesor_gradoescolarExists(int id)
        {
            return db.profesor_gradoescolar.Count(e => e.id == id) > 0;
        }
    }
}