using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using API.Models;

namespace API.Controllers
{
    public class tutoriasController : ApiController
    {
        private TrabajoMovilesEntities db = new TrabajoMovilesEntities();

        // GET api/tutorias
        public IEnumerable<tutoriaApp> Gettutorias()
        {

            IEnumerable<tutoriaApp> lista = from i in db.tutorias

                                            select new tutoriaApp
                                            {
                                                idtutoria = i.idtutoria,
                                                id_padre = i.id_padre,
                                                id_servicio = i.id_servicio,
                                                id_horario = i.id_horario,
                                                hora = i.hora,
                                                fecha = i.fecha,
                                                precio = i.precio,
                                                comentario = i.comentario,
                                                calificacion = i.calificacion,
                                                estado = i.estado,
                                                curso = i.curso,
                                                numerohoras = i.numerohoras
                                            };
            return lista;
        }
        public IEnumerable<tutoriaApp> Gettutorias(int idpadre)
        {

            IEnumerable<tutoriaApp> lista = from i in db.tutorias
                                            where i.id_padre == idpadre
                                            select new tutoriaApp
                                            {
                                                idtutoria = i.idtutoria,
                                                id_padre = i.id_padre,
                                                id_servicio = i.id_servicio,
                                                id_horario = i.id_horario,
                                                hora = i.hora,
                                                fecha = i.fecha,
                                                precio = i.precio,
                                                comentario = i.comentario,
                                                calificacion = i.calificacion,
                                                estado = i.estado,
                                                curso = i.curso,
                                                numerohoras = i.numerohoras
                                            };
            return lista;
        }
        public IEnumerable<tutoriaApp> Gettutorias2(int idprofe)
        {

            IEnumerable<tutoriaApp> lista = from i in db.tutorias
                                            join z in db.profesor_horario on i.id_horario equals z.id_horario
                                            where z.id_profesor == idprofe
                                            select new tutoriaApp
                                            {
                                                idtutoria = i.idtutoria,
                                                id_padre = i.id_padre,
                                                id_servicio = i.id_servicio,
                                                id_horario = i.id_horario,
                                                hora = i.hora,
                                                fecha = i.fecha,
                                                precio = i.precio,
                                                comentario = i.comentario,
                                                calificacion = i.calificacion,
                                                estado = i.estado,
                                                curso = i.curso,
                                                numerohoras = i.numerohoras
                                            };
            return lista;
        }
        // GET api/tutorias/5
        public tutoriaApp Gettutoria(int id)
        {
            var tutoria = from i in db.tutorias
                          where i.idtutoria == id
                          select new tutoriaApp
                          {
                              idtutoria = i.idtutoria,
                              id_padre = i.id_padre,
                              id_servicio = i.id_servicio,
                              id_horario = i.id_horario,
                              hora = i.hora,
                              fecha = i.fecha,
                              precio = i.precio,
                              comentario = i.comentario,
                              calificacion = i.calificacion,
                              estado = i.estado,
                              curso = i.curso,
                              numerohoras = i.numerohoras
                          };
            if (tutoria == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return tutoria.FirstOrDefault() ;
        }

        // PUT api/tutorias/5
        public HttpResponseMessage Puttutoria(int id, tutoria tutoria)
        {
            if (ModelState.IsValid && id == tutoria.idtutoria)
            {
                db.Entry(tutoria).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
        private bool tutoriaExists(int id)
        {
            return db.tutorias.Count(e => e.idtutoria == id) > 0;
        }
        // POST api/tutorias
        public HttpResponseMessage Posttutoria(tutoria tutoria)
        {
            if (ModelState.IsValid)
            {
                if (tutoriaExists(tutoria.idtutoria))
                {
                    db.Entry(tutoria).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    db.tutorias.Add(tutoria);
                    db.SaveChanges();
                }

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, tutoria);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = tutoria.idtutoria }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/tutorias/5
        public HttpResponseMessage Deletetutoria(int id)
        {
            tutoria tutoria = db.tutorias.Find(id);
            if (tutoria == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.tutorias.Remove(tutoria);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, tutoria);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}