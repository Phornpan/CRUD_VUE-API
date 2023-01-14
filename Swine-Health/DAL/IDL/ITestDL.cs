using Test_SEC_P.Models;

namespace Test_SEC_P.DAL.IDL
{
    public interface ITestDL
    {
        Task<List<TestModel>> GetAllTestDL();
        Task<TestModel> GetTestByCodeDL(int EmployeeID);
        Task<int> CreateTestDL(TestModel data, string Username);
        Task<int> UpdateTestDL(TestModel data, string Username);
        Task<int> DeleteTestDL(int EmployeeID, string UpdateBy);
    }
}
