using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models.Cities
{
    public class EditCityViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StateId { get; set; }

        public SelectList StatesList { get; set; }
    }
}
