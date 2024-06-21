namespace UserManagement.Web.Models.Users;

public class CreateLog
{
    public int UserId { get; set; }
    public string LogType { get; set; } = string.Empty;
    public string LogMessage { get; set; } = string.Empty;

}
