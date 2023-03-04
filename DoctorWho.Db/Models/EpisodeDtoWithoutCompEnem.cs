using DoctorWho.Db.Entities;

namespace DoctorWho.Db.Models
{
    public class EpisodeDtoWithoutCompEnem
    {
        public string Title { get; set; }
        public int SeriesNumber { get; set; }
        public int EpisodeNumber { get; set; }
        public string EpisodeType { get; set; }
        public DateTime EpisodeDate { get; set; }
        public int AuthorId { get; set; }
        public int DoctorId { get; set; }
        public string Notes { get; set; }
    }
}
