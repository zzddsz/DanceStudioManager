
namespace DanceStudioManager.ViewModel
{
    public class DanceClassViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;      
        public string Teacher { get; set; } = string.Empty;   
        public string DayOfWeek { get; set; } = string.Empty; 
        public TimeSpan Time { get; set; }                    
        public int MaxStudents { get; set; }                  
    }
}