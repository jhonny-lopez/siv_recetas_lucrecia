using Application.Interfaces;
using Domain.Contacts;
using Domain.Events;
using Domain.Recipes;
using Domain.Regions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence
{
    public class DatabaseService : DbContext, IDatabaseService, IDisposable
    {
        public DatabaseService() : base()
        {

        }

        public DatabaseService(DbContextOptions<DatabaseService> options) : base(options)
        {

        }

        public DatabaseService(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventCategory> EventsCategories { get; set; }
        public DbSet<EventRegisteredContact> EventsRegisteredContacts { get; set; }
        public DbSet<EventType> EventsTypes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeCategory> RecipesCategories { get; set; }
        public DbSet<RecipeIngredient> RecipesIngredients { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<State> States { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("Contacts");

                entity.HasKey(it => it.Id);

                entity.HasOne(it => it.City)
                    .WithMany(it => it.Contacts)
                    .HasForeignKey(it => it.CityId);

            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.ToTable("Events");

                entity.HasKey(it => it.Id);

                entity.HasOne(it => it.City)
                    .WithMany(it => it.Events)
                    .HasForeignKey(it => it.CityId);

                entity.HasOne(it => it.EventType)
                    .WithMany(it => it.Events)
                    .HasForeignKey(it => it.EventTypeId);

                entity.HasOne(it => it.EventCategory)
                    .WithMany(it => it.Events)
                    .HasForeignKey(it => it.EventCategoryId);
            });

            modelBuilder.Entity<EventCategory>(entity =>
            {
                entity.ToTable("EventsCategories");
            });

            modelBuilder.Entity<EventType>(entity =>
            {
                entity.ToTable("EventsTypes");
            });

            modelBuilder.Entity<EventRegisteredContact>(entity =>
            {
                entity.ToTable("EventsRegisteredContacts");
            });

            modelBuilder.Entity<Ingredient>(entity =>
            {
                entity.ToTable("Ingredients");
            });

            modelBuilder.Entity<Recipe>(entity =>
            {
                entity.ToTable("Recipes");
            });

            modelBuilder.Entity<RecipeCategory>(entity =>
            {
                entity.ToTable("RecipesCategories");
            });

            modelBuilder.Entity<RecipeIngredient>(entity =>
            {
                entity.ToTable("RecipesIngredients");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.ToTable("States");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("Cities");

                entity.HasOne(it => it.State)
                    .WithMany(it => it.Cities)
                    .HasForeignKey("StateId");
            });
        }

        public void Save()
        {
            this.SaveChanges();
        }
    }
}
