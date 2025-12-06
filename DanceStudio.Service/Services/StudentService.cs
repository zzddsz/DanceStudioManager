using AutoMapper;
using DanceStudio.Domain.Models;
using DanceStudio.Repository.Repositories;
using DanceStudio.Service.DTOs;
using DanceStudio.Service.Validators;
using FluentValidation;

namespace DanceStudio.Service.Services
{
    public class StudentService
    {
        private readonly StudentRepository _repo;
        private readonly IMapper _mapper;
        private readonly StudentValidator _validator;

        public StudentService(
            StudentRepository repo,
            IMapper mapper,
            StudentValidator validator)
        {
            _repo = repo;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<List<StudentDTO>> ListarTodasAsync()
        {
            var list = await _repo.GetAllAsync();
            return _mapper.Map<List<StudentDTO>>(list);
        }

        public async Task<StudentDTO?> BuscarPorIdAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            return entity == null ? null : _mapper.Map<StudentDTO>(entity);
        }

        public async Task<(bool ok, string message)> AdicionarAsync(StudentDTO dto)
        {
            var val = _validator.Validate(dto);
            if (!val.IsValid)
                return (false, string.Join("; ", val.Errors.Select(e => e.ErrorMessage)));

            var entity = _mapper.Map<Student>(dto);
            await _repo.AddAsync(entity);

            return (true, "Aluno cadastrado com sucesso");
        }

        public async Task<(bool ok, string message)> AtualizarAsync(int id, StudentDTO dto)
        {
            var val = _validator.Validate(dto);
            if (!val.IsValid)
                return (false, string.Join("; ", val.Errors.Select(e => e.ErrorMessage)));

            var existing = await _repo.GetByIdAsync(id);
            if (existing == null)
                return (false, "Aluno não encontrado");

            _mapper.Map(dto, existing);
            await _repo.UpdateAsync(existing);

            return (true, "Aluno atualizado");
        }

        public async Task<(bool ok, string message)> RemoverAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity == null)
                return (false, "Aluno não encontrado");

            await _repo.DeleteAsync(entity);

            return (true, "Aluno removido com sucesso");
        }
    }
}
