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
    public class padresController : ApiController
    {
        private TrabajoMovilesEntities db = new TrabajoMovilesEntities();

        // GET api/padres
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
                                              fotourl = i.fotourl
                                          };
            return lista;
        }

       
        // GET api/padres/5
        public padreApp Getpadre(int id)
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

            return padre.FirstOrDefault();
        }
        public padreApp Getpadre(string email)
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

            return padre.FirstOrDefault();
        }
        // PUT api/padres/5
        public HttpResponseMessage Putpadre(int id, padre padre)
        {
            if (ModelState.IsValid && id == padre.idpadre)
            {
                db.Entry(padre).State = EntityState.Modified;

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
        private bool padreExists(int id)
        {
            return db.padres.Count(e => e.idpadre == id) > 0;
        }
        // POST api/padres
        public HttpResponseMessage Postpadre(padre padre)
        {
            if (ModelState.IsValid)
            {
                if (padreExists(padre.idpadre))
                {
                    db.Entry(padre).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    db.padres.Add(padre);
                    db.SaveChanges();
                }

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, padre);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = padre.idpadre }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/padres/5
        public HttpResponseMessage Deletepadre(int id)
        {
            padre padre = db.padres.Find(id);
            if (padre == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.padres.Remove(padre);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, padre);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}