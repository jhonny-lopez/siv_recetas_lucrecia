using Domain.Regions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Regions.States
{
    public class StateModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<City> Cities { get; set; }
    }
}
