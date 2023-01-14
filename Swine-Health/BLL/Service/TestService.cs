using Microsoft.Extensions.Options;
using Test_SEC_P.BLL.IService;
using Test_SEC_P.DAL.IDL;
using Test_SEC_P.Models;
using System.Drawing;
using Test_SEC_P.Models;
using Test_SEC_P.Helper;

namespace Test_SEC_P.BLL.Service
{
    public class TestService : ITestService
    {
        private readonly ITestDL _iTestDL;
        public TestService(ITestDL iTestDL)
        {
            _iTestDL = iTestDL;
        }

        public async Task<MessageResponseModel> GetAllTestService()
        {
            string methodName = Util.GetMethodName();
            MessageResponseModel meg_res = new MessageResponseModel();
            try
            {
                var res = await _iTestDL.GetAllTestDL();

                meg_res.Success = true;
                meg_res.Message = "Success";
                meg_res.Data = res;

                return meg_res;
            }
            catch (Exception ex)
            {
                meg_res.Message = ex.Message + " - " + ex.StackTrace;
                return meg_res;
            }
        }
        public async Task<MessageResponseModel> GetTestByCodeService(int EmployeeID)
        {
            MessageResponseModel meg_res = new MessageResponseModel();
            try
            {
                var res = await _iTestDL.GetTestByCodeDL(EmployeeID);

                meg_res.Success = true;
                meg_res.Message = "Success";
                meg_res.Data = res;

                return meg_res;
            }
            catch (Exception ex)
            {
                meg_res.Message = ex.Message + " - " + ex.StackTrace;
                return meg_res;
            }
        }
        public async Task<MessageResponseModel> CreateTestService(TestModel data, string Username)
        {
            string methodName = Util.GetMethodName();
            MessageResponseModel meg_res = new MessageResponseModel();
            try
            {

                var res = await _iTestDL.CreateTestDL(data, Username);

                meg_res.Success = true;
                meg_res.Message = "Success";
                meg_res.Data = res;
                return meg_res;
            }
            catch (Exception ex)
            {
                meg_res.Message = ex.Message + " - " + ex.StackTrace;
                return meg_res;
            }
        }
        public async Task<MessageResponseModel> UpdateTestService(TestModel data, string Username)
        {
            string methodName = Util.GetMethodName();
            MessageResponseModel meg_res = new MessageResponseModel();
            try
            {
                var res = await _iTestDL.UpdateTestDL(data, Username);

                meg_res.Success = true;
                meg_res.Message = "Success";
                meg_res.Data = res;

                return meg_res;
            }
            catch (Exception ex)
            {
                meg_res.Message = ex.Message + " - " + ex.StackTrace;
                return meg_res;
            }
        }
       public async Task<MessageResponseModel> DeleteTestByCodeService(int EmployeeID, string Username)
        {
            string methodName = Util.GetMethodName();
            MessageResponseModel meg_res = new MessageResponseModel();
            try
            {
                var res = await _iTestDL.DeleteTestDL(EmployeeID, Username);
                meg_res.Data = res;

                meg_res.Success = true;
                meg_res.Message = "Success";


                return meg_res;
            }
            catch (Exception ex)
            {
                meg_res.Message = ex.Message + " - " + ex.StackTrace;
                return meg_res;
            }
        }
    }
}
