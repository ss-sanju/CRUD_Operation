using CRUD.Models;

namespace CRUD.Generic;

public interface IUnitOfWork : IDisposable
{
    IRepository<Employee> EmployeeRepository { get; }
    Task SaveAsync();
}
