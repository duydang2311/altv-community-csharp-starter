using AltV.Net.Client.Async;
using Com.Shared.AltV.Helpers;

namespace Com.Client.AltV;

public sealed class ClientResource : AsyncResource
{
    public override void OnStart()
    {
        ResourceHelper.RegisterAdapters();
    }

    public override void OnStop()
    {
        throw new NotImplementedException();
    }
}
