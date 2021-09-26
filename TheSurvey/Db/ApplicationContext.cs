using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheSurvey.Entities;

namespace TheSurvey.Db
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Variant> Variants { get; set; }
        public DbSet<Answer> Answers { get; set; }

        public ApplicationContext()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
            //Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Server=DESKTOP-GPON2I3;Database=TheSurvey;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Survey>()
                .HasMany(s => s.Questions)
                .WithOne(q => q.Survey);
            modelBuilder
                .Entity<Question>()
                .HasMany(q => q.Variants)
                .WithOne(v => v.Question);
            modelBuilder
                .Entity<Variant>()
                .HasMany(v => v.Answers)
                .WithOne(a => a.Variant);
        }
    }
}
