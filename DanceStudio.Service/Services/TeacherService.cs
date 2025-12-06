using AutoMapper;
using DanceStudio.Domain.Models;
using DanceStudio.Repository.Repositories;
using DanceStudio.Service.DTOs;
using DanceStudio.Service.Validators;
using FluentValidation;

namespace DanceStudio.Service.Services
{
    public class TeacherService
    {
        private readonly TeacherRepository _repo;
        private readonly IMapper _mapper;
        private readonly TeacherValidator _validator;

        public TeacherService(
            TeacherRepository repo,
            IMapper mapper,
            TeacherValidator validator)
        {
            _repo = repo;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<List<TeacherDTO>> ListarTodasAsync()
        {
            var list = await _repo.GetAllAsync();
            return _mapper.Map<List<TeacherDTO>>(list);
        }

        public async Task<TeacherDTO?> BuscarPorIdAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            return entity == null ? null : _mapper.Map<TeacherDTO>(entity);
        }

        public async Task<(bool ok, string message)> AdicionarAsync(TeacherDTO dto)
        {
            var val = _validator.Validate(dto);
            if (!val.IsValid)
                return (false, string.Join("; ", val.Errors.Select(e => e.ErrorMessage)));

            var entity = _mapper.Map<Teacher>(dto);
            await _repo.AddAsync(entity);

            return (true, "Professor cadastrado com sucesso");
        }

        public async Task<(bool ok, string message)> AtualizarAsync(int id, TeacherDTO dto)
        {
            var val = _validator.Validate(dto);
            if (!val.IsValid)
                return (false, string.Join("; ", val.Errors.Select(e => e.ErrorMessage)));

            var existing = await _repo.GetByIdAsync(id);
            if (existing == null)
                return (false, "Professor não encontrado");

            _mapper.Map(dto, existing);
            await _repo.UpdateAsync(existing);

            return (true, "Professor atualizado");
        }

        public async Task<(bool ok, string message)> RemoverAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity == null)
                return (false, "Professor não encontrado");

            await _repo.DeleteAsync(entity);

            return (true, "Professor removido com sucesso");
        }
    }
}
