using Models;
namespace Services;
public interface INetworkService
{
    SignalReport CheckSignal(string location);
    bool ActivateSim(string simId);
    bool DeactivateSim(string simId);
    bool RegisterDevice(Device device);
    RoamingStatus GetRoamingStatus(string simId);
    bool UpdateRoamingStatus(string simId, bool enable);
}
