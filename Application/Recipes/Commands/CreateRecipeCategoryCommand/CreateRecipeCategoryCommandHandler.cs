using Application.Interfaces;
using Domain.Recipes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Recipes.Commands.CreateRecipeCategoryCommand
{
    public class CreateRecipeCategoryCommandHandler : AsyncRequestHandler<CreateRecipeCategoryCommand>
    {
        private readonly IDatabaseService _databaseService;

        public CreateRecipeCategoryCommandHandler(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        protected async override Task Handle(CreateRecipeCategoryCommand request, CancellationToken cancellationToken)
        {
            var recipeCatgoryToAdd = new RecipeCategory();

            recipeCatgoryToAdd.Name = request.Model.Name;
            recipeCatgoryToAdd.ImageUrl = request.Model.ImageUrl;

            await  _databaseService.RecipesCategories.AddAsync(recipeCatgoryToAdd);

            _databaseService.Save();
        }
    }
}
