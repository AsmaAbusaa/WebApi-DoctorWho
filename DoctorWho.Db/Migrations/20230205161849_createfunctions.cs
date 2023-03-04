using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorWho.Db.Migrations
{
    /// <inheritdoc />
    public partial class createfunctions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"CREATE FUNCTION fnCompanions(
                  @episodeId INT
                )
                RETURNS  varchar(255) AS
                BEGIN
                DECLARE @count INT
                DECLARE @result varchar(255)
                SET @count=1
                SET @result =''
                SELECT @result = @result+CONCAT('Companion ',@count)+' '+C.CompanionName+', ',
                @count=@count+1
                from Companions as C INNER JOIN CompanionEpisode as EC
	            ON C.CompanionId=EC.CompanionsCompanionId 
	            where EC.EpisodesEpisodeId=@episodeId
                return @result
                END;
                Go"
               );

            migrationBuilder.Sql(
                @"CREATE FUNCTION fnEnemies(
                @episodeId INT
                )
                RETURNS  varchar(255) AS
                BEGIN
                DECLARE @count INT
                DECLARE @result varchar(255)
                SET @count=1
                SET @result =''
                SELECT @result = @result+CONCAT('Enemy ',@count)+' '+E.EnemyName+', ',
                @count=@count+1
                FROM Enemies as E INNER JOIN EnemyEpisode as EE
                ON E.EnemyId=EE.EnemiesEnemyId
                WHERE EE.EpisodesEpisodeId= @episodeId
                return @result
                END;
                Go"
                );

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP FUNCTION fnCompanions");
            migrationBuilder.Sql("DROP FUNCTION fnEnemies");

        }
    }
}
