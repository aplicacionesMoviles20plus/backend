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
    public class profesorsController : ApiController
    {
        private TrabajoMovilesEntities db = new TrabajoMovilesEntities();

        // GET: api/profesors
        public IEnumerable<profesorApp> Getprofesors()
        {
            IEnumerable<profesorApp> lista = from i in db.profesors

                                             select new profesorApp
                                             {
                                                 idprofesor = i.idprofesor,
                                                 nombre = i.nombre,
                                                 apellido = i.apellido,
                                                 password = i.password,
                                                 email = i.email,
                                                 celular = i.celular,
                                                 descripcion = i.descripcion,
                                                 preciomax = i.preciomax,
                                                 preciomin = i.preciomin,
                                                 experiencia = i.experiencia,
                                                 calificacion = i.calificacion,
                                                 dni = i.dni,
                                                 antecedentes = i.antecedentes,
                                                 fotourl=i.fotourl,
                                                 id_metodopago=i.id_metodopago
                                             };
            return lista;
        }

        // GET: api/profesors/5
        [ResponseType(typeof(profesor))]
        public IHttpActionResult Getprofesor(int id)
        {
            var profesor = from i in db.profesors
                           where i.idprofesor == id

                           select new profesorApp
                           {

                               idprofesor = i.idprofesor,
                               nombre = i.nombre,
                               apellido = i.apellido,
                               password = i.password,
                               email = i.email,
                               celular = i.celular,
                               descripcion = i.descripcion,
                               preciomax = i.preciomax,
                               preciomin = i.preciomin,
                               experiencia = i.experiencia,
                               calificacion = i.calificacion,
                               dni = i.dni,
                               antecedentes = i.antecedentes,
                               fotourl = i.fotourl,
                               id_metodopago = i.id_metodopago
                           };
            if (profesor == null)
            {
                return NotFound();
            }
            return Ok(profesor.ToList());
        }

        // PUT: api/profesors/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putprofesor(int id, profesor profesor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != profesor.idprofesor)
            {
                return BadRequest();
            }

            db.Entry(profesor).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!profesorExists(id))
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

        // POST: api/profesors
        [ResponseType(typeof(profesor))]
        public IHttpActionResult Postprofesor(profesor profesor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.profesors.Add(profesor);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = profesor.idprofesor }, profesor);
        }

        // DELETE: api/profesors/5
        [ResponseType(typeof(profesor))]
        public IHttpActionResult Deleteprofesor(int id)
        {
            profesor profesor = db.profesors.Find(id);
            if (profesor == null)
            {
                return NotFound();
            }

            db.profesors.Remove(profesor);
            db.SaveChanges();

            return Ok(profesor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool profesorExists(int id)
        {
            return db.profesors.Count(e => e.idprofesor == id) > 0;
        }
    }
}