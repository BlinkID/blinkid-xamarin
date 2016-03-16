# BlinkID Xamarin SDK

This is BlinkID Xamarin implementation based on native [Objective-C](https://github.com/BlinkID/blinkid-ios) and [Java](https://github.com/BlinkID/blinkid-android) BlinkID SDKs.

**BlinkID SDK** is not available as **Xamarin Component** because it is much simplier to reuse C# Binding Library projects from this repository with resources included inside other than manual import of Android and iOS Resources from **Xamarin Component's Sample applications**. 

## Directory and files summary

* `Binding` - Xamarin [iOS](https://developer.xamarin.com/guides/ios/advanced_topics/binding_objective-c/) and [Android](https://developer.xamarin.com/guides/android/advanced_topics/binding-a-java-library/) Binding Libraries
* `BidingSource` - Objective-C and Java wrappers source with Samples 
* `Samples` - [Xamarin.iOS](Samples/iOS), [Xamarin.Android](Samples/Android) and [Xamarin.Forms](Samples/Forms) sample applications
