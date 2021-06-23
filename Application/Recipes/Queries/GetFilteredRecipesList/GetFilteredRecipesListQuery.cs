using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Recipes.Queries.GetFilteredRecipesList
{
    public class GetFilteredRecipesListQuery : IGetFilteredRecipesListQuery
    {
        private readonly IDatabaseService _databaseService;

        public GetFilteredRecipesListQuery(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public GetFilteredRecipesListModel Execute(RecipesFiltersModel filters)
        {
            var recipes = _databaseService.Recipes
                .Where(it => it.IsActive)
                .Where(r => filters.RecipeCategoryId == null || r.RecipeCategoryId == filters.RecipeCategoryId)
                .Where(r => string.IsNullOrEmpty(filters.SearchTerm)
                    || r.Name.Contains(filters.SearchTerm)
                    || r.Description.Contains(filters.SearchTerm))
                .Select(r => new RecipeModel()
                {
                    Description = r.Description,
                    Id = r.Id,
                    ImageUrl = r.ImageUrl,
                    Name = r.Name,
                    RecipeCategoryName = r.RecipeCategory.Name
                }).ToList();

            int totalRecords = _databaseService.Recipes
                .Where(r => r.IsActive)
                .Count();

            return new GetFilteredRecipesListModel()
            {
                FilteredRecords = recipes.Count,
                Recipes = recipes,
                TotalRecords = totalRecords
            };
        }
    }
}
