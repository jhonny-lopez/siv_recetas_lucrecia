using Domain.Recipes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Recipes.Queries.GetRecipeCategoriesList
{
    public class GetRecipeCategoriesListQuery : IRequest<ICollection<RecipeCategory>>
    {

    }
}
