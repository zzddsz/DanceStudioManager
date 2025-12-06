using DanceStudio.Service.DTOs;
using DanceStudio.Service.Services;

namespace DanceStudioManager.Controllers
{
    public class TeacherController
    {
        private readonly TeacherService _service;

        public TeacherController(TeacherService service)
        {
            _service = service;
        }

        public Task<List<TeacherDTO>> Listar()
            => _service.ListarTodasAsync();

        public Task<TeacherDTO?> Buscar(int id)
            => _service.BuscarPorIdAsync(id);

        public Task<(bool ok, string msg)> Criar(TeacherDTO dto)
            => _service.AdicionarAsync(dto);

        public Task<(bool ok, string msg)> Atualizar(int id, TeacherDTO dto)
            => _service.AtualizarAsync(id, dto);

        public Task<(bool ok, string msg)> Remover(int id)
            => _service.RemoverAsync(id);
    }
}
