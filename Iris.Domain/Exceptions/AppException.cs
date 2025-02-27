namespace Iris.Domain.Exceptions;
[Serializable]
public class AppException:Exception
{
    public AppException()
    {
        
    }

    public AppException(string message):base(message)
    {
        
    }
}
