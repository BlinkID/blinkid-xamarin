using System;
using AVFoundation;
using CoreAnimation;
using CoreGraphics;
using CoreMedia;
using Foundation;
using ObjCRuntime;
using UIKit;
using Microblink;
using System.Runtime.InteropServices;

namespace Microblink
{
    // @interface MBMicroblinkApp : NSObject
    
    [BaseType(typeof(NSObject))]
    interface MBMicroblinkApp
    {
        // @property (nonatomic) NSString * language;
        [Export("language")]
        string Language { get; set; }

        // @property (nonatomic) NSBundle * resourcesBundle;
        [Export("resourcesBundle", ArgumentSemantic.Assign)]
        NSBundle ResourcesBundle { get; set; }

        // +(instancetype)instance;
        [Static]
        [Export("instance")]
        MBMicroblinkApp Instance { get; }

        // -(void)setDefaultLanguage;
        [Export("setDefaultLanguage")]
        void SetDefaultLanguage();

        // -(void)pushStatusBarStyle:(UIStatusBarStyle)statusBarStyle;
        [Export("pushStatusBarStyle:")]
        void PushStatusBarStyle(UIStatusBarStyle statusBarStyle);

        // -(void)popStatusBarStyle;
        [Export("popStatusBarStyle")]
        void PopStatusBarStyle();

        // -(void)pushStatusBarHidden:(BOOL)hidden;
        [Export("pushStatusBarHidden:")]
        void PushStatusBarHidden(bool hidden);

        // -(void)popStatusBarHidden;
        [Export("popStatusBarHidden")]
        void PopStatusBarHidden();

        // -(void)setHelpShown:(BOOL)value;
        [Export("setHelpShown:")]
        void SetHelpShown(bool value);

        // -(BOOL)isHelpShown;
        [Export("isHelpShown")]
        bool IsHelpShown { get; }

        // +(NSBundle *)verifyAndGetDefaultResourcesBundle;
        [Static]
        [Export("verifyAndGetDefaultResourcesBundle")]
        NSBundle VerifyAndGetDefaultResourcesBundle();
    }

    interface IMBRecognizerRunnerViewController {}

    // @protocol MBRecognizerRunnerViewController <NSObject>
    [Protocol, Model]
    [BaseType (typeof(NSObject))]
    interface MBRecognizerRunnerViewController
    {
        // @required @property (nonatomic) BOOL autorotate;
        [Abstract]
        [Export ("autorotate")]
        bool Autorotate { get; set; }

        // @required @property (nonatomic) UIInterfaceOrientationMask supportedOrientations;
        [Abstract]
        [Export ("supportedOrientations", ArgumentSemantic.Assign)]
        UIInterfaceOrientationMask SupportedOrientations { get; set; }

        // @required -(void)pauseScanning;
        [Abstract]
        [Export ("pauseScanning")]
        void PauseScanning ();

        // @required -(BOOL)isScanningPaused;
        [Abstract]
        [Export ("isScanningPaused")]
        bool IsScanningPaused { get; }

        // @required -(void)resumeScanningAndResetState:(BOOL)resetState;
        [Abstract]
        [Export ("resumeScanningAndResetState:")]
        void ResumeScanningAndResetState (bool resetState);

        // @required -(BOOL)resumeCamera;
        [Abstract]
        [Export ("resumeCamera")]
        bool ResumeCamera { get; }

        // @required -(BOOL)pauseCamera;
        [Abstract]
        [Export ("pauseCamera")]
        bool PauseCamera { get; }

        // @required -(BOOL)isCameraPaused;
        [Abstract]
        [Export ("isCameraPaused")]
        bool IsCameraPaused { get; }

        // @required -(void)playScanSuccessSound;
        [Abstract]
        [Export ("playScanSuccessSound")]
        void PlayScanSuccessSound ();

        // @required -(void)willSetTorchOn:(BOOL)torchOn;
        [Abstract]
        [Export ("willSetTorchOn:")]
        void WillSetTorchOn (bool torchOn);

        // @required -(void)resetState;
        [Abstract]
        [Export ("resetState")]
        void ResetState ();

        // @required -(void)captureHighResImage:(MBCaptureHighResImage _Nonnull)highResoulutionImageCaptured;
        [Abstract]
        [Export ("captureHighResImage:")]
        void CaptureHighResImage (MBCaptureHighResImage highResoulutionImageCaptured);
    }

    // typedef void (^MBCaptureHighResImage)(MBImage * _Nullable);
    delegate void MBCaptureHighResImage ([NullAllowed] MBImage arg0);

    // @protocol MBOverlayContainerViewController <MBRecognizerRunnerViewController>
    [Protocol]
    interface MBOverlayContainerViewController : MBRecognizerRunnerViewController
    {
        // @required -(void)overlayViewControllerWillCloseCamera:(MBOverlayViewController *)overlayViewController;
        [Abstract]
        [Export("overlayViewControllerWillCloseCamera:")]
        void OverlayViewControllerWillCloseCamera(MBOverlayViewController overlayViewController);

        // @required -(BOOL)overlayViewControllerShouldDisplayTorch:(MBOverlayViewController *)overlayViewController;
        [Abstract]
        [Export("overlayViewControllerShouldDisplayTorch:")]
        bool OverlayViewControllerShouldDisplayTorch(MBOverlayViewController overlayViewController);

        // @required -(BOOL)overlayViewController:(MBOverlayViewController *)overlayViewController willSetTorch:(BOOL)isTorchOn;
        [Abstract]
        [Export("overlayViewController:willSetTorch:")]
        bool OverlayViewController(MBOverlayViewController overlayViewController, bool isTorchOn);

        // @required -(BOOL)shouldDisplayHelpButton;
        [Abstract]
        [Export("shouldDisplayHelpButton")]
        bool ShouldDisplayHelpButton { get; }

        // @required -(BOOL)isStatusBarPresented;
        [Abstract]
        [Export("isStatusBarPresented")]
        bool IsStatusBarPresented { get; }

        // @required -(BOOL)isTorchOn;
        [Abstract]
        [Export("isTorchOn")]
        bool IsTorchOn { get; }

        // @required -(BOOL)isCameraAuthorized;
        [Abstract]
        [Export("isCameraAuthorized")]
        bool IsCameraAuthorized { get; }
    }

    interface IMBOverlayContainerViewController {}

    // @interface MBOverlayViewController : UIViewController
    
    [BaseType(typeof(UIViewController))]
    [DisableDefaultCtor]
    interface MBOverlayViewController
    {
        // @property (nonatomic, weak) UIViewController<MBOverlayContainerViewController> * _Nullable recognizerRunnerViewController;
        [NullAllowed, Export("recognizerRunnerViewController", ArgumentSemantic.Weak)]
        IMBOverlayContainerViewController RecognizerRunnerViewController { get; set; }

        // @property (nonatomic, strong) UIView * _Nullable cameraPausedView;
        [NullAllowed, Export("cameraPausedView", ArgumentSemantic.Strong)]
        UIView CameraPausedView { get; set; }
    }

    // @interface MBViewControllerFactory : NSObject
    
    [BaseType(typeof(NSObject))]
    interface MBViewControllerFactory
    {
        // +(UIViewController<MBRecognizerRunnerViewController> * _Nonnull)recognizerRunnerViewControllerWithOverlayViewController:(MBOverlayViewController * _Nonnull)overlayViewController;
        [Static]
        [Export("recognizerRunnerViewControllerWithOverlayViewController:")]
        IMBRecognizerRunnerViewController RecognizerRunnerViewControllerWithOverlayViewController(MBOverlayViewController overlayViewController);
    }

    // @interface MBMicroblinkSDK : NSObject
    
    [BaseType(typeof(NSObject))]
    interface MBMicroblinkSDK
    {
        // +(instancetype _Nonnull)sharedInstance;
        [Static]
        [Export("sharedInstance")]
        MBMicroblinkSDK SharedInstance { get; }

        // @property (assign, nonatomic) BOOL showLicenseKeyTimeLimitedWarning;
        [Export("showLicenseKeyTimeLimitedWarning")]
        bool ShowLicenseKeyTimeLimitedWarning { get; set; }

        // @property (nonatomic, strong) NSBundle * _Nonnull resourcesBundle;
        [Export("resourcesBundle", ArgumentSemantic.Strong)]
        NSBundle ResourcesBundle { get; set; }

        // -(void)setLicenseBuffer:(NSData * _Nonnull)licenseBuffer;
        [Export("setLicenseBuffer:")]
        void SetLicenseBuffer(NSData licenseBuffer);

        // -(void)setLicenseBuffer:(NSData * _Nonnull)licenseBuffer andLicensee:(NSString * _Nonnull)licensee;
        [Export("setLicenseBuffer:andLicensee:")]
        void SetLicenseBuffer(NSData licenseBuffer, string licensee);

        // -(void)setLicenseKey:(NSString * _Nonnull)base64LicenseKey;
        [Export("setLicenseKey:")]
        void SetLicenseKey(string base64LicenseKey);

        // -(void)setLicenseKey:(NSString * _Nonnull)base64LicenseKey andLicensee:(NSString * _Nonnull)licensee;
        [Export("setLicenseKey:andLicensee:")]
        void SetLicenseKey(string base64LicenseKey, string licensee);

        // -(void)setLicenseResource:(NSString * _Nonnull)fileName withExtension:(NSString * _Nullable)extension inSubdirectory:(NSString * _Nullable)subdirectory forBundle:(NSBundle * _Nonnull)bundle;
        [Export("setLicenseResource:withExtension:inSubdirectory:forBundle:")]
        void SetLicenseResource(string fileName, [NullAllowed] string extension, [NullAllowed] string subdirectory, NSBundle bundle);

        // -(void)setLicenseResource:(NSString * _Nonnull)fileName withExtension:(NSString * _Nullable)extension inSubdirectory:(NSString * _Nullable)subdirectory forBundle:(NSBundle * _Nonnull)bundle andLicensee:(NSString * _Nonnull)licensee;
        [Export("setLicenseResource:withExtension:inSubdirectory:forBundle:andLicensee:")]
        void SetLicenseResource(string fileName, [NullAllowed] string extension, [NullAllowed] string subdirectory, NSBundle bundle, string licensee);

        // +(NSString * _Nonnull)buildVersionString;
        [Static]
        [Export("buildVersionString")]
        string BuildVersionString { get; }

        // +(BOOL)isScanningUnsupportedForCameraType:(MBCameraType)type error:(NSError * _Nullable * _Nullable)error;
        [Static]
        [Export("isScanningUnsupportedForCameraType:error:")]
        bool IsScanningUnsupportedForCameraType (MBCameraType type, [NullAllowed] out NSError error);
    }

    [Static]
    partial interface Constants
    {
        // extern const MBExceptionName MBIllegalModificationException;
        [Field("MBIllegalModificationException", "__Internal")]
        NSString MBIllegalModificationException { get; }

        // extern const MBExceptionName MBInvalidLicenseKeyException;
        [Field("MBInvalidLicenseKeyException", "__Internal")]
        NSString MBInvalidLicenseKeyException { get; }

        // extern const MBExceptionName MBInvalidLicenseeKeyException;
        [Field("MBInvalidLicenseeKeyException", "__Internal")]
        NSString MBInvalidLicenseeKeyException { get; }

        // extern const MBExceptionName MBInvalidLicenseResourceException;
        [Field("MBInvalidLicenseResourceException", "__Internal")]
        NSString MBInvalidLicenseResourceException { get; }

        // extern const MBExceptionName MBInvalidBundleException;
        [Field("MBInvalidBundleException", "__Internal")]
        NSString MBInvalidBundleException { get; }

        // extern const MBExceptionName MBMissingSettingsException;
        [Field("MBMissingSettingsException", "__Internal")]
        NSString MBMissingSettingsException { get; }

        // extern const MBExceptionName MBInvalidArgumentException;
        [Field("MBInvalidArgumentException", "__Internal")]
        NSString MBInvalidArgumentException { get; }
    }

    // @interface MBImage : NSObject
    
    [BaseType(typeof(NSObject))]
    interface MBImage
    {
        // @property (readonly, nonatomic) UIImage * _Nonnull image;
        [Export("image")]
        UIImage Image { get; }

        // @property (nonatomic) CGRect roi;
        [Export("roi", ArgumentSemantic.Assign)]
        CGRect Roi { get; set; }

        // @property (nonatomic) MBProcessingOrientation orientation;
        [Export("orientation", ArgumentSemantic.Assign)]
        MBProcessingOrientation Orientation { get; set; }

        // @property (nonatomic) BOOL mirroredHorizontally;
        [Export("mirroredHorizontally")]
        bool MirroredHorizontally { get; set; }

        // @property (nonatomic) BOOL mirroredVertically;
        [Export("mirroredVertically")]
        bool MirroredVertically { get; set; }

        // @property (nonatomic) BOOL estimateFrameQuality;
        [Export("estimateFrameQuality")]
        bool EstimateFrameQuality { get; set; }

        // @property (nonatomic) BOOL cameraFrame;
        [Export("cameraFrame")]
        bool CameraFrame { get; set; }

        // +(instancetype _Nonnull)imageWithUIImage:(UIImage * _Nonnull)image;
        [Static]
        [Export("imageWithUIImage:")]
        MBImage ImageWithUIImage(UIImage image);

        // +(instancetype _Nonnull)imageWithCmSampleBuffer:(CMSampleBufferRef _Nonnull)buffer;
        [Static]
        [Export("imageWithCmSampleBuffer:")]
        unsafe MBImage ImageWithCmSampleBuffer(CMSampleBuffer buffer);
    }

   // @interface MBCameraSettings : NSObject <NSCopying>
    [iOS (8,0)]
    [BaseType(typeof(NSObject))]
    interface MBCameraSettings : INSCopying
    {
        // @property (assign, nonatomic) MBCameraPreset cameraPreset;
        [Export("cameraPreset", ArgumentSemantic.Assign)]
        MBCameraPreset CameraPreset { get; set; }

        // @property (assign, nonatomic) MBCameraType cameraType;
        [Export("cameraType", ArgumentSemantic.Assign)]
        MBCameraType CameraType { get; set; }

        // @property (assign, nonatomic) NSTimeInterval autofocusInterval;
        [Export("autofocusInterval")]
        double AutofocusInterval { get; set; }

        // @property (assign, nonatomic) MBCameraAutofocusRestriction cameraAutofocusRestriction;
        [Export("cameraAutofocusRestriction", ArgumentSemantic.Assign)]
        MBCameraAutofocusRestriction CameraAutofocusRestriction { get; set; }

        // @property (nonatomic, weak) NSString * videoGravity;
        [Export("videoGravity", ArgumentSemantic.Weak)]
        string VideoGravity { get; set; }

        // @property (assign, nonatomic) CGPoint focusPoint;
        [Export("focusPoint", ArgumentSemantic.Assign)]
        CGPoint FocusPoint { get; set; }

        // @property (nonatomic) BOOL cameraMirroredHorizontally;
        [Export("cameraMirroredHorizontally")]
        bool CameraMirroredHorizontally { get; set; }

        // @property (nonatomic) BOOL cameraMirroredVertically;
        [Export("cameraMirroredVertically")]
        bool CameraMirroredVertically { get; set; }

        // -(NSString *)calcSessionPreset;
        [Export("calcSessionPreset")]
        string CalcSessionPreset { get; }

        // -(AVCaptureAutoFocusRangeRestriction)calcAutofocusRangeRestriction;
        [Export("calcAutofocusRangeRestriction")]
        AVCaptureAutoFocusRangeRestriction CalcAutofocusRangeRestriction { get; }
    }


    // @protocol MBDebugRecognizerRunnerViewControllerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface MBDebugRecognizerRunnerViewControllerDelegate
    {
        // @required -(void)recognizerRunnerViewController:(UIViewController<MBRecognizerRunnerViewController> * _Nonnull)recognizerRunnerViewController didOutputDebugImage:(MBImage * _Nonnull)image;
        [Abstract]
        [Export("recognizerRunnerViewController:didOutputDebugImage:")]
        void DidOutputDebugImage(IMBRecognizerRunnerViewController recognizerRunnerViewController, MBImage image);

        // @required -(void)recognizerRunnerViewController:(UIViewController<MBRecognizerRunnerViewController> * _Nonnull)recognizerRunnerViewController didOutputDebugText:(NSString * _Nonnull)text;
        [Abstract]
        [Export("recognizerRunnerViewController:didOutputDebugText:")]
        void DidOutputDebugText(IMBRecognizerRunnerViewController recognizerRunnerViewController, string text);
    }

    // @protocol MBDetectionRecognizerRunnerViewControllerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface MBDetectionRecognizerRunnerViewControllerDelegate
    {
        // @optional -(void)recognizerRunnerViewController:(UIViewController<MBRecognizerRunnerViewController> * _Nonnull)recognizerRunnerViewController didFinishDetectionWithDisplayableQuad:(MBDisplayableQuadDetection * _Nonnull)displayableQuad;
        [Export("recognizerRunnerViewController:didFinishDetectionWithDisplayableQuad:")]
        void RecognizerRunnerViewController(IMBRecognizerRunnerViewController recognizerRunnerViewController, MBDisplayableQuadDetection displayableQuad);

        // @optional -(void)recognizerRunnerViewController:(UIViewController<MBRecognizerRunnerViewController> * _Nonnull)recognizerRunnerViewController didFinishDetectionWithDisplayablePoints:(MBDisplayablePointsDetection * _Nonnull)displayablePoints;
        [Export("recognizerRunnerViewController:didFinishDetectionWithDisplayablePoints:")]
        void RecognizerRunnerViewController(IMBRecognizerRunnerViewController recognizerRunnerViewController, MBDisplayablePointsDetection displayablePoints);

        // @optional -(void)recognizerRunnerViewControllerDidFailDetection:(UIViewController<MBRecognizerRunnerViewController> * _Nonnull)recognizerRunnerViewController;
        [Export("recognizerRunnerViewControllerDidFailDetection:")]
        void RecognizerRunnerViewControllerDidFailDetection(IMBRecognizerRunnerViewController recognizerRunnerViewController);
    }

    // @interface MBDewarpPolicy : NSObject
    [iOS (8,0)]
    [BaseType (typeof(NSObject))]
    interface MBDewarpPolicy
    {
    }

    // @interface MBFixedDewarpPolicy : MBDewarpPolicy
    [iOS (8,0)]
    [BaseType (typeof(MBDewarpPolicy))]
    interface MBFixedDewarpPolicy
    {
        // -(instancetype _Nonnull)initWithDewarpHeight:(NSUInteger)dewarpHeight __attribute__((objc_designated_initializer));
        [Export ("initWithDewarpHeight:")]
        [DesignatedInitializer]
        IntPtr Constructor (nuint dewarpHeight);

        // @property (readonly, assign, nonatomic) NSUInteger dewarpHeight;
        [Export ("dewarpHeight")]
        nuint DewarpHeight { get; }
    }

    // @interface MBDPIBasedDewarpPolicy : MBDewarpPolicy
    [iOS (8,0)]
    [BaseType (typeof(MBDewarpPolicy))]
    interface MBDPIBasedDewarpPolicy
    {
        // -(instancetype _Nonnull)initWithDesiredDPI:(NSUInteger)desiredDPI __attribute__((objc_designated_initializer));
        [Export ("initWithDesiredDPI:")]
        [DesignatedInitializer]
        IntPtr Constructor (nuint desiredDPI);

        // @property (readonly, assign, nonatomic) NSUInteger desiredDPI;
        [Export ("desiredDPI")]
        nuint DesiredDPI { get; }
    }

