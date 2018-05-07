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
    public class cursoesController : ApiController
    {
        private TrabajoMovilesEntities db = new TrabajoMovilesEntities();

        // GET: api/cursoes
        public IEnumerable<cursoApp> Getcursoes()
        {

            IEnumerable<cursoApp> lista = from i in db.cursoes

                                          select new cursoApp
                                          {
                                              idcurso = i.idcurso,
                                              nombre = i.nombre,
                                              contenido = i.contenido
                                               
                                           };
            return lista;
        }

        // GET: api/cursoes/5
        [ResponseType(typeof(curso))]
        public IHttpActionResult Getcurso(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            IEnumerable<cursoApp> curso = from i in db.cursoes
                                         where i.idcurso == id
                                         select new cursoApp
                                         {
                                             idcurso = i.idcurso,
                                             nombre = i.nombre,
                                             contenido = i.contenido

                                         };
            return Ok(curso.FirstOrDefault());
        }

        // PUT: api/cursoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putcurso(int id, curso curso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != curso.idcurso)
            {
                return BadRequest();
            }

            db.Entry(curso).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!cursoExists(id))
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

        // POST: api/cursoes
        [ResponseType(typeof(curso))]
        public IHttpActionResult Postcurso(curso curso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.cursoes.Add(curso);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = curso.idcurso }, curso);
        }

        // DELETE: api/cursoes/5
        [ResponseType(typeof(curso))]
        public IHttpActionResult Deletecurso(int id)
        {
            curso curso = db.cursoes.Find(id);
            if (curso == null)
            {
                return NotFound();
            }

            db.cursoes.Remove(curso);
            db.SaveChanges();

            return Ok(curso);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool cursoExists(int id)
        {
            return db.cursoes.Count(e => e.idcurso == id) > 0;
        }
    }
}