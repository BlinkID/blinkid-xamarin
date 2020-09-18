<!--<p align="center" >
  <img src="https://raw.githubusercontent.com/BlinkID/blinkid-xamarin/design/Design/logo-microblink-xamarin.png" alt="MicroBlink" title="MicroBlink">
</p>-->

_BlinkID_ Xamarin SDK
======================

Enhance your Xamarin cross-platform apps with an AI-driven mobile ID scanning software.

Please note that, for maximum performance and full access to all features, it’s best to go with one of our native SDKs (for [iOS](https://github.com/BlinkID/blinkid-ios) or [Android](https://github.com/BlinkID/blinkid-android)).

Below you can try out our sample app, read the integration guides for both Android and iOS and study advanced topics ⬇️


# Integration into Xamarin Forms project

Steps for integrating BlinkID into your Xamarin Forms project:

1. In both your `Core`, `Droid` and `iOS` projects, add `BlinkID.Forms` NuGet package as a reference.
2. In your `Droid` project, update your `MainActivity.cs` in a following way:
    - update your `MainActivity` class so that it implements `Microblink.Forms.Droid.IMicroblinkScannerAndroidHostActivity`. This interface specifies 2 properties and 1 method that you must implement:
        - `HostActivity` property must return reference to current host activity.
        - `ScanActivityRequestCode` property must return integer that will be used as request code for Android's `StartActivityForResult` invocation
        - `ScanningStarted` method will be called just before scanning starts. It will receive currently used `MicroblinkScannerImplementation` as a parameter. You should save a reference to this object because you will need it later in your implementation of `OnActivityResult`
    - override `Activity's` method `OnActivityResult` and pass its parameters to reference of `MicroblinkScannerImplementation`
3. Your `iOS` project does not need any modifications.
4. In your `Core` project, obtain a reference to `IMicroblinkScannerFactory` using a `DependencyService`
5. Use a factory to create an instance of `IMicroblinkScanner`.
6. Use the dependency service to create recognizer you wish to use
7. Subscribe to `Messages.ScanningDoneMessage` that will inform you whether the scanning has completed or was cancelled by end user
8. Using on or more of recognizer objects obtained in step 6., create an instance `IRecognizerCollection` using `IRecognizerCollectionFactory` obtained via `DependencyService`
9. Create a settings object for desired UI overlay
10. Start scanning by invoking method `Scan` on instance of `IMicroblinkScanner`

## Xamarin Forms sample app

Xamarin Forms sample app is available [here](Samples/Forms).

# Integration into native Android project

In your native Android project, add reference to `BlinkID.Android.Binding` NuGet package and follow the integration instructions for [BlinkID Android SDK](https://github.com/blinkid/blinkid-android).

## Native Android sample app

Native Android sample app is available [here](Samples/Android).

# Integration into native iOS project

In your native iOS project, add reference to `BlinkID.iOS.Binding` NuGet package and follow the integration instructions for [BlinkID iOS SDK](https://github.com/BlinkID/blinkid-ios).

## Native iOS sample app

Native iOS sample app is available [here](Samples/iOS).

# Integration via Binding projects

If you do not wish to use BlinkID NuGet packages, you can directly reference binding projects in your solutions. Just make sure that following conditions are met:

- all large binary files have been checked out
    - to ensure that all files have been checked out, please make sure that you have installed [Git Large File Storage](https://git-lfs.github.com/) and that you have fetched all LFS files with `git lfs pull` command.
- your solution has referenced all dependencies of the project that you are referencing

# Directory and files summary

* `Binding` - Xamarin [iOS](https://developer.xamarin.com/guides/ios/advanced_topics/binding_objective-c/) and [Android](https://developer.xamarin.com/guides/android/advanced_topics/binding-a-java-library/) Binding Libraries and Xamarin Forms project from which all mentioned NuGet packages were built
* `Samples` - [Xamarin.iOS](Samples/iOS), [Xamarin.Android](Samples/Android) and [Xamarin.Forms](Samples/Forms) sample applications


# Advanced topics

## Updating native binding libraries

### Android

1. Download latest AAR from [Android SDK repository](https://github.com/BlinkID/blinkid-android/blob/master/LibBlinkID.aar)
2. Replace `Binding/Android/Jars/LibBlindID.aar` with latest AAR
3. Open `Binding/Forms/BlinkID.Forms/BlinkID.Forms.sln` solution
4. If needed, update `Transforms/Metadata.xml` in `AndroidBinding` project.
5. Right-click the `AndroidBinding` project, select `Options`, under `NuGet Package` section select `Metadata`
6. Update `Version` on tab `General`
7. Update `Release notes` on tab `Details`
8. Rebuild the `AndroidBinding` project

### iOS

1. Download latest [MicroBlink.bundle](https://github.com/BlinkID/blinkid-ios/tree/master/MicroBlink.bundle) and [MicroBlink.framework](https://github.com/BlinkID/blinkid-ios/tree/master/MicroBlink.framework) from [iOS SDK repository](https://github.com/BlinkID/blinkid-ios)
2. Replace `Binding/iOS/MicroBlink.bundle` and `Binding/iOS/MicroBlink.framework` with latest versions
3. Generate new `ApiDefinitions.cs` and `StructsAndEnums.cs` with latest version of [Objective Sharpie](https://docs.microsoft.com/en-us/xamarin/cross-platform/macios/binding/objective-sharpie/get-started), but **DO NOT OVERWRITE existing `ApiDefiniton.cs` and `Structs.cs`**
    - you can generate new `ApiDefinitions.cs` and `StructsAndEnums.cs` with following command (replace `iphoneos11.4` with latest SDK you have on your Mac):

    ```
    cd Binding/iOS
    sharpie bind -sdk iphoneos11.4 MicroBlink.framework/Headers/MicroBlink.h -scope MicroBlink.framework/Headers -namespace Microblink -c -F .
    ```
4. Manually merge new structures from generated `StructsAndEnums.cs` into existing `Structs.cs` while fixing compile errors
    - `sharpie` generates enums with underlying types such as `nuint` or `nint` which are not supported by latest version of C# - you must replace those with `uint` or `int` types.
5. Manually merge new API classes from generated `ApiDefinitions.cs` into existing `ApiDefinition.cs`
    - note that diff between those two files may be quite large, as `ApiDefinition.cs` has been manually edited to ensure correct compilation and correct exposure of all native SDK features. Focus only on adding new recognizers and parsers. Usually it shuold not be necessary to add other classes.
6. Open `Binding/Forms/BlinkID.Forms/BlinkID.Forms.sln` solution
7. From `iOSBinding` project remove `MicroBlink.bundle` and re-add it back
    - this will ensure that all new resources from new bundle are correctly added to the project
    - also make sure that all resources within added `MicroBlink.bundle` have `BuildAction` set to `BundleResource`
8. Right-click the `iOSBinding` project, select `Options`, under `NuGet Package` section select `Metadata`
9. Update `Version` on tab `General`
10. Update `Release notes` on tab `Details`
11. Rebuild the `iOSBinding` project and fix any compile errors that may have been introduced in steps 4. and 5.

## Updating Xamarin Forms core and platform implementations

1. Ensure that **both Android and iOS** native binding libraries have been updated as explained above
2. Open `Binding/Forms/BlinkID.Forms/BlinkID.Forms.sln` solution
3. Right-click the `BlinkID.Forms.Core` project, select `Options`, under `NuGet Package` section select `Metadata`
4. Update `Version` on tab `General`
5. Update `Release notes` on tab `Details`
6. Do the same for `BlinkID.Forms.Android`, `BlinkID.Forms.iOS` and `BlinkID.Forms.NuGet` projects
7. in `BlinkID.Forms.Core` add interfaces for new functionality (e.g. new recognizer)
8. add implementation for those interfaces in `BlinkID.Forms.Android` and `BlinkID.Forms.iOS` projects
9. rebuild both `BlinkID.Forms.Core`, `BlinkID.Forms.Android` and `BlinkID.Forms.iOS` projects

## Creating updated NuGet packages

1. Ensure that all projects have been updated as described above
    - this includes Android and iOS native binding libraries **and** Xamarin Forms core and platform implementations libraries
2. Open `Binding/Forms/BlinkID.Forms/BlinkID.Forms.sln` solution
3. Make sure `Release` build type is selected in `Visual Studio`
4. Right-click on `BlinkID.Forms.NuGet` project and select `Create NuGet package`
    - all projects will be built and their respective NuGet packages will be created in their `bin/Release` folder
5. Upload packages to [NuGet](https://www.nuget.org/)

## Android custom integration

This section describes how to create your scan activity with BlinkID SDK, natively in Android and wrap it to Xamarin. For that purpose, we have prepared [AndroidCustomUI](./Samples/AndroidCustomUI) sample.

Steps to wrap custom functionality to Xamarin:

1. Implement it natively for Android - create Android library:
    - make sure that you are not using any resources from the BlinkID Android SDK in resource files inside your library, otherwise, you will get compile errors while generating Xamarin bindings from Android library
    - we have created [BlinkIDWrapper](./Samples/AndroidCustomUI/BindingSource/BlinkIDWrapper) Android Studio project which contains [LibBlinkIDWrapper](./Samples/AndroidCustomUI/BindingSource/BlinkIDWrapper/LibBlinkIDWrapper) Android library module with custom scan activity
2. Build .aar archive from the library module:
    - we have built `LibBlinkIDWrapper-release.aar` from our Android library module
3. Create a new Xamarin Bindings Library for Android:
    - add a dependency to `BlinkID.Android.Binding` nuget package
    - add `.aar` to `Jars` folder and set the *Build Action* for `.aar` to *LibraryProjectZip*
    - we have prepared [CustomUIBinding](./Samples/AndroidCustomUI/CustomUISample/CustomUIBinding) project inside [CustomUISample](./Samples/AndroidCustomUI/CustomUISample) solution
4. You can use the Bindings Library in the application project:
    - first, add a reference to the created Bindings Library
    - add a dependency to `BlinkID.Android.Binding`
    - we have prepared sample application project [CustomUIApp](./Samples/AndroidCustomUI/CustomUISample/CustomUIApp) inside [CustomUISample](./Samples/AndroidCustomUI/CustomUISample) solution
