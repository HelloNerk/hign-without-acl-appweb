using ebopenu20221a133.API.assessment.Domain.Model.Aggregates;
using ebopenu20221a133.API.assessment.Interfaces.REST.Resources;

namespace ebopenu20221a133.API.assessment.Interfaces.REST.Transform
{
    public class MentalStateExamResourceFromEntityAssembler
    {
        public static MentalStateExamResource ToResourceFromEntity(MentalStateExam entity)
        {
            return new MentalStateExamResource(
                entity.Id,
                entity.PatientId,
                entity.getExaminerNationalProviderIdentifier(),
                entity.ExamDate,
                entity.OrientationScore,
                entity.RegistrationScore,
                entity.AttentionAndCalculationScore,
                entity.RecallScore,
                entity.LanguageScore
            );
        }
    }
}