using Test_SEC_P.Models;

namespace Test_SEC_P.Models
{
    public class TestModel
    {
        public int EmployeeID { get; set; }
        public string? Name { get; set; } = "";
        public string? Surname { get; set; } = "";
        public int? Age { get; set; }
        public string? Address { get; set; } = "";
        public string? PhoneNo { get; set; } = "";
        public string? Email { get; set; } = "";
        public bool? IsActive { get; set; }
    }
}
