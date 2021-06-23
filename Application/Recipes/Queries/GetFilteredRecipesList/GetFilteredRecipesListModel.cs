using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Recipes.Queries.GetFilteredRecipesList
{
    public class GetFilteredRecipesListModel
    {
        public GetFilteredRecipesListModel()
        {
            this.Recipes = new List<RecipeModel>();
        }
        public int TotalRecords { get; set; }
        public int FilteredRecords { get; set; }

        public List<RecipeModel> Recipes { get; set; }
    }

    public class RecipeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string RecipeCategoryName { get; set; }
    }
}
