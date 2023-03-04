namespace DoctorWho.Db.Entities
{
    public class EnemyEpisode
    { 
        public int EpisodeId { get; set; }
        public int EnemyId { get; set; }
        public Episode Episode { get; set; }
        public Enemy Enemy { get; set; }
    }
}
