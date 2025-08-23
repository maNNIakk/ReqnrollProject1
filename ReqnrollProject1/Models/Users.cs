namespace ReqnrollProject1.Models
{
    public class Users
    {
        public string? UserName { get; set; }
        public InternalUserType UserType { get; set; }
    }

    public class InternalUserTypeContext
    {
        public List<Users> Users { get; set; }
    }

    public enum InternalUserType
    {   Unknown,
        Admin,
        User,
        Guest
    }
}
