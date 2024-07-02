using ebopenu20221a133.API.personnel.Domain.Model.Aggregates;
using ebopenu20221a133.API.personnel.Interfaces.REST.Resources;

namespace ebopenu20221a133.API.personnel.Interfaces.REST.Transform
{

    public class ExaminerResourceFromEntityAssembler
    {
        public static ExaminerResource ToResourceFromEntity(Examiner entity)
        {
            return new ExaminerResource(entity.Id, entity.FirstName, entity.LastName, entity.NationalProviderIdentifier);
        }
    }
}