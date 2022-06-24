using Microsoft.AspNetCore.Mvc;
using NorthWindApi2.DTO;
using NorthWindApi2.Services;

namespace NorthWindApi2.Controllers
{
    [ApiController]
    [Route("api/employees")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService service;

        public EmployeeController(IEmployeeService service)
        {
            this.service = service;
        }

        [HttpPost]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MyErrorMessage), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(EmployeeRequest employee)
        {
            try
            {
                var id = await this.service.Add(employee);
                return this.Ok(id);
            }
            catch (Exception)
            {
                return BadRequest(); // add handler
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IAsyncEnumerable<EmployeeResponse>), StatusCodes.Status200OK)]
        public async IAsyncEnumerable<EmployeeResponse> GetCollecttion(int offset, int limit)
        {
            var employeeCount = await this.service.GetCount();
            Response.Headers.Add(Defines.Total, employeeCount.ToString());
            await foreach (var employee in this.service.GetCollection(offset, limit))
            {
                yield return employee;
            }
        }

        [HttpGet("{employeeId}")]
        [ProducesResponseType(typeof(EmployeeResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MyErrorMessage), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get([FromRoute] int employeeId)
        {
            try
            {
                return this.Ok(await this.service.Get(employeeId));
            }
            catch (Exception)
            {
                return BadRequest(); // add handler
            }
        }

        [HttpPut("{employeeId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MyErrorMessage), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update([FromRoute] int employeeId, [FromBody] EmployeeRequest request)
        {
            try
            {
                await this.service.Update(employeeId, request);
                return this.Ok();
            }
            catch (Exception)
            {
                return BadRequest(); // add handler
            }
        }

        [HttpDelete("{employeeId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MyErrorMessage), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete([FromRoute] int employeeId)
        {
            try
            {
                await this.service.Delete(employeeId);
                return this.Ok();
            }
            catch (Exception)
            {
                return BadRequest(); // add handler
            }
        }
    }
}
