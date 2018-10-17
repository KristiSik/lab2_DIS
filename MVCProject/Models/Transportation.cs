using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCProject.Models
{
    public class Transportation
    {
        public int ID { get; set; }
        public string CityFrom { get; set; }
        public string CityTo { get; set; }
        public ICollection<Transport> Transports { get; set; }
    }
}
