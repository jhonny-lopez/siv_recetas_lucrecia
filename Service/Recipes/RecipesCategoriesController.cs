using Application.Recipes.Commands.CreateRecipeCategoryCommand;
using Application.Recipes.Queries.GetRecipeCategoriesList;
using Application.Recipes.Queries.GetRecipeCategoryByIdQuery;
using Domain.Recipes;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Recipes
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesCategoriesController : ControllerBase
    {
        private IMediator _mediator;

        public RecipesCategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("list")]
        public async Task<ICollection<RecipeCategory>> GetRecipesCategoriesList()
        {
            var recipesCategories = await _mediator.Send(new GetRecipeCategoriesListQuery());

            return recipesCategories;
        }

        [HttpGet("get/{id}")]
        public async Task<RecipeCategory> GetRecipeCategory(int id)
        {
            var recipeCategory = await _mediator.Send(new GetRecipeCategoryByIdQuery()
            {
                Id = id
            });

            return recipeCategory;
        }

        [HttpPost("add")]
        public async Task<IActionResult> CreateRecipeCategory([FromForm] CreateRecipeCategoryModel model)
        {
            await _mediator.Send(new CreateRecipeCategoryCommand()
            {
                Model = model
            });

            return Ok();
        }
    }
}
