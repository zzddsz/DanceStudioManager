namespace DanceStudioManager.ViewModel
{
    public class EnrollmentViewModel
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int DanceClassId { get; set; }
        public string DanceClassName { get; set; }
        public DateTime Date { get; set; }
    }
}
