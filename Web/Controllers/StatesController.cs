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
