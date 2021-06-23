using Domain.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models.States
{
    public class IndexViewModel
    {
        public IndexViewModel()
        {
            States = new List<State>();
        }
        public List<State> States { get; set; }
    }
}
