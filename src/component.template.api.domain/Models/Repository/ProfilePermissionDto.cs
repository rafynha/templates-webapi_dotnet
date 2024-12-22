using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace component.template.api.domain.Models.Repository;

[Table("ProfilePermissions")]
public class ProfilePermissionDto
{
    [Key]
    public int ProfilePermissionId { get; set; }

    [ForeignKey("Profile")]
    public int ProfileId { get; set; }

    [ForeignKey("Permission")]
    public int PermissionId { get; set; }

    public DateTime GrantedAt { get; set; } = DateTime.Now;

    public ProfileDto Profile { get; set; }
    public PermissionDto Permission { get; set; }
}
