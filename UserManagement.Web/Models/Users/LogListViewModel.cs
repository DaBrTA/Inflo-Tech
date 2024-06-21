namespace UserManagement.Web.Models.Users;

public class LogListViewModel
{
    public IEnumerable<LogListItemViewModel> LogList { get; set; } = new List<LogListItemViewModel>();
}

public class LogListItemViewModel
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string? LogType { get; set; }
    public string? LogMessage { get; set; }
}


