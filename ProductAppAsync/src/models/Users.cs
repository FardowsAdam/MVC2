using System.ComponentModel.DataAnnotations;

namespace ProductAppAsync.src.models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public string Adedress { get; set; } = string.Empty;
        
    }
}