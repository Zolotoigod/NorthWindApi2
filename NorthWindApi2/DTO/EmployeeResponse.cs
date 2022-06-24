namespace NorthWindApi2.DTO
{
    public class EmployeeResponse : EmployeeRequest
    {
        public int EmployeeId { get; set; }

        public DateTime? HireDate { get; set; }
    }
}
