using Domain.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models.States
{
    public class StateDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<City> Cities { get; set; }
    }
}
