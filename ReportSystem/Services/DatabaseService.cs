using Microsoft.EntityFrameworkCore;
using ReportSystem.Contexts;
using ReportSystem.Models;
using ReportSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ReportSystem.Services
{
    internal class DatabaseService
    {
        private static DataContext _context = new DataContext();
        public static async Task SaveTenantReportToDatabaseAsync(Tenant tenant)
        {
            var tenantEntity = new TenantEntity
            {
                FirstName = tenant.FirstName,
                LastName = tenant.LastName,
                Phone = tenant.Phone,
            };
            /*
                        var addressEntity = await _context.Address.FirstOrDefaultAsync(
                            x =>
                            x.StreetName == tenant.Address.StreetName &&
                            x.StreetNumber == tenant.Address.StreetNumber &&
                            x.PostalCode == tenant.Address.PostalCode &&
                            x.City == tenant.Address.City
                        );


                        if (addressEntity != null)
                        {
                           tenantEntity.AddressId = addressEntity.Id;
                        }
                        else
                        {
                        }
            */ 

            tenantEntity.Address = new AddressEntity
            {
                StreetName = tenant.Address.StreetName,
                StreetNumber = tenant.Address.StreetNumber,
                PostalCode = tenant.Address.PostalCode,
                City = tenant.Address.City
            };


            var reportEntity = new ReportsEntity
            {
                Description = tenant.TenantReports.Report.Description,
                Status = tenant.TenantReports.Report.Status,
            };


            var tenantReport = new TenantReportsEntity
            {
                Report = reportEntity,
                Tenant = tenantEntity
            };

            tenantEntity.TenantReports.Add(tenantReport);
            reportEntity.TenantReports.Add(tenantReport);


            





            /*            tenantEntity.TenantReports = new TenantReportsEntity
                        {
                            TenantId = tenant.Id
                        };
            */




            _context.Add(tenantEntity);
            await _context.SaveChangesAsync();
        }




        public static async Task<IEnumerable<Tenant>> GetAllTenantReportsAsync()
        {
            var tenants = new List<Tenant>();
            foreach (var tenant in await _context.Tenants.Include(x => x.Address).ToListAsync())
                tenants.Add(new Tenant
                {
                    FirstName = tenant.FirstName,
                    LastName = tenant.LastName,
                    Phone = tenant.Phone,
                    Address =
                    {
                        StreetName = tenant.Address.StreetName,
                        StreetNumber = tenant.Address.StreetNumber,
                        PostalCode = tenant.Address.PostalCode,
                        City = tenant.Address.City
                    }


                });

            return tenants;
        }
    }
}
