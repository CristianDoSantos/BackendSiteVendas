namespace BackendSiteVendas.Comunication.Requests.User;

public class ChangePasswordRequestJson
{
    public string CurrentPassword { get; set; }
    public string NewPassword { get; set; }
}
