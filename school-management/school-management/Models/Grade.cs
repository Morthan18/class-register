using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace school_management.Models
{
    public class Grade
    {
        public int Id { get; set; }
        [Range(1, 6)]
        public int GradeNumber { get; set; }
        public string Description { get; set; }
        public Student Student { get; set; }
        public SchoolSubject SchoolSubject { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
