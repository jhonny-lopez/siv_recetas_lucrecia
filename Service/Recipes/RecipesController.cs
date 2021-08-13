using Application.Recipes.Queries.GetFilteredRecipesList;
using Application.Recipes.Queries.GetRecipeDetailsQuery;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Recipes
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly IGetFilteredRecipesListQuery _filteredListQuery;
        private readonly IGetRecipeDetailsQuery _detailsQuery;

        public RecipesController(IGetFilteredRecipesListQuery filteredListQuery, 
            IGetRecipeDetailsQuery detailsQuery)
        {
            _filteredListQuery = filteredListQuery;
            _detailsQuery = detailsQuery;
        }


        //Inyección de dependencias en tiempo de compilación
        //Inyectar una dependencia directamente proporcionando en 
        //el constructor la implementación concreta que se va a utilizar
        //public RecipesController()
        //{
        //    _detailsQuery = new GetRecipeDetailsQuery(_databaseService);
        //}

        [Route("get")]
        public GetFilteredRecipesListModel GetRecipes([FromQuery]RecipesFiltersModel filters)
        {
            var model = _filteredListQuery.Execute(filters);

            return model;
        }

        [Route("get/{recipeId}")]
        public async Task<GetRecipeDetailsModel> Get(int recipeId)
        {    
            var model = await _detailsQuery.ExecuteAsync(recipeId);
            
            return model;
        }

        public async Task Calculate(int a, int b)
        {

        }
    }
}
