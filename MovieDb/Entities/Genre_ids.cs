namespace MovieDb.Entities
{
    public class Genre_ids
    {
        public int Id { get; set; }
        public int GenreId { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; } = null!;
    }
}
