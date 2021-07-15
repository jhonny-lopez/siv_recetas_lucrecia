using Application.Interfaces;
using Common.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Ingredients.Queries.GetIngredients
{
    public class GetIngredientsQuery : IGetIngredientsQuery
    {
        private readonly IDatabaseService _databaseService;
        private readonly GeneralOptions _generalOptions;

        public GetIngredientsQuery(IDatabaseService databaseService, IOptions<GeneralOptions> generalOptions)
        {
            _databaseService = databaseService;
            _generalOptions = generalOptions.Value;
        }

        public IngredientsListModel Execute()
        {
            var ingredients = _databaseService.Ingredients
                .OrderBy(i => i.Name)
                .ToList();


            string appSecret = _generalOptions.SMSProvider.AppSecret;
            Console.WriteLine(appSecret);

            var model = new IngredientsListModel();

            model.Ingredients = ingredients;

            return model;
        }
    }
}
