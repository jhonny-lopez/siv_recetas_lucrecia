using Domain.Contacts;
using Domain.Employees;
using Domain.Events;
using Domain.Recipes;
using Domain.Regions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IDatabaseService
    {
        DbSet<Contact> Contacts { get; set; }
        DbSet<Event> Events { get; set; }
        DbSet<EventCategory> EventsCategories { get; set; }
        DbSet<EventRegisteredContact> EventsRegisteredContacts { get; set; }
        DbSet<EventType> EventsTypes { get; set; }
        DbSet<Ingredient> Ingredients { get; set; }
        DbSet<Recipe> Recipes { get; set; }
        DbSet<RecipeCategory> RecipesCategories { get; set; }
        DbSet<RecipeIngredient> RecipesIngredients { get; set; }
        DbSet<City> Cities { get; set; }
        DbSet<State> States { get; set; }
        DbSet<Employee> Employees { get; set; }
        void Save();
    }
}
