using ebopenu20221a133.API.personnel.Domain.Model.Commands;
using ebopenu20221a133.API.personnel.Domain.Services;
using ebopenu20221a133.API.personnel.Interfaces.REST.Resources;
using ebopenu20221a133.API.personnel.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace ebopenu20221a133.API.personnel.Interfaces.REST
{
    [ApiController]
    [Route("api/v1/examiners")]
    public class ExaminerController : ControllerBase
    {
            private readonly IExaminerCommandService examinerCommandService;
            
            public ExaminerController(IExaminerCommandService examinerCommandService)
            {
                this.examinerCommandService = examinerCommandService;
            }

            [HttpPost]
            public async Task<IActionResult> CreateExaminer(CreateExaminerResource resource)
            {
                var createExaminerCommand = CreateExaminerCommandFromResourceAssembler.ToCommandFromResource(resource);
                var examiner = await examinerCommandService.Handle(createExaminerCommand);
                var examinerResource = ExaminerResourceFromEntityAssembler.ToResourceFromEntity(examiner);
                return new CreatedResult(string.Empty, examinerResource);
            }
    }
}