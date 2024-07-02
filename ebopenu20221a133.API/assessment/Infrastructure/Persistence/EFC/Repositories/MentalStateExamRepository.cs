using ebopenu20221a133.API.assessment.Domain.Model.Aggregates;
using ebopenu20221a133.API.assessment.Domain.Repositories;
using ebopenu20221a133.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using ebopenu20221a133.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace ebopenu20221a133.API.assessment.Infrastructure.Persistence.EFC.Repositories
{
    
    public class MentalStateExamRepository : BaseRepository<MentalStateExam>, IMentalStateExamRepository
    {
        public MentalStateExamRepository(AppDbContext context) : base(context)
        {
        }
    }
}