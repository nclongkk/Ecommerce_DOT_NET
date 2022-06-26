using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace daily_blog.Models
{
    public class BaseModel
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [DataType(DataType.Date)]
        public DateTime? CreatedAt { get; set; }
    }
}