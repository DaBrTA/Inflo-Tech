using System.Collections.Generic;
using UserManagement.Models;

namespace UserManagement.Services.Domain.Interfaces;

public interface ILogService 
{
    void AddLog(int userId, string logType, string logMessage);
    IEnumerable<Log> GetAll();
    IEnumerable<Log> GetUserLogs(int Id);
}
