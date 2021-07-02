using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models.Recipes;

namespace Web.Controllers
{
    public class RecipesController : Controller
    {
        private readonly DatabaseService _context;

        public RecipesController()
        {
            string connectionString = "Server=localhost;Database=RecetasLucrecia;User id=sa;Password=m4l4l3ch3";
            var options = SqlServerDbContextOptionsExtensions
                .UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
            _context = new DatabaseService(options);
        }

        public IActionResult Index()
        {
            RecipesIndexViewModel model = new RecipesIndexViewModel();

            model.Recipes = _context.Recipes.ToList();

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            CreateRecipeViewModel model = new CreateRecipeViewModel();

            model.RecipesCategoriesList = new SelectList(_context.RecipesCategories.ToList(), "Id", "Name");

            return View(model);
        }
    }
}
