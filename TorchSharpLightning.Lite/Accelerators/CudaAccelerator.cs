using TorchSharp;

namespace TorchSharpLightning.Lite.Accelerators;

public class CudaAccelerator : Accelerator
{
    public override void SetupDevice(torch.Device device)
    {
        if (device.type != DeviceType.CUDA)
        {
            throw new ArgumentException($"Device should be Cuda, got {device.type} instead.");
        }
        
        torch.cuda.dev
    }

    public override void TearDown()
    {
        throw new NotImplementedException();
    }

    public override int ParseDevices(int devices)
    {
        throw new NotImplementedException();
    }

    public override torch.Device[] GetParallelDevices(int devices)
    {
        throw new NotImplementedException();
    }

    public override int AutoDeviceCount()
    {
        throw new NotImplementedException();
    }

    public override bool IsAvailable()
    {
        throw new NotImplementedException();
    }

    public override void RegisterAccelerators(Dictionary<DeviceType, Accelerator> acceleratorRegistry)
    {
        throw new NotImplementedException();
    }

    public static int GetNumberOfCudaDevices()
    {
        return torch.cuda.device_count();
    }

    public static bool IsCudaAvailabe()
    {
        return GetNumberOfCudaDevices() > 0;
    }
}