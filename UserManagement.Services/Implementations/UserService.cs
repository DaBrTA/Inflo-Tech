using System.Collections.Generic;
using System.Linq;
using UserManagement.Data;
using UserManagement.Models;
using UserManagement.Services.Domain.Interfaces;
namespace UserManagement.Services.Domain.Implementations;

public class UserService : IUserService
{
    private readonly IDataContext _dataAccess;
    public UserService(IDataContext dataAccess) => _dataAccess = dataAccess;

    public IEnumerable<User> FilterByActive(bool isActive)
    {
        var users = _dataAccess.GetAll<User>();

        if (isActive)
        {
            return users.Where(users => users.IsActive == true).ToList();
        }

        if (!isActive)
        {
            return users.Where(users => users.IsActive == false).ToList();
        }

        return users;
    }

    public IEnumerable<User> GetAll() => _dataAccess.GetAll<User>();

    public int CreateUser(string Forename, string Surname, string DateOfBirth, string Email, bool IsActive)
    {
        var user = new User
        {
            Forename = Forename,
            Surname = Surname,
            DateOfBirth = DateOfBirth,
            Email = Email,
            IsActive = IsActive
        };
        var id = _dataAccess.Create(user).Id;

        return id;
    }

    public User? ViewUser(int id)
    {
        var user = _dataAccess.GetSingle<User>(id);
        return user;
    }

    public void DeleteUser(int Id, string Forename, string Surname, string DateOfBirth, string Email, bool IsActive)
    {
        var user = new User
        {
            Id = Id,
            Forename = Forename,
            Surname = Surname,
            DateOfBirth = DateOfBirth,
            Email = Email,
            IsActive = IsActive
        };

        _dataAccess.Delete<User>(user);
    }

    public void EditUser(int Id, string Forename, string Surname, string DateOfBirth, string Email, bool IsActive)
    {
        var user = new User
        {
            Id = Id,
            Forename = Forename,
            Surname = Surname,
            DateOfBirth = DateOfBirth,
            Email = Email,
            IsActive = IsActive
        };

        _dataAccess.Edit<User>(user);
    }
}
