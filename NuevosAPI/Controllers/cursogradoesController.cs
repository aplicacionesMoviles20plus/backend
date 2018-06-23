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
    public class cursogradoesController : ApiController
    {
        private TrabajoMovilesEntities db = new TrabajoMovilesEntities();

        // GET: api/cursogradoes
        public IEnumerable<cursogradoApp> Getcursogradoes()
        {

            IEnumerable<cursogradoApp> lista = from i in db.cursogradoes

                                               select new cursogradoApp
                                               {
                                                   idcursogrado = i.idcursogrado,
                                                   nombre = i.nombre,
                                                   contenido = i.contenido,
                                                   grado = i.grado

                                          };
            return lista;
        }
        public IEnumerable<cursogradoApp> Getcursogradoes2(int idprofe)
        {

            IEnumerable<cursogradoApp> lista = from i in db.cursogradoes
                                             join z in db.profesor_cursogrado on i.idcursogrado equals z.id_cursogrado
                                             where (z.id_profesor == idprofe)
                                             select new cursogradoApp
                                             {
                                                 idcursogrado = i.idcursogrado,
                                                 nombre = i.nombre,
                                                 contenido = i.contenido,
                                                 grado = i.grado
                                             };

            return lista;
        }
        // GET: api/cursogradoes/5
        [ResponseType(typeof(cursogradoApp))]
        public IHttpActionResult Getcursogrado(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            IEnumerable<cursogradoApp> curso = from i in db.cursogradoes
                                          where i.idcursogrado == id
                                          select new cursogradoApp
                                          {

                                              idcursogrado = i.idcursogrado,
                                              nombre = i.nombre,
                                              contenido = i.contenido,
                                              grado = i.grado

                                          };
            return Ok(curso.FirstOrDefault());
        }

        // PUT: api/cursogradoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putcursogrado(int id, cursogrado cursogrado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cursogrado.idcursogrado)
            {
                return BadRequest();
            }

            db.Entry(cursogrado).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!cursogradoExists(id))
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

        // POST: api/cursogradoes
        [ResponseType(typeof(cursogrado))]
        public IHttpActionResult Postcursogrado(cursogrado cursogrado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.cursogradoes.Add(cursogrado);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cursogrado.idcursogrado }, cursogrado);
        }

        // DELETE: api/cursogradoes/5
        [ResponseType(typeof(cursogrado))]
        public IHttpActionResult Deletecursogrado(int id)
        {
            cursogrado cursogrado = db.cursogradoes.Find(id);
            if (cursogrado == null)
            {
                return NotFound();
            }

            db.cursogradoes.Remove(cursogrado);
            db.SaveChanges();

            return Ok(cursogrado);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool cursogradoExists(int id)
        {
            return db.cursogradoes.Count(e => e.idcursogrado == id) > 0;
        }
    }
}