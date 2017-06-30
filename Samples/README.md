# Samples

This application samples can be **starting point (boilerplate)** for **new Xamarin application** which should contains **BlinkID SDK** and also contains simple functionality which can be reused in **existing Xamarin application**.

## Directory and files summary

* `Android` - **Xamarin.Android** sample application
    - projects in solution [Android/Android.sln](Android/Android.sln):
        - Xamarin.Android application; [Android/BlinkIDSample.csproj](Android/BlinkIDSample.csproj) 
        - Xamarin Binding library for Android; [../Binding/Android/BlinkIDAndroidBinding.csproj](../Binding/Android/BlinkIDAndroidBinding.csproj)   
* `Forms` - **Xamarin.Forms** sample application 
    - projects in solution [Forms/Forms.sln](Forms/Forms.sln):
        - Xamarin.Forms common PCL project; [Forms/Core/Core.csproj](Forms/Core/Core.csproj) 
        - Xamarin.Android application; [Forms/Droid/Droid.csproj](Forms/Droid/Droid.csproj) 
        - Xamarin.iOS application; [Forms/iOS/iOS.csproj](Forms/iOS/iOS.csproj) 
        - Xamarin Binding library for Android; [../Binding/Android/BlinkIDAndroidBinding.csproj](../Binding/Android/BlinkIDAndroidBinding.csproj)   
        - Xamarin Binding library for iOS; [../Binding/iOS/BlinkIDiOSBinding.csproj](../Binding/iOS/BlinkIDiOSBinding.csproj)   
* `iOS` - **Xamarin iOS** sample application
    - projects in solution [iOS/iOS.sln](iOS/iOS.sln):
        - Xamarin.iOS application; [iOS/BlinkIDSample.csproj](iOS/BlinkIDSample.csproj) 
        - Xamarin Binding library for iOS; [../Binding/iOS/BlinkIDiOSBinding.csproj](../Binding/iOS/BlinkIDiOSBinding.csproj)   


## Platform Specific

### iOS

Required `mtouch` arguments:
```
--linkskip=MicroBlink
```
To skip linking of MicroBlink assembly when `Linker behavior: Link Framework SDKs Only`.  
More details: https://developer.xamarin.com/guides/ios/advanced_topics/linker/#Skipping_Assemblies   
