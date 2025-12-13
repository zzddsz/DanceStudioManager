using DanceStudio.Domain.Base;
using System.Collections.Generic;

namespace DanceStudio.Domain.Entities
{
    public class Teacher : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Specialty { get; set; }
        public ICollection<DanceClass> DanceClass { get; set; }
    }
}