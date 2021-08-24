using Application.Recipes.Queries.GetFilteredRecipesList;
using Application.Recipes.Queries.GetRecipeDetailsQuery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Service.Security;
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
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _config;

        public RecipesController(IGetFilteredRecipesListQuery filteredListQuery,
            IGetRecipeDetailsQuery detailsQuery, ITokenService tokenService, IConfiguration config)
        {
            _filteredListQuery = filteredListQuery;
            _detailsQuery = detailsQuery;
            _tokenService = tokenService;
            _config = config;
        }


        //Inyección de dependencias en tiempo de compilación
        //Inyectar una dependencia directamente proporcionando en 
        //el constructor la implementación concreta que se va a utilizar
        //public RecipesController()
        //{
        //    _detailsQuery = new GetRecipeDetailsQuery(_databaseService);
        //}

        [Route("get")]
        [Authorize]
        public IActionResult GetRecipes([FromQuery]RecipesFiltersModel filters)
        {
            string token = HttpContext.Request.Headers["Authorization"];

            if (token == null)
            {
                return Unauthorized();
            }

            var securityKey = _config["Jwt:Key"];
            var issuer = _config["Jwt:Issuer"];

            if (_tokenService.ValidateToken(securityKey, issuer, token)) {
                var model = _filteredListQuery.Execute(filters);

                return Ok(model);
            }
            else
            {
                return Unauthorized();
            }
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
