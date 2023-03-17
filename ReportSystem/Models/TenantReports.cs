using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportSystem.Models
{
    internal class TenantReports
    {
        public int TenantId { get; set; }
        public Report Report { get; set; } = new Report();
    }
}
