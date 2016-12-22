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
        internal bool Add(int movieId, ActorRequest actor)
        {
            using (var ctx = new TvApiContext())
            {
                if (ctx.Movies.FirstOrDefault(i => i.Id == movieId) == null)
                {
                    return false;
                }
                var existingActor = ctx.Actors.FirstOrDefault(i => i.Surname == actor.Surname && i.Forename == actor.Forename && i.Birthdate == actor.Birthdate);
                if (existingActor == null)
                {
                    ctx.Movies.Find(movieId).Actors.Add(new Actor()
                    {
                        Surname = actor.Surname,
                        Forename = actor.Forename,
                        Birthdate = actor.Birthdate
                    });
                    ctx.SaveChanges();
                    return true;
                }
                ctx.Movies.Find(movieId).Actors.Add(existingActor);
                ctx.SaveChanges();
                return true;
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
                if(actor == null)
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
                if(actor==null)
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