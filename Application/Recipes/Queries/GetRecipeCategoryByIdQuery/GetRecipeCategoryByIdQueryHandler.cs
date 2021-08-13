using Application.Interfaces;
using Domain.Recipes;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Recipes.Queries.GetRecipeCategoryByIdQuery
{
    public class GetRecipeCategoryByIdQueryHandler : IRequestHandler<GetRecipeCategoryByIdQuery, RecipeCategory>
    {
        private readonly IDatabaseService _databaseService;

        public GetRecipeCategoryByIdQueryHandler(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public async Task<RecipeCategory> Handle(GetRecipeCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            return await _databaseService.RecipesCategories
                .SingleOrDefaultAsync(rc => rc.Id == request.Id);
        }
    }
}
