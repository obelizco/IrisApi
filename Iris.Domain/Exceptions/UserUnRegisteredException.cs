namespace Iris.Domain.Exceptions;

public class UserUnRegisteredException: Exception
{
    public UserUnRegisteredException()
    {

    }

    public UserUnRegisteredException(string message) : base(message)
    {

    }
}


