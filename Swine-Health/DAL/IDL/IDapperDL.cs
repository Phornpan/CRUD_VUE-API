using Dapper;
using System.Data.Common;
using System.Data;

namespace Test_SEC_P.DAL.IDL
{
    public interface IDapperDL: IDisposable
    {
        DbConnection GetDbconnection();
        T Get<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.Text);
        List<T> GetAll<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.Text);
        int Execute(string sp, DynamicParameters parms, CommandType commandType = CommandType.Text);
        T Insert<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.Text);
        T Update<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.Text);
        //T ExcuteDatabase<T>(List<DapperModel> sp);
    }
}
