using System.Linq;
using UserManagement.Services.Domain.Interfaces;
using UserManagement.Web.Models.Users;

namespace UserManagement.Web.Controllers;
public class LogsController : Controller
{
    private readonly ILogService _logService;
    public LogsController( ILogService logService)
    {
        _logService = logService;
    }
    public IActionResult Index()
    {
        var logList = _logService.GetAll().Select(l => new LogListItemViewModel
        {
            Id = l.Id,
            UserId = l.UserId,
            LogType = l.LogType,
            LogMessage = l.LogMessage
        });

        var model = new LogListViewModel
        {
            LogList = logList
        };
        return View(model);
    }
}
