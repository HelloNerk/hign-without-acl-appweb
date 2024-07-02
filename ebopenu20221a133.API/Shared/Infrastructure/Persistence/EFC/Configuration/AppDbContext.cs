using ebopenu20221a133.API.assessment.Domain.Model.Aggregates;
using ebopenu20221a133.API.personnel.Domain.Model.Aggregates;
using ebopenu20221a133.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;


namespace ebopenu20221a133.API.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
        // Enable Audit Fields Interceptors
        builder.AddCreatedUpdatedInterceptor();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<Examiner>().ToTable("examiners");
        builder.Entity<Examiner>().HasKey(p=>p.Id);
        builder.Entity<Examiner>().Property(p=>p.Id).ValueGeneratedOnAdd();
        builder.Entity<Examiner>().Property(p=>p.FirstName).IsRequired();
        builder.Entity<Examiner>().Property(p=>p.LastName).IsRequired();
        builder.Entity<Examiner>().Property(p=>p.NationalProviderIdentifier).IsRequired();
        
        builder.Entity<MentalStateExam>().ToTable("mental_state_exams");
        builder.Entity<MentalStateExam>().HasKey(p=>p.Id);
        builder.Entity<MentalStateExam>().Property(p=>p.Id).ValueGeneratedOnAdd();
        builder.Entity<MentalStateExam>().Property(p=>p.PatientId).IsRequired();
        builder.Entity<MentalStateExam>().Property(p=>p.ExaminerNationalProviderIdentifier).IsRequired();
        builder.Entity<MentalStateExam>().Property(p=>p.ExamDate).IsRequired();
        builder.Entity<MentalStateExam>().Property(p=>p.OrientationScore).IsRequired();
        builder.Entity<MentalStateExam>().Property(p=>p.RegistrationScore).IsRequired();
        builder.Entity<MentalStateExam>().Property(p=>p.AttentionAndCalculationScore).IsRequired();
        builder.Entity<MentalStateExam>().Property(p=>p.RecallScore).IsRequired();
        builder.Entity<MentalStateExam>().Property(p=>p.LanguageScore).IsRequired();

        //realtionship
        builder.Entity<Examiner>()
            .HasMany(e => e.MentalStateExams)
            .WithOne(e => e.Examiner)
            .HasForeignKey(e => e.ExaminerId);
        
        // Apply SnakeCase Naming Convention
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}