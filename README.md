<p align="center" >
  <img src="https://raw.githubusercontent.com/BlinkID/blinkid-xamarin/design/Design/logo-microblink-xamarin.png" alt="MicroBlink" title="MicroBlink">
</p>

# _BlinkID_ Xamarin SDK

This is BlinkID Xamarin implementation based on native [Objective-C](https://github.com/BlinkID/blinkid-ios) and [Java](https://github.com/BlinkID/blinkid-android) BlinkID SDKs.

**BlinkID SDK** is not available as **Xamarin Component** because it is much simpler to reuse C# Binding Library projects from this repository with resources included inside other than manual import of Android and iOS Resources from **Xamarin Component's Sample applications**. 

## Directory and files summary

* `Binding` - Xamarin [iOS](https://developer.xamarin.com/guides/ios/advanced_topics/binding_objective-c/) and [Android](https://developer.xamarin.com/guides/android/advanced_topics/binding-a-java-library/) Binding Libraries
* `BidingSource` - Objective-C and Java wrappers source with Samples 
* `Samples` - [Xamarin.iOS](Samples/iOS), [Xamarin.Android](Samples/Android) and [Xamarin.Forms](Samples/Forms) sample applications

## Quick start
### Quick start with Sample app

1. Open Xamarin Studio or Visual Studio
2. Choose one of sample application's solution as starting point:
    * [Xamarin.Android](Samples/Android)
    * [Xamarin.iOS](Samples/iOS)
    * [Xamarin.Forms](Samples/Forms)
3. More details about Samples [here](Samples)

### Quick start with Existing app

1. "Add Existing Project..." - Binding Library project(s) to your app's Solution
  * [Android Binding Library](Binding/Android/BlinkIDAndroidBinding.csproj)  
    ![Add Android Binding Library](https://raw.githubusercontent.com/BlinkID/blinkid-xamarin/design/Design/blinkid-add-existing-project-android-binding-library-project.png)  
  * [iOS Binding Library](Binding/iOS/BlinkIDiOSBinding.csproj)  
    ![Add iOS Binding Library](https://raw.githubusercontent.com/BlinkID/blinkid-xamarin/design/Design/blinkid-add-existing-project-ios-binding-library-project.png)  

2. Add Binding Library project as Reference to platform specific project
  * Android  
  ![Add Android Binding Project as Reference](https://raw.githubusercontent.com/BlinkID/blinkid-xamarin/design/Design/blinkid-add-binding-android-project-as-reference.png)
  * iOS  
  ![Add iOS Binding Project as Reference](https://raw.githubusercontent.com/BlinkID/blinkid-xamarin/design/Design/blinkid-add-binding-ios-project-as-reference.png)

3a. Android specific
  * Add `MicroBlink` assets
  * ![Android Specific add assets](https://raw.githubusercontent.com/BlinkID/blinkid-xamarin/design/Design/blinkid-android-specific-add-microblink-assets.png)
  * Use assets from the Sample application, find it [here](Samples/Android/Assets/microblink)
  * In `AndroidManifest.xml` add `Camera` permission

3b. iOS specific
  * Update git submodule [`blinkid-ios`](https://github.com/blinkid/blinkid-ios)
```
git submodule init  
git submodule update --recursive
```

4. Change license key based on unique app ID
  * Android - Package name 
  * iOS - Bundle Identifier

5. Feel free to use code from [Sample apps](Samples)


## How to update native wrappers and binding libraries?
### Android

1. Open project with Android Studio [BindingSource/Android/BlinkIDWrapper](BindingSource/Android/BlinkIDWrapper)
2. Add/edit exposed functionality from Java to C#
3. Build `LibWrapper-release.aar` with Gradle
4. Replace [Binding/Android/LibWrapper-release.aar](Binding/Android/LibWrapper-release.aar) in project [Binding/Android/BlinkIDAndroidBinding.csproj](Binding/Android/BlinkIDAndroidBinding.csproj) with built `LibWrapper-release.aar`  
Set `Build Action` to `LibraryProjectZip`
5. Extract `classes.jar` from [github.com/BlinkID/blinkid-android/blob/master/LibRecognizer.aar](https://github.com/BlinkID/blinkid-android/blob/master/LibRecognizer.aar)
6. Replace [Binding/Android/Jars/classes.jar](Binding/Android/Jars/classes.jar) with extracted `classes.jar`  
Set `Build Action` to `EmbeddedReferenceJar`
7. Extract native libraries from `LibRecognizer.aar` - `jni/**/*.so` files
8. Replace native libraries [Binding/Android/lib/*](Binding/Android/lib) with extracted native libraries  
Set `Build Action` to `EmbeddedNativeLibrary`
9. Rebuild binding library project

\* Steps from 5 to 8 could be automated with this Bash script [`updateAndroidBindingLibraryFromLibRecognizer.aar.sh`](BindingSource/Android/updateAndroidBindingLibraryFromLibRecognizer.aar.sh)  
Example to run it from the repository root and fetch latest `LibRecognizer.aar` from master of `blinkid-android` repository:
```
./BindingSource/Android/updateAndroidBindingLibraryFromLibRecognizer.aar.sh ./Binding/Android/ https://github.com/BlinkID/blinkid-android/blob/master/LibRecognizer.aar?raw=true
```

\* Steps from 5 to 8 are required only if you use newer version of `LibRecognizer.aar` from [github.com/BlinkID/blinkid-android/blob/master/LibRecognizer.aar](https://github.com/BlinkID/blinkid-android/blob/master/LibRecognizer.aar)

### iOS

1. Update submodule [BindingSource/iOS/blinkid-ios](https://github.com/BlinkID/blinkid-ios) with  
```
git submodule init  
git submodule update --recursive
```
2. Open project with Xcode [BindingSource/iOS/BlinkID/BlinkID.xcodeproj](BindingSource/iOS/BlinkID/BlinkID.xcodeproj)
3. Add/edit exposed functionallity from Objective-C to C#
4. Build Release with Xcode
5. Locate Product `BlinkID.framework` with Finder
6. Extract `BlinkID` from `BlinkID.framework` and rename it to `BlinkID.a`
7. Replace [Binding/iOS/BlinkID.a](Binding/iOS/BlinkID.a) with extracted `BlinkID.a`
8. `BlinkID` Native Reference Properties  
![iOS Native Reference Properties](https://raw.githubusercontent.com/BlinkID/blinkid-xamarin/design/Design/blinkid-ios-native-reference-properties.png)
9. Replace [Binding/iOS/Resources/MicroBlink.bundle](Binding/iOS/Resources/MicroBlink.bundle) with [BindingSource/iOS/blinkid-ios/MicroBlink.bundle](https://github.com/BlinkID/blinkid-ios/tree/master/MicroBlink.bundle)
10. Generate new `ApiDefinition.cs` and `StructsAndEnums.cs` (optional) with [Objective Sharpie](https://developer.xamarin.com/guides/cross-platform/macios/binding/objective-sharpie/)
Example: `sharpie bind -sdk iphoneos9.2 BlinkID.framework/Headers/BlinkID.h -scope BlinkID.framework/Headers -c -F .`  
Note: Use latest iOS SDK!  
11. Replace [Binding/iOS/ApiDefinition.cs](Binding/iOS/ApiDefinition.cs) and [Binding/iOS/StructsAndEnums.cs](Binding/iOS/StructsAndEnums.cs) with new generated files `ApiDefinition.cs` and `StructsAndEnums.cs`, edit generated files if it is necessary
12. Rebuild binding library project

\* Steps from 6 to 9 are required only if you use newer version of `MicroBlink.framework` from [BindingSource/iOS/blinkid-ios](https://github.com/BlinkID/blinkid-ios)

