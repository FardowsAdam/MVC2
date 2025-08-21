using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductAppAsync.src.models
{
    public class Profile
    {
        [Key]
        public int Id { get; set; }

        public string? Username { get; set; }

        public string? Pass { get; set; }

       
        [ForeignKey("user")]
        public int UserId { get; set; }

        
        
    }
}