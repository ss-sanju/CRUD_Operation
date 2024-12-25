using CRUD.Data;
using CRUD.Models;
using System;

namespace CRUD.Generic;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        EmployeeRepository = new Repository<Employee>(_context);
    }

    public IRepository<Employee> EmployeeRepository { get; private set; }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
