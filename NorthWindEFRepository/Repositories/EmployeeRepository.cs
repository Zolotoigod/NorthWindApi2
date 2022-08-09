using Microsoft.EntityFrameworkCore;
using NorthWindEFRepository.Contexts;
using NorthWindEFRepository.Entities;

namespace NorthWindEFRepository.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly NorthWindContext context;

        public EmployeeRepository(NorthWindContext context)
        {
            this.context = context;
        }

        public async Task<int> Add(Employee employee)
        {
            await context.Employees!.AddAsync(employee);
            context.SaveChanges();
            return employee.Id;
        }

        public async Task<Employee> GetById(int employeeId)
        {
            return await context.Employees!.FindAsync(employeeId)
                ?? throw new KeyNotFoundException(string.Format(
                    Defines.ErrorMesage.ItemNotFoundTemplate,
                    Defines.EntityNames.Employee,
                    employeeId));
        }

        public async IAsyncEnumerable<Employee> GetCollection(int offset, int limit)
        {
            var query = context.Employees!.Skip(offset).Take(limit).AsAsyncEnumerable();
            await foreach (var employee in query)
            {
                yield return employee;
            }
        }

        public async Task<int> GetCount()=> await context.Employees!.CountAsync();

        public async Task Remove(int employeeId)
        {
            var employee = await context.Employees!.FindAsync(employeeId)
                ?? throw new KeyNotFoundException(string.Format(
                    Defines.ErrorMesage.ItemNotFoundTemplate,
                    Defines.EntityNames.Employee,
                    employeeId));
            context.Remove(employee);

            await context.SaveChangesAsync();
        }

        public async Task Update(int employeeId, Employee newEmployee)
        {
            var employee = await context.Employees!.FindAsync(employeeId)
                ?? throw new KeyNotFoundException(string.Format(
                    Defines.ErrorMesage.ItemNotFoundTemplate,
                    Defines.EntityNames.Product,
                    employeeId));

            UpdateDate(employee, newEmployee);

            await context.SaveChangesAsync();
        }

        private void UpdateDate(Employee oldE, Employee newE)
        {
            oldE.LastName = newE.LastName;
            oldE.FirstName = newE.FirstName;
            oldE.BirthDate = newE.BirthDate;
            oldE.HireDate = newE.HireDate;
            oldE.Title = newE.Title;
            oldE.TitleOfCourtesy = newE.TitleOfCourtesy;
            oldE.Address = newE.Address;
            oldE.City = newE.City;
            oldE.Region = newE.Region;
            oldE.Country = newE.Country;
            oldE.HomePhone = newE.HomePhone;
            oldE.PostalCode = newE.PostalCode;
            oldE.Photo = newE.Photo;
        }
    }
}
