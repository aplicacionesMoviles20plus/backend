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
    public class metodopagoesController : ApiController
    {
        private TrabajoMovilesEntities db = new TrabajoMovilesEntities();

        // GET: api/metodopagoes
        public IEnumerable<metodopagoApp> Getmetodopagoes()
        {
            IEnumerable<metodopagoApp> lista = from i in db.metodopagoes

                                         select new metodopagoApp
                                         {
                                            id=i.id,
                                            nombre=i.nombre,
                                            numerotarjeta=i.numerotarjeta,
                                            fecha=i.fecha,
                                            cvv=i.cvv

                                         };
            return lista;
        }

        // GET: api/metodopagoes/5
        [ResponseType(typeof(metodopagoApp))]
        public IHttpActionResult Getmetodopago(int id)
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
            if (mp == null)
            {
                return NotFound();
            }
            return Ok(mp.FirstOrDefault());
        }

        // PUT: api/metodopagoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putmetodopago(int id, metodopago metodopago)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != metodopago.id)
            {
                return BadRequest();
            }

            db.Entry(metodopago).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!metodopagoExists(id))
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

        // POST: api/metodopagoes
        [ResponseType(typeof(metodopago))]
        public IHttpActionResult Postmetodopago(metodopago metodopago)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.metodopagoes.Add(metodopago);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = metodopago.id }, metodopago);
        }

        // DELETE: api/metodopagoes/5
        [ResponseType(typeof(metodopago))]
        public IHttpActionResult Deletemetodopago(int id)
        {
            metodopago metodopago = db.metodopagoes.Find(id);
            if (metodopago == null)
            {
                return NotFound();
            }

            db.metodopagoes.Remove(metodopago);
            db.SaveChanges();

            return Ok(metodopago);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool metodopagoExists(int id)
        {
            return db.metodopagoes.Count(e => e.id == id) > 0;
        }
    }
}