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
    public class PeopleController : ApiController
    {
        private MOVIE_WEBModel db = new MOVIE_WEBModel();
        // GET: api/People
        public IQueryable<PERSON> GetPerson()
        {
            return db.PERSONS;
        }

        // GET: api/People/5
        [ResponseType (typeof(PERSON))]
        public IHttpActionResult GetPerson(int id)
        {
            PERSON person = db.PERSONS.Find(id);
            if(person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        // PUT: api/People/5
        public IHttpActionResult  PutPerson(int id, PERSON person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != person.ID)
            {
                return BadRequest(); 
            }

            db.Entry(person).State = EntityState.Modified;
            try
            {
                db.SaveChanges();
            }
            catch (Exception)
            {
                if (!ModelState.IsValid)
                {
                    return NotFound();
                }else
                    throw;
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/People
        [ResponseType(typeof(PERSON))]
        public IHttpActionResult PostPerson(PERSON person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.PERSONS.Add(person);
            db.SaveChanges();

            return CreatedAtRoute("defaultApi", new { id = person.ID }, person);
        }

        // DELETE: api/People/5
        [ResponseType(typeof(PERSON))]
        public IHttpActionResult DeletePerson(int id)
        {
            PERSON person = db.PERSONS.Find(id);
            if (person == null)
            {
                return NotFound();
            }
            db.PERSONS.Remove(person);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
