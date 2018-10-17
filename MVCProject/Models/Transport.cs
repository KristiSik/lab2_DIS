using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCProject.Models
{
    public class Transport
    {
        public int ID { get; set; }
        public string Number { get; set; }
        public string DriverName { get; set; }
        public Transportation Transportation { get; set; }
        public int TransportationId { get; set; }
        public TransportCompany TransportCompany { get; set; }
        public int? TransportCompanyId { get; set; }
    }
}
