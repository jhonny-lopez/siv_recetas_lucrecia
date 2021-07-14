using Application.Interfaces;
using Domain.Recipes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Ingredients.Commands.CreateIngredient
{
    public class CreateIngredientCommand : ICreateIngredientCommand
    {
        private readonly IDatabaseService _databaseService;

        public CreateIngredientCommand(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public void Execute(CreateIngredientModel model)
        {
            var ingredient = new Ingredient()
            {
                Name = model.Name
            };

            _databaseService.Ingredients.Add(ingredient);

            _databaseService.Save();
        }
    }
}
