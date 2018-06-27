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
    public class horariosController : ApiController
    {
        private TrabajoMovilesEntities db = new TrabajoMovilesEntities();

        // GET api/horarios
        public IEnumerable<horarioApp> Gethorarios()
        {
            IEnumerable<horarioApp> lista = from i in db.horarios

                                            select new horarioApp
                                            {
                                                idhorario = i.idhorario,
                                                horainicio = i.horainicio,
                                                horafin = i.horafin,
                                                dia = i.dia
                                            };
            return lista;
        }
        public IEnumerable<horarioApp> Gethorarios2(int idprofe)
        {

            IEnumerable<horarioApp> lista = from i in db.horarios
                                            join z in db.profesor_horario on i.idhorario equals z.id_horario
                                            where (z.id_profesor == idprofe)
                                            select new horarioApp
                                            {
                                                idhorario = i.idhorario,
                                                horainicio = i.horainicio,
                                                horafin = i.horafin,
                                                dia = i.dia
                                            };

            return lista;
        }

        // GET api/horarios/5
        public horarioApp Gethorario(int id)
        {
            var horario = from i in db.horarios
                          where i.idhorario == id
                          select new horarioApp
                          {
                              idhorario = i.idhorario,
                              horainicio = i.horainicio,
                              horafin = i.horafin,
                              dia = i.dia
                          };

            return horario.FirstOrDefault();
        }

        // PUT api/horarios/5
        public HttpResponseMessage Puthorario(int id, horario horario)
        {
            if (ModelState.IsValid && id == horario.idhorario)
            {
                db.Entry(horario).State = EntityState.Modified;

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

        // POST api/horarios
        public HttpResponseMessage Posthorario(horario horario)
        {
            if (ModelState.IsValid)
            {
                db.horarios.Add(horario);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, horario);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = horario.idhorario }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/horarios/5
        public HttpResponseMessage Deletehorario(int id)
        {
            horario horario = db.horarios.Find(id);
            if (horario == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.horarios.Remove(horario);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, horario);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}