using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace component.template.api.domain.Models.Repository;

[Table("Profile")]
public class ProfileDto
{
    [Key]
    public int ProfileId { get; set; }

    [Required, MaxLength(50)]
    public string ProfileName { get; set; }

    [MaxLength(200)]
    public string Description { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public ICollection<UserProfileDto> UserProfiles { get; set; }
    public ICollection<ProfilePermissionDto> ProfilePermissions { get; set; }
}
