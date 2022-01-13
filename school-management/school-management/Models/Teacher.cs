using System.ComponentModel.DataAnnotations.Schema;

namespace school_management.Models
{
    public class Teacher
    {
        public int Id { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Column(TypeName = "date")]
        public DateTime BirthDate { get; set; }

        public List<Student> Students { get; set; } = new List<Student>();

        public DateOnly BirthDateAsDate()
        {
            return DateOnly.FromDateTime(BirthDate);
        }
        public string GetFullName()
        {
            return FirstName + " " + LastName;
        }
    }
}
