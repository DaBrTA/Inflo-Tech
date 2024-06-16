using System.Linq;
using System.Threading.Tasks;
using UserManagement.Services.Domain.Interfaces;
using UserManagement.Web.Models.Users;

namespace UserManagement.WebMS.Controllers;

[Route("users")]
public class UsersController : Controller
{
    private readonly IUserService _userService;
    public UsersController(IUserService userService) => _userService = userService;

    [HttpGet]
    public IActionResult List(string id)
    {
        var items = _userService.GetAll().Select(p => new UserListItemViewModel
        {
            Id = p.Id,
            Forename = p.Forename,
            Surname = p.Surname,
            Email = p.Email,
            IsActive = p.IsActive
        });

        var model = new UserListViewModel
        {
            Items = items.ToList()
        };

        if (id == "IsActive")
        {
            model = new UserListViewModel
            {
                Items = items.Where(a => a.IsActive == true).ToList()
            };
        }

        if (id == "NotActive")
        {
            model = new UserListViewModel
            {
                Items = items.Where(a => a.IsActive == false).ToList()
            };
        }

        return View(model);
    }
}
