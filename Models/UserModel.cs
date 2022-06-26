using System.ComponentModel.DataAnnotations;

namespace Ecommerce_DOT_NET.Models
{
    public class UserModel : BaseModel
    {

        [Required]
        [StringLength(50)]
        public string? Username { get; set; }

        [Required]
        [StringLength(50)]
        public string? Password { get; set; }

        [Required]
        [StringLength(50)]
        public string? Email { get; set; }

        [Required]
        public RoleEnum? Role { get; set; }
    }
}