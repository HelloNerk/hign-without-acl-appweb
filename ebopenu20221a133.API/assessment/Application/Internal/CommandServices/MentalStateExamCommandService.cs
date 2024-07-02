using System.Text.RegularExpressions;
using ebopenu20221a133.API.assessment.Domain.Model.Aggregates;
using ebopenu20221a133.API.assessment.Domain.Model.Commands;
using ebopenu20221a133.API.assessment.Domain.Repositories;
using ebopenu20221a133.API.assessment.Domain.Services;
using ebopenu20221a133.API.personnel.Domain.Model.Aggregates;
using ebopenu20221a133.API.personnel.Domain.Repositories;
using ebopenu20221a133.API.Shared.Domain.Repositories;

namespace ebopenu20221a133.API.assessment.Application.Internal.CommandServices
{

    public class MentalStateExamCommandService : IMentalStateExamCommandService
    {
        private readonly IMentalStateExamRepository mentalStateExamRepository;
        private readonly IExaminerRepository examinerRepository;
        private readonly IUnitOfWork unitOfWork;
        
        public MentalStateExamCommandService(IMentalStateExamRepository mentalStateExamRepository, IUnitOfWork unitOfWork, IExaminerRepository examinerRepository)
        {
            this.mentalStateExamRepository = mentalStateExamRepository ?? throw new System.ArgumentNullException(nameof(mentalStateExamRepository));
            this.unitOfWork = unitOfWork ?? throw new System.ArgumentNullException(nameof(unitOfWork));
            this.examinerRepository = examinerRepository ?? throw new System.ArgumentNullException(nameof(examinerRepository));
        }

        public async Task<MentalStateExam?> Handle(CreateMentalStateExamCommand command)
        {
            try
            {
                var examiner =
                    await examinerRepository.FindByNationalProviderIdentifierAsync(command.ExaminerNationalProviderIdentifier);
                if (examiner == null)
                {
                    throw new System.ArgumentException("Examiner not found.");
                }
            
                if (command.ExaminerNationalProviderIdentifier.Length != 36)
                {
                    throw new System.ArgumentException("ExaminerNationalProviderIdentifier must be 36 characters long.");
                }
                
                if(command.ExamDate > DateTime.Now)
                {
                    throw new System.ArgumentException("ExamDate must be before the current date.");
                }
                
                if(command.OrientationScore< 0 || command.OrientationScore > 10)
                {
                    throw new System.ArgumentException("OrientationScore must be between 0 and 10.");
                }
                
                if(command.RegistrationScore<0 || command.RegistrationScore > 3)
                {
                    throw new System.ArgumentException("RegistrationScore must be between 0 and 3.");
                }
                
                if(command.AttentionAndCalculationScore<0 || command.AttentionAndCalculationScore > 5)
                {
                    throw new System.ArgumentException("AttentionAndCalculationScore must be between 0 and 5.");
                }
                
                if(command.RecallScore<0 || command.RecallScore > 3)
                {
                    throw new System.ArgumentException("RecallScore must be between 0 and 3.");
                }

                if (command.LanguageScore < 0 || command.LanguageScore > 9)
                {
                    throw new System.ArgumentException("LanguageScore must be between 0 and 9.");
                }
                
                try
                {
                    Guid uuid;
                    if (Guid.TryParse(command.ExaminerNationalProviderIdentifier, out uuid))
                    {
                        // Verificar si es un UUID versión 4
                        var regex = new Regex(@"^[0-9a-f]{8}-[0-9a-f]{4}-4[0-9a-f]{3}-[89ab][0-9a-f]{3}-[0-9a-f]{12}$", RegexOptions.IgnoreCase);
                        if (!regex.IsMatch(command.ExaminerNationalProviderIdentifier))
                        {
                            throw new System.ArgumentException("ExaminerNationalProviderIdentifier must be a version 4 UUID.");
                        }
                    }
                    else
                    {
                        throw new System.ArgumentException("ExaminerNationalProviderIdentifier must be a valid UUID.");
                    }
                }
                catch (ArgumentException e)
                {
                    throw new Exception(e.Message);
                }
            
                var mentalStateExam = new MentalStateExam(command,examiner.Id,examiner);
                await mentalStateExamRepository.AddAsync(mentalStateExam);
                await unitOfWork.CompleteAsync();
                return mentalStateExam;
            }catch(ArgumentException e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}