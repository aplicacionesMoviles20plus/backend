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
    public class zonasController : ApiController
    {
        private TrabajoMovilesEntities db = new TrabajoMovilesEntities();

        // GET api/zonas
        public IEnumerable<zonaApp> Getzonas()
        {
            IEnumerable<zonaApp> zonas = from c in db.zonas
                                         select new zonaApp
                                         {
                                             idzona = c.idzona,
                                             zona1 = c.zona1
                                         };
            return zonas;

            //return Json(zonas.List());

        }
        public IEnumerable<zonaApp> Getzonas2(int idprofe)
        {

            IEnumerable<zonaApp> lista = from i in db.zonas
                                         join z in db.profesor_zona on i.idzona equals z.id_zona
                                         where (z.id_profe == idprofe)
                                         select new zonaApp
                                         {
                                             idzona = i.idzona,
                                             zona1 = i.zona1
                                         };

            return lista;
        }

        // GET api/zonas/5
        public zonaApp Getzona(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            IEnumerable<zonaApp> zona = from c in db.zonas
                                        where c.idzona == id
                                        select new zonaApp
                                        {
                                            idzona = c.idzona,
                                            zona1 = c.zona1
                                        };
            if (zona == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return zona.FirstOrDefault();
        }

        // PUT api/zonas/5
        public HttpResponseMessage Putzona(int id, zona zona)
        {
            if (ModelState.IsValid && id == zona.idzona)
            {
                db.Entry(zona).State = EntityState.Modified;

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

        // POST api/zonas
        public HttpResponseMessage Postzona(zona zona)
        {
            if (ModelState.IsValid)
            {
                db.zonas.Add(zona);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, zona);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = zona.idzona }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/zonas/5
        public HttpResponseMessage Deletezona(int id)
        {
            zona zona = db.zonas.Find(id);
            if (zona == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.zonas.Remove(zona);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, zona);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}