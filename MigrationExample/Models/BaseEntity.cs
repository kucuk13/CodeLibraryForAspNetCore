using System.ComponentModel.DataAnnotations;

namespace MigrationExample.Models
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.UtcNow;
        public int? CreatedMemberId { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public int? UpdatedMemberId { get; set; }
        public DateTime? DeletedDateTime { get; set; }
        public int? DeletedMemberId { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
