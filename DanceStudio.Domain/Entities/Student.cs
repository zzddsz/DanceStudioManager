using DanceStudio.Domain.Base;

namespace DanceStudio.Domain.Entities
{
    public class Student : BaseEntity<int>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Level { get; set; }
    }
}