using DanceStudio.Service.DTOs;
using DanceStudio.Service.Services;
using System.Collections.Generic;
using System.Threading.Tasks; 

namespace DanceStudioManager.Controllers
{
    public class DanceClassController
    {
        private readonly DanceClassService _service;

        public DanceClassController(DanceClassService service)
        {
            _service = service;
        }

        public async Task Add(DanceClassDTO dto)
        {
            await _service.AdicionarAsync(dto);
        }

        public Task<List<DanceClassDTO>> Listar()
            => _service.ListarTodasAsync();

        public Task<DanceClassDTO> Buscar(int id)
            => _service.BuscarPorIdAsync(id);

        public Task<(bool ok, string msg)> Criar(DanceClassDTO dto)
            => _service.AdicionarAsync(dto);

        public Task<(bool ok, string msg)> Atualizar(int id, DanceClassDTO dto)
            => _service.AtualizarAsync(id, dto);

        public Task<(bool ok, string msg)> Remover(int id)
            => _service.RemoverAsync(id);
    }
}