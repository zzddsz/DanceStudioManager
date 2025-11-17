using DanceStudioManager.DTOs;
using DanceStudioManager.Services;

namespace DanceStudioManager.Controllers
{
    public class DanceClassController
    {
        private readonly DanceClassService _service;
        public DanceClassController(DanceClassService service) => _service = service;

        public Task<List<DanceClassDTO>> Listar() => _service.ListarTodasAsync();
        public Task<DanceClassDTO?> Buscar(int id) => _service.BuscarPorIdAsync(id);
        public Task<(bool ok, string msg)> Criar(DanceClassDTO dto) => _service.AdicionarAsync(dto);
        public Task<(bool ok, string msg)> Atualizar(int id, DanceClassDTO dto) => _service.AtualizarAsync(id, dto);
        public Task<(bool ok, string msg)> Remover(int id) => _service.RemoverAsync(id);
    }
}
