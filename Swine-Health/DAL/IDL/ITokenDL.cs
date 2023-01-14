namespace Test_SEC_P.DAL.IDL
{
    public interface ITokenDL
    {
        Task<int> SaveTokenDL(string Token, string Username);
        void DeleteTokenDL(string Username);
    }
}
