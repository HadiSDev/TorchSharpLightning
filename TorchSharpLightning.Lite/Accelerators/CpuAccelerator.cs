using System.Collections;
using TorchSharp;
using static TorchSharp.torch;

namespace TorchSharpLightning.Lite.Accelerators;

public class CpuAccelerator : Accelerator
{
    public override void SetupDevice(torch.Device device)
    {
        if (device.type != DeviceType.CPU)
        {
            throw new ArgumentException($"Device should be CPU, got {device.type} instead.");
        }
    }

    public override void TearDown()
    {
        
    }

    public override int ParseDevices(int devices)
    {
        return devices;
    }

    public override Device[] GetParallelDevices(int devices)
    {
        devices = ParseDevices(devices);
        return Enumerable.Repeat(device(DeviceType.CPU), devices).ToArray();
    }

    public override int AutoDeviceCount()
    {
        return 1;
    }

    public override bool IsAvailable()
    {
        return true;
    }

    public override void RegisterAccelerators(Dictionary<DeviceType, Accelerator> acceleratorRegistry)
    {
        acceleratorRegistry.Add(DeviceType.CPU, this);
    }
    
}