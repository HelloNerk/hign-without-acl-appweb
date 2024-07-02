using ebopenu20221a133.API.assessment.Domain.Model.Commands;
using ebopenu20221a133.API.assessment.Domain.Services;
using ebopenu20221a133.API.assessment.Interfaces.REST.Resources;
using ebopenu20221a133.API.assessment.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace ebopenu20221a133.API.assessment.Interfaces.REST
{
    [ApiController]
    [Route("api/v1/mental-state-exams")]
    public class MentalStateExamController : ControllerBase
    {
        private readonly IMentalStateExamCommandService mentalStateExamCommandService;
        
        public MentalStateExamController(IMentalStateExamCommandService mentalStateExamCommandService)
        {
            this.mentalStateExamCommandService = mentalStateExamCommandService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMentalStateExam(CreateMentalStateExamResource resource)
        {
            var createMentalStateExamCommand = CreateMentalStateExamCommandFromResourceAssembler.ToCommandFromResource(resource);
            var mentalStateExam = await mentalStateExamCommandService.Handle(createMentalStateExamCommand);
            var mentalStateExamResource = MentalStateExamResourceFromEntityAssembler.ToResourceFromEntity(mentalStateExam);
            return new CreatedResult(string.Empty, mentalStateExamResource);
        }
    }
}
