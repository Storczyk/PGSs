using PGSs.DAL;
using PGSs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PGSs.Services
{
    public class ActorService
    {
        internal bool Add(int movieId, ActorRequest actorRequest)
        {
            using (var ctx = new TvApiContext())
            {
                if (ctx.Movies.FirstOrDefault(i => i.Id == movieId) == null)
                {
                    return false;
                }
                var actor = ctx.Actors.FirstOrDefault(i => i.Surname == actorRequest.Surname && i.Forename == actorRequest.Forename && i.Birthdate == actorRequest.Birthdate);
                if (actor == null)
                {
                    actor = new Actor()
                    {
                        Forename = actorRequest.Forename,
                        Surname = actorRequest.Surname,
                        Birthdate = actorRequest.Birthdate
                    };
                }
                ctx.Movies.Find(movieId).Actors.Add(actor);
                ctx.SaveChanges();
                return true;
            }
        }
        /*Filmy w ktorych wystapic aktor Filmy w ktorych wystapic aktor Filmy w ktorych wystapic aktor Filmy w ktorych wystapic aktor*/
        internal IEnumerable<MovieResponse> GetMoviesForActor(int actorId)
        {
            using (var ctx = new TvApiContext())
            {
                var actor = ctx.Actors.Find(actorId);
                if(actor == null)
                {
                    return null;
                }
                return actor.Movies.OrderBy(i => i.Title).Select(m => new MovieResponse()
                {
                    Id = m.Id,
                    Title = m.Title,
                    Year = m.Year,
                    Genre = m.Genre
                }).ToList();
            }
        }

        internal IEnumerable<ActorRespone> GetActorsForMovie(int movieId)
        {
            using (var ctx = new TvApiContext())
            {
                var movie = ctx.Movies.Find(movieId);
                if (movie == null)
                {
                    return null;
                }

                return movie.Actors.Select(a => new ActorRespone()
                {
                    Id = a.Id,
                    Forename = a.Forename,
                    Surname = a.Surname,
                    Birthdate = a.Birthdate
                }).ToList();
            }
        }

        internal void DeleteFromDb(int actorId)
        {
            using (var ctx = new TvApiContext())
            {
                var actor = ctx.Actors.Find(actorId);
                if (actor == null)
                {
                    return;
                }
                ctx.Actors.Remove(actor);
                ctx.SaveChanges();
            }
        }

        internal bool DeleteFromMovie(int movieId, int actorId)
        {
            using (var ctx = new TvApiContext())
            {
                var movie = ctx.Movies.Find(movieId);
                if (movie == null)
                {
                    return false;
                }
                var actor = ctx.Actors.Find(actorId);
                if (actor == null)
                {
                    return false;
                }
                movie.Actors.Remove(actor);
                ctx.SaveChanges();
                return true;
            }
        }

        internal IEnumerable<ActorRespone> GetAllActors()
        {
            using (var ctx = new TvApiContext())
            {
                return ctx.Actors.Select(a => new ActorRespone()
                {
                    Id = a.Id,
                    Forename = a.Forename,
                    Surname = a.Surname,
                    Birthdate = a.Birthdate
                }).ToList();
            }
        }
    }
}