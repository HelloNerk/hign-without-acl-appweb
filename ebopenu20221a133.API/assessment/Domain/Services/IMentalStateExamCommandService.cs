using ebopenu20221a133.API.assessment.Domain.Model.Aggregates;
using ebopenu20221a133.API.assessment.Domain.Model.Commands;

namespace ebopenu20221a133.API.assessment.Domain.Services
{

    public interface IMentalStateExamCommandService
    {
        Task<MentalStateExam?> Handle(CreateMentalStateExamCommand command);
    }
}