namespace BackendSiteVendas.Exceptions.ExceptionsBase;

public class ValidationErrorException : BackendSiteVendasException
{
    public List<string> ErrorMessages { get; set; }

    public ValidationErrorException(List<string> errorMessages) : base(String.Empty)
    {
        ErrorMessages = errorMessages;
    }
}
