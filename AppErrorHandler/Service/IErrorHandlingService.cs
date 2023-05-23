namespace AppErrorHandler.Service
{
    public interface IErrorHandlingService
    {
        string HandleError(Exception ex);
    }
}