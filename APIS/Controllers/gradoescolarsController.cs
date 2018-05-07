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
using APIS.Models;

namespace APIS.Controllers
{
    public class gradoescolarsController : ApiController
    {
        private TrabajoMovilesEntities db = new TrabajoMovilesEntities();

        // GET: api/gradoescolars
        public IEnumerable<gradoescolarApp> Getgradoescolars()
        {

            IEnumerable<gradoescolarApp> lista = from i in db.gradoescolars

                                           select new gradoescolarApp
                                           {
                                              idgradoescolar=i.idgradoescolar,
                                              nombregrado=i.nombregrado
                                           };
            return lista;
        }

        // GET: api/gradoescolars/5
        [ResponseType(typeof(gradoescolar))]
        public IHttpActionResult Getgradoescolar(int id)
        {

            var gradoescolar = from i in db.gradoescolars
                                    where i.idgradoescolar == id
                                    select new gradoescolarApp
                                    {
                                        idgradoescolar = i.idgradoescolar,
                                        nombregrado = i.nombregrado
                                    };
            if (gradoescolar == null)
            {
                return NotFound();
            }
            return Ok(gradoescolar.ToList());
        }

        // PUT: api/gradoescolars/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putgradoescolar(int id, gradoescolar gradoescolar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gradoescolar.idgradoescolar)
            {
                return BadRequest();
            }

            db.Entry(gradoescolar).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!gradoescolarExists(id))
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

        // POST: api/gradoescolars
        [ResponseType(typeof(gradoescolar))]
        public IHttpActionResult Postgradoescolar(gradoescolar gradoescolar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.gradoescolars.Add(gradoescolar);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = gradoescolar.idgradoescolar }, gradoescolar);
        }

        // DELETE: api/gradoescolars/5
        [ResponseType(typeof(gradoescolar))]
        public IHttpActionResult Deletegradoescolar(int id)
        {
            gradoescolar gradoescolar = db.gradoescolars.Find(id);
            if (gradoescolar == null)
            {
                return NotFound();
            }

            db.gradoescolars.Remove(gradoescolar);
            db.SaveChanges();

            return Ok(gradoescolar);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool gradoescolarExists(int id)
        {
            return db.gradoescolars.Count(e => e.idgradoescolar == id) > 0;
        }
    }
}