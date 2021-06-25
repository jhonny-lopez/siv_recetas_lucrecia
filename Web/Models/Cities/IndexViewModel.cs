using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models.Cities
{
    public class IndexViewModel
    {
        public IndexViewModel()
        {
            PageIndex = 0;
            PageSize = 20;
        }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
        public List<CityModel> Cities { get; set; }
    }

    public class CityModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string StateName { get; set; }
    }
}
