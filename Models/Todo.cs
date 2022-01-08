using System.ComponentModel.DataAnnotations;

namespace ReastApiJwt.Models
{
    public class Todo
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
    }
}