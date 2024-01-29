namespace WebApp.Services.Exceptions
{
    public class NotFoundException(string msg) : ApplicationException(msg);

}