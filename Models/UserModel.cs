using System.ComponentModel.DataAnnotations;

namespace daily_blog.Models
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

        public virtual ICollection<PostModel>? Posts { get; set; }

        public string toString()
        {
            return $"{Id} - {Username} - {Password} - {Email} - {Role} - {CreatedAt}";
        }
    }
}