using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Application.Recipes.Queries.GetRecipeDetailsQuery
{
    public class GetRecipeDetailsQuery : IGetRecipeDetailsQuery
    {
        private readonly IDatabaseService _databaseService;

        public GetRecipeDetailsQuery(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public GetRecipeDetailsModel Execute(int recipeId)
        {
            
            var ingredients = _databaseService.RecipesIngredients
                .Where(ri => ri.RecipeId == recipeId)
                .Select(ri => new RecipeIngredientModel()
                {
                    Id = ri.Id,
                    IngredientName = ri.Ingredient.Name,
                    Quantity = ri.Quantity
                })
                .ToList();

            var model = _databaseService.Recipes
                .Where(it => it.Id == recipeId)
                .Select(r => new GetRecipeDetailsModel()
                {
                    Description = r.Description,
                    Id = r.Id,
                    ImageUrl = r.ImageUrl,
                    Ingredients = ingredients,
                    Name = r.Name,
                    RecipeCategoryName = r.RecipeCategory.Name
                })
                .Single();

            return model;
        }
    }
}
