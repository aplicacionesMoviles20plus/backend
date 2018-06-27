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
    public class metodopagoesController : ApiController
    {
        private TrabajoMovilesEntities db = new TrabajoMovilesEntities();

        // GET api/metodopagoes
        public IEnumerable<metodopagoApp> Getmetodopagoes()
        {
            IEnumerable<metodopagoApp> lista = from i in db.metodopagoes

                                               select new metodopagoApp
                                               {
                                                   id = i.id,
                                                   nombre = i.nombre,
                                                   numerotarjeta = i.numerotarjeta,
                                                   fecha = i.fecha,
                                                   cvv = i.cvv

                                               };
            return lista;
        }

        // GET api/metodopagoes/5
        public metodopagoApp Getmetodopago(int id)
        {
            var mp = from i in db.metodopagoes
                     where i.id == id
                     select new metodopagoApp
                     {
                         id = i.id,
                         nombre = i.nombre,
                         numerotarjeta = i.numerotarjeta,
                         fecha = i.fecha,
                         cvv = i.cvv
                     };
            
            return mp.FirstOrDefault();
        }

        // PUT api/metodopagoes/5
        public HttpResponseMessage Putmetodopago(int id, metodopago metodopago)
        {
            if (ModelState.IsValid && id == metodopago.id)
            {
                db.Entry(metodopago).State = EntityState.Modified;

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

        // POST api/metodopagoes
        public HttpResponseMessage Postmetodopago(metodopago metodopago)
        {
            if (ModelState.IsValid)
            {
                db.metodopagoes.Add(metodopago);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, metodopago);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = metodopago.id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/metodopagoes/5
        public HttpResponseMessage Deletemetodopago(int id)
        {
            metodopago metodopago = db.metodopagoes.Find(id);
            if (metodopago == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.metodopagoes.Remove(metodopago);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, metodopago);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}