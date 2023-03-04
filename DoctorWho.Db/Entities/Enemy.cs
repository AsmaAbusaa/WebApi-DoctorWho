namespace DoctorWho.Db.Entities
{
    public class Enemy
    {
        public Enemy()
        {
            Episodes = new List<Episode>();
        }
        public int EnemyId { get; set; }
        public string EnemyName { get; set; }
        public string Description { get; set; }
        public ICollection<Episode> Episodes { get; set; }
    }
}
