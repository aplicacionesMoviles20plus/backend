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
    public class profesor_horarioController : ApiController
    {
        private TrabajoMovilesEntities db = new TrabajoMovilesEntities();

        // GET api/profesor_horario
        public IEnumerable<profesor_horarioApp> Getprofesor_horario()
        {
            IEnumerable<profesor_horarioApp> lista = from i in db.profesor_horario

                                                     select new profesor_horarioApp
                                                     {
                                                         id = i.id,
                                                         id_horario = i.id_horario,
                                                         id_profesor = i.id_profesor,
                                                         estado = i.estado,
                                                         fecha = i.fecha
                                                     };
            return lista;
        }

        // GET api/profesor_horario/5
        public profesor_horarioApp Getprofesor_horario(int id)
        {
            var profesor_horario = from i in db.profesor_horario
                                   where i.id == id
                                   select new profesor_horarioApp
                                   {
                                       id = i.id,
                                       id_horario = i.id_horario,
                                       id_profesor = i.id_profesor,
                                       estado = i.estado,
                                       fecha = i.fecha
                                   };
            if (profesor_horario == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return profesor_horario.FirstOrDefault();
        }

        // PUT api/profesor_horario/5
        public HttpResponseMessage Putprofesor_horario(int id, profesor_horario profesor_horario)
        {
            if (ModelState.IsValid && id == profesor_horario.id)
            {
                db.Entry(profesor_horario).State = EntityState.Modified;

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

        // POST api/profesor_horario
        public HttpResponseMessage Postprofesor_horario(profesor_horario profesor_horario)
        {
            if (ModelState.IsValid)
            {
                db.profesor_horario.Add(profesor_horario);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, profesor_horario);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = profesor_horario.id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/profesor_horario/5
        public HttpResponseMessage Deleteprofesor_horario(int id)
        {
            profesor_horario profesor_horario = db.profesor_horario.Find(id);
            if (profesor_horario == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.profesor_horario.Remove(profesor_horario);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, profesor_horario);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}