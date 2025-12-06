using DanceStudio.Service.DTOs;
using DanceStudio.Service.Services;

namespace DanceStudioManager.Controllers
{
    public class EnrollmentController
    {
        private readonly EnrollmentService _service;

        public EnrollmentController(EnrollmentService service)
        {
            _service = service;
        }

        public Task<List<EnrollmentDTO>> Listar()
            => _service.ListarTodasAsync();

        public Task<(bool ok, string msg)> Criar(EnrollmentDTO dto)
            => _service.AdicionarAsync(dto);

        public Task<(bool ok, string msg)> Remover(int id)
            => _service.RemoverAsync(id);
    }
}
