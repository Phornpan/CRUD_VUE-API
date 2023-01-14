using Test_SEC_P.Models;

namespace Test_SEC_P.BLL.IService
{
    public interface ITestService
    {
        Task<MessageResponseModel> GetAllTestService();
        Task<MessageResponseModel> GetTestByCodeService(int EmployeeID);
        Task<MessageResponseModel> CreateTestService(TestModel data, string Username);
        Task<MessageResponseModel> UpdateTestService(TestModel data, string Username);
        Task<MessageResponseModel> DeleteTestByCodeService(int EmployeeID, string Username);
    }
}
