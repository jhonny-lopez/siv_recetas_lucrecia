using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Recipes.Queries.GetRecipeDetailsQuery
{
    public class GetRecipeDetailsModel
    {

        public GetRecipeDetailsModel()
        {
            this.Ingredients = new List<RecipeIngredientModel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string RecipeCategoryName { get; set; }

        public List<RecipeIngredientModel> Ingredients { get; set; }
    }

    public class RecipeIngredientModel
    {
        public int Id { get; set; }
        public string IngredientName { get; set; }
        public string Quantity { get; set; }
    }
}
