using System.Runtime.Serialization;

namespace BackendSiteVendas.Exceptions.ExceptionsBase;
    
[Serializable]
public class InvalidLoginException : BackendSiteVendasException
{
    public InvalidLoginException() : base(ResourceCustomErrorMessages.INVALID_LOGIN) 
    {
    }

    protected InvalidLoginException(SerializationInfo info, StreamingContext context) : base(info, context) 
    {
    }
}
