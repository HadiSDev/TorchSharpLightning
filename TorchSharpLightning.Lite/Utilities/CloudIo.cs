using TorchSharp;
using static TorchSharp.torch;

namespace TorchSharpLightning.Lite.Utilities;

public static class CloudIo
{
    public static async Task<nn.Module> Load(this nn.Module model, string path, string? destination = null)
    {
        if (path.StartsWith("http"))
        {
            await hub.download_url_to_file_async(path, destination);
            return model.load(destination);
        }
        
        return model.load(path);
    }
}