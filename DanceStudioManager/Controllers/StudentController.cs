using DanceStudio.Service.DTOs;
using DanceStudio.Service.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DanceStudioManager.Controllers
{
    public class StudentController
    {
        private readonly StudentService _service;

        public StudentController(StudentService service)
        {
            _service = service;
        }

        public async Task Add(StudentDTO dto)
        {
            await _service.AdicionarAsync(dto);
        }

        public Task<List<StudentDTO>> Listar()
            => _service.ListarTodosAsync();

        public Task<StudentDTO> Buscar(int id)
            => _service.BuscarPorIdAsync(id);

        public Task<(bool ok, string msg)> Atualizar(int id, StudentDTO dto)
            => _service.AtualizarAsync(id, dto);

        public Task<(bool ok, string msg)> Remover(int id)
            => _service.RemoverAsync(id);
    }
}