using Models;
using System.Collections.Concurrent;

namespace Services;

public class NetworkService : INetworkService
{
    private static readonly ConcurrentDictionary<string, SimCard> Sims = new();
    private static readonly ConcurrentDictionary<string, Device> Devices = new();
    private static readonly ConcurrentDictionary<string, RoamingStatus> Roaming = new();

    public SignalReport CheckSignal(string location)
    {
        return new SignalReport
        {
            Location = location,
            SignalStrengthDbm = -65,
            NetworkType = "5G"
        };
    }

    public bool ActivateSim(string simId)
    {
        if (Sims.TryGetValue(simId, out var sim))
        {
            sim.IsActive = true;
            return true;
        }
        return false;
    }

    public bool DeactivateSim(string simId)
    {
        if (Sims.TryGetValue(simId, out var sim))
        {
            sim.IsActive = false;
            return true;
        }
        return false;
    }

    public bool RegisterDevice(Device device)
    {
        device.RegisteredAt = DateTime.UtcNow;
        return Devices.TryAdd(device.DeviceId, device);
    }

    public RoamingStatus GetRoamingStatus(string simId)
    {
        return Roaming.TryGetValue(simId, out var status) ? status : null;
    }

    public bool UpdateRoamingStatus(string simId, bool enable)
    {
        if (!Sims.ContainsKey(simId)) return false;
        Roaming[simId] = new RoamingStatus { SimId = simId, IsRoamingEnabled = enable };
        return true;
    }
}
