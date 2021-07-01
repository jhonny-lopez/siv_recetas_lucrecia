using Domain.Regions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public IActionResult Index([FromQuery]IndexViewModel model)
        {
            var context = GetDatabaseService();

            var query = context.Cities
                .OrderBy(it => it.State.Name)
                    .ThenBy(it => it.Name)
                .Skip(model.PageIndex)
                .Take(model.PageSize)
                .Select(city => new CityModel()
                {
                    Id = city.Id,
                    Name = city.Name,
                    StateName = city.State.Name
                });

            var querySQL = query.ToQueryString();
            model.Cities = query.ToList();
            model.TotalRecords = context.Cities.Count();

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            CreateCityViewModel model = new CreateCityViewModel();

            var context = GetDatabaseService();

            var states = context.States
                    .Include(it => it.Cities)
                .OrderBy(it => it.Name)
                .ToList();

            model.StatesList = new SelectList(states, "Id", "Name");

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(CreateCityViewModel model)
        {
            var context = GetDatabaseService();

            if (ModelState.IsValid)
            {
                City city = new City();
                city.Name = model.Name;
                city.StateId = model.StateId;

                context.Cities.Add(city);
                context.SaveChanges();

                return RedirectToAction("Index"); 
            }

            var states = context.States
                .OrderBy(it => it.Name)
                .ToList();

            model.StatesList = new SelectList(states, "Id", "Name");

            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var context = GetDatabaseService();

            var city = context.Cities.Find(id);

            var states = context.States
                .OrderBy(state => state.Name)
                .ToList();

            EditCityViewModel model = new EditCityViewModel();
            model.Id = city.Id;
            model.Name = city.Name;
            model.StateId = city.StateId;

            model.StatesList = new SelectList(states, "Id", "Name", city.StateId);

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(EditCityViewModel model)
        {
            var context = GetDatabaseService();

            var city = context.Cities.Find(model.Id);

            city.Name = model.Name;
            city.StateId = model.StateId;

            context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            DeleteCityViewModel model = new DeleteCityViewModel();

            var context = GetDatabaseService();

            var city = context.Cities.Find(id);

            model.Id = city.Id;
            model.Name = city.Name;

            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(DeleteCityViewModel model)
        {
            var context = GetDatabaseService();

            var city = context.Cities.Find(model.Id);

            context.Cities.Remove(city);

            context.SaveChanges();

            return RedirectToAction("Index");
        }


        private DatabaseService GetDatabaseService()
        {
            string connectionString = "Server=localhost;Database=RecetasLucrecia;User id=sa;Password=m4l4l3ch3";
            var options = SqlServerDbContextOptionsExtensions
                .UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
            DatabaseService context = new DatabaseService(options);

            return context;
        }
    }
}
