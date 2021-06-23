using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Recipes
{
    public class RecipeCategory
    {
        public RecipeCategory()
        {
            this.Recipes = new HashSet<Recipe>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }

        public ICollection<Recipe> Recipes { get; set; }
    }
}
