using MovieDb.Models;
using System.ComponentModel.DataAnnotations;

namespace MovieDb.Entities
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public bool Adult { get; set; }
        public string Backdrop_path { get; set; }
        public ICollection<Genre_ids> genre_ids { get; } = new List<Genre_ids>();
        // public List<int> genre_ids { get; set; }        
        public string Original_language { get; set; }
        public string Original_title { get; set; }
        public string Overview { get; set; }
        public double Popularity { get; set; }
        public string Poster_path { get; set; }
        public string Release_date { get; set; }
        public string Title { get; set; }
        public bool Video { get; set; }
        public double Vote_average { get; set; }
        public int Vote_count { get; set; }
    }
}
