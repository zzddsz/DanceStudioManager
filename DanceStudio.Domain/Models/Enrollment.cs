using System;
using System.Collections.Generic;
namespace DanceStudio.Domain.Models
{
    public class Enrollment
    {
        public int Id { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int DanceClassId { get; set; }
        public DanceClass DanceClass { get; set; }

        public DateTime Date { get; set; }
    }
}
