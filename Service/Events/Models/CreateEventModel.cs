using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Events.Models
{
    public class CreateEventModel
    {
        public int EventTypeId { get; set; }
        public int EventCategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int Hours { get; set; }
        public int CityId { get; set; }
        public string LocationName { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
    }
}
