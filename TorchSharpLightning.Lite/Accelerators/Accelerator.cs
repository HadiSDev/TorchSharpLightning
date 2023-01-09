using System.Collections;
using TorchSharp;
using static TorchSharp.torch;


namespace TorchSharpLightning.Lite.Accelerators;

public abstract class Accelerator
{
    public abstract void SetupDevice(Device device);
    
    public abstract void TearDown();
    
    public abstract int ParseDevices(int devices); 
    
    public abstract Device[] GetParallelDevices(int devices); 
    
    public abstract int AutoDeviceCount(); 
    
    public abstract bool IsAvailable(); 
    
    public abstract void RegisterAccelerators(Dictionary<DeviceType, Accelerator> acceleratorRegistry); 
}