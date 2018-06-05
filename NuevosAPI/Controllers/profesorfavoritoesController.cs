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
    public class profesorfavoritoesController : ApiController
    {
        private TrabajoMovilesEntities db = new TrabajoMovilesEntities();

        // GET: api/profesorfavoritoes
        public IEnumerable<profesorfavoritoApp> Getprofesorfavoritoes()
        {
            IEnumerable<profesorfavoritoApp> lista = from i in db.profesorfavoritoes

                                                     select new profesorfavoritoApp
                                                     {
                                                         id = i.id,
                                                         id_padre = i.id_padre,
                                                         id_profesor = i.id_profesor
                                                     };
            return lista;
        }

        // GET: api/profesorfavoritoes/5
        [ResponseType(typeof(profesorfavorito))]
        public IHttpActionResult Getprofesorfavorito(int id)
        {
            var profesorfavoritoes = from i in db.profesorfavoritoes
                                     where i.id == id
                                     select new profesorfavoritoApp
                                     {
                                         id = i.id,
                                         id_padre = i.id_padre,
                                         id_profesor = i.id_profesor
                                     };
            if (profesorfavoritoes == null)
            {
                return NotFound();
            }
            return Ok(profesorfavoritoes.ToList());
        }

        // PUT: api/profesorfavoritoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putprofesorfavorito(int id, profesorfavorito profesorfavorito)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != profesorfavorito.id)
            {
                return BadRequest();
            }

            db.Entry(profesorfavorito).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!profesorfavoritoExists(id))
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

        // POST: api/profesorfavoritoes
        [ResponseType(typeof(profesorfavorito))]
        public IHttpActionResult Postprofesorfavorito(profesorfavorito profesorfavorito)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.profesorfavoritoes.Add(profesorfavorito);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = profesorfavorito.id }, profesorfavorito);
        }

        // DELETE: api/profesorfavoritoes/5
        [ResponseType(typeof(profesorfavorito))]
        public IHttpActionResult Deleteprofesorfavorito(int id)
        {
            profesorfavorito profesorfavorito = db.profesorfavoritoes.Find(id);
            if (profesorfavorito == null)
            {
                return NotFound();
            }

            db.profesorfavoritoes.Remove(profesorfavorito);
            db.SaveChanges();

            return Ok(profesorfavorito);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool profesorfavoritoExists(int id)
        {
            return db.profesorfavoritoes.Count(e => e.id == id) > 0;
        }
    }
}