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
    public class padresController : ApiController
    {
        private TrabajoMovilesEntities db = new TrabajoMovilesEntities();

        // GET: api/padres
        public IEnumerable<padreApp> Getpadres()
        {
            IEnumerable<padreApp> lista = from i in db.padres

                                          select new padreApp
                                          {
                                              idpadre = i.idpadre,
                                              nombre = i.nombre,
                                              apellido = i.apellido,
                                              password = i.password,
                                              departamento = i.departamento,
                                              email = i.email,
                                              provincia = i.provincia,
                                              distrito = i.distrito,
                                              direccion = i.direccion,
                                              celular = i.celular,
                                              dni = i.dni,
                                              fotourl=i.fotourl
                                          };
            return lista;
        }

        // GET: api/padres/5
        [ResponseType(typeof(padreApp))]
        public IHttpActionResult Getpadre(int id)
        {
            var padre = from i in db.padres
                        where i.idpadre == id
                        select new padreApp
                        {
                            idpadre = i.idpadre,
                            nombre = i.nombre,
                            apellido = i.apellido,
                            password = i.password,
                            departamento = i.departamento,
                            email = i.email,
                            provincia = i.provincia,
                            distrito = i.distrito,
                            direccion = i.direccion,
                            celular = i.celular,
                            dni = i.dni,
                            fotourl = i.fotourl
                        };
            if (padre == null)
            {
                return NotFound();
            }
            return Ok(padre.ToList());
        }
        [ResponseType(typeof(padreApp))]
        public IHttpActionResult Getpadre(string email)
        {
            var padre = from i in db.padres
                        where i.email == email
                        select new padreApp
                        {
                            idpadre = i.idpadre,
                            nombre = i.nombre,
                            apellido = i.apellido,
                            password = i.password,
                            departamento = i.departamento,
                            email = i.email,
                            provincia = i.provincia,
                            distrito = i.distrito,
                            direccion = i.direccion,
                            celular = i.celular,
                            dni = i.dni,
                            fotourl = i.fotourl
                        };
            if (padre == null)
            {
                return NotFound();
            }
            return Ok(padre.ToList());
        }
        // PUT: api/padres/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putpadre(int id, padre padre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != padre.idpadre)
            {
                return BadRequest();
            }

            db.Entry(padre).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!padreExists(id))
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

        // POST: api/padres
        [ResponseType(typeof(padre))]
        public IHttpActionResult Postpadre(padre padre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.padres.Add(padre);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = padre.idpadre }, padre);
        }

        // DELETE: api/padres/5
        [ResponseType(typeof(padre))]
        public IHttpActionResult Deletepadre(int id)
        {
            padre padre = db.padres.Find(id);
            if (padre == null)
            {
                return NotFound();
            }

            db.padres.Remove(padre);
            db.SaveChanges();

            return Ok(padre);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool padreExists(int id)
        {
            return db.padres.Count(e => e.idpadre == id) > 0;
        }
    }
}