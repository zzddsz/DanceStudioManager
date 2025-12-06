namespace DanceStudio.Domain.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Specialty { get; set; }
        public ICollection<DanceClass> DanceClass { get; set; }
    }
}
