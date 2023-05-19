using System.Runtime.Serialization;

namespace BackendSiteVendas.Exceptions.ExceptionsBase;

[Serializable]
public class BackendSiteVendasException : SystemException
{
    public BackendSiteVendasException(string message) : base(message) { }

    protected BackendSiteVendasException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}
