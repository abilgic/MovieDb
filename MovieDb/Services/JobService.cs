using MovieDb.Entities;
using MovieDb.Models;


namespace MovieDb.Services
{
    public class JobService : IJobService
    {
        ApplicationDbContext context_;
        public JobService(ApplicationDbContext context)
        {
            context_ = context;
        }

        public void AddJob(MovieModel moviemodel)
        {
            try
            {
                foreach (var result in moviemodel.results)
                {
                    var movie = new Movie
                    {
                        Adult = result.adult,
                        Backdrop_path = result.backdrop_path,
                        Original_language = result.original_language,
                        Original_title = result.original_title,
                        Overview = result.overview,
                        Popularity = result.popularity,
                        Poster_path = result.poster_path,
                        Release_date = result.release_date,
                        Title = result.title,
                        Video = result.video,
                        Vote_average = result.vote_average,
                        Vote_count = result.vote_count
                    };

                    foreach (var genreid in result.genre_ids)
                    {
                        var genre_id = new Genre_ids
                        {
                            GenreId = genreid
                        };
                        movie.genre_ids.Add(genre_id);


                    }
                    context_.Add(movie);
                    context_.SaveChanges();


                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
