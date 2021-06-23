using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Regions
{
    public class State
    {
        public State()
        {
            this.Cities = new HashSet<City>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<City> Cities { get; set; }
    }
}
