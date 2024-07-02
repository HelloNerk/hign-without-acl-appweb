namespace ebopenu20221a133.API.assessment.Interfaces.REST.Resources;

public record CreateMentalStateExamResource(
        long PatientId,
        string ExaminerNationalProvidedIdentifier,
        DateTime ExamDate,
        int OrientationScore,
        int RegistrationScore,
        int AttentionAndCalculationScore,
        int RecallScore,
        int LanguageScore
    );