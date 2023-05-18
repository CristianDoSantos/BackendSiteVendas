namespace BackendSiteVendas.Comunication.Requests;

public class ChangePasswordRequestJson
{
    public string CurrentPassword { get; set; }
    public string NewPassword { get; set; }
}
