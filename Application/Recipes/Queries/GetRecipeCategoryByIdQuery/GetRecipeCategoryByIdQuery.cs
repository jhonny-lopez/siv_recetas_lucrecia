using Domain.Recipes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Recipes.Queries.GetRecipeCategoryByIdQuery
{
    public class GetRecipeCategoryByIdQuery : IRequest<RecipeCategory>
    {
        public int Id { get; set; }
    }
}
