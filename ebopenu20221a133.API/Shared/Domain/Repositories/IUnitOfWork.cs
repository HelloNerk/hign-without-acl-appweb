namespace ebopenu20221a133.API.Shared.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}