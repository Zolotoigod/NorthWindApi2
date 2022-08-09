using NorthWindApi2.DTO;
using NorthWindEFRepository.Repositories;

namespace NorthWindApi2.Services
{
    /// <summary>
    /// Represents a management service for employees.
    /// </summary>
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository repository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            repository = employeeRepository;
        }

        /// <inheritdoc/>
        public async Task<int> Add(EmployeeRequest employee)
        {
            byte[] photo = new byte[10]; // get from repo
            return await repository.Add(employee.ToEntity(photo));
        }

        /// <inheritdoc/>
        public async Task Delete(int employeeId)
        {
            await repository.Remove(employeeId);
        }

        /// <inheritdoc/>
        public async Task<EmployeeResponse> Get(int employeeId)
        {
            return new EmployeeResponse(await repository.GetById(employeeId));
        }

        /// <inheritdoc/>
        public async IAsyncEnumerable<EmployeeResponse> GetCollection(int offset, int limit)
        {
            await foreach(var employee in repository.GetCollection(offset, limit))
            {
                yield return new EmployeeResponse(employee);
            }
        }

        /// <inheritdoc/>
        public async Task<int> GetCount()
        {
            return await repository.GetCount();
        }

        /// <inheritdoc/>
        public async Task Update(int employeeId, EmployeeRequest employee)
        {
            await repository.Update(employeeId, employee.ToEntity(new byte[10]));
        }
    }
}
