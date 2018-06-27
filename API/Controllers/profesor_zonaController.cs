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
    public class profesor_zonaController : ApiController
    {
        private TrabajoMovilesEntities db = new TrabajoMovilesEntities();

        // GET api/profesor_zona
        public IEnumerable<profesor_zonaApp> Getprofesor_zona()
        {

            IEnumerable<profesor_zonaApp> lista = from i in db.profesor_zona

                                                  select new profesor_zonaApp
                                                  {
                                                      id = i.id,
                                                      id_zona = i.id_zona,
                                                      id_profe = i.id_profe
                                                  };
            return lista;
        }

        // GET api/profesor_zona/5
        public profesor_zonaApp Getprofesor_zona(int id)
        {
            var profesor_zona = from i in db.profesor_zona
                                where i.id == id
                                select new profesor_zonaApp
                                {
                                    id = i.id,
                                    id_profe = i.id_profe,
                                    id_zona = i.id_zona
                                };
            if (profesor_zona == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return profesor_zona.FirstOrDefault();
        }

        // PUT api/profesor_zona/5
        public HttpResponseMessage Putprofesor_zona(int id, profesor_zona profesor_zona)
        {
            if (ModelState.IsValid && id == profesor_zona.id)
            {
                db.Entry(profesor_zona).State = EntityState.Modified;

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

        // POST api/profesor_zona
        public HttpResponseMessage Postprofesor_zona(profesor_zona profesor_zona)
        {
            if (ModelState.IsValid)
            {
                db.profesor_zona.Add(profesor_zona);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, profesor_zona);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = profesor_zona.id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/profesor_zona/5
        public HttpResponseMessage Deleteprofesor_zona(int id)
        {
            profesor_zona profesor_zona = db.profesor_zona.Find(id);
            if (profesor_zona == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.profesor_zona.Remove(profesor_zona);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, profesor_zona);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}