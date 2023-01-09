using Linq.Extras;
using static TorchSharp.torch;

namespace TorchSharpLightning.Lite.Utilities;

public class DeviceParser
{
    public static Device DetermineRootGpuDevice(Device[] gpus)
    {
        if (gpus.IsNullOrEmpty())
        {
            throw new ArgumentException("Gpus is empty or null");
        }

        return gpus.First();
    }

    public static Device[] ParseGpuIds(int gpus, bool includeCuda = false)
    {
        if (gpus == 0)
        {
            return null;
        }
        
        
            
    }

    private static void CheckUnique(int[] deviceIds)
    {
        if (deviceIds.Length != deviceIds.ToHashSet().Count)
        {
            throw new ArgumentException("Device Ids needs to be unique");
        }
    }

    private static Device[] GetAllAvailableGpus(bool includeCuda = false)
    {
        
        return 
    }
}