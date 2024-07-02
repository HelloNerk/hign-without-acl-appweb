using System.ComponentModel.DataAnnotations;
using ebopenu20221a133.API.assessment.Domain.Model.Aggregates;
using ebopenu20221a133.API.personnel.Domain.Model.Commands;

namespace ebopenu20221a133.API.personnel.Domain.Model.Aggregates
{
    public partial class Examiner
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }
        
        [Required]
        public string NationalProviderIdentifier { get; set; }
        
        public ICollection<MentalStateExam> MentalStateExams { get; set; } = new List<MentalStateExam>();
        
        public Examiner()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            NationalProviderIdentifier = string.Empty;
        }
        
        public Examiner(string firstName, string lastName, string nationalProviderIdentifier)
        {
            FirstName = firstName;
            LastName = lastName;
            NationalProviderIdentifier = nationalProviderIdentifier;
        }

        public Examiner(CreateExaminerCommand command)
        {
            FirstName = command.FirstName;
            LastName = command.LastName;
            NationalProviderIdentifier = command.NationalProviderIdentifier;
        }
    }
}

