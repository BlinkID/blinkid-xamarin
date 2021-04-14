using System;
namespace BlinkID.Forms.Core.Overlays
{
    /// <summary>
    /// Base interface for all Overlay settings classes.
    /// </summary>
    public interface IOverlaySettings {
        /// <summary>
        /// Whether front camera should be used instead of the default camera.
        /// Default: false.
        /// </summary>
        bool UseFrontCamera { get; set; }
    }
}