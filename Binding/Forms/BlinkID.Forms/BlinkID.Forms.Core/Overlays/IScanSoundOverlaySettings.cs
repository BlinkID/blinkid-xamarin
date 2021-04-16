using System;
namespace BlinkID.Forms.Core.Overlays
{
    /// <summary>
    /// Interface for Overlay settings classes which have scan sound option.
    /// </summary>
    public interface IScanSoundOverlaySettings {

        /// <summary>
        /// Whether beep sound will be played on successful scan.
        /// Default: false.
        /// </summary>
        bool EnableBeep { get; set; }
    }
}