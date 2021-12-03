namespace school_management.Controllers
{
    public class TeacherViewModel
    {
        public TeacherViewModel(int id, DateTime birthDate, string fullName)
        {
            Id = id;
            BirthDate = birthDate;
            FullName = fullName;    
        }

        public int Id { get; set; }

        public DateTime BirthDate { get; set; }
        public string FullName { get; set; }


    }
}
