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
    public class resumenclasesController : ApiController
    {
        private TrabajoMovilesEntities db = new TrabajoMovilesEntities();

        // GET: api/resumenclases
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

        // GET: api/resumenclases/5
        [ResponseType(typeof(resumenclase))]
        public IHttpActionResult Getresumenclase(int id)
        {
            var avanceCurrentUser = from i in db.resumenclases
                                    where i.idresumen == id
                                    select new resumenclase
                                    {
                                        idresumen = i.idresumen,
                                        id_tutoria = i.id_tutoria,
                                        descripcion = i.descripcion,
                                        fecha = i.fecha
                                    };
            if (avanceCurrentUser == null)
            {
                return NotFound();
            }
            return Ok(avanceCurrentUser.ToList());

        }

        // PUT: api/resumenclases/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putresumenclase(int id, resumenclase resumenclase)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != resumenclase.idresumen)
            {
                return BadRequest();
            }

            db.Entry(resumenclase).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!resumenclaseExists(id))
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

        // POST: api/resumenclases
        [ResponseType(typeof(resumenclase))]
        public IHttpActionResult Postresumenclase(resumenclase resumenclase)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.resumenclases.Add(resumenclase);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = resumenclase.idresumen }, resumenclase);
        }

        // DELETE: api/resumenclases/5
        [ResponseType(typeof(resumenclase))]
        public IHttpActionResult Deleteresumenclase(int id)
        {
            resumenclase resumenclase = db.resumenclases.Find(id);
            if (resumenclase == null)
            {
                return NotFound();
            }

            db.resumenclases.Remove(resumenclase);
            db.SaveChanges();

            return Ok(resumenclase);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool resumenclaseExists(int id)
        {
            return db.resumenclases.Count(e => e.idresumen == id) > 0;
        }
    }
}