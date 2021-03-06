using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models.Cities
{
    public class CreateCityViewModel
    {
        [Required]
        [Display(ResourceType = typeof(Resources.Cities.CitiesResources), Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resources.Cities.CitiesResources), Name = "StateId")]
        public int StateId { get; set; }

        public SelectList StatesList { get; set; }
    }
}
