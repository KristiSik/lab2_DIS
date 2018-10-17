using MVCProject.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MVCProject.EF
{
    public class TransportsDbInitializer : CreateDatabaseIfNotExists<TransportsDbContext>
    {
        protected override void Seed(TransportsDbContext context)
        {
            List<Transport> transports = new List<Transport>()
            {
                new Transport() { DriverName = "Магочі Олександр", Number = "АК9679АО" },
                new Transport() { DriverName = "Пшук Микола", Number = "АІ9201АО" },
                new Transport() { DriverName = "Співак Андрій", Number = "АА1369АВ" },
                new Transport() { DriverName = "Кіш Роберт", Number = "АА8237НН" }
            };

            List<TransportCompany> transportCompanies = new List<TransportCompany>() {
                new TransportCompany() { Name = "AvtoZerro", Transports = transports.Take(2).ToList() },
                new TransportCompany() { Name = "Vito", Transports = transports.Skip(2).Take(2).ToList() }
            };

            List<Transportation> transportations = new List<Transportation>()
            {
                new Transportation() { CityFrom = "Kyiv", CityTo = "Uzhgorod", Transports = transports.Skip(1).Take(2).ToList() },
                new Transportation() { CityFrom = "Lviv", CityTo = "Batyovo", Transports = transports }
            };
            context.Transports.AddRange(transports);
            context.TransportCompanies.AddRange(transportCompanies);
            context.Transportations.AddRange(transportations);
            base.Seed(context);
        }
    }
}
