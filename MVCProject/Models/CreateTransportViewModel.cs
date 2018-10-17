using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCProject.Models
{
    public class CreateTransportViewModel
    {
        public int ID { get; set; }
        public string Number { get; set; }
        public string DriverName { get; set; }
        public List<TransportationViewModel> Transportations { get; set; }
        public int TransportationId { get; set; }
        public List<TransportCompany> TransportCompanies { get; set; }
        public int? TransportCompanyId { get; set; }
        public CreateTransportViewModel()
        {
            Transportations = new List<TransportationViewModel>();
            TransportCompanies = new List<TransportCompany>();
        }
    }
}