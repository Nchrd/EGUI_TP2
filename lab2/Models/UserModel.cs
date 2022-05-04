using lab2.Data.Base;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace lab2.Models
{
    [Serializable]
    public class UserModel: IdentityUser, IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }

        //Relationships
        public List<BlogModel> Blogs { get; set; }
    }
}
