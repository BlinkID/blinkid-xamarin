using System;
using Com.Microblink.Uisettings;
using Microblink.Forms.Core.Overlays;
using Microblink.Forms.Core.Recognizers;
using Microblink.Forms.Droid.Overlays.Implementations;
using Microblink.Forms.Droid.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(BlinkCardOverlaySettingsFactory))]
namespace Microblink.Forms.Droid.Overlays.Implementations
{
    public sealed class BlinkCardOverlaySettings : OverlaySettings, IBlinkCardOverlaySettings
    {
        public override UISettings NativeUISettings { 
            get {
                var concreteUISettings = (BlinkCardUISettings)base.NativeUISettings;
                if (FirstSideInstructions != null) {
                    concreteUISettings.FirstSideInstructions = FirstSideInstructions;
                }
                if (SecondSideInstructions != null) {
                    concreteUISettings.SecondSideInstructions = SecondSideInstructions;
                }
                return concreteUISettings;
            }
        }

        public string FirstSideInstructions { get; set; }

        public string SecondSideInstructions { get; set; }

        public BlinkCardOverlaySettings(IRecognizerCollection recognizerCollection)
            : base(new BlinkCardUISettings((recognizerCollection as RecognizerCollection).NativeRecognizerBundle), recognizerCollection)
        {}
    }

    public sealed class BlinkCardOverlaySettingsFactory : IBlinkCardOverlaySettingsFactory
    {
        public IBlinkCardOverlaySettings CreateBlinkCardOverlaySettings(IRecognizerCollection recognizerCollection)
        {
            return new BlinkCardOverlaySettings(recognizerCollection);
        }
    }
}
