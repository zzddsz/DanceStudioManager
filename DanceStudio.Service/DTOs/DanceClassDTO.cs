namespace DanceStudio.Service.DTOs
{
    public class DanceClassDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Professor { get; set; } = string.Empty;
        public string DiaDaSemana { get; set; } = string.Empty;
        public TimeSpan Horario { get; set; }
        public int NumeroVagas { get; set; }
    }
}
