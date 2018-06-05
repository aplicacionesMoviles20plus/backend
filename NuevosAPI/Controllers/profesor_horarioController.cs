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
    public class profesor_horarioController : ApiController
    {
        private TrabajoMovilesEntities db = new TrabajoMovilesEntities();

        // GET: api/profesor_horario
        public IEnumerable<profesor_horarioApp> Getprofesor_horario()
        {
            IEnumerable<profesor_horarioApp> lista = from i in db.profesor_horario

                                                     select new profesor_horarioApp
                                                     {
                                                         id = i.id,
                                                         id_horario = i.id_horario,
                                                         id_profesor = i.id_profesor,
                                                         estado=i.estado,
                                                         fecha=i.fecha
                                                     };
            return lista;
        }

        // GET: api/profesor_horario/5
        [ResponseType(typeof(profesor_horario))]
        public IHttpActionResult Getprofesor_horario(int id)
        {
            var profesor_horario = from i in db.profesor_horario
                                   where i.id == id
                                   select new profesor_horarioApp
                                   {
                                       id = i.id,
                                       id_horario = i.id_horario,
                                       id_profesor = i.id_profesor,
                                       estado = i.estado,
                                       fecha=i.fecha
                                   };
            if (profesor_horario == null)
            {
                return NotFound();
            }
            return Ok(profesor_horario.ToList());
        }

        // PUT: api/profesor_horario/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putprofesor_horario(int id, profesor_horario profesor_horario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != profesor_horario.id)
            {
                return BadRequest();
            }

            db.Entry(profesor_horario).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!profesor_horarioExists(id))
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

        // POST: api/profesor_horario
        [ResponseType(typeof(profesor_horario))]
        public IHttpActionResult Postprofesor_horario(profesor_horario profesor_horario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.profesor_horario.Add(profesor_horario);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = profesor_horario.id }, profesor_horario);
        }

        // DELETE: api/profesor_horario/5
        [ResponseType(typeof(profesor_horario))]
        public IHttpActionResult Deleteprofesor_horario(int id)
        {
            profesor_horario profesor_horario = db.profesor_horario.Find(id);
            if (profesor_horario == null)
            {
                return NotFound();
            }

            db.profesor_horario.Remove(profesor_horario);
            db.SaveChanges();

            return Ok(profesor_horario);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool profesor_horarioExists(int id)
        {
            return db.profesor_horario.Count(e => e.id == id) > 0;
        }
    }
}