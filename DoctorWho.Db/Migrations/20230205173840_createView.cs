using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorWho.Db.Migrations
{
    /// <inheritdoc />
    public partial class createView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @" CREATE VIEW viewReport AS( 
 SELECT dbo.fnEnemies(e.EpisodeId)AS EnemiesName,dbo.fnCompanions(e.EpisodeId)AS CompanionsName,d.DoctorName,a.AuthorName
 FROM Episodes AS e INNER JOIN Authors AS a on a.AuthorId=e.AuthorId
 INNER JOIN Doctors as d on d.DoctorId=e.DoctorId
 )");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW viewReport");
        }

    }

}
