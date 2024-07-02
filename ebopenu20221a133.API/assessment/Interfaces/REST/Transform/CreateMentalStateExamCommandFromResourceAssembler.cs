using ebopenu20221a133.API.assessment.Domain.Model.Commands;
using ebopenu20221a133.API.assessment.Interfaces.REST.Resources;

namespace ebopenu20221a133.API.assessment.Interfaces.REST.Transform{

    public class CreateMentalStateExamCommandFromResourceAssembler
    {
        public static CreateMentalStateExamCommand ToCommandFromResource(CreateMentalStateExamResource resource)
        {
            return new CreateMentalStateExamCommand(
                resource.PatientId,
                resource.ExaminerNationalProvidedIdentifier,
                resource.ExamDate,
                resource.OrientationScore,
                resource.RegistrationScore,
                resource.AttentionAndCalculationScore,
                resource.RecallScore,
                resource.LanguageScore
            );
        }
    }
}