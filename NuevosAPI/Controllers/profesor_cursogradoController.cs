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
    public class profesor_cursogradoController : ApiController
    {
        private TrabajoMovilesEntities db = new TrabajoMovilesEntities();

        // GET: api/profesor_cursogrado
        public IEnumerable<profesor_cursogradoApp> Getprofesor_cursogrado()
        {
            IEnumerable<profesor_cursogradoApp> lista = from i in db.profesor_cursogrado

                                                   select new profesor_cursogradoApp
                                                   {
                                                       id = i.id,
                                                       id_cursogrado = i.id_cursogrado,
                                                       id_profesor = i.id_profesor
                                                   };
            return lista;

        }

        // GET: api/profesor_cursogrado/5
        [ResponseType(typeof(profesor_cursogradoApp))]
        public IHttpActionResult Getprofesor_cursogrado(int id)
        {
            var profesor_curso = from i in db.profesor_cursogrado
                                 where i.id == id
                                 select new profesor_cursogradoApp
                                 {
                                     id = i.id,
                                     id_cursogrado = i.id_cursogrado,
                                     id_profesor = i.id_profesor
                                 };
            if (profesor_curso == null)
            {
                return NotFound();
            }
            return Ok(profesor_curso.ToList());
        }

        // PUT: api/profesor_cursogrado/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putprofesor_cursogrado(int id, profesor_cursogrado profesor_cursogrado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != profesor_cursogrado.id)
            {
                return BadRequest();
            }

            db.Entry(profesor_cursogrado).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!profesor_cursogradoExists(id))
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

        // POST: api/profesor_cursogrado
        [ResponseType(typeof(profesor_cursogrado))]
        public IHttpActionResult Postprofesor_cursogrado(profesor_cursogrado profesor_cursogrado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.profesor_cursogrado.Add(profesor_cursogrado);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = profesor_cursogrado.id }, profesor_cursogrado);
        }

        // DELETE: api/profesor_cursogrado/5
        [ResponseType(typeof(profesor_cursogrado))]
        public IHttpActionResult Deleteprofesor_cursogrado(int id)
        {
            profesor_cursogrado profesor_cursogrado = db.profesor_cursogrado.Find(id);
            if (profesor_cursogrado == null)
            {
                return NotFound();
            }

            db.profesor_cursogrado.Remove(profesor_cursogrado);
            db.SaveChanges();

            return Ok(profesor_cursogrado);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool profesor_cursogradoExists(int id)
        {
            return db.profesor_cursogrado.Count(e => e.id == id) > 0;
        }
    }
}