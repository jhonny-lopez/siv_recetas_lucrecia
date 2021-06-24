using Domain.Regions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models.States;

namespace Web.Controllers
{
    public class StatesController : Controller
    {
        public IActionResult Index()
        {
            IndexViewModel model = new IndexViewModel();

            model.States = GetStates();

            return View(model);
        }

        public IActionResult Details(int id)
        {
            var state = GetStates()
                .Where(s => s.Id == id)
                .First();

            StateDetailsViewModel model = new StateDetailsViewModel();
            model.Id = state.Id;
            model.Name = state.Name;
            model.Cities = GetCitiesByState(state.Id);

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            CreateStateViewModel model = new CreateStateViewModel();

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(CreateStateViewModel model)
        {
            State state = new State();

            state.Name = model.Name;

            var databaseContext = GetDatabaseService();

            databaseContext.States.Add(state);

            databaseContext.SaveChanges();

            return RedirectToAction("Index", "States");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var context = GetDatabaseService();
            var state = context.States.Find(id);

            if (state is null)
            {
                return NotFound();
            }

            EditStateViewModel model = new EditStateViewModel();
            model.Id = state.Id;
            model.Name = state.Name;

            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var context = GetDatabaseService();

            var state = context.States.Find(id);

            var cities = context.Cities.Where(it => it.StateId == state.Id)
                .ToList();

            var contacts = context.Contacts.Where(it => it.City.StateId == state.Id).ToList();

            context.Contacts.RemoveRange(contacts);

            context.Cities.RemoveRange(cities);

            context.States.Remove(state);

            context.SaveChanges();

            return RedirectToAction();
        }

        [HttpPost]
        public IActionResult DeleteWithScript(int id)
        {
            var context = GetDatabaseService();

            var state = context.States.Find(id);

            var cities = context.Cities.Where(it => it.StateId == state.Id)
                .ToList();

            var contacts = context.Contacts.Where(it => it.City.StateId == state.Id).ToList();

            context.Contacts.RemoveRange(contacts);

            context.Cities.RemoveRange(cities);

            context.States.Remove(state);

            context.SaveChanges();

            return RedirectToAction();
        }

        [HttpPost]
        public IActionResult Edit(EditStateViewModel model)
        {
            var context = GetDatabaseService();

            var state = context.States.Find(model.Id);

            state.Name = model.Name;

            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult TestParameters(int id, string name, DateTime date)
        {
            ViewBag.Id = id;
            ViewBag.Name = name;
            ViewBag.Date = date;
            return View();
        }

        private DatabaseService GetDatabaseService()
        {
            string connectionString = "Server=localhost;Database=RecetasLucrecia;User id=sa;Password=m4l4l3ch3";
            var options = SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
            DatabaseService context = new DatabaseService(options);

            return context;
        }

        private List<City> GetCitiesByState(int stateId)
        {
            string connectionString = "Server=localhost;Database=RecetasLucrecia;User id=sa;Password=m4l4l3ch3";
            var options = SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
            DatabaseService context = new DatabaseService(options);

            var cities = context.Cities
                .Where(c => c.StateId == stateId)
                .OrderBy(it => it.Name)
                .ToList();

            return cities;
        }

        private List<State> GetStates()
        {
            string connectionString = "Server=localhost;Database=RecetasLucrecia;User id=sa;Password=m4l4l3ch3";
            var options = SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
            DatabaseService context = new DatabaseService(options);

            var states = context.States
                .OrderBy(it => it.Name)
                .ToList();

            return states;
        }
    }
}
