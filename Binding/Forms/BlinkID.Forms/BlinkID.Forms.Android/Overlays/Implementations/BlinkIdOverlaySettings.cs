using Microblink.Forms.Droid.Overlays;
using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Overlays;
using Microblink.Forms.Core.Recognizers;
using Com.Microblink.Uisettings;

[assembly: Xamarin.Forms.Dependency(typeof(BlinkIdOverlaySettingsFactory))]
namespace Microblink.Forms.Droid.Overlays
{
    public sealed class BlinkIdOverlaySettings : OverlaySettings, IBlinkIdOverlaySettings
    {
        public BlinkIdOverlaySettings(IRecognizerCollection recognizerCollection)
            : base(new BlinkIdUISettings((recognizerCollection as RecognizerCollection).NativeRecognizerBundle), recognizerCollection)
        {}
    }

    public sealed class BlinkIdOverlaySettingsFactory : IBlinkIdOverlaySettingsFactory
    {
        public IBlinkIdOverlaySettings CreateBlinkIdOverlaySettings(IRecognizerCollection recognizerCollection)
        {
            return new BlinkIdOverlaySettings(recognizerCollection);
        }
    }
}
