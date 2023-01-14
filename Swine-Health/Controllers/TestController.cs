using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Test_SEC_P.BLL.IService;
using Test_SEC_P.Models;

namespace Test_SEC_P.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        public readonly ITestService _service;
        public TestController(ITestService service)
        {
            _service = service;
        }

        [HttpGet("GetAll")]
        public async Task<MessageResponseModel> GetAll()
        {
            var result = await _service.GetAllTestService();
            return result;
        }

        [HttpGet("GetByCode")]
        public async Task<MessageResponseModel> GetByCode(int EmployeeID)
        {
            var result = await _service.GetTestByCodeService(EmployeeID);
            return result;
        }

        [HttpPost("Create")]
        public async Task<MessageResponseModel> Create([FromBody] TestModel data,string username)
        {
            var result = await _service.CreateTestService(data, username);
            return result;
        }

        [HttpPut("Update")]
        public async Task<MessageResponseModel> Update([FromBody] TestModel data, string username)
        {
            var result = await _service.UpdateTestService(data, username);
            return result;
        }


        [HttpDelete("Delete")]
        public async Task<MessageResponseModel> Delete([FromQuery] int EmployeeID, string username)
        {
            var result = await _service.DeleteTestByCodeService(EmployeeID, username);
            return result;
        }

    }
}
