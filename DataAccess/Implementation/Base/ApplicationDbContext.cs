using DataAccess.Models;
using DataAccess.Models.Tables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Implementation.Base
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public ApplicationDbContext()
        {

        }
        public virtual DbSet<Actors> Actors { get; set; }
        public virtual DbSet<Genres> Genres { get; set; }
        public virtual DbSet<Movies> Movies { get; set; }
        public virtual DbSet<MoviesActors> MoviesActors { get; set; }
        public virtual DbSet<Awards> Awards { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Actors>();
            modelBuilder.Entity<Genres>();
            modelBuilder.Entity<Movies>(
                entity =>
                {
                    entity.HasOne(d => d.Genre)
                    .WithMany(p => p.Movies)
                    .HasForeignKey(d => d.GenreId);

                    entity.HasOne(d => d.Award)
                    .WithMany(p => p.Movies)
                    .HasForeignKey(d => d.AwardId);

                    //Other key configurations
                });
            modelBuilder.Entity<Awards>();
            modelBuilder.Entity<MoviesActors>();
        }
    }
}
