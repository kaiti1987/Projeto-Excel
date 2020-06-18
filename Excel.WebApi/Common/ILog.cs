namespace Excel.WebApi.Common
{
    public interface ILog
    {
        void LogError(string error);

        void LogInformation(string information);        
    }
}