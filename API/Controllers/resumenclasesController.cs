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
    public class resumenclasesController : ApiController
    {
        private TrabajoMovilesEntities db = new TrabajoMovilesEntities();

        // GET api/resumenclases
        public IEnumerable<resumenclaseApp> Getresumenclases()
        {
            IEnumerable<resumenclaseApp> lista = from i in db.resumenclases

                                                 select new resumenclaseApp
                                                 {
                                                     idresumen = i.idresumen,
                                                     id_tutoria = i.id_tutoria,
                                                     descripcion = i.descripcion,
                                                     fecha = i.fecha
                                                 };
            return lista;
        }
        public IEnumerable<resumenclaseApp> Getresumenclases(int idtutoria)
        {
            IEnumerable<resumenclaseApp> lista = from i in db.resumenclases
                                                 where i.id_tutoria == idtutoria
                                                 select new resumenclaseApp
                                                 {
                                                     idresumen = i.idresumen,
                                                     id_tutoria = i.id_tutoria,
                                                     descripcion = i.descripcion,
                                                     fecha = i.fecha
                                                 };
            return lista;
        }
        public IEnumerable<resumenclaseApp> Getresumenclases2(int idprofe)
        {
            IEnumerable<resumenclaseApp> lista = from i in db.resumenclases
                                                 join z in db.tutorias on i.id_tutoria equals z.idtutoria
                                                 join x in db.profesor_horario on z.id_horario equals x.id 
                                                 where x.id_profesor==idprofe
                                                 select new resumenclaseApp
                                                 {
                                                     idresumen = i.idresumen,
                                                     id_tutoria = i.id_tutoria,
                                                     descripcion = i.descripcion,
                                                     fecha = i.fecha
                                                 };
            return lista;
        }

        // GET api/resumenclases/5
        public resumenclaseApp Getresumenclase(int id)
        {
            var avanceCurrentUser = from i in db.resumenclases
                                    where i.idresumen == id
                                    select new resumenclaseApp
                                    {
                                        idresumen = i.idresumen,
                                        id_tutoria = i.id_tutoria,
                                        descripcion = i.descripcion,
                                        fecha = i.fecha
                                    };
            if (avanceCurrentUser == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return avanceCurrentUser.FirstOrDefault();
        }

        // PUT api/resumenclases/5
        public HttpResponseMessage Putresumenclase(int id, resumenclase resumenclase)
        {
            if (ModelState.IsValid && id == resumenclase.idresumen)
            {
                db.Entry(resumenclase).State = EntityState.Modified;

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

        // POST api/resumenclases
        public HttpResponseMessage Postresumenclase(resumenclase resumenclase)
        {
            if (ModelState.IsValid)
            {
                db.resumenclases.Add(resumenclase);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, resumenclase);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = resumenclase.idresumen }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/resumenclases/5
        public HttpResponseMessage Deleteresumenclase(int id)
        {
            resumenclase resumenclase = db.resumenclases.Find(id);
            if (resumenclase == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.resumenclases.Remove(resumenclase);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, resumenclase);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}