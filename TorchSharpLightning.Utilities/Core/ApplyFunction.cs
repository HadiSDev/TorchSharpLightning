using System.Collections;
using static TorchSharp.torch;

namespace TorchSharpLightning.Utilities.Core;

public static class TensorExtensions
{
    public static IEnumerable<Tensor> ApplyToTensors(this ICollection<Tensor> data, Func<Tensor, Tensor> applyFunction)
    {
        foreach (var item in data)
        {
            yield return applyFunction(item);
        }
    }
    
    public static Tensor ApplyToTensor(this Tensor tensor, Func<Tensor, Tensor> applyFunction)
    {
        return applyFunction(tensor);
    }
}