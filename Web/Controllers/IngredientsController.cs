using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Controllers
{
    public class IngredientsController : Controller
    {

        private readonly IDatabaseService _context;
        private readonly INotifications _notifications;
        private readonly IStockService _stockService;

        public IngredientsController(IDatabaseService context, INotifications notifications, IStockService stockService)
        {
            _context = context;
            _notifications = notifications;
            _stockService = stockService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
