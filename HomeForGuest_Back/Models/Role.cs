using System.ComponentModel.DataAnnotations;
namespace HomeForGuest_Back.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public ICollection<UserRoles> UserRoles { get; set; }
    }

}
