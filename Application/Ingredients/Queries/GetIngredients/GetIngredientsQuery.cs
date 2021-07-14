using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Ingredients.Queries.GetIngredients
{
    public class GetIngredientsQuery : IGetIngredientsQuery
    {
        private readonly IDatabaseService _databaseService;

        public GetIngredientsQuery(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public IngredientsListModel Execute()
        {
            var ingredients = _databaseService.Ingredients
                .OrderBy(i => i.Name)
                .ToList();

            var model = new IngredientsListModel();

            model.Ingredients = ingredients;

            return model;
        }
    }
}