    // @interface MBNoUpScalingDewarpPolicy : MBDewarpPolicy
    [iOS (8,0)]
    [BaseType (typeof(MBDewarpPolicy))]
    interface MBNoUpScalingDewarpPolicy
    {
        // -(instancetype _Nonnull)initWithMaxAllowedDewarpHeight:(NSUInteger)maxAllowedDewarpHeight __attribute__((objc_designated_initializer));
        [Export ("initWithMaxAllowedDewarpHeight:")]
        [DesignatedInitializer]
        IntPtr Constructor (nuint maxAllowedDewarpHeight);

        // @property (readonly, assign, nonatomic) NSUInteger maxAllowedDewarpHeight;
        [Export ("maxAllowedDewarpHeight")]
        nuint MaxAllowedDewarpHeight { get; }
    }

    // @protocol MBOcrRecognizerRunnerViewControllerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface MBOcrRecognizerRunnerViewControllerDelegate
    {
        // @required -(void)recognizerRunnerViewController:(UIViewController<MBRecognizerRunnerViewController> * _Nonnull)recognizerRunnerViewController didObtainOcrResult:(MBOcrLayout * _Nonnull)ocrResult withResultName:(NSString * _Nonnull)resultName;
        [Abstract]
        [Export("recognizerRunnerViewController:didObtainOcrResult:withResultName:")]
        void DidObtainOcrResult(IMBRecognizerRunnerViewController recognizerRunnerViewController, MBOcrLayout ocrResult, string resultName);
    }

    // @protocol MBGlareRecognizerRunnerViewControllerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface MBGlareRecognizerRunnerViewControllerDelegate
    {
        // @required -(void)recognizerRunnerViewController:(UIViewController<MBRecognizerRunnerViewController> * _Nonnull)recognizerRunnerViewController didFinishGlareDetectionWithResult:(BOOL)glareFound;
        [Abstract]
        [Export("recognizerRunnerViewController:didFinishGlareDetectionWithResult:")]
        void DidFinishGlareDetectionWithResult(IMBRecognizerRunnerViewController recognizerRunnerViewController, bool glareFound);
    }

    // @protocol MBFirstSideFinishedRecognizerRunnerViewControllerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface MBFirstSideFinishedRecognizerRunnerViewControllerDelegate
    {
        // @required -(void)recognizerRunnerViewControllerDidFinishRecognitionOfFirstSide:(UIViewController<MBRecognizerRunnerViewController> * _Nonnull)recognizerRunnerViewController;
        [Abstract]
        [Export("recognizerRunnerViewControllerDidFinishRecognitionOfFirstSide:")]
        void RecognizerRunnerViewControllerDidFinishRecognitionOfFirstSide(IMBRecognizerRunnerViewController recognizerRunnerViewController);
    }

    // @interface MBRecognizerRunnerViewControllerMetadataDelegates : NSObject
    
    [BaseType(typeof(NSObject))]
    interface MBRecognizerRunnerViewControllerMetadataDelegates
    {
        [Wrap("WeakDebugRecognizerRunnerViewControllerDelegate")]
        [NullAllowed]
        MBDebugRecognizerRunnerViewControllerDelegate DebugRecognizerRunnerViewControllerDelegate { get; set; }

        // @property (nonatomic, weak) id<MBDebugRecognizerRunnerViewControllerDelegate> _Nullable debugRecognizerRunnerViewControllerDelegate;
        [NullAllowed, Export("debugRecognizerRunnerViewControllerDelegate", ArgumentSemantic.Weak)]
        NSObject WeakDebugRecognizerRunnerViewControllerDelegate { get; set; }

        [Wrap("WeakDetectionRecognizerRunnerViewControllerDelegate")]
        [NullAllowed]
        MBDetectionRecognizerRunnerViewControllerDelegate DetectionRecognizerRunnerViewControllerDelegate { get; set; }

        // @property (nonatomic, weak) id<MBDetectionRecognizerRunnerViewControllerDelegate> _Nullable detectionRecognizerRunnerViewControllerDelegate;
        [NullAllowed, Export("detectionRecognizerRunnerViewControllerDelegate", ArgumentSemantic.Weak)]
        NSObject WeakDetectionRecognizerRunnerViewControllerDelegate { get; set; }

        [Wrap("WeakOcrRecognizerRunnerViewControllerDelegate")]
        [NullAllowed]
        MBOcrRecognizerRunnerViewControllerDelegate OcrRecognizerRunnerViewControllerDelegate { get; set; }

        // @property (nonatomic, weak) id<MBOcrRecognizerRunnerViewControllerDelegate> _Nullable ocrRecognizerRunnerViewControllerDelegate;
        [NullAllowed, Export("ocrRecognizerRunnerViewControllerDelegate", ArgumentSemantic.Weak)]
        NSObject WeakOcrRecognizerRunnerViewControllerDelegate { get; set; }

        [Wrap("WeakGlareRecognizerRunnerViewControllerDelegate")]
        [NullAllowed]
        MBGlareRecognizerRunnerViewControllerDelegate GlareRecognizerRunnerViewControllerDelegate { get; set; }

        // @property (nonatomic, weak) id<MBGlareRecognizerRunnerViewControllerDelegate> _Nullable glareRecognizerRunnerViewControllerDelegate;
        [NullAllowed, Export("glareRecognizerRunnerViewControllerDelegate", ArgumentSemantic.Weak)]
        NSObject WeakGlareRecognizerRunnerViewControllerDelegate { get; set; }

        [Wrap("WeakFirstSideFinishedRecognizerRunnerViewControllerDelegate")]
        [NullAllowed]
        MBFirstSideFinishedRecognizerRunnerViewControllerDelegate FirstSideFinishedRecognizerRunnerViewControllerDelegate { get; set; }

        // @property (nonatomic, weak) id<MBFirstSideFinishedRecognizerRunnerViewControllerDelegate> _Nullable firstSideFinishedRecognizerRunnerViewControllerDelegate;
        [NullAllowed, Export("firstSideFinishedRecognizerRunnerViewControllerDelegate", ArgumentSemantic.Weak)]
        NSObject WeakFirstSideFinishedRecognizerRunnerViewControllerDelegate { get; set; }
    }

    // @protocol MBRecognizerRunnerViewControllerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface MBRecognizerRunnerViewControllerDelegate
    {
        // @required -(void)recognizerRunnerViewControllerUnauthorizedCamera:(UIViewController<MBRecognizerRunnerViewController> * _Nonnull)recognizerRunnerViewController;
        [Abstract]
        [Export("recognizerRunnerViewControllerUnauthorizedCamera:")]
        void RecognizerRunnerViewControllerUnauthorizedCamera(IMBRecognizerRunnerViewController recognizerRunnerViewController);

        // @required -(void)recognizerRunnerViewController:(UIViewController<MBRecognizerRunnerViewController> * _Nonnull)recognizerRunnerViewController didFindError:(NSError * _Nonnull)error;
        [Abstract]
        [Export("recognizerRunnerViewController:didFindError:")]
        void RecognizerRunnerViewController(IMBRecognizerRunnerViewController recognizerRunnerViewController, NSError error);

        // @required -(void)recognizerRunnerViewControllerDidClose:(UIViewController<MBRecognizerRunnerViewController> * _Nonnull)recognizerRunnerViewController;
        [Abstract]
        [Export("recognizerRunnerViewControllerDidClose:")]
        void RecognizerRunnerViewControllerDidClose(IMBRecognizerRunnerViewController recognizerRunnerViewController);

        // @required -(void)recognizerRunnerViewControllerWillPresentHelp:(UIViewController<MBRecognizerRunnerViewController> * _Nonnull)recognizerRunnerViewController;
        [Abstract]
        [Export("recognizerRunnerViewControllerWillPresentHelp:")]
        void RecognizerRunnerViewControllerWillPresentHelp(IMBRecognizerRunnerViewController recognizerRunnerViewController);

        // @required -(void)recognizerRunnerViewControllerDidResumeScanning:(UIViewController<MBRecognizerRunnerViewController> * _Nonnull)recognizerRunnerViewController;
        [Abstract]
        [Export("recognizerRunnerViewControllerDidResumeScanning:")]
        void RecognizerRunnerViewControllerDidResumeScanning(IMBRecognizerRunnerViewController recognizerRunnerViewController);

        // @required -(void)recognizerRunnerViewControllerDidStopScanning:(UIViewController<MBRecognizerRunnerViewController> * _Nonnull)recognizerRunnerViewController;
        [Abstract]
        [Export("recognizerRunnerViewControllerDidStopScanning:")]
        void RecognizerRunnerViewControllerDidStopScanning(IMBRecognizerRunnerViewController recognizerRunnerViewController);
    }

    // @interface MBRecognizerResult : NSObject
    
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBRecognizerResult
    {
        // @property (readonly, assign, nonatomic) MBRecognizerResultState resultState;
        [Export("resultState", ArgumentSemantic.Assign)]
        MBRecognizerResultState ResultState { get; }
    }

    // @protocol MBScanningRecognizerRunnerViewControllerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface MBScanningRecognizerRunnerViewControllerDelegate
    {
        // @required -(void)recognizerRunnerViewController:(UIViewController<MBRecognizerRunnerViewController> * _Nonnull)recognizerRunnerViewController didFinishScanningWithState:(MBRecognizerResultState)state;
        [Abstract]
        [Export("recognizerRunnerViewController:didFinishScanningWithState:")]
        void DidFinishScanningWithState(IMBRecognizerRunnerViewController recognizerRunnerViewController, MBRecognizerResultState state);
    }

    // @protocol MBDebugRecognizerRunnerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface MBDebugRecognizerRunnerDelegate
    {
        // @optional -(void)recognizerRunner:(MBRecognizerRunner * _Nonnull)recognizerRunner didOutputDebugImage:(MBImage * _Nonnull)image;
        [Export("recognizerRunner:didOutputDebugImage:")]
        void DidOutputDebugImage(MBRecognizerRunner recognizerRunner, MBImage image);

        // @optional -(void)recognizerRunner:(MBRecognizerRunner * _Nonnull)recognizerRunner didOutputDebugText:(NSString * _Nonnull)text;
        [Export("recognizerRunner:didOutputDebugText:")]
        void DidOutputDebugText(MBRecognizerRunner recognizerRunner, string text);
    }

    // @protocol MBDetectionRecognizerRunnerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface MBDetectionRecognizerRunnerDelegate
    {
        // @optional -(void)recognizerRunner:(MBRecognizerRunner * _Nonnull)recognizerRunner didFinishDetectionWithDisplayableQuad:(MBDisplayableQuadDetection * _Nonnull)displayableQuad;
        [Export("recognizerRunner:didFinishDetectionWithDisplayableQuad:")]
        void RecognizerRunner(MBRecognizerRunner recognizerRunner, MBDisplayableQuadDetection displayableQuad);

        // @optional -(void)recognizerRunner:(MBRecognizerRunner * _Nonnull)recognizerRunner didFinishDetectionWithDisplayablePoints:(MBDisplayablePointsDetection * _Nonnull)displayablePoints;
        [Export("recognizerRunner:didFinishDetectionWithDisplayablePoints:")]
        void RecognizerRunner(MBRecognizerRunner recognizerRunner, MBDisplayablePointsDetection displayablePoints);

        // @optional -(void)recognizerRunnerDidFailDetection:(MBRecognizerRunner * _Nonnull)recognizerRunner;
        [Export("recognizerRunnerDidFailDetection:")]
        void RecognizerRunnerDidFailDetection(MBRecognizerRunner recognizerRunner);
    }

    // @protocol MBOcrRecognizerRunnerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface MBOcrRecognizerRunnerDelegate
    {
        // @required -(void)recognizerRunner:(MBRecognizerRunner * _Nonnull)recognizerRunner didObtainOcrResult:(MBOcrLayout * _Nonnull)ocrResult withResultName:(NSString * _Nonnull)resultName;
        [Abstract]
        [Export("recognizerRunner:didObtainOcrResult:withResultName:")]
        void DidObtainOcrResult(MBRecognizerRunner recognizerRunner, MBOcrLayout ocrResult, string resultName);
    }

    // @protocol MBGlareRecognizerRunnerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface MBGlareRecognizerRunnerDelegate
    {
        // @required -(void)recognizerRunner:(MBRecognizerRunner * _Nonnull)recognizerRunner didFinishGlareDetectionWithResult:(BOOL)glareFound;
        [Abstract]
        [Export("recognizerRunner:didFinishGlareDetectionWithResult:")]
        void DidFinishGlareDetectionWithResult(MBRecognizerRunner recognizerRunner, bool glareFound);
    }

    // @protocol MBFirstSideFinishedRecognizerRunnerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface MBFirstSideFinishedRecognizerRunnerDelegate
    {
        // @required -(void)recognizerRunnerDidFinishRecognitionOfFirstSide:(MBRecognizerRunner * _Nonnull)recognizerRunner;
        [Abstract]
        [Export("recognizerRunnerDidFinishRecognitionOfFirstSide:")]
        void RecognizerRunnerDidFinishRecognitionOfFirstSide(MBRecognizerRunner recognizerRunner);
    }

    // @interface MBRecognizerRunnerMetadataDelegates : NSObject
    
    [BaseType(typeof(NSObject))]
    interface MBRecognizerRunnerMetadataDelegates
    {
        [Wrap("WeakDebugRecognizerRunnerDelegate")]
        [NullAllowed]
        MBDebugRecognizerRunnerDelegate DebugRecognizerRunnerDelegate { get; set; }

        // @property (nonatomic, weak) id<MBDebugRecognizerRunnerDelegate> _Nullable debugRecognizerRunnerDelegate;
        [NullAllowed, Export("debugRecognizerRunnerDelegate", ArgumentSemantic.Weak)]
        NSObject WeakDebugRecognizerRunnerDelegate { get; set; }

        [Wrap("WeakDetectionRecognizerRunnerDelegate")]
        [NullAllowed]
        MBDetectionRecognizerRunnerDelegate DetectionRecognizerRunnerDelegate { get; set; }

        // @property (nonatomic, weak) id<MBDetectionRecognizerRunnerDelegate> _Nullable detectionRecognizerRunnerDelegate;
        [NullAllowed, Export("detectionRecognizerRunnerDelegate", ArgumentSemantic.Weak)]
        NSObject WeakDetectionRecognizerRunnerDelegate { get; set; }

        [Wrap("WeakOcrRecognizerRunnerDelegate")]
        [NullAllowed]
        MBOcrRecognizerRunnerDelegate OcrRecognizerRunnerDelegate { get; set; }

        // @property (nonatomic, weak) id<MBOcrRecognizerRunnerDelegate> _Nullable ocrRecognizerRunnerDelegate;
        [NullAllowed, Export("ocrRecognizerRunnerDelegate", ArgumentSemantic.Weak)]
        NSObject WeakOcrRecognizerRunnerDelegate { get; set; }

        [Wrap("WeakGlareRecognizerRunnerDelegate")]
        [NullAllowed]
        MBGlareRecognizerRunnerDelegate GlareRecognizerRunnerDelegate { get; set; }

        // @property (nonatomic, weak) id<MBGlareRecognizerRunnerDelegate> _Nullable glareRecognizerRunnerDelegate;
        [NullAllowed, Export("glareRecognizerRunnerDelegate", ArgumentSemantic.Weak)]
        NSObject WeakGlareRecognizerRunnerDelegate { get; set; }

        [Wrap("WeakFirstSideFinishedRecognizerRunnerDelegate")]
        [NullAllowed]
        MBFirstSideFinishedRecognizerRunnerDelegate FirstSideFinishedRecognizerRunnerDelegate { get; set; }

        // @property (nonatomic, weak) id<MBFirstSideFinishedRecognizerRunnerDelegate> _Nullable firstSideFinishedRecognizerRunnerDelegate;
        [NullAllowed, Export("firstSideFinishedRecognizerRunnerDelegate", ArgumentSemantic.Weak)]
        NSObject WeakFirstSideFinishedRecognizerRunnerDelegate { get; set; }
    }

    // @protocol MBScanningRecognizerRunnerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface MBScanningRecognizerRunnerDelegate
    {
        // @required -(void)recognizerRunner:(MBRecognizerRunner * _Nonnull)recognizerRunner didFinishScanningWithState:(MBRecognizerResultState)state;
        [Abstract]
        [Export("recognizerRunner:didFinishScanningWithState:")]
        void DidFinishScanningWithState(MBRecognizerRunner recognizerRunner, MBRecognizerResultState state);
    }

    // @protocol MBImageProcessingRecognizerRunnerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface MBImageProcessingRecognizerRunnerDelegate
    {
        // @required -(void)recognizerRunner:(MBRecognizerRunner * _Nonnull)recognizerRunner didFinishProcessingImage:(MBImage * _Nonnull)image;
        [Abstract]
        [Export("recognizerRunner:didFinishProcessingImage:")]
        void DidFinishProcessingImage(MBRecognizerRunner recognizerRunner, MBImage image);
    }

    // @protocol MBStringProcessingRecognizerRunnerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface MBStringProcessingRecognizerRunnerDelegate
    {
        // @required -(void)recognizerRunner:(MBRecognizerRunner * _Nonnull)recognizerRunner didFinishProcessingString:(NSString * _Nonnull)string;
        [Abstract]
        [Export("recognizerRunner:didFinishProcessingString:")]
        void DidFinishProcessingString(MBRecognizerRunner recognizerRunner, string @string);
    }

    // @interface MBRecognizerRunner : NSObject
    
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBRecognizerRunner
    {
        // @property (readonly, nonatomic, strong) MBRecognizerRunnerMetadataDelegates * _Nonnull metadataDelegates;
        [Export("metadataDelegates", ArgumentSemantic.Strong)]
        MBRecognizerRunnerMetadataDelegates MetadataDelegates { get; }

        [Wrap("WeakScanningRecognizerRunnerDelegate")]
        [NullAllowed]
        MBScanningRecognizerRunnerDelegate ScanningRecognizerRunnerDelegate { get; set; }

        // @property (nonatomic, weak) id<MBScanningRecognizerRunnerDelegate> _Nullable scanningRecognizerRunnerDelegate;
        [NullAllowed, Export("scanningRecognizerRunnerDelegate", ArgumentSemantic.Weak)]
        NSObject WeakScanningRecognizerRunnerDelegate { get; set; }

        [Wrap("WeakImageProcessingRecognizerRunnerDelegate")]
        [NullAllowed]
        MBImageProcessingRecognizerRunnerDelegate ImageProcessingRecognizerRunnerDelegate { get; set; }

        // @property (nonatomic, weak) id<MBImageProcessingRecognizerRunnerDelegate> _Nullable imageProcessingRecognizerRunnerDelegate;
        [NullAllowed, Export("imageProcessingRecognizerRunnerDelegate", ArgumentSemantic.Weak)]
        NSObject WeakImageProcessingRecognizerRunnerDelegate { get; set; }

        [Wrap("WeakStringProcessingRecognizerRunnerDelegate")]
        [NullAllowed]
        MBStringProcessingRecognizerRunnerDelegate StringProcessingRecognizerRunnerDelegate { get; set; }

        // @property (nonatomic, weak) id<MBStringProcessingRecognizerRunnerDelegate> _Nullable stringProcessingRecognizerRunnerDelegate;
        [NullAllowed, Export("stringProcessingRecognizerRunnerDelegate", ArgumentSemantic.Weak)]
        NSObject WeakStringProcessingRecognizerRunnerDelegate { get; set; }

        // -(instancetype _Nonnull)initWithRecognizerCollection:(MBRecognizerCollection * _Nonnull)recognizerCollection __attribute__((objc_designated_initializer));
        [Export("initWithRecognizerCollection:")]
        [DesignatedInitializer]
        IntPtr Constructor(MBRecognizerCollection recognizerCollection);

        // -(void)resetState;
        [Export("resetState")]
        void ResetState();

        // -(void)resetState:(BOOL)hard;
        [Export("resetState:")]
        void ResetState(bool hard);

        // -(void)cancelProcessing;
        [Export("cancelProcessing")]
        void CancelProcessing();

        // -(void)processImage:(MBImage * _Nonnull)image;
        [Export("processImage:")]
        void ProcessImage(MBImage image);

        // -(void)processString:(NSString * _Nonnull)string;
        [Export("processString:")]
        void ProcessString(string @string);

        // -(void)reconfigureRecognizers:(MBRecognizerCollection * _Nonnull)recognizerCollection;
        [Export("reconfigureRecognizers:")]
        void ReconfigureRecognizers(MBRecognizerCollection recognizerCollection);
    }

