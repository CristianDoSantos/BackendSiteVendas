using System.Runtime.Serialization;

namespace BackendSiteVendas.Exceptions.ExceptionsBase;

[Serializable]
public class ValidationErrorException : BackendSiteVendasException
{
    public List<string> ErrorMessages { get; set; }

    public ValidationErrorException(List<string> errorMessages) : base(String.Empty)
    {
        ErrorMessages = errorMessages;
    }

    protected ValidationErrorException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}
