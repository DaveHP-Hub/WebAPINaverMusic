using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace webAPI_NaverMusic.Models
{
    public partial class BDNaverMusicContext : DbContext
    {
        public BDNaverMusicContext()
        {
        }

        public BDNaverMusicContext(DbContextOptions<BDNaverMusicContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Favorite> Favorites { get; set; }
        public virtual DbSet<Subscription> Subscriptions { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Vote> Votes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Favorite>(entity =>
            {
                entity.HasKey(e => e.IdFavorite)
                    .HasName("PK__Favorite__36472CA67F8530D5");

                entity.Property(e => e.IdFavorite).HasColumnName("idFavorite");

                entity.Property(e => e.Apiname)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("apiname");

                entity.Property(e => e.IdGetFav)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("idGetFav");

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.Property(e => e.NameFav)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nameFav");

                entity.Property(e => e.PictureFav)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("pictureFav");

                entity.Property(e => e.SongFav)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("songFav");

                entity.Property(e => e.TypeFav)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("typeFav");

                entity.Property(e => e.Uri)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("uri");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Favorites)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK__Favorites__idUse__398D8EEE");
            });

            modelBuilder.Entity<Subscription>(entity =>
            {
                entity.HasKey(e => e.IdSubs)
                    .HasName("PK__Subscrip__C1F6B5A221299CBA");

                entity.Property(e => e.IdSubs).HasColumnName("idSubs");

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.Property(e => e.PayUser)
                    .HasColumnType("money")
                    .HasColumnName("payUser");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("status_");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Subscriptions)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK__Subscript__idUse__3F466844");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PK__Users__3717C98213AC94E0");

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Forename)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("forename");

                entity.Property(e => e.Gender)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("gender")
                    .IsFixedLength(true);

                entity.Property(e => e.Nationality)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("nationality");

                entity.Property(e => e.Numberphone)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("numberphone");

                entity.Property(e => e.Picture)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("picture");

                entity.Property(e => e.Pwd)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("pwd");

                entity.Property(e => e.Surname)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("surname");

                entity.Property(e => e.Username)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<Vote>(entity =>
            {
                entity.HasKey(e => e.IdVote)
                    .HasName("PK__Votes__0355858F6E578228");

                entity.Property(e => e.IdVote).HasColumnName("idVote");

                entity.Property(e => e.Apiname)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("apiname");

                entity.Property(e => e.DateVote)
                    .HasColumnType("date")
                    .HasColumnName("dateVote");

                entity.Property(e => e.IdGetVote)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("idGetVote");

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.Property(e => e.NameVote)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nameVote");

                entity.Property(e => e.PictureVote)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("pictureVote");

                entity.Property(e => e.TypeVote)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("typeVote");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Votes)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK__Votes__idUser__3C69FB99");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
