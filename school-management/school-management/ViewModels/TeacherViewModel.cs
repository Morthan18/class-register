namespace school_management.Controllers
{
    public class TeacherViewModel
    {
        public TeacherViewModel(int id, DateTime birthDate, string fullName)
        {
            Id = id;
            BirthDate = DateOnly.FromDateTime(birthDate);
            FullName = fullName;    
        }

        public int Id { get; set; }

        public DateOnly BirthDate { get; set; }
        public string FullName { get; set; }


    }
}
