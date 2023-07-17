using MovieDb.Models;

namespace MovieDb.Services
{
    public interface IJobService
    {
        void AddJob(MovieModel moviemodel);
    }
}
