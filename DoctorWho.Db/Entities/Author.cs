namespace DoctorWho.Db.Entities
{
    public class Author
    {
        public Author()
        {
            episodes = new List<Episode>();
        }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public List<Episode> episodes { get; set; }
    }
}
