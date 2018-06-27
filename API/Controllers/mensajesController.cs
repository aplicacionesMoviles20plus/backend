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
    public class mensajesController : ApiController
    {
        private TrabajoMovilesEntities db = new TrabajoMovilesEntities();

        // GET api/mensajes
        public IEnumerable<mensajeApp> Getmensajes()
        {
            IEnumerable<mensajeApp> lista = from i in db.mensajes

                                            select new mensajeApp
                                            {
                                                idmensaje = i.idmensaje,
                                                hora = i.hora,
                                                fecha = i.fecha,
                                                id_padre = i.id_padre,
                                                id_profe = i.id_profe,
                                                remitente = i.remitente,
                                                contenido = i.contenido
                                            };
            return lista;
        }
        public IEnumerable<mensajeApp> Getmensajes(int idpadre, int idprofe)
        {
            IEnumerable<mensajeApp> lista = from i in db.mensajes
                                            where i.id_padre == idpadre && i.id_profe == idprofe
                                            select new mensajeApp
                                            {
                                                idmensaje = i.idmensaje,
                                                hora = i.hora,
                                                fecha = i.fecha,
                                                id_padre = i.id_padre,
                                                id_profe = i.id_profe,
                                                remitente = i.remitente,
                                                contenido = i.contenido
                                            };
            return lista;
        }

        // GET api/mensajes/5
        public mensajeApp Getmensaje(int id)
        {
            var mensaje = from i in db.mensajes
                          where i.idmensaje == id
                          select new mensajeApp
                          {
                              idmensaje = i.idmensaje,
                              hora = i.hora,
                              fecha = i.fecha,
                              id_padre = i.id_padre,
                              id_profe = i.id_profe,
                              remitente = i.remitente,
                              contenido = i.contenido
                          };
          
            return mensaje.FirstOrDefault();
        }

        // PUT api/mensajes/5
        public HttpResponseMessage Putmensaje(int id, mensaje mensaje)
        {
            if (ModelState.IsValid && id == mensaje.idmensaje)
            {
                db.Entry(mensaje).State = EntityState.Modified;

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

        // POST api/mensajes
        public HttpResponseMessage Postmensaje(mensaje mensaje)
        {
            if (ModelState.IsValid)
            {
                db.mensajes.Add(mensaje);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, mensaje);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = mensaje.idmensaje }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/mensajes/5
        public HttpResponseMessage Deletemensaje(int id)
        {
            mensaje mensaje = db.mensajes.Find(id);
            if (mensaje == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.mensajes.Remove(mensaje);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, mensaje);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}