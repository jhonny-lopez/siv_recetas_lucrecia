using Domain.Regions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models.Cities;

namespace Web.Controllers
{
    public class CitiesController : Controller
    {
        public IActionResult Index()
        {
            IndexViewModel model = new IndexViewModel();

            var context = GetDatabaseService();

            model.Cities = context.Cities
                .Select(city => new CityModel()
                {
                    Id = city.Id,
                    Name = city.Name,
                    StateName = city.State.Name
                }).ToList();

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            CreateCityViewModel model = new CreateCityViewModel();

            var context = GetDatabaseService();

            var states = context.States
                .OrderBy(it => it.Name)
                .ToList();

            model.StatesList = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(states, "Id", "Name");

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(CreateCityViewModel model)
        {
            var context = GetDatabaseService();

            City city = new City();
            city.Name = model.Name;
            city.StateId = model.StateId;

            context.Cities.Add(city);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        private DatabaseService GetDatabaseService()
        {
            string connectionString = "Server=localhost;Database=RecetasLucrecia;User id=sa;Password=m4l4l3ch3";
            var options = SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
            DatabaseService context = new DatabaseService(options);

            return context;
        }
    }
}
