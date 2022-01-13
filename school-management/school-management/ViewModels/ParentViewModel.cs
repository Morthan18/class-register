namespace school_management.ViewModels
{
    public class ParentViewModel
    {
        public ParentViewModel(int id, string fullName)
        {
            Id = id;
            FullName = fullName;
        }

        public int Id { get; set; }
        public string FullName { get; set; }
    }
}
