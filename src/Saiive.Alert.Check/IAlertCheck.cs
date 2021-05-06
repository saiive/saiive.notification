using System.Threading.Tasks;

namespace Saiive.Alert.Check
{
    public interface IAlertCheck
    {
        Task CheckAlerts();
    }
}
