using ebopenu20221a133.API.personnel.Domain.Model.Aggregates;
using ebopenu20221a133.API.Shared.Domain.Repositories;

namespace ebopenu20221a133.API.personnel.Domain.Repositories
{

    public interface IExaminerRepository : IBaseRepository<Examiner>
    {
        
        Task<Examiner?> FindByNationalProviderIdentifierAsync(string nationalProviderIdentifier);
    }
   
}