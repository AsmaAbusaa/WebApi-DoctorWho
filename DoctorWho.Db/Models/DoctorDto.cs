using DoctorWho.Db.Entities;
using System.ComponentModel.DataAnnotations;

namespace DoctorWho.Db.Models
{
    public class DoctorDto
    {
        public string DoctorName { get; set; }
        public int DoctorNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime FirstEpisodeDate { get; set; } = new DateTime();
        public DateTime LastEpisodeDate { get; set; }=new DateTime();
        public ICollection<EpisodeDtoWithoutCompEnem> Episodes { get; set; } = new List<EpisodeDtoWithoutCompEnem>();

    }
}
