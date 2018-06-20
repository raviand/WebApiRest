using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MoviesApi.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
namespace MoviesApi.Controllers
{
    public class MoviesController : ApiController
    {

        private MOVIE_WEBModel db = new MOVIE_WEBModel();
        // GET: api/Movies
        public IQueryable<MOVy> GetMovie()
        {
            return db.MOVIES;
        }

        // GET: api/Movies/5
        [ResponseType(typeof(MOVy))]
        public IHttpActionResult GetMovie(int id)
        {
            MOVy movie = db.MOVIES.Find(id);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
        }

        // PUT: api/Movies/5
        public IHttpActionResult PutMovie(int id, MOVy movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != movie.ID)
            {
                return BadRequest();
            }

            db.Entry(movie).State = EntityState.Modified;
            try
            {
                db.SaveChanges();
            }
            catch (Exception)
            {
                if (!ModelState.IsValid)
                {
                    return NotFound();
                }
                else
                    throw;
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Movies
        [ResponseType(typeof(MOVy))]
        public IHttpActionResult PostMovie(MOVy movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.MOVIES.Add(movie);
            db.SaveChanges();

            return CreatedAtRoute("defaultApi", new { id = movie.ID }, movie);
        }

        // DELETE: api/Movies/5
        [ResponseType(typeof(MOVy))]
        public IHttpActionResult DeleteMovie(int id)
        {
            MOVy movie = db.MOVIES.Find(id);
            if (movie == null)
            {
                return NotFound();
            }
            db.MOVIES.Remove(movie);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
