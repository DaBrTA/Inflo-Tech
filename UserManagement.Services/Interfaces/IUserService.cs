using System.Collections.Generic;
using UserManagement.Models;

namespace UserManagement.Services.Domain.Interfaces;

public interface IUserService 
{

    IEnumerable<User> FilterByActive(bool isActive);
    IEnumerable<User> GetAll();

    int CreateUser(string Forename, string Surname, string DateOfBirth, string Email, bool IsActive);

    User? ViewUser(int id);

    void DeleteUser(int Id, string Forename, string Surname, string DateOfBirth, string Email, bool IsActive);

    void EditUser(int Id, string Forename, string Surname, string DateOfBirth, string Email, bool IsActive);
}
