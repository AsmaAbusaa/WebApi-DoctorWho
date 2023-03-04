using DoctorWho.Db.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db.Repositories
{
    public class EpisodeRepository
    {
        private readonly DoctorWhoCoreDbContext context;

        public EpisodeRepository(DoctorWhoCoreDbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddEpisode(int episodeNumber, string type,
                              DateTime episodeDate, string title, int authorId, int doctorId, int sereiesNumber)
        {
            context.Episodes.Add(
               new Episode
               {
                   EpisodeType = type,
                   EpisodeDate = episodeDate,
                   EpisodeNumber = episodeNumber,
                   AuthorId = authorId,
                   DoctorId = doctorId,
                   Title = title,
                   SeriesNumber = sereiesNumber
               });
            context.SaveChanges();
        }

        public async Task AddEpisode(Episode episode)
        {
            context.Episodes.Add(episode);
            await context.SaveChangesAsync();

        }
        public async Task<ActionResult> DeleteEpisode(int id)
        {
            var episode = context.Episodes.Find(id);
            if (episode == null)
                return new NotFoundResult();
            if (episode != null)
                context.Episodes.Remove(episode);
            await context.SaveChangesAsync();
            return new NoContentResult();
        }

        public async Task<IEnumerable<Episode>> GetEpisodes()
        {
            return await context.Episodes.
                OrderByDescending(e => e.EpisodeDate).ToListAsync();
        }

        public async Task<Episode?> GetEpisode(int id)
        {
            return await context.Episodes.FindAsync(id);
        }

        public async Task<IActionResult> AddEnemyToEpisode(int enemyId, int episodeId)
        {
            var enemyEntity = await context.Enemies.FindAsync(enemyId);

            if (enemyEntity == null)
                return new NotFoundResult();

            EnemyEpisode enemyEpisode = new EnemyEpisode { EnemyId = enemyId, EpisodeId = episodeId };
            var enemyEpisodeEntity = await context.EnemyEpisode
                .Where(x => x.EnemyId == enemyId && x.EpisodeId == episodeId)
                .FirstOrDefaultAsync();

            if (enemyEpisodeEntity != null)
                return new NoContentResult();

            context.Add(enemyEpisode);
            await context.SaveChangesAsync();

            return new OkResult();
        }

        public async Task<IActionResult> AddCompanionToEpisode(int companionId, int episodeId)
        {
            var companionEntity = await context.Companions.FindAsync(companionId);
            if (companionEntity == null)
                return new NotFoundResult();
            var companionEpisode = new CompanionEpisode { CompanionId = companionId, EpisodeId = episodeId };

            var companionEpisodeEntity = await context.CompanionEpisode
               .Where(x => x.CompanionId == companionId && x.EpisodeId == episodeId)
               .FirstOrDefaultAsync();

            if (companionEpisodeEntity != null)
                return new NoContentResult();

            context.Add(companionEpisode);
            await context.SaveChangesAsync();

            return new OkResult();
        }

    }
}
