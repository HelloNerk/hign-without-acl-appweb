using System.Text.RegularExpressions;
using ebopenu20221a133.API.personnel.Domain.Model.Aggregates;
using ebopenu20221a133.API.personnel.Domain.Model.Commands;
using ebopenu20221a133.API.personnel.Domain.Repositories;
using ebopenu20221a133.API.personnel.Domain.Services;
using ebopenu20221a133.API.Shared.Domain.Repositories;

namespace ebopenu20221a133.API.personnel.Application.Internal.CommandServices
{

    public class ExaminerCommandService : IExaminerCommandService
    {
        private readonly IExaminerRepository examinerRepository;
        private readonly IUnitOfWork unitOfWork;
        
        public ExaminerCommandService(IExaminerRepository examinerRepository, IUnitOfWork unitOfWork)
        {
            this.examinerRepository = examinerRepository ?? throw new System.ArgumentNullException(nameof(examinerRepository));
            this.unitOfWork = unitOfWork ?? throw new System.ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<Examiner?> Handle(CreateExaminerCommand command)
        {
            try
            {
                var existingExaminerWithNPI =
                    await examinerRepository.FindByNationalProviderIdentifierAsync(command.NationalProviderIdentifier);
                if (existingExaminerWithNPI != null)
                {
                    throw new System.ArgumentException(
                        "An examiner with the same NationalProviderIdentifier already exists.");
                }

                if (command.NationalProviderIdentifier.Length != 36)
                {
                    throw new System.ArgumentException("NationalProviderIdentifier must be 36 characters long.");
                }

                try
                {
                    Guid uuid;
                    if (Guid.TryParse(command.NationalProviderIdentifier, out uuid))
                    {
                        // Verificar si es un UUID versión 4
                        var regex = new Regex(@"^[0-9a-f]{8}-[0-9a-f]{4}-4[0-9a-f]{3}-[89ab][0-9a-f]{3}-[0-9a-f]{12}$", RegexOptions.IgnoreCase);
                        if (!regex.IsMatch(command.NationalProviderIdentifier))
                        {
                            throw new System.ArgumentException("NationalProviderIdentifier must be a version 4 UUID.");
                        }
                    }
                    else
                    {
                        throw new System.ArgumentException("NationalProviderIdentifier must be a valid UUID.");
                    }
                }
                catch (ArgumentException e)
                {
                    throw new Exception(e.Message);
                }
                
                var examiner = new Examiner(command);
                await examinerRepository.AddAsync(examiner);
                await unitOfWork.CompleteAsync();
                return examiner;
            }
            catch (ArgumentException e)
            {
                throw new Exception(e.Message);
            }
        }
    }

}