using NorthWindEFRepository.Entities;

namespace NorthWindEFRepository.Repositories
{
    public interface IEmployeeRepository
    {
        Task<int> Add(Employee category);
        Task<Employee> GetById(int categoryId);
        IAsyncEnumerable<Employee> GetCollection(int offset, int limit);
        Task Remove(int categoryId);
        Task Update(int categoryId, Employee newCategory);
        Task<int> GetCount();
    }
}