using Application.Recipes.Queries.GetRecipesCategoriesList;
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
        private readonly IGetRecipesCategoriesListQuery _listQuery;

        public RecipesCategoriesController(IGetRecipesCategoriesListQuery listQuery)
        {
            _listQuery = listQuery;
        }

        [Route("get")]
        public IEnumerable<RecipeCategoryModel> Get()
        {
            return _listQuery.Execute();
        }
    }
}
