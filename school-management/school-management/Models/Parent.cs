using System.ComponentModel.DataAnnotations.Schema;

namespace school_management.Models
{
    public class Parent
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        [Column(TypeName = "date")]
        public DateTime BirthDate { get; set; }
        public List<Student> Students { get; set; }

        public DateOnly BirthDateAsDate()
        {
            return DateOnly.FromDateTime(BirthDate);
        }
        public string FullName()
        {
            return FirstName + " " + LastName;
        }
    }
}
