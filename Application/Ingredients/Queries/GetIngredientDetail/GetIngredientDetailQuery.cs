using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Ingredients.Queries.GetIngredientDetail
{
    public class GetIngredientDetailQuery : IGetIngredientDetailQuery
    {
        private readonly IDatabaseService _databaseService;

        public GetIngredientDetailQuery(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public IngredientModel Execute(int id)
        {
            var model = _databaseService.Ingredients
                .Where(i => i.Id == id)
                .Select(i => new IngredientModel()
                {
                    Id = i.Id,
                    ImageUrl = i.ImageUrl,
                    Name = i.Name
                })
                .SingleOrDefault();

            return model;
        }
    }
}
