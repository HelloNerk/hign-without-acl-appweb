namespace ebopenu20221a133.API.personnel.Domain.Model.Commands;

public record CreateExaminerCommand(
    string FirstName,
    string LastName,
    string NationalProviderIdentifier
);