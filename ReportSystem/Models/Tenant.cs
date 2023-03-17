using ReportSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportSystem.Models
{
    internal class Tenant
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Phone { get; set; } = null!;

        public Address Address { get; set; } = new Address();
        public TenantReports TenantReports { get; set; } = new TenantReports();

    }
}
