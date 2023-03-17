using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ReportSystem.Models.Entities
{
    [Index(nameof(Phone), IsUnique = true)]
    internal class TenantEntity
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;


        public int AddressId { get; internal set; }
        public virtual AddressEntity Address { get; set; } = null!;

        public ICollection<TenantReportsEntity> TenantReports = new HashSet<TenantReportsEntity>();

    }


}

