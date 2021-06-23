using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Recipes.Queries.GetRecipesCategoriesList
{
    public class GetRecipesCategoriesListQuery : IGetRecipesCategoriesListQuery
    {
        private readonly IDatabaseService _databaseService;

        public GetRecipesCategoriesListQuery(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public List<RecipeCategoryModel> Execute()
        {
            var recipesCategories = _databaseService.RecipesCategories
                .OrderBy(rc => rc.Name)
                .Select(rc => new RecipeCategoryModel()
                {
                    Id = rc.Id,
                    ImageUrl = rc.ImageUrl,
                    Name = rc.Name
                });

            return recipesCategories.ToList();
        }
    }
}
