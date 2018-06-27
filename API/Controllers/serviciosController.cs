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
    public class serviciosController : ApiController
    {
        private TrabajoMovilesEntities db = new TrabajoMovilesEntities();

        // GET api/servicios
        public IEnumerable<servicioApp> Getservicios()
        {
            IEnumerable<servicioApp> lista = from i in db.servicios

                                             select new servicioApp
                                             {
                                                 idservicio = i.idservicio,
                                                 tipodepago = i.tipodepago,
                                                 fecha = i.fecha
                                             };
            return lista;
        }

        // GET api/servicios/5
        public servicioApp Getservicio(int id)
        {
            var servicioactual = from i in db.servicios
                                 where i.idservicio == id
                                 select new servicioApp
                                 {
                                     idservicio = i.idservicio,
                                     tipodepago = i.tipodepago,
                                     fecha = i.fecha
                                 };
            if (servicioactual == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return servicioactual.FirstOrDefault();
        }

        // PUT api/servicios/5
        public HttpResponseMessage Putservicio(int id, servicio servicio)
        {
            if (ModelState.IsValid && id == servicio.idservicio)
            {
                db.Entry(servicio).State = EntityState.Modified;

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

        // POST api/servicios
        public HttpResponseMessage Postservicio(servicio servicio)
        {
            if (ModelState.IsValid)
            {
                db.servicios.Add(servicio);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, servicio);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = servicio.idservicio }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/servicios/5
        public HttpResponseMessage Deleteservicio(int id)
        {
            servicio servicio = db.servicios.Find(id);
            if (servicio == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.servicios.Remove(servicio);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, servicio);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}