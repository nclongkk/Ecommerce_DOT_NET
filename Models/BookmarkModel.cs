using System.ComponentModel.DataAnnotations;

namespace daily_blog.Models
{
    public class BookmarkModel : BaseModel
    {
        [Required]
        public int? UserId { get; set; }
        public virtual UserModel? User { get; set; }
        [Required]
        public int? PostId { get; set; }
        public virtual PostModel? Post { get; set; }
    }
}