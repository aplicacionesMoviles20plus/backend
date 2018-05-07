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
    public class profesor_cursoController : ApiController
    {
        private TrabajoMovilesEntities db = new TrabajoMovilesEntities();

        // GET: api/profesor_curso
        public IEnumerable<profesor_cursoApp> Getprofesor_curso()
        {
            IEnumerable<profesor_cursoApp> lista = from i in db.profesor_curso

                                           select new profesor_cursoApp
                                           {
                                              id=i.id,
                                              id_curso=i.id_curso,
                                              id_profesor=i.id_profesor
                                           };
            return lista;
        }

        // GET: api/profesor_curso/5
        [ResponseType(typeof(profesor_curso))]
        public IHttpActionResult Getprofesor_curso(int id)
        {
            var profesor_curso = from i in db.profesor_curso
                                    where i.id == id
                                    select new profesor_cursoApp
                                    {
                                        id = i.id,
                                        id_curso = i.id_curso,
                                        id_profesor = i.id_profesor
                                    };
            if (profesor_curso == null)
            {
                return NotFound();
            }
            return Ok(profesor_curso.ToList());
        }

        // PUT: api/profesor_curso/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putprofesor_curso(int id, profesor_curso profesor_curso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != profesor_curso.id)
            {
                return BadRequest();
            }

            db.Entry(profesor_curso).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!profesor_cursoExists(id))
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

        // POST: api/profesor_curso
        [ResponseType(typeof(profesor_curso))]
        public IHttpActionResult Postprofesor_curso(profesor_curso profesor_curso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.profesor_curso.Add(profesor_curso);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = profesor_curso.id }, profesor_curso);
        }

        // DELETE: api/profesor_curso/5
        [ResponseType(typeof(profesor_curso))]
        public IHttpActionResult Deleteprofesor_curso(int id)
        {
            profesor_curso profesor_curso = db.profesor_curso.Find(id);
            if (profesor_curso == null)
            {
                return NotFound();
            }

            db.profesor_curso.Remove(profesor_curso);
            db.SaveChanges();

            return Ok(profesor_curso);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool profesor_cursoExists(int id)
        {
            return db.profesor_curso.Count(e => e.id == id) > 0;
        }
    }
}