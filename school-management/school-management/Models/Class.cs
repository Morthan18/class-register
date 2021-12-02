namespace school_management.Models
{
    public class Class
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public int Year { get; set; }   
        public Teacher ClassTeacher { get; set; }   

        public List<SchoolSubject> Subjects { get; set; }   
        public List<Student> Students { get; set; }
    }
}
