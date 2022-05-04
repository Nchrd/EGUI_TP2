using lab2.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab2.Models
{
    public class BlogModel : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public int BlogId { get; set; }
        [Required(ErrorMessage="Title is required")]
        public string Title { get; set; }
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public UserModel User { get; set; }
        public List<PostModel> Posts { get; set; }
    }
}
