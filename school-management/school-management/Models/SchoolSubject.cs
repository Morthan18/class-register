namespace school_management.Models
{
    public class SchoolSubject
    {
        public int Id { get; set; }    
        public string Name { get; set; }
        public Teacher Teacher { get; set; }    
        public string SubjectContent { get; set; }  
    }
}
