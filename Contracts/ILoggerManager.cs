namespace DatingAPI.Contracts
{
    public interface ILoggerManager
    {
        void LogInfo(string message, string ip = "");
        void LogWarn(string message, string ip = "");
        void LogDebug(string message, string ip = "");
        void LogError(string message, string ip = "");
    }
}