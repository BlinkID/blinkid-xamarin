// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace iOS
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView metadataImageView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView metadataTextView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton startScanningButton { get; set; }


        [Action ("StartScanningButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void StartScanningButton_TouchUpInside (UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (metadataImageView != null) {
                metadataImageView.Dispose ();
                metadataImageView = null;
            }

            if (metadataTextView != null) {
                metadataTextView.Dispose ();
                metadataTextView = null;
            }

            if (startScanningButton != null) {
                startScanningButton.Dispose ();
                startScanningButton = null;
            }
        }
    }
}