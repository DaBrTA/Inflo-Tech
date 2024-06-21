using System.Collections.Generic;
using System.Linq;
using UserManagement.Data;
using UserManagement.Models;
using UserManagement.Services.Domain.Interfaces;
namespace UserManagement.Services.Domain.Implementations;

public class LogService : ILogService
{
    private readonly IDataContext _dataAccess;
    public LogService(IDataContext dataAccess) => _dataAccess = dataAccess;

    public void AddLog(int userId, string logType, string logMessage)
    {
        var log = new Log
        {
            UserId = userId,
            LogType = logType,
            LogMessage = logMessage
        };

        _dataAccess.Create(log);
    }

    public IEnumerable<Log> GetAll() => _dataAccess.GetAll<Log>();

    public IEnumerable<Log> GetUserLogs(int id) {
        var loglist = _dataAccess.GetAll<Log>();

        return loglist.Where(x => x.UserId == id); 
    } 
}
