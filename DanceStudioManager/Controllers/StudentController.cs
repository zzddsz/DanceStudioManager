using DanceStudio.Service.DTOs;
using DanceStudio.Service.Services;

namespace DanceStudioManager.Controllers
{
    public class StudentController
    {
        private readonly StudentService _service;

        public StudentController(StudentService service)
        {
            _service = service;
        }

        public Task<List<StudentDTO>> Listar()
            => _service.ListarTodasAsync();

        public Task<StudentDTO?> Buscar(int id)
            => _service.BuscarPorIdAsync(id);

        public Task<(bool ok, string msg)> Criar(StudentDTO dto)
            => _service.AdicionarAsync(dto);

        public Task<(bool ok, string msg)> Atualizar(int id, StudentDTO dto)
            => _service.AtualizarAsync(id, dto);

        public Task<(bool ok, string msg)> Remover(int id)
            => _service.RemoverAsync(id);
    }
}
