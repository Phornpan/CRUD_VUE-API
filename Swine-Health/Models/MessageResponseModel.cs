namespace Test_SEC_P.Models
{
    public class MessageResponseModel
    {
        public bool Success { get; set; } = false;
        public string Message { get; set; }
        public object Data { get; set; } = null;
    }
}
