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
    public class profesorfavoritoesController : ApiController
    {
        private TrabajoMovilesEntities db = new TrabajoMovilesEntities();

        // GET api/profesorfavoritoes
        public IEnumerable<profesorfavoritoApp> Getprofesorfavoritoes()
        {
            IEnumerable<profesorfavoritoApp> lista = from i in db.profesorfavoritoes

                                                     select new profesorfavoritoApp
                                                     {
                                                         id = i.id,
                                                         id_padre = i.id_padre,
                                                         id_profesor = i.id_profesor
                                                     };
            return lista;
        }
      

        // GET api/profesorfavoritoes/5
        public profesorfavoritoApp Getprofesorfavorito(int id)
        {
            var profesorfavorito = from i in db.profesorfavoritoes
                                     where i.id == id
                                     select new profesorfavoritoApp
                                     {
                                         id = i.id,
                                         id_padre = i.id_padre,
                                         id_profesor = i.id_profesor
                                     };
            if (profesorfavorito == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return profesorfavorito.FirstOrDefault();
        }

        // PUT api/profesorfavoritoes/5
        public HttpResponseMessage Putprofesorfavorito(int id, profesorfavorito profesorfavorito)
        {
            if (ModelState.IsValid && id == profesorfavorito.id)
            {
                db.Entry(profesorfavorito).State = EntityState.Modified;

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

        // POST api/profesorfavoritoes
        public HttpResponseMessage Postprofesorfavorito(profesorfavorito profesorfavorito)
        {
            if (ModelState.IsValid)
            {
                db.profesorfavoritoes.Add(profesorfavorito);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, profesorfavorito);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = profesorfavorito.id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/profesorfavoritoes/5
        public HttpResponseMessage Deleteprofesorfavorito(int id)
        {
            profesorfavorito profesorfavorito = db.profesorfavoritoes.Find(id);
            if (profesorfavorito == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.profesorfavoritoes.Remove(profesorfavorito);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, profesorfavorito);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}