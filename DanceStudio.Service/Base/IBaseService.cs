using DanceStudio.Domain.Base;
using FluentValidation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DanceStudio.Service.Base
{
    public interface IBaseService<TEntity> where TEntity : BaseEntity<int>
    {
        Task<TOutputModel> Add<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
            where TValidator : AbstractValidator<TEntity>
            where TInputModel : class
            where TOutputModel : class;

        Task Delete(int id);

        Task<IEnumerable<TOutputModel>> Get<TOutputModel>(IList<string>? includes = null)
            where TOutputModel : class;

        Task<TOutputModel> GetById<TOutputModel>(int id, IList<string>? includes = null)
            where TOutputModel : class;

        Task<TOutputModel> Update<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
            where TValidator : AbstractValidator<TEntity>
            where TInputModel : class
            where TOutputModel : class;
    }
}