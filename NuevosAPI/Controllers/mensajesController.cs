using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using NuevosAPI.Models;

namespace NuevosAPI.Controllers
{
    public class mensajesController : ApiController
    {
        private TrabajoMovilesEntities db = new TrabajoMovilesEntities();

        // GET: api/mensajes
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
                                            where i.id_padre==idpadre && i.id_profe==idprofe
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
        // GET: api/mensajes/5
        [ResponseType(typeof(mensajeApp))]
        public IHttpActionResult Getmensaje(int id)
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
            if (mensaje == null)
            {
                return NotFound();
            }
            return Ok(mensaje.ToList());
        }

        // PUT: api/mensajes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putmensaje(int id, mensaje mensaje)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mensaje.idmensaje)
            {
                return BadRequest();
            }

            db.Entry(mensaje).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!mensajeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/mensajes
        [ResponseType(typeof(mensaje))]
        public IHttpActionResult Postmensaje(mensaje mensaje)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.mensajes.Add(mensaje);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = mensaje.idmensaje }, mensaje);
        }

        // DELETE: api/mensajes/5
        [ResponseType(typeof(mensaje))]
        public IHttpActionResult Deletemensaje(int id)
        {
            mensaje mensaje = db.mensajes.Find(id);
            if (mensaje == null)
            {
                return NotFound();
            }

            db.mensajes.Remove(mensaje);
            db.SaveChanges();

            return Ok(mensaje);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool mensajeExists(int id)
        {
            return db.mensajes.Count(e => e.idmensaje == id) > 0;
        }
    }
}