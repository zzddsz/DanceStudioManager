using AutoMapper;
using DanceStudio.Domain.Models;
using DanceStudio.Repository.Repositories;
using DanceStudio.Service.DTOs;
using DanceStudio.Service.Validators; // <- CORRETO
using FluentValidation;

namespace DanceStudio.Service.Services
{
    public class DanceClassService
    {
        private readonly DanceClassRepository _repo;
        private readonly IMapper _mapper;
        private readonly DanceClassValidator _validator;

        public DanceClassService(
            DanceClassRepository repo,
            IMapper mapper,
            DanceClassValidator validator)
        {
            _repo = repo;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<List<DanceClassDTO>> ListarTodasAsync()
        {
            var list = await _repo.GetAllAsync();
            return _mapper.Map<List<DanceClassDTO>>(list);
        }

        public async Task<DanceClassDTO?> BuscarPorIdAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            return entity == null ? null : _mapper.Map<DanceClassDTO>(entity);
        }

        public async Task<(bool ok, string message)> AdicionarAsync(DanceClassDTO dto)
        {
            var val = _validator.Validate(dto);
            if (!val.IsValid)
                return (false, string.Join("; ", val.Errors.Select(e => e.ErrorMessage)));

            var entity = _mapper.Map<DanceClass>(dto);
            await _repo.AddAsync(entity);

            return (true, "Aula adicionada com sucesso");
        }

        public async Task<(bool ok, string message)> AtualizarAsync(int id, DanceClassDTO dto)
        {
            var val = _validator.Validate(dto);
            if (!val.IsValid)
                return (false, string.Join("; ", val.Errors.Select(e => e.ErrorMessage)));

            var existing = await _repo.GetByIdAsync(id);
            if (existing == null)
                return (false, "Aula não encontrada");

            _mapper.Map(dto, existing);
            await _repo.UpdateAsync(existing);

            return (true, "Aula atualizada");
        }

        public async Task<(bool ok, string message)> RemoverAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity == null)
                return (false, "Aula não encontrada");

            await _repo.DeleteAsync(entity);

            return (true, "Removida com sucesso");
        }
    }
}
