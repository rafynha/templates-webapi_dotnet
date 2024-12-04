using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace component.template.api.domain.Models.Repository;

[Table("UserProfile")]
public class UserProfileDto
{
        [Key]
        public int UserProfileId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("Profile")]
        public int ProfileId { get; set; }

        public DateTime AssignedAt { get; set; } = DateTime.Now;

        public UserDto User { get; set; }
        public ProfileDto Profile { get; set; }
}
