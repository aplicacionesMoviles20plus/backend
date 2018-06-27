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
    public class suscripcionsController : ApiController
    {
        private TrabajoMovilesEntities db = new TrabajoMovilesEntities();

        // GET api/suscripcions
        public IEnumerable<suscripcionApp> Getsuscripcions()
        {
            IEnumerable<suscripcionApp> lista = from i in db.suscripcions

                                                select new suscripcionApp
                                                {
                                                    idsuscripcion = i.idsuscripcion,
                                                    fechainicio = i.fechainicio,
                                                    fechafin = i.fechafin,
                                                    id_profesor = i.id_profesor
                                                };
            return lista;
        }
        public IEnumerable<suscripcionApp> Getsuscripcions(int idprofesor)
        {
            IEnumerable<suscripcionApp> lista = from i in db.suscripcions
                                                where i.id_profesor == idprofesor
                                                select new suscripcionApp
                                                {
                                                    idsuscripcion = i.idsuscripcion,
                                                    fechainicio = i.fechainicio,
                                                    fechafin = i.fechafin,
                                                    id_profesor = i.id_profesor
                                                };
            return lista;
        }

        // GET api/suscripcions/5
        public suscripcionApp Getsuscripcion(int id)
        {
            var suscripcon = from i in db.suscripcions
                             where i.idsuscripcion == id
                             select new suscripcionApp
                             {
                                 idsuscripcion = i.idsuscripcion,
                                 fechainicio = i.fechainicio,
                                 fechafin = i.fechafin,
                                 id_profesor = i.id_profesor
                             };
            if (suscripcon == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return suscripcon.FirstOrDefault();
        }

        // PUT api/suscripcions/5
        public HttpResponseMessage Putsuscripcion(int id, suscripcion suscripcion)
        {
            if (ModelState.IsValid && id == suscripcion.idsuscripcion)
            {
                db.Entry(suscripcion).State = EntityState.Modified;

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
         private bool suscripcionExists(int id)
        {
            return db.suscripcions.Count(e => e.idsuscripcion == id) > 0;
        }
        // POST api/suscripcions
        public HttpResponseMessage Postsuscripcion(suscripcion suscripcion)
        {
            if (ModelState.IsValid)
            {

                if (suscripcion.idsuscripcion == suscripcion.idsuscripcion)
                {
                    db.Entry(suscripcion).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    db.suscripcions.Add(suscripcion);
                    db.SaveChanges();
                }
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, suscripcion);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = suscripcion.idsuscripcion }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/suscripcions/5
        public HttpResponseMessage Deletesuscripcion(int id)
        {
            suscripcion suscripcion = db.suscripcions.Find(id);
            if (suscripcion == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.suscripcions.Remove(suscripcion);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, suscripcion);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}