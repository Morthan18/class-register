using System.ComponentModel.DataAnnotations.Schema;

namespace school_management.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Column(TypeName = "date")]
        public DateTime BirthDate { get; set; }

        public Parent Parent { get; set; }
        public Class? @class { get; set; }

        public List<Teacher> Teachers { get; set; }
    }
}
