using DataAccess.Models;
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
        public ApplicationDbContext(DbContextOptions options): base(options)
        {

        }
        public ApplicationDbContext()
        {

        }
        public virtual DbSet<Actors> Actors { get; set; }
        public virtual DbSet<Genres> Genres { get; set; }
        public virtual DbSet<Movies> Movies { get; set; }
        public virtual DbSet<MoviesActors> MoviesActors { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Actors>();
            modelBuilder.Entity<Genres>();
            modelBuilder.Entity<Movies>();
            modelBuilder.Entity<MoviesActors>();
        }
    }
}
