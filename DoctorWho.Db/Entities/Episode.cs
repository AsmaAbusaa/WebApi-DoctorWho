namespace DoctorWho.Db.Entities
{
    public class Episode
    {
        public Episode()
        {
            Companions = new List<Companion>();
            Enemies = new List<Enemy>();
        }
        public int EpisodeId { get; set; }
        public int SeriesNumber { get; set; }
        public int EpisodeNumber { get; set; }
        public string EpisodeType { get; set; }
        public string Title { get; set; }
        public DateTime EpisodeDate { get; set; }
        public Author Author { get; set; }
        public int AuthorId { get; set; }
        public Doctor Doctor { get; set; }
        public int DoctorId { get; set; }
        public string Notes { get; set; }
        public ICollection<Companion> Companions { get; set; }
        public ICollection<Enemy> Enemies { get; set; }
    }
}
