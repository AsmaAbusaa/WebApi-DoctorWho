namespace DoctorWho.Db.Models
{
    public class DoctorDtoWithoutEpisodes
    {

        public string DoctorName { get; set; } = string.Empty;
        public int DoctorNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime? FirstEpisodeDate { get; set; }
        public DateTime? LastEpisodeDate { get; set; }
    }
}
