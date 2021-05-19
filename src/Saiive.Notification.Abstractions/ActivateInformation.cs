namespace Saiive.Notification.Abstractions
{
    public class RequestInformation
    {
        public string Host { get; set; }
    }
    
    public class AddedInformation : RequestInformation
    {
    }

    public class ActivateInformation : RequestInformation
    {
    }

    public class DeactivateInformation : RequestInformation
    {
    }
}
