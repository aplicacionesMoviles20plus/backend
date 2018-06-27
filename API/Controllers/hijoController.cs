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
    public class hijoController : ApiController
    {
        private TrabajoMovilesEntities db = new TrabajoMovilesEntities();

        // GET api/hijo
        public IEnumerable<hijoApp> Gethijos()
        {
            IEnumerable<hijoApp> lista = from i in db.hijoes

                                         select new hijoApp
                                         {
                                             idhijo = i.idhijo,
                                             id_padre = i.id_padre,
                                             id_tutoria = i.id_tutoria,
                                             nombre = i.nombre,
                                             descripcion = i.descripcion
                                         };
            return lista;
        }
        public IEnumerable<hijoApp> Gethijos(int idpadre)
        {
            IEnumerable<hijoApp> lista = from i in db.hijoes
                                         where i.id_padre == idpadre
                                         select new hijoApp
                                         {
                                             idhijo = i.idhijo,
                                             id_padre = i.id_padre,
                                             id_tutoria = i.id_tutoria,
                                             nombre = i.nombre,
                                             descripcion = i.descripcion
                                         };
            return lista;
        }
        // GET api/hijo/5
        public hijoApp Gethijo(int id)
        {
            var hijo = from i in db.hijoes
                       where i.idhijo == id
                       select new hijoApp
                       {
                           idhijo = i.idhijo,
                           id_padre = i.id_padre,
                           id_tutoria = i.id_tutoria,
                           nombre = i.nombre,
                           descripcion = i.descripcion
                       };
           
            return hijo.FirstOrDefault();
        }

        // PUT api/hijo/5
        public HttpResponseMessage Puthijo(int id, hijo hijo)
        {
            if (ModelState.IsValid && id == hijo.idhijo)
            {
                db.Entry(hijo).State = EntityState.Modified;

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
        private bool hijoExists(int id)
        {
            return db.hijoes.Count(e => e.idhijo == id) > 0;
        }
        // POST api/hijo
        public HttpResponseMessage Posthijo(hijo hijo)
        {
            if (ModelState.IsValid)
            {
                if (hijoExists(hijo.idhijo))
                {
                    db.Entry(hijo).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    db.hijoes.Add(hijo);
                    db.SaveChanges();
                } 
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, hijo);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = hijo.idhijo }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/hijo/5
        public HttpResponseMessage Deletehijo(int id)
        {
            hijo hijo = db.hijoes.Find(id);
            if (hijo == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.hijoes.Remove(hijo);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, hijo);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}