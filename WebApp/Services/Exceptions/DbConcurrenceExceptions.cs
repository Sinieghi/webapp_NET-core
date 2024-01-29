namespace WebApp.Services.Exceptions
{
    public class DbConcurrenceExceptions(string msg) : ApplicationException(msg);

}