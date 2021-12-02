namespace school_management.Models
{
    public class Grade
    {
        public int Id { get; set; }
        public int GradeNumber { get; set; }
        public string Description { get; set; }
        public Student Student { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
