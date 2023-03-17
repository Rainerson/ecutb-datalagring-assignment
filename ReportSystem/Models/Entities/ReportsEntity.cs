using System.ComponentModel.DataAnnotations;

namespace ReportSystem.Models.Entities
{
    internal class ReportsEntity
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; }
        public string Status { get; set; } = string.Empty;

        public ICollection<TenantReportsEntity> TenantReports = new HashSet<TenantReportsEntity>();
    }



}

