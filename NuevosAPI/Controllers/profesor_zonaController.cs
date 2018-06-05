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
    public class profesor_zonaController : ApiController
    {
        private TrabajoMovilesEntities db = new TrabajoMovilesEntities();

        // GET: api/profesor_zona
        public IEnumerable<profesor_zonaApp> Getprofesor_zona()
        {

            IEnumerable<profesor_zonaApp> lista = from i in db.profesor_zona

                                                  select new profesor_zonaApp
                                                  {
                                                      id = i.id,
                                                      id_zona = i.id_zona,
                                                      id_profe = i.id_profe
                                                  };
            return lista;
        }

        // GET: api/profesor_zona/5
        [ResponseType(typeof(profesor_zona))]
        public IHttpActionResult Getprofesor_zona(int id)
        {
            var profesor_zona = from i in db.profesor_zona
                                where i.id == id
                                select new profesor_zonaApp
                                {
                                    id = i.id,
                                    id_profe = i.id_profe,
                                    id_zona = i.id_zona
                                };
            if (profesor_zona == null)
            {
                return NotFound();
            }
            return Ok(profesor_zona.ToList());
        }

        // PUT: api/profesor_zona/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putprofesor_zona(int id, profesor_zona profesor_zona)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != profesor_zona.id)
            {
                return BadRequest();
            }

            db.Entry(profesor_zona).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!profesor_zonaExists(id))
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

        // POST: api/profesor_zona
        [ResponseType(typeof(profesor_zona))]
        public IHttpActionResult Postprofesor_zona(profesor_zona profesor_zona)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.profesor_zona.Add(profesor_zona);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = profesor_zona.id }, profesor_zona);
        }

        // DELETE: api/profesor_zona/5
        [ResponseType(typeof(profesor_zona))]
        public IHttpActionResult Deleteprofesor_zona(int id)
        {
            profesor_zona profesor_zona = db.profesor_zona.Find(id);
            if (profesor_zona == null)
            {
                return NotFound();
            }

            db.profesor_zona.Remove(profesor_zona);
            db.SaveChanges();

            return Ok(profesor_zona);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool profesor_zonaExists(int id)
        {
            return db.profesor_zona.Count(e => e.id == id) > 0;
        }
    }
}