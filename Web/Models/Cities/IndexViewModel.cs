using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models.Cities
{
    public class IndexViewModel
    {
        public List<CityModel> Cities { get; set; }
    }

    public class CityModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string StateName { get; set; }
    }
}
