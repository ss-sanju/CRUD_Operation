using CRUD.Generic;
using CRUD.Models;

namespace CRUD.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IUnitOfWork _unitOfWork;

    public EmployeeService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
    {
        return await _unitOfWork.EmployeeRepository.GetAllAsync();
    }

    public async Task<Employee> GetEmployeeByIdAsync(Guid id)
    {
        return await _unitOfWork.EmployeeRepository.GetByIdAsync(id);
    }

    public async Task AddEmployeeAsync(Employee employee)
    {
        await _unitOfWork.EmployeeRepository.AddAsync(employee);
        await _unitOfWork.SaveAsync();
    }

    public async Task UpdateEmployeeAsync(Employee employee)
    {
        await _unitOfWork.EmployeeRepository.UpdateAsync(employee);
        await _unitOfWork.SaveAsync();
    }

    public async Task DeleteEmployeeAsync(Guid id)
    {
        await _unitOfWork.EmployeeRepository.DeleteAsync(id);
        await _unitOfWork.SaveAsync();
    }
}
