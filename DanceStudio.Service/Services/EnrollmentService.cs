using AutoMapper;
using DanceStudio.Domain.Models;
using DanceStudio.Repository.Repositories;
using DanceStudio.Service.DTOs;
using DanceStudio.Service.Validators;

namespace DanceStudio.Service.Services
{
    public class EnrollmentService
    {
        private readonly EnrollmentRepository _repo;
        private readonly StudentRepository _studentRepo;
        private readonly DanceClassRepository _classRepo;
        private readonly IMapper _mapper;
        private readonly EnrollmentValidator _validator;

        public EnrollmentService(
            EnrollmentRepository repo,
            StudentRepository studentRepo,
            DanceClassRepository classRepo,
            IMapper mapper,
            EnrollmentValidator validator)
        {
            _repo = repo;
            _studentRepo = studentRepo;
            _classRepo = classRepo;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<List<EnrollmentDTO>> ListarTodasAsync()
        {
            var list = await _repo.GetAllAsync();
            return _mapper.Map<List<EnrollmentDTO>>(list);
        }

        public async Task<(bool ok, string message)> AdicionarAsync(EnrollmentDTO dto)
        {
            var val = _validator.Validate(dto);
            if (!val.IsValid)
                return (false, string.Join("; ", val.Errors.Select(e => e.ErrorMessage)));

            if (await _studentRepo.GetByIdAsync(dto.StudentId) == null)
                return (false, "Aluno não existe");

            if (await _classRepo.GetByIdAsync(dto.DanceClassId) == null)
                return (false, "Aula não existe");

            var entity = _mapper.Map<Enrollment>(dto);
            await _repo.AddAsync(entity);

            return (true, "Matrícula criada com sucesso");
        }

        public async Task<(bool ok, string message)> RemoverAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity == null)
                return (false, "Matrícula não encontrada");

            await _repo.DeleteAsync(entity);

            return (true, "Matrícula removida");
        }
    }
}
