using school_management.Models;

namespace school_management.ViewModels
{
    public class StudentViewModel
    {

        public StudentViewModel(int id, string firstName, string lastName, DateTime birthDate, Parent parent, Class? @class, List<Teacher> teachers)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = DateOnly.FromDateTime(birthDate);
            Parent = parent;
            this.@class = @class;
            Teachers = teachers;
            ParentFullName = parent.FullName();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateOnly BirthDate { get; set; }

        public Parent Parent { get; set; }
        public Class? @class { get; set; }

        public List<Teacher> Teachers { get; set; }

        public string ParentFullName { get; set; }

    }
}
