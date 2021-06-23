using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Recipes
{
    public class RecipeIngredient
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public int IngredientId { get; set; }
        public string Quantity { get; set; }
        public Recipe Recipe { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}
