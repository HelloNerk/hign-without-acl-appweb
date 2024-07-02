using ebopenu20221a133.API.personnel.Domain.Model.Aggregates;
using ebopenu20221a133.API.personnel.Domain.Model.Commands;

namespace ebopenu20221a133.API.personnel.Domain.Services
{

    public interface IExaminerCommandService
    {

        Task<Examiner?> Handle(CreateExaminerCommand command);
    }
}