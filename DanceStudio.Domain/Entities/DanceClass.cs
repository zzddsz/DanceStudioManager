using DanceStudio.Domain.Base;
using System;

namespace DanceStudio.Domain.Entities
{
    public class DanceClass : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Teacher { get; set; }
        public string DayOfWeek { get; set; }
        public TimeSpan Time { get; set; }
        public int MaxStudents { get; set; }
    }
}