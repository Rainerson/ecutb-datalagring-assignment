using System.ComponentModel.DataAnnotations;

namespace ReportSystem.Models.Entities
{
    internal class TenantReportsEntity
    {
        [Key]
        public int TenantId { get; set; }
        public TenantEntity Tenant { get; set; } = null!;

        [Key]
        public int ReportId { get; set; }
        public ReportsEntity Report { get; set; } = null!;

    }

}

