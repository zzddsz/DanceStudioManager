using AutoMapper;
using DanceStudio.Domain.Base;
using DanceStudio.Repository.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DanceStudio.Service.Base
{
    public class BaseService<TEntity> : IBaseService<TEntity>
        where TEntity : BaseEntity<int>
    {
        private readonly IBaseRepository<TEntity> _baseRepository;
        private readonly IMapper _mapper;

        public BaseService(IBaseRepository<TEntity> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<TOutputModel> Add<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
            where TInputModel : class
            where TOutputModel : class
            where TValidator : AbstractValidator<TEntity>
        {
            var entity = _mapper.Map<TEntity>(inputModel);

            Validate(entity, Activator.CreateInstance<TValidator>());

            await _baseRepository.InsertAsync(entity);

            return _mapper.Map<TOutputModel>(entity);
        }

        public async Task Delete(int id)
        {
            await _baseRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<TOutputModel>> Get<TOutputModel>(IList<string>? includes = null)
            where TOutputModel : class
        {
            var entities = await _baseRepository.SelectAsync(includes);
            return entities.Select(e => _mapper.Map<TOutputModel>(e));
        }

        public async Task<TOutputModel> GetById<TOutputModel>(int id, IList<string>? includes = null)
            where TOutputModel : class
        {
            var entity = await _baseRepository.SelectAsync(id, includes);
            return _mapper.Map<TOutputModel>(entity);
        }

        public async Task<TOutputModel> Update<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
            where TInputModel : class
            where TOutputModel : class
            where TValidator : AbstractValidator<TEntity>
        {
            var entity = _mapper.Map<TEntity>(inputModel);

            Validate(entity, Activator.CreateInstance<TValidator>());

            await _baseRepository.UpdateAsync(entity);

            return _mapper.Map<TOutputModel>(entity);
        }

        private void Validate(TEntity obj, AbstractValidator<TEntity> validator)
        {
            if (obj == null)
                throw new Exception("Registros não detectados!");

            validator.ValidateAndThrow(obj);
        }
    }
}
