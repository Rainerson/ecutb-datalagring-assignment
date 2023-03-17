using ReportSystem.Models;
using Sharprompt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportSystem.Services
{
    internal class MenuService
    {
        public void Menu()
        {
            Console.Clear();

            Console.WriteLine("Välkommen till Felrapportering");
            Console.WriteLine("1. Skapa ett ärende");
            Console.WriteLine("2. Visa alla ärenden");
            Console.WriteLine("3. Visa ett specifikt");
            Console.WriteLine("4. Byt status på ett ärende");
            Console.WriteLine("Välj ett av alternativen ovan");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1": CreateReport(); break;
                case "2": ShowAllReports(); break;
                /*case "3": ShowOneReport(); break;
                case "4": UpdateReportStatus(); break;*/
            }
        }

        public async void CreateReport()
        {
            Console.Clear();
            Console.WriteLine("Skapa en ny kontakt");

            Tenant tenant = new Tenant();

            Console.Write("Ange Förnamn: ");
            tenant.FirstName = Console.ReadLine() ?? null!;
            Console.Write("Ange Efternamn: ");
            tenant.LastName = Console.ReadLine() ?? null!;
            Console.Write("Ange Telefonnummer: ");
            tenant.Phone = Console.ReadLine() ?? null!;
            
            Console.Write("Ange Gatunamn: ");
            tenant.Address.StreetName = Console.ReadLine() ?? null!;
            Console.Write("Ange Gatunummer: ");

            //OBS FELHANTERING VID BOKSTAV ISTÄLLET FÖR SIFFRA

            tenant.Address.StreetNumber = Int32.Parse(Console.ReadLine() ?? null!);
            Console.Write("Ange Postkod: ");
            tenant.Address.PostalCode = Console.ReadLine() ?? null!;
            Console.Write("Ange Stad: ");
            tenant.Address.City = Console.ReadLine() ?? null!;

            Console.Write("Ange fel:");
            tenant.TenantReports.Report.Description = Console.ReadLine() ?? null!;
            var status = Prompt.Select("Ange Status", new[] { "Ej påbörjad", "Pågående", "Avslutad" });
            tenant.TenantReports.Report.Status = status;

            tenant.TenantReports.Report.Timestamp = DateTime.Now;

            //create comment

            await DatabaseService.SaveTenantReportToDatabaseAsync(tenant);
        }

        public async void ShowAllReports()
        {
            var tenantreports = await DatabaseService.GetAllTenantReportsAsync();
            if (tenantreports.Any()) 
            {
                foreach(Tenant t in tenantreports)
                {
                    Console.WriteLine("\n Förnamn:" + t.FirstName + " \n Efternamn: " + t.LastName + " \n  Telefon: " + t.Phone + " \n Adress: " + t.Address.StreetName + t.Address.StreetNumber + t.Address.PostalCode + t.Address.City + "\n Felbeskrivning: " + t.TenantReports.Report.Description +"\n");
                }
            }

            else
            {
                Console.Clear();
                Console.WriteLine("Något gick fel");
            }

            Console.ReadKey();
        }
        
    }
}
