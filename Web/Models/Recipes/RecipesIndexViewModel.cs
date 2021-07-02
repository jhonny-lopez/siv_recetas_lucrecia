using Domain.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models.Recipes
{
    public class RecipesIndexViewModel
    {
        public ICollection<Recipe> Recipes { get; set; }
    }
}
