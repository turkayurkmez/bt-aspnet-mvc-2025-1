using System.ComponentModel.DataAnnotations;

namespace introduceMVC.Models
{
    public class Person
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Lütfen adınızı giriniz")]
        public string Name { get; set; }
        public string Surname { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}
