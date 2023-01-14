using Dapper;
using Test_SEC_P.DAL.IDL;
using Test_SEC_P.Models;
using System.Data;
using Test_SEC_P.Helper;

namespace Test_SEC_P.DAL.DL
{
    public class TestDL : ITestDL
    {
        private readonly IDapperDL _iDapperDL;
        public TestDL(IDapperDL iDapperDL)
        {
            _iDapperDL = iDapperDL;
        }

        public async Task<List<TestModel>> GetAllTestDL()
        {
            try
            {
                var query = @"select * from Test where IsActive = 'true'";

                query = Util.InjectionClear(query);
                var result = await Task.FromResult(_iDapperDL.GetAll<TestModel>(query, null, commandType: CommandType.Text).ToList());

                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<TestModel> GetTestByCodeDL(int EmployeeID)
        {
            try
            {
                var query = @"SELECT * FROM Test WHERE EmployeeID = @EmployeeID";

                query = Util.InjectionClear(query);
                var parameters = new DynamicParameters();
                parameters.Add("EmployeeID", EmployeeID, DbType.Int32);
                var result = await Task.FromResult(_iDapperDL.Get<TestModel>(query, parameters, commandType: CommandType.Text));

                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<int> CreateTestDL(TestModel data, string UpdateBy)
        {
            try
            {
                var query = @"INSERT INTO Test (
                                                Name
                                                ,Surname
                                                ,Age
                                                ,Address
                                                ,PhoneNo
                                                ,Email
                                                ,IsActive
                                              )
                                        VALUES(
                                                @Name
                                                ,@Surname
                                                ,@Age
                                                ,@Address
                                                ,@PhoneNo
                                                ,@Email
                                                ,@IsActive
                                             )";

                query = Util.InjectionClear(query);
                var parameters = new DynamicParameters();
                parameters.Add("Name", data.Name, DbType.String);
                parameters.Add("Surname", data.Surname, DbType.String);
                parameters.Add("Age", data.Age, DbType.Int32);
                parameters.Add("Address", data.Address, DbType.String);
                parameters.Add("PhoneNo", data.PhoneNo, DbType.String);
                parameters.Add("Email", data.Email, DbType.String);
                parameters.Add("IsActive", true, DbType.Boolean);
                var result = await Task.FromResult(_iDapperDL.Update<int>(query, parameters, commandType: CommandType.Text));

                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<int> UpdateTestDL(TestModel data, string UpdateBy)
        {
            try
            {
                var query = @"UPDATE Test 
                            SET Name = @Name
                            ,Surname = @Surname
                            ,Address = @Address
                            ,PhoneNo = @PhoneNo
                            ,Email = @Email
                            WHERE EmployeeID = @EmployeeID";

                query = Util.InjectionClear(query);
                var parameters = new DynamicParameters();
                parameters.Add("EmployeeID", data.EmployeeID, DbType.Int32);
                parameters.Add("Name", data.Name, DbType.String);
                parameters.Add("Surname", data.Surname, DbType.String);
                parameters.Add("Address", data.Address, DbType.String);
                parameters.Add("PhoneNo", data.PhoneNo, DbType.String);
                parameters.Add("Email", data.Email, DbType.String);
                var result = await Task.FromResult(_iDapperDL.Update<int>(query, parameters, commandType: CommandType.Text));

                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<int> DeleteTestDL(int EmployeeID, string UpdateBy)
        {
            try
            {
                var query = @"UPDATE Test 
                            SET IsActive = @IsActive
                            WHERE EmployeeID = @EmployeeID";

                query = Util.InjectionClear(query);
                var parameters = new DynamicParameters();
                parameters.Add("IsActive", false, DbType.Boolean);
                parameters.Add("EmployeeID", EmployeeID, DbType.String);
                var result = await Task.FromResult(_iDapperDL.Update<int>(query, parameters, commandType: CommandType.Text));

                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
