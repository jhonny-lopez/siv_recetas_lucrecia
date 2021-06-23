using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Recipes
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool IsActive { get; set; }
        public int RecipeCategoryId { get; set; }

        public RecipeCategory RecipeCategory { get; set; }
    }
}
