using NorthWindEFRepository.Entities;

namespace NorthWindApi2.DTO
{
    public class EmployeeResponse : EmployeeRequest
    {
        public EmployeeResponse(Employee employee)
        {
            EmployeeId = employee.Id;
            HireDate = employee.HireDate;
            FirstName = employee.FirstName;
            LastName = employee.LastName;
            Title = employee.Title;
            BirthDate = employee.BirthDate;
            Address = employee.Address;
            City = employee.City;
            Region = employee.Region;
            Country = employee.Country;
            HomePhone = employee.HomePhone;
        }

        public int EmployeeId { get; set; }

        public DateTime? HireDate { get; set; }
    }
}
