using DanceStudio.Domain.Base;
using System;

namespace DanceStudio.Domain.Entities
{
    public class Enrollment : BaseEntity<int>
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int DanceClassId { get; set; }
        public DanceClass DanceClass { get; set; }

        public DateTime Date { get; set; }
    }
}