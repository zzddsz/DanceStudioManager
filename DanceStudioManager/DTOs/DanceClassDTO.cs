namespace DanceStudioManager.DTOs
{
    public class DanceClassDTO
    {
        public int Id { get; set; } // útil para editar
        public string Nome { get; set; } = string.Empty;
        public string Professor { get; set; } = string.Empty;
        public string DiaDaSemana { get; set; } = string.Empty;
        public TimeSpan Horario { get; set; }
        public int NumeroVagas { get; set; }
    }
}
