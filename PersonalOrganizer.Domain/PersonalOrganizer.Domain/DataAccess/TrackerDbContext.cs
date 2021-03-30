using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PersonalOrganizer.Domain.Models;

namespace PersonalOrganizer.Domain.DataAccess
{
    public class TrackerDbContext : DbContext
    {
        public TrackerDbContext()
        {
        }

        public TrackerDbContext(DbContextOptions<TrackerDbContext> options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) 
                optionsBuilder.UseNpgsql("Host=localhost;Database=tracker;Username=dbuser;Password=");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Note>()
                .Property(p => p.NoteId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<ToDo>()
                .Property(t => t.Id)
                .ValueGeneratedOnAdd();
            
            modelBuilder.Entity<AppUser>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<ToDo>()
                .HasData(
                        new ToDo() {Id = 1, Description = "Feed the dog", IsCompleted = false, DateCreated = DateTime.Now},
                        new ToDo() {Id = 2, Description = "Feed the cat", IsCompleted = false, DateCreated = DateTime.Now},
                        new ToDo() {Id = 3, Description = "Walk the dog", IsCompleted = false, DateCreated = DateTime.Now},
                        new ToDo() {Id = 4, Description = "Change cat litter", IsCompleted = false, DateCreated = DateTime.Now}
                    );
        }

        public DbSet<Note> Notes { get; set; }
        public DbSet<ToDo> ToDos { get; set; }
        
        public DbSet<AppUser> AppUsers { get; set; }
    }
}