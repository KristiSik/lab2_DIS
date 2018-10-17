using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCProject.Models
{
    public class TransportCompany
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<Transport> Transports { get; set; }
    }
}
