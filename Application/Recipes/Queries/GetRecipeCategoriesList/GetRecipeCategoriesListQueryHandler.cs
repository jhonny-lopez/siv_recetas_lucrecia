using Application.Interfaces;
using Domain.Recipes;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Recipes.Queries.GetRecipeCategoriesList
{
    public class GetRecipeCategoriesListQueryHandler : IRequestHandler<GetRecipeCategoriesListQuery, ICollection<RecipeCategory>>
    {
        private IDatabaseService _databaseService;

        public GetRecipeCategoriesListQueryHandler(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public async Task<ICollection<RecipeCategory>> Handle(GetRecipeCategoriesListQuery request, CancellationToken cancellationToken)
        {
            return await _databaseService.RecipesCategories
                .OrderBy(it => it.Name)
                .ToListAsync();
        }
    }
}
