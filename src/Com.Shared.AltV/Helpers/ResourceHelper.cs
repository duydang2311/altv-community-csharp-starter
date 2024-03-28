using AltExtensions = AltV.Net.AltExtensions;

namespace Com.Shared.AltV.Helpers;

public static class ResourceHelper
{
    public static void RegisterAdapters()
    {
        AltExtensions.RegisterAdapters(registerListAdapters: true, logAdapters: true);
    }
}
