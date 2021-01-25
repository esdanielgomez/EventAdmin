using System;
using EventAdmin.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EventAdmin.DAL
{
    public partial class DBContext : DbContext
    {
        public DBContext()
        {
        }

        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<Organizer> Organizer { get; set; }
        public virtual DbSet<Session> Session { get; set; }
        public virtual DbSet<Sessionlevel> Sessionlevel { get; set; }
        public virtual DbSet<Sessiontype> Sessiontype { get; set; }
        public virtual DbSet<Speaker> Speaker { get; set; }
        public virtual DbSet<SpeakerHasSession> SpeakerHasSession { get; set; }
        public virtual DbSet<Sponsor> Sponsor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>(entity =>
            {
                entity.HasKey(e => e.IdEvent)
                    .HasName("PRIMARY");

                entity.ToTable("event");

                entity.Property(e => e.IdEvent).HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Icon)
                    .HasMaxLength(45)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.RegistrationLink)
                    .HasMaxLength(45)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.StreamingLink)
                    .HasMaxLength(45)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Organizer>(entity =>
            {
                entity.HasKey(e => e.IdOrganizer)
                    .HasName("PRIMARY");

                entity.ToTable("organizer");

                entity.HasIndex(e => e.IdEvent)
                    .HasName("fk_Organizer_Event1_idx");

                entity.Property(e => e.IdOrganizer).HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .HasMaxLength(45)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Email)
                    .HasMaxLength(45)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.FacebookLink)
                    .HasMaxLength(45)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IdEvent).HasColumnType("int(11)");

                entity.Property(e => e.InstagramLink)
                    .HasMaxLength(45)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.LogoLink)
                    .HasMaxLength(45)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.TwitterLink)
                    .HasMaxLength(45)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.WebPage)
                    .HasMaxLength(45)
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.IdEventNavigation)
                    .WithMany(p => p.Organizer)
                    .HasForeignKey(d => d.IdEvent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Organizer_Event1");
            });

            modelBuilder.Entity<Session>(entity =>
            {
                entity.HasKey(e => e.IdSession)
                    .HasName("PRIMARY");

                entity.ToTable("session");

                entity.HasIndex(e => e.IdSessionLevel)
                    .HasName("fk_Session_SessionLevel1_idx");

                entity.HasIndex(e => e.IdSessionType)
                    .HasName("fk_Session_SessionType1_idx");

                entity.Property(e => e.IdSession).HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IconLink)
                    .HasMaxLength(45)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IdSessionLevel).HasColumnType("int(11)");

                entity.Property(e => e.IdSessionType).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.IdSessionLevelNavigation)
                    .WithMany(p => p.Session)
                    .HasForeignKey(d => d.IdSessionLevel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Session_SessionLevel1");

                entity.HasOne(d => d.IdSessionTypeNavigation)
                    .WithMany(p => p.Session)
                    .HasForeignKey(d => d.IdSessionType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Session_SessionType1");
            });

            modelBuilder.Entity<Sessionlevel>(entity =>
            {
                entity.HasKey(e => e.IdSessionLevel)
                    .HasName("PRIMARY");

                entity.ToTable("sessionlevel");

                entity.Property(e => e.IdSessionLevel).HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .HasMaxLength(45)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Sessiontype>(entity =>
            {
                entity.HasKey(e => e.IdSessionType)
                    .HasName("PRIMARY");

                entity.ToTable("sessiontype");

                entity.Property(e => e.IdSessionType).HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .HasMaxLength(45)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Speaker>(entity =>
            {
                entity.HasKey(e => e.IdSpeaker)
                    .HasName("PRIMARY");

                entity.ToTable("speaker");

                entity.HasIndex(e => e.IdEvent)
                    .HasName("fk_Speaker_Event_idx");

                entity.Property(e => e.IdSpeaker).HasColumnType("int(11)");

                entity.Property(e => e.FirstLastName)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.IdEvent).HasColumnType("int(11)");

                entity.Property(e => e.LinkedInLink)
                    .HasMaxLength(45)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.PhotoLink)
                    .HasMaxLength(45)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.SecondLastName)
                    .HasMaxLength(45)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.SecondName)
                    .HasMaxLength(45)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.TwitterLink)
                    .HasMaxLength(45)
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.IdEventNavigation)
                    .WithMany(p => p.Speaker)
                    .HasForeignKey(d => d.IdEvent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Speaker_Event");
            });

            modelBuilder.Entity<SpeakerHasSession>(entity =>
            {
                

                entity.ToTable("speaker_has_session");

                entity.HasIndex(e => e.IdSession)
                    .HasName("fk_Speaker_has_Session_Session1_idx");

                entity.HasIndex(e => e.IdSpeaker)
                    .HasName("fk_Speaker_has_Session_Speaker1_idx");

                entity.HasKey(e => e.IdSession).HasName("PRIMARY");
                entity.HasKey(e => e.IdSpeaker).HasName("PRIMARY");

                //entity.Property(e => e.IdSession).HasColumnType("int(11)");

                //entity.Property(e => e.IdSpeaker).HasColumnType("int(11)");

                entity.HasOne(d => d.IdSessionNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdSession)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Speaker_has_Session_Session1");

                entity.HasOne(d => d.IdSpeakerNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdSpeaker)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Speaker_has_Session_Speaker1");
            });

            modelBuilder.Entity<Sponsor>(entity =>
            {
                entity.HasKey(e => e.IdSponsor)
                    .HasName("PRIMARY");

                entity.ToTable("sponsor");

                entity.HasIndex(e => e.IdEvent)
                    .HasName("fk_Sponsor_Event1_idx");

                entity.Property(e => e.IdSponsor).HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .HasMaxLength(45)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IdEvent).HasColumnType("int(11)");

                entity.Property(e => e.LogoLink)
                    .HasMaxLength(45)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.WebPage)
                    .HasMaxLength(45)
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.IdEventNavigation)
                    .WithMany(p => p.Sponsor)
                    .HasForeignKey(d => d.IdEvent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Sponsor_Event1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
