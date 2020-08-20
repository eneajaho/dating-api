using DatingAPI.Contracts;
using DatingAPI.Entities;

namespace DatingAPI.Logger
{
    public class LoggerManager : ILoggerManager
    {
        private readonly RepositoryContext _context;

        public LoggerManager(RepositoryContext context)
        {
            _context = context;
        }

        public void LogDebug(string message, string ip = "")
        {
            Add(new Log(message, LogType.Debug, ip));
        }

        public void LogError(string message, string ip = "")
        {
            Add(new Log(message, LogType.Error, ip));
        }

        public void LogInfo(string message, string ip = "")
        {
            Add(new Log(message, LogType.Info, ip));
        }

        public void LogWarn(string message, string ip = "")
        {
            Add(new Log(message, LogType.Warn, ip));
        }

        private void Add(Log log)
        {
            _context.Logs.Add(log);
            _context.SaveChanges();
        }
    }
}