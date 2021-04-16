
using BlinkID.Forms.iOS.Overlays;
using BlinkID.Forms.Core.Overlays;
using BlinkID.Forms.Core.Recognizers;
using BlinkID;

namespace BlinkID.Forms.iOS.Overlays
{
	public abstract class BaseOverlaySettings : OverlaySettings, IScanSoundOverlaySettings
    {
        public MBBaseOverlaySettings baseOverlaySettings { get; }

        protected BaseOverlaySettings(MBBaseOverlaySettings baseOverlaySettings): base(baseOverlaySettings)
        {
            this.baseOverlaySettings = baseOverlaySettings;
        }

        public bool EnableBeep
        {
            get
            {
                return baseOverlaySettings.SoundFilePath == "";
            }
            set
            {
                if (value)
                {
                    string path = MBMicroblinkApp.SharedInstance().ResourcesBundle.PathForResource("PPbeep", "wav");
                    baseOverlaySettings.SoundFilePath = path;
                }
                else
                {
                    baseOverlaySettings.SoundFilePath = "";
                }
            }
        }
    }
}