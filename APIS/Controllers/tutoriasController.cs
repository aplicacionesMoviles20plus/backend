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
    public class tutoriasController : ApiController
    {
        private TrabajoMovilesEntities db = new TrabajoMovilesEntities();

        // GET: api/tutorias
        public IEnumerable<tutoriaApp> Gettutorias()
        {
            IEnumerable<tutoriaApp> lista = from i in db.tutorias

                                           select new tutoriaApp
                                           {
                                             idtutoria=i.idtutoria,
                                             id_padre=i.id_padre,
                                             id_profesor=i.id_profesor,
                                             hora=i.hora,
                                             fecha=i.fecha,
                                             precio=i.precio,
                                             comentario=i.comentario,
                                             calificacion=i.calificacion,
                                             estado=i.estado,
                                             horafinal=i.horafinal,
                                             curso=i.curso
                                           };
            return lista;
        }

        // GET: api/tutorias/5
        [ResponseType(typeof(tutoria))]
        public IHttpActionResult Gettutoria(int id)
        {
            var tutoria = from i in db.tutorias
                                    where i.idtutoria == id
                          select new tutoriaApp
                          {
                              idtutoria = i.idtutoria,
                              id_padre = i.id_padre,
                              id_profesor = i.id_profesor,
                              hora = i.hora,
                              fecha = i.fecha,
                              precio = i.precio,
                              comentario = i.comentario,
                              calificacion = i.calificacion,
                              estado = i.estado,
                              horafinal = i.horafinal,
                              curso = i.curso
                          };
            if (tutoria == null)
            {
                return NotFound();
            }
            return Ok(tutoria.ToList());
        }

        // PUT: api/tutorias/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttutoria(int id, tutoria tutoria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tutoria.idtutoria)
            {
                return BadRequest();
            }

            db.Entry(tutoria).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tutoriaExists(id))
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

        // POST: api/tutorias
        [ResponseType(typeof(tutoria))]
        public IHttpActionResult Posttutoria(tutoria tutoria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tutorias.Add(tutoria);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tutoria.idtutoria }, tutoria);
        }

        // DELETE: api/tutorias/5
        [ResponseType(typeof(tutoria))]
        public IHttpActionResult Deletetutoria(int id)
        {
            tutoria tutoria = db.tutorias.Find(id);
            if (tutoria == null)
            {
                return NotFound();
            }

            db.tutorias.Remove(tutoria);
            db.SaveChanges();

            return Ok(tutoria);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tutoriaExists(int id)
        {
            return db.tutorias.Count(e => e.idtutoria == id) > 0;
        }
    }
}