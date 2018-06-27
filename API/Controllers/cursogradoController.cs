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
    public class cursogradoController : ApiController
    {
        private TrabajoMovilesEntities db = new TrabajoMovilesEntities();

        // GET api/cursogrado
        public IEnumerable<cursogradoApp> Getcursogrado()
        {
            IEnumerable<cursogradoApp> lista = from i in db.cursogradoes

                                               select new cursogradoApp
                                               {
                                                   idcursogrado = i.idcursogrado,
                                                   nombre = i.nombre,
                                                   contenido = i.contenido,
                                                   grado = i.grado

                                               };
            return lista;
        }
        public IEnumerable<cursogradoApp> Getcursogrado2(int idprofe)
        {

            IEnumerable<cursogradoApp> lista = from i in db.cursogradoes
                                               join z in db.profesor_cursogrado on i.idcursogrado equals z.id_cursogrado
                                               where (z.id_profesor == idprofe)
                                               select new cursogradoApp
                                               {
                                                   idcursogrado = i.idcursogrado,
                                                   nombre = i.nombre,
                                                   contenido = i.contenido,
                                                   grado = i.grado
                                               };

            return lista;
        }
        // GET api/cursogrado/5
        public cursogradoApp Getcursogrado(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            IEnumerable<cursogradoApp> curso = from i in db.cursogradoes
                                               where i.idcursogrado == id
                                               select new cursogradoApp
                                               {

                                                   idcursogrado = i.idcursogrado,
                                                   nombre = i.nombre,
                                                   contenido = i.contenido,
                                                   grado = i.grado

                                               };
            return curso.FirstOrDefault();
        }

        // PUT api/cursogrado/5
        public HttpResponseMessage Putcursogrado(int id, cursogrado cursogrado)
        {
            if (ModelState.IsValid && id == cursogrado.idcursogrado)
            {
                db.Entry(cursogrado).State = EntityState.Modified;

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

        // POST api/cursogrado
        public HttpResponseMessage Postcursogrado(cursogrado cursogrado)
        {
            if (ModelState.IsValid)
            {
                db.cursogradoes.Add(cursogrado);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, cursogrado);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = cursogrado.idcursogrado }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/cursogrado/5
        public HttpResponseMessage Deletecursogrado(int id)
        {
            cursogrado cursogrado = db.cursogradoes.Find(id);
            if (cursogrado == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.cursogradoes.Remove(cursogrado);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, cursogrado);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}