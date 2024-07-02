using ebopenu20221a133.API.personnel.Domain.Model.Commands;
using ebopenu20221a133.API.personnel.Interfaces.REST.Resources;

namespace ebopenu20221a133.API.personnel.Interfaces.REST.Transform
{

    public class CreateExaminerCommandFromResourceAssembler
    {
        public static CreateExaminerCommand ToCommandFromResource(CreateExaminerResource resource)
        {
            return new CreateExaminerCommand(resource.FirstName, resource.LastName, resource.NationalProviderIdentifier);
        }
    }
}