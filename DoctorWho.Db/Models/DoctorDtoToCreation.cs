namespace DoctorWho.Db.Models
{
    public class DoctorDtoToCreation
    {
        public int Id { get; set; }
        public string DoctorName { get; set; } = string.Empty;
        public int DoctorNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime FirstEpisodeDate { get; set; }
        public DateTime LastEpisodeDate { get; set; }
    }
}
