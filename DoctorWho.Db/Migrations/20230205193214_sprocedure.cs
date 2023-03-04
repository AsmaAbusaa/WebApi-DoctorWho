using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorWho.Db.Migrations
{
    /// <inheritdoc />
    public partial class sprocedure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {migrationBuilder.Sql(
            @"CREATE PROCEDURE spSummariseEpisodes AS
                 BEGIN 
            SELECT EnemyName AS Top3_Enemies
FROM Enemies
where EnemyId IN(
SELECT TOP 3 EnemyId
FROM EnemyEpisode
GROUP BY EnemiesEnemyId
ORDER BY COUNT(EpisodesEpisodeId) desc
)

SELECT CompanionName AS Top3_Companions
FROM Companions
where CompanionId IN(
SELECT TOP 3 CompanionId 
FROM CompanionEpisode
GROUP BY CompanionsCompanionId
ORDER BY COUNT(EpisodesEpisodeId) desc)

END;
");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE spSummariseEpisodes");
        }
    }

}
