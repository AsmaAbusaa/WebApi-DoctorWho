using DoctorWho.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db;
public class DoctorWhoCoreDbContext : DbContext
{
    public DbSet<Episode> Episodes { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Companion> Companions { get; set; }
    public DbSet<Enemy> Enemies { get; set; }
    public DbSet<EnemyEpisode> EnemyEpisode { get; set; }
    public DbSet<CompanionEpisode> CompanionEpisode { get; set; }
    public DbSet<ReportEpisode> viewReport { get; set; }

    public DoctorWhoCoreDbContext(DbContextOptions<DoctorWhoCoreDbContext> options)
              : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ReportEpisode>().HasNoKey().ToView("viewReport");

        List<Doctor> doctors = new List<Doctor>
        {
            new Doctor { DoctorId=200, DoctorNumber = 1, DoctorName = "William Hartnell", BirthDate = DateTime.Now.Date, FirstEpisodeDate = DateTime.Now.Date, LastEpisodeDate = DateTime.Now.Date },
            new Doctor { DoctorId=201, DoctorNumber = 2, DoctorName = "Peter Capaldi", BirthDate = DateTime.Now.Date, FirstEpisodeDate = DateTime.Now.Date, LastEpisodeDate = DateTime.Now.Date },
            new Doctor { DoctorId=202, DoctorNumber = 3, DoctorName = "Jon Pertwee", BirthDate = DateTime.Now.Date, FirstEpisodeDate = DateTime.Now.Date, LastEpisodeDate = DateTime.Now.Date },
            new Doctor { DoctorId=203, DoctorNumber = 4, DoctorName = "Patrick Troughton", BirthDate = DateTime.Now.Date, FirstEpisodeDate = DateTime.Now.Date, LastEpisodeDate = DateTime.Now.Date },
            new Doctor { DoctorId=204, DoctorNumber = 5, DoctorName = "Sylvester McCoy", BirthDate = DateTime.Now.Date, FirstEpisodeDate = DateTime.Now.Date, LastEpisodeDate = DateTime.Now.Date }
        };
        modelBuilder.Entity<Doctor>().HasData(doctors);

        List<Author> authors = new List<Author>
        {
            new Author{ AuthorId=1000, AuthorName="Ahmad" },
            new Author{ AuthorId=1001, AuthorName="Mohammad" },
            new Author{ AuthorId=1002, AuthorName="Amr" },
            new Author{ AuthorId=1003, AuthorName="Subhi" },
            new Author{ AuthorId=1004, AuthorName="Rana"}
        };
        modelBuilder.Entity<Author>().HasData(authors);

        List<Enemy> enemies = new List<Enemy>
        {
            new Enemy{EnemyId=100, EnemyName="Army", Description="Armies are small armadillo enemies that appear in Donkey Kong Country and Donkey Kong Land." },
            new Enemy{EnemyId=101, EnemyName="Beach Koopa", Description="is a Koopa Troopa that has lost its shell and wears nothing more than an undershirt" },
            new Enemy{EnemyId=102, EnemyName="Buzzes", Description="also named Green Zingers and Buzzers" },
            new Enemy{EnemyId=103, EnemyName="Croctopus", Description="Croctopuses appear in blue and purple varieties, and their color scheme resembles the venomous blue-ringed octopus." },
            new Enemy{EnemyId=104, EnemyName="Grunts", Description="are heavy enemies found in Wario Land II" }
        };
        modelBuilder.Entity<Enemy>().HasData(enemies);

        List<Companion> companion = new List<Companion>
        {
           new Companion{ CompanionId=1,CompanionName="Susan Foreman",WhoPlayed="Carole Ann Ford" },
           new Companion{ CompanionId=2,CompanionName="Polly",WhoPlayed="Anneke Wills" },
           new Companion{ CompanionId=3,CompanionName="Liz Shaw",WhoPlayed="Caroline John" },
           new Companion{ CompanionId=7,CompanionName="Mel Bush",WhoPlayed="Bonnie Langford" },
           new Companion{ CompanionId=12,CompanionName="River Song",WhoPlayed="Alex Kingston" }
        };
        modelBuilder.Entity<Companion>().HasData(companion);

        modelBuilder.Entity<Episode>(entity =>
        {
            entity.Property(n => n.Notes).HasDefaultValue("No Notes");
            entity.Property(t => t.EpisodeType).HasDefaultValue("Episode Type");
        });


        List<Episode> episodes = new List<Episode>
        {
            new Episode{EpisodeId=300,SeriesNumber=1,EpisodeNumber=2,Title="The Forest of Fear",EpisodeDate=new DateTime(1963,12,14),AuthorId=1002,DoctorId=200},
            new Episode{EpisodeId=301,SeriesNumber=3,EpisodeNumber=42,Title="An Unearthly Child",EpisodeDate=new DateTime(2013,12,25),AuthorId=1000,DoctorId=200},
            new Episode{EpisodeId=302,SeriesNumber=9,EpisodeNumber=241,Title="The Time of the Doctor",EpisodeDate=new DateTime(2013,12,25),AuthorId=1001,DoctorId=202},
            new Episode{EpisodeId=303,SeriesNumber=8,EpisodeNumber=21,Title="Deep Breath",EpisodeDate=new DateTime(2014,8,5),AuthorId=1003,DoctorId=204},
            new Episode{EpisodeId=304,SeriesNumber=10,EpisodeNumber=275,Title="The Doctor Falls",EpisodeDate=new DateTime(2013,1,23),AuthorId=1004,DoctorId=201 }
        };
        modelBuilder.Entity<Episode>().HasData(episodes);

        //Explicit Join Entity
        modelBuilder.Entity<Episode>()
            .HasMany(a => a.Enemies)
            .WithMany(e => e.Episodes)
            .UsingEntity<EnemyEpisode>
            (
             e => e.HasOne(e => e.Enemy).WithMany(),
             e => e.HasOne(e => e.Episode).WithMany()
            );
        modelBuilder.Entity<Episode>()
            .HasMany(c => c.Companions)
            .WithMany(e => e.Episodes)
            .UsingEntity<CompanionEpisode>(
            c=>c.HasOne(c=>c.Companion).WithMany(),
            e=>e.HasOne(e=>e.Episode).WithMany()
            );
        modelBuilder.Entity<EnemyEpisode>()
                         .Property(e=>e.EpisodeId).HasColumnName("EpisodesEpisodeId");
        modelBuilder.Entity<EnemyEpisode>()
                     .Property(x=>x.EnemyId).HasColumnName("EnemiesEnemyId");
        modelBuilder.Entity<CompanionEpisode>()
            .Property(c => c.CompanionId).HasColumnName("CompanionsCompanionId");
        modelBuilder.Entity<CompanionEpisode>()
            .Property(e => e.EpisodeId).HasColumnName("EpisodesEpisodeId");
    }
    [DbFunction("fnEnemies", "dbo")]
    public string GetEnemiesByEpisodeId(int id) => throw new NotSupportedException();

    [DbFunction("fnCompanions", "dbo")]
    public string GetCompanionsByEpisodeId(int id) => throw new NotSupportedException();


}
