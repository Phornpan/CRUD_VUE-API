using Dapper;
using Test_SEC_P.DAL.IDL;
using Test_SEC_P.Helper;
using System.Data;
using System.Reflection;

namespace Test_SEC_P.DAL.DL
{
    public class TokenDL : ITokenDL
    {
        private readonly IDapperDL _iDapperDL;
        public TokenDL(IDapperDL iDapperDL)
        {
            _iDapperDL = iDapperDL;
        }
        public async Task<int> SaveTokenDL(string Token, string Username)
        {
            try
            {
                var query = @"INSERT INTO T_Token(Username,Token) VALUES(@Username,@Token)";

                //query = Util.InjectionClear(query);
                DynamicParameters param = new DynamicParameters();
                param.Add("Username", Username);
                param.Add("Token", Token);
                var result = await Task.FromResult(_iDapperDL.Insert<int>(query, param, commandType: CommandType.Text));

                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async void DeleteTokenDL(string Username)
        {
            try
            {
                var query = @"DELETE FROM T_Token WHERE Username = @Username";

                query = Util.InjectionClear(query);
                var parameters = new DynamicParameters();
                parameters.Add("Username", Username, DbType.String);
                var result = await Task.FromResult(_iDapperDL.Update<int>(query, parameters, commandType: CommandType.Text));

                //return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