    // @interface MBEntity : NSObject
    
    [BaseType(typeof(NSObject))]
    interface MBEntity
    {
    }

    // @interface MBRecognizer : MBEntity
    
    [BaseType(typeof(MBEntity))]
    interface MBRecognizer
    {
        // @property (getter = isEnabled, nonatomic) BOOL enabled;
        [Export("enabled")]
        bool Enabled { [Bind("isEnabled")] get; set; }

        // @property (readonly, nonatomic, weak) MBRecognizerResult * _Nullable baseResult;
        [NullAllowed, Export("baseResult", ArgumentSemantic.Weak)]
        MBRecognizerResult BaseResult { get; }

        // -(UIInterfaceOrientationMask)getOptimalHudOrientation;
        [Export("getOptimalHudOrientation")]
        UIInterfaceOrientationMask OptimalHudOrientation { get; }
    }

    // @interface MBFrameGrabberRecognizer : MBRecognizer <NSCopying>
    
    [BaseType(typeof(MBRecognizer))]
    [DisableDefaultCtor]
    interface MBFrameGrabberRecognizer : INSCopying
    {
        // -(instancetype _Nonnull)initWithFrameGrabberDelegate:(id<MBFrameGrabberRecognizerDelegate> _Nonnull)frameGrabberDelegate;
        [Export("initWithFrameGrabberDelegate:")]
        IntPtr Constructor(MBFrameGrabberRecognizerDelegate frameGrabberDelegate);

        // @property (assign, nonatomic) BOOL grabFocusedFrames;
        [Export("grabFocusedFrames")]
        bool GrabFocusedFrames { get; set; }

        // @property (assign, nonatomic) BOOL grabUnfocusedFrames;
        [Export("grabUnfocusedFrames")]
        bool GrabUnfocusedFrames { get; set; }
    }

    // @protocol MBFrameGrabberRecognizerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface MBFrameGrabberRecognizerDelegate
    {
        // @required -(void)onFrameAvailable:(MBImage * _Nonnull)cameraFrame isFocused:(BOOL)focused frameQuality:(CGFloat)frameQuality;
        [Abstract]
        [Export("onFrameAvailable:isFocused:frameQuality:")]
        void IsFocused(MBImage cameraFrame, bool focused, nfloat frameQuality);
    }

    // @interface MBSuccessFrameGrabberRecognizerResult : MBRecognizerResult <NSCopying>
    
