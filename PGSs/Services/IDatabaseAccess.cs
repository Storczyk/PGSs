using PGSs.Models;

namespace PGSs.Services
{
    internal interface IDatabaseAccess
    {
        void Add(MovieRequest movie);
        void Add(ReviewRequest review, int movieId);
        void Add(ActorRequest actor, int movieId);
    }
}