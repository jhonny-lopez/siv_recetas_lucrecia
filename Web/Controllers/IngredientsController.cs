using Application.Ingredients.Commands.CreateIngredient;
using Application.Ingredients.Commands.UpdateIngredient;
using Application.Ingredients.Queries.GetIngredientDetail;
using Application.Ingredients.Queries.GetIngredients;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public IngredientsController(IGetIngredientsQuery getQuery, 
            IGetIngredientDetailQuery getDetailQuery, 
            ICreateIngredientCommand createCommand, 
            IUpdateIngredientCommand updateCommand)
        {
            _getQuery = getQuery;
            _getDetailQuery = getDetailQuery;
            _createCommand = createCommand;
            _updateCommand = updateCommand;
        }

        public IActionResult Index()
        {
            var model = _getQuery.Execute();

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
