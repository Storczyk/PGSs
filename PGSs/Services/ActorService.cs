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
                ctx.Movies.Find(movieId).Actors.Add(new Actor()
                {
                    Surname = actor.Surname,
                    Forename = actor.Forename,
                });
                ctx.SaveChanges();
                return true;
            }
        }

        internal IEnumerable<ActorRespone> GetActors(int? movieId = null)
        {
            using (var ctx = new TvApiContext())
            {
                if (movieId.HasValue)
                {
                    var movie = ctx.Movies.Find(movieId);
                    if (movie == null)
                    {
                        return null;
                    }
                    if (movie.Actors.Any())
                    {
                        return movie.Actors.Select(a => new ActorRespone()
                        {
                            Id = a.Id,
                            Forename = a.Forename,
                            Surname = a.Surname
                        }).ToList();
                    }
                    return null;

                }
                if (ctx.Actors.Any())
                {
                    return ctx.Actors.Select(a => new ActorRespone()
                    {
                        Id = a.Id,
                        Forename = a.Forename,
                        Surname = a.Surname
                    }).ToList();
                }
                return null;
            }
        }


    }
}