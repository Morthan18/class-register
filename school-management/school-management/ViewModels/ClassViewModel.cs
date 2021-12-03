namespace school_management.ViewModels
{
    public class ClassViewModel
    {
        public ClassViewModel(int id, string name, int year, string classTeacherFullName)
        {
            Id = id;
            Name = name;
            Year = year;
            ClassTeacherFullName = classTeacherFullName;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string ClassTeacherFullName { get; set; }
    }
}
