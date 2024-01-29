namespace WebApp.Services.Exceptions
{
    public class IntegrityException(string msg) : ApplicationException(msg);
}