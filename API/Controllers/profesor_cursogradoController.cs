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
    public class profesor_cursogradoController : ApiController
    {
        private TrabajoMovilesEntities db = new TrabajoMovilesEntities();

        // GET api/profesor_cursogrado
        public IEnumerable<profesor_cursogradoApp> Getprofesor_cursogrado()
        {
            IEnumerable<profesor_cursogradoApp> lista = from i in db.profesor_cursogrado

                                                        select new profesor_cursogradoApp
                                                        {
                                                            id = i.id,
                                                            id_cursogrado = i.id_cursogrado,
                                                            id_profesor = i.id_profesor
                                                        };
            return lista;

        }


        // GET api/profesor_cursogrado/5
        public profesor_cursogradoApp Getprofesor_cursogrado(int id)
        {
            var profesor_curso = from i in db.profesor_cursogrado
                                 where i.id == id
                                 select new profesor_cursogradoApp
                                 {
                                     id = i.id,
                                     id_cursogrado = i.id_cursogrado,
                                     id_profesor = i.id_profesor
                                 };


            if (profesor_curso == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return profesor_curso.FirstOrDefault();
        }

        // PUT api/profesor_cursogrado/5
        public HttpResponseMessage Putprofesor_cursogrado(int id, profesor_cursogrado profesor_cursogrado)
        {
            if (ModelState.IsValid && id == profesor_cursogrado.id)
            {
                db.Entry(profesor_cursogrado).State = EntityState.Modified;

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

        // POST api/profesor_cursogrado
        public HttpResponseMessage Postprofesor_cursogrado(profesor_cursogrado profesor_cursogrado)
        {
            if (ModelState.IsValid)
            {
                db.profesor_cursogrado.Add(profesor_cursogrado);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, profesor_cursogrado);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = profesor_cursogrado.id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/profesor_cursogrado/5
        public HttpResponseMessage Deleteprofesor_cursogrado(int id)
        {
            profesor_cursogrado profesor_cursogrado = db.profesor_cursogrado.Find(id);
            if (profesor_cursogrado == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.profesor_cursogrado.Remove(profesor_cursogrado);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, profesor_cursogrado);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}