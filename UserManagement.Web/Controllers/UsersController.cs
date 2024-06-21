using System;
using System.Linq;
using UserManagement.Services.Domain.Interfaces;
using UserManagement.Web.Models.Users;

namespace UserManagement.WebMS.Controllers;

//[Route("users")]
public class UsersController : Controller
{
    private readonly IUserService _userService;
    private readonly ILogService _logService;
    public UsersController(IUserService userService, ILogService logService)
    {
        _userService = userService;
        _logService = logService;
    }

    [HttpGet]
    public ActionResult Index(string? Filter)
    {
        IEnumerable<UserListItemViewModel> items;

        if (Filter is not null)
        {
            bool isActive = Filter == "IsActive" ? true : false;

            items = _userService.FilterByActive(isActive).Select(p => new UserListItemViewModel
            {
                Id = p.Id,
                Forename = p.Forename,
                Surname = p.Surname,
                Email = p.Email,
                IsActive = p.IsActive,
                DateOfBirth = p.DateOfBirth
            });
        }
        else
        {
            items = _userService.GetAll().Select(p => new UserListItemViewModel
            {
                Id = p.Id,
                Forename = p.Forename,
                Surname = p.Surname,
                Email = p.Email,
                IsActive = p.IsActive,
                DateOfBirth = p.DateOfBirth
            });
        }

        var model = new UserListViewModel
        {
            Items = items.ToList()
        };

        return View(model);
    }

    [HttpGet("/AddUser")]
    public ActionResult AddUser() => View();

    [HttpPost("/AddUser")]
    public ActionResult AddUser(CreateUser model)
    {
        if (!ModelState.IsValid)
        {
            return RedirectToAction("Index");
        }

        var id = _userService.CreateUser(model.Forename, model.Surname, model.DateOfBirth, model.Email, true);

        var log = new CreateLog
        {
            UserId = id,
            LogType = "Create",
            LogMessage = $"User {id} created at {DateTime.Now}"
        };

        _logService.AddLog(log.UserId, log.LogType, log.LogMessage);

        return RedirectToAction("Index");
    }

    [HttpGet("/ViewUser/{Id}")]
    public ActionResult ViewUser(int id)
    {
        var user = _userService.ViewUser(id);
        var logs = _logService.GetUserLogs(id);

        var logList = new List<LogListItemViewModel>();

        foreach (var log in logs) {
            var item = new LogListItemViewModel
            {
                Id = log.Id,
                UserId = log.UserId,
                LogType = log.LogType,
                LogMessage = log.LogMessage
            };

            logList.Add(item);
        }

        if (user != null)
        {
            var model = new ViewUser
            {
                Id = user.Id,
                Forename = user.Forename,
                Surname = user.Surname,
                Email = user.Email,
                IsActive = user.IsActive,
                DateOfBirth = user.DateOfBirth,
                LogList = logList
            };
            return View(model);
        }

        return RedirectToAction("Index");
    }

    [HttpGet("/DeleteUser/{Id}")]
    public ActionResult DeleteUser(int id)
    {
        var user = _userService.ViewUser(id);

        if (user != null)
        {
            var model = new ViewUser
            {
                Id = user.Id,
                Forename = user.Forename,
                Surname = user.Surname,
                Email = user.Email,
                IsActive = user.IsActive,
                DateOfBirth = user.DateOfBirth
            };
            return View(model);
        }
        return RedirectToAction("Index");
    }

    [HttpPost("/DeleteUser/{Id}")]
    public ActionResult DeleteUser(ViewUser model)
    {
        _userService.DeleteUser(model.Id, model.Forename, model.Surname, model.DateOfBirth, model.Email, model.IsActive);

        var log = new CreateLog
        {
            UserId = model.Id,
            LogType = "Delete",
            LogMessage = $"User {model.Id} deleted at {DateTime.Now}"
        };

        _logService.AddLog(log.UserId, log.LogType, log.LogMessage);

        return RedirectToAction("Index");
    }

    [HttpGet("/EditUser/{Id}")]
    public ActionResult EditUser(int id)
    {
        var user = _userService.ViewUser(id);

        if (user != null)
        {
            var model = new ViewUser
            {
                Id = user.Id,
                Forename = user.Forename,
                Surname = user.Surname,
                Email = user.Email,
                IsActive = user.IsActive,
                DateOfBirth = user.DateOfBirth
            };
            return View(model);
        }
        return RedirectToAction("Index");
    }

    [HttpPost("/EditUser/{Id}")]
    public ActionResult EditUser(ViewUser model)
    {
        if (!ModelState.IsValid)
        {
            return RedirectToAction("Index");
        }

        var id = model.Id;

        _userService.EditUser(model.Id, model.Forename, model.Surname, model.DateOfBirth, model.Email, model.IsActive);

        var log = new CreateLog
        {
            UserId = id,
            LogType = "Edit",
            LogMessage = $"User {model.Id} edited at {DateTime.Now}"
        };

        _logService.AddLog(log.UserId, log.LogType, log.LogMessage);

        return RedirectToAction("Index");
    }


}
