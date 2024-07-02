using ebopenu20221a133.API.personnel.Domain.Model.Aggregates;
using ebopenu20221a133.API.personnel.Domain.Repositories;
using ebopenu20221a133.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using ebopenu20221a133.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ebopenu20221a133.API.personnel.Infrastructure.Persistence.EFC.Repositories
{

    public class ExaminerRepository: BaseRepository<Examiner>, IExaminerRepository
    {
        public ExaminerRepository(AppDbContext context) : base(context)
        {
        }
        
        public async Task<Examiner?> FindByNationalProviderIdentifierAsync(string nationalProviderIdentifier)
        {
            return await Context.Set<Examiner>()
                .FirstOrDefaultAsync(p=>p.NationalProviderIdentifier == nationalProviderIdentifier);
        }
    }
}