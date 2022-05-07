using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab2.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Please enter a title")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "You have to put content in your entry")]
        public string? Content { get; set; }
        public DateTime Date { get; set; }
        public string Author { get; set; }

        //Relationship
        [ForeignKey("BlogId")]
        public Blog? Blog { get; set; }
        public int BlogId { get; set; }
    }
}
