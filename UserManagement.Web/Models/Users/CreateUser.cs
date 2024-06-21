namespace UserManagement.Web.Models.Users;

public class CreateUser
{
    public string Forename { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public string DateOfBirth { get; set; } = string.Empty;
}
