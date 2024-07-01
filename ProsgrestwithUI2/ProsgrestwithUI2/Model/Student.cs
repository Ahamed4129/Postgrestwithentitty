using System.ComponentModel.DataAnnotations;

namespace ProsgrestwithUI2.Model
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public string Gender { get; set; }
    }
}
