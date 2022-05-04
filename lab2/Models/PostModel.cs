using lab2.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab2.Models
{
    public class PostModel : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }

        [ForeignKey("BlogId")]
        public BlogModel Blog { get; set; }
        public int BlogId { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
    }
}
