using System.Collections.Generic;

namespace Application.Recipes.Queries.GetRecipesCategoriesList
{
    public interface IGetRecipesCategoriesListQuery
    {
        List<RecipeCategoryModel> Execute();
    }
}