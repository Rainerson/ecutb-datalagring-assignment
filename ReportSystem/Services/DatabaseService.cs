using Microsoft.EntityFrameworkCore;
using ReportSystem.Contexts;
using ReportSystem.Models;
using ReportSystem.Models.Entities;
using Sharprompt;
using System;

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
                Email = tenant.Email,
                Phone = tenant.Phone
            };


            tenantEntity.Address = new AddressEntity
            {
                StreetName = tenant.Address.StreetName,
                StreetNumber = tenant.Address.StreetNumber,
                PostalCode = tenant.Address.PostalCode,
                City = tenant.Address.City
            };

            tenantEntity.Report = new ReportsEntity
            {
                Description = tenant.Report.Description,
                Status = tenant.Report.Status,
                Timestamp = tenant.Report.Timestamp,
            };
            _context.Add(tenantEntity);
            await _context.SaveChangesAsync();
        }




        public static async Task<IEnumerable<Tenant>> GetAllReportsAsync()
        {
            var reports = new List<Tenant>();
            foreach (var report in await _context.Tenants
                .Include(x => x.Address)
                .Include(x => x.Report)
                .ToListAsync())
            {
                reports.Add(new Tenant
                {
                    Id = report.Id,
                    FirstName = report.FirstName,
                    LastName = report.LastName,
                    Email = report.Email,
                    Phone = report.Phone,
                    Address =
                    {
                        StreetName = report.Address.StreetName,
                        StreetNumber = report.Address.StreetNumber,
                        PostalCode = report.Address.PostalCode,
                        City = report.Address.City
                    },
                    Report =
                        {
                            Description = report.Report.Description,
                            Status = report.Report.Status
                        }

                });
            };

            return reports;
        }

        public static async Task<Tenant> GetOneReportAsync(string phone)
        {
            var report = await _context.Tenants
                .Include(x => x.Address)
                .Include(x => x.Report)
                .FirstOrDefaultAsync(x => x.Phone == phone);

            if (report != null)
            {
                return new Tenant
                {
                    Id = report.Id,
                    FirstName = report.FirstName,
                    LastName = report.LastName,
                    Email = report.Email,
                    Phone = report.Phone,
                    Address =
                        {
                            StreetName = report.Address.StreetName,
                            StreetNumber = report.Address.StreetNumber,
                            PostalCode = report.Address.PostalCode,
                            City = report.Address.City
                        },
                    Report =
                        {
                            Description = report.Report.Description,
                            Status = report.Report.Status
                        }
                };
            }
            else
            {
                return null!;
            }

        }

        public static async Task UpdateStatusAsync(Tenant tenant)
        {
            var _tenant = await _context.Tenants.Include(x => x.Report).FirstOrDefaultAsync(x => x.Id == tenant.Id);
            if (_tenant != null)
            {
                var _reportEntity = await _context.Reports.FirstOrDefaultAsync(x => x.Id == _tenant.Report.Id);
                if (_reportEntity != null)
                {
                    _reportEntity.Status = tenant.Report.Status;
                    await _context.SaveChangesAsync();
                }
                else
                {
                    Console.WriteLine("Något gick fel");
                }

            }
            else
            {
                Console.WriteLine("Något gick fel");
            }
        }


    }
}