    [BaseType(typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBSuccessFrameGrabberRecognizerResult : INSCopying
    {
        // @property (readonly, nonatomic, strong) MBImage * _Nonnull successFrame;
        [Export("successFrame", ArgumentSemantic.Strong)]
        MBImage SuccessFrame { get; }
    }

    // @interface MBSuccessFrameGrabberRecognizer : MBRecognizer <NSCopying>
    
    [BaseType(typeof(MBRecognizer))]
    [DisableDefaultCtor]
    interface MBSuccessFrameGrabberRecognizer : INSCopying
    {
        // -(instancetype _Nonnull)initWithRecognizer:(MBRecognizer * _Nonnull)recognizer __attribute__((objc_designated_initializer));
        [Export("initWithRecognizer:")]
        [DesignatedInitializer]
        IntPtr Constructor(MBRecognizer recognizer);

        // @property (readonly, nonatomic, strong) MBSuccessFrameGrabberRecognizerResult * _Nonnull result;
        [Export("result", ArgumentSemantic.Strong)]
        MBSuccessFrameGrabberRecognizerResult Result { get; }

        // @property (readonly, nonatomic, strong) MBRecognizer * _Nonnull slaveRecognizer;
        [Export("slaveRecognizer", ArgumentSemantic.Strong)]
        MBRecognizer SlaveRecognizer { get; }
    }

    // @interface MBQuadrangle : NSObject
    
    [BaseType(typeof(NSObject))]
    interface MBQuadrangle
    {
        // @property (assign, nonatomic) CGPoint upperLeft;
        [Export("upperLeft", ArgumentSemantic.Assign)]
        CGPoint UpperLeft { get; set; }

        // @property (assign, nonatomic) CGPoint upperRight;
        [Export("upperRight", ArgumentSemantic.Assign)]
        CGPoint UpperRight { get; set; }

        // @property (assign, nonatomic) CGPoint lowerLeft;
        [Export("lowerLeft", ArgumentSemantic.Assign)]
        CGPoint LowerLeft { get; set; }

        // @property (assign, nonatomic) CGPoint lowerRight;
        [Export("lowerRight", ArgumentSemantic.Assign)]
        CGPoint LowerRight { get; set; }

        // -(instancetype _Nonnull)initWithUpperLeft:(CGPoint)upperLeft upperRight:(CGPoint)upperRight lowerLeft:(CGPoint)lowerLeft lowerRight:(CGPoint)lowerRight;
        [Export("initWithUpperLeft:upperRight:lowerLeft:lowerRight:")]
        IntPtr Constructor(CGPoint upperLeft, CGPoint upperRight, CGPoint lowerLeft, CGPoint lowerRight);

        // -(NSArray * _Nonnull)toPointsArray;
        [Export("toPointsArray")]
        NSValue[] ToPointsArray { get; }

        // -(instancetype _Nonnull)quadrangleWithTransformation:(CGAffineTransform)transform;
        [Export("quadrangleWithTransformation:")]
        MBQuadrangle QuadrangleWithTransformation(CGAffineTransform transform);

        // -(CGPoint)center;
        [Export("center")]
        CGPoint Center { get; }
    }

    // @interface MBMrtdSpecification : NSObject <NSCopying>
    
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBMrtdSpecification : INSCopying
    {
        // +(instancetype _Nonnull)createFromPreset:(MBMrtdSpecificationPreset)preset;
        [Static]
        [Export("createFromPreset:")]
        MBMrtdSpecification CreateFromPreset(MBMrtdSpecificationPreset preset);
    }

    // @protocol MBNativeResult
    [Protocol]
    interface MBNativeResult
    {
        // @required -(NSObject * _Nullable)nativeResult;
        [Abstract]
        [NullAllowed, Export("nativeResult")]
        NSObject NativeResult { get; }

        // @required -(NSString * _Nullable)stringResult;
        [Abstract]
        [NullAllowed, Export("stringResult")]
        string StringResult { get; }
    }

    // @interface MBDateResult : NSObject <MBNativeResult>
    
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBDateResult : MBNativeResult
    {
        // -(instancetype _Nonnull)initWithDay:(NSInteger)day month:(NSInteger)month year:(NSInteger)year originalDateString:(NSString * _Nullable)originalDateString __attribute__((objc_designated_initializer));
        [Export("initWithDay:month:year:originalDateString:")]
        [DesignatedInitializer]
        IntPtr Constructor(nint day, nint month, nint year, [NullAllowed] string originalDateString);

        // @property (readonly, nonatomic) NSString * _Nullable originalDateString;
        [NullAllowed, Export("originalDateString")]
        string OriginalDateString { get; }

        // @property (readonly, nonatomic) NSDate * _Nonnull date;
        [Export("date")]
        NSDate Date { get; }

        // @property (readonly, assign, nonatomic) NSInteger day;
        [Export("day")]
        nint Day { get; }

        // @property (readonly, assign, nonatomic) NSInteger month;
        [Export("month")]
        nint Month { get; }

        // @property (readonly, assign, nonatomic) NSInteger year;
        [Export("year")]
        nint Year { get; }

        // +(instancetype _Nonnull)dateResultWithDay:(NSInteger)day month:(NSInteger)month year:(NSInteger)year originalDateString:(NSString * _Nullable)originalDateString;
        [Static]
        [Export("dateResultWithDay:month:year:originalDateString:")]
        MBDateResult DateResultWithDay(nint day, nint month, nint year, [NullAllowed] string originalDateString);
    }

    // @interface MBTemplatingClass : NSObject
    
    [BaseType(typeof(NSObject))]
    interface MBTemplatingClass
    {
        // -(void)setTemplatingClassifier:(id<MBTemplatingClassifier> _Nullable)templatingClassifier;
        [Export("setTemplatingClassifier:")]
        void SetTemplatingClassifier([NullAllowed] MBTemplatingClassifier templatingClassifier);
    }

    // @protocol MBTemplatingClassifier <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface MBTemplatingClassifier
    {
        // @required -(BOOL)classify;
        [Abstract]
        [Export("classify")]
        bool Classify();
    }

    // @interface MBTemplatingRecognizerResult : MBRecognizerResult
    
    [BaseType(typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBTemplatingRecognizerResult
    {
        // @property (readonly, nonatomic, strong) MBTemplatingClass * _Nullable templatingClass;
        [NullAllowed, Export("templatingClass", ArgumentSemantic.Strong)]
        MBTemplatingClass TemplatingClass { get; }
    }

    // @interface MBTemplatingRecognizer : MBRecognizer
    
    [BaseType(typeof(MBRecognizer))]
    [DisableDefaultCtor]
    interface MBTemplatingRecognizer
    {
        // @property (readonly, nonatomic, strong) MBTemplatingRecognizerResult * _Nonnull templatingResult;
        [Export("templatingResult", ArgumentSemantic.Strong)]
        MBTemplatingRecognizerResult TemplatingResult { get; }

        // @property (assign, nonatomic) BOOL useGlareDetector;
        [Export("useGlareDetector")]
        bool UseGlareDetector { get; set; }

        // @property (readonly, nonatomic, strong) NSArray<__kindof MBTemplatingClass *> * _Nullable templatingClasses;
        [NullAllowed, Export("templatingClasses", ArgumentSemantic.Strong)]
        MBTemplatingClass[] TemplatingClasses { get; }

        // -(void)setTemplatingClasses:(NSArray<__kindof MBTemplatingClass *> * _Nullable)templatingClasses;
        [Export("setTemplatingClasses:")]
        void SetTemplatingClasses([NullAllowed] MBTemplatingClass[] templatingClasses);
    }

    // @interface MBProcessorResult : NSObject
    
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBProcessorResult
    {
        // @property (readonly, assign, nonatomic) MBProcessorResultState resultState;
        [Export("resultState", ArgumentSemantic.Assign)]
        MBProcessorResultState ResultState { get; }
    }

    // @interface MBProcessor : MBEntity
    
    [BaseType(typeof(MBEntity))]
    interface MBProcessor
    {
        // @property (readonly, nonatomic, weak) MBProcessorResult * _Nullable baseResult;
        [NullAllowed, Export("baseResult", ArgumentSemantic.Weak)]
        MBProcessorResult BaseResult { get; }
    }

    // @interface MBOcrLayout : NSObject
    
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBOcrLayout
    {
        // @property (nonatomic) CGRect box;
        [Export("box", ArgumentSemantic.Assign)]
        CGRect Box { get; set; }

        // @property (nonatomic) NSArray<MBOcrBlock *> * _Nonnull blocks;
        [Export("blocks", ArgumentSemantic.Assign)]
        MBOcrBlock[] Blocks { get; set; }

        // @property (nonatomic) CGAffineTransform transform;
        [Export("transform", ArgumentSemantic.Assign)]
        CGAffineTransform Transform { get; set; }

        // @property (nonatomic) BOOL transformInvalid;
        [Export("transformInvalid")]
        bool TransformInvalid { get; set; }

        // @property (nonatomic) MBPosition * _Nonnull position;
        [Export("position", ArgumentSemantic.Assign)]
        MBPosition Position { get; set; }

        // @property (nonatomic) BOOL flipped;
        [Export("flipped")]
        bool Flipped { get; set; }

        // -(instancetype _Nonnull)initWithOcrBlocks:(NSArray<MBOcrBlock *> * _Nonnull)ocrBlocks transform:(CGAffineTransform)transform box:(CGRect)box flipped:(BOOL)flipped __attribute__((objc_designated_initializer));
        [Export("initWithOcrBlocks:transform:box:flipped:")]
        [DesignatedInitializer]
        IntPtr Constructor(MBOcrBlock[] ocrBlocks, CGAffineTransform transform, CGRect box, bool flipped);

        // -(instancetype _Nonnull)initWithOcrBlocks:(NSArray * _Nonnull)ocrBlocks;
        [Export("initWithOcrBlocks:")]
        IntPtr Constructor(MBOcrBlock[] ocrBlocks);

        // -(NSString * _Nonnull)string;
        [Export("string")]
        string String { get; }
    }

    // @interface MBOcrBlock : NSObject
    
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBOcrBlock
    {
        // @property (nonatomic) NSArray<MBOcrLine *> * _Nonnull lines;
        [Export("lines", ArgumentSemantic.Assign)]
        MBOcrLine[] Lines { get; set; }

        // @property (nonatomic) MBPosition * _Nonnull position;
        [Export("position", ArgumentSemantic.Assign)]
        MBPosition Position { get; set; }

        // -(instancetype _Nonnull)initWithOcrLines:(NSArray<MBOcrLine *> * _Nonnull)ocrLines position:(MBPosition * _Nonnull)position __attribute__((objc_designated_initializer));
        [Export("initWithOcrLines:position:")]
        [DesignatedInitializer]
        IntPtr Constructor(MBOcrLine[] ocrLines, MBPosition position);

        // -(NSString * _Nonnull)string;
        [Export("string")]
        string String { get; }
    }

    // @interface MBOcrLine : NSObject
    
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBOcrLine
    {
        // @property (nonatomic) NSArray<MBCharWithVariants *> * _Nonnull chars;
        [Export("chars", ArgumentSemantic.Assign)]
        MBCharWithVariants[] Chars { get; set; }

        // @property (nonatomic) MBPosition * _Nonnull position;
        [Export("position", ArgumentSemantic.Assign)]
        MBPosition Position { get; set; }

        // -(instancetype _Nonnull)initWithOcrChars:(NSArray<MBCharWithVariants *> * _Nonnull)ocrChars position:(MBPosition * _Nonnull)position __attribute__((objc_designated_initializer));
        [Export("initWithOcrChars:position:")]
        [DesignatedInitializer]
        IntPtr Constructor(MBCharWithVariants[] ocrChars, MBPosition position);

        // -(NSString * _Nonnull)string;
        [Export("string")]
        string String { get; }
    }

    // @interface MBCharWithVariants : NSObject
    
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBCharWithVariants
    {
        // @property (nonatomic) MBOcrChar * _Nonnull character;
        [Export("character", ArgumentSemantic.Assign)]
        MBOcrChar Character { get; set; }

        // @property (nonatomic) NSSet * _Nonnull variants;
        [Export("variants", ArgumentSemantic.Assign)]
        NSSet Variants { get; set; }

        // -(instancetype _Nonnull)initWithValue:(MBOcrChar * _Nonnull)character __attribute__((objc_designated_initializer));
        [Export("initWithValue:")]
        [DesignatedInitializer]
        IntPtr Constructor(MBOcrChar character);
    }

    // @interface MBOcrChar : NSObject
    
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBOcrChar
    {
        // @property (nonatomic) unichar value;
        [Export("value")]
        ushort Value { get; set; }

        // @property (nonatomic) MBPosition * _Nonnull position;
        [Export("position", ArgumentSemantic.Assign)]
        MBPosition Position { get; set; }

        // @property (nonatomic) CGFloat height;
        [Export("height")]
        nfloat Height { get; set; }

        // @property (getter = isUncertain, nonatomic) BOOL uncertain;
        [Export("uncertain")]
        bool Uncertain { [Bind("isUncertain")] get; set; }

        // @property (nonatomic) NSInteger quality;
        [Export("quality")]
        nint Quality { get; set; }

        // @property (nonatomic) MBOcrFont font;
        [Export("font", ArgumentSemantic.Assign)]
        MBOcrFont Font { get; set; }

        // -(instancetype _Nonnull)initWithValue:(unichar)value position:(MBPosition * _Nonnull)position height:(CGFloat)height __attribute__((objc_designated_initializer));
        [Export("initWithValue:position:height:")]
        [DesignatedInitializer]
        IntPtr Constructor(ushort value, MBPosition position, nfloat height);
    }

    // @interface MBPosition : NSObject
    
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBPosition
    {
        // @property (nonatomic) CGPoint ul;
        [Export("ul", ArgumentSemantic.Assign)]
        CGPoint Ul { get; set; }

        // @property (nonatomic) CGPoint ur;
        [Export("ur", ArgumentSemantic.Assign)]
        CGPoint Ur { get; set; }

        // @property (nonatomic) CGPoint ll;
        [Export("ll", ArgumentSemantic.Assign)]
        CGPoint Ll { get; set; }

        // @property (nonatomic) CGPoint lr;
        [Export("lr", ArgumentSemantic.Assign)]
        CGPoint Lr { get; set; }

        // -(instancetype _Nonnull)initWithUpperLeft:(CGPoint)ul upperRight:(CGPoint)ur lowerLeft:(CGPoint)ll lowerRight:(CGPoint)lr __attribute__((objc_designated_initializer));
        [Export("initWithUpperLeft:upperRight:lowerLeft:lowerRight:")]
        [DesignatedInitializer]
        IntPtr Constructor(CGPoint ul, CGPoint ur, CGPoint ll, CGPoint lr);

        // -(MBPosition * _Nonnull)positionWithOffset:(CGPoint)offset;
        [Export("positionWithOffset:")]
        MBPosition PositionWithOffset(CGPoint offset);

        // -(CGRect)rect;
        [Export("rect")]
        CGRect Rect { get; }

        // -(CGPoint)center;
        [Export("center")]
        CGPoint Center { get; }

        // -(CGFloat)height;
        [Export("height")]
        nfloat Height { get; }
    }

    // @interface MBImageReturnProcessorResult : MBProcessorResult <NSCopying>
    
    [BaseType(typeof(MBProcessorResult))]
    [DisableDefaultCtor]
    interface MBImageReturnProcessorResult : INSCopying
    {
        // @property (readonly, nonatomic, strong) MBImage * _Nullable rawImage;
        [NullAllowed, Export("rawImage", ArgumentSemantic.Strong)]
        MBImage RawImage { get; }

        // @property (readonly, nonatomic, strong) NSData * _Nullable encodedImage;
        [NullAllowed, Export("encodedImage", ArgumentSemantic.Strong)]
        NSData EncodedImage { get; }
    }

    // @interface MBImageReturnProcessor : MBProcessor <NSCopying>
    
    [BaseType(typeof(MBProcessor))]
    interface MBImageReturnProcessor : INSCopying
    {
        // @property (readonly, nonatomic, strong) MBImageReturnProcessorResult * _Nonnull result;
        [Export("result", ArgumentSemantic.Strong)]
        MBImageReturnProcessorResult Result { get; }

        // @property (assign, nonatomic) BOOL encodeImage;
        [Export("encodeImage")]
        bool EncodeImage { get; set; }
    }

    // @protocol MBFaceImageResult
    [Protocol]
    interface IMBFaceImageResult
    {
        // @required @property (readonly, nonatomic) MBImage * _Nullable faceImage;
        [Abstract]
        [NullAllowed, Export("faceImage")]
        MBImage FaceImage { get; }
    }

    // @protocol MBSignatureImageResult
    [Protocol]
    interface IMBSignatureImageResult
    {
        // @required @property (readonly, nonatomic) MBImage * _Nullable signatureImage;
        [Abstract]
        [NullAllowed, Export("signatureImage")]
        MBImage SignatureImage { get; }
    }

    // @protocol MBFullDocumentImageResult
    [Protocol]
    interface IMBFullDocumentImageResult
    {
        // @required @property (readonly, nonatomic) MBImage * _Nullable fullDocumentImage;
        [Abstract]
        [NullAllowed, Export("fullDocumentImage")]
        MBImage FullDocumentImage { get; }
    }

    // @protocol MBFaceImage
    [Protocol]
    interface IMBFaceImage
    {
        // @required @property (assign, nonatomic) BOOL returnFaceImage;
        [Abstract]
        [Export("returnFaceImage")]
        bool ReturnFaceImage { get; set; }
    }

    // @protocol MBSignatureImage
    [Protocol]
    interface IMBSignatureImage
    {
        // @required @property (assign, nonatomic) BOOL returnSignatureImage;
        [Abstract]
        [Export("returnSignatureImage")]
        bool ReturnSignatureImage { get; set; }
    }

    // @protocol MBFullDocumentImage
    [Protocol]
    interface IMBFullDocumentImage
    {
        // @required @property (assign, nonatomic) BOOL returnFullDocumentImage;
        [Abstract]
        [Export("returnFullDocumentImage")]
        bool ReturnFullDocumentImage { get; set; }
    }

    // @protocol MBFullDocumentImageDpi
    [Protocol]
    interface IMBFullDocumentImageDpi
    {
        // @required @property (assign, nonatomic) NSUInteger fullDocumentImageDpi;
        [Abstract]
        [Export("fullDocumentImageDpi")]
        nuint FullDocumentImageDpi { get; set; }
    }

    // @protocol IMBAgeResult
    [Protocol]
    interface IMBAgeResult
    {
        // @required @property (assign, nonatomic) NSInteger fullDocumentImageDpi;
        [Abstract]
        [Export("age")]
        int Age { get; set; }
    }

    // @protocol MBDocumentExpirationCheckResult
	[Protocol]
	interface IMBDocumentExpirationCheckResult
	{
		// @required -(BOOL)isExpired;
		[Abstract]
		[Export ("isExpired")]
		bool Expired { get; }
	}

   // @interface MBMrzResult : NSObject
	[iOS (8,0)]
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBMrzResult : IMBAgeResult
	{
		// @property (readonly, assign, nonatomic) MBMrtdDocumentType documentType;
		[Export ("documentType", ArgumentSemantic.Assign)]
		MBMrtdDocumentType DocumentType { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nonnull primaryID;
		[Export ("primaryID", ArgumentSemantic.Strong)]
		string PrimaryID { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nonnull secondaryID;
		[Export ("secondaryID", ArgumentSemantic.Strong)]
		string SecondaryID { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nonnull issuer;
		[Export ("issuer", ArgumentSemantic.Strong)]
		string Issuer { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nonnull issuerName;
		[Export ("issuerName", ArgumentSemantic.Strong)]
		string IssuerName { get; }

		// @property (readonly, nonatomic, strong) MBDateResult * _Nonnull dateOfBirth;
		[Export ("dateOfBirth", ArgumentSemantic.Strong)]
		MBDateResult DateOfBirth { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nonnull documentNumber;
		[Export ("documentNumber", ArgumentSemantic.Strong)]
		string DocumentNumber { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nonnull nationality;
		[Export ("nationality", ArgumentSemantic.Strong)]
		string Nationality { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nonnull gender;
		[Export ("gender", ArgumentSemantic.Strong)]
		string Gender { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nonnull documentCode;
		[Export ("documentCode", ArgumentSemantic.Strong)]
		string DocumentCode { get; }

		// @property (readonly, nonatomic, strong) MBDateResult * _Nonnull dateOfExpiry;
		[Export ("dateOfExpiry", ArgumentSemantic.Strong)]
		MBDateResult DateOfExpiry { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nonnull opt1;
		[Export ("opt1", ArgumentSemantic.Strong)]
		string Opt1 { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nonnull opt2;
		[Export ("opt2", ArgumentSemantic.Strong)]
		string Opt2 { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nonnull alienNumber;
		[Export ("alienNumber", ArgumentSemantic.Strong)]
		string AlienNumber { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nonnull applicationReceiptNumber;
		[Export ("applicationReceiptNumber", ArgumentSemantic.Strong)]
		string ApplicationReceiptNumber { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nonnull immigrantCaseNumber;
		[Export ("immigrantCaseNumber", ArgumentSemantic.Strong)]
		string ImmigrantCaseNumber { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nonnull mrzText;
		[Export ("mrzText", ArgumentSemantic.Strong)]
		string MrzText { get; }

		// @property (readonly, assign, nonatomic) BOOL isParsed;
		[Export ("isParsed")]
		bool IsParsed { get; }

		// @property (readonly, assign, nonatomic) BOOL isVerified;
		[Export ("isVerified")]
		bool IsVerified { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nonnull sanitizedOpt1;
		[Export ("sanitizedOpt1", ArgumentSemantic.Strong)]
		string SanitizedOpt1 { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nonnull sanitizedOpt2;
		[Export ("sanitizedOpt2", ArgumentSemantic.Strong)]
		string SanitizedOpt2 { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nonnull sanitizedNationality;
		[Export ("sanitizedNationality", ArgumentSemantic.Strong)]
		string SanitizedNationality { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nonnull sanitizedIssuer;
		[Export ("sanitizedIssuer", ArgumentSemantic.Strong)]
		string SanitizedIssuer { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nonnull sanitizedDocumentCode;
		[Export ("sanitizedDocumentCode", ArgumentSemantic.Strong)]
		string SanitizedDocumentCode { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nonnull sanitizedDocumentNumber;
		[Export ("sanitizedDocumentNumber", ArgumentSemantic.Strong)]
		string SanitizedDocumentNumber { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nonnull nationalityName;
		[Export ("nationalityName", ArgumentSemantic.Strong)]
		string NationalityName { get; }
	}

    // @interface MBClassInfo : NSObject
	[iOS (8,0)]
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBClassInfo
	{
		// @property (readonly, assign, nonatomic) MBCountry country;
		[Export ("country", ArgumentSemantic.Assign)]
		MBCountry Country { get; }

		// @property (readonly, assign, nonatomic) MBRegion region;
		[Export ("region", ArgumentSemantic.Assign)]
		MBRegion Region { get; }

		// @property (readonly, assign, nonatomic) MBType type;
		[Export ("type", ArgumentSemantic.Assign)]
		MBType Type { get; }
	}

    // @protocol MBGlareDetection
    [Protocol]
    interface IMBGlareDetection
    {
        // @required @property (assign, nonatomic) BOOL detectGlare;
        [Abstract]
        [Export("detectGlare")]
        bool DetectGlare { get; set; }
    }

    // @protocol MBEncodedFaceImageResult
    [Protocol]
    interface IMBEncodedFaceImageResult
    {
        // @required @property (readonly, nonatomic) NSData * _Nullable encodedFaceImage;
        [Abstract]
        [NullAllowed, Export("encodedFaceImage")]
        NSData EncodedFaceImage { get; }
    }

    // @protocol MBFaceImageDpi
    [Protocol]
    interface IMBFaceImageDpi
    {
        // @required @property (assign, nonatomic) NSUInteger faceImageDpi;
        [Abstract]
        [Export("faceImageDpi")]
        nuint FaceImageDpi { get; set; }
    }

    // @protocol MBSignatureImageDpi
    [Protocol]
    interface IMBSignatureImageDpi
    {
        // @required @property (assign, nonatomic) NSUInteger signatureImageDpi;
        [Abstract]
        [Export("signatureImageDpi")]
        nuint SignatureImageDpi { get; set; }
    }

    // @protocol MBEncodeFaceImage
    [Protocol]
    interface IMBEncodeFaceImage
    {
        // @required @property (assign, nonatomic) BOOL encodeFaceImage;
        [Abstract]
        [Export("encodeFaceImage")]
        bool EncodeFaceImage { get; set; }
    }

    // @protocol MBDigitalSignatureResult
    [Protocol]
    interface IMBDigitalSignatureResult
    {
        // @required @property (readonly, nonatomic) NSData * _Nullable digitalSignature;
        [Abstract]
        [NullAllowed, Export("digitalSignature")]
        NSData DigitalSignature { get; }

        // @required @property (readonly, nonatomic) NSUInteger digitalSignatureVersion;
        [Abstract]
        [Export("digitalSignatureVersion")]
        nuint DigitalSignatureVersion { get; }
    }

    // @protocol MBCombinedFullDocumentImageResult
    [Protocol]
    interface IMBCombinedFullDocumentImageResult
    {
        // @required @property (readonly, nonatomic) MBImage * _Nullable fullDocumentFrontImage;
        [Abstract]
        [NullAllowed, Export("fullDocumentFrontImage")]
        MBImage FullDocumentFrontImage { get; }

        // @required @property (readonly, nonatomic) MBImage * _Nullable fullDocumentBackImage;
        [Abstract]
        [NullAllowed, Export("fullDocumentBackImage")]
        MBImage FullDocumentBackImage { get; }
    }

    // @protocol MBEncodedSignatureImageResult
    [Protocol]
    interface IMBEncodedSignatureImageResult
    {
        // @required @property (readonly, nonatomic) NSData * _Nullable encodedSignatureImage;
        [Abstract]
        [NullAllowed, Export("encodedSignatureImage")]
        NSData EncodedSignatureImage { get; }
    }

    // @protocol MBEncodedCombinedFullDocumentImageResult
    [Protocol]
    interface IMBEncodedCombinedFullDocumentImageResult
    {
        // @required @property (readonly, nonatomic) NSData * _Nullable encodedFullDocumentFrontImage;
        [Abstract]
        [NullAllowed, Export("encodedFullDocumentFrontImage")]
        NSData EncodedFullDocumentFrontImage { get; }

        // @required @property (readonly, nonatomic) NSData * _Nullable encodedFullDocumentBackImage;
        [Abstract]
        [NullAllowed, Export("encodedFullDocumentBackImage")]
        NSData EncodedFullDocumentBackImage { get; }
    }

    interface IMBCombinedRecognizerResult {}

    // @protocol MBCombinedRecognizerResult
    [Protocol]   
    interface MBCombinedRecognizerResult
    {
        // @required @property (readonly, assign, nonatomic) MBDataMatchResult documentDataMatch;
        [Abstract]
        [Export ("documentDataMatch", ArgumentSemantic.Assign)]
        MBDataMatchResult DocumentDataMatch { get; }

        // @required @property (readonly, assign, nonatomic) BOOL scanningFirstSideDone;
        [Abstract]
        [Export("scanningFirstSideDone")]
        bool ScanningFirstSideDone { get; }
    }

    // @protocol MBCombinedRecognizer
    [Protocol]
    interface IMBCombinedRecognizer
    {
        // @required @property (readonly, nonatomic) MBRecognizerResult<MBCombinedRecognizerResult> * combinedResult;
        [Abstract]
        [Export("combinedResult")]
        IMBCombinedRecognizerResult CombinedResult { get; }
    }

    // @protocol MBDigitalSignature
    [Protocol]
    interface IMBDigitalSignature
    {
        // @required @property (assign, nonatomic) BOOL signResult;
        [Abstract]
        [Export("signResult")]
        bool SignResult { get; set; }
    }

    // @protocol MBEncodeFullDocumentImage
    [Protocol]
    interface IMBEncodeFullDocumentImage
    {
        // @required @property (assign, nonatomic) BOOL encodeFullDocumentImage;
        [Abstract]
        [Export("encodeFullDocumentImage")]
        bool EncodeFullDocumentImage { get; set; }
    }

    // @protocol MBEncodeSignatureImage
    [Protocol]
    interface IMBEncodeSignatureImage
    {
        // @required @property (assign, nonatomic) BOOL encodeSignatureImage;
        [Abstract]
        [Export("encodeSignatureImage")]
        bool EncodeSignatureImage { get; set; }
    }

    // @interface MBDocumentFaceRecognizerResult : MBRecognizerResult <NSCopying, MBFullDocumentImageResult, MBFaceImageResult>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBDocumentFaceRecognizerResult : INSCopying, IMBFullDocumentImageResult, IMBFaceImageResult
    {
        // @property (readonly, nonatomic) MBQuadrangle * _Nonnull documentLocation;
        [Export ("documentLocation")]
        MBQuadrangle DocumentLocation { get; }

        // @property (readonly, nonatomic) MBQuadrangle * _Nonnull faceLocation;
        [Export ("faceLocation")]
        MBQuadrangle FaceLocation { get; }
    }

    // @interface MBDocumentFaceRecognizer : MBRecognizer <NSCopying, MBFullDocumentImage, MBFullDocumentImageDpi, MBFaceImage, MBFaceImageDpi, MBFullDocumentImageExtensionFactors>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizer))]
    interface MBDocumentFaceRecognizer : INSCopying, IMBFullDocumentImage, IMBFullDocumentImageDpi, IMBFaceImage, IMBFaceImageDpi, IMBFullDocumentImageExtensionFactors
    {
        // @property (readonly, nonatomic, strong) MBDocumentFaceRecognizerResult * _Nonnull result;
        [Export ("result", ArgumentSemantic.Strong)]
        MBDocumentFaceRecognizerResult Result { get; }

        // @property (assign, nonatomic) MBDocumentFaceDetectorType detectorType;
        [Export ("detectorType", ArgumentSemantic.Assign)]
        MBDocumentFaceDetectorType DetectorType { get; set; }

        // @property (assign, nonatomic) NSUInteger numStableDetectionsThreshold;
        [Export ("numStableDetectionsThreshold")]
        nuint NumStableDetectionsThreshold { get; set; }
    }

    // @interface MBDriverLicenseDetailedInfo : NSObject
    [iOS (8,0)]
    [BaseType (typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBDriverLicenseDetailedInfo
    {
        // @property (readonly, nonatomic) NSString * _Nullable restrictions;
        [NullAllowed, Export ("restrictions")]
        string Restrictions { get; }

        // @property (readonly, nonatomic) NSString * _Nullable endorsements;
        [NullAllowed, Export ("endorsements")]
        string Endorsements { get; }

        // @property (readonly, nonatomic) NSString * _Nullable vehicleClass;
        [NullAllowed, Export ("vehicleClass")]
        string VehicleClass { get; }

        // @property (readonly, nonatomic) NSString * _Nullable conditions;
		[NullAllowed, Export ("conditions")]
		string Conditions { get; }
    }

    // @interface MBImageAnalysisResult : NSObject
	[iOS (8,0)]
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBImageAnalysisResult
	{
		// @property (readonly, assign, nonatomic) BOOL blurred;
		[Export ("blurred")]
		bool Blurred { get; }

		// @property (readonly, assign, nonatomic) MBDocumentImageColorStatus documentImageColorStatus;
		[Export ("documentImageColorStatus", ArgumentSemantic.Assign)]
		MBDocumentImageColorStatus DocumentImageColorStatus { get; }

		// @property (readonly, assign, nonatomic) MBImageAnalysisDetectionStatus documentImageMoireStatus;
		[Export ("documentImageMoireStatus", ArgumentSemantic.Assign)]
		MBImageAnalysisDetectionStatus DocumentImageMoireStatus { get; }

		// @property (readonly, assign, nonatomic) MBImageAnalysisDetectionStatus faceDetectionStatus;
		[Export ("faceDetectionStatus", ArgumentSemantic.Assign)]
		MBImageAnalysisDetectionStatus FaceDetectionStatus { get; }

		// @property (readonly, assign, nonatomic) MBImageAnalysisDetectionStatus mrzDetectionStatus;
		[Export ("mrzDetectionStatus", ArgumentSemantic.Assign)]
		MBImageAnalysisDetectionStatus MrzDetectionStatus { get; }

		// @property (readonly, assign, nonatomic) MBImageAnalysisDetectionStatus barcodeDetectionStatus;
		[Export ("barcodeDetectionStatus", ArgumentSemantic.Assign)]
		MBImageAnalysisDetectionStatus BarcodeDetectionStatus { get; }
	}

    // @interface MBBarcodeResult : NSObject
	[iOS (8,0)]
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBBarcodeResult
	{
		// @property (readonly, nonatomic, strong) NSData * _Nullable rawData;
		[NullAllowed, Export ("rawData", ArgumentSemantic.Strong)]
		NSData RawData { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nullable stringData;
		[NullAllowed, Export ("stringData", ArgumentSemantic.Strong)]
		string StringData { get; }

		// @property (readonly, assign, nonatomic) BOOL uncertain;
		[Export ("uncertain")]
		bool Uncertain { get; }

		// @property (readonly, assign, nonatomic) MBBarcodeType barcodeType;
		[Export ("barcodeType", ArgumentSemantic.Assign)]
		MBBarcodeType BarcodeType { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull firstName;
		[Export ("firstName")]
		string FirstName { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull lastName;
		[Export ("lastName")]
		string LastName { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull fullName;
		[Export ("fullName")]
		string FullName { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull additionalNameInformation;
		[Export ("additionalNameInformation")]
		string AdditionalNameInformation { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull address;
		[Export ("address")]
		string Address { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull placeOfBirth;
		[Export ("placeOfBirth")]
		string PlaceOfBirth { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull nationality;
		[Export ("nationality")]
		string Nationality { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull race;
		[Export ("race")]
		string Race { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull religion;
		[Export ("religion")]
		string Religion { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull profession;
		[Export ("profession")]
		string Profession { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull maritalStatus;
		[Export ("maritalStatus")]
		string MaritalStatus { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull residentialStatus;
		[Export ("residentialStatus")]
		string ResidentialStatus { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull employer;
		[Export ("employer")]
		string Employer { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull sex;
		[Export ("sex")]
		string Sex { get; }

		// @property (readonly, nonatomic) MBDateResult * _Nonnull dateOfBirth;
		[Export ("dateOfBirth")]
		MBDateResult DateOfBirth { get; }

		// @property (readonly, nonatomic) MBDateResult * _Nonnull dateOfIssue;
		[Export ("dateOfIssue")]
		MBDateResult DateOfIssue { get; }

		// @property (readonly, nonatomic) MBDateResult * _Nonnull dateOfExpiry;
		[Export ("dateOfExpiry")]
		MBDateResult DateOfExpiry { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull documentNumber;
		[Export ("documentNumber")]
		string DocumentNumber { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull personalIdNumber;
		[Export ("personalIdNumber")]
		string PersonalIdNumber { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull documentAdditionalNumber;
		[Export ("documentAdditionalNumber")]
		string DocumentAdditionalNumber { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull issuingAuthority;
		[Export ("issuingAuthority")]
		string IssuingAuthority { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull street;
		[Export ("street")]
		string Street { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull postalCode;
		[Export ("postalCode")]
		string PostalCode { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull city;
		[Export ("city")]
		string City { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull jurisdiction;
		[Export ("jurisdiction")]
		string Jurisdiction { get; }

		// @property (readonly, nonatomic) MBDriverLicenseDetailedInfo * _Nullable driverLicenseDetailedInfo;
		[NullAllowed, Export ("driverLicenseDetailedInfo")]
		MBDriverLicenseDetailedInfo DriverLicenseDetailedInfo { get; }

		// @property (readonly, assign, nonatomic) BOOL empty;
		[Export ("empty")]
		bool Empty { get; }
	}

	// @interface MBVizResult : NSObject
	[iOS (8,0)]
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBVizResult
	{
		// @property (readonly, nonatomic) NSString * _Nonnull firstName;
		[Export ("firstName")]
		string FirstName { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull lastName;
		[Export ("lastName")]
		string LastName { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull fullName;
		[Export ("fullName")]
		string FullName { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull additionalNameInformation;
		[Export ("additionalNameInformation")]
		string AdditionalNameInformation { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull localizedName;
		[Export ("localizedName")]
		string LocalizedName { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull address;
		[Export ("address")]
		string Address { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull additionalAddressInformation;
		[Export ("additionalAddressInformation")]
		string AdditionalAddressInformation { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull placeOfBirth;
		[Export ("placeOfBirth")]
		string PlaceOfBirth { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull nationality;
		[Export ("nationality")]
		string Nationality { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull race;
		[Export ("race")]
		string Race { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull religion;
		[Export ("religion")]
		string Religion { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull profession;
		[Export ("profession")]
		string Profession { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull maritalStatus;
		[Export ("maritalStatus")]
		string MaritalStatus { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull residentialStatus;
		[Export ("residentialStatus")]
		string ResidentialStatus { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull employer;
		[Export ("employer")]
		string Employer { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull sex;
		[Export ("sex")]
		string Sex { get; }

		// @property (readonly, nonatomic) MBDateResult * _Nonnull dateOfBirth;
		[Export ("dateOfBirth")]
		MBDateResult DateOfBirth { get; }

		// @property (readonly, nonatomic) MBDateResult * _Nonnull dateOfIssue;
		[Export ("dateOfIssue")]
		MBDateResult DateOfIssue { get; }

		// @property (readonly, nonatomic) MBDateResult * _Nonnull dateOfExpiry;
		[Export ("dateOfExpiry")]
		MBDateResult DateOfExpiry { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull documentNumber;
		[Export ("documentNumber")]
		string DocumentNumber { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull personalIdNumber;
		[Export ("personalIdNumber")]
		string PersonalIdNumber { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull documentAdditionalNumber;
		[Export ("documentAdditionalNumber")]
		string DocumentAdditionalNumber { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull additionalPersonalIdNumber;
		[Export ("additionalPersonalIdNumber")]
		string AdditionalPersonalIdNumber { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull issuingAuthority;
		[Export ("issuingAuthority")]
		string IssuingAuthority { get; }

		// @property (readonly, nonatomic) MBDriverLicenseDetailedInfo * _Nullable driverLicenseDetailedInfo;
		[NullAllowed, Export ("driverLicenseDetailedInfo")]
		MBDriverLicenseDetailedInfo DriverLicenseDetailedInfo { get; }

		// @property (readonly, assign, nonatomic) BOOL empty;
		[Export ("empty")]
		bool Empty { get; }
	}

    // @interface MBRecognitionModeFilter : NSObject <NSCopying>
	[iOS (8,0)]
	[BaseType (typeof(NSObject))]
	interface MBRecognitionModeFilter : INSCopying
	{
		// @property (assign, nonatomic) BOOL enableMrzId;
		[Export ("enableMrzId")]
		bool EnableMrzId { get; set; }

		// @property (assign, nonatomic) BOOL enableMrzVisa;
		[Export ("enableMrzVisa")]
		bool EnableMrzVisa { get; set; }

		// @property (assign, nonatomic) BOOL enableMrzPassport;
		[Export ("enableMrzPassport")]
		bool EnableMrzPassport { get; set; }

		// @property (assign, nonatomic) BOOL enablePhotoId;
		[Export ("enablePhotoId")]
		bool EnablePhotoId { get; set; }

		// @property (assign, nonatomic) BOOL enableFullDocumentRecognition;
		[Export ("enableFullDocumentRecognition")]
		bool EnableFullDocumentRecognition { get; set; }
	}

   // @interface MBBlinkIdRecognizerResult : MBRecognizerResult <NSCopying, MBFullDocumentImageResult, MBEncodedFullDocumentImageResult, MBFaceImageResult, MBEncodedFaceImageResult, IMBAgeResult>
	[iOS (8,0)]
	[BaseType (typeof(MBRecognizerResult))]
	[DisableDefaultCtor]
	interface MBBlinkIdRecognizerResult : INSCopying, IMBFullDocumentImageResult, IMBEncodedFullDocumentImageResult, IMBFaceImageResult, IMBEncodedFaceImageResult, IMBAgeResult, IMBDocumentExpirationCheckResult
	{
		// @property (readonly, nonatomic) NSString * _Nullable address;
		[NullAllowed, Export ("address")]
		string Address { get; }

		// @property (readonly, nonatomic) MBDateResult * _Nullable dateOfBirth;
		[NullAllowed, Export ("dateOfBirth")]
		MBDateResult DateOfBirth { get; }

		// @property (readonly, nonatomic) MBDateResult * _Nullable dateOfExpiry;
		[NullAllowed, Export ("dateOfExpiry")]
		MBDateResult DateOfExpiry { get; }

		// @property (readonly, nonatomic) MBDateResult * _Nullable dateOfIssue;
		[NullAllowed, Export ("dateOfIssue")]
		MBDateResult DateOfIssue { get; }

		// @property (readonly, nonatomic) BOOL dateOfExpiryPermanent;
		[Export ("dateOfExpiryPermanent")]
		bool DateOfExpiryPermanent { get; }

		// @property (readonly, nonatomic) NSString * _Nullable documentNumber;
		[NullAllowed, Export ("documentNumber")]
		string DocumentNumber { get; }

		// @property (readonly, nonatomic) NSString * _Nullable firstName;
		[NullAllowed, Export ("firstName")]
		string FirstName { get; }

		// @property (readonly, nonatomic) NSString * _Nullable fullName;
		[NullAllowed, Export ("fullName")]
		string FullName { get; }

		// @property (readonly, nonatomic) NSString * _Nullable lastName;
		[NullAllowed, Export ("lastName")]
		string LastName { get; }

		// @property (readonly, nonatomic) NSString * _Nullable sex;
		[NullAllowed, Export ("sex")]
		string Sex { get; }

		// @property (readonly, nonatomic) NSString * _Nullable localizedName;
		[NullAllowed, Export ("localizedName")]
		string LocalizedName { get; }

		// @property (readonly, nonatomic) NSString * _Nullable additionalNameInformation;
		[NullAllowed, Export ("additionalNameInformation")]
		string AdditionalNameInformation { get; }

		// @property (readonly, nonatomic) NSString * _Nullable additionalAddressInformation;
		[NullAllowed, Export ("additionalAddressInformation")]
		string AdditionalAddressInformation { get; }

		// @property (readonly, nonatomic) NSString * _Nullable placeOfBirth;
		[NullAllowed, Export ("placeOfBirth")]
		string PlaceOfBirth { get; }

		// @property (readonly, nonatomic) NSString * _Nullable nationality;
		[NullAllowed, Export ("nationality")]
		string Nationality { get; }

		// @property (readonly, nonatomic) NSString * _Nullable race;
		[NullAllowed, Export ("race")]
		string Race { get; }

		// @property (readonly, nonatomic) NSString * _Nullable religion;
		[NullAllowed, Export ("religion")]
		string Religion { get; }

		// @property (readonly, nonatomic) NSString * _Nullable profession;
		[NullAllowed, Export ("profession")]
		string Profession { get; }

		// @property (readonly, nonatomic) NSString * _Nullable maritalStatus;
		[NullAllowed, Export ("maritalStatus")]
		string MaritalStatus { get; }

		// @property (readonly, nonatomic) NSString * _Nullable residentialStatus;
		[NullAllowed, Export ("residentialStatus")]
		string ResidentialStatus { get; }

		// @property (readonly, nonatomic) NSString * _Nullable employer;
		[NullAllowed, Export ("employer")]
		string Employer { get; }

		// @property (readonly, nonatomic) NSString * _Nullable personalIdNumber;
		[NullAllowed, Export ("personalIdNumber")]
		string PersonalIdNumber { get; }

		// @property (readonly, nonatomic) NSString * _Nullable documentAdditionalNumber;
		[NullAllowed, Export ("documentAdditionalNumber")]
		string DocumentAdditionalNumber { get; }

		// @property (readonly, nonatomic) NSString * _Nullable issuingAuthority;
		[NullAllowed, Export ("issuingAuthority")]
		string IssuingAuthority { get; }

		// @property (readonly, nonatomic) MBMrzResult * _Nonnull mrzResult;
		[Export ("mrzResult")]
		MBMrzResult MrzResult { get; }

		// @property (readonly, nonatomic) MBDriverLicenseDetailedInfo * _Nullable driverLicenseDetailedInfo;
		[NullAllowed, Export ("driverLicenseDetailedInfo")]
		MBDriverLicenseDetailedInfo DriverLicenseDetailedInfo { get; }

		// @property (readonly, nonatomic) MBClassInfo * _Nullable classInfo;
		[NullAllowed, Export ("classInfo")]
		MBClassInfo ClassInfo { get; }

		// @property (readonly, nonatomic) MBImageAnalysisResult * _Nullable imageAnalysisResult;
		[NullAllowed, Export ("imageAnalysisResult")]
		MBImageAnalysisResult ImageAnalysisResult { get; }

		// @property (readonly, nonatomic) MBBarcodeResult * _Nullable barcodeResult;
		[NullAllowed, Export ("barcodeResult")]
		MBBarcodeResult BarcodeResult { get; }

		// @property (readonly, nonatomic) MBVizResult * _Nullable vizResult;
		[NullAllowed, Export ("vizResult")]
		MBVizResult VizResult { get; }

		// @property (readonly, assign, nonatomic) MBProcessingStatus processingStatus;
		[Export ("processingStatus", ArgumentSemantic.Assign)]
		MBProcessingStatus ProcessingStatus { get; }

		// @property (readonly, assign, nonatomic) MBRecognitionMode recognitionMode;
		[Export ("recognitionMode", ArgumentSemantic.Assign)]
		MBRecognitionMode RecognitionMode { get; }
	}


    // @interface MBBlinkIdRecognizer : MBRecognizer <NSCopying, MBFaceImage, MBEncodeFaceImage, MBFaceImageDpi, MBFullDocumentImage, MBEncodeFullDocumentImage, MBFullDocumentImageDpi, MBFullDocumentImageExtensionFactors>
	[iOS (8,0)]
	[BaseType (typeof(MBRecognizer))]
	interface MBBlinkIdRecognizer : INSCopying, IMBFaceImage, IMBEncodeFaceImage, IMBFaceImageDpi, IMBFullDocumentImage, IMBEncodeFullDocumentImage, IMBFullDocumentImageDpi, IMBFullDocumentImageExtensionFactors
	{
		// @property (readonly, nonatomic, strong) MBBlinkIdRecognizerResult * _Nonnull result;
		[Export ("result", ArgumentSemantic.Strong)]
		MBBlinkIdRecognizerResult Result { get; }

		// @property (nonatomic, weak) id<MBBlinkIdRecognizerDelegate> _Nullable classifierDelegate;
		[NullAllowed, Export ("classifierDelegate", ArgumentSemantic.Weak)]
		NSObject WeakClassifierDelegate { get; set; }

		// @property (assign, nonatomic) BOOL allowBlurFilter;
		[Export ("allowBlurFilter")]
		bool AllowBlurFilter { get; set; }

		// @property (assign, nonatomic) BOOL allowUnparsedMrzResults;
		[Export ("allowUnparsedMrzResults")]
		bool AllowUnparsedMrzResults { get; set; }

		// @property (assign, nonatomic) BOOL allowUnverifiedMrzResults;
		[Export ("allowUnverifiedMrzResults")]
		bool AllowUnverifiedMrzResults { get; set; }

        // @property (assign, nonatomic) CGFloat paddingEdge;
		[Export ("paddingEdge")]
		nfloat PaddingEdge { get; set; }

        // @property (assign, nonatomic) BOOL validateResultCharacters;
		[Export ("validateResultCharacters")]
		bool ValidateResultCharacters { get; set; }

		// @property (assign, nonatomic) MBAnonymizationMode anonymizationMode;
		[Export ("anonymizationMode", ArgumentSemantic.Assign)]
		MBAnonymizationMode AnonymizationMode { get; set; }

        // @property (nonatomic, strong) MBRecognitionModeFilter * _Nonnull recognitionModeFilter;
		[Export ("recognitionModeFilter", ArgumentSemantic.Strong)]
		MBRecognitionModeFilter RecognitionModeFilter { get; set; }
	}

    // @protocol MBBlinkIdRecognizerDelegate <NSObject>
    [Protocol, Model]
    [BaseType (typeof(NSObject))]
    interface MBBlinkIdRecognizerDelegate
    {
        // @optional -(void)onImageAvailable:(MBImage * _Nullable)dewarpedImage;
        [Export ("onImageAvailable:")]
        void OnImageAvailable ([NullAllowed] MBImage dewarpedImage);

        // @optional -(void)onDocumentSupportStatus:(BOOL)isDocumentSupported;
        [Export ("onDocumentSupportStatus:")]
        void OnDocumentSupportStatus (bool isDocumentSupported);

        // @optional -(BOOL)classInfoFilter:(MBClassInfo * _Nullable)classInfo;
		[Export ("classInfoFilter:")]
		bool ClassInfoFilter ([NullAllowed] MBClassInfo classInfo);

		// @optional -(void)onBarcodeScanningStarted;
		[Export ("onBarcodeScanningStarted")]
		void OnBarcodeScanningStarted ();
    }

    // @interface MBBlinkIdCombinedRecognizerResult : MBRecognizerResult <NSCopying, MBCombinedRecognizerResult, MBDigitalSignatureResult, MBFaceImageResult, MBEncodedFaceImageResult, MBCombinedFullDocumentImageResult, MBEncodedCombinedFullDocumentImageResult, IMBAgeResult>
	[iOS (8,0)]
	[BaseType (typeof(MBRecognizerResult))]
	[DisableDefaultCtor]
	interface MBBlinkIdCombinedRecognizerResult : INSCopying, MBCombinedRecognizerResult, IMBDigitalSignatureResult, IMBFaceImageResult, IMBEncodedFaceImageResult, IMBCombinedFullDocumentImageResult, IMBEncodedCombinedFullDocumentImageResult, IMBAgeResult, IMBDocumentExpirationCheckResult
	{
		// @property (readonly, nonatomic) NSString * _Nullable address;
		[NullAllowed, Export ("address")]
		string Address { get; }

		// @property (readonly, nonatomic) MBDateResult * _Nullable dateOfBirth;
		[NullAllowed, Export ("dateOfBirth")]
		MBDateResult DateOfBirth { get; }

		// @property (readonly, nonatomic) MBDateResult * _Nullable dateOfExpiry;
		[NullAllowed, Export ("dateOfExpiry")]
		MBDateResult DateOfExpiry { get; }

		// @property (readonly, nonatomic) MBDateResult * _Nullable dateOfIssue;
		[NullAllowed, Export ("dateOfIssue")]
		MBDateResult DateOfIssue { get; }

		// @property (readonly, nonatomic) BOOL dateOfExpiryPermanent;
		[Export ("dateOfExpiryPermanent")]
		bool DateOfExpiryPermanent { get; }

		// @property (readonly, nonatomic) NSString * _Nullable documentNumber;
		[NullAllowed, Export ("documentNumber")]
		string DocumentNumber { get; }

		// @property (readonly, nonatomic) NSString * _Nullable firstName;
		[NullAllowed, Export ("firstName")]
		string FirstName { get; }

		// @property (readonly, nonatomic) NSString * _Nullable fullName;
		[NullAllowed, Export ("fullName")]
		string FullName { get; }

		// @property (readonly, nonatomic) NSString * _Nullable lastName;
		[NullAllowed, Export ("lastName")]
		string LastName { get; }

		// @property (readonly, nonatomic) NSString * _Nullable sex;
		[NullAllowed, Export ("sex")]
		string Sex { get; }

		// @property (readonly, nonatomic) NSString * _Nullable localizedName;
		[NullAllowed, Export ("localizedName")]
		string LocalizedName { get; }

		// @property (readonly, nonatomic) NSString * _Nullable additionalNameInformation;
		[NullAllowed, Export ("additionalNameInformation")]
		string AdditionalNameInformation { get; }

		// @property (readonly, nonatomic) NSString * _Nullable additionalAddressInformation;
		[NullAllowed, Export ("additionalAddressInformation")]
		string AdditionalAddressInformation { get; }

		// @property (readonly, nonatomic) NSString * _Nullable placeOfBirth;
		[NullAllowed, Export ("placeOfBirth")]
		string PlaceOfBirth { get; }

		// @property (readonly, nonatomic) NSString * _Nullable nationality;
		[NullAllowed, Export ("nationality")]
		string Nationality { get; }

		// @property (readonly, nonatomic) NSString * _Nullable race;
		[NullAllowed, Export ("race")]
		string Race { get; }

		// @property (readonly, nonatomic) NSString * _Nullable religion;
		[NullAllowed, Export ("religion")]
		string Religion { get; }

		// @property (readonly, nonatomic) NSString * _Nullable profession;
		[NullAllowed, Export ("profession")]
		string Profession { get; }

		// @property (readonly, nonatomic) NSString * _Nullable maritalStatus;
		[NullAllowed, Export ("maritalStatus")]
		string MaritalStatus { get; }

		// @property (readonly, nonatomic) NSString * _Nullable residentialStatus;
		[NullAllowed, Export ("residentialStatus")]
		string ResidentialStatus { get; }

		// @property (readonly, nonatomic) NSString * _Nullable employer;
		[NullAllowed, Export ("employer")]
		string Employer { get; }

		// @property (readonly, nonatomic) NSString * _Nullable personalIdNumber;
		[NullAllowed, Export ("personalIdNumber")]
		string PersonalIdNumber { get; }

		// @property (readonly, nonatomic) NSString * _Nullable documentAdditionalNumber;
		[NullAllowed, Export ("documentAdditionalNumber")]
		string DocumentAdditionalNumber { get; }

		// @property (readonly, nonatomic) NSString * _Nullable issuingAuthority;
		[NullAllowed, Export ("issuingAuthority")]
		string IssuingAuthority { get; }

		// @property (readonly, nonatomic) MBMrzResult * _Nonnull mrzResult;
		[Export ("mrzResult")]
		MBMrzResult MrzResult { get; }

		// @property (readonly, nonatomic) MBDriverLicenseDetailedInfo * _Nullable driverLicenseDetailedInfo;
		[NullAllowed, Export ("driverLicenseDetailedInfo")]
		MBDriverLicenseDetailedInfo DriverLicenseDetailedInfo { get; }

		// @property (readonly, nonatomic) MBClassInfo * _Nullable classInfo;
		[NullAllowed, Export ("classInfo")]
		MBClassInfo ClassInfo { get; }

		// @property (readonly, nonatomic) MBImageAnalysisResult * _Nullable frontImageAnalysisResult;
		[NullAllowed, Export ("frontImageAnalysisResult")]
		MBImageAnalysisResult FrontImageAnalysisResult { get; }

		// @property (readonly, nonatomic) MBImageAnalysisResult * _Nullable backImageAnalysisResult;
		[NullAllowed, Export ("backImageAnalysisResult")]
		MBImageAnalysisResult BackImageAnalysisResult { get; }

		// @property (readonly, nonatomic) MBBarcodeResult * _Nullable barcodeResult;
		[NullAllowed, Export ("barcodeResult")]
		MBBarcodeResult BarcodeResult { get; }

		// @property (readonly, nonatomic) MBVizResult * _Nullable frontVizResult;
		[NullAllowed, Export ("frontVizResult")]
		MBVizResult FrontVizResult { get; }

		// @property (readonly, nonatomic) MBVizResult * _Nullable backVizResult;
		[NullAllowed, Export ("backVizResult")]
		MBVizResult BackVizResult { get; }

        // @property (readonly, assign, nonatomic) MBProcessingStatus processingStatus;
		[Export ("processingStatus", ArgumentSemantic.Assign)]
		MBProcessingStatus ProcessingStatus { get; }

		// @property (readonly, assign, nonatomic) MBRecognitionMode recognitionMode;
		[Export ("recognitionMode", ArgumentSemantic.Assign)]
		MBRecognitionMode RecognitionMode { get; }
	}

    // @interface MBBlinkIdCombinedRecognizer : MBRecognizer <NSCopying, MBCombinedRecognizer, MBDigitalSignature, MBFaceImage, MBEncodeFaceImage, MBFaceImageDpi, MBFullDocumentImage, MBEncodeFullDocumentImage, MBFullDocumentImageDpi, MBFullDocumentImageExtensionFactors>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizer))]
    interface MBBlinkIdCombinedRecognizer : INSCopying, IMBCombinedRecognizer, IMBDigitalSignature, IMBFaceImage, IMBEncodeFaceImage, IMBFaceImageDpi, IMBFullDocumentImage, IMBEncodeFullDocumentImage, IMBFullDocumentImageDpi, IMBFullDocumentImageExtensionFactors
    {
        // @property (readonly, nonatomic, strong) MBBlinkIdCombinedRecognizerResult * _Nonnull result;
        [Export ("result", ArgumentSemantic.Strong)]
        MBBlinkIdCombinedRecognizerResult Result { get; }

        // @property (assign, nonatomic) BOOL allowBlurFilter;
        [Export ("allowBlurFilter")]
        bool AllowBlurFilter { get; set; }

		// @property (assign, nonatomic) BOOL allowUnparsedMrzResults;
		[Export ("allowUnparsedMrzResults")]
		bool AllowUnparsedMrzResults { get; set; }

		// @property (assign, nonatomic) BOOL allowUnverifiedMrzResults;
		[Export ("allowUnverifiedMrzResults")]
		bool AllowUnverifiedMrzResults { get; set; }

        // @property (assign, nonatomic) CGFloat paddingEdge;
		[Export ("paddingEdge")]
		nfloat PaddingEdge { get; set; }

		// @property (assign, nonatomic) BOOL skipUnsupportedBack;
		[Export ("skipUnsupportedBack")]
		bool SkipUnsupportedBack { get; set; }

        // @property (assign, nonatomic) BOOL validateResultCharacters;
		[Export ("validateResultCharacters")]
		bool ValidateResultCharacters { get; set; }

		// @property (assign, nonatomic) MBAnonymizationMode anonymizationMode;
		[Export ("anonymizationMode", ArgumentSemantic.Assign)]
		MBAnonymizationMode AnonymizationMode { get; set; }

        // @property (nonatomic, strong) MBRecognitionModeFilter * _Nonnull recognitionModeFilter;
		[Export ("recognitionModeFilter", ArgumentSemantic.Strong)]
		MBRecognitionModeFilter RecognitionModeFilter { get; set; }
    }

    // @protocol MBBlinkIdCombinedRecognizerDelegate <NSObject>
    [Protocol, Model]
    [BaseType (typeof(NSObject))]
    interface MBBlinkIdCombinedRecognizerDelegate
    {
        // @optional -(void)onCombinedImageAvailable:(MBImage * _Nullable)dewarpedImage;
        [Export ("onCombinedImageAvailable:")]
        void OnCombinedImageAvailable ([NullAllowed] MBImage dewarpedImage);

        // @optional -(void)onCombinedDocumentSupportStatus:(BOOL)isDocumentSupported;
        [Export ("onCombinedDocumentSupportStatus:")]
        void OnCombinedDocumentSupportStatus (bool isDocumentSupported);

        // @optional -(BOOL)combinedClassInfoFilter:(MBClassInfo * _Nullable)classInfo;
		[Export ("combinedClassInfoFilter:")]
		bool CombinedClassInfoFilter ([NullAllowed] MBClassInfo classInfo);

		// @optional -(void)onCombinedBarcodeScanningStarted;
		[Export ("onCombinedBarcodeScanningStarted")]
		void OnCombinedBarcodeScanningStarted ();
    }

    // @interface MBIdBarcodeRecognizerResult : MBRecognizerResult <NSCopying>
	[iOS (8,0)]
	[BaseType (typeof(MBRecognizerResult))]
	[DisableDefaultCtor]
	interface MBIdBarcodeRecognizerResult : INSCopying, IMBAgeResult, IMBDocumentExpirationCheckResult
	{
		// @property (readonly, nonatomic) NSString * _Nonnull additionalNameInformation;
		[Export ("additionalNameInformation")]
		string AdditionalNameInformation { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull address;
		[Export ("address")]
		string Address { get; }

		// @property (readonly, nonatomic) MBDateResult * _Nonnull dateOfBirth;
		[Export ("dateOfBirth")]
		MBDateResult DateOfBirth { get; }

		// @property (readonly, nonatomic) MBDateResult * _Nonnull dateOfExpiry;
		[Export ("dateOfExpiry")]
		MBDateResult DateOfExpiry { get; }

		// @property (readonly, nonatomic) MBDateResult * _Nonnull dateOfIssue;
		[Export ("dateOfIssue")]
		MBDateResult DateOfIssue { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull documentAdditionalNumber;
		[Export ("documentAdditionalNumber")]
		string DocumentAdditionalNumber { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull documentNumber;
		[Export ("documentNumber")]
		string DocumentNumber { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull employer;
		[Export ("employer")]
		string Employer { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull firstName;
		[Export ("firstName")]
		string FirstName { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull fullName;
		[Export ("fullName")]
		string FullName { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull issuingAuthority;
		[Export ("issuingAuthority")]
		string IssuingAuthority { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull lastName;
		[Export ("lastName")]
		string LastName { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull maritalStatus;
		[Export ("maritalStatus")]
		string MaritalStatus { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull nationality;
		[Export ("nationality")]
		string Nationality { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull personalIdNumber;
		[Export ("personalIdNumber")]
		string PersonalIdNumber { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull placeOfBirth;
		[Export ("placeOfBirth")]
		string PlaceOfBirth { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull profession;
		[Export ("profession")]
		string Profession { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull race;
		[Export ("race")]
		string Race { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull religion;
		[Export ("religion")]
		string Religion { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull residentialStatus;
		[Export ("residentialStatus")]
		string ResidentialStatus { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull sex;
		[Export ("sex")]
		string Sex { get; }

		// @property (readonly, nonatomic, strong) NSData * _Nullable rawData;
		[NullAllowed, Export ("rawData", ArgumentSemantic.Strong)]
		NSData RawData { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nullable stringData;
		[NullAllowed, Export ("stringData", ArgumentSemantic.Strong)]
		string StringData { get; }

		// @property (readonly, assign, nonatomic) BOOL uncertain;
		[Export ("uncertain")]
		bool Uncertain { get; }

		// @property (readonly, assign, nonatomic) MBBarcodeType barcodeType;
		[Export ("barcodeType", ArgumentSemantic.Assign)]
		MBBarcodeType BarcodeType { get; }

		// @property (readonly, assign, nonatomic) MBIdBarcodeDocumentType documentType;
		[Export ("documentType", ArgumentSemantic.Assign)]
		MBIdBarcodeDocumentType DocumentType { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull restrictions;
		[Export ("restrictions")]
		string Restrictions { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull endorsements;
		[Export ("endorsements")]
		string Endorsements { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull vehicleClass;
		[Export ("vehicleClass")]
		string VehicleClass { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull street;
		[Export ("street")]
		string Street { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull postalCode;
		[Export ("postalCode")]
		string PostalCode { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull city;
		[Export ("city")]
		string City { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull jurisdiction;
		[Export ("jurisdiction")]
		string Jurisdiction { get; }
	}

	// @interface MBIdBarcodeRecognizer : MBRecognizer <NSCopying>
	[iOS (8,0)]
	[BaseType (typeof(MBRecognizer))]
	interface MBIdBarcodeRecognizer : INSCopying
	{
		// @property (readonly, nonatomic, strong) MBIdBarcodeRecognizerResult * _Nonnull result;
		[Export ("result", ArgumentSemantic.Strong)]
		MBIdBarcodeRecognizerResult Result { get; }
	}

    // @protocol MBFullDocumentImageExtensionFactors
    [Protocol]
    interface IMBFullDocumentImageExtensionFactors
    {
        // @required @property (assign, nonatomic) MBImageExtensionFactors fullDocumentImageExtensionFactors;
        [Abstract]
        [Export("fullDocumentImageExtensionFactors", ArgumentSemantic.Assign)]
        MBImageExtensionFactors FullDocumentImageExtensionFactors { get; set; }
    }

    // @interface MBMrtdRecognizerResult : MBTemplatingRecognizerResult <NSCopying, MBFullDocumentImageResult, MBEncodedFullDocumentImageResult>
	[iOS (8,0)]
	[BaseType (typeof(MBTemplatingRecognizerResult))]
	[DisableDefaultCtor]
	interface MBMrtdRecognizerResult : INSCopying, IMBFullDocumentImageResult, IMBEncodedFullDocumentImageResult
	{
		// @property (readonly, nonatomic, strong) MBMrzResult * _Nonnull mrzResult;
		[Export ("mrzResult", ArgumentSemantic.Strong)]
		MBMrzResult MrzResult { get; }

		// @property (readonly, nonatomic) MBOcrLayout * _Nullable rawOcrLayout;
		[NullAllowed, Export ("rawOcrLayout")]
		MBOcrLayout RawOcrLayout { get; }
	}

    // @interface MBMrtdRecognizer : MBTemplatingRecognizer <NSCopying, MBFullDocumentImage, MBEncodeFullDocumentImage, MBFullDocumentImageDpi, MBFullDocumentImageExtensionFactors, MBGlareDetection>
	[iOS (8,0)]
	[BaseType (typeof(MBTemplatingRecognizer))]
	interface MBMrtdRecognizer : INSCopying, IMBFullDocumentImage, IMBEncodeFullDocumentImage, IMBFullDocumentImageDpi, IMBFullDocumentImageExtensionFactors, IMBGlareDetection
	{
		// @property (readonly, nonatomic, strong) MBMrtdRecognizerResult * _Nonnull result;
		[Export ("result", ArgumentSemantic.Strong)]
		MBMrtdRecognizerResult Result { get; }

		// @property (assign, nonatomic) BOOL allowUnparsedResults;
		[Export ("allowUnparsedResults")]
		bool AllowUnparsedResults { get; set; }

		// @property (assign, nonatomic) BOOL allowUnverifiedResults;
		[Export ("allowUnverifiedResults")]
		bool AllowUnverifiedResults { get; set; }

        // @property (assign, nonatomic) BOOL allowSpecialCharacters;
        [Export("allowSpecialCharacters")]
        bool AllowSpecialCharacters { get; set; }

        // -(void)setMrtdSpecifications:(NSArray<__kindof MBMrtdSpecification *> * _Nullable)mrtdSpecifications;
        [Export ("setMrtdSpecifications:")]
		void SetMrtdSpecifications ([NullAllowed] MBMrtdSpecification[] mrtdSpecifications);

		// @property (readonly, nonatomic, strong) NSArray<__kindof MBMrtdSpecification *> * _Nullable mrtdSpecifications;
		[NullAllowed, Export ("mrtdSpecifications", ArgumentSemantic.Strong)]
		MBMrtdSpecification[] MrtdSpecifications { get; }
	}

    // @protocol MBMrzFilter <NSObject>
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface MBMrzFilter
    {
        // @required -(BOOL)mrzFilter;
        [Abstract]
        [Export("mrzFilter")]
        bool MrzFilter();
    }

    // @protocol MBMrzImageResult
    [Protocol]
    interface IMBMrzImageResult
    {
        // @required @property (readonly, nonatomic) MBImage * _Nullable mrzImage;
        [Abstract]
        [NullAllowed, Export("mrzImage")]
        MBImage MrzImage { get; }
    }

    // @protocol MBEncodedMrzImageResult
    [Protocol]
    interface IMBEncodedMrzImageResult
    {
        // @required @property (readonly, nonatomic) NSData * _Nullable encodedMrzImage;
        [Abstract]
        [NullAllowed, Export("encodedMrzImage")]
        NSData EncodedMrzImage { get; }
    }

    
    // @protocol MBMrzImage
    [Protocol]
    interface IMBMrzImage
    {
        // @required @property (assign, nonatomic) BOOL returnMrzImage;
        [Abstract]
        [Export("returnMrzImage")]
        bool ReturnMrzImage { get; set; }
    }


    // @protocol MBMrzImageDpi
    [Protocol, Model]
    interface IMBMrzImageDpi
    {
        // @required @property (assign, nonatomic) NSUInteger mrzImageDpi;
        [Abstract]
        [Export ("mrzImageDpi")]
        nuint MrzImageDpi { get; set; }
    }


    // @protocol MBEncodeMrzImage
    [Protocol]
    interface IMBEncodeMrzImage
    {
        // @required @property (assign, nonatomic) BOOL encodeMrzImage;
        [Abstract]
        [Export("encodeMrzImage")]
        bool EncodeMrzImage { get; set; }
    }

   // @interface MBMrtdCombinedRecognizerResult : MBRecognizerResult <NSCopying, MBCombinedRecognizerResult, MBFaceImageResult, MBCombinedFullDocumentImageResult, MBEncodedFaceImageResult, MBEncodedCombinedFullDocumentImageResult, MBDigitalSignatureResult>
	[iOS (8,0)]
	[BaseType (typeof(MBRecognizerResult))]
	[DisableDefaultCtor]
	interface MBMrtdCombinedRecognizerResult : INSCopying, MBCombinedRecognizerResult, IMBFaceImageResult, IMBCombinedFullDocumentImageResult, IMBEncodedFaceImageResult, IMBEncodedCombinedFullDocumentImageResult, IMBDigitalSignatureResult
	{
		// @property (readonly, nonatomic, strong) MBMrzResult * _Nonnull mrzResult;
		[Export ("mrzResult", ArgumentSemantic.Strong)]
		MBMrzResult MrzResult { get; }
	}

	// @interface MBMrtdCombinedRecognizer : MBRecognizer <NSCopying, MBCombinedRecognizer, MBDigitalSignature, MBFullDocumentImage, MBEncodeFullDocumentImage, MBFullDocumentImageDpi, MBFullDocumentImageExtensionFactors, MBFaceImage, MBEncodeFaceImage, MBFaceImageDpi>
	[iOS (8,0)]
	[BaseType (typeof(MBRecognizer))]
	interface MBMrtdCombinedRecognizer : INSCopying, IMBCombinedRecognizer, IMBDigitalSignature, IMBFullDocumentImage, IMBEncodeFullDocumentImage, IMBFullDocumentImageDpi, IMBFullDocumentImageExtensionFactors, IMBFaceImage, IMBEncodeFaceImage, IMBFaceImageDpi
	{
		// @property (readonly, nonatomic, strong) MBMrtdCombinedRecognizerResult * _Nonnull result;
		[Export ("result", ArgumentSemantic.Strong)]
		MBMrtdCombinedRecognizerResult Result { get; }

		// @property (assign, nonatomic) BOOL allowUnparsedResults;
		[Export ("allowUnparsedResults")]
		bool AllowUnparsedResults { get; set; }

		// @property (assign, nonatomic) BOOL allowUnverifiedResults;
		[Export ("allowUnverifiedResults")]
		bool AllowUnverifiedResults { get; set; }

        // @property (assign, nonatomic) BOOL allowSpecialCharacters;
        [Export("allowSpecialCharacters")]
        bool AllowSpecialCharacters { get; set; }

        // @property (assign, nonatomic) NSUInteger numStableDetectionsThreshold;
        [Export ("numStableDetectionsThreshold")]
		nuint NumStableDetectionsThreshold { get; set; }

		// @property (assign, nonatomic) MBDocumentFaceDetectorType detectorType;
		[Export ("detectorType", ArgumentSemantic.Assign)]
		MBDocumentFaceDetectorType DetectorType { get; set; }
	}

    // @interface MBPassportRecognizerResult : MBRecognizerResult <NSCopying, MBFaceImageResult, MBEncodedFaceImageResult, MBFullDocumentImageResult, MBEncodedFullDocumentImageResult>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBPassportRecognizerResult : INSCopying, IMBDigitalSignatureResult, IMBFaceImageResult, IMBEncodedFaceImageResult, IMBFullDocumentImageResult, IMBEncodedFullDocumentImageResult
    {
        // @property (readonly, nonatomic) MBMrzResult * _Nonnull mrzResult;
        [Export ("mrzResult")]
        MBMrzResult MrzResult { get; }
    }

    // @interface MBPassportRecognizer : MBRecognizer <NSCopying, MBGlareDetection, MBFaceImage, MBEncodeFaceImage, MBFaceImageDpi, MBFullDocumentImage, MBEncodeFullDocumentImage, MBFullDocumentImageDpi, MBFullDocumentImageExtensionFactors>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizer))]
    interface MBPassportRecognizer : INSCopying, IMBDigitalSignature, IMBGlareDetection, IMBFaceImage, IMBEncodeFaceImage, IMBFaceImageDpi, IMBFullDocumentImage, IMBEncodeFullDocumentImage, IMBFullDocumentImageDpi, IMBFullDocumentImageExtensionFactors
    {
        // @property (readonly, nonatomic, strong) MBPassportRecognizerResult * _Nonnull result;
        [Export ("result", ArgumentSemantic.Strong)]
        MBPassportRecognizerResult Result { get; }

        // @property (assign, nonatomic) BOOL anonymizeNetherlandsMrz;
        [Export ("anonymizeNetherlandsMrz")]
        bool AnonymizeNetherlandsMrz { get; set; }
    }

    // @interface MBVisaRecognizerResult : MBRecognizerResult <NSCopying, MBFaceImageResult, MBEncodedFaceImageResult, MBFullDocumentImageResult, MBEncodedFullDocumentImageResult>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBVisaRecognizerResult : INSCopying, IMBFaceImageResult, IMBEncodedFaceImageResult, IMBFullDocumentImageResult, IMBEncodedFullDocumentImageResult
    {
        // @property (readonly, nonatomic) MBMrzResult * _Nonnull mrzResult;
        [Export ("mrzResult")]
        MBMrzResult MrzResult { get; }
    }

    // @interface MBVisaRecognizer : MBRecognizer <NSCopying, MBGlareDetection, MBFaceImage, MBEncodeFaceImage, MBFaceImageDpi, MBFullDocumentImage, MBEncodeFullDocumentImage, MBFullDocumentImageDpi, MBFullDocumentImageExtensionFactors>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizer))]
    interface MBVisaRecognizer : INSCopying, IMBGlareDetection, IMBFaceImage, IMBEncodeFaceImage, IMBFaceImageDpi, IMBFullDocumentImage, IMBEncodeFullDocumentImage, IMBFullDocumentImageDpi, IMBFullDocumentImageExtensionFactors
    {
        // @property (readonly, nonatomic, strong) MBVisaRecognizerResult * _Nonnull result;
        [Export ("result", ArgumentSemantic.Strong)]
        MBVisaRecognizerResult Result { get; }
    }

    // @protocol MBEncodedFullDocumentImageResult
    [Protocol]
    interface IMBEncodedFullDocumentImageResult
    {
        // @required @property (readonly, nonatomic) NSData * _Nullable encodedFullDocumentImage;
        [Abstract]
        [NullAllowed, Export("encodedFullDocumentImage")]
        NSData EncodedFullDocumentImage { get; }
    }

    // @interface MBUsdlCombinedRecognizerResult : MBRecognizerResult <NSCopying, MBCombinedRecognizerResult, MBFaceImageResult, MBFullDocumentImageResult, MBDigitalSignatureResult, MBEncodedFaceImageResult, MBEncodedFullDocumentImageResult, IMBAgeResult>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBUsdlCombinedRecognizerResult : INSCopying, MBCombinedRecognizerResult, IMBFaceImageResult, IMBFullDocumentImageResult, IMBDigitalSignatureResult, IMBEncodedFaceImageResult, IMBEncodedFullDocumentImageResult, IMBAgeResult
    {
        // @property (readonly, nonatomic) NSString * _Nullable firstName;
        [NullAllowed, Export ("firstName")]
        string FirstName { get; }

        // @property (readonly, nonatomic) NSString * _Nullable lastName;
        [NullAllowed, Export ("lastName")]
        string LastName { get; }

        // @property (readonly, nonatomic) NSString * _Nullable fullName;
        [NullAllowed, Export ("fullName")]
        string FullName { get; }

        // @property (readonly, nonatomic) NSString * _Nullable address;
        [NullAllowed, Export ("address")]
        string Address { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nullable dateOfBirth;
        [NullAllowed, Export ("dateOfBirth")]
        MBDateResult DateOfBirth { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nullable dateOfIssue;
        [NullAllowed, Export ("dateOfIssue")]
        MBDateResult DateOfIssue { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nullable dateOfExpiry;
        [NullAllowed, Export ("dateOfExpiry")]
        MBDateResult DateOfExpiry { get; }

        // @property (readonly, nonatomic) NSString * _Nullable documentNumber;
        [NullAllowed, Export ("documentNumber")]
        string DocumentNumber { get; }

        // @property (readonly, nonatomic) NSString * _Nullable sex;
        [NullAllowed, Export ("sex")]
        string Sex { get; }

        // @property (readonly, nonatomic) NSString * _Nullable restrictions;
        [NullAllowed, Export ("restrictions")]
        string Restrictions { get; }

        // @property (readonly, nonatomic) NSString * _Nullable endorsements;
        [NullAllowed, Export ("endorsements")]
        string Endorsements { get; }

        // @property (readonly, nonatomic) NSString * _Nullable vehicleClass;
        [NullAllowed, Export ("vehicleClass")]
        string VehicleClass { get; }

        // -(NSData * _Nullable)data;
        [NullAllowed, Export ("data")]
        NSData Data { get; }

        // -(BOOL)isUncertain;
        [Export ("isUncertain")]
        bool IsUncertain { get; }

        // -(NSString * _Nullable)getField:(MBUsdlKeys)usdlKey __attribute__((deprecated("")));
        [Export ("getField:")]
        [return: NullAllowed]
        string GetField (MBUsdlKeys usdlKey);

        // -(NSArray<NSString *> * _Nullable)optionalElements __attribute__((deprecated("")));
        [NullAllowed, Export ("optionalElements")]
        string[] OptionalElements { get; }
    }

    // @interface MBUsdlCombinedRecognizer : MBRecognizer <NSCopying, MBCombinedRecognizer, MBFullDocumentImage, MBFullDocumentImageDpi, MBFaceImage, MBFaceImageDpi, MBEncodeFaceImage, MBEncodeFullDocumentImage, MBDigitalSignature, MBFullDocumentImageExtensionFactors>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizer))]
    interface MBUsdlCombinedRecognizer : INSCopying, IMBCombinedRecognizer, IMBFullDocumentImage, IMBFullDocumentImageDpi, IMBFaceImage, IMBFaceImageDpi, IMBEncodeFaceImage, IMBEncodeFullDocumentImage, IMBDigitalSignature, IMBFullDocumentImageExtensionFactors
    {
        // @property (readonly, nonatomic, strong) MBUsdlCombinedRecognizerResult * _Nonnull result;
        [Export ("result", ArgumentSemantic.Strong)]
        MBUsdlCombinedRecognizerResult Result { get; }

        // @property (assign, nonatomic) BOOL scanUncertain;
        [Export ("scanUncertain")]
        bool ScanUncertain { get; set; }

        // @property (assign, nonatomic) BOOL allowNullQuietZone;
        [Export ("allowNullQuietZone")]
        bool AllowNullQuietZone { get; set; }

        // @property (assign, nonatomic) BOOL enableCompactParser;
		[Export ("enableCompactParser")]
		bool EnableCompactParser { get; set; }

        // @property (assign, nonatomic) MBDocumentFaceDetectorType type;
        [Export ("type", ArgumentSemantic.Assign)]
        MBDocumentFaceDetectorType Type { get; set; }

        // @property (assign, nonatomic) NSUInteger numStableDetectionsThreshold;
        [Export ("numStableDetectionsThreshold")]
        nuint NumStableDetectionsThreshold { get; set; }
    }

    // @interface MBUsdlRecognizerResult : MBRecognizerResult <NSCopying>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBUsdlRecognizerResult : INSCopying, IMBAgeResult
    {
        // @property (readonly, nonatomic) NSString * _Nullable firstName;
        [NullAllowed, Export ("firstName")]
        string FirstName { get; }

        // @property (readonly, nonatomic) NSString * _Nullable lastName;
        [NullAllowed, Export ("lastName")]
        string LastName { get; }

        // @property (readonly, nonatomic) NSString * _Nullable fullName;
        [NullAllowed, Export ("fullName")]
        string FullName { get; }

        // @property (readonly, nonatomic) NSString * _Nullable address;
        [NullAllowed, Export ("address")]
        string Address { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nullable dateOfBirth;
        [NullAllowed, Export ("dateOfBirth")]
        MBDateResult DateOfBirth { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nullable dateOfIssue;
        [NullAllowed, Export ("dateOfIssue")]
        MBDateResult DateOfIssue { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nullable dateOfExpiry;
        [NullAllowed, Export ("dateOfExpiry")]
        MBDateResult DateOfExpiry { get; }

        // @property (readonly, nonatomic) NSString * _Nullable documentNumber;
        [NullAllowed, Export ("documentNumber")]
        string DocumentNumber { get; }

        // @property (readonly, nonatomic) NSString * _Nullable sex;
        [NullAllowed, Export ("sex")]
        string Sex { get; }

        // @property (readonly, nonatomic) NSString * _Nullable restrictions;
        [NullAllowed, Export ("restrictions")]
        string Restrictions { get; }

        // @property (readonly, nonatomic) NSString * _Nullable endorsements;
        [NullAllowed, Export ("endorsements")]
        string Endorsements { get; }

        // @property (readonly, nonatomic) NSString * _Nullable vehicleClass;
        [NullAllowed, Export ("vehicleClass")]
        string VehicleClass { get; }

        // @property (readonly, nonatomic) NSString * _Nullable street;
		[NullAllowed, Export ("street")]
		string Street { get; }

		// @property (readonly, nonatomic) NSString * _Nullable postalCode;
		[NullAllowed, Export ("postalCode")]
		string PostalCode { get; }

		// @property (readonly, nonatomic) NSString * _Nullable city;
		[NullAllowed, Export ("city")]
		string City { get; }

		// @property (readonly, nonatomic) NSString * _Nullable jurisdiction;
		[NullAllowed, Export ("jurisdiction")]
		string Jurisdiction { get; }

        // -(NSData * _Nullable)data;
        [NullAllowed, Export ("data")]
        NSData Data { get; }

        // -(BOOL)isUncertain;
        [Export ("isUncertain")]
        bool IsUncertain { get; }

        // -(NSString * _Nullable)getField:(MBUsdlKeys)usdlKey __attribute__((deprecated("")));
        [Export ("getField:")]
        [return: NullAllowed]
        string GetField (MBUsdlKeys usdlKey);

        // -(NSArray<NSString *> * _Nullable)optionalElements __attribute__((deprecated("")));
        [NullAllowed, Export ("optionalElements")]
        string[] OptionalElements { get; }
    }

    // @interface MBUsdlRecognizer : MBRecognizer <NSCopying>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizer))]
    interface MBUsdlRecognizer : INSCopying
    {
        // @property (readonly, nonatomic, strong) MBUsdlRecognizerResult * _Nonnull result;
        [Export ("result", ArgumentSemantic.Strong)]
        MBUsdlRecognizerResult Result { get; }

        // @property (assign, nonatomic) BOOL scanUncertain;
        [Export ("scanUncertain")]
        bool ScanUncertain { get; set; }

        // @property (assign, nonatomic) BOOL allowNullQuietZone;
        [Export ("allowNullQuietZone")]
        bool AllowNullQuietZone { get; set; }

        // @property (assign, nonatomic) BOOL enableCompactParser;
		[Export ("enableCompactParser")]
		bool EnableCompactParser { get; set; }
    }


    // @interface MBBaseOverlayViewController : MBOverlayViewController
    
    [BaseType(typeof(MBOverlayViewController))]
    interface MBBaseOverlayViewController
    {
    }

    // @interface MBRecognizerCollection : NSObject <NSCopying>
    
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBRecognizerCollection : INSCopying
    {
        // -(instancetype _Nonnull)initWithRecognizers:(NSArray<MBRecognizer *> * _Nonnull)recognizers __attribute__((objc_designated_initializer));
        [Export("initWithRecognizers:")]
        [DesignatedInitializer]
        IntPtr Constructor(MBRecognizer[] recognizers);

        // @property (nonatomic, strong) NSArray<MBRecognizer *> * _Nonnull recognizerList;
        [Export("recognizerList", ArgumentSemantic.Strong)]
        MBRecognizer[] RecognizerList { get; set; }

        // @property (nonatomic) BOOL allowMultipleResults;
        [Export("allowMultipleResults")]
        bool AllowMultipleResults { get; set; }

        // @property (nonatomic) NSTimeInterval partialRecognitionTimeout;
        [Export("partialRecognitionTimeout")]
        double PartialRecognitionTimeout { get; set; }

        // @property (nonatomic) MBRecognitionMode recognitionMode;
        [Export("recognitionMode", ArgumentSemantic.Assign)]
        MBRecognitionMode RecognitionMode { get; set; }

        // @property (nonatomic) MBFrameQualityEstimationMode frameQualityEstimationMode;
        [Export("frameQualityEstimationMode", ArgumentSemantic.Assign)]
        MBFrameQualityEstimationMode FrameQualityEstimationMode { get; set; }
    }

    // @interface MBOverlaySettings : NSObject <NSCopying>
    
    [BaseType(typeof(NSObject))]
    interface MBOverlaySettings : INSCopying
    {
        // @property (nonatomic, strong) NSString * _Nullable language;
        [NullAllowed, Export("language", ArgumentSemantic.Strong)]
        string Language { get; set; }

        // @property (nonatomic, strong) MBCameraSettings * _Nonnull cameraSettings;
        [Export("cameraSettings", ArgumentSemantic.Strong)]
        MBCameraSettings CameraSettings { get; set; }
    }

    // @interface MBBaseOverlaySettings : MBOverlaySettings
    
    [BaseType(typeof(MBOverlaySettings))]
    interface MBBaseOverlaySettings
    {
        // @property (assign, nonatomic) BOOL autorotateOverlay;
        [Export("autorotateOverlay")]
        bool AutorotateOverlay { get; set; }

        // @property (assign, nonatomic) BOOL showStatusBar;
        [Export("showStatusBar")]
        bool ShowStatusBar { get; set; }

        // @property (assign, nonatomic) NSUInteger supportedOrientations;
        [Export("supportedOrientations")]
        nuint SupportedOrientations { get; set; }

        // @property (nonatomic, strong) NSString * _Nullable soundFilePath;
        [NullAllowed, Export("soundFilePath", ArgumentSemantic.Strong)]
        string SoundFilePath { get; set; }

        // @property (assign, nonatomic) BOOL displayCancelButton;
        [Export("displayCancelButton")]
        bool DisplayCancelButton { get; set; }

        // @property (assign, nonatomic) BOOL displayTorchButton;
        [Export("displayTorchButton")]
        bool DisplayTorchButton { get; set; }
    }

    // @interface MBCustomOverlayViewController : MBOverlayViewController
    
    [BaseType(typeof(MBOverlayViewController))]
    interface MBCustomOverlayViewController
    {
        // @property (readonly, nonatomic, strong) MBRecognizerCollection * _Nonnull recognizerCollection;
        [Export("recognizerCollection", ArgumentSemantic.Strong)]
        MBRecognizerCollection RecognizerCollection { get; }

        // @property (readonly, nonatomic, strong) MBCameraSettings * _Nonnull cameraSettings;
        [Export("cameraSettings", ArgumentSemantic.Strong)]
        MBCameraSettings CameraSettings { get; }

        // @property (nonatomic, strong) MBRecognizerRunnerViewControllerMetadataDelegates * _Nonnull metadataDelegates;
        [Export("metadataDelegates", ArgumentSemantic.Strong)]
        MBRecognizerRunnerViewControllerMetadataDelegates MetadataDelegates { get; set; }

        [Wrap("WeakScanningRecognizerRunnerViewControllerDelegate")]
        [NullAllowed]
        MBScanningRecognizerRunnerViewControllerDelegate ScanningRecognizerRunnerViewControllerDelegate { get; set; }

        // @property (nonatomic, weak) id<MBScanningRecognizerRunnerViewControllerDelegate> _Nullable scanningRecognizerRunnerViewControllerDelegate;
        [NullAllowed, Export("scanningRecognizerRunnerViewControllerDelegate", ArgumentSemantic.Weak)]
        NSObject WeakScanningRecognizerRunnerViewControllerDelegate { get; set; }

        [Wrap("WeakRecognizerRunnerViewControllerDelegate")]
        [NullAllowed]
        MBRecognizerRunnerViewControllerDelegate RecognizerRunnerViewControllerDelegate { get; set; }

        // @property (nonatomic, weak) id<MBRecognizerRunnerViewControllerDelegate> _Nullable recognizerRunnerViewControllerDelegate;
        [NullAllowed, Export("recognizerRunnerViewControllerDelegate", ArgumentSemantic.Weak)]
        NSObject WeakRecognizerRunnerViewControllerDelegate { get; set; }

        // -(instancetype _Nonnull)initWithRecognizerCollection:(MBRecognizerCollection * _Nonnull)recognizerCollection cameraSettings:(MBCameraSettings * _Nonnull)cameraSettings __attribute__((objc_designated_initializer));
        [Export("initWithRecognizerCollection:cameraSettings:")]
        [DesignatedInitializer]
        IntPtr Constructor(MBRecognizerCollection recognizerCollection, MBCameraSettings cameraSettings);

        // @property (nonatomic) CGRect scanningRegion;
        [Export("scanningRegion", ArgumentSemantic.Assign)]
        CGRect ScanningRegion { get; set; }

        // @property (assign, nonatomic) BOOL autorotateOverlay;
        [Export("autorotateOverlay")]
        bool AutorotateOverlay { get; set; }

        // @property (assign, nonatomic) BOOL showStatusBar;
        [Export("showStatusBar")]
        bool ShowStatusBar { get; set; }

        // @property (assign, nonatomic) NSUInteger supportedOrientations;
        [Export("supportedOrientations")]
        nuint SupportedOrientations { get; set; }

        // -(void)reconfigureRecognizers:(MBRecognizerCollection * _Nonnull)recognizerCollection;
        [Export("reconfigureRecognizers:")]
        void ReconfigureRecognizers(MBRecognizerCollection recognizerCollection);
    }

    // @interface MBSubview : UIView
    
    [BaseType(typeof(UIView))]
    interface MBSubview
    {
        [Wrap("WeakDelegate")]
        [NullAllowed]
        MBSubviewDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<MBSubviewDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }
    }

    // @protocol MBSubviewDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface MBSubviewDelegate
    {
        // @required -(void)subviewAnimationDidStart:(MBSubview * _Nonnull)subview;
        [Abstract]
        [Export("subviewAnimationDidStart:")]
        void SubviewAnimationDidStart(MBSubview subview);

        // @required -(void)subviewAnimationDidFinish:(MBSubview * _Nonnull)subview;
        [Abstract]
        [Export("subviewAnimationDidFinish:")]
        void SubviewAnimationDidFinish(MBSubview subview);
    }

    // @interface MBDisplayableObject : NSObject
    
    [BaseType(typeof(NSObject))]
    interface MBDisplayableObject
    {
        // @property (assign, nonatomic) CGAffineTransform transform;
        [Export("transform", ArgumentSemantic.Assign)]
        CGAffineTransform Transform { get; set; }
    }

    // @interface MBDisplayableDetection : MBDisplayableObject
    
    [BaseType(typeof(MBDisplayableObject))]
    [DisableDefaultCtor]
    interface MBDisplayableDetection
    {
        // -(instancetype _Nonnull)initWithDetectionStatus:(MBDetectionStatus)status __attribute__((objc_designated_initializer));
        [Export("initWithDetectionStatus:")]
        [DesignatedInitializer]
        IntPtr Constructor(MBDetectionStatus status);

        // @property (readonly, assign, nonatomic) MBDetectionStatus detectionStatus;
        [Export("detectionStatus", ArgumentSemantic.Assign)]
        MBDetectionStatus DetectionStatus { get; }
    }

    // @interface MBDisplayablePointsDetection : MBDisplayableDetection
    
    [BaseType(typeof(MBDisplayableDetection))]
    interface MBDisplayablePointsDetection
    {
        // @property (nonatomic) NSArray * _Nonnull points;
        [Export("points", ArgumentSemantic.Assign)]
        NSValue[] Points { get; set; }
    }

    // @protocol MBPointDetectorSubview <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface IMBPointDetectorSubview
    {
        // @required -(void)detectionFinishedWithDisplayablePoints:(MBDisplayablePointsDetection *)displayablePointsDetection;
        [Abstract]
        [Export("detectionFinishedWithDisplayablePoints:")]
        void DetectionFinishedWithDisplayablePoints(MBDisplayablePointsDetection displayablePointsDetection);
    }

    // @interface MBDotsSubview : MBSubview <MBPointDetectorSubview>
    
    [BaseType(typeof(MBSubview))]
    interface MBDotsSubview : IMBPointDetectorSubview
    {
        // @property (nonatomic, strong) CAShapeLayer * _Nonnull dotsLayer;
        [Export("dotsLayer", ArgumentSemantic.Strong)]
        CAShapeLayer DotsLayer { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull dotsColor;
        [Export("dotsColor", ArgumentSemantic.Strong)]
        UIColor DotsColor { get; set; }

        // @property (assign, nonatomic) CGFloat dotsStrokeWidth;
        [Export("dotsStrokeWidth")]
        nfloat DotsStrokeWidth { get; set; }

        // @property (assign, nonatomic) CGFloat dotsRadius;
        [Export("dotsRadius")]
        nfloat DotsRadius { get; set; }

        // @property (assign, nonatomic) CGFloat animationDuration;
        [Export("animationDuration")]
        nfloat AnimationDuration { get; set; }

        // -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
        [Export("initWithFrame:")]
        [DesignatedInitializer]
        IntPtr Constructor(CGRect frame);
    }

    // @interface MBDotsResultSubview : MBSubview <MBPointDetectorSubview, MBOcrLayoutSubview>
    
    [BaseType(typeof(MBSubview))]
    interface MBDotsResultSubview : IMBPointDetectorSubview
    {
        // @property (nonatomic, strong) UIColor * _Nonnull foregroundColor;
        [Export("foregroundColor", ArgumentSemantic.Strong)]
        UIColor ForegroundColor { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull tintColor;
        [Export("tintColor", ArgumentSemantic.Strong)]
        UIColor TintColor { get; set; }

        // @property (assign, nonatomic) BOOL shouldIgnoreFastResults;
        [Export("shouldIgnoreFastResults")]
        bool ShouldIgnoreFastResults { get; set; }

        // @property (assign, nonatomic) CGFloat charFadeInDuration;
        [Export("charFadeInDuration")]
        nfloat CharFadeInDuration { get; set; }

        // @property (assign, nonatomic) NSUInteger dotCount;
        [Export("dotCount")]
        nuint DotCount { get; set; }
    }

        // @interface MBDisplayableQuadDetection : MBDisplayableDetection
    
    [BaseType(typeof(MBDisplayableDetection))]
    interface MBDisplayableQuadDetection
    {
        // @property (nonatomic, strong) MBQuadrangle * _Nonnull detectionLocation;
        [Export("detectionLocation", ArgumentSemantic.Strong)]
        MBQuadrangle DetectionLocation { get; set; }
    }

    // @interface MBTapToFocusSubview : MBSubview
    
    [BaseType(typeof(MBSubview))]
    interface MBTapToFocusSubview
    {
        // -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
        [Export("initWithFrame:")]
        [DesignatedInitializer]
        IntPtr Constructor(CGRect frame);

        // -(void)willFocusAtPoint:(CGPoint)point;
        [Export("willFocusAtPoint:")]
        void WillFocusAtPoint(CGPoint point);
    }

    // @protocol MBResultSubview <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface MBResultSubview
    {
        // @required -(void)scanningFinishedWithState:(MBRecognizerResultState)state;
        [Abstract]
        [Export("scanningFinishedWithState:")]
        void ScanningFinishedWithState(MBRecognizerResultState state);
    }

    // @interface MBGlareStatusSubview : MBSubview
    
    [BaseType(typeof(MBSubview))]
    [DisableDefaultCtor]
    interface MBGlareStatusSubview
    {
        // @property (nonatomic) UILabel * _Nonnull label;
        [Export("label", ArgumentSemantic.Assign)]
        UILabel Label { get; set; }

        // -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
        [Export("initWithFrame:")]
        [DesignatedInitializer]
        IntPtr Constructor(CGRect frame);

        // -(void)glareDetectionFinishedWithResult:(BOOL)glareFound;
        [Export("glareDetectionFinishedWithResult:")]
        void GlareDetectionFinishedWithResult(bool glareFound);
    }

    // @interface MBBaseOcrOverlaySettings : MBBaseOverlaySettings
    
    [BaseType(typeof(MBBaseOverlaySettings))]
    interface MBBaseOcrOverlaySettings
    {
        // @property (nonatomic) BOOL showOcrDots;
        [Export("showOcrDots")]
        bool ShowOcrDots { get; set; }
    }

    // @interface MBDocumentOverlaySettings : MBBaseOcrOverlaySettings
    
    [BaseType(typeof(MBBaseOcrOverlaySettings))]
    interface MBDocumentOverlaySettings
    {
        // @property (nonatomic, strong) NSString * _Nonnull tooltipText;
        [Export("tooltipText", ArgumentSemantic.Strong)]
        string TooltipText { get; set; }

        // @property (assign, nonatomic) BOOL showTooltip;
        [Export("showTooltip")]
        bool ShowTooltip { get; set; }
    }

    // @interface MBDocumentOverlayViewController : MBBaseOverlayViewController
    
    [BaseType(typeof(MBBaseOverlayViewController))]
    interface MBDocumentOverlayViewController
    {
        // @property (readonly, nonatomic, strong) MBDocumentOverlaySettings * _Nonnull settings;
        [Export("settings", ArgumentSemantic.Strong)]
        MBDocumentOverlaySettings Settings { get; }

        [Wrap("WeakDelegate")]
        [NullAllowed]
        MBDocumentOverlayViewControllerDelegate Delegate { get; }

        // @property (readonly, nonatomic, weak) id<MBDocumentOverlayViewControllerDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; }

        // -(instancetype _Nonnull)initWithSettings:(MBDocumentOverlaySettings * _Nonnull)settings recognizerCollection:(MBRecognizerCollection * _Nonnull)recognizerCollection delegate:(id<MBDocumentOverlayViewControllerDelegate> _Nonnull)delegate;
        [Export("initWithSettings:recognizerCollection:delegate:")]
        IntPtr Constructor(MBDocumentOverlaySettings settings, MBRecognizerCollection recognizerCollection, MBDocumentOverlayViewControllerDelegate @delegate);
    }

    // @protocol MBDocumentOverlayViewControllerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface MBDocumentOverlayViewControllerDelegate
    {
        // @required -(void)documentOverlayViewControllerDidFinishScanning:(MBDocumentOverlayViewController * _Nonnull)documentOverlayViewController state:(MBRecognizerResultState)state;
        [Abstract]
        [Export("documentOverlayViewControllerDidFinishScanning:state:")]
        void DocumentOverlayViewControllerDidFinishScanning(MBDocumentOverlayViewController documentOverlayViewController, MBRecognizerResultState state);

        // @required -(void)documentOverlayViewControllerDidTapClose:(MBDocumentOverlayViewController * _Nonnull)documentOverlayViewController;
        [Abstract]
        [Export("documentOverlayViewControllerDidTapClose:")]
        void DocumentOverlayViewControllerDidTapClose(MBDocumentOverlayViewController documentOverlayViewController);
    }

    // @interface MBDocumentVerificationOverlaySettings : MBBaseOcrOverlaySettings
    [iOS (8,0)]
    [BaseType (typeof(MBBaseOcrOverlaySettings))]
    interface MBDocumentVerificationOverlaySettings
    {
        // @property (nonatomic, strong) NSString * _Nonnull firstSideInstructions;
        [Export ("firstSideInstructions", ArgumentSemantic.Strong)]
        string FirstSideInstructions { get; set; }

        // @property (nonatomic, strong) NSString * _Nonnull secondSideInstructions;
        [Export ("secondSideInstructions", ArgumentSemantic.Strong)]
        string SecondSideInstructions { get; set; }

        // @property (nonatomic, strong) NSString * _Nonnull firstSideSplashMessage;
        [Export ("firstSideSplashMessage", ArgumentSemantic.Strong)]
        string FirstSideSplashMessage { get; set; }

        // @property (nonatomic, strong) NSString * _Nonnull secondSideSplashMessage;
        [Export ("secondSideSplashMessage", ArgumentSemantic.Strong)]
        string SecondSideSplashMessage { get; set; }

        // @property (nonatomic, strong) NSString * _Nonnull scanningDoneSplashMessage;
        [Export ("scanningDoneSplashMessage", ArgumentSemantic.Strong)]
        string ScanningDoneSplashMessage { get; set; }

        // @property (nonatomic, strong) NSString * _Nonnull glareMessage;
        [Export ("glareMessage", ArgumentSemantic.Strong)]
        string GlareMessage { get; set; }

        // @property (nonatomic, strong) UIImage * _Nonnull firstSideSplashImage;
        [Export ("firstSideSplashImage", ArgumentSemantic.Strong)]
        UIImage FirstSideSplashImage { get; set; }

        // @property (nonatomic, strong) UIImage * _Nonnull secondSideSplashImage;
        [Export ("secondSideSplashImage", ArgumentSemantic.Strong)]
        UIImage SecondSideSplashImage { get; set; }

        // @property (nonatomic, strong) UIImage * _Nonnull firstSideInstructionsImage;
        [Export ("firstSideInstructionsImage", ArgumentSemantic.Strong)]
        UIImage FirstSideInstructionsImage { get; set; }

        // @property (nonatomic, strong) UIImage * _Nonnull secondSideInstructionsImage;
        [Export ("secondSideInstructionsImage", ArgumentSemantic.Strong)]
        UIImage SecondSideInstructionsImage { get; set; }
    }

    // @interface MBDocumentVerificationOverlayViewController : MBBaseOverlayViewController
    
    [BaseType(typeof(MBBaseOverlayViewController))]
    interface MBDocumentVerificationOverlayViewController
    {
        // @property (readonly, nonatomic, strong) MBDocumentVerificationOverlaySettings * _Nonnull settings;
        [Export("settings", ArgumentSemantic.Strong)]
        MBDocumentVerificationOverlaySettings Settings { get; }

        [Wrap("WeakDelegate")]
        [NullAllowed]
        MBDocumentVerificationOverlayViewControllerDelegate Delegate { get; }

        // @property (readonly, nonatomic, weak) id<MBDocumentVerificationOverlayViewControllerDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; }

        // -(instancetype _Nonnull)initWithSettings:(MBDocumentVerificationOverlaySettings * _Nonnull)settings recognizerCollection:(MBRecognizerCollection * _Nonnull)recognizerCollection delegate:(id<MBDocumentVerificationOverlayViewControllerDelegate> _Nonnull)delegate;
        [Export("initWithSettings:recognizerCollection:delegate:")]
        IntPtr Constructor(MBDocumentVerificationOverlaySettings settings, MBRecognizerCollection recognizerCollection, MBDocumentVerificationOverlayViewControllerDelegate @delegate);
    }

    // @protocol MBDocumentVerificationOverlayViewControllerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface MBDocumentVerificationOverlayViewControllerDelegate
    {
        // @required -(void)documentVerificationOverlayViewControllerDidFinishScanning:(MBDocumentVerificationOverlayViewController * _Nonnull)documentVerificationOverlayViewController state:(MBRecognizerResultState)state;
        [Abstract]
        [Export("documentVerificationOverlayViewControllerDidFinishScanning:state:")]
        void DocumentVerificationOverlayViewControllerDidFinishScanning (MBDocumentVerificationOverlayViewController documentVerificationOverlayViewController, MBRecognizerResultState state);

        // @required -(void)documentVerificationOverlayViewControllerDidTapClose:(MBDocumentVerificationOverlayViewController * _Nonnull)documentVerificationOverlayViewController;
        [Abstract]
        [Export("documentVerificationOverlayViewControllerDidTapClose:")]
        void DocumentVerificationOverlayViewControllerDidTapClose (MBDocumentVerificationOverlayViewController documentVerificationOverlayViewController);

        // @optional -(void)documentVerificationOverlayViewControllerDidFinishScanningFirstSide:(MBDocumentVerificationOverlayViewController * _Nonnull)documentVerificationOverlayViewController;
        [Export("documentVerificationOverlayViewControllerDidFinishScanningFirstSide:")]
        void DocumentVerificationOverlayViewControllerDidFinishScanningFirstSide (MBDocumentVerificationOverlayViewController documentVerificationOverlayViewController);
    }

    // @interface MBBlinkIdOverlayViewController : MBBaseOverlayViewController
    [iOS (8,0)]
    [BaseType (typeof(MBBaseOverlayViewController))]
    interface MBBlinkIdOverlayViewController
    {
        // @property (readonly, nonatomic) MBBlinkIdOverlaySettings * _Nonnull settings;
        [Export ("settings")]
        MBBlinkIdOverlaySettings Settings { get; }

        [Wrap ("WeakDelegate")]
        [NullAllowed]
        MBBlinkIdOverlayViewControllerDelegate Delegate { get; }

        // @property (readonly, nonatomic, weak) id<MBBlinkIdOverlayViewControllerDelegate> _Nullable delegate;
        [NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; }

        // -(instancetype _Nonnull)initWithSettings:(MBBlinkIdOverlaySettings * _Nonnull)settings recognizerCollection:(MBRecognizerCollection * _Nonnull)recognizerCollection delegate:(id<MBBlinkIdOverlayViewControllerDelegate> _Nonnull)delegate;
        [Export ("initWithSettings:recognizerCollection:delegate:")]
        IntPtr Constructor (MBBlinkIdOverlaySettings settings, MBRecognizerCollection recognizerCollection, MBBlinkIdOverlayViewControllerDelegate @delegate);
    }

    // @protocol MBBlinkIdOverlayViewControllerDelegate <NSObject>
    [Protocol, Model]
    [BaseType (typeof(NSObject))]
    interface MBBlinkIdOverlayViewControllerDelegate
    {
        // @required -(void)blinkIdOverlayViewControllerDidFinishScanning:(MBBlinkIdOverlayViewController * _Nonnull)blinkIdOverlayViewController state:(MBRecognizerResultState)state;
        [Abstract]
        [Export ("blinkIdOverlayViewControllerDidFinishScanning:state:")]
        void BlinkIdOverlayViewControllerDidFinishScanning (MBBlinkIdOverlayViewController blinkIdOverlayViewController, MBRecognizerResultState state);

        // @required -(void)blinkIdOverlayViewControllerDidTapClose:(MBBlinkIdOverlayViewController * _Nonnull)blinkIdOverlayViewController;
        [Abstract]
        [Export ("blinkIdOverlayViewControllerDidTapClose:")]
        void BlinkIdOverlayViewControllerDidTapClose (MBBlinkIdOverlayViewController blinkIdOverlayViewController);

        // @optional -(void)blinkIdOverlayViewControllerDidFinishScanningFirstSide:(MBBlinkIdOverlayViewController * _Nonnull)blinkIdOverlayViewController;
        [Export ("blinkIdOverlayViewControllerDidFinishScanningFirstSide:")]
        void BlinkIdOverlayViewControllerDidFinishScanningFirstSide (MBBlinkIdOverlayViewController blinkIdOverlayViewController);
    }

    // @interface MBBlinkIdOverlaySettings : MBBaseOverlaySettings
	[iOS (8,0)]
	[BaseType (typeof(MBBaseOverlaySettings))]
	interface MBBlinkIdOverlaySettings
	{
		// @property (assign, nonatomic) BOOL requireDocumentSidesDataMatch;
		[Export ("requireDocumentSidesDataMatch")]
		bool RequireDocumentSidesDataMatch { get; set; }

		// @property (assign, nonatomic) BOOL showNotSupportedDialog;
		[Export ("showNotSupportedDialog")]
		bool ShowNotSupportedDialog { get; set; }

		// @property (assign, nonatomic) NSTimeInterval backSideScanningTimeout;
		[Export ("backSideScanningTimeout")]
		double BackSideScanningTimeout { get; set; }

		// @property (nonatomic, strong) NSString * _Nonnull firstSideInstructionsText;
		[Export ("firstSideInstructionsText", ArgumentSemantic.Strong)]
		string FirstSideInstructionsText { get; set; }

		// @property (nonatomic, strong) NSString * _Nonnull scanBarcodeText;
		[Export ("scanBarcodeText", ArgumentSemantic.Strong)]
		string ScanBarcodeText { get; set; }

		// @property (nonatomic, strong) NSString * _Nonnull flipInstructions;
		[Export ("flipInstructions", ArgumentSemantic.Strong)]
		string FlipInstructions { get; set; }

		// @property (nonatomic, strong) NSString * _Nonnull errorMoveCloser;
		[Export ("errorMoveCloser", ArgumentSemantic.Strong)]
		string ErrorMoveCloser { get; set; }

		// @property (nonatomic, strong) NSString * _Nonnull errorMoveFarther;
		[Export ("errorMoveFarther", ArgumentSemantic.Strong)]
		string ErrorMoveFarther { get; set; }

		// @property (nonatomic, strong) NSString * _Nonnull errorDocumentTooCloseToEdge;
		[Export ("errorDocumentTooCloseToEdge", ArgumentSemantic.Strong)]
		string ErrorDocumentTooCloseToEdge { get; set; }

		// @property (nonatomic, strong) NSString * _Nonnull sidesNotMatchingTitle;
		[Export ("sidesNotMatchingTitle", ArgumentSemantic.Strong)]
		string SidesNotMatchingTitle { get; set; }

		// @property (nonatomic, strong) NSString * _Nonnull sidesNotMatchingMessage;
		[Export ("sidesNotMatchingMessage", ArgumentSemantic.Strong)]
		string SidesNotMatchingMessage { get; set; }

		// @property (nonatomic, strong) NSString * _Nonnull unsupportedDocumentTitle;
		[Export ("unsupportedDocumentTitle", ArgumentSemantic.Strong)]
		string UnsupportedDocumentTitle { get; set; }

		// @property (nonatomic, strong) NSString * _Nonnull unsupportedDocumentMessage;
		[Export ("unsupportedDocumentMessage", ArgumentSemantic.Strong)]
		string UnsupportedDocumentMessage { get; set; }

		// @property (nonatomic, strong) NSString * _Nonnull recognitionTimeoutTitle;
		[Export ("recognitionTimeoutTitle", ArgumentSemantic.Strong)]
		string RecognitionTimeoutTitle { get; set; }

		// @property (nonatomic, strong) NSString * _Nonnull recognitionTimeoutMessage;
		[Export ("recognitionTimeoutMessage", ArgumentSemantic.Strong)]
		string RecognitionTimeoutMessage { get; set; }

		// @property (nonatomic, strong) NSString * _Nonnull retryButtonText;
		[Export ("retryButtonText", ArgumentSemantic.Strong)]
		string RetryButtonText { get; set; }
	}

    // @interface MBDocumentSubview : MBSubview

    [BaseType(typeof(MBSubview))]
    interface MBDocumentSubview
    {
        // @property (nonatomic) UIView * _Nonnull viewfinderView;
        [Export("viewfinderView", ArgumentSemantic.Assign)]
        UIView ViewfinderView { get; set; }

        // @property (nonatomic) CGFloat viewfinderWidthToHeightRatio;
        [Export("viewfinderWidthToHeightRatio")]
        nfloat ViewfinderWidthToHeightRatio { get; set; }

        // @property (nonatomic) UILabel * _Nonnull tooltipLabel;
        [Export("tooltipLabel", ArgumentSemantic.Assign)]
        UILabel TooltipLabel { get; set; }

        // -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
        [Export("initWithFrame:")]
        [DesignatedInitializer]
        IntPtr Constructor(CGRect frame);
    }

    // @interface MBDocumentVerificationSubview : MBSubview
    
    [BaseType(typeof(MBSubview))]
    interface MBDocumentVerificationSubview
    {
        // @property (nonatomic) UILabel * _Nonnull helpLabel;
        [Export("helpLabel", ArgumentSemantic.Assign)]
        UILabel HelpLabel { get; set; }

        // @property (nonatomic) UIImageView * _Nonnull helpImageView;
        [Export("helpImageView", ArgumentSemantic.Assign)]
        UIImageView HelpImageView { get; set; }

        // -(void)animateHelp;
        [Export("animateHelp")]
        void AnimateHelp();

        [Wrap("WeakDocumentVerificationSubviewDelegate")]
        [NullAllowed]
        MBDocumentVerificationSubviewDelegate DocumentVerificationSubviewDelegate { get; set; }

        // @property (nonatomic, weak) id<MBDocumentVerificationSubviewDelegate> _Nullable documentVerificationSubviewDelegate;
        [NullAllowed, Export("documentVerificationSubviewDelegate", ArgumentSemantic.Weak)]
        NSObject WeakDocumentVerificationSubviewDelegate { get; set; }
    }

    // @protocol MBDocumentVerificationSubviewDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface MBDocumentVerificationSubviewDelegate
    {
        // @required -(void)documentVerificationSubviewDidFinishAnimation:(MBDocumentVerificationSubview * _Nonnull)documentVerificationSubview;
        [Abstract]
        [Export("documentVerificationSubviewDidFinishAnimation:")]
        void DocumentVerificationSubviewDidFinishAnimation(MBDocumentVerificationSubview documentVerificationSubview);
    }

    // @interface MBDocumentVerificationInstructionsSubview : MBSubview
    
    [BaseType(typeof(MBSubview))]
    interface MBDocumentVerificationInstructionsSubview
    {
        // @property (nonatomic) UILabel * _Nonnull instructionsLabel;
        [Export("instructionsLabel", ArgumentSemantic.Assign)]
        UILabel InstructionsLabel { get; set; }

        // @property (nonatomic) UIImageView * _Nonnull instructionsImageView;
        [Export("instructionsImageView", ArgumentSemantic.Assign)]
        UIImageView InstructionsImageView { get; set; }
    }
}
