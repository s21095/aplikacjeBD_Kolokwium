using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Models
{
    public class MainDbContext : DbContext
    {
        protected MainDbContext()
        {
        }
        public MainDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Album> Album { get; set; }
        public DbSet<Musician> Musician { get; set; }
        public DbSet<Musician_Track> Musician_Track { get; set; }
        public DbSet<MusicLabel> MusicLabel { get; set; }
        public DbSet<Track> Track { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Album>(e =>
            {
                e.HasKey(e => e.IdAlbum);
                e.Property(e => e.AlbumName).IsRequired().HasMaxLength(30);
                e.Property(e => e.PublishDate).IsRequired();
                e.HasOne(e => e.MusicLabel).WithMany(e => e.Albums).HasForeignKey(e => e.IdMusicLabel);

                e.HasData(
                  new Album
                  {
                      IdAlbum = 1,
                      AlbumName = "Muzyka Klasyczna",
                      PublishDate = DateTime.Parse("2010-01-10"),
                      IdMusicLabel = 1
                  },
                  new Album
                  {
                      IdAlbum = 2,
                      AlbumName = "Muzyka Rozrywkowka",
                      PublishDate = DateTime.Parse("2022-01-10"),
                      IdMusicLabel = 1
                  },
                  new Album
                     {
                          IdAlbum = 3,
                          AlbumName = "Muzyka Rockowa",
                          PublishDate = DateTime.Parse("2012-01-10"),
                          IdMusicLabel = 2
                      }
              );

            });


            modelBuilder.Entity<Musician>(e =>
            {
                e.HasKey(e => e.IdMusician);
                e.Property(e => e.FirstName).IsRequired().HasMaxLength(30);
                e.Property(e => e.LastName).IsRequired().HasMaxLength(50);
                e.Property(e => e.Nickname).HasMaxLength(50);

                e.HasData(
                  new Musician
                  {
                      IdMusician = 1,
                      FirstName = "Bob",
                      LastName = "Smith",
                      Nickname = "Smithy"
                  },
                  new Musician
                  {
                      IdMusician = 2,
                      FirstName = "John",
                      LastName = "Doe",
                      Nickname = "TheMissing"
                  }
             
              );

            });

            modelBuilder.Entity<Musician_Track>(e =>
            {
                e.HasKey(e => new { e.IdTrack, e.IdMusician });
                e.HasOne(e => e.Musician).WithMany(e => e.Musician_Tracks).HasForeignKey(e => e.IdMusician);
                e.HasOne(e => e.Track).WithMany(e => e.Musician_Tracks).HasForeignKey(e => e.IdTrack);

                e.HasData(
                  new Musician_Track
                  {
                     IdTrack = 1,
                     IdMusician = 1
                  },
                  new Musician_Track
                  {
                      IdTrack = 2,
                      IdMusician = 2
                  }

              );


            });

            modelBuilder.Entity<MusicLabel>(e =>
            {
                e.HasKey(e => e.IdMusicLabel);
                e.Property(e => e.Name).IsRequired().HasMaxLength(50);


                e.HasData(
                  new MusicLabel
                  {
                      IdMusicLabel = 1,
                      Name = "Babylon"
                  },
                  new MusicLabel
                  {
                      IdMusicLabel = 2,
                      Name = "Records"
                  }

              );
            });

            modelBuilder.Entity<Track>(e =>
            {
                e.HasKey(e => e.IdTrack);
                e.Property(e => e.TrackName).IsRequired().HasMaxLength(20);
                e.Property(e => e.Duration).IsRequired();
                e.HasOne(e => e.Album).WithMany(e => e.Tracks).HasForeignKey(e => e.IdMusicAlbum);

                e.HasData(
                  new Track
                  {
                      IdTrack = 1,
                      TrackName = "Cztery pory roku",
                      Duration = 60,
                      IdMusicAlbum = 1
                  },
                  new Track
                  {
                      IdTrack = 2,
                      TrackName = "Interstellar Main Theme",
                      Duration = 60,
                      IdMusicAlbum = 2
                  }

              ); ;

            });
        }
    }
}
