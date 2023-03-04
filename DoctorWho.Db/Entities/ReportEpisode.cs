namespace DoctorWho.Db.Entities
{
    public class ReportEpisode
    {
        public int EpisodeId { get; set; }
        public string? Title { get; set; }
        public string? AuthorName { get; set; }
        public string? DoctorName { get; set; }
        public string? CompanionsName { get; set; }
        public string? EnemiesName { get; set; }
        public override string ToString()
        {
            return " Episode Id : " + EpisodeId
                + " Title : " + Title
                + " Author Name : " + AuthorName
                + " Doctor Name : " + DoctorName
                + " Comapnions Name : " + CompanionsName
                + " Enemies Name : " + EnemiesName;
        }
    }
}
