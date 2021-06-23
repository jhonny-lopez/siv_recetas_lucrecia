using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Recipes.Queries.GetFilteredRecipesList
{
    public class RecipesFiltersModel
    {

        public RecipesFiltersModel()
        {
            PageIndex = 0;
            PageSize = 10;
        }

        public Nullable<int> RecipeCategoryId { get; set; }
        public string SearchTerm { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
