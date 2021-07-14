using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Ingredients.Commands.UpdateIngredient
{
    public class UpdateIngredientCommand : IUpdateIngredientCommand
    {
        private readonly IDatabaseService _databaseService;

        public UpdateIngredientCommand(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        //YAGNI

        public void Execute(UpdateIngredientModel model)
        {
            var ingredient = _databaseService.Ingredients
                .Find(model.Id);

            ingredient.Name = model.Name;

            _databaseService.Save();
        }
    }
}
