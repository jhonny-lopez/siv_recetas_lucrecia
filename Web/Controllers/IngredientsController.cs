using Application.Ingredients.Commands.CreateIngredient;
using Application.Ingredients.Commands.UpdateIngredient;
using Application.Ingredients.Queries.GetIngredientDetail;
using Application.Ingredients.Queries.GetIngredients;
using Application.Interfaces;
using Common.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models.Ingredients;

namespace Web.Controllers
{
    public class IngredientsController : Controller
    {
        private readonly IGetIngredientsQuery _getQuery;
        private readonly IGetIngredientDetailQuery _getDetailQuery;
        private readonly ICreateIngredientCommand _createCommand;
        private readonly IUpdateIngredientCommand _updateCommand;
        private readonly GeneralOptions _generalOptions;

        public IngredientsController(IGetIngredientsQuery getQuery, 
            IGetIngredientDetailQuery getDetailQuery, 
            ICreateIngredientCommand createCommand, 
            IUpdateIngredientCommand updateCommand,
            IOptions<GeneralOptions> generalOptions)
        {
            _getQuery = getQuery;
            _getDetailQuery = getDetailQuery;
            _createCommand = createCommand;
            _updateCommand = updateCommand;
            _generalOptions = generalOptions.Value;
        }

        public IActionResult Index()
        {
            var model = _getQuery.Execute();

            string appKey = _generalOptions.SMSProvider.AppKey;
            Console.WriteLine(appKey);

            return View(model);
        }

        public IActionResult Details(int id)
        {
            var model = _getDetailQuery.Execute(id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateIngredientModel model)
        {
            _createCommand.Execute(model);

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var ingredient = _getDetailQuery.Execute(id);

            var model = new UpdateIngredientModel()
            {
                Id = ingredient.Id,
                Name = ingredient.Name
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(UpdateIngredientModel model)
        {
            _updateCommand.Execute(model);

            return RedirectToAction("Index");
        }
    }
}
