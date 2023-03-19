using ReportSystem.Models;
using Sharprompt;


namespace ReportSystem.Services
{
    internal class MenuService
    {


        public async Task CreateReport()
        {
            Console.Clear();
            Console.WriteLine("Skapa en ny kontakt");

            Tenant tenant = new Tenant();

            Console.Write("Ange Förnamn: ");
            tenant.FirstName = Console.ReadLine() ?? null!;
            Console.Write("Ange Efternamn: ");
            tenant.LastName = Console.ReadLine() ?? null!;
            Console.Write("Ange Email: ");
            tenant.Email = Console.ReadLine() ?? null!;
            Console.Write("Ange Telefonnummer: ");
            tenant.Phone = Console.ReadLine() ?? null!;

            Console.Write("Ange Gatunamn: ");
            tenant.Address.StreetName = Console.ReadLine() ?? null!;
            Console.Write("Ange Gatunummer: ");

            int x;
            if (int.TryParse(Console.ReadLine(), out x))
            {
                tenant.Address.StreetNumber = x;
            }
            else
            {
                Console.WriteLine("Gatunummer måste vara en siffra");
            }

            Console.Write("Ange Postkod: ");
            tenant.Address.PostalCode = Console.ReadLine() ?? null!;
            Console.Write("Ange Stad: ");
            tenant.Address.City = Console.ReadLine() ?? null!;

            Console.Write("Ange fel:");
            tenant.Report.Description = Console.ReadLine() ?? null!;
            var status = Prompt.Select("Ange Status", new[] { "Ej påbörjad", "Pågående", "Avslutad" });
            tenant.Report.Status = status;

            tenant.Report.Timestamp = DateTime.Now;


            await DatabaseService.SaveTenantReportToDatabaseAsync(tenant);
        }

        public async Task ShowAllReports()
        {
            var reports = await DatabaseService.GetAllReportsAsync();
            if (reports.Any())
            {
                foreach (Tenant t in reports)
                {
                    Console.WriteLine("\n Id: " + t.Id + " \n Förnamn:" + t.FirstName + " \n Efternamn: " + t.LastName + " \n Email: " + t.Email + " \n Telefon: " + t.Phone + " \n Adress: " + t.Address.StreetName + " " + t.Address.StreetNumber + " " + t.Address.PostalCode + " " + t.Address.City + "\n Felbeskrivning: " + t.Report.Description + "\n Status: " + t.Report.Status + " \n");
                }
            }

            else
            {
                Console.Clear();
                Console.WriteLine("Något gick fel");
            }

            Console.ReadKey();
        }

        public async Task ShowOneReport()
        {
            Console.Clear();
            Console.WriteLine("Skriv telefonnummret som är kopplat till ditt ärende:");
            var phone = Console.ReadLine() ?? null!;

            var report = await DatabaseService.GetOneReportAsync(phone);
            if (report != null)
            {
                Console.WriteLine("\n  Id: " + report.Id + " \n Förnamn:" + report.FirstName + " \n Efternamn: " + report.LastName + " \n Email: " + report.Email + " \n Telefon: " + report.Phone + " \n Adress: " + report.Address.StreetName + " " + report.Address.StreetNumber + " " + report.Address.PostalCode + " " + report.Address.City + "\n Felbeskrivning: " + report.Report.Description + "\n Status: " + report.Report.Status + "");
            }
            else
            {
                Console.WriteLine("Hittar inget ärende kopplat till detta telefonnummer");
            }

            Console.ReadKey();
        }

        public async Task UpdateReportStatus()
        {
            Console.Clear();
            Console.WriteLine("Skriv telefonnummer som är kopplat till ditt ärende:");
            var reportPhone = Console.ReadLine() ?? null!;


            if (reportPhone != null)
            {
                var tenantEntity = await DatabaseService.GetOneReportAsync(reportPhone);
                if (tenantEntity != null)
                {
                    Console.WriteLine($"Nuvarande status: {tenantEntity.Report.Status}");

                    tenantEntity.Report.Status = Prompt.Select("Ändra Status", new[] { "Ej påbörjad", "Pågående", "Avslutad" });

                    await DatabaseService.UpdateStatusAsync(tenantEntity);
                }
                else
                {
                    Console.WriteLine("Hittar inget ärende kopplat till detta telefonnummer");
                }

            }

            Console.WriteLine("Tryck på en tangent för att fortsätta...");
            Console.ReadKey();


        }
    }
}
