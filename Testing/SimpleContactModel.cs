using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    class SimpleContactModel
    {
        public Guid Id { get; set; }
        public string ContactName { get; set; }
        public string ContactEmailAddress { get; set; }
        public string ContactCityName { get; set; }
    }
}
