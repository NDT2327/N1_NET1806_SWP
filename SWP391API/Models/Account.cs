namespace SWP391API.Models
{
    public class Account
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsAdmin { get; set; }
        public int RoleID { get; set; }

        // Constructor
        public Account(int userId, string username, string password, string email, string phone, bool isAdmin, int roleId)
        {
            UserID = userId;
            Username = username;
            Password = password;
            Email = email;
            Phone = phone;
            IsAdmin = isAdmin;
            RoleID = roleId;
        }

        // Overriding ToString method for better readability
        public override string ToString()
        {
            return $"UserID: {UserID}, Username: {Username}, Email: {Email}, Phone: {Phone}, IsAdmin: {IsAdmin}, RoleID: {RoleID}";
        }
    }

}
