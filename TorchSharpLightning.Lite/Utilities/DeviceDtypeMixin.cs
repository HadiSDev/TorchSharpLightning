using TorchSharp;
using static TorchSharp.torch;

namespace TorchSharpLightning.Lite.Utilities;

public class DeviceDtypeMixin : nn.Module
{
    public ScalarType Dtype { get; set; }
    private Device _device { get; set; }
    
    protected DeviceDtypeMixin(string name) : base(name)
    {
        Dtype = get_default_dtype();
        _device = device(DeviceType.CPU);
    }

    public Device Device()
    {
        if (_device.type == DeviceType.CUDA && _device.index == -1)
        {
            return device($"Is Cuda available:{torch.cuda.is_available()}");
        }

        return _device;
    }

    public nn.Module To(DeviceType device)
    {
        return base.to(device);
    }
    
    public nn.Module To(Device device)
    {
        UpdateProperties(device);
        return base.to(device);
    }
    public nn.Module To(string device)
    {
        UpdateProperties(device);
        return base.to(device);
    }
    
    public nn.Module To(ScalarType dType)
    {
        UpdateProperties(dType: dType);
        return base.to(dType);
    }

    private void UpdateProperties(Device? device = null, ScalarType? dType = null)
    {
        void ApplyFn(nn.Module module)
        {
            var ddm = module as DeviceDtypeMixin;
            
            if (device != null && ddm != null)
            {
                ddm._device = device;
            }
            
            if (dType != null && ddm != null)
            {
                ddm.Dtype = dType.Value;
            }
        }

        base.apply(ApplyFn);
    }
    
}