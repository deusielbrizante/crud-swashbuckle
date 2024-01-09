using System.ComponentModel.DataAnnotations;

namespace crud_swashbuckle.Model
{
    public class User
    {
        
        public int Id { get; }
        
        [Required]
        public string Name { get; set; }
        
        public DateTime DateOfBirth { get; set; }

    }
}