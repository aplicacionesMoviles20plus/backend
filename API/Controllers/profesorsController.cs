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
    public class profesorsController : ApiController
    {
        private TrabajoMovilesEntities db = new TrabajoMovilesEntities();

        // GET api/profesors
        public IEnumerable<profesorApp> Getprofesors()
        {
            IEnumerable<profesorApp> lista = from i in db.profesors

                                             select new profesorApp
                                             {
                                                 idprofesor = i.idprofesor,
                                                 nombre = i.nombre,
                                                 apellido = i.apellido,
                                                 password = i.password,
                                                 email = i.email,
                                                 celular = i.celular,
                                                 descripcion = i.descripcion,
                                                 preciomax = i.preciomax,
                                                 preciomin = i.preciomin,
                                                 experiencia = i.experiencia,
                                                 calificacion = i.calificacion,
                                                 dni = i.dni,
                                                 antecedentes = i.antecedentes,
                                                 fotourl = i.fotourl,
                                                 id_metodopago = i.id_metodopago
                                             };
            return lista;
        }

        // GET: api/profesors
        public IEnumerable<profesorApp> Getprofesors(int iduser)
        {
            IEnumerable<profesorApp> lista = from i in db.profesors
                                             where (i.idprofesor != iduser && i.experiencia != "")
                                             select new profesorApp
                                             {
                                                 idprofesor = i.idprofesor,
                                                 nombre = i.nombre,
                                                 apellido = i.apellido,
                                                 password = i.password,
                                                 email = i.email,
                                                 celular = i.celular,
                                                 descripcion = i.descripcion,
                                                 preciomax = i.preciomax,
                                                 preciomin = i.preciomin,
                                                 experiencia = i.experiencia,
                                                 calificacion = i.calificacion,
                                                 dni = i.dni,
                                                 antecedentes = i.antecedentes,
                                                 fotourl = i.fotourl,
                                                 id_metodopago = i.id_metodopago
                                             };
            return lista;
        }
        // GET: Profesores By Zona
        public IEnumerable<profesorApp> Getprofesors2(int idzona, int iduser)
        {

            IEnumerable<profesorApp> lista = from i in db.profesors
                                             join z in db.profesor_zona on i.idprofesor equals z.id_profe
                                             where (z.id_zona == idzona && i.idprofesor != iduser && i.experiencia != "")
                                             select new profesorApp
                                             {
                                                 idprofesor = i.idprofesor,
                                                 nombre = i.nombre,
                                                 apellido = i.apellido,
                                                 password = i.password,
                                                 email = i.email,
                                                 celular = i.celular,
                                                 descripcion = i.descripcion,
                                                 preciomax = i.preciomax,
                                                 preciomin = i.preciomin,
                                                 experiencia = i.experiencia,
                                                 calificacion = i.calificacion,
                                                 dni = i.dni,
                                                 antecedentes = i.antecedentes,
                                                 fotourl = i.fotourl,
                                                 id_metodopago = i.id_metodopago
                                             };

            return lista;
        }
        // GET: Profesores By Curso y Grado
        public IEnumerable<profesorApp> Getprofesors3(int idcurso, int iduser)
        {

            IEnumerable<profesorApp> lista = from i in db.profesors
                                             join z in db.profesor_cursogrado on i.idprofesor equals z.id_profesor
                                             where (z.id_cursogrado == idcurso && i.idprofesor != iduser && i.experiencia != "")
                                             select new profesorApp
                                             {
                                                 idprofesor = i.idprofesor,
                                                 nombre = i.nombre,
                                                 apellido = i.apellido,
                                                 password = i.password,
                                                 email = i.email,
                                                 celular = i.celular,
                                                 descripcion = i.descripcion,
                                                 preciomax = i.preciomax,
                                                 preciomin = i.preciomin,
                                                 experiencia = i.experiencia,
                                                 calificacion = i.calificacion,
                                                 dni = i.dni,
                                                 antecedentes = i.antecedentes,
                                                 fotourl = i.fotourl,
                                                 id_metodopago = i.id_metodopago
                                             };

            return lista;
        }
        // GET: Profesores favoritos
        public IEnumerable<profesorApp> Getprofesors4(int idpadre)
        {

            IEnumerable<profesorApp> lista = from i in db.profesors
                                             join z in db.profesorfavoritoes on i.idprofesor equals z.id_profesor
                                             where (z.id_padre == idpadre)
                                             select new profesorApp
                                             {
                                                 idprofesor = i.idprofesor,
                                                 nombre = i.nombre,
                                                 apellido = i.apellido,
                                                 password = i.password,
                                                 email = i.email,
                                                 celular = i.celular,
                                                 descripcion = i.descripcion,
                                                 preciomax = i.preciomax,
                                                 preciomin = i.preciomin,
                                                 experiencia = i.experiencia,
                                                 calificacion = i.calificacion,
                                                 dni = i.dni,
                                                 antecedentes = i.antecedentes,
                                                 fotourl = i.fotourl,
                                                 id_metodopago = i.id_metodopago
                                             };

            return lista;
        }
        // GET: Profesores con antecedentes
        public IEnumerable<profesorApp> Getprofesors5(int idusuario)
        {
            IEnumerable<profesorApp> lista = from i in db.profesors
                                             where (i.idprofesor != idusuario && i.experiencia != "" && i.antecedentes != "")
                                             select new profesorApp
                                             {
                                                 idprofesor = i.idprofesor,
                                                 nombre = i.nombre,
                                                 apellido = i.apellido,
                                                 password = i.password,
                                                 email = i.email,
                                                 celular = i.celular,
                                                 descripcion = i.descripcion,
                                                 preciomax = i.preciomax,
                                                 preciomin = i.preciomin,
                                                 experiencia = i.experiencia,
                                                 calificacion = i.calificacion,
                                                 dni = i.dni,
                                                 antecedentes = i.antecedentes,
                                                 fotourl = i.fotourl,
                                                 id_metodopago = i.id_metodopago
                                             };
            return lista;
        }
        //Get profesores ocn los que chateo
        public IEnumerable<profesorApp> Getprofesors6(int idfather)
        {

            IEnumerable<profesorApp> lista = from i in db.profesors.Distinct()
                                             join z in db.mensajes on i.idprofesor equals z.id_profe
                                             where z.id_padre == idfather
                                             select new profesorApp
                                             {
                                                 idprofesor = i.idprofesor,
                                                 nombre = i.nombre,
                                                 apellido = i.apellido,
                                                 password = i.password,
                                                 email = i.email,
                                                 celular = i.celular,
                                                 descripcion = i.descripcion,
                                                 preciomax = i.preciomax,
                                                 preciomin = i.preciomin,
                                                 experiencia = i.experiencia,
                                                 calificacion = i.calificacion,
                                                 dni = i.dni,
                                                 antecedentes = i.antecedentes,
                                                 fotourl = i.fotourl,
                                                 id_metodopago = i.id_metodopago
                                             };

            return lista;
        }
        // GET api/profesors/5
        public profesorApp Getprofesor(int id)
        {
            var profesor = from i in db.profesors
                           where i.idprofesor == id

                           select new profesorApp
                           {

                               idprofesor = i.idprofesor,
                               nombre = i.nombre,
                               apellido = i.apellido,
                               password = i.password,
                               email = i.email,
                               celular = i.celular,
                               descripcion = i.descripcion,
                               preciomax = i.preciomax,
                               preciomin = i.preciomin,
                               experiencia = i.experiencia,
                               calificacion = i.calificacion,
                               dni = i.dni,
                               antecedentes = i.antecedentes,
                               fotourl = i.fotourl,
                               id_metodopago = i.id_metodopago
                           };
            if (profesor == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return profesor.FirstOrDefault();
        }
        public profesorApp Getprofesor(string email)
        {
            var profesor = from i in db.profesors
                           where i.email == email

                           select new profesorApp
                           {

                               idprofesor = i.idprofesor,
                               nombre = i.nombre,
                               apellido = i.apellido,
                               password = i.password,
                               email = i.email,
                               celular = i.celular,
                               descripcion = i.descripcion,
                               preciomax = i.preciomax,
                               preciomin = i.preciomin,
                               experiencia = i.experiencia,
                               calificacion = i.calificacion,
                               dni = i.dni,
                               antecedentes = i.antecedentes,
                               fotourl = i.fotourl,
                               id_metodopago = i.id_metodopago
                           };
            if (profesor == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return profesor.FirstOrDefault();
        }
        // PUT api/profesors/5
        public HttpResponseMessage Putprofesor(int id, profesor profesor)
        {
            if (ModelState.IsValid && id == profesor.idprofesor)
            {
                db.Entry(profesor).State = EntityState.Modified;

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
        private bool profesorExists(int id)
        {
            return db.profesors.Count(e => e.idprofesor == id) > 0;
        }
        // POST api/profesors
        public HttpResponseMessage Postprofesor(profesor profesor)
        {
            if (ModelState.IsValid)
            {
                if (profesorExists(profesor.idprofesor))
                {
                    db.Entry(profesor).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    db.profesors.Add(profesor);
                    db.SaveChanges();
                }

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, profesor);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = profesor.idprofesor }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/profesors/5
        public HttpResponseMessage Deleteprofesor(int id)
        {
            profesor profesor = db.profesors.Find(id);
            if (profesor == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.profesors.Remove(profesor);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, profesor);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}