using DanceStudio.Domain.Base;
using System;

namespace DanceStudio.Domain.Entities
{
    public class DanceClass : BaseEntity<int>
    {
        public string Name { get; set; }
        public string DayOfWeek { get; set; }
        public TimeSpan Time { get; set; }
        public int MaxStudents { get; set; }
        public int? TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}