namespace ebopenu20221a133.API.assessment.Domain.Model.Commands;

public record CreateMentalStateExamCommand(
        long PatientId,
        string ExaminerNationalProviderIdentifier,
        DateTime ExamDate,
        int OrientationScore,
        int RegistrationScore,
        int AttentionAndCalculationScore,
        int RecallScore,
        int LanguageScore
    );