using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace component.template.api.domain.Models.Repository;

[Table("Permissions")]
public class PermissionDto
{
        [Key]
        public int PermissionId { get; set; }

        [Required, MaxLength(50)]
        public string PermissionName { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public ICollection<ProfilePermissionDto> ProfilePermissions { get; set; }
}
