using AutoMapper;
using DanceStudio.Domain.Models;
using DanceStudio.Repository.Repositories;
using DanceStudio.Service.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace DanceStudio.Service.Services
{
    public class StudentService
    {
        private readonly StudentRepository _repository;
        private readonly IMapper _mapper;

        public StudentService(StudentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<StudentDTO>> ListarTodosAsync()
        {
            var lista = await _repository.GetAllAsync();
            return _mapper.Map<List<StudentDTO>>(lista);
        }

        public async Task<StudentDTO> BuscarPorIdAsync(int id)
        {
            var obj = await _repository.GetByIdAsync(id);
            return _mapper.Map<StudentDTO>(obj);
        }

        public async Task<(bool ok, string msg)> AdicionarAsync(StudentDTO dto)
        {
            try
            {
                var entity = _mapper.Map<Student>(dto);
                await _repository.AddAsync(entity);
                return (true, "Sucesso");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public async Task<(bool ok, string msg)> AtualizarAsync(int id, StudentDTO dto)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(id);
                if (entity == null) return (false, "Estudante não encontrado");

                _mapper.Map(dto, entity); 
                await _repository.UpdateAsync(entity);
                return (true, "Sucesso");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public async Task<(bool ok, string msg)> RemoverAsync(int id)
        {
            try
            {
                
                var entity = await _repository.GetByIdAsync(id);

                if (entity == null)
                    return (false, "Estudante não encontrado para exclusão.");

                await _repository.DeleteAsync(entity);

                return (true, "Sucesso");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
    }
}