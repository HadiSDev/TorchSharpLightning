using TorchSharp;
using static TorchSharp.torch;
using TorchSharpLightning.Utilities.Core;
namespace TorchSharpLightning.Lite.Utilities;


public class ApplyFunction
{
    private static readonly DeviceType[] BlockedDevices = { DeviceType.CPU};

    private static Tensor FromArray(Array value, Device device)
    {
        return TorchSharp.torch.from_array(value).to(device);
    }
    
    private static Tensor FromArray(Array value, string device)
    {
        return TorchSharp.torch.from_array(value).to(device);
    }
    
    private static Tensor FromArray(Array value, int device)
    {
        return TorchSharp.torch.from_array(value).to(device);
    }
    
    private static Tensor FromBool(bool value, Device device)
    {
        return tensor(value, dtype: @bool).to(device);
    }
    
    private static Tensor FromFloat(float value, Device device)
    {
        return tensor(value, dtype: float32).to(device);
    }
    
    private static Tensor FromFloat(Half value, Device device)
    {
        return tensor((float)value, dtype: @float16).to(device);
    }
    
    private static Tensor FromFloat(double value, Device device)
    {
        return tensor((float)value, dtype: float64).to(device);
    }

    public Tensor MoveDataToDevice(Tensor batch, Device device)
    {
        Tensor BatchTo(Tensor data)
        {
            var dataOutput = data.to(device);
            
            if ((dataOutput as object) != null)
            {
                return dataOutput;
            }

            return data;
        }

        return batch.ApplyToTensor(BatchTo);
    }

    public Tensor ConvertToTensor(object data, Device device)
    {
        if (data is bool b)
        {
            return FromBool(b, device).contiguous();
        }

        if (data is float f)
        {
            return FromFloat(f, device).contiguous();
        }

        if (data is double d)
        {
            return FromFloat(d, device).contiguous();
        }

        if (data is Half h)
        {
            return FromFloat(h, device).contiguous();
        }

        throw new NotImplementedException("Cannot Cast to Tensor");
    }

    public IEnumerable<Tensor> ConvertToTensors(IEnumerable<object> data, Device device)
    {
        foreach (var item in data)
        {
            yield return ConvertToTensor(item, device);
        }
    }

}

