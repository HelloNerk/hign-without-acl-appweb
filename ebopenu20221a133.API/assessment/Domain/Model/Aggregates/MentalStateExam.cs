using System.ComponentModel.DataAnnotations;
using ebopenu20221a133.API.assessment.Domain.Model.Commands;
using ebopenu20221a133.API.personnel.Domain.Model.Aggregates;
using ebopenu20221a133.API.personnel.Domain.Model.Commands;

namespace ebopenu20221a133.API.assessment.Domain.Model.Aggregates
{
    public partial class MentalStateExam
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string ExaminerNationalProviderIdentifier { get; set; }
        
        [Required] 
        public long PatientId{get;set;}
        
        [Required]
        public DateTime ExamDate { get; set; }
        
        [Required]
        public int OrientationScore { get; set; }
        
        [Required]
        public int RegistrationScore { get; set; }
        
        [Required]
        public int AttentionAndCalculationScore { get; set; }
        
        [Required]
        public int RecallScore { get; set; }
        
        [Required]
        public int LanguageScore { get; set; }
        
        [Required]
        public int ExaminerId { get; set; }
        
        public Examiner Examiner { get; set; }
        
        public MentalStateExam()
        {
            PatientId= 0;
            ExaminerNationalProviderIdentifier = "";
            ExamDate = DateTime.Now;
            OrientationScore = 0;
            RegistrationScore = 0;
            AttentionAndCalculationScore = 0;
            RecallScore = 0;
            LanguageScore = 0;
            ExaminerId= 0;
            Examiner = new Examiner();
        }

        public MentalStateExam(
            long patientId,
            string examinerNationalProviderIdentifier,
            DateTime examDate,
            int orientationScore,
            int registrationScore,
            int attentionAndCalculationScore,
            int recallScore,
            int languageScore,
            int examinerId
            )
        {
            PatientId = patientId;
            ExaminerNationalProviderIdentifier = examinerNationalProviderIdentifier;
            ExamDate = examDate;
            OrientationScore = orientationScore;
            RegistrationScore = registrationScore;
            AttentionAndCalculationScore = attentionAndCalculationScore;
            RecallScore = recallScore;
            LanguageScore = languageScore;
            ExaminerId = examinerId;
            Examiner = new Examiner();
        }
        
        public MentalStateExam(CreateMentalStateExamCommand command,int examinerId,Examiner examiner)
        {
            PatientId = command.PatientId;
            ExaminerNationalProviderIdentifier = command.ExaminerNationalProviderIdentifier;
            ExamDate = command.ExamDate;
            OrientationScore = command.OrientationScore;
            RegistrationScore = command.RegistrationScore;
            AttentionAndCalculationScore = command.AttentionAndCalculationScore;
            RecallScore = command.RecallScore;
            LanguageScore = command.LanguageScore;
            ExaminerId = examinerId;
            Examiner = examiner;
        }
        
        public string getExaminerNationalProviderIdentifier()
        {
            return ExaminerNationalProviderIdentifier;
        }
    }    
}

