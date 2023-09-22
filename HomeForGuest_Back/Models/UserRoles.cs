using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace HomeForGuest_Back.Models
{
    public class UserRoles
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        [ForeignKey("RoleId")]
        public int RoleId { get; set; }
        public User User { get; set; }
        public Role Role { get; set; }
    }

}
