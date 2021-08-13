using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Recipes.Queries.GetRecipeDetailsQuery
{
    public class GetRecipeDetailsQuery : IGetRecipeDetailsQuery
    {
        private readonly IDatabaseService _databaseService;

        public GetRecipeDetailsQuery(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public async Task<GetRecipeDetailsModel> ExecuteAsync(int recipeId)
        {
            
            var ingredients = await _databaseService.RecipesIngredients
                .Where(ri => ri.RecipeId == recipeId)
                .Select(ri => new RecipeIngredientModel()
                {
                    Id = ri.Id,
                    IngredientName = ri.Ingredient.Name,
                    Quantity = ri.Quantity
                })
                .ToListAsync();

            var model = await _databaseService.Recipes
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
                .SingleAsync();

            return model;
        }
    }
}
