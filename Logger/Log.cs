using System;

namespace DatingAPI.Logger
{
    public class Log
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string Message { get; set; }
        public LogType Type { get; set; }
        public string IpAddress { get; set; }

        public Log(string message)
        {
            Message = message;
            Type = LogType.Info;
            IpAddress = "";
        }

        public Log(string message, LogType type, string ip = "")
        {
            Message = message;
            Type = type;
            IpAddress = ip;
        }
    }

    public enum LogType
    {
        Info,
        Warn,
        Debug,
        Error
    }
}