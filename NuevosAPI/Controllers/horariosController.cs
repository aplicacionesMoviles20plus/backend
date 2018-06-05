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
    public class horariosController : ApiController
    {
        private TrabajoMovilesEntities db = new TrabajoMovilesEntities();

        // GET: api/horarios
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

        // GET: api/horarios/5
        [ResponseType(typeof(horario))]
        public IHttpActionResult Gethorario(int id)
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
            if (horario == null)
            {
                return NotFound();
            }
            return Ok(horario.ToList());
        }

        // PUT: api/horarios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puthorario(int id, horario horario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != horario.idhorario)
            {
                return BadRequest();
            }

            db.Entry(horario).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!horarioExists(id))
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

        // POST: api/horarios
        [ResponseType(typeof(horario))]
        public IHttpActionResult Posthorario(horario horario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.horarios.Add(horario);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = horario.idhorario }, horario);
        }

        // DELETE: api/horarios/5
        [ResponseType(typeof(horario))]
        public IHttpActionResult Deletehorario(int id)
        {
            horario horario = db.horarios.Find(id);
            if (horario == null)
            {
                return NotFound();
            }

            db.horarios.Remove(horario);
            db.SaveChanges();

            return Ok(horario);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool horarioExists(int id)
        {
            return db.horarios.Count(e => e.idhorario == id) > 0;
        }
    }
}