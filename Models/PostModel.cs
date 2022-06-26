using System.ComponentModel.DataAnnotations;

namespace daily_blog.Models
{
    public class PostModel : BaseModel
    {

        [StringLength(50)]
        public string? Title { get; set; }

        [StringLength(100)]
        public string? Image { get; set; }

        [StringLength(100)]
        public string? Url { get; set; }

        public int? Upvote { get; set; }
        public virtual ICollection<BookmarkModel>? Bookmarks { get; set; }

        [Required]
        public int? AuthorId { get; set; }
        [Required]
        public virtual UserModel? Author { get; set; }


    }
}