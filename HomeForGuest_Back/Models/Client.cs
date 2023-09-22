using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeForGuest_Back.Models
{
    public class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Photo_Url { get; set; }

        //property of navigation for the User's relation
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
