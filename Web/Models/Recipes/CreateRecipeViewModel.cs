using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models.Recipes
{
    public class CreateRecipeViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool IsActive { get; set; }
        public int RecipeCategoryId { get; set; }

        public SelectList RecipesCategoriesList { get; set; }
    }
}
