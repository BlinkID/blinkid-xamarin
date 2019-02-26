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
    [BaseType(typeof(NSObject))]
    interface MBRecognizerRunnerViewController
    {
        // @required @property (nonatomic) BOOL autorotate;
        [Abstract]
        [Export("autorotate")]
        bool Autorotate { get; set; }

        // @required @property (nonatomic) UIInterfaceOrientationMask supportedOrientations;
        [Abstract]
        [Export("supportedOrientations", ArgumentSemantic.Assign)]
        UIInterfaceOrientationMask SupportedOrientations { get; set; }

        // @required -(BOOL)pauseScanning;
        [Abstract]
        [Export("pauseScanning")]
        bool PauseScanning();

        // @required -(BOOL)isScanningPaused;
        [Abstract]
        [Export("isScanningPaused")]
        bool IsScanningPaused { get; }

        // @required -(BOOL)resumeScanningAndResetState:(BOOL)resetState;
        [Abstract]
        [Export("resumeScanningAndResetState:")]
        bool ResumeScanningAndResetState(bool resetState);

        // @required -(BOOL)resumeCamera;
        [Abstract]
        [Export("resumeCamera")]
        bool ResumeCamera();

        // @required -(BOOL)pauseCamera;
        [Abstract]
        [Export("pauseCamera")]
        bool PauseCamera();

        // @required -(BOOL)isCameraPaused;
        [Abstract]
        [Export("isCameraPaused")]
        bool IsCameraPaused { get; }

        // @required -(void)playScanSuccessSound;
        [Abstract]
        [Export("playScanSuccessSound")]
        void PlayScanSuccessSound();

        // @required -(void)willSetTorchOn:(BOOL)torchOn;
        [Abstract]
        [Export("willSetTorchOn:")]
        void WillSetTorchOn(bool torchOn);

        // @required -(void)resetState;
        [Abstract]
        [Export("resetState")]
        void ResetState();

        // @required -(BOOL)isScanningUnsupportedForCameraType:(MBCameraType)type error:(NSError * _Nullable * _Nullable)error;
        [Abstract]
        [Export("isScanningUnsupportedForCameraType:error:")]
        bool IsScanningUnsupportedForCameraType(MBCameraType type, [NullAllowed] out NSError error);
    }
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

    // @interface MBPdf417RecognizerResult : MBRecognizerResult <NSCopying>
    
    [BaseType(typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBPdf417RecognizerResult : INSCopying
    {
        // @property (readonly, nonatomic, strong) NSData * _Nullable rawData;
        [NullAllowed, Export("rawData", ArgumentSemantic.Strong)]
        NSData RawData { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nullable stringData;
        [NullAllowed, Export("stringData", ArgumentSemantic.Strong)]
        string StringData { get; }

        // @property (readonly, assign, nonatomic) BOOL uncertain;
        [Export("uncertain")]
        bool Uncertain { get; }

        // @property (readonly, assign, nonatomic) MBBarcodeType barcodeType;
        [Export("barcodeType", ArgumentSemantic.Assign)]
        MBBarcodeType BarcodeType { get; }
    }

    // @interface MBPdf417Recognizer : MBRecognizer <NSCopying>
    
    [BaseType(typeof(MBRecognizer))]
    interface MBPdf417Recognizer : INSCopying
    {
        // @property (readonly, nonatomic, strong) MBPdf417RecognizerResult * _Nonnull result;
        [Export("result", ArgumentSemantic.Strong)]
        MBPdf417RecognizerResult Result { get; }

        // @property (assign, nonatomic) BOOL scanUncertain;
        [Export("scanUncertain")]
        bool ScanUncertain { get; set; }

        // @property (assign, nonatomic) BOOL nullQuietZoneAllowed;
        [Export("nullQuietZoneAllowed")]
        bool NullQuietZoneAllowed { get; set; }

        // @property (assign, nonatomic) BOOL scanInverse;
        [Export("scanInverse")]
        bool ScanInverse { get; set; }
    }

    // @interface MBSimNumberRecognizerResult : MBRecognizerResult <NSCopying>
    
    [BaseType(typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBSimNumberRecognizerResult : INSCopying
    {
        // @property (readonly, nonatomic, strong) NSString * _Nullable simNumber;
        [NullAllowed, Export("simNumber", ArgumentSemantic.Strong)]
        string SimNumber { get; }
    }

    // @interface MBSimNumberRecognizer : MBRecognizer <NSCopying>
    
    [BaseType(typeof(MBRecognizer))]
    interface MBSimNumberRecognizer : INSCopying
    {
        // @property (readonly, nonatomic, strong) MBSimNumberRecognizerResult * _Nonnull result;
        [Export("result", ArgumentSemantic.Strong)]
        MBSimNumberRecognizerResult Result { get; }
    }

    // @interface MBVinRecognizerResult : MBRecognizerResult <NSCopying>
    
    [BaseType(typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBVinRecognizerResult : INSCopying
    {
        // @property (readonly, nonatomic, strong) NSString * _Nullable vin;
        [NullAllowed, Export("vin", ArgumentSemantic.Strong)]
        string Vin { get; }
    }

    // @interface MBVinRecognizer : MBRecognizer <NSCopying>
    
    [BaseType(typeof(MBRecognizer))]
    interface MBVinRecognizer : INSCopying
    {
        // @property (readonly, nonatomic, strong) MBVinRecognizerResult * _Nonnull result;
        [Export("result", ArgumentSemantic.Strong)]
        MBVinRecognizerResult Result { get; }
    }

    // @interface MBBarcodeRecognizerResult : MBRecognizerResult <NSCopying>
    
    [BaseType(typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBBarcodeRecognizerResult : INSCopying
    {
        // @property (readonly, nonatomic, strong) NSData * _Nullable rawData;
        [NullAllowed, Export("rawData", ArgumentSemantic.Strong)]
        NSData RawData { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nullable stringData;
        [NullAllowed, Export("stringData", ArgumentSemantic.Strong)]
        string StringData { get; }

        // @property (readonly, assign, nonatomic) BOOL uncertain;
        [Export("uncertain")]
        bool Uncertain { get; }

        // +(NSString * _Nonnull)toTypeName:(MBBarcodeType)type;
        [Static]
        [Export("toTypeName:")]
        string ToTypeName(MBBarcodeType type);

        // @property (readonly, assign, nonatomic) MBBarcodeType barcodeType;
        [Export("barcodeType", ArgumentSemantic.Assign)]
        MBBarcodeType BarcodeType { get; }
    }

    // @interface MBBarcodeRecognizer : MBRecognizer <NSCopying>
    
    [BaseType(typeof(MBRecognizer))]
    interface MBBarcodeRecognizer : INSCopying
    {
        // @property (readonly, nonatomic, strong) MBBarcodeRecognizerResult * _Nonnull result;
        [Export("result", ArgumentSemantic.Strong)]
        MBBarcodeRecognizerResult Result { get; }

        // @property (assign, nonatomic) BOOL scanAztecCode;
        [Export("scanAztecCode")]
        bool ScanAztecCode { get; set; }

        // @property (assign, nonatomic) BOOL scanCode128;
        [Export("scanCode128")]
        bool ScanCode128 { get; set; }

        // @property (assign, nonatomic) BOOL scanCode39;
        [Export("scanCode39")]
        bool ScanCode39 { get; set; }

        // @property (assign, nonatomic) BOOL scanDataMatrix;
        [Export("scanDataMatrix")]
        bool ScanDataMatrix { get; set; }

        // @property (assign, nonatomic) BOOL scanEan13;
        [Export("scanEan13")]
        bool ScanEan13 { get; set; }

        // @property (assign, nonatomic) BOOL scanEan8;
        [Export("scanEan8")]
        bool ScanEan8 { get; set; }

        // @property (assign, nonatomic) BOOL scanItf;
        [Export("scanItf")]
        bool ScanItf { get; set; }

        // @property (assign, nonatomic) BOOL scanQrCode;
        [Export("scanQrCode")]
        bool ScanQrCode { get; set; }

        // @property (assign, nonatomic) BOOL scanUpca;
        [Export("scanUpca")]
        bool ScanUpca { get; set; }

        // @property (assign, nonatomic) BOOL scanUpce;
        [Export("scanUpce")]
        bool ScanUpce { get; set; }

        // @property (assign, nonatomic) BOOL scanPdf417;
        [Export("scanPdf417")]
        bool ScanPdf417 { get; set; }

        // @property (assign, nonatomic) BOOL slowerThoroughScan;
        [Export("slowerThoroughScan")]
        bool SlowerThoroughScan { get; set; }

        // @property (assign, nonatomic) BOOL autoScaleDetection;
        [Export("autoScaleDetection")]
        bool AutoScaleDetection { get; set; }

        // @property (assign, nonatomic) BOOL readCode39AsExtendedData;
        [Export("readCode39AsExtendedData")]
        bool ReadCode39AsExtendedData { get; set; }

        // @property (assign, nonatomic) BOOL scanInverse;
        [Export("scanInverse")]
        bool ScanInverse { get; set; }

        // @property (assign, nonatomic) BOOL scanUncertain;
        [Export("scanUncertain")]
        bool ScanUncertain { get; set; }

        // @property (assign, nonatomic) BOOL nullQuietZoneAllowed;
        [Export("nullQuietZoneAllowed")]
        bool NullQuietZoneAllowed { get; set; }

        // @property (nonatomic, strong) NSString * _Nonnull manateeLicenseKey;
        [Export("manateeLicenseKey", ArgumentSemantic.Strong)]
        string ManateeLicenseKey { get; set; }
    }

    // @interface MBDetectorResult : NSObject
    
    [BaseType(typeof(NSObject))]
    interface MBDetectorResult
    {
        // @property (readonly, assign, nonatomic) MBDetectionCode detectionCode;
        [Export("detectionCode", ArgumentSemantic.Assign)]
        MBDetectionCode DetectionCode { get; }

        // @property (readonly, assign, nonatomic) MBDetectionStatus detectionStatus;
        [Export("detectionStatus", ArgumentSemantic.Assign)]
        MBDetectionStatus DetectionStatus { get; }
    }

    // @interface MBDetector : MBEntity
    
    [BaseType(typeof(MBEntity))]
    interface MBDetector
    {
        // @property (readonly, nonatomic, weak) MBDetectorResult * _Nullable baseResult;
        [NullAllowed, Export("baseResult", ArgumentSemantic.Weak)]
        MBDetectorResult BaseResult { get; }
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

    // @interface MBQuadDetectorResult : MBDetectorResult <NSCopying>
    
    [BaseType(typeof(MBDetectorResult))]
    [DisableDefaultCtor]
    interface MBQuadDetectorResult : INSCopying
    {
        // @property (readonly, nonatomic, strong) MBQuadrangle * _Nullable quadrangle;
        [NullAllowed, Export("quadrangle", ArgumentSemantic.Strong)]
        MBQuadrangle Quadrangle { get; }
    }

    // @interface MBQuadDetector : MBDetector
    
    [BaseType(typeof(MBDetector))]
    [DisableDefaultCtor]
    interface MBQuadDetector
    {
        // @property (readonly, nonatomic, weak) MBQuadDetectorResult * _Nullable quadResult;
        [NullAllowed, Export("quadResult", ArgumentSemantic.Weak)]
        MBQuadDetectorResult QuadResult { get; }
    }

    // @interface MBQuadWithSizeDetectorResult : MBQuadDetectorResult <NSCopying>
    
    [BaseType(typeof(MBQuadDetectorResult))]
    [DisableDefaultCtor]
    interface MBQuadWithSizeDetectorResult : INSCopying
    {
        // @property (readonly, assign, nonatomic) CGFloat physicalHeightInInches;
        [Export("physicalHeightInInches")]
        nfloat PhysicalHeightInInches { get; }
    }

    // @interface MBQuadWithSizeDetector : MBQuadDetector
    
    [BaseType(typeof(MBQuadDetector))]
    [DisableDefaultCtor]
    interface MBQuadWithSizeDetector
    {
        // @property (readonly, nonatomic, weak) MBQuadWithSizeDetectorResult * _Nullable quadWithSizeResult;
        [NullAllowed, Export("quadWithSizeResult", ArgumentSemantic.Weak)]
        MBQuadWithSizeDetectorResult QuadWithSizeResult { get; }
    }

    // @interface MBMrtdDetectorResult : MBQuadWithSizeDetectorResult <NSCopying>
    
    [BaseType(typeof(MBQuadWithSizeDetectorResult))]
    [DisableDefaultCtor]
    interface MBMrtdDetectorResult : INSCopying
    {
        // @property (readonly, nonatomic, strong) MBQuadrangle * _Nullable mrzLocation;
        [NullAllowed, Export("mrzLocation", ArgumentSemantic.Strong)]
        MBQuadrangle MrzLocation { get; }

        // @property (readonly, assign, nonatomic) CGFloat mrzPhysicalHeightInInches;
        [Export("mrzPhysicalHeightInInches")]
        nfloat MrzPhysicalHeightInInches { get; }
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

    // @interface MBMrtdDetector : MBQuadWithSizeDetector <NSCopying>
    
    [BaseType(typeof(MBQuadWithSizeDetector))]
    interface MBMrtdDetector : INSCopying
    {
        // @property (readonly, nonatomic, strong) MBMrtdDetectorResult * _Nonnull result;
        [Export("result", ArgumentSemantic.Strong)]
        MBMrtdDetectorResult Result { get; }

        // @property (assign, nonatomic) BOOL detectFullDocument;
        [Export("detectFullDocument")]
        bool DetectFullDocument { get; set; }

        // @property (assign, nonatomic) BOOL useCardDetector;
        [Export("useCardDetector")]
        bool UseCardDetector { get; set; }

        // -(void)setMrtdSpecifications:(NSArray<__kindof MBMrtdSpecification *> * _Nonnull)mrtdSpecifications;
        [Export("setMrtdSpecifications:")]
        void SetMrtdSpecifications(MBMrtdSpecification[] mrtdSpecifications);
    }

    // @interface MBDocumentSpecification : NSObject <NSCopying>
    
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBDocumentSpecification : INSCopying
    {
        // -(instancetype _Nonnull)initWithAspectRatio:(CGFloat)aspectRatio physicalSizeInInches:(CGFloat)physicalSizeInInches;
        [Export("initWithAspectRatio:physicalSizeInInches:")]
        IntPtr Constructor(nfloat aspectRatio, nfloat physicalSizeInInches);

        // +(instancetype _Nonnull)createFromPreset:(MBDocumentSpecificationPreset)preset;
        [Static]
        [Export("createFromPreset:")]
        MBDocumentSpecification CreateFromPreset(MBDocumentSpecificationPreset preset);

        // -(void)setPortraitAndLandscapeScale:(MBScale)scale;
        [Export("setPortraitAndLandscapeScale:")]
        void SetPortraitAndLandscapeScale(MBScale scale);

        // @property (assign, nonatomic) CGFloat maxAngle;
        [Export("maxAngle")]
        nfloat MaxAngle { get; set; }

        // @property (assign, nonatomic) MBScale portraitScale;
        [Export("portraitScale", ArgumentSemantic.Assign)]
        MBScale PortraitScale { get; set; }

        // @property (assign, nonatomic) MBScale landscapeScale;
        [Export("landscapeScale", ArgumentSemantic.Assign)]
        MBScale LandscapeScale { get; set; }

        // @property (assign, nonatomic) MBScanningMode scanningMode;
        [Export("scanningMode", ArgumentSemantic.Assign)]
        MBScanningMode ScanningMode { get; set; }

        // @property (assign, nonatomic) MBRange xRange;
        [Export("xRange", ArgumentSemantic.Assign)]
        MBRange XRange { get; set; }

        // @property (assign, nonatomic) MBRange yRange;
        [Export("yRange", ArgumentSemantic.Assign)]
        MBRange YRange { get; set; }

        // @property (readonly, assign, nonatomic) CGFloat physicalSizeInInches;
        [Export("physicalSizeInInches")]
        nfloat PhysicalSizeInInches { get; }
    }

    // @interface MBDocumentDetectorResult : MBQuadWithSizeDetectorResult <NSCopying>
    
    [BaseType(typeof(MBQuadWithSizeDetectorResult))]
    [DisableDefaultCtor]
    interface MBDocumentDetectorResult : INSCopying
    {
        // @property (readonly, assign, nonatomic) CGFloat aspectRatio;
        [Export("aspectRatio")]
        nfloat AspectRatio { get; }
    }

    // @interface MBDocumentDetector : MBQuadWithSizeDetector <NSCopying>
    
    [BaseType(typeof(MBQuadWithSizeDetector))]
    [DisableDefaultCtor]
    interface MBDocumentDetector : INSCopying
    {
        // -(instancetype _Nonnull)initWithDocumentSpecifications:(NSArray<__kindof MBDocumentSpecification *> * _Nonnull)documentSpecifications __attribute__((objc_designated_initializer));
        [Export("initWithDocumentSpecifications:")]
        [DesignatedInitializer]
        IntPtr Constructor(MBDocumentSpecification[] documentSpecifications);

        // @property (readonly, nonatomic, strong) MBDocumentDetectorResult * _Nonnull result;
        [Export("result", ArgumentSemantic.Strong)]
        MBDocumentDetectorResult Result { get; }

        // @property (assign, nonatomic) NSUInteger numStableDetectionsThreshold;
        [Export("numStableDetectionsThreshold")]
        nuint NumStableDetectionsThreshold { get; set; }

        // @property (readonly, nonatomic, strong) NSArray<__kindof MBDocumentSpecification *> * _Nonnull documentSpecifications;
        [Export("documentSpecifications", ArgumentSemantic.Strong)]
        MBDocumentSpecification[] DocumentSpecifications { get; }
    }

    // @interface MBBlinkInputRecognizerResult : MBRecognizerResult <NSCopying>
    
    [BaseType(typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBBlinkInputRecognizerResult : INSCopying
    {
    }

    // @interface MBBlinkInputRecognizer : MBRecognizer <NSCopying>
    
    [BaseType(typeof(MBRecognizer))]
    interface MBBlinkInputRecognizer : INSCopying
    {
        // -(instancetype _Nonnull)initWithProcessors:(NSArray<MBProcessor *> * _Nonnull)processors __attribute__((objc_designated_initializer));
        [Export("initWithProcessors:")]
        [DesignatedInitializer]
        IntPtr Constructor(MBProcessor[] processors);

        // @property (readonly, nonatomic, strong) NSArray<MBProcessor *> * _Nonnull processors;
        [Export("processors", ArgumentSemantic.Strong)]
        MBProcessor[] Processors { get; }

        // @property (readonly, nonatomic, strong) MBBlinkInputRecognizerResult * _Nonnull result;
        [Export("result", ArgumentSemantic.Strong)]
        MBBlinkInputRecognizerResult Result { get; }
    }

    // @interface MBParserResult : NSObject
    
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBParserResult
    {
        // @property (readonly, assign, nonatomic) MBParserResultState resultState;
        [Export("resultState", ArgumentSemantic.Assign)]
        MBParserResultState ResultState { get; }
    }

    // @interface MBParser : MBEntity
    
    [BaseType(typeof(MBEntity))]
    interface MBParser
    {
        // @property (readonly, nonatomic, weak) MBParserResult * _Nullable baseResult;
        [NullAllowed, Export("baseResult", ArgumentSemantic.Weak)]
        MBParserResult BaseResult { get; }
    }

    // @interface MBVinParserResult : MBParserResult <NSCopying>
    
    [BaseType(typeof(MBParserResult))]
    [DisableDefaultCtor]
    interface MBVinParserResult : INSCopying
    {
        // @property (readonly, nonatomic, strong) NSString * _Nullable vin;
        [NullAllowed, Export("vin", ArgumentSemantic.Strong)]
        string Vin { get; }
    }

    // @interface MBVinParser : MBParser <NSCopying>
    
    [BaseType(typeof(MBParser))]
    interface MBVinParser : INSCopying
    {
        // @property (readonly, nonatomic, strong) MBVinParserResult * _Nonnull result;
        [Export("result", ArgumentSemantic.Strong)]
        MBVinParserResult Result { get; }
    }

    // @interface MBTopUpParserResult : MBParserResult <NSCopying>
    
    [BaseType(typeof(MBParserResult))]
    [DisableDefaultCtor]
    interface MBTopUpParserResult : INSCopying
    {
        // @property (readonly, nonatomic, strong) NSString * _Nullable topUp;
        [NullAllowed, Export("topUp", ArgumentSemantic.Strong)]
        string TopUp { get; }
    }

    // @interface MBTopUpParser : MBParser <NSCopying>
    
    [BaseType(typeof(MBParser))]
    interface MBTopUpParser : INSCopying
    {
        // @property (readonly, nonatomic, strong) MBTopUpParserResult * _Nonnull result;
        [Export("result", ArgumentSemantic.Strong)]
        MBTopUpParserResult Result { get; }

        // @property (assign, nonatomic) BOOL allowNoPrefix;
        [Export("allowNoPrefix")]
        bool AllowNoPrefix { get; set; }

        // @property (assign, nonatomic) BOOL returnCodeWithoutPrefix;
        [Export("returnCodeWithoutPrefix")]
        bool ReturnCodeWithoutPrefix { get; set; }

        // -(void)setTopUpPreset:(MBTopUpPreset)topUpPreset;
        [Export("setTopUpPreset:")]
        void SetTopUpPreset(MBTopUpPreset topUpPreset);

        // -(void)setPrefix:(NSString * _Nonnull)prefix andUssdCodeLength:(NSInteger)ussdCodeLength;
        [Export("setPrefix:andUssdCodeLength:")]
        void SetPrefix(string prefix, nint ussdCodeLength);
    }

    // @interface MBEmailParserResult : MBParserResult <NSCopying>
    
    [BaseType(typeof(MBParserResult))]
    [DisableDefaultCtor]
    interface MBEmailParserResult : INSCopying
    {
        // @property (readonly, nonatomic, strong) NSString * _Nullable email;
        [NullAllowed, Export("email", ArgumentSemantic.Strong)]
        string Email { get; }
    }

    // @interface MBEmailParser : MBParser <NSCopying>
    
    [BaseType(typeof(MBParser))]
    interface MBEmailParser : INSCopying
    {
        // @property (readonly, nonatomic, strong) MBEmailParserResult * _Nonnull result;
        [Export("result", ArgumentSemantic.Strong)]
        MBEmailParserResult Result { get; }
    }

    // @interface MBLicensePlatesParserResult : MBParserResult <NSCopying>
    
    [BaseType(typeof(MBParserResult))]
    [DisableDefaultCtor]
    interface MBLicensePlatesParserResult : INSCopying
    {
        // @property (readonly, nonatomic, strong) NSString * _Nullable licensePlate;
        [NullAllowed, Export("licensePlate", ArgumentSemantic.Strong)]
        string LicensePlate { get; }
    }

    // @interface MBLicensePlatesParser : MBParser <NSCopying>
    
    [BaseType(typeof(MBParser))]
    interface MBLicensePlatesParser : INSCopying
    {
        // @property (readonly, nonatomic, strong) MBLicensePlatesParserResult * _Nonnull result;
        [Export("result", ArgumentSemantic.Strong)]
        MBLicensePlatesParserResult Result { get; }
    }

    // @interface MBAmountParserResult : MBParserResult <NSCopying>
    
    [BaseType(typeof(MBParserResult))]
    [DisableDefaultCtor]
    interface MBAmountParserResult : INSCopying
    {
        // @property (readonly, nonatomic, strong) NSString * _Nullable amount;
        [NullAllowed, Export("amount", ArgumentSemantic.Strong)]
        string Amount { get; }
    }

    // @interface MBAmountParser : MBParser <NSCopying>
    
    [BaseType(typeof(MBParser))]
    interface MBAmountParser : INSCopying
    {
        // @property (readonly, nonatomic, strong) MBAmountParserResult * _Nonnull result;
        [Export("result", ArgumentSemantic.Strong)]
        MBAmountParserResult Result { get; }

        // @property (assign, nonatomic) BOOL allowNegativeAmounts;
        [Export("allowNegativeAmounts")]
        bool AllowNegativeAmounts { get; set; }

        // @property (assign, nonatomic) BOOL allowSpaceSeparators;
        [Export("allowSpaceSeparators")]
        bool AllowSpaceSeparators { get; set; }

        // @property (assign, nonatomic) BOOL allowMissingDecimals;
        [Export("allowMissingDecimals")]
        bool AllowMissingDecimals { get; set; }

        // @property (assign, nonatomic) BOOL arabicIndicMode;
        [Export("arabicIndicMode")]
        bool ArabicIndicMode { get; set; }
    }

    // @interface MBIbanParserResult : MBParserResult <NSCopying>
    
    [BaseType(typeof(MBParserResult))]
    [DisableDefaultCtor]
    interface MBIbanParserResult : INSCopying
    {
        // @property (readonly, nonatomic, strong) NSString * _Nullable iban;
        [NullAllowed, Export("iban", ArgumentSemantic.Strong)]
        string Iban { get; }
    }

    // @interface MBIbanParser : MBParser <NSCopying>
    
    [BaseType(typeof(MBParser))]
    interface MBIbanParser : INSCopying
    {
        // @property (readonly, nonatomic, strong) MBIbanParserResult * _Nonnull result;
        [Export("result", ArgumentSemantic.Strong)]
        MBIbanParserResult Result { get; }

        // @property (assign, nonatomic) BOOL alwaysReturnPrefix;
        [Export("alwaysReturnPrefix")]
        bool AlwaysReturnPrefix { get; set; }

        // @property (nonatomic, strong) NSArray<NSString *> * _Nullable countryCodeWhitelist;
        [NullAllowed, Export("countryCodeWhitelist", ArgumentSemantic.Strong)]
        string[] CountryCodeWhitelist { get; set; }
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

    // @interface MBDateParserResult : MBParserResult <NSCopying>
    
    [BaseType(typeof(MBParserResult))]
    [DisableDefaultCtor]
    interface MBDateParserResult : INSCopying
    {
        // @property (readonly, nonatomic, strong) MBDateResult * _Nonnull date;
        [Export("date", ArgumentSemantic.Strong)]
        MBDateResult Date { get; }
    }

    // @interface MBDateParser : MBParser <NSCopying>
    
    [BaseType(typeof(MBParser))]
    interface MBDateParser : INSCopying
    {
        // @property (readonly, nonatomic, strong) MBDateParserResult * _Nonnull result;
        [Export("result", ArgumentSemantic.Strong)]
        MBDateParserResult Result { get; }

        // -(void)setDateFormats:(MBDateFormatArray * _Nonnull)dateFormats;
        [Export("setDateFormats:")]
        void SetDateFormats(NSNumber[] dateFormats);

        // -(void)setDateSeparatorChars:(MBDateSeparatorCharsArray * _Nonnull)dateSeparatorChars;
        [Export("setDateSeparatorChars:")]
        void SetDateSeparatorChars(string[] dateSeparatorChars);
    }

    // @interface MBRawParserResult : MBParserResult <NSCopying>
    
    [BaseType(typeof(MBParserResult))]
    [DisableDefaultCtor]
    interface MBRawParserResult : INSCopying
    {
        // @property (readonly, nonatomic, strong) NSString * _Nonnull rawText;
        [Export("rawText", ArgumentSemantic.Strong)]
        string RawText { get; }
    }

    // @interface MBBaseOcrEngineOptions : NSObject
    
    [BaseType(typeof(NSObject))]
    interface MBBaseOcrEngineOptions
    {
        // @property (assign, nonatomic) NSUInteger maxCharsExpected;
        [Export("maxCharsExpected")]
        nuint MaxCharsExpected { get; set; }

        // @property (assign, nonatomic) BOOL colorDropoutEnabled;
        [Export("colorDropoutEnabled")]
        bool ColorDropoutEnabled { get; set; }
    }

    // @interface MBRawParser : MBParser <NSCopying>
    
    [BaseType(typeof(MBParser))]
    interface MBRawParser : INSCopying
    {
        // @property (readonly, nonatomic, strong) MBRawParserResult * _Nonnull result;
        [Export("result", ArgumentSemantic.Strong)]
        MBRawParserResult Result { get; }

        // @property (assign, nonatomic) BOOL useSieve;
        [Export("useSieve")]
        bool UseSieve { get; set; }

        // @property (nonatomic, strong) MBBaseOcrEngineOptions * _Nonnull ocrEngineOptions;
        [Export("ocrEngineOptions", ArgumentSemantic.Strong)]
        MBBaseOcrEngineOptions OcrEngineOptions { get; set; }
    }

    // @interface MBRegexParserResult : MBParserResult <NSCopying>
    
    [BaseType(typeof(MBParserResult))]
    [DisableDefaultCtor]
    interface MBRegexParserResult : INSCopying
    {
        // @property (readonly, nonatomic, strong) NSString * _Nonnull parsedString;
        [Export("parsedString", ArgumentSemantic.Strong)]
        string ParsedString { get; }
    }

    // @interface MBRegexParser : MBParser <NSCopying>
    
    [BaseType(typeof(MBParser))]
    [DisableDefaultCtor]
    interface MBRegexParser : INSCopying
    {
        // -(instancetype _Nonnull)initWithRegex:(NSString * _Nonnull)regex __attribute__((objc_designated_initializer));
        [Export("initWithRegex:")]
        [DesignatedInitializer]
        IntPtr Constructor(string regex);

        // @property (readonly, nonatomic, strong) MBRegexParserResult * _Nonnull result;
        [Export("result", ArgumentSemantic.Strong)]
        MBRegexParserResult Result { get; }

        // @property (nonatomic, strong) NSString * _Nonnull regex;
        [Export("regex", ArgumentSemantic.Strong)]
        string Regex { get; set; }

        // @property (assign, nonatomic) BOOL useSieve;
        [Export("useSieve")]
        bool UseSieve { get; set; }

        // @property (assign, nonatomic) BOOL startWithWhitespace;
        [Export("startWithWhitespace")]
        bool StartWithWhitespace { get; set; }

        // @property (assign, nonatomic) BOOL endWithWhitespace;
        [Export("endWithWhitespace")]
        bool EndWithWhitespace { get; set; }

        // @property (nonatomic, strong) MBBaseOcrEngineOptions * _Nonnull ocrEngineOptions;
        [Export("ocrEngineOptions", ArgumentSemantic.Strong)]
        MBBaseOcrEngineOptions OcrEngineOptions { get; set; }
    }

    // @interface MBDewarpPolicy : NSObject
    
    [BaseType(typeof(NSObject))]
    interface MBDewarpPolicy
    {
    }

    // @interface MBFixedDewarpPolicy : MBDewarpPolicy
    
    [BaseType(typeof(MBDewarpPolicy))]
    interface MBFixedDewarpPolicy
    {
        // -(instancetype _Nonnull)initWithDewarpHeight:(NSUInteger)dewarpHeight __attribute__((objc_designated_initializer));
        [Export("initWithDewarpHeight:")]
        [DesignatedInitializer]
        IntPtr Constructor(nuint dewarpHeight);

        // @property (readonly, assign, nonatomic) NSUInteger dewarpHeight;
        [Export("dewarpHeight")]
        nuint DewarpHeight { get; }
    }

    // @interface MBDPIBasedDewarpPolicy : MBDewarpPolicy
    
    [BaseType(typeof(MBDewarpPolicy))]
    interface MBDPIBasedDewarpPolicy
    {
        // -(instancetype _Nonnull)initWithDesiredDPI:(NSUInteger)desiredDPI __attribute__((objc_designated_initializer));
        [Export("initWithDesiredDPI:")]
        [DesignatedInitializer]
        IntPtr Constructor(nuint desiredDPI);

        // @property (readonly, assign, nonatomic) NSUInteger desiredDPI;
        [Export("desiredDPI")]
        nuint DesiredDPI { get; }
    }

    // @interface MBNoUpScalingDewarpPolicy : MBDewarpPolicy
    
    [BaseType(typeof(MBDewarpPolicy))]
    interface MBNoUpScalingDewarpPolicy
    {
        // -(instancetype _Nonnull)initWithMaxAllowedDewarpHeight:(NSUInteger)maxAllowedDewarpHeight __attribute__((objc_designated_initializer));
        [Export("initWithMaxAllowedDewarpHeight:")]
        [DesignatedInitializer]
        IntPtr Constructor(nuint maxAllowedDewarpHeight);

        // @property (readonly, assign, nonatomic) NSUInteger maxAllowedDewarpHeight;
        [Export("maxAllowedDewarpHeight")]
        nuint MaxAllowedDewarpHeight { get; }
    }

    // @interface MBDeepOcrEngineOptions : MBBaseOcrEngineOptions <NSCopying>
    
    [BaseType(typeof(MBBaseOcrEngineOptions))]
    interface MBDeepOcrEngineOptions : INSCopying
    {
        // @property (assign, nonatomic) CGFloat deepOcrPostprocessorNmsThreshold;
        [Export("deepOcrPostprocessorNmsThreshold")]
        nfloat DeepOcrPostprocessorNmsThreshold { get; set; }

        // @property (assign, nonatomic) CGFloat deepOcrPostprocessorScoreThreshold;
        [Export("deepOcrPostprocessorScoreThreshold")]
        nfloat DeepOcrPostprocessorScoreThreshold { get; set; }

        // @property (assign, nonatomic) MBDeepOcrModel deepOcrModel;
        [Export("deepOcrModel", ArgumentSemantic.Assign)]
        MBDeepOcrModel DeepOcrModel { get; set; }

        // @property (assign, nonatomic) NSString * _Nonnull deepOcrModelString;
        [Export("deepOcrModelString")]
        string DeepOcrModelString { get; set; }
    }

    // @interface MBOcrCharKey : NSObject
    
    [BaseType(typeof(NSObject))]
    interface MBOcrCharKey : INativeObject
    {
        // @property (assign, nonatomic) int code;
        [Export("code")]
        int Code { get; set; }

        // @property (assign, nonatomic) MBOcrFont font;
        [Export("font", ArgumentSemantic.Assign)]
        MBOcrFont Font { get; set; }

        // -(instancetype _Nonnull)initWithCode:(int)code font:(MBOcrFont)font;
        [Export("initWithCode:font:")]
        IntPtr Constructor(int code, MBOcrFont font);

        // +(instancetype _Nonnull)keyWithCode:(int)code font:(MBOcrFont)font;
        [Static]
        [Export("keyWithCode:font:")]
        MBOcrCharKey KeyWithCode(int code, MBOcrFont font);
    }

    // @interface MBOcrEngineOptions : MBBaseOcrEngineOptions <NSCopying>
    
    [BaseType(typeof(MBBaseOcrEngineOptions))]
    interface MBOcrEngineOptions : INSCopying
    {
        // @property (assign, nonatomic) PPDocumentType documentType;
        [Export("documentType", ArgumentSemantic.Assign)]
        PPDocumentType DocumentType { get; set; }

        // @property (assign, nonatomic) NSUInteger minimalLineHeight;
        [Export("minimalLineHeight")]
        nuint MinimalLineHeight { get; set; }

        // @property (assign, nonatomic) NSUInteger maximalLineHeight;
        [Export("maximalLineHeight")]
        nuint MaximalLineHeight { get; set; }

        // @property (assign, nonatomic) BOOL imageProcessingEnabled;
        [Export("imageProcessingEnabled")]
        bool ImageProcessingEnabled { get; set; }

        // @property (nonatomic, strong) NSSet<MBOcrCharKey *> * _Nonnull charWhitelist;
        [Export("charWhitelist", ArgumentSemantic.Strong)]
        NSSet<MBOcrCharKey> CharWhitelist { get; set; }
    }

    // @interface MBProcessorGroup : NSObject
    
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBProcessorGroup
    {
        // -(instancetype _Nonnull)initWithProcessingLocation:(CGRect)processingLocation dewarpPolicy:(MBDewarpPolicy * _Nonnull)dewarpPolicy andProcessors:(NSArray<__kindof MBProcessor *> * _Nonnull)processors __attribute__((objc_designated_initializer));
        [Export("initWithProcessingLocation:dewarpPolicy:andProcessors:")]
        [DesignatedInitializer]
        IntPtr Constructor(CGRect processingLocation, MBDewarpPolicy dewarpPolicy, MBProcessor[] processors);

        // @property (readonly, nonatomic, strong) NSArray<__kindof MBProcessor *> * _Nonnull processors;
        [Export("processors", ArgumentSemantic.Strong)]
        MBProcessor[] Processors { get; }
    }

    // @interface MBTemplatingClass : NSObject
    
    [BaseType(typeof(NSObject))]
    interface MBTemplatingClass
    {
        // -(void)setClassificationProcessorGroups:(NSArray<__kindof MBProcessorGroup *> * _Nonnull)processorGroups;
        [Export("setClassificationProcessorGroups:")]
        void SetClassificationProcessorGroups(MBProcessorGroup[] processorGroups);

        // -(NSArray<__kindof MBProcessorGroup *> * _Nullable)getClassificationProcessorGroups;
        [NullAllowed, Export("getClassificationProcessorGroups")]
        MBProcessorGroup[] GetClassificationProcessorGroups();

        // -(void)setNonClassificationProcessorGroups:(NSArray<__kindof MBProcessorGroup *> * _Nonnull)processorGroups;
        [Export("setNonClassificationProcessorGroups:")]
        void SetNonClassificationProcessorGroups(MBProcessorGroup[] processorGroups);

        // -(NSArray<__kindof MBProcessorGroup *> * _Nullable)getNonClassificationProcessorGroups;
        [NullAllowed, Export("getNonClassificationProcessorGroups")]
        MBProcessorGroup[] GetNonClassificationProcessorGroups();

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

    // @interface MBDetectorRecognizerResult : MBTemplatingRecognizerResult <NSCopying>
    
    [BaseType(typeof(MBTemplatingRecognizerResult))]
    [DisableDefaultCtor]
    interface MBDetectorRecognizerResult : INSCopying
    {
    }

    // @interface MBDetectorRecognizer : MBTemplatingRecognizer <NSCopying>
    
    [BaseType(typeof(MBTemplatingRecognizer))]
    [DisableDefaultCtor]
    interface MBDetectorRecognizer : INSCopying
    {
        // -(instancetype _Nonnull)initWithQuadWithSizeDetector:(MBQuadWithSizeDetector * _Nonnull)detector __attribute__((objc_designated_initializer));
        [Export("initWithQuadWithSizeDetector:")]
        [DesignatedInitializer]
        IntPtr Constructor(MBQuadWithSizeDetector detector);

        // @property (readonly, nonatomic, strong) MBDetectorRecognizerResult * _Nonnull result;
        [Export("result", ArgumentSemantic.Strong)]
        MBDetectorRecognizerResult Result { get; }

        // @property (assign, nonatomic) BOOL allowFlipped;
        [Export("allowFlipped")]
        bool AllowFlipped { get; set; }

        // @property (readonly, nonatomic, strong) MBQuadWithSizeDetector * _Nonnull detector;
        [Export("detector", ArgumentSemantic.Strong)]
        MBQuadWithSizeDetector Detector { get; }
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

    // @interface MBParserGroupProcessorResult : MBProcessorResult <NSCopying>
    
    [BaseType(typeof(MBProcessorResult))]
    [DisableDefaultCtor]
    interface MBParserGroupProcessorResult : INSCopying
    {
        // @property (readonly, nonatomic, strong) MBOcrLayout * _Nonnull ocrLayout;
        [Export("ocrLayout", ArgumentSemantic.Strong)]
        MBOcrLayout OcrLayout { get; }
    }

    // @interface MBParserGroupProcessor : MBProcessor <NSCopying>
    
    [BaseType(typeof(MBProcessor))]
    [DisableDefaultCtor]
    interface MBParserGroupProcessor : INSCopying
    {
        // -(instancetype _Nonnull)initWithParsers:(NSArray<MBParser *> * _Nonnull)parsers __attribute__((objc_designated_initializer));
        [Export("initWithParsers:")]
        [DesignatedInitializer]
        IntPtr Constructor(MBParser[] parsers);

        // @property (readonly, nonatomic, strong) NSArray<MBParser *> * _Nonnull parsers;
        [Export("parsers", ArgumentSemantic.Strong)]
        MBParser[] Parsers { get; }

        // @property (readonly, nonatomic, strong) MBParserGroupProcessorResult * _Nonnull result;
        [Export("result", ArgumentSemantic.Strong)]
        MBParserGroupProcessorResult Result { get; }

        // @property (assign, nonatomic) BOOL oneOptionalElementInGroupShouldBeValid;
        [Export("oneOptionalElementInGroupShouldBeValid")]
        bool OneOptionalElementInGroupShouldBeValid { get; set; }
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

    // @interface MBLegacyRecognizer : MBRecognizer
    
    [BaseType(typeof(MBRecognizer))]
    [DisableDefaultCtor]
    interface MBLegacyRecognizer
    {
    }

    // @interface MBLegacyRecognizerResult : MBRecognizerResult
    
    [BaseType(typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBLegacyRecognizerResult
    {
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

    // @interface MBAustraliaDlFrontRecognizer : MBRecognizer <NSCopying, MBGlareDetection, MBFaceImage, MBEncodeFaceImage, MBFaceImageDpi, MBFullDocumentImage, MBEncodeFullDocumentImage, MBFullDocumentImageDpi, MBFullDocumentImageExtensionFactors, MBSignatureImage, MBSignatureImageDpi, MBEncodeSignatureImage>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizer))]
    interface MBAustraliaDlFrontRecognizer : INSCopying, IMBGlareDetection, IMBFaceImage, IMBEncodeFaceImage, IMBFaceImageDpi, IMBFullDocumentImage, IMBEncodeFullDocumentImage, IMBFullDocumentImageDpi, IMBFullDocumentImageExtensionFactors, IMBSignatureImage, IMBSignatureImageDpi, IMBEncodeSignatureImage
    {
        // @property (readonly, nonatomic, strong) MBAustraliaDlFrontRecognizerResult * _Nonnull result;
        [Export ("result", ArgumentSemantic.Strong)]
        MBAustraliaDlFrontRecognizerResult Result { get; }

        // @property (assign, nonatomic) BOOL extractAddress;
        [Export ("extractAddress")]
        bool ExtractAddress { get; set; }

        // @property (assign, nonatomic) BOOL extractDateOfBirth;
        [Export ("extractDateOfBirth")]
        bool ExtractDateOfBirth { get; set; }

        // @property (assign, nonatomic) BOOL extractFullName;
        [Export ("extractFullName")]
        bool ExtractFullName { get; set; }

        // @property (assign, nonatomic) BOOL extractLicenseExpiry;
        [Export ("extractLicenseExpiry")]
        bool ExtractLicenseExpiry { get; set; }
    }

    // @interface MBAustraliaDlFrontRecognizerResult : MBRecognizerResult <NSCopying, MBFaceImageResult, MBEncodedFaceImageResult, MBFullDocumentImageResult, MBEncodedFullDocumentImageResult, MBSignatureImageResult, MBEncodedSignatureImageResult>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBAustraliaDlFrontRecognizerResult : INSCopying, IMBFaceImageResult, IMBEncodedFaceImageResult, IMBFullDocumentImageResult, IMBEncodedFullDocumentImageResult, IMBSignatureImageResult, IMBEncodedSignatureImageResult
    {
        // @property (readonly, nonatomic) NSString * _Nonnull address;
        [Export ("address")]
        string Address { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nonnull dateOfBirth;
        [Export ("dateOfBirth")]
        MBDateResult DateOfBirth { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull fullName;
        [Export ("fullName")]
        string FullName { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nonnull licenceExpiry;
        [Export ("licenceExpiry")]
        MBDateResult LicenceExpiry { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull licenceNumber;
        [Export ("licenceNumber")]
        string LicenceNumber { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull licenceType;
        [Export ("licenceType")]
        string LicenceType { get; }
    }


    // @interface MBAustraliaDlBackRecognizerResult : MBRecognizerResult <NSCopying, MBFullDocumentImageResult, MBEncodedFullDocumentImageResult>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBAustraliaDlBackRecognizerResult : INSCopying, IMBFullDocumentImageResult, IMBEncodedFullDocumentImageResult
    {
        // @property (readonly, nonatomic) NSString * _Nonnull address;
        [Export ("address")]
        string Address { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull lastName;
        [Export ("lastName")]
        string LastName { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nonnull licenceExpiry;
        [Export ("licenceExpiry")]
        MBDateResult LicenceExpiry { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull licenceNumber;
        [Export ("licenceNumber")]
        string LicenceNumber { get; }
    }

    // @interface MBAustraliaDlBackRecognizer : MBRecognizer <NSCopying, MBGlareDetection, MBFullDocumentImage, MBEncodeFullDocumentImage, MBFullDocumentImageDpi, MBFullDocumentImageExtensionFactors>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizer))]
    interface MBAustraliaDlBackRecognizer : INSCopying, IMBGlareDetection, IMBFullDocumentImage, IMBEncodeFullDocumentImage, IMBFullDocumentImageDpi, IMBFullDocumentImageExtensionFactors
    {
        // @property (readonly, nonatomic, strong) MBAustraliaDlBackRecognizerResult * _Nonnull result;
        [Export ("result", ArgumentSemantic.Strong)]
        MBAustraliaDlBackRecognizerResult Result { get; }

        // @property (assign, nonatomic) BOOL extractAddress;
        [Export ("extractAddress")]
        bool ExtractAddress { get; set; }

        // @property (assign, nonatomic) BOOL extractLastName;
        [Export ("extractLastName")]
        bool ExtractLastName { get; set; }

        // @property (assign, nonatomic) BOOL extractLicenceNumber;
        [Export ("extractLicenceNumber")]
        bool ExtractLicenceNumber { get; set; }

        // @property (assign, nonatomic) BOOL extractLicenseExpiry;
        [Export ("extractLicenseExpiry")]
        bool ExtractLicenseExpiry { get; set; }
    }

    // @interface MBMrzResult : NSObject
    
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBMrzResult
    {
        // @property (readonly, assign, nonatomic) MBMrtdDocumentType documentType;
        [Export("documentType", ArgumentSemantic.Assign)]
        MBMrtdDocumentType DocumentType { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull primaryID;
        [Export("primaryID", ArgumentSemantic.Strong)]
        string PrimaryID { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull secondaryID;
        [Export("secondaryID", ArgumentSemantic.Strong)]
        string SecondaryID { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull issuer;
        [Export("issuer", ArgumentSemantic.Strong)]
        string Issuer { get; }

        // @property (readonly, nonatomic, strong) MBDateResult * _Nonnull dateOfBirth;
        [Export("dateOfBirth", ArgumentSemantic.Strong)]
        MBDateResult DateOfBirth { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull documentNumber;
        [Export("documentNumber", ArgumentSemantic.Strong)]
        string DocumentNumber { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull nationality;
        [Export("nationality", ArgumentSemantic.Strong)]
        string Nationality { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull gender;
        [Export("gender", ArgumentSemantic.Strong)]
        string Gender { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull documentCode;
        [Export("documentCode", ArgumentSemantic.Strong)]
        string DocumentCode { get; }

        // @property (readonly, nonatomic, strong) MBDateResult * _Nonnull dateOfExpiry;
        [Export("dateOfExpiry", ArgumentSemantic.Strong)]
        MBDateResult DateOfExpiry { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull opt1;
        [Export("opt1", ArgumentSemantic.Strong)]
        string Opt1 { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull opt2;
        [Export("opt2", ArgumentSemantic.Strong)]
        string Opt2 { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull alienNumber;
        [Export("alienNumber", ArgumentSemantic.Strong)]
        string AlienNumber { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull applicationReceiptNumber;
        [Export("applicationReceiptNumber", ArgumentSemantic.Strong)]
        string ApplicationReceiptNumber { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull immigrantCaseNumber;
        [Export("immigrantCaseNumber", ArgumentSemantic.Strong)]
        string ImmigrantCaseNumber { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull mrzText;
        [Export("mrzText", ArgumentSemantic.Strong)]
        string MrzText { get; }

        // @property (readonly, assign, nonatomic) BOOL isParsed;
        [Export("isParsed")]
        bool IsParsed { get; }

        // @property (readonly, assign, nonatomic) BOOL isVerified;
        [Export("isVerified")]
        bool IsVerified { get; }
    }

    // @interface MBAustriaIdBackRecognizerResult : MBRecognizerResult <NSCopying, MBFullDocumentImageResult>
    
    [BaseType(typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBAustriaIdBackRecognizerResult : INSCopying, IMBFullDocumentImageResult
    {
        // @property (readonly, nonatomic) MBMrzResult * _Nonnull mrzResult;
        [Export("mrzResult")]
        MBMrzResult MrzResult { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull documentNumber;
        [Export("documentNumber")]
        string DocumentNumber { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull issuingAuthority;
        [Export("issuingAuthority")]
        string IssuingAuthority { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull placeOfBirth;
        [Export("placeOfBirth")]
        string PlaceOfBirth { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull principalResidence;
        [Export("principalResidence")]
        string PrincipalResidence { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull height;
        [Export("height")]
        string Height { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nonnull dateOfIssuance;
        [Export("dateOfIssuance")]
        MBDateResult DateOfIssuance { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull eyeColour;
        [Export("eyeColour")]
        string EyeColour { get; }
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

    // @interface MBAustriaIdBackRecognizer : MBRecognizer <NSCopying, MBFullDocumentImage, MBFullDocumentImageDpi, MBGlareDetection, IMBFullDocumentImageExtensionFactors>
    
    [BaseType(typeof(MBRecognizer))]
    interface MBAustriaIdBackRecognizer : INSCopying, IMBFullDocumentImage, IMBFullDocumentImageDpi, IMBGlareDetection, IMBFullDocumentImageExtensionFactors
    {
        // @property (readonly, nonatomic, strong) MBAustriaIdBackRecognizerResult * _Nonnull result;
        [Export("result", ArgumentSemantic.Strong)]
        MBAustriaIdBackRecognizerResult Result { get; }

        // @property (assign, nonatomic) BOOL extractIssuingAuthority;
        [Export("extractIssuingAuthority")]
        bool ExtractIssuingAuthority { get; set; }

        // @property (assign, nonatomic) BOOL extractDateOfIssuance;
        [Export("extractDateOfIssuance")]
        bool ExtractDateOfIssuance { get; set; }

        // @property (assign, nonatomic) BOOL extractPlaceOfBirth;
        [Export("extractPlaceOfBirth")]
        bool ExtractPlaceOfBirth { get; set; }

        // @property (assign, nonatomic) BOOL extractPrincipalResidence;
        [Export("extractPrincipalResidence")]
        bool ExtractPrincipalResidence { get; set; }

        // @property (assign, nonatomic) BOOL extractHeight;
        [Export("extractHeight")]
        bool ExtractHeight { get; set; }
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

    // @interface MBAustriaIdFrontRecognizerResult : MBRecognizerResult <NSCopying, MBFaceImageResult, MBFullDocumentImageResult, MBSignatureImageResult, MBEncodedFaceImageResult>
    
    [BaseType(typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBAustriaIdFrontRecognizerResult : INSCopying, IMBFaceImageResult, IMBFullDocumentImageResult, IMBSignatureImageResult, IMBEncodedFaceImageResult
    {
        // @property (readonly, nonatomic) NSString * _Nullable givenName;
        [NullAllowed, Export("givenName")]
        string GivenName { get; }

        // @property (readonly, nonatomic) NSString * _Nullable surname;
        [NullAllowed, Export("surname")]
        string Surname { get; }

        // @property (readonly, nonatomic) NSString * _Nullable documentNumber;
        [NullAllowed, Export("documentNumber")]
        string DocumentNumber { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nullable dateOfBirth;
        [NullAllowed, Export("dateOfBirth")]
        MBDateResult DateOfBirth { get; }

        // @property (readonly, nonatomic) NSString * _Nullable sex;
        [NullAllowed, Export("sex")]
        string Sex { get; }
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

    // @interface MBAustriaIdFrontRecognizer : MBRecognizer <NSCopying, MBFaceImage, MBFaceImageDpi, MBSignatureImage, MBSignatureImageDpi, MBFullDocumentImage, MBFullDocumentImageDpi, MBGlareDetection, MBEncodeFaceImage, IMBFullDocumentImageExtensionFactors>
    
    [BaseType(typeof(MBRecognizer))]
    interface MBAustriaIdFrontRecognizer : INSCopying, IMBFaceImage, IMBFaceImageDpi, IMBSignatureImage, IMBSignatureImageDpi, IMBFullDocumentImage, IMBFullDocumentImageDpi, IMBGlareDetection, IMBEncodeFaceImage, IMBFullDocumentImageExtensionFactors
    {
        // @property (readonly, nonatomic, strong) MBAustriaIdFrontRecognizerResult * _Nonnull result;
        [Export("result", ArgumentSemantic.Strong)]
        MBAustriaIdFrontRecognizerResult Result { get; }

        // @property (assign, nonatomic) BOOL extractSex;
        [Export("extractSex")]
        bool ExtractSex { get; set; }

        // @property (assign, nonatomic) BOOL extractSurname;
        [Export("extractSurname")]
        bool ExtractSurname { get; set; }

        // @property (assign, nonatomic) BOOL extractGivenName;
        [Export("extractGivenName")]
        bool ExtractGivenName { get; set; }

        // @property (assign, nonatomic) BOOL extractDateOfBirth;
        [Export("extractDateOfBirth")]
        bool ExtractDateOfBirth { get; set; }
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

    // @interface MBAustriaCombinedRecognizerResult : MBRecognizerResult <NSCopying, MBCombinedRecognizerResult, MBFaceImageResult, MBCombinedFullDocumentImageResult, MBSignatureImageResult, MBDigitalSignatureResult, MBEncodedFaceImageResult, MBEncodedSignatureImageResult, MBEncodedCombinedFullDocumentImageResult>
    
    [BaseType(typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBAustriaCombinedRecognizerResult : INSCopying, MBCombinedRecognizerResult, IMBFaceImageResult, IMBCombinedFullDocumentImageResult, IMBSignatureImageResult, IMBDigitalSignatureResult, IMBEncodedFaceImageResult, IMBEncodedSignatureImageResult, IMBEncodedCombinedFullDocumentImageResult
    {
        // @property (readonly, nonatomic) NSString * _Nullable givenName;
        [NullAllowed, Export("givenName")]
        string GivenName { get; }

        // @property (readonly, nonatomic) NSString * _Nullable surname;
        [NullAllowed, Export("surname")]
        string Surname { get; }

        // @property (readonly, nonatomic) NSString * _Nullable documentNumber;
        [NullAllowed, Export("documentNumber")]
        string DocumentNumber { get; }

        // @property (readonly, nonatomic) NSString * _Nullable nationality;
        [NullAllowed, Export("nationality")]
        string Nationality { get; }

        // @property (readonly, nonatomic) NSString * _Nullable sex;
        [NullAllowed, Export("sex")]
        string Sex { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nullable dateOfBirth;
        [NullAllowed, Export("dateOfBirth")]
        MBDateResult DateOfBirth { get; }

        // @property (readonly, nonatomic) NSString * _Nullable placeOfBirth;
        [NullAllowed, Export("placeOfBirth")]
        string PlaceOfBirth { get; }

        // @property (readonly, nonatomic) NSString * _Nullable issuingAuthority;
        [NullAllowed, Export("issuingAuthority")]
        string IssuingAuthority { get; }

        // @property (readonly, nonatomic) NSString * _Nullable principalResidence;
        [NullAllowed, Export("principalResidence")]
        string PrincipalResidence { get; }

        // @property (readonly, nonatomic) NSString * _Nullable height;
        [NullAllowed, Export("height")]
        string Height { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nullable dateOfIssuance;
        [NullAllowed, Export("dateOfIssuance")]
        MBDateResult DateOfIssuance { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nullable dateOfExpiry;
        [NullAllowed, Export("dateOfExpiry")]
        MBDateResult DateOfExpiry { get; }

        // @property (readonly, nonatomic) NSString * _Nullable eyeColour;
        [NullAllowed, Export("eyeColour")]
        string EyeColour { get; }

        // @property (readonly, assign, nonatomic) BOOL mrtdVerified;
        [Export("mrtdVerified")]
        bool MrtdVerified { get; }
    }

     interface IMBCombinedRecognizerResult {}

    // @protocol MBCombinedRecognizerResult
    [Protocol]   
    interface MBCombinedRecognizerResult
    {
        // @required @property (readonly, assign, nonatomic) BOOL documentDataMatch;
        [Abstract]
        [Export("documentDataMatch")]
        bool DocumentDataMatch { get; }

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

    // @interface MBAustriaCombinedRecognizer : MBRecognizer <NSCopying, MBCombinedRecognizer, MBGlareDetection, MBFullDocumentImage, MBFullDocumentImageDpi, MBSignatureImage, MBSignatureImageDpi, MBFaceImage, MBFaceImageDpi, MBEncodeFaceImage, MBEncodeFullDocumentImage, MBEncodeSignatureImage, MBDigitalSignature, IMBFullDocumentImageExtensionFactors>
    
    [BaseType(typeof(MBRecognizer))]
    interface MBAustriaCombinedRecognizer : INSCopying, IMBCombinedRecognizer, IMBGlareDetection, IMBFullDocumentImage, IMBFullDocumentImageDpi, IMBSignatureImage, IMBSignatureImageDpi, IMBFaceImage, IMBFaceImageDpi, IMBEncodeFaceImage, IMBEncodeFullDocumentImage, IMBEncodeSignatureImage, IMBDigitalSignature, IMBFullDocumentImageExtensionFactors
    {
        // @property (readonly, nonatomic, strong) MBAustriaCombinedRecognizerResult * _Nonnull result;
        [Export("result", ArgumentSemantic.Strong)]
        MBAustriaCombinedRecognizerResult Result { get; }

        // @property (assign, nonatomic) BOOL extractIssuingAuthority;
        [Export("extractIssuingAuthority")]
        bool ExtractIssuingAuthority { get; set; }

        // @property (assign, nonatomic) BOOL extractDateOfIssuance;
        [Export("extractDateOfIssuance")]
        bool ExtractDateOfIssuance { get; set; }

        // @property (assign, nonatomic) BOOL extractPlaceOfBirth;
        [Export("extractPlaceOfBirth")]
        bool ExtractPlaceOfBirth { get; set; }

        // @property (assign, nonatomic) BOOL extractPrincipalResidence;
        [Export("extractPrincipalResidence")]
        bool ExtractPrincipalResidence { get; set; }

        // @property (assign, nonatomic) BOOL extractHeight;
        [Export("extractHeight")]
        bool ExtractHeight { get; set; }

        // @property (assign, nonatomic) BOOL extractSex;
        [Export("extractSex")]
        bool ExtractSex { get; set; }

        // @property (assign, nonatomic) BOOL extractSurname;
        [Export("extractSurname")]
        bool ExtractSurname { get; set; }

        // @property (assign, nonatomic) BOOL extractGivenName;
        [Export("extractGivenName")]
        bool ExtractGivenName { get; set; }

        // @property (assign, nonatomic) BOOL extractDateOfBirth;
        [Export("extractDateOfBirth")]
        bool ExtractDateOfBirth { get; set; }

        // @property (assign, nonatomic) BOOL extractNationality;
        [Export("extractNationality")]
        bool ExtractNationality { get; set; }

        // @property (assign, nonatomic) BOOL extractDateOfIssue;
        [Export("extractDateOfIssue")]
        bool ExtractDateOfIssue { get; set; }

        // @property (assign, nonatomic) BOOL extractPassportNumber;
        [Export("extractPassportNumber")]
        bool ExtractPassportNumber { get; set; }

        // @property (assign, nonatomic) BOOL extractDateOfExpiry;
        [Export("extractDateOfExpiry")]
        bool ExtractDateOfExpiry { get; set; }
    }

    // @interface MBAustriaPassportRecognizerResult : MBRecognizerResult <NSCopying, MBFaceImageResult, MBSignatureImageResult, MBFullDocumentImageResult>
    
    [BaseType(typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBAustriaPassportRecognizerResult : INSCopying, IMBFaceImageResult, IMBSignatureImageResult, IMBFullDocumentImageResult
    {
        // @property (readonly, nonatomic) MBMrzResult * _Nonnull mrzResult;
        [Export("mrzResult")]
        MBMrzResult MrzResult { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull surname;
        [Export("surname")]
        string Surname { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull givenName;
        [Export("givenName")]
        string GivenName { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull nationality;
        [Export("nationality")]
        string Nationality { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull placeOfBirth;
        [Export("placeOfBirth")]
        string PlaceOfBirth { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull issuingAuthority;
        [Export("issuingAuthority")]
        string IssuingAuthority { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull height;
        [Export("height")]
        string Height { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull sex;
        [Export("sex")]
        string Sex { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull passportNumber;
        [Export("passportNumber")]
        string PassportNumber { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nonnull dateOfIssue;
        [Export("dateOfIssue")]
        MBDateResult DateOfIssue { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nonnull dateOfBirth;
        [Export("dateOfBirth")]
        MBDateResult DateOfBirth { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nonnull dateOfExpiry;
        [Export("dateOfExpiry")]
        MBDateResult DateOfExpiry { get; }
    }

    // @interface MBAustriaPassportRecognizer : MBRecognizer <NSCopying, MBFullDocumentImage, MBFullDocumentImageDpi, MBSignatureImage, MBSignatureImageDpi, MBFaceImage, MBFaceImageDpi, MBGlareDetection, IMBFullDocumentImageExtensionFactors>
    
    [BaseType(typeof(MBRecognizer))]
    interface MBAustriaPassportRecognizer : INSCopying, IMBFullDocumentImage, IMBFullDocumentImageDpi, IMBSignatureImage, IMBSignatureImageDpi, IMBFaceImage, IMBFaceImageDpi, IMBGlareDetection, IMBFullDocumentImageExtensionFactors
    {
        // @property (readonly, nonatomic, strong) MBAustriaPassportRecognizerResult * _Nonnull result;
        [Export("result", ArgumentSemantic.Strong)]
        MBAustriaPassportRecognizerResult Result { get; }

        // @property (assign, nonatomic) BOOL extractSurname;
        [Export("extractSurname")]
        bool ExtractSurname { get; set; }

        // @property (assign, nonatomic) BOOL extractGivenName;
        [Export("extractGivenName")]
        bool ExtractGivenName { get; set; }

        // @property (assign, nonatomic) BOOL extractNationality;
        [Export("extractNationality")]
        bool ExtractNationality { get; set; }

        // @property (assign, nonatomic) BOOL extractPlaceOfBirth;
        [Export("extractPlaceOfBirth")]
        bool ExtractPlaceOfBirth { get; set; }

        // @property (assign, nonatomic) BOOL extractDateOfIssue;
        [Export("extractDateOfIssue")]
        bool ExtractDateOfIssue { get; set; }

        // @property (assign, nonatomic) BOOL extractIssuingAuthority;
        [Export("extractIssuingAuthority")]
        bool ExtractIssuingAuthority { get; set; }

        // @property (assign, nonatomic) BOOL extractHeight;
        [Export("extractHeight")]
        bool ExtractHeight { get; set; }

        // @property (assign, nonatomic) BOOL extractSex;
        [Export("extractSex")]
        bool ExtractSex { get; set; }

        // @property (assign, nonatomic) BOOL extractPassportNumber;
        [Export("extractPassportNumber")]
        bool ExtractPassportNumber { get; set; }

        // @property (assign, nonatomic) BOOL extractDateOfBirth;
        [Export("extractDateOfBirth")]
        bool ExtractDateOfBirth { get; set; }

        // @property (assign, nonatomic) BOOL extractDateOfExpiry;
        [Export("extractDateOfExpiry")]
        bool ExtractDateOfExpiry { get; set; }
    }

    // @interface MBAustriaDlFrontRecognizerResult : MBRecognizerResult <NSCopying, MBFaceImageResult, MBEncodedFaceImageResult, MBFullDocumentImageResult, MBEncodedFullDocumentImageResult, MBSignatureImageResult, MBEncodedSignatureImageResult>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBAustriaDlFrontRecognizerResult : INSCopying, IMBFaceImageResult, IMBEncodedFaceImageResult, IMBFullDocumentImageResult, IMBEncodedFullDocumentImageResult, IMBSignatureImageResult, IMBEncodedSignatureImageResult
    {
        // @property (readonly, nonatomic) MBDateResult * _Nonnull dateOfBirth;
        [Export ("dateOfBirth")]
        MBDateResult DateOfBirth { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nonnull dateOfExpiry;
        [Export ("dateOfExpiry")]
        MBDateResult DateOfExpiry { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nonnull dateOfIssue;
        [Export ("dateOfIssue")]
        MBDateResult DateOfIssue { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull firstName;
        [Export ("firstName")]
        string FirstName { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull issuingAuthority;
        [Export ("issuingAuthority")]
        string IssuingAuthority { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull licenceNumber;
        [Export ("licenceNumber")]
        string LicenceNumber { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull name;
        [Export ("name")]
        string Name { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull placeOfBirth;
        [Export ("placeOfBirth")]
        string PlaceOfBirth { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull vehicleCategories;
        [Export ("vehicleCategories")]
        string VehicleCategories { get; }
    }

    // @interface MBAustriaDlFrontRecognizer : MBRecognizer <NSCopying, MBFaceImage, MBEncodeFaceImage, MBFaceImageDpi, MBFullDocumentImage, MBEncodeFullDocumentImage, MBFullDocumentImageDpi, MBSignatureImage, MBEncodeSignatureImage, MBSignatureImageDpi, MBGlareDetection, MBFullDocumentImageExtensionFactors>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizer))]
    interface MBAustriaDlFrontRecognizer : INSCopying, IMBFaceImage, IMBEncodeFaceImage, IMBFaceImageDpi, IMBFullDocumentImage, IMBEncodeFullDocumentImage, IMBFullDocumentImageDpi, IMBSignatureImage, IMBEncodeSignatureImage, IMBSignatureImageDpi, IMBGlareDetection, IMBFullDocumentImageExtensionFactors
    {
        // @property (readonly, nonatomic, strong) MBAustriaDlFrontRecognizerResult * _Nonnull result;
        [Export ("result", ArgumentSemantic.Strong)]
        MBAustriaDlFrontRecognizerResult Result { get; }

        // @property (assign, nonatomic) BOOL extractDateOfBirth;
        [Export ("extractDateOfBirth")]
        bool ExtractDateOfBirth { get; set; }

        // @property (assign, nonatomic) BOOL extractDateOfExpiry;
        [Export ("extractDateOfExpiry")]
        bool ExtractDateOfExpiry { get; set; }

        // @property (assign, nonatomic) BOOL extractDateOfIssue;
        [Export ("extractDateOfIssue")]
        bool ExtractDateOfIssue { get; set; }

        // @property (assign, nonatomic) BOOL extractFirstName;
        [Export ("extractFirstName")]
        bool ExtractFirstName { get; set; }

        // @property (assign, nonatomic) BOOL extractIssuingAuthority;
        [Export ("extractIssuingAuthority")]
        bool ExtractIssuingAuthority { get; set; }

        // @property (assign, nonatomic) BOOL extractName;
        [Export ("extractName")]
        bool ExtractName { get; set; }

        // @property (assign, nonatomic) BOOL extractPlaceOfBirth;
        [Export ("extractPlaceOfBirth")]
        bool ExtractPlaceOfBirth { get; set; }

        // @property (assign, nonatomic) BOOL extractVehicleCategories;
        [Export ("extractVehicleCategories")]
        bool ExtractVehicleCategories { get; set; }
    }

    // @interface MBBruneiIdFrontRecognizerResult : MBRecognizerResult <NSCopying, MBFaceImageResult, MBEncodedFaceImageResult, MBFullDocumentImageResult, MBEncodedFullDocumentImageResult>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBBruneiIdFrontRecognizerResult : INSCopying, IMBFaceImageResult, IMBEncodedFaceImageResult, IMBFullDocumentImageResult, IMBEncodedFullDocumentImageResult
    {
        // @property (readonly, nonatomic) MBDateResult * _Nonnull dateOfBirth;
        [Export("dateOfBirth")]
        MBDateResult DateOfBirth { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull documentNumber;
        [Export("documentNumber")]
        string DocumentNumber { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull fullName;
        [Export("fullName")]
        string FullName { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull placeOfBirth;
        [Export("placeOfBirth")]
        string PlaceOfBirth { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull sex;
        [Export("sex")]
        string Sex { get; }
    }

    // @interface MBBruneiIdFrontRecognizer : MBRecognizer <NSCopying, MBGlareDetection, MBFaceImage, MBEncodeFaceImage, MBFaceImageDpi, MBFullDocumentImage, MBEncodeFullDocumentImage, MBFullDocumentImageDpi, MBFullDocumentImageExtensionFactors>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizer))]
    interface MBBruneiIdFrontRecognizer : INSCopying, IMBGlareDetection, IMBFaceImage, IMBEncodeFaceImage, IMBFaceImageDpi, IMBFullDocumentImage, IMBEncodeFullDocumentImage, IMBFullDocumentImageDpi, IMBFullDocumentImageExtensionFactors
    {
        // @property (readonly, nonatomic, strong) MBBruneiIdFrontRecognizerResult * _Nonnull result;
        [Export("result", ArgumentSemantic.Strong)]
        MBBruneiIdFrontRecognizerResult Result { get; }

        // @property (assign, nonatomic) BOOL extractDateOfBirth;
        [Export("extractDateOfBirth")]
        bool ExtractDateOfBirth { get; set; }

        // @property (assign, nonatomic) BOOL extractFullName;
        [Export("extractFullName")]
        bool ExtractFullName { get; set; }

        // @property (assign, nonatomic) BOOL extractPlaceOfBirth;
        [Export("extractPlaceOfBirth")]
        bool ExtractPlaceOfBirth { get; set; }

        // @property (assign, nonatomic) BOOL extractSex;
        [Export("extractSex")]
        bool ExtractSex { get; set; }
    }

    // @interface MBBruneiIdBackRecognizerResult : MBRecognizerResult <NSCopying, MBFullDocumentImageResult, MBEncodedFullDocumentImageResult>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBBruneiIdBackRecognizerResult : INSCopying, IMBFullDocumentImageResult, IMBEncodedFullDocumentImageResult
    {
        // @property (readonly, nonatomic) NSString * _Nonnull address;
        [Export ("address")]
        string Address { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nonnull dateOfIssue;
        [Export ("dateOfIssue")]
        MBDateResult DateOfIssue { get; }

        // @property (readonly, nonatomic) MBMrzResult * _Nonnull mrzResult;
        [Export ("mrzResult")]
        MBMrzResult MrzResult { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull race;
        [Export ("race")]
        string Race { get; }
    }

    // @interface MBBruneiIdBackRecognizer : MBRecognizer <NSCopying, MBGlareDetection, MBFullDocumentImage, MBEncodeFullDocumentImage, MBFullDocumentImageDpi, MBFullDocumentImageExtensionFactors>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizer))]
    interface MBBruneiIdBackRecognizer : INSCopying, IMBGlareDetection, IMBFullDocumentImage, IMBEncodeFullDocumentImage, IMBFullDocumentImageDpi, IMBFullDocumentImageExtensionFactors
    {
        // @property (readonly, nonatomic, strong) MBBruneiIdBackRecognizerResult * _Nonnull result;
        [Export ("result", ArgumentSemantic.Strong)]
        MBBruneiIdBackRecognizerResult Result { get; }

        // @property (assign, nonatomic) BOOL extractAddress;
        [Export ("extractAddress")]
        bool ExtractAddress { get; set; }

        // @property (assign, nonatomic) BOOL extractDateOfIssue;
        [Export ("extractDateOfIssue")]
        bool ExtractDateOfIssue { get; set; }

        // @property (assign, nonatomic) BOOL extractRace;
        [Export ("extractRace")]
        bool ExtractRace { get; set; }
    }

    // @interface MBBruneiResidencePermitFrontRecognizerResult : MBRecognizerResult <NSCopying, MBFaceImageResult, MBEncodedFaceImageResult, MBFullDocumentImageResult, MBEncodedFullDocumentImageResult>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBBruneiResidencePermitFrontRecognizerResult : INSCopying, IMBFaceImageResult, IMBEncodedFaceImageResult, IMBFullDocumentImageResult, IMBEncodedFullDocumentImageResult
    {
        // @property (readonly, nonatomic) MBDateResult * _Nonnull dateOfBirth;
        [Export ("dateOfBirth")]
        MBDateResult DateOfBirth { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull documentNumber;
        [Export ("documentNumber")]
        string DocumentNumber { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull fullName;
        [Export ("fullName")]
        string FullName { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull placeOfBirth;
        [Export ("placeOfBirth")]
        string PlaceOfBirth { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull sex;
        [Export ("sex")]
        string Sex { get; }
    }

    // @interface MBBruneiResidencePermitFrontRecognizer : MBRecognizer <NSCopying, MBGlareDetection, MBFaceImage, MBEncodeFaceImage, MBFaceImageDpi, MBFullDocumentImage, MBEncodeFullDocumentImage, MBFullDocumentImageDpi, MBFullDocumentImageExtensionFactors>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizer))]
    interface MBBruneiResidencePermitFrontRecognizer : INSCopying, IMBGlareDetection, IMBFaceImage, IMBEncodeFaceImage, IMBFaceImageDpi, IMBFullDocumentImage, IMBEncodeFullDocumentImage, IMBFullDocumentImageDpi, IMBFullDocumentImageExtensionFactors
    {
        // @property (readonly, nonatomic, strong) MBBruneiResidencePermitFrontRecognizerResult * _Nonnull result;
        [Export ("result", ArgumentSemantic.Strong)]
        MBBruneiResidencePermitFrontRecognizerResult Result { get; }

        // @property (assign, nonatomic) BOOL extractDateOfBirth;
        [Export ("extractDateOfBirth")]
        bool ExtractDateOfBirth { get; set; }

        // @property (assign, nonatomic) BOOL extractFullName;
        [Export ("extractFullName")]
        bool ExtractFullName { get; set; }

        // @property (assign, nonatomic) BOOL extractPlaceOfBirth;
        [Export ("extractPlaceOfBirth")]
        bool ExtractPlaceOfBirth { get; set; }

        // @property (assign, nonatomic) BOOL extractSex;
        [Export ("extractSex")]
        bool ExtractSex { get; set; }
    }

    // @interface MBBruneiResidencePermitBackRecognizerResult : MBRecognizerResult <NSCopying, MBFullDocumentImageResult, MBEncodedFullDocumentImageResult>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBBruneiResidencePermitBackRecognizerResult : INSCopying, IMBFullDocumentImageResult, IMBEncodedFullDocumentImageResult
    {
        // @property (readonly, nonatomic) NSString * _Nonnull address;
        [Export ("address")]
        string Address { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nonnull dateOfIssue;
        [Export ("dateOfIssue")]
        MBDateResult DateOfIssue { get; }

        // @property (readonly, nonatomic) MBMrzResult * _Nonnull mrzResult;
        [Export ("mrzResult")]
        MBMrzResult MrzResult { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull race;
        [Export ("race")]
        string Race { get; }
    }

    // @interface MBBruneiResidencePermitBackRecognizer : MBRecognizer <NSCopying, MBGlareDetection, MBFullDocumentImage, MBEncodeFullDocumentImage, MBFullDocumentImageDpi, MBFullDocumentImageExtensionFactors>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizer))]
    interface MBBruneiResidencePermitBackRecognizer : INSCopying, IMBGlareDetection, IMBFullDocumentImage, IMBEncodeFullDocumentImage, IMBFullDocumentImageDpi, IMBFullDocumentImageExtensionFactors
    {
        // @property (readonly, nonatomic, strong) MBBruneiResidencePermitBackRecognizerResult * _Nonnull result;
        [Export ("result", ArgumentSemantic.Strong)]
        MBBruneiResidencePermitBackRecognizerResult Result { get; }

        // @property (assign, nonatomic) BOOL extractAddress;
        [Export ("extractAddress")]
        bool ExtractAddress { get; set; }

        // @property (assign, nonatomic) BOOL extractDateOfIssue;
        [Export ("extractDateOfIssue")]
        bool ExtractDateOfIssue { get; set; }

        // @property (assign, nonatomic) BOOL extractRace;
        [Export ("extractRace")]
        bool ExtractRace { get; set; }
    }

    // @interface MBBruneiTemporaryResidencePermitFrontRecognizerResult : MBRecognizerResult <NSCopying, MBFaceImageResult, MBEncodedFaceImageResult, MBFullDocumentImageResult, MBEncodedFullDocumentImageResult>
	[iOS (8,0)]
	[BaseType (typeof(MBRecognizerResult))]
	[DisableDefaultCtor]
	interface MBBruneiTemporaryResidencePermitFrontRecognizerResult : INSCopying, IMBFaceImageResult, IMBEncodedFaceImageResult, IMBFullDocumentImageResult, IMBEncodedFullDocumentImageResult
	{
		// @property (readonly, nonatomic) NSString * _Nonnull address;
		[Export ("address")]
		string Address { get; }

		// @property (readonly, nonatomic) MBDateResult * _Nonnull dateOfBirth;
		[Export ("dateOfBirth")]
		MBDateResult DateOfBirth { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull documentNumber;
		[Export ("documentNumber")]
		string DocumentNumber { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull fullName;
		[Export ("fullName")]
		string FullName { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull placeOfBirth;
		[Export ("placeOfBirth")]
		string PlaceOfBirth { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull sex;
		[Export ("sex")]
		string Sex { get; }
	}

	// @interface MBBruneiTemporaryResidencePermitFrontRecognizer : MBRecognizer <NSCopying, MBGlareDetection, MBFaceImage, MBEncodeFaceImage, MBFaceImageDpi, MBFullDocumentImage, MBEncodeFullDocumentImage, MBFullDocumentImageDpi, MBFullDocumentImageExtensionFactors>
	[iOS (8,0)]
	[BaseType (typeof(MBRecognizer))]
	interface MBBruneiTemporaryResidencePermitFrontRecognizer : INSCopying, IMBGlareDetection, IMBFaceImage, IMBEncodeFaceImage, IMBFaceImageDpi, IMBFullDocumentImage, IMBEncodeFullDocumentImage, IMBFullDocumentImageDpi, IMBFullDocumentImageExtensionFactors
	{
		// @property (readonly, nonatomic, strong) MBBruneiTemporaryResidencePermitFrontRecognizerResult * _Nonnull result;
		[Export ("result", ArgumentSemantic.Strong)]
		MBBruneiTemporaryResidencePermitFrontRecognizerResult Result { get; }

		// @property (assign, nonatomic) BOOL extractAddress;
		[Export ("extractAddress")]
		bool ExtractAddress { get; set; }

		// @property (assign, nonatomic) BOOL extractDateOfBirth;
		[Export ("extractDateOfBirth")]
		bool ExtractDateOfBirth { get; set; }

		// @property (assign, nonatomic) BOOL extractFullName;
		[Export ("extractFullName")]
		bool ExtractFullName { get; set; }

		// @property (assign, nonatomic) BOOL extractPlaceOfBirth;
		[Export ("extractPlaceOfBirth")]
		bool ExtractPlaceOfBirth { get; set; }

		// @property (assign, nonatomic) BOOL extractSex;
		[Export ("extractSex")]
		bool ExtractSex { get; set; }
	}

	// @interface MBBruneiTemporaryResidencePermitBackRecognizerResult : MBRecognizerResult <NSCopying, MBFullDocumentImageResult, MBEncodedFullDocumentImageResult>
	[iOS (8,0)]
	[BaseType (typeof(MBRecognizerResult))]
	[DisableDefaultCtor]
	interface MBBruneiTemporaryResidencePermitBackRecognizerResult : INSCopying, IMBFullDocumentImageResult, IMBEncodedFullDocumentImageResult
	{
		// @property (readonly, nonatomic) NSString * _Nonnull address;
		[Export ("address")]
		string Address { get; }

		// @property (readonly, nonatomic) MBDateResult * _Nonnull dateOfIssue;
		[Export ("dateOfIssue")]
		MBDateResult DateOfIssue { get; }

		// @property (readonly, nonatomic) MBMrzResult * _Nonnull mrzResult;
		[Export ("mrzResult")]
		MBMrzResult MrzResult { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull passportNumber;
		[Export ("passportNumber")]
		string PassportNumber { get; }
	}

	// @interface MBBruneiTemporaryResidencePermitBackRecognizer : MBRecognizer <NSCopying, MBGlareDetection, MBFullDocumentImage, MBEncodeFullDocumentImage, MBFullDocumentImageDpi, MBFullDocumentImageExtensionFactors>
	[iOS (8,0)]
	[BaseType (typeof(MBRecognizer))]
	interface MBBruneiTemporaryResidencePermitBackRecognizer : INSCopying, IMBGlareDetection, IMBFullDocumentImage, IMBEncodeFullDocumentImage, IMBFullDocumentImageDpi, IMBFullDocumentImageExtensionFactors
	{
		// @property (readonly, nonatomic, strong) MBBruneiTemporaryResidencePermitBackRecognizerResult * _Nonnull result;
		[Export ("result", ArgumentSemantic.Strong)]
		MBBruneiTemporaryResidencePermitBackRecognizerResult Result { get; }

		// @property (assign, nonatomic) BOOL extractAddress;
		[Export ("extractAddress")]
		bool ExtractAddress { get; set; }

		// @property (assign, nonatomic) BOOL extractDateOfIssue;
		[Export ("extractDateOfIssue")]
		bool ExtractDateOfIssue { get; set; }

		// @property (assign, nonatomic) BOOL extractPassportNumber;
		[Export ("extractPassportNumber")]
		bool ExtractPassportNumber { get; set; }
	}
   
    // @interface MBColombiaIdBackRecognizerResult : MBRecognizerResult <NSCopying, MBFullDocumentImageResult, MBEncodedFullDocumentImageResult>
    [iOS (8,0)]
    [BaseType(typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBColombiaIdBackRecognizerResult : INSCopying, IMBFullDocumentImageResult, IMBEncodedFullDocumentImageResult
    {
        // @property (readonly, nonatomic) MBDateResult * _Nonnull birthDate;
        [Export("birthDate")]
        MBDateResult BirthDate { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull bloodGroup;
        [Export("bloodGroup")]
        string BloodGroup { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull documentNumber;
        [Export("documentNumber")]
        string DocumentNumber { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull firstName;
        [Export("firstName")]
        string FirstName { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull lastName;
        [Export("lastName")]
        string LastName { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull sex;
        [Export("sex")]
        string Sex { get; }

        // @property (readonly, nonatomic) NSData * _Nullable fingerprint;
        [NullAllowed, Export("fingerprint")]
        NSData Fingerprint { get; }
    }

    // @interface MBColombiaIdBackRecognizer : MBRecognizer <NSCopying, MBFullDocumentImage, MBEncodeFullDocumentImage, MBFullDocumentImageDpi, MBGlareDetection, IMBFullDocumentImageExtensionFactors>
    [iOS (8,0)]
    [BaseType(typeof(MBRecognizer))]
    interface MBColombiaIdBackRecognizer : INSCopying, IMBFullDocumentImage, IMBEncodeFullDocumentImage, IMBFullDocumentImageDpi, IMBGlareDetection, IMBFullDocumentImageExtensionFactors
    {
        // @property (readonly, nonatomic, strong) MBColombiaIdBackRecognizerResult * _Nonnull result;
        [Export("result", ArgumentSemantic.Strong)]
        MBColombiaIdBackRecognizerResult Result { get; }

        // @property (nonatomic) BOOL scanUncertain;
        [Export("scanUncertain")]
        bool ScanUncertain { get; set; }

        // @property (nonatomic) BOOL nullQuietZoneAllowed;
        [Export("nullQuietZoneAllowed")]
        bool NullQuietZoneAllowed { get; set; }
    }

    // @interface MBColombiaIdFrontRecognizerResult : MBRecognizerResult <NSCopying, MBFaceImageResult, MBEncodedFaceImageResult, MBFullDocumentImageResult, MBEncodedFullDocumentImageResult, MBSignatureImageResult, MBEncodedSignatureImageResult>
    [iOS (8,0)]
    [BaseType(typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBColombiaIdFrontRecognizerResult : INSCopying, IMBFaceImageResult, IMBEncodedFaceImageResult, IMBFullDocumentImageResult, IMBEncodedFullDocumentImageResult, IMBSignatureImageResult, IMBEncodedSignatureImageResult
    {
        // @property (readonly, nonatomic) NSString * _Nonnull documentNumber;
        [Export("documentNumber")]
        string DocumentNumber { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull firstName;
        [Export("firstName")]
        string FirstName { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull lastName;
        [Export("lastName")]
        string LastName { get; }
    }

    // @interface MBColombiaIdFrontRecognizer : MBRecognizer <NSCopying, MBFaceImage, MBEncodeFaceImage, MBFaceImageDpi, MBFullDocumentImage, MBEncodeFullDocumentImage, MBFullDocumentImageDpi, MBSignatureImage, MBEncodeSignatureImage, MBSignatureImageDpi, MBGlareDetection, IMBFullDocumentImageExtensionFactors>
    [iOS (8,0)]
    [BaseType(typeof(MBRecognizer))]
    interface MBColombiaIdFrontRecognizer : INSCopying, IMBFaceImage, IMBEncodeFaceImage, IMBFaceImageDpi, IMBFullDocumentImage, IMBEncodeFullDocumentImage, IMBFullDocumentImageDpi, IMBSignatureImage, IMBEncodeSignatureImage, IMBSignatureImageDpi, IMBGlareDetection, IMBFullDocumentImageExtensionFactors
    {
        // @property (readonly, nonatomic, strong) MBColombiaIdFrontRecognizerResult * _Nonnull result;
        [Export("result", ArgumentSemantic.Strong)]
        MBColombiaIdFrontRecognizerResult Result { get; }

        // @property (assign, nonatomic) BOOL extractFirstName;
        [Export("extractFirstName")]
        bool ExtractFirstName { get; set; }

        // @property (assign, nonatomic) BOOL extractLastName;
        [Export("extractLastName")]
        bool ExtractLastName { get; set; }
    }

    // @interface MBColombiaDlFrontRecognizerResult : MBRecognizerResult <NSCopying, MBFaceImageResult, MBEncodedFaceImageResult, MBFullDocumentImageResult, MBEncodedFullDocumentImageResult>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBColombiaDlFrontRecognizerResult : INSCopying, IMBFaceImageResult, IMBEncodedFaceImageResult, IMBFullDocumentImageResult, IMBEncodedFullDocumentImageResult
    {
        // @property (readonly, nonatomic) MBDateResult * _Nonnull dateOfBirth;
        [Export ("dateOfBirth")]
        MBDateResult DateOfBirth { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nonnull dateOfIssue;
        [Export ("dateOfIssue")]
        MBDateResult DateOfIssue { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull driverRestrictions;
        [Export ("driverRestrictions")]
        string DriverRestrictions { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull issuingAgency;
        [Export ("issuingAgency")]
        string IssuingAgency { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull licenceNumber;
        [Export ("licenceNumber")]
        string LicenceNumber { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull name;
        [Export ("name")]
        string Name { get; }
    }

    // @interface MBColombiaDlFrontRecognizer : MBRecognizer <NSCopying, MBFaceImage, MBEncodeFaceImage, MBFaceImageDpi, MBFullDocumentImage, MBEncodeFullDocumentImage, MBFullDocumentImageDpi, MBGlareDetection, MBFullDocumentImageExtensionFactors>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizer))]
    interface MBColombiaDlFrontRecognizer : INSCopying, IMBFaceImage, IMBEncodeFaceImage, IMBFaceImageDpi, IMBFullDocumentImage, IMBEncodeFullDocumentImage, IMBFullDocumentImageDpi, IMBGlareDetection, IMBFullDocumentImageExtensionFactors
    {
        // @property (readonly, nonatomic, strong) MBColombiaDlFrontRecognizerResult * _Nonnull result;
        [Export ("result", ArgumentSemantic.Strong)]
        MBColombiaDlFrontRecognizerResult Result { get; }

        // @property (assign, nonatomic) BOOL extractDateOfBirth;
        [Export ("extractDateOfBirth")]
        bool ExtractDateOfBirth { get; set; }

        // @property (assign, nonatomic) BOOL extractDriverRestrictions;
        [Export ("extractDriverRestrictions")]
        bool ExtractDriverRestrictions { get; set; }

        // @property (assign, nonatomic) BOOL extractIssuingAgency;
        [Export ("extractIssuingAgency")]
        bool ExtractIssuingAgency { get; set; }

        // @property (assign, nonatomic) BOOL extractName;
        [Export ("extractName")]
        bool ExtractName { get; set; }
    }
   
    // @interface MBCroatiaIdFrontRecognizerResult : MBRecognizerResult <NSCopying, MBFaceImageResult, MBEncodedFaceImageResult, MBSignatureImageResult, MBEncodedSignatureImageResult, MBFullDocumentImageResult, MBEncodedFullDocumentImageResult>
    [iOS (8,0)]
    [BaseType(typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBCroatiaIdFrontRecognizerResult : INSCopying, IMBFaceImageResult, IMBEncodedFaceImageResult, IMBSignatureImageResult, IMBEncodedSignatureImageResult, IMBFullDocumentImageResult, IMBEncodedFullDocumentImageResult
    {
        // @property (readonly, nonatomic) NSString * _Nullable firstName;
        [NullAllowed, Export("firstName")]
        string FirstName { get; }

        // @property (readonly, nonatomic) NSString * _Nullable lastName;
        [NullAllowed, Export("lastName")]
        string LastName { get; }

        // @property (readonly, nonatomic) NSString * _Nullable documentNumber;
        [NullAllowed, Export("documentNumber")]
        string DocumentNumber { get; }

        // @property (readonly, nonatomic) NSString * _Nullable sex;
        [NullAllowed, Export("sex")]
        string Sex { get; }

        // @property (readonly, nonatomic) NSString * _Nullable citizenship;
        [NullAllowed, Export("citizenship")]
        string Citizenship { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nullable dateOfBirth;
        [NullAllowed, Export("dateOfBirth")]
        MBDateResult DateOfBirth { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nullable dateOfExpiry;
        [NullAllowed, Export("dateOfExpiry")]
        MBDateResult DateOfExpiry { get; }

        // @property (readonly, nonatomic) BOOL dateOfExpiryPermanent;
        [Export("dateOfExpiryPermanent")]
        bool DateOfExpiryPermanent { get; }

        // @property (readonly, nonatomic) BOOL documentBilingual;
        [Export("documentBilingual")]
        bool DocumentBilingual { get; }
    }

    // @interface MBCroatiaIdFrontRecognizer : MBRecognizer <NSCopying, MBFaceImage, MBEncodeFaceImage, MBFaceImageDpi, MBSignatureImage, MBEncodeSignatureImage, MBSignatureImageDpi, MBFullDocumentImage, MBEncodeFullDocumentImage, MBFullDocumentImageDpi, MBGlareDetection, IMBFullDocumentImageExtensionFactors>
    [iOS (8,0)]
    [BaseType(typeof(MBRecognizer))]
    interface MBCroatiaIdFrontRecognizer : INSCopying, IMBFaceImage, IMBEncodeFaceImage, IMBFaceImageDpi, IMBSignatureImage, IMBEncodeSignatureImage, IMBSignatureImageDpi, IMBFullDocumentImage, IMBEncodeFullDocumentImage, IMBFullDocumentImageDpi, IMBGlareDetection, IMBFullDocumentImageExtensionFactors
    {
        // @property (readonly, nonatomic, strong) MBCroatiaIdFrontRecognizerResult * result;
        [Export("result", ArgumentSemantic.Strong)]
        MBCroatiaIdFrontRecognizerResult Result { get; }

        // @property (assign, nonatomic) BOOL extractFirstName;
        [Export("extractFirstName")]
        bool ExtractFirstName { get; set; }

        // @property (assign, nonatomic) BOOL extractLastName;
        [Export("extractLastName")]
        bool ExtractLastName { get; set; }

        // @property (assign, nonatomic) BOOL extractSex;
        [Export("extractSex")]
        bool ExtractSex { get; set; }

        // @property (assign, nonatomic) BOOL extractCitizenship;
        [Export("extractCitizenship")]
        bool ExtractCitizenship { get; set; }

        // @property (assign, nonatomic) BOOL extractDateOfBirth;
        [Export("extractDateOfBirth")]
        bool ExtractDateOfBirth { get; set; }

        // @property (assign, nonatomic) BOOL extractDateOfExpiry;
        [Export("extractDateOfExpiry")]
        bool ExtractDateOfExpiry { get; set; }
    }


    // @interface MBLegacyMRTDRecognizerResult : MBLegacyRecognizerResult
    
    [BaseType(typeof(MBLegacyRecognizerResult))]
    [DisableDefaultCtor]
    interface MBLegacyMRTDRecognizerResult
    {
        // @property (readonly, nonatomic) NSString * _Nullable issuer;
        [NullAllowed, Export("issuer")]
        string Issuer { get; }

        // @property (readonly, nonatomic) NSString * _Nullable documentNumber;
        [NullAllowed, Export("documentNumber")]
        string DocumentNumber { get; }

        // @property (readonly, nonatomic) NSString * _Nullable documentCode;
        [NullAllowed, Export("documentCode")]
        string DocumentCode { get; }

        // @property (readonly, nonatomic) NSString * _Nullable rawDateOfExpiry;
        [NullAllowed, Export("rawDateOfExpiry")]
        string RawDateOfExpiry { get; }

        // @property (readonly, nonatomic) NSDate * _Nullable dateOfExpiry;
        [NullAllowed, Export("dateOfExpiry")]
        NSDate DateOfExpiry { get; }

        // @property (readonly, nonatomic) NSString * _Nullable primaryId;
        [NullAllowed, Export("primaryId")]
        string PrimaryId { get; }

        // @property (readonly, nonatomic) NSString * _Nullable secondaryId;
        [NullAllowed, Export("secondaryId")]
        string SecondaryId { get; }

        // @property (readonly, nonatomic) NSString * _Nullable rawDateOfBirth;
        [NullAllowed, Export("rawDateOfBirth")]
        string RawDateOfBirth { get; }

        // @property (readonly, nonatomic) NSDate * _Nullable dateOfBirth;
        [NullAllowed, Export("dateOfBirth")]
        NSDate DateOfBirth { get; }

        // @property (readonly, nonatomic) NSString * _Nullable nationality;
        [NullAllowed, Export("nationality")]
        string Nationality { get; }

        // @property (readonly, nonatomic) NSString * _Nullable sex;
        [NullAllowed, Export("sex")]
        string Sex { get; }

        // @property (readonly, nonatomic) NSString * _Nullable opt1;
        [NullAllowed, Export("opt1")]
        string Opt1 { get; }

        // @property (readonly, nonatomic) NSString * _Nullable opt2;
        [NullAllowed, Export("opt2")]
        string Opt2 { get; }

        // @property (readonly, nonatomic) NSString * _Nullable mrzText;
        [NullAllowed, Export("mrzText")]
        string MrzText { get; }

        // @property (readonly, nonatomic) BOOL mrzParsed;
        [Export("mrzParsed")]
        bool MrzParsed { get; }

        // @property (readonly, nonatomic) BOOL mrzVerified;
        [Export("mrzVerified")]
        bool MrzVerified { get; }
    }

// @interface MBCroatiaIdBackRecognizerResult : MBRecognizerResult <NSCopying, MBFullDocumentImageResult, MBEncodedFullDocumentImageResult>
    [iOS (8,0)]
    [BaseType(typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBCroatiaIdBackRecognizerResult : INSCopying, IMBFullDocumentImageResult, IMBEncodedFullDocumentImageResult
    {
        // @property (readonly, nonatomic) NSString * _Nullable residence;
        [NullAllowed, Export("residence")]
        string Residence { get; }

        // @property (readonly, nonatomic) NSString * _Nullable issuedBy;
        [NullAllowed, Export("issuedBy")]
        string IssuedBy { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nullable dateOfIssue;
        [NullAllowed, Export("dateOfIssue")]
        MBDateResult DateOfIssue { get; }

        // @property (readonly, nonatomic) BOOL documentForNonResident;
        [Export("documentForNonResident")]
        bool DocumentForNonResident { get; }

        // @property (readonly, nonatomic) BOOL dateOfExpiryPermanent;
        [Export("dateOfExpiryPermanent")]
        bool DateOfExpiryPermanent { get; }

        // @property (readonly, nonatomic) MBMrzResult * _Nonnull mrzResult;
        [Export("mrzResult")]
        MBMrzResult MrzResult { get; }
    }

    // @interface MBCroatiaIdBackRecognizer : MBRecognizer <NSCopying, MBFullDocumentImage, MBEncodeFullDocumentImage, MBFullDocumentImageDpi, MBGlareDetection, IMBFullDocumentImageExtensionFactors>
    [iOS (8,0)]
    [BaseType(typeof(MBRecognizer))]
    interface MBCroatiaIdBackRecognizer : INSCopying, IMBFullDocumentImage, IMBEncodeFullDocumentImage, IMBFullDocumentImageDpi, IMBGlareDetection, IMBFullDocumentImageExtensionFactors
    {
        // @property (readonly, nonatomic, strong) MBCroatiaIdBackRecognizerResult * result;
        [Export("result", ArgumentSemantic.Strong)]
        MBCroatiaIdBackRecognizerResult Result { get; }

        // @property (assign, nonatomic) BOOL extractResidence;
        [Export("extractResidence")]
        bool ExtractResidence { get; set; }

        // @property (assign, nonatomic) BOOL extractIssuedBy;
        [Export("extractIssuedBy")]
        bool ExtractIssuedBy { get; set; }

        // @property (assign, nonatomic) BOOL extractDateOfIssue;
        [Export("extractDateOfIssue")]
        bool ExtractDateOfIssue { get; set; }
    }

    // @interface MBCroatiaCombinedRecognizerResult : MBRecognizerResult <NSCopying, MBCombinedRecognizerResult, MBDigitalSignatureResult, MBFaceImageResult, MBEncodedFaceImageResult, MBCombinedFullDocumentImageResult, MBEncodedCombinedFullDocumentImageResult, MBSignatureImageResult, MBEncodedSignatureImageResult>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBCroatiaCombinedRecognizerResult : INSCopying, MBCombinedRecognizerResult, IMBDigitalSignatureResult, IMBFaceImageResult, IMBEncodedFaceImageResult, IMBCombinedFullDocumentImageResult, IMBEncodedCombinedFullDocumentImageResult, IMBSignatureImageResult, IMBEncodedSignatureImageResult
    {
        // @property (readonly, nonatomic) NSString * _Nonnull citizenship;
        [Export ("citizenship")]
        string Citizenship { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nonnull dateOfBirth;
        [Export ("dateOfBirth")]
        MBDateResult DateOfBirth { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nonnull dateOfExpiry;
        [Export ("dateOfExpiry")]
        MBDateResult DateOfExpiry { get; }

        // @property (readonly, nonatomic) BOOL dateOfExpiryPermanent;
        [Export ("dateOfExpiryPermanent")]
        bool DateOfExpiryPermanent { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nonnull dateOfIssue;
        [Export ("dateOfIssue")]
        MBDateResult DateOfIssue { get; }

        // @property (readonly, nonatomic) BOOL documentBilingual;
        [Export ("documentBilingual")]
        bool DocumentBilingual { get; }

        // @property (readonly, nonatomic) BOOL documentForNonResident;
        [Export ("documentForNonResident")]
        bool DocumentForNonResident { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull documentNumber;
        [Export ("documentNumber")]
        string DocumentNumber { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull firstName;
        [Export ("firstName")]
        string FirstName { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull issuedBy;
        [Export ("issuedBy")]
        string IssuedBy { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull lastName;
        [Export ("lastName")]
        string LastName { get; }

        // @property (readonly, nonatomic) BOOL mrzVerified;
        [Export ("mrzVerified")]
        bool MrzVerified { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull oib;
        [Export ("oib")]
        string Oib { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull residence;
        [Export ("residence")]
        string Residence { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull sex;
        [Export ("sex")]
        string Sex { get; }
    }

    // @interface MBCroatiaCombinedRecognizer : MBRecognizer <NSCopying, MBCombinedRecognizer, MBDigitalSignature, MBGlareDetection, MBFaceImage, MBEncodeFaceImage, MBFaceImageDpi, MBFullDocumentImage, MBEncodeFullDocumentImage, MBFullDocumentImageDpi, MBFullDocumentImageExtensionFactors, MBSignatureImage, MBSignatureImageDpi, MBEncodeSignatureImage>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizer))]
    interface MBCroatiaCombinedRecognizer : INSCopying, IMBCombinedRecognizer, IMBDigitalSignature, IMBGlareDetection, IMBFaceImage, IMBEncodeFaceImage, IMBFaceImageDpi, IMBFullDocumentImage, IMBEncodeFullDocumentImage, IMBFullDocumentImageDpi, IMBFullDocumentImageExtensionFactors, IMBSignatureImage, IMBSignatureImageDpi, IMBEncodeSignatureImage
    {
        // @property (readonly, nonatomic, strong) MBCroatiaCombinedRecognizerResult * _Nonnull result;
        [Export ("result", ArgumentSemantic.Strong)]
        MBCroatiaCombinedRecognizerResult Result { get; }

        // @property (assign, nonatomic) BOOL extractCitizenship;
        [Export ("extractCitizenship")]
        bool ExtractCitizenship { get; set; }

        // @property (assign, nonatomic) BOOL extractDateOfBirth;
        [Export ("extractDateOfBirth")]
        bool ExtractDateOfBirth { get; set; }

        // @property (assign, nonatomic) BOOL extractDateOfExpiry;
        [Export ("extractDateOfExpiry")]
        bool ExtractDateOfExpiry { get; set; }

        // @property (assign, nonatomic) BOOL extractDateOfIssue;
        [Export ("extractDateOfIssue")]
        bool ExtractDateOfIssue { get; set; }

        // @property (assign, nonatomic) BOOL extractFirstName;
        [Export ("extractFirstName")]
        bool ExtractFirstName { get; set; }

        // @property (assign, nonatomic) BOOL extractIssuedBy;
        [Export ("extractIssuedBy")]
        bool ExtractIssuedBy { get; set; }

        // @property (assign, nonatomic) BOOL extractLastName;
        [Export ("extractLastName")]
        bool ExtractLastName { get; set; }

        // @property (assign, nonatomic) BOOL extractResidence;
        [Export ("extractResidence")]
        bool ExtractResidence { get; set; }

        // @property (assign, nonatomic) BOOL extractSex;
        [Export ("extractSex")]
        bool ExtractSex { get; set; }
    }

    // @interface MBCyprusIdFrontRecognizerResult : MBRecognizerResult <NSCopying, MBFaceImageResult, MBEncodedFaceImageResult, MBFullDocumentImageResult, MBEncodedFullDocumentImageResult, MBSignatureImageResult, MBEncodedSignatureImageResult>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBCyprusIdFrontRecognizerResult : INSCopying, IMBFaceImageResult, IMBEncodedFaceImageResult, IMBFullDocumentImageResult, IMBEncodedFullDocumentImageResult, IMBSignatureImageResult, IMBEncodedSignatureImageResult
    {
        // @property (readonly, nonatomic) NSString * _Nonnull idNumber;
        [Export ("idNumber")]
        string IdNumber { get; }
    }

    // @interface MBCyprusIdFrontRecognizer : MBRecognizer <NSCopying, MBGlareDetection, MBFaceImage, MBEncodeFaceImage, MBFaceImageDpi, MBFullDocumentImage, MBEncodeFullDocumentImage, MBFullDocumentImageDpi, MBFullDocumentImageExtensionFactors, MBSignatureImage, MBSignatureImageDpi, MBEncodeSignatureImage>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizer))]
    interface MBCyprusIdFrontRecognizer : INSCopying, IMBGlareDetection, IMBFaceImage, IMBEncodeFaceImage, IMBFaceImageDpi, IMBFullDocumentImage, IMBEncodeFullDocumentImage, IMBFullDocumentImageDpi, IMBFullDocumentImageExtensionFactors, IMBSignatureImage, IMBSignatureImageDpi, IMBEncodeSignatureImage
    {
        // @property (readonly, nonatomic, strong) MBCyprusIdFrontRecognizerResult * _Nonnull result;
        [Export ("result", ArgumentSemantic.Strong)]
        MBCyprusIdFrontRecognizerResult Result { get; }
    }

    // @interface MBCyprusIdBackRecognizerResult : MBRecognizerResult <NSCopying, MBFullDocumentImageResult, MBEncodedFullDocumentImageResult>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBCyprusIdBackRecognizerResult : INSCopying, IMBFullDocumentImageResult, IMBEncodedFullDocumentImageResult
    {
        // @property (readonly, nonatomic) MBMrzResult * _Nonnull mrzResult;
        [Export ("mrzResult")]
        MBMrzResult MrzResult { get; }
    }

    // @interface MBCyprusIdBackRecognizer : MBRecognizer <NSCopying, MBGlareDetection, MBFullDocumentImage, MBEncodeFullDocumentImage, MBFullDocumentImageDpi, MBFullDocumentImageExtensionFactors>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizer))]
    interface MBCyprusIdBackRecognizer : INSCopying, IMBGlareDetection, IMBFullDocumentImage, IMBEncodeFullDocumentImage, IMBFullDocumentImageDpi, IMBFullDocumentImageExtensionFactors
    {
        // @property (readonly, nonatomic, strong) MBCyprusIdBackRecognizerResult * _Nonnull result;
        [Export ("result", ArgumentSemantic.Strong)]
        MBCyprusIdBackRecognizerResult Result { get; }
    }

    // @interface MBCyprusOldIdFrontRecognizerResult : MBRecognizerResult <NSCopying, MBFaceImageResult, MBEncodedFaceImageResult, MBFullDocumentImageResult, MBEncodedFullDocumentImageResult>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBCyprusOldIdFrontRecognizerResult : INSCopying, IMBFaceImageResult, IMBEncodedFaceImageResult, IMBFullDocumentImageResult, IMBEncodedFullDocumentImageResult
    {
        // @property (readonly, nonatomic) NSString * _Nonnull documentNumber;
        [Export ("documentNumber")]
        string DocumentNumber { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull idNumber;
        [Export ("idNumber")]
        string IdNumber { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull name;
        [Export ("name")]
        string Name { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull surname;
        [Export ("surname")]
        string Surname { get; }
    }

    // @interface MBCyprusOldIdFrontRecognizer : MBRecognizer <NSCopying, MBGlareDetection, MBFaceImage, MBEncodeFaceImage, MBFaceImageDpi, MBFullDocumentImage, MBEncodeFullDocumentImage, MBFullDocumentImageDpi, MBFullDocumentImageExtensionFactors>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizer))]
    interface MBCyprusOldIdFrontRecognizer : INSCopying, IMBGlareDetection, IMBFaceImage, IMBEncodeFaceImage, IMBFaceImageDpi, IMBFullDocumentImage, IMBEncodeFullDocumentImage, IMBFullDocumentImageDpi, IMBFullDocumentImageExtensionFactors
    {
        // @property (readonly, nonatomic, strong) MBCyprusOldIdFrontRecognizerResult * _Nonnull result;
        [Export ("result", ArgumentSemantic.Strong)]
        MBCyprusOldIdFrontRecognizerResult Result { get; }

        // @property (assign, nonatomic) BOOL extractDocumentNumber;
        [Export ("extractDocumentNumber")]
        bool ExtractDocumentNumber { get; set; }

        // @property (assign, nonatomic) BOOL extractName;
        [Export ("extractName")]
        bool ExtractName { get; set; }

        // @property (assign, nonatomic) BOOL extractSurname;
        [Export ("extractSurname")]
        bool ExtractSurname { get; set; }
    }

    // @interface MBCyprusOldIdBackRecognizerResult : MBRecognizerResult <NSCopying, MBFullDocumentImageResult, MBEncodedFullDocumentImageResult>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBCyprusOldIdBackRecognizerResult : INSCopying, IMBFullDocumentImageResult, IMBEncodedFullDocumentImageResult
    {
        // @property (readonly, nonatomic) MBDateResult * _Nonnull dateOfBirth;
        [Export ("dateOfBirth")]
        MBDateResult DateOfBirth { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nonnull expiresOn;
        [Export ("expiresOn")]
        MBDateResult ExpiresOn { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull sex;
        [Export ("sex")]
        string Sex { get; }
    }

    // @interface MBCyprusOldIdBackRecognizer : MBRecognizer <NSCopying, MBGlareDetection, MBFullDocumentImage, MBEncodeFullDocumentImage, MBFullDocumentImageDpi, MBFullDocumentImageExtensionFactors>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizer))]
    interface MBCyprusOldIdBackRecognizer : INSCopying, IMBGlareDetection, IMBFullDocumentImage, IMBEncodeFullDocumentImage, IMBFullDocumentImageDpi, IMBFullDocumentImageExtensionFactors
    {
        // @property (readonly, nonatomic, strong) MBCyprusOldIdBackRecognizerResult * _Nonnull result;
        [Export ("result", ArgumentSemantic.Strong)]
        MBCyprusOldIdBackRecognizerResult Result { get; }

        // @property (assign, nonatomic) BOOL extractExpiresOn;
        [Export ("extractExpiresOn")]
        bool ExtractExpiresOn { get; set; }

        // @property (assign, nonatomic) BOOL extractSex;
        [Export ("extractSex")]
        bool ExtractSex { get; set; }
    }

    // @interface MBCzechiaIdBackRecognizerResult : MBRecognizerResult <NSCopying, MBFullDocumentImageResult, MBEncodedFullDocumentImageResult>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBCzechiaIdBackRecognizerResult : INSCopying, IMBFullDocumentImageResult, IMBEncodedFullDocumentImageResult
    {
        // @property (readonly, nonatomic) NSString * _Nonnull authority;
        [Export ("authority")]
        string Authority { get; }

        // @property (readonly, nonatomic) MBMrzResult * _Nonnull mrzResult;
        [Export ("mrzResult")]
        MBMrzResult MrzResult { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull permanentStay;
        [Export ("permanentStay")]
        string PermanentStay { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull personalNumber;
        [Export ("personalNumber")]
        string PersonalNumber { get; }
    }

    // @interface MBCzechiaIdBackRecognizer : MBRecognizer <NSCopying, MBGlareDetection, MBFullDocumentImage, MBEncodeFullDocumentImage, MBFullDocumentImageDpi, MBFullDocumentImageExtensionFactors>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizer))]
    interface MBCzechiaIdBackRecognizer : INSCopying, IMBGlareDetection, IMBFullDocumentImage, IMBEncodeFullDocumentImage, IMBFullDocumentImageDpi, IMBFullDocumentImageExtensionFactors
    {
        // @property (readonly, nonatomic, strong) MBCzechiaIdBackRecognizerResult * _Nonnull result;
        [Export ("result", ArgumentSemantic.Strong)]
        MBCzechiaIdBackRecognizerResult Result { get; }

        // @property (assign, nonatomic) BOOL extractAuthority;
        [Export ("extractAuthority")]
        bool ExtractAuthority { get; set; }

        // @property (assign, nonatomic) BOOL extractPermanentStay;
        [Export ("extractPermanentStay")]
        bool ExtractPermanentStay { get; set; }

        // @property (assign, nonatomic) BOOL extractPersonalNumber;
        [Export ("extractPersonalNumber")]
        bool ExtractPersonalNumber { get; set; }
    }

    // @interface MBCzechiaIdFrontRecognizerResult : MBRecognizerResult <NSCopying, MBFaceImageResult, MBEncodedFaceImageResult, MBFullDocumentImageResult, MBEncodedFullDocumentImageResult, MBSignatureImageResult, MBEncodedSignatureImageResult>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBCzechiaIdFrontRecognizerResult : INSCopying, IMBFaceImageResult, IMBEncodedFaceImageResult, IMBFullDocumentImageResult, IMBEncodedFullDocumentImageResult, IMBSignatureImageResult, IMBEncodedSignatureImageResult
    {
        // @property (readonly, nonatomic) MBDateResult * _Nonnull dateOfBirth;
        [Export ("dateOfBirth")]
        MBDateResult DateOfBirth { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nonnull dateOfExpiry;
        [Export ("dateOfExpiry")]
        MBDateResult DateOfExpiry { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nonnull dateOfIssue;
        [Export ("dateOfIssue")]
        MBDateResult DateOfIssue { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull documentNumber;
        [Export ("documentNumber")]
        string DocumentNumber { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull givenNames;
        [Export ("givenNames")]
        string GivenNames { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull placeOfBirth;
        [Export ("placeOfBirth")]
        string PlaceOfBirth { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull sex;
        [Export ("sex")]
        string Sex { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull surname;
        [Export ("surname")]
        string Surname { get; }
    }

    // @interface MBCzechiaIdFrontRecognizer : MBRecognizer <NSCopying, MBGlareDetection, MBFaceImage, MBEncodeFaceImage, MBFaceImageDpi, MBFullDocumentImage, MBEncodeFullDocumentImage, MBFullDocumentImageDpi, MBFullDocumentImageExtensionFactors, MBSignatureImage, MBSignatureImageDpi, MBEncodeSignatureImage>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizer))]
    interface MBCzechiaIdFrontRecognizer : INSCopying, IMBGlareDetection, IMBFaceImage, IMBEncodeFaceImage, IMBFaceImageDpi, IMBFullDocumentImage, IMBEncodeFullDocumentImage, IMBFullDocumentImageDpi, IMBFullDocumentImageExtensionFactors, IMBSignatureImage, IMBSignatureImageDpi, IMBEncodeSignatureImage
    {
        // @property (readonly, nonatomic, strong) MBCzechiaIdFrontRecognizerResult * _Nonnull result;
        [Export ("result", ArgumentSemantic.Strong)]
        MBCzechiaIdFrontRecognizerResult Result { get; }

        // @property (assign, nonatomic) BOOL extractDateOfBirth;
        [Export ("extractDateOfBirth")]
        bool ExtractDateOfBirth { get; set; }

        // @property (assign, nonatomic) BOOL extractDateOfExpiry;
        [Export ("extractDateOfExpiry")]
        bool ExtractDateOfExpiry { get; set; }

        // @property (assign, nonatomic) BOOL extractDateOfIssue;
        [Export ("extractDateOfIssue")]
        bool ExtractDateOfIssue { get; set; }

        // @property (assign, nonatomic) BOOL extractGivenNames;
        [Export ("extractGivenNames")]
        bool ExtractGivenNames { get; set; }

        // @property (assign, nonatomic) BOOL extractPlaceOfBirth;
        [Export ("extractPlaceOfBirth")]
        bool ExtractPlaceOfBirth { get; set; }

        // @property (assign, nonatomic) BOOL extractSex;
        [Export ("extractSex")]
        bool ExtractSex { get; set; }

        // @property (assign, nonatomic) BOOL extractSurname;
        [Export ("extractSurname")]
        bool ExtractSurname { get; set; }
    }
    // @interface MBCzechiaCombinedRecognizerResult : MBLegacyRecognizerResult <NSCopying, MBCombinedRecognizerResult, MBFaceImageResult, MBCombinedFullDocumentImageResult, MBSignatureImageResult, MBDigitalSignatureResult, MBEncodedFaceImageResult, MBEncodedSignatureImageResult, MBEncodedCombinedFullDocumentImageResult>
    
    [BaseType(typeof(MBLegacyRecognizerResult))]
    [DisableDefaultCtor]
    interface MBCzechiaCombinedRecognizerResult : INSCopying, MBCombinedRecognizerResult, IMBFaceImageResult, IMBCombinedFullDocumentImageResult, IMBSignatureImageResult, IMBDigitalSignatureResult, IMBEncodedFaceImageResult, IMBEncodedSignatureImageResult, IMBEncodedCombinedFullDocumentImageResult
    {
        // @property (readonly, nonatomic) NSString * _Nullable firstName;
        [NullAllowed, Export("firstName")]
        string FirstName { get; }

        // @property (readonly, nonatomic) NSString * _Nullable lastName;
        [NullAllowed, Export("lastName")]
        string LastName { get; }

        // @property (readonly, nonatomic) NSString * _Nullable identityCardNumber;
        [NullAllowed, Export("identityCardNumber")]
        string IdentityCardNumber { get; }

        // @property (readonly, nonatomic) NSString * _Nullable sex;
        [NullAllowed, Export("sex")]
        string Sex { get; }

        // @property (readonly, nonatomic) NSString * _Nullable nationality;
        [NullAllowed, Export("nationality")]
        string Nationality { get; }

        // @property (readonly, nonatomic) NSDate * _Nullable dateOfBirth;
        [NullAllowed, Export("dateOfBirth")]
        NSDate DateOfBirth { get; }

        // @property (readonly, nonatomic) NSDate * _Nullable dateOfExpiry;
        [NullAllowed, Export("dateOfExpiry")]
        NSDate DateOfExpiry { get; }

        // @property (readonly, nonatomic) NSString * _Nullable placeOfBirth;
        [NullAllowed, Export("placeOfBirth")]
        string PlaceOfBirth { get; }

        // @property (readonly, nonatomic) NSString * _Nullable address;
        [NullAllowed, Export("address")]
        string Address { get; }

        // @property (readonly, nonatomic) NSString * _Nullable issuingAuthority;
        [NullAllowed, Export("issuingAuthority")]
        string IssuingAuthority { get; }

        // @property (readonly, nonatomic) NSDate * _Nullable dateOfIssue;
        [NullAllowed, Export("dateOfIssue")]
        NSDate DateOfIssue { get; }

        // @property (readonly, nonatomic) NSString * _Nullable personalIdentificationNumber;
        [NullAllowed, Export("personalIdentificationNumber")]
        string PersonalIdentificationNumber { get; }

        // @property (readonly, nonatomic) BOOL mrzVerified;
        [Export("mrzVerified")]
        bool MrzVerified { get; }
    }

    // @interface MBCzechiaCombinedRecognizer : MBLegacyRecognizer <NSCopying, MBCombinedRecognizer, MBGlareDetection, MBFullDocumentImage, MBSignatureImage, MBFaceImage, MBEncodeFaceImage, MBEncodeFullDocumentImage, MBEncodeSignatureImage, MBDigitalSignature>
    
    [BaseType(typeof(MBLegacyRecognizer))]
    interface MBCzechiaCombinedRecognizer : INSCopying, IMBCombinedRecognizer, IMBGlareDetection, IMBFullDocumentImage, IMBSignatureImage, IMBFaceImage, IMBEncodeFaceImage, IMBEncodeFullDocumentImage, IMBEncodeSignatureImage, IMBDigitalSignature
    {
        // @property (readonly, nonatomic, strong) MBCzechiaCombinedRecognizerResult * result;
        [Export("result", ArgumentSemantic.Strong)]
        MBCzechiaCombinedRecognizerResult Result { get; }
    }

    // @interface MBDocumentFaceRecognizerResult : MBRecognizerResult <NSCopying, MBFullDocumentImageResult, MBFaceImageResult>
    
    [BaseType(typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBDocumentFaceRecognizerResult : INSCopying, IMBFullDocumentImageResult, IMBFaceImageResult
    {
        // @property (readonly, nonatomic) MBQuadrangle * _Nonnull documentLocation;
        [Export("documentLocation")]
        MBQuadrangle DocumentLocation { get; }

        // @property (readonly, nonatomic) MBQuadrangle * _Nonnull faceLocation;
        [Export("faceLocation")]
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

    // @interface MBEgyptIdFrontRecognizerResult : MBLegacyRecognizerResult <NSCopying, MBFullDocumentImageResult, MBFaceImageResult>
    
    [BaseType(typeof(MBLegacyRecognizerResult))]
    [DisableDefaultCtor]
    interface MBEgyptIdFrontRecognizerResult : INSCopying, IMBFullDocumentImageResult, IMBFaceImageResult
    {
        // @property (readonly, nonatomic) NSString * _Nullable nationalNumber;
        [NullAllowed, Export("nationalNumber")]
        string NationalNumber { get; }

        // @property (readonly, nonatomic) NSString * _Nullable documentNumber;
        [NullAllowed, Export("documentNumber")]
        string DocumentNumber { get; }
    }

    // @interface MBEgyptIdFrontRecognizer : MBLegacyRecognizer <NSCopying, MBFullDocumentImage, MBFaceImage, MBGlareDetection>
    
    [BaseType(typeof(MBLegacyRecognizer))]
    interface MBEgyptIdFrontRecognizer : INSCopying, IMBFullDocumentImage, IMBFaceImage, IMBGlareDetection
    {
        // @property (readonly, nonatomic, strong) MBEgyptIdFrontRecognizerResult * _Nonnull result;
        [Export("result", ArgumentSemantic.Strong)]
        MBEgyptIdFrontRecognizerResult Result { get; }

        // @property (assign, nonatomic) BOOL extractNationalNumber;
        [Export("extractNationalNumber")]
        bool ExtractNationalNumber { get; set; }
    }

    // @interface MBEudlRecognizerResult : MBRecognizerResult <NSCopying, MBFullDocumentImageResult, MBFaceImageResult>
    
    [BaseType(typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBEudlRecognizerResult : INSCopying, IMBFullDocumentImageResult, IMBFaceImageResult
    {
        // @property (readonly, nonatomic) NSString * _Nullable firstName;
        [NullAllowed, Export("firstName")]
        string FirstName { get; }

        // @property (readonly, nonatomic) NSString * _Nullable lastName;
        [NullAllowed, Export("lastName")]
        string LastName { get; }

        // @property (readonly, nonatomic) NSString * _Nullable birthData;
        [NullAllowed, Export("birthData")]
        string BirthData { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nullable issueDate;
        [NullAllowed, Export("issueDate")]
        MBDateResult IssueDate { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nullable expiryDate;
        [NullAllowed, Export("expiryDate")]
        MBDateResult ExpiryDate { get; }

        // @property (readonly, nonatomic) NSString * _Nullable issuingAuthority;
        [NullAllowed, Export("issuingAuthority")]
        string IssuingAuthority { get; }

        // @property (readonly, nonatomic) NSString * _Nullable personalNumber;
        [NullAllowed, Export("personalNumber")]
        string PersonalNumber { get; }

        // @property (readonly, nonatomic) NSString * _Nullable driverNumber;
        [NullAllowed, Export("driverNumber")]
        string DriverNumber { get; }

        // @property (readonly, nonatomic) NSString * _Nullable address;
        [NullAllowed, Export("address")]
        string Address { get; }

        // @property (readonly, nonatomic) MBEudlCountry country;
        [Export("country")]
        MBEudlCountry Country { get; }
    }

    // @interface MBEudlRecognizer : MBRecognizer <NSCopying, MBFaceImage, MBFaceImageDpi, MBFullDocumentImage, MBFullDocumentImageDpi, IMBFullDocumentImageExtensionFactors>
    
    [BaseType(typeof(MBRecognizer))]
    interface MBEudlRecognizer : INSCopying, IMBFaceImage, IMBFaceImageDpi, IMBFullDocumentImage, IMBFullDocumentImageDpi, IMBFullDocumentImageExtensionFactors
    {
        // @property (readonly, nonatomic, strong) MBEudlRecognizerResult * _Nonnull result;
        [Export("result", ArgumentSemantic.Strong)]
        MBEudlRecognizerResult Result { get; }

        // @property (assign, nonatomic) BOOL extractDateOfIssue;
        [Export("extractDateOfIssue")]
        bool ExtractDateOfIssue { get; set; }

        // @property (assign, nonatomic) BOOL extractDateOfExpiry;
        [Export("extractDateOfExpiry")]
        bool ExtractDateOfExpiry { get; set; }

        // @property (assign, nonatomic) BOOL extractPersonalNumber;
        [Export("extractPersonalNumber")]
        bool ExtractPersonalNumber { get; set; }

        // @property (assign, nonatomic) BOOL extractIssuingAuthority;
        [Export("extractIssuingAuthority")]
        bool ExtractIssuingAuthority { get; set; }

        // @property (assign, nonatomic) BOOL extractAddress;
        [Export("extractAddress")]
        bool ExtractAddress { get; set; }

        // @property (assign, nonatomic) MBEudlCountry country;
        [Export("country", ArgumentSemantic.Assign)]
        MBEudlCountry Country { get; set; }
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

   // @interface MBGermanyIdBackRecognizerResult : MBRecognizerResult <NSCopying, MBFullDocumentImageResult, MBEncodedFullDocumentImageResult>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBGermanyIdBackRecognizerResult : INSCopying, IMBFullDocumentImageResult, IMBEncodedFullDocumentImageResult
    {
        // @property (readonly, nonatomic) NSString * _Nonnull addressCity;
        [Export ("addressCity")]
        string AddressCity { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull addressHouseNumber;
        [Export ("addressHouseNumber")]
        string AddressHouseNumber { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull addressStreet;
        [Export ("addressStreet")]
        string AddressStreet { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull addressZipCode;
        [Export ("addressZipCode")]
        string AddressZipCode { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull authority;
        [Export ("authority")]
        string Authority { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull colourOfEyes __attribute__((deprecated("")));
        [Export ("colourOfEyes")]
        string ColourOfEyes { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nonnull dateOfIssue;
        [Export ("dateOfIssue")]
        MBDateResult DateOfIssue { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull fullAddress;
        [Export ("fullAddress")]
        string FullAddress { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull height __attribute__((deprecated("")));
        [Export ("height")]
        string Height { get; }

        // @property (readonly, nonatomic) MBMrzResult * _Nonnull mrzResult;
        [Export ("mrzResult")]
        MBMrzResult MrzResult { get; }
    }

    // @interface MBGermanyIdBackRecognizer : MBRecognizer <NSCopying, MBGlareDetection, MBFullDocumentImage, MBEncodeFullDocumentImage, MBFullDocumentImageDpi, MBFullDocumentImageExtensionFactors>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizer))]
    interface MBGermanyIdBackRecognizer : INSCopying, IMBGlareDetection, IMBFullDocumentImage, IMBEncodeFullDocumentImage, IMBFullDocumentImageDpi, IMBFullDocumentImageExtensionFactors
    {
        // @property (readonly, nonatomic, strong) MBGermanyIdBackRecognizerResult * _Nonnull result;
        [Export ("result", ArgumentSemantic.Strong)]
        MBGermanyIdBackRecognizerResult Result { get; }

        // @property (assign, nonatomic) BOOL extractAddress;
        [Export ("extractAddress")]
        bool ExtractAddress { get; set; }

        // @property (assign, nonatomic) BOOL extractAuthority;
        [Export ("extractAuthority")]
        bool ExtractAuthority { get; set; }

        // @property (assign, nonatomic) BOOL extractColourOfEyes;
        [Export ("extractColourOfEyes")]
        bool ExtractColourOfEyes { get; set; }

        // @property (assign, nonatomic) BOOL extractDateOfIssue;
        [Export ("extractDateOfIssue")]
        bool ExtractDateOfIssue { get; set; }

        // @property (assign, nonatomic) BOOL extractHeight;
        [Export ("extractHeight")]
        bool ExtractHeight { get; set; }
    }

    // @interface MBGermanyIdFrontRecognizerResult : MBRecognizerResult <NSCopying, MBFaceImageResult, MBEncodedFaceImageResult, MBFullDocumentImageResult, MBEncodedFullDocumentImageResult, MBSignatureImageResult, MBEncodedSignatureImageResult>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBGermanyIdFrontRecognizerResult : INSCopying, IMBFaceImageResult, IMBEncodedFaceImageResult, IMBFullDocumentImageResult, IMBEncodedFullDocumentImageResult, IMBSignatureImageResult, IMBEncodedSignatureImageResult
    {
        // @property (readonly, nonatomic) NSString * _Nonnull canNumber;
        [Export ("canNumber")]
        string CanNumber { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nonnull dateOfBirth;
        [Export ("dateOfBirth")]
        MBDateResult DateOfBirth { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nonnull dateOfExpiry;
        [Export ("dateOfExpiry")]
        MBDateResult DateOfExpiry { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull documentNumber;
        [Export ("documentNumber")]
        string DocumentNumber { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull givenNames;
        [Export ("givenNames")]
        string GivenNames { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull nationality;
        [Export ("nationality")]
        string Nationality { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull placeOfBirth;
        [Export ("placeOfBirth")]
        string PlaceOfBirth { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull surname;
        [Export ("surname")]
        string Surname { get; }
    }

    // @interface MBGermanyIdFrontRecognizer : MBRecognizer <NSCopying, MBGlareDetection, MBFaceImage, MBEncodeFaceImage, MBFaceImageDpi, MBFullDocumentImage, MBEncodeFullDocumentImage, MBFullDocumentImageDpi, MBFullDocumentImageExtensionFactors, MBSignatureImage, MBSignatureImageDpi, MBEncodeSignatureImage>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizer))]
    interface MBGermanyIdFrontRecognizer : INSCopying, IMBGlareDetection, IMBFaceImage, IMBEncodeFaceImage, IMBFaceImageDpi, IMBFullDocumentImage, IMBEncodeFullDocumentImage, IMBFullDocumentImageDpi, IMBFullDocumentImageExtensionFactors, IMBSignatureImage, IMBSignatureImageDpi, IMBEncodeSignatureImage
    {
        // @property (readonly, nonatomic, strong) MBGermanyIdFrontRecognizerResult * _Nonnull result;
        [Export ("result", ArgumentSemantic.Strong)]
        MBGermanyIdFrontRecognizerResult Result { get; }

        // @property (assign, nonatomic) BOOL extractCanNumber;
        [Export ("extractCanNumber")]
        bool ExtractCanNumber { get; set; }

        // @property (assign, nonatomic) BOOL extractDateOfExpiry;
        [Export ("extractDateOfExpiry")]
        bool ExtractDateOfExpiry { get; set; }

        // @property (assign, nonatomic) BOOL extractDocumentNumber;
        [Export ("extractDocumentNumber")]
        bool ExtractDocumentNumber { get; set; }

        // @property (assign, nonatomic) BOOL extractGivenNames;
        [Export ("extractGivenNames")]
        bool ExtractGivenNames { get; set; }

        // @property (assign, nonatomic) BOOL extractNationality;
        [Export ("extractNationality")]
        bool ExtractNationality { get; set; }

        // @property (assign, nonatomic) BOOL extractPlaceOfBirth;
        [Export ("extractPlaceOfBirth")]
        bool ExtractPlaceOfBirth { get; set; }

        // @property (assign, nonatomic) BOOL extractSurname;
        [Export ("extractSurname")]
        bool ExtractSurname { get; set; }
    }

    // @interface MBGermanyCombinedRecognizerResult : MBLegacyRecognizerResult <NSCopying, MBCombinedRecognizerResult, MBFaceImageResult, MBCombinedFullDocumentImageResult, MBSignatureImageResult, MBDigitalSignatureResult, MBEncodedFaceImageResult, MBEncodedSignatureImageResult, MBEncodedCombinedFullDocumentImageResult>
    
    [BaseType(typeof(MBLegacyRecognizerResult))]
    [DisableDefaultCtor]
    interface MBGermanyCombinedRecognizerResult : INSCopying, MBCombinedRecognizerResult, IMBFaceImageResult, IMBCombinedFullDocumentImageResult, IMBSignatureImageResult, IMBDigitalSignatureResult, IMBEncodedFaceImageResult, IMBEncodedSignatureImageResult, IMBEncodedCombinedFullDocumentImageResult
    {
        // @property (readonly, nonatomic) NSString * _Nullable firstName;
        [NullAllowed, Export("firstName")]
        string FirstName { get; }

        // @property (readonly, nonatomic) NSString * _Nullable lastName;
        [NullAllowed, Export("lastName")]
        string LastName { get; }

        // @property (readonly, nonatomic) NSString * _Nullable nationality;
        [NullAllowed, Export("nationality")]
        string Nationality { get; }

        // @property (readonly, nonatomic) NSString * _Nullable placeOfBirth;
        [NullAllowed, Export("placeOfBirth")]
        string PlaceOfBirth { get; }

        // @property (readonly, nonatomic) NSString * _Nullable sex;
        [NullAllowed, Export("sex")]
        string Sex { get; }

        // @property (readonly, nonatomic) NSDate * _Nullable dateOfBirth;
        [NullAllowed, Export("dateOfBirth")]
        NSDate DateOfBirth { get; }

        // @property (readonly, nonatomic) NSDate * _Nullable dateOfIssue;
        [NullAllowed, Export("dateOfIssue")]
        NSDate DateOfIssue { get; }

        // @property (readonly, nonatomic) NSDate * _Nullable dateOfExpiry;
        [NullAllowed, Export("dateOfExpiry")]
        NSDate DateOfExpiry { get; }

        // @property (readonly, nonatomic) NSString * _Nullable identityCardNumber;
        [NullAllowed, Export("identityCardNumber")]
        string IdentityCardNumber { get; }

        // @property (readonly, nonatomic) NSString * _Nullable address;
        [NullAllowed, Export("address")]
        string Address { get; }

        // @property (readonly, nonatomic) NSString * _Nullable issuingAuthority;
        [NullAllowed, Export("issuingAuthority")]
        string IssuingAuthority { get; }

        // @property (readonly, nonatomic) NSString * _Nullable height;
        [NullAllowed, Export("height")]
        string Height { get; }

        // @property (readonly, nonatomic) NSString * _Nullable eyeColor;
        [NullAllowed, Export("eyeColor")]
        string EyeColor { get; }

        // @property (readonly, nonatomic) NSString * _Nullable canNumber;
        [NullAllowed, Export("canNumber")]
        string CanNumber { get; }

        // @property (readonly, nonatomic) BOOL mrzVerified;
        [Export("mrzVerified")]
        bool MrzVerified { get; }
    }

    // @interface MBGermanyCombinedRecognizer : MBLegacyRecognizer <NSCopying, MBCombinedRecognizer, MBGlareDetection, MBFullDocumentImage, MBSignatureImage, MBFaceImage, MBEncodeFaceImage, MBEncodeFullDocumentImage, MBEncodeSignatureImage, MBDigitalSignature, MBFullDocumentImageExtensionFactors>
    
    [BaseType(typeof(MBLegacyRecognizer))]
    interface MBGermanyCombinedRecognizer : INSCopying, IMBCombinedRecognizer, IMBGlareDetection, IMBFullDocumentImage, IMBSignatureImage, IMBFaceImage, IMBEncodeFaceImage, IMBEncodeFullDocumentImage, IMBEncodeSignatureImage, IMBDigitalSignature, IMBFullDocumentImageExtensionFactors
    {
        // @property (readonly, nonatomic, strong) MBGermanyCombinedRecognizerResult * result;
        [Export("result", ArgumentSemantic.Strong)]
        MBGermanyCombinedRecognizerResult Result { get; }

        // @property (assign, nonatomic) BOOL extractAddress;
        [Export("extractAddress")]
        bool ExtractAddress { get; set; }
    }

    // @interface MBGermanyPassportRecognizerResult : MBRecognizerResult <NSCopying, MBFaceImageResult, MBEncodedFaceImageResult, MBFullDocumentImageResult, MBEncodedFullDocumentImageResult, MBSignatureImageResult, MBEncodedSignatureImageResult>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBGermanyPassportRecognizerResult : INSCopying, IMBFaceImageResult, IMBEncodedFaceImageResult, IMBFullDocumentImageResult, IMBEncodedFullDocumentImageResult, IMBSignatureImageResult, IMBEncodedSignatureImageResult
    {
        // @property (readonly, nonatomic) NSString * _Nonnull authority;
        [Export ("authority")]
        string Authority { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nonnull dateOfIssue;
        [Export ("dateOfIssue")]
        MBDateResult DateOfIssue { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull givenName;
        [Export ("givenName")]
        string GivenName { get; }

        // @property (readonly, nonatomic) MBMrzResult * _Nonnull mrzResult;
        [Export ("mrzResult")]
        MBMrzResult MrzResult { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull nationality;
        [Export ("nationality")]
        string Nationality { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull placeOfBirth;
        [Export ("placeOfBirth")]
        string PlaceOfBirth { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull surname;
        [Export ("surname")]
        string Surname { get; }
    }

    // @interface MBGermanyPassportRecognizer : MBRecognizer <NSCopying, MBGlareDetection, MBFaceImage, MBEncodeFaceImage, MBFaceImageDpi, MBFullDocumentImage, MBEncodeFullDocumentImage, MBFullDocumentImageDpi, MBFullDocumentImageExtensionFactors, MBSignatureImage, MBSignatureImageDpi, MBEncodeSignatureImage>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizer))]
    interface MBGermanyPassportRecognizer : INSCopying, IMBGlareDetection, IMBFaceImage, IMBEncodeFaceImage, IMBFaceImageDpi, IMBFullDocumentImage, IMBEncodeFullDocumentImage, IMBFullDocumentImageDpi, IMBFullDocumentImageExtensionFactors, IMBSignatureImage, IMBSignatureImageDpi, IMBEncodeSignatureImage
    {
        // @property (readonly, nonatomic, strong) MBGermanyPassportRecognizerResult * _Nonnull result;
        [Export ("result", ArgumentSemantic.Strong)]
        MBGermanyPassportRecognizerResult Result { get; }

        // @property (assign, nonatomic) BOOL extractAuthority;
        [Export ("extractAuthority")]
        bool ExtractAuthority { get; set; }

        // @property (assign, nonatomic) BOOL extractDateOfIssue;
        [Export ("extractDateOfIssue")]
        bool ExtractDateOfIssue { get; set; }

        // @property (assign, nonatomic) BOOL extractGivenName;
        [Export ("extractGivenName")]
        bool ExtractGivenName { get; set; }

        // @property (assign, nonatomic) BOOL extractNationality;
        [Export ("extractNationality")]
        bool ExtractNationality { get; set; }

        // @property (assign, nonatomic) BOOL extractPlaceOfBirth;
        [Export ("extractPlaceOfBirth")]
        bool ExtractPlaceOfBirth { get; set; }

        // @property (assign, nonatomic) BOOL extractSurname;
        [Export ("extractSurname")]
        bool ExtractSurname { get; set; }
    }


    // @interface MBGermanyIdOldRecognizerResult : MBRecognizerResult <NSCopying, MBFaceImageResult, MBEncodedFaceImageResult, MBFullDocumentImageResult, MBEncodedFullDocumentImageResult, MBSignatureImageResult, MBEncodedSignatureImageResult>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBGermanyIdOldRecognizerResult : INSCopying, IMBFaceImageResult, IMBEncodedFaceImageResult, IMBFullDocumentImageResult, IMBEncodedFullDocumentImageResult, IMBSignatureImageResult, IMBEncodedSignatureImageResult
    {
        // @property (readonly, nonatomic) MBMrzResult * _Nonnull mrzResult;
        [Export ("mrzResult")]
        MBMrzResult MrzResult { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull placeOfBirth;
        [Export ("placeOfBirth")]
        string PlaceOfBirth { get; }
    }

    // @interface MBGermanyIdOldRecognizer : MBRecognizer <NSCopying, MBGlareDetection, MBFaceImage, MBEncodeFaceImage, MBFaceImageDpi, MBFullDocumentImage, MBEncodeFullDocumentImage, MBFullDocumentImageDpi, MBFullDocumentImageExtensionFactors, MBSignatureImage, MBSignatureImageDpi, MBEncodeSignatureImage>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizer))]
    interface MBGermanyIdOldRecognizer : INSCopying, IMBGlareDetection, IMBFaceImage, IMBEncodeFaceImage, IMBFaceImageDpi, IMBFullDocumentImage, IMBEncodeFullDocumentImage, IMBFullDocumentImageDpi, IMBFullDocumentImageExtensionFactors, IMBSignatureImage, IMBSignatureImageDpi, IMBEncodeSignatureImage
    {
        // @property (readonly, nonatomic, strong) MBGermanyIdOldRecognizerResult * _Nonnull result;
        [Export ("result", ArgumentSemantic.Strong)]
        MBGermanyIdOldRecognizerResult Result { get; }

        // @property (assign, nonatomic) BOOL extractPlaceOfBirth;
        [Export ("extractPlaceOfBirth")]
        bool ExtractPlaceOfBirth { get; set; }
    }


    // @interface MBGermanyDlBackRecognizerResult : MBRecognizerResult <NSCopying, MBFullDocumentImageResult, MBEncodedFullDocumentImageResult>
    [iOS (8,0)]
    [BaseType(typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBGermanyDlBackRecognizerResult : INSCopying, IMBFullDocumentImageResult, IMBEncodedFullDocumentImageResult
    {
        // @property (readonly, nonatomic) MBDateResult * _Nonnull dateOfIssueB10;
        [Export ("dateOfIssueB10")]
        MBDateResult DateOfIssueB10 { get; }

        // @property (readonly, nonatomic) BOOL dateOfIssueB10NotSpecified;
        [Export ("dateOfIssueB10NotSpecified")]
        bool DateOfIssueB10NotSpecified { get; }
    }

    // @interface MBGermanyDlBackRecognizer : MBRecognizer <NSCopying, MBGlareDetection, MBFullDocumentImage, MBEncodeFullDocumentImage, MBFullDocumentImageDpi, MBFullDocumentImageExtensionFactors>
    [iOS (8,0)]
    [BaseType(typeof(MBRecognizer))]
    interface MBGermanyDlBackRecognizer : INSCopying, IMBGlareDetection, IMBFullDocumentImage, IMBEncodeFullDocumentImage, IMBFullDocumentImageDpi, IMBFullDocumentImageExtensionFactors
    {
        // @property (readonly, nonatomic, strong) MBGermanyDlBackRecognizerResult * _Nonnull result;
        [Export ("result", ArgumentSemantic.Strong)]
        MBGermanyDlBackRecognizerResult Result { get; }
    }

    // @interface MBGermanyDlFrontRecognizerResult : MBRecognizerResult <NSCopying, MBFaceImageResult, MBEncodedFaceImageResult, MBFullDocumentImageResult, MBEncodedFullDocumentImageResult, MBSignatureImageResult, MBEncodedSignatureImageResult>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBGermanyDlFrontRecognizerResult : INSCopying, IMBFaceImageResult, IMBEncodedFaceImageResult, IMBFullDocumentImageResult, IMBEncodedFullDocumentImageResult, IMBSignatureImageResult, IMBEncodedSignatureImageResult
    {
        // @property (readonly, nonatomic) MBDateResult * _Nonnull dateOfBirth;
        [Export ("dateOfBirth")]
        MBDateResult DateOfBirth { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nonnull dateOfExpiry;
        [Export ("dateOfExpiry")]
        MBDateResult DateOfExpiry { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nonnull dateOfIssue;
        [Export ("dateOfIssue")]
        MBDateResult DateOfIssue { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull firstName;
        [Export ("firstName")]
        string FirstName { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull issuingAuthority;
        [Export ("issuingAuthority")]
        string IssuingAuthority { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull lastName;
        [Export ("lastName")]
        string LastName { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull licenceCategories;
        [Export ("licenceCategories")]
        string LicenceCategories { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull licenceNumber;
        [Export ("licenceNumber")]
        string LicenceNumber { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull placeOfBirth;
        [Export ("placeOfBirth")]
        string PlaceOfBirth { get; }
    }

    // @interface MBGermanyDlFrontRecognizer : MBRecognizer <NSCopying, MBGlareDetection, MBFaceImage, MBEncodeFaceImage, MBFaceImageDpi, MBFullDocumentImage, MBEncodeFullDocumentImage, MBFullDocumentImageDpi, MBFullDocumentImageExtensionFactors, MBSignatureImage, MBSignatureImageDpi, MBEncodeSignatureImage>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizer))]
    interface MBGermanyDlFrontRecognizer : INSCopying, IMBGlareDetection, IMBFaceImage, IMBEncodeFaceImage, IMBFaceImageDpi, IMBFullDocumentImage, IMBEncodeFullDocumentImage, IMBFullDocumentImageDpi, IMBFullDocumentImageExtensionFactors, IMBSignatureImage, IMBSignatureImageDpi, IMBEncodeSignatureImage
    {
        // @property (readonly, nonatomic, strong) MBGermanyDlFrontRecognizerResult * _Nonnull result;
        [Export ("result", ArgumentSemantic.Strong)]
        MBGermanyDlFrontRecognizerResult Result { get; }

        // @property (assign, nonatomic) BOOL extractDateOfBirth;
        [Export ("extractDateOfBirth")]
        bool ExtractDateOfBirth { get; set; }

        // @property (assign, nonatomic) BOOL extractDateOfExpiry;
        [Export ("extractDateOfExpiry")]
        bool ExtractDateOfExpiry { get; set; }

        // @property (assign, nonatomic) BOOL extractDateOfIssue;
        [Export ("extractDateOfIssue")]
        bool ExtractDateOfIssue { get; set; }

        // @property (assign, nonatomic) BOOL extractFirstName;
        [Export ("extractFirstName")]
        bool ExtractFirstName { get; set; }

        // @property (assign, nonatomic) BOOL extractIssuingAuthority;
        [Export ("extractIssuingAuthority")]
        bool ExtractIssuingAuthority { get; set; }

        // @property (assign, nonatomic) BOOL extractLastName;
        [Export ("extractLastName")]
        bool ExtractLastName { get; set; }

        // @property (assign, nonatomic) BOOL extractLicenceCategories;
        [Export ("extractLicenceCategories")]
        bool ExtractLicenceCategories { get; set; }

        // @property (assign, nonatomic) BOOL extractPlaceOfBirth;
        [Export ("extractPlaceOfBirth")]
        bool ExtractPlaceOfBirth { get; set; }
    }


  // @interface MBHongKongIdFrontRecognizerResult : MBRecognizerResult <NSCopying, MBFaceImageResult, MBEncodedFaceImageResult, MBFullDocumentImageResult, MBEncodedFullDocumentImageResult>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBHongKongIdFrontRecognizerResult : INSCopying, IMBFaceImageResult, IMBEncodedFaceImageResult, IMBFullDocumentImageResult, IMBEncodedFullDocumentImageResult
    {
        // @property (readonly, nonatomic) NSString * _Nullable fullName;
        [NullAllowed, Export ("fullName")]
        string FullName { get; }

        // @property (readonly, nonatomic) NSString * _Nullable commercialCode;
        [NullAllowed, Export ("commercialCode")]
        string CommercialCode { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nullable dateOfBirth;
        [NullAllowed, Export ("dateOfBirth")]
        MBDateResult DateOfBirth { get; }

        // @property (readonly, nonatomic) NSString * _Nullable sex;
        [NullAllowed, Export ("sex")]
        string Sex { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nullable dateOfIssue;
        [NullAllowed, Export ("dateOfIssue")]
        MBDateResult DateOfIssue { get; }

        // @property (readonly, nonatomic) NSString * _Nullable documentNumber;
        [NullAllowed, Export ("documentNumber")]
        string DocumentNumber { get; }

        // @property (readonly, nonatomic) NSString * _Nullable residentialStatus;
        [NullAllowed, Export ("residentialStatus")]
        string ResidentialStatus { get; }
    }

    // @interface MBHongKongIdFrontRecognizer : MBRecognizer <NSCopying, MBFaceImage, MBEncodeFaceImage, MBFaceImageDpi, MBFullDocumentImage, MBEncodeFullDocumentImage, MBFullDocumentImageDpi, MBGlareDetection, MBFullDocumentImageExtensionFactors>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizer))]
    interface MBHongKongIdFrontRecognizer : INSCopying, IMBFaceImage, IMBEncodeFaceImage, IMBFaceImageDpi, IMBFullDocumentImage, IMBEncodeFullDocumentImage, IMBFullDocumentImageDpi, IMBGlareDetection, IMBFullDocumentImageExtensionFactors
    {
        // @property (readonly, nonatomic, strong) MBHongKongIdFrontRecognizerResult * _Nonnull result;
        [Export ("result", ArgumentSemantic.Strong)]
        MBHongKongIdFrontRecognizerResult Result { get; }

        // @property (assign, nonatomic) BOOL extractFullName;
        [Export ("extractFullName")]
        bool ExtractFullName { get; set; }

        // @property (assign, nonatomic) BOOL extractCommercialCode;
        [Export ("extractCommercialCode")]
        bool ExtractCommercialCode { get; set; }

        // @property (assign, nonatomic) BOOL extractDateOfBirth;
        [Export ("extractDateOfBirth")]
        bool ExtractDateOfBirth { get; set; }

        // @property (assign, nonatomic) BOOL extractResidentialStatus;
        [Export ("extractResidentialStatus")]
        bool ExtractResidentialStatus { get; set; }

        // @property (assign, nonatomic) BOOL extractSex;
        [Export ("extractSex")]
        bool ExtractSex { get; set; }

        // @property (assign, nonatomic) BOOL extractDateOfIssue;
        [Export ("extractDateOfIssue")]
        bool ExtractDateOfIssue { get; set; }
    }

    // @interface MBIndonesiaIdFrontRecognizerResult : MBRecognizerResult <NSCopying, MBFaceImageResult, MBEncodedFaceImageResult, MBFullDocumentImageResult, MBEncodedFullDocumentImageResult, MBSignatureImageResult, MBEncodedSignatureImageResult>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBIndonesiaIdFrontRecognizerResult : INSCopying, IMBFaceImageResult, IMBEncodedFaceImageResult, IMBFullDocumentImageResult, IMBEncodedFullDocumentImageResult, IMBSignatureImageResult, IMBEncodedSignatureImageResult
    {
        // @property (readonly, nonatomic) NSString * _Nonnull address;
        [Export ("address")]
        string Address { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull bloodType;
        [Export ("bloodType")]
        string BloodType { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull citizenship;
        [Export ("citizenship")]
        string Citizenship { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull city;
        [Export ("city")]
        string City { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nonnull dateOfBirth;
        [Export ("dateOfBirth")]
        MBDateResult DateOfBirth { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nonnull dateOfExpiry;
        [Export ("dateOfExpiry")]
        MBDateResult DateOfExpiry { get; }

        // @property (readonly, assign, nonatomic) BOOL dateOfExpiryPermanent;
        [Export ("dateOfExpiryPermanent")]
        bool DateOfExpiryPermanent { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull district;
        [Export ("district")]
        string District { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull documentNumber;
        [Export ("documentNumber")]
        string DocumentNumber { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull kelDesa;
        [Export ("kelDesa")]
        string KelDesa { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull maritalStatus;
        [Export ("maritalStatus")]
        string MaritalStatus { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull name;
        [Export ("name")]
        string Name { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull occupation;
        [Export ("occupation")]
        string Occupation { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull placeOfBirth;
        [Export ("placeOfBirth")]
        string PlaceOfBirth { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull province;
        [Export ("province")]
        string Province { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull religion;
        [Export ("religion")]
        string Religion { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull rt;
        [Export ("rt")]
        string Rt { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull rw;
        [Export ("rw")]
        string Rw { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull sex;
        [Export ("sex")]
        string Sex { get; }
    }

    // @interface MBIndonesiaIdFrontRecognizer : MBRecognizer <NSCopying, MBFaceImage, MBEncodeFaceImage, MBFaceImageDpi, MBFullDocumentImage, MBEncodeFullDocumentImage, MBFullDocumentImageDpi, MBSignatureImage, MBEncodeSignatureImage, MBSignatureImageDpi, MBGlareDetection, MBFullDocumentImageExtensionFactors>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizer))]
    interface MBIndonesiaIdFrontRecognizer : INSCopying, IMBFaceImage, IMBEncodeFaceImage, IMBFaceImageDpi, IMBFullDocumentImage, IMBEncodeFullDocumentImage, IMBFullDocumentImageDpi, IMBSignatureImage, IMBEncodeSignatureImage, IMBSignatureImageDpi, IMBGlareDetection, IMBFullDocumentImageExtensionFactors
    {
        // @property (readonly, nonatomic, strong) MBIndonesiaIdFrontRecognizerResult * _Nonnull result;
        [Export ("result", ArgumentSemantic.Strong)]
        MBIndonesiaIdFrontRecognizerResult Result { get; }

        // @property (assign, nonatomic) BOOL extractAddress;
        [Export ("extractAddress")]
        bool ExtractAddress { get; set; }

        // @property (assign, nonatomic) BOOL extractBloodType;
        [Export ("extractBloodType")]
        bool ExtractBloodType { get; set; }

        // @property (assign, nonatomic) BOOL extractCitizenship;
        [Export ("extractCitizenship")]
        bool ExtractCitizenship { get; set; }

        // @property (assign, nonatomic) BOOL extractCity;
        [Export ("extractCity")]
        bool ExtractCity { get; set; }

        // @property (assign, nonatomic) BOOL extractDateOfExpiry;
        [Export ("extractDateOfExpiry")]
        bool ExtractDateOfExpiry { get; set; }

        // @property (assign, nonatomic) BOOL extractDistrict;
        [Export ("extractDistrict")]
        bool ExtractDistrict { get; set; }

        // @property (assign, nonatomic) BOOL extractKelDesa;
        [Export ("extractKelDesa")]
        bool ExtractKelDesa { get; set; }

        // @property (assign, nonatomic) BOOL extractMaritalStatus;
        [Export ("extractMaritalStatus")]
        bool ExtractMaritalStatus { get; set; }

        // @property (assign, nonatomic) BOOL extractName;
        [Export ("extractName")]
        bool ExtractName { get; set; }

        // @property (assign, nonatomic) BOOL extractOccupation;
        [Export ("extractOccupation")]
        bool ExtractOccupation { get; set; }

        // @property (assign, nonatomic) BOOL extractPlaceOfBirth;
        [Export ("extractPlaceOfBirth")]
        bool ExtractPlaceOfBirth { get; set; }

        // @property (assign, nonatomic) BOOL extractReligion;
        [Export ("extractReligion")]
        bool ExtractReligion { get; set; }

        // @property (assign, nonatomic) BOOL extractRt;
        [Export ("extractRt")]
        bool ExtractRt { get; set; }

        // @property (assign, nonatomic) BOOL extractRw;
        [Export ("extractRw")]
        bool ExtractRw { get; set; }
    }

    // @interface MBIrelandDlFrontRecognizerResult : MBRecognizerResult <NSCopying, MBFaceImageResult, MBEncodedFaceImageResult, MBFullDocumentImageResult, MBEncodedFullDocumentImageResult, MBSignatureImageResult, MBEncodedSignatureImageResult>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBIrelandDlFrontRecognizerResult : INSCopying, IMBFaceImageResult, IMBEncodedFaceImageResult, IMBFullDocumentImageResult, IMBEncodedFullDocumentImageResult, IMBSignatureImageResult, IMBEncodedSignatureImageResult
    {
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

        // @property (readonly, nonatomic) NSString * _Nonnull driverNumber;
        [Export ("driverNumber")]
        string DriverNumber { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull firstName;
        [Export ("firstName")]
        string FirstName { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull issuedBy;
        [Export ("issuedBy")]
        string IssuedBy { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull licenceCategories;
        [Export ("licenceCategories")]
        string LicenceCategories { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull licenceNumber;
        [Export ("licenceNumber")]
        string LicenceNumber { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull placeOfBirth;
        [Export ("placeOfBirth")]
        string PlaceOfBirth { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull surname;
        [Export ("surname")]
        string Surname { get; }
    }

    // @interface MBIrelandDlFrontRecognizer : MBRecognizer <NSCopying, MBFaceImage, MBEncodeFaceImage, MBFaceImageDpi, MBFullDocumentImage, MBEncodeFullDocumentImage, MBFullDocumentImageDpi, MBSignatureImage, MBEncodeSignatureImage, MBSignatureImageDpi, MBGlareDetection, MBFullDocumentImageExtensionFactors>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizer))]
    interface MBIrelandDlFrontRecognizer : INSCopying, IMBFaceImage, IMBEncodeFaceImage, IMBFaceImageDpi, IMBFullDocumentImage, IMBEncodeFullDocumentImage, IMBFullDocumentImageDpi, IMBSignatureImage, IMBEncodeSignatureImage, IMBSignatureImageDpi, IMBGlareDetection, IMBFullDocumentImageExtensionFactors
    {
        // @property (readonly, nonatomic, strong) MBIrelandDlFrontRecognizerResult * _Nonnull result;
        [Export ("result", ArgumentSemantic.Strong)]
        MBIrelandDlFrontRecognizerResult Result { get; }

        // @property (assign, nonatomic) BOOL extractAddress;
        [Export ("extractAddress")]
        bool ExtractAddress { get; set; }

        // @property (assign, nonatomic) BOOL extractDateOfBirth;
        [Export ("extractDateOfBirth")]
        bool ExtractDateOfBirth { get; set; }

        // @property (assign, nonatomic) BOOL extractDateOfExpiry;
        [Export ("extractDateOfExpiry")]
        bool ExtractDateOfExpiry { get; set; }

        // @property (assign, nonatomic) BOOL extractDateOfIssue;
        [Export ("extractDateOfIssue")]
        bool ExtractDateOfIssue { get; set; }

        // @property (assign, nonatomic) BOOL extractFirstName;
        [Export ("extractFirstName")]
        bool ExtractFirstName { get; set; }

        // @property (assign, nonatomic) BOOL extractIssuedBy;
        [Export ("extractIssuedBy")]
        bool ExtractIssuedBy { get; set; }

        // @property (assign, nonatomic) BOOL extractLicenceCategories;
        [Export ("extractLicenceCategories")]
        bool ExtractLicenceCategories { get; set; }

        // @property (assign, nonatomic) BOOL extractLicenceNumber;
        [Export ("extractLicenceNumber")]
        bool ExtractLicenceNumber { get; set; }

        // @property (assign, nonatomic) BOOL extractPlaceOfBirth;
        [Export ("extractPlaceOfBirth")]
        bool ExtractPlaceOfBirth { get; set; }

        // @property (assign, nonatomic) BOOL extractSurname;
        [Export ("extractSurname")]
        bool ExtractSurname { get; set; }
    }

    // @interface MBItalyDlFrontRecognizerResult : MBRecognizerResult <NSCopying, MBFaceImageResult, MBEncodedFaceImageResult, MBFullDocumentImageResult, MBEncodedFullDocumentImageResult, MBSignatureImageResult, MBEncodedSignatureImageResult>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBItalyDlFrontRecognizerResult : INSCopying, IMBFaceImageResult, IMBEncodedFaceImageResult, IMBFullDocumentImageResult, IMBEncodedFullDocumentImageResult, IMBSignatureImageResult, IMBEncodedSignatureImageResult
    {
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

        // @property (readonly, nonatomic) NSString * _Nonnull givenName;
        [Export ("givenName")]
        string GivenName { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull issuingAuthority;
        [Export ("issuingAuthority")]
        string IssuingAuthority { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull licenceCategories;
        [Export ("licenceCategories")]
        string LicenceCategories { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull licenceNumber;
        [Export ("licenceNumber")]
        string LicenceNumber { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull placeOfBirth;
        [Export ("placeOfBirth")]
        string PlaceOfBirth { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull surname;
        [Export ("surname")]
        string Surname { get; }
    }

    // @interface MBItalyDlFrontRecognizer : MBRecognizer <NSCopying, MBFaceImage, MBEncodeFaceImage, MBFaceImageDpi, MBFullDocumentImage, MBEncodeFullDocumentImage, MBFullDocumentImageDpi, MBSignatureImage, MBEncodeSignatureImage, MBSignatureImageDpi, MBGlareDetection, MBFullDocumentImageExtensionFactors>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizer))]
    interface MBItalyDlFrontRecognizer : INSCopying, IMBFaceImage, IMBEncodeFaceImage, IMBFaceImageDpi, IMBFullDocumentImage, IMBEncodeFullDocumentImage, IMBFullDocumentImageDpi, IMBSignatureImage, IMBEncodeSignatureImage, IMBSignatureImageDpi, IMBGlareDetection, IMBFullDocumentImageExtensionFactors
    {
        // @property (readonly, nonatomic, strong) MBItalyDlFrontRecognizerResult * _Nonnull result;
        [Export ("result", ArgumentSemantic.Strong)]
        MBItalyDlFrontRecognizerResult Result { get; }

        // @property (assign, nonatomic) BOOL extractAddress;
        [Export ("extractAddress")]
        bool ExtractAddress { get; set; }

        // @property (assign, nonatomic) BOOL extractDateOfBirth;
        [Export ("extractDateOfBirth")]
        bool ExtractDateOfBirth { get; set; }

        // @property (assign, nonatomic) BOOL extractDateOfExpiry;
        [Export ("extractDateOfExpiry")]
        bool ExtractDateOfExpiry { get; set; }

        // @property (assign, nonatomic) BOOL extractDateOfIssue;
        [Export ("extractDateOfIssue")]
        bool ExtractDateOfIssue { get; set; }

        // @property (assign, nonatomic) BOOL extractGivenName;
        [Export ("extractGivenName")]
        bool ExtractGivenName { get; set; }

        // @property (assign, nonatomic) BOOL extractIssuingAuthority;
        [Export ("extractIssuingAuthority")]
        bool ExtractIssuingAuthority { get; set; }

        // @property (assign, nonatomic) BOOL extractLicenceCategories;
        [Export ("extractLicenceCategories")]
        bool ExtractLicenceCategories { get; set; }

        // @property (assign, nonatomic) BOOL extractPlaceOfBirth;
        [Export ("extractPlaceOfBirth")]
        bool ExtractPlaceOfBirth { get; set; }

        // @property (assign, nonatomic) BOOL extractSurname;
        [Export ("extractSurname")]
        bool ExtractSurname { get; set; }
    }

    // @interface MBKuwaitIdFrontRecognizerResult : MBRecognizerResult <NSCopying, MBFaceImageResult, MBEncodedFaceImageResult, MBFullDocumentImageResult, MBEncodedFullDocumentImageResult>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBKuwaitIdFrontRecognizerResult : INSCopying, IMBFaceImageResult, IMBEncodedFaceImageResult, IMBFullDocumentImageResult, IMBEncodedFullDocumentImageResult
    {
        // @property (readonly, nonatomic) MBDateResult * _Nonnull birthDate;
        [Export ("birthDate")]
        MBDateResult BirthDate { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull civilIdNumber;
        [Export ("civilIdNumber")]
        string CivilIdNumber { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nonnull expiryDate;
        [Export ("expiryDate")]
        MBDateResult ExpiryDate { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull name;
        [Export ("name")]
        string Name { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull nationality;
        [Export ("nationality")]
        string Nationality { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull sex;
        [Export ("sex")]
        string Sex { get; }
    }

    // @interface MBKuwaitIdFrontRecognizer : MBRecognizer <NSCopying, MBFaceImage, MBEncodeFaceImage, MBFaceImageDpi, MBFullDocumentImage, MBEncodeFullDocumentImage, MBFullDocumentImageDpi, MBGlareDetection, MBFullDocumentImageExtensionFactors>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizer))]
    interface MBKuwaitIdFrontRecognizer : INSCopying, IMBFaceImage, IMBEncodeFaceImage, IMBFaceImageDpi, IMBFullDocumentImage, IMBEncodeFullDocumentImage, IMBFullDocumentImageDpi, IMBGlareDetection, IMBFullDocumentImageExtensionFactors
    {
        // @property (readonly, nonatomic, strong) MBKuwaitIdFrontRecognizerResult * _Nonnull result;
        [Export ("result", ArgumentSemantic.Strong)]
        MBKuwaitIdFrontRecognizerResult Result { get; }

        // @property (assign, nonatomic) BOOL extractBirthDate;
        [Export ("extractBirthDate")]
        bool ExtractBirthDate { get; set; }

        // @property (assign, nonatomic) BOOL extractName;
        [Export ("extractName")]
        bool ExtractName { get; set; }

        // @property (assign, nonatomic) BOOL extractNationality;
        [Export ("extractNationality")]
        bool ExtractNationality { get; set; }

        // @property (assign, nonatomic) BOOL extractSex;
        [Export ("extractSex")]
        bool ExtractSex { get; set; }
    }

    // @interface MBKuwaitIdBackRecognizerResult : MBRecognizerResult <NSCopying, MBFullDocumentImageResult, MBEncodedFullDocumentImageResult>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBKuwaitIdBackRecognizerResult : INSCopying, IMBFullDocumentImageResult, IMBEncodedFullDocumentImageResult
    {
        // @property (readonly, nonatomic) MBMrzResult * _Nonnull mrzResult;
        [Export ("mrzResult")]
        MBMrzResult MrzResult { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull serialNo;
        [Export ("serialNo")]
        string SerialNo { get; }
    }

    // @interface MBKuwaitIdBackRecognizer : MBRecognizer <NSCopying, MBFullDocumentImage, MBEncodeFullDocumentImage, MBFullDocumentImageDpi, MBGlareDetection, MBFullDocumentImageExtensionFactors>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizer))]
    interface MBKuwaitIdBackRecognizer : INSCopying, IMBFullDocumentImage, IMBEncodeFullDocumentImage, IMBFullDocumentImageDpi, IMBGlareDetection, IMBFullDocumentImageExtensionFactors
    {
        // @property (readonly, nonatomic, strong) MBKuwaitIdBackRecognizerResult * _Nonnull result;
        [Export ("result", ArgumentSemantic.Strong)]
        MBKuwaitIdBackRecognizerResult Result { get; }

        // @property (assign, nonatomic) BOOL extractSerialNo;
        [Export ("extractSerialNo")]
        bool ExtractSerialNo { get; set; }
    }
    // @interface MBJordanIdBackRecognizerResult : MBLegacyMRTDRecognizerResult <NSCopying, MBFullDocumentImageResult>
    
    [BaseType(typeof(MBLegacyMRTDRecognizerResult))]
    [DisableDefaultCtor]
    interface MBJordanIdBackRecognizerResult : INSCopying, IMBFullDocumentImageResult
    {
    }

    // @interface MBJordanIdBackRecognizer : MBLegacyRecognizer <NSCopying, MBFullDocumentImage, MBGlareDetection>
    
    [BaseType(typeof(MBLegacyRecognizer))]
    interface MBJordanIdBackRecognizer : INSCopying, IMBFullDocumentImage, IMBGlareDetection
    {
        // @property (readonly, nonatomic, strong) MBJordanIdBackRecognizerResult * _Nonnull result;
        [Export("result", ArgumentSemantic.Strong)]
        MBJordanIdBackRecognizerResult Result { get; }
    }

    // @interface MBJordanIdFrontRecognizerResult : MBLegacyRecognizerResult <NSCopying, MBFullDocumentImageResult, MBFaceImageResult>
    
    [BaseType(typeof(MBLegacyRecognizerResult))]
    [DisableDefaultCtor]
    interface MBJordanIdFrontRecognizerResult : INSCopying, IMBFullDocumentImageResult, IMBFaceImageResult
    {
        // @property (readonly, nonatomic) NSString * _Nullable name;
        [NullAllowed, Export("name")]
        string Name { get; }

        // @property (readonly, nonatomic) NSString * _Nullable sex;
        [NullAllowed, Export("sex")]
        string Sex { get; }

        // @property (readonly, nonatomic) NSDate * _Nullable dateOfBirth;
        [NullAllowed, Export("dateOfBirth")]
        NSDate DateOfBirth { get; }

        // @property (readonly, nonatomic) NSString * _Nullable nationalNumber;
        [NullAllowed, Export("nationalNumber")]
        string NationalNumber { get; }
    }

    // @interface MBJordanIdFrontRecognizer : MBLegacyRecognizer <NSCopying, MBFullDocumentImage, MBFaceImage, MBGlareDetection, MBFullDocumentImageDpi>
    
    [BaseType(typeof(MBLegacyRecognizer))]
    interface MBJordanIdFrontRecognizer : INSCopying, IMBFullDocumentImage, IMBFaceImage, IMBGlareDetection, IMBFullDocumentImageDpi
    {
        // @property (readonly, nonatomic, strong) MBJordanIdFrontRecognizerResult * _Nonnull result;
        [Export("result", ArgumentSemantic.Strong)]
        MBJordanIdFrontRecognizerResult Result { get; }

        // @property (assign, nonatomic) BOOL extractName;
        [Export("extractName")]
        bool ExtractName { get; set; }

        // @property (assign, nonatomic) BOOL extractSex;
        [Export("extractSex")]
        bool ExtractSex { get; set; }

        // @property (assign, nonatomic) BOOL extractDateOfBirth;
        [Export("extractDateOfBirth")]
        bool ExtractDateOfBirth { get; set; }
    }

    // @interface MBJordanCombinedRecognizerResult : MBLegacyRecognizerResult <NSCopying, MBCombinedRecognizerResult, MBFaceImageResult, MBCombinedFullDocumentImageResult, MBDigitalSignatureResult, MBEncodedFaceImageResult, MBEncodedCombinedFullDocumentImageResult>
    
    [BaseType(typeof(MBLegacyRecognizerResult))]
    [DisableDefaultCtor]
    interface MBJordanCombinedRecognizerResult : INSCopying, MBCombinedRecognizerResult, IMBFaceImageResult, IMBCombinedFullDocumentImageResult, IMBDigitalSignatureResult, IMBEncodedFaceImageResult, IMBEncodedCombinedFullDocumentImageResult
    {
        // @property (readonly, nonatomic) NSString * _Nullable name;
        [NullAllowed, Export("name")]
        string Name { get; }

        // @property (readonly, nonatomic) NSString * _Nullable sex;
        [NullAllowed, Export("sex")]
        string Sex { get; }

        // @property (readonly, nonatomic) NSDate * _Nullable dateOfBirth;
        [NullAllowed, Export("dateOfBirth")]
        NSDate DateOfBirth { get; }

        // @property (readonly, nonatomic) NSString * _Nullable nationalNumber;
        [NullAllowed, Export("nationalNumber")]
        string NationalNumber { get; }

        // @property (readonly, nonatomic) NSString * _Nullable nationality;
        [NullAllowed, Export("nationality")]
        string Nationality { get; }

        // @property (readonly, nonatomic) NSString * _Nullable issuer;
        [NullAllowed, Export("issuer")]
        string Issuer { get; }

        // @property (readonly, nonatomic) NSString * _Nullable documentNumber;
        [NullAllowed, Export("documentNumber")]
        string DocumentNumber { get; }

        // @property (readonly, nonatomic) NSDate * _Nullable dateOfExpiry;
        [NullAllowed, Export("dateOfExpiry")]
        NSDate DateOfExpiry { get; }

        // @property (readonly, nonatomic) BOOL mrzVerified;
        [Export("mrzVerified")]
        bool MrzVerified { get; }
    }

    // @interface MBJordanCombinedRecognizer : MBLegacyRecognizer <NSCopying, MBCombinedRecognizer, MBGlareDetection, MBFullDocumentImage, MBFaceImage, MBEncodeFaceImage, MBEncodeFullDocumentImage, MBDigitalSignature>
    
    [BaseType(typeof(MBLegacyRecognizer))]
    interface MBJordanCombinedRecognizer : INSCopying, IMBCombinedRecognizer, IMBGlareDetection, IMBFullDocumentImage, IMBFaceImage, IMBEncodeFaceImage, IMBEncodeFullDocumentImage, IMBDigitalSignature
    {
        // @property (readonly, nonatomic, strong) MBJordanCombinedRecognizerResult * result;
        [Export("result", ArgumentSemantic.Strong)]
        MBJordanCombinedRecognizerResult Result { get; }

        // @property (assign, nonatomic) BOOL extractName;
        [Export("extractName")]
        bool ExtractName { get; set; }

        // @property (assign, nonatomic) BOOL extractSex;
        [Export("extractSex")]
        bool ExtractSex { get; set; }

        // @property (assign, nonatomic) BOOL extractDateOfBirth;
        [Export("extractDateOfBirth")]
        bool ExtractDateOfBirth { get; set; }
    }

    // @interface MBMalaysiaMyKadBackRecognizerResult : MBRecognizerResult <NSCopying, MBFullDocumentImageResult>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBMalaysiaMyKadBackRecognizerResult : INSCopying, IMBFullDocumentImageResult
    {
        // @property (readonly, nonatomic) NSString * _Nonnull extendedNric __attribute__((deprecated("")));
        [Export ("extendedNric")]
        string ExtendedNric { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull nric;
        [Export ("nric")]
        string Nric { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull oldNric;
        [Export ("oldNric")]
        string OldNric { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nonnull dateOfBirth;
        [Export ("dateOfBirth")]
        MBDateResult DateOfBirth { get; }
    }

    // @interface MBMalaysiaMyKadBackRecognizer : MBRecognizer <NSCopying, MBFullDocumentImage, MBFullDocumentImageDpi, MBGlareDetection, MBFullDocumentImageExtensionFactors>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizer))]
    interface MBMalaysiaMyKadBackRecognizer : INSCopying, IMBFullDocumentImage, IMBFullDocumentImageDpi, IMBGlareDetection, IMBFullDocumentImageExtensionFactors
    {
        // @property (readonly, nonatomic, strong) MBMalaysiaMyKadBackRecognizerResult * _Nonnull result;
        [Export ("result", ArgumentSemantic.Strong)]
        MBMalaysiaMyKadBackRecognizerResult Result { get; }

        // @property (assign, nonatomic) BOOL extractOldNric;
        [Export ("extractOldNric")]
        bool ExtractOldNric { get; set; }
    }

    // @interface MBMalaysiaMyKadFrontRecognizerResult : MBRecognizerResult <NSCopying, MBFaceImageResult, MBEncodedFaceImageResult, MBFullDocumentImageResult, MBEncodedFullDocumentImageResult>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBMalaysiaMyKadFrontRecognizerResult : INSCopying, IMBFaceImageResult, IMBEncodedFaceImageResult, IMBFullDocumentImageResult, IMBEncodedFullDocumentImageResult
    {
        // @property (readonly, nonatomic) MBDateResult * _Nonnull birthDate;
        [Export ("birthDate")]
        MBDateResult BirthDate { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull city;
        [Export ("city")]
        string City { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull fullAddress;
        [Export ("fullAddress")]
        string FullAddress { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull fullName;
        [Export ("fullName")]
        string FullName { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull nric;
        [Export ("nric")]
        string Nric { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull ownerState;
        [Export ("ownerState")]
        string OwnerState { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull religion;
        [Export ("religion")]
        string Religion { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull sex;
        [Export ("sex")]
        string Sex { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull street;
        [Export ("street")]
        string Street { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull zipcode;
        [Export ("zipcode")]
        string Zipcode { get; }
    }

    // @interface MBMalaysiaMyKadFrontRecognizer : MBRecognizer <NSCopying, MBGlareDetection, MBFaceImage, MBEncodeFaceImage, MBFaceImageDpi, MBFullDocumentImage, MBEncodeFullDocumentImage, MBFullDocumentImageDpi, MBFullDocumentImageExtensionFactors>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizer))]
    interface MBMalaysiaMyKadFrontRecognizer : INSCopying, IMBGlareDetection, IMBFaceImage, IMBEncodeFaceImage, IMBFaceImageDpi, IMBFullDocumentImage, IMBEncodeFullDocumentImage, IMBFullDocumentImageDpi, IMBFullDocumentImageExtensionFactors
    {
        // @property (readonly, nonatomic, strong) MBMalaysiaMyKadFrontRecognizerResult * _Nonnull result;
        [Export ("result", ArgumentSemantic.Strong)]
        MBMalaysiaMyKadFrontRecognizerResult Result { get; }

        // @property (assign, nonatomic) BOOL extractFullNameAndAddress;
        [Export ("extractFullNameAndAddress")]
        bool ExtractFullNameAndAddress { get; set; }

        // @property (assign, nonatomic) BOOL extractReligion;
        [Export ("extractReligion")]
        bool ExtractReligion { get; set; }

        // @property (assign, nonatomic) BOOL extractSex;
        [Export ("extractSex")]
        bool ExtractSex { get; set; }
    }

    // @interface MBMalaysiaIkadFrontRecognizerResult : MBRecognizerResult <NSCopying, MBFaceImageResult, MBEncodedFaceImageResult, MBFullDocumentImageResult, MBEncodedFullDocumentImageResult>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBMalaysiaIkadFrontRecognizerResult : INSCopying, IMBFaceImageResult, IMBEncodedFaceImageResult, IMBFullDocumentImageResult, IMBEncodedFullDocumentImageResult
    {
        // @property (readonly, nonatomic) NSString * _Nonnull address;
        [Export ("address")]
        string Address { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nonnull dateOfBirth;
        [Export ("dateOfBirth")]
        MBDateResult DateOfBirth { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nonnull dateOfExpiry;
        [Export ("dateOfExpiry")]
        MBDateResult DateOfExpiry { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull employer;
        [Export ("employer")]
        string Employer { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull facultyAddress;
        [Export ("facultyAddress")]
        string FacultyAddress { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull gender;
        [Export ("gender")]
        string Gender { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull name;
        [Export ("name")]
        string Name { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull nationality;
        [Export ("nationality")]
        string Nationality { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull passportNumber;
        [Export ("passportNumber")]
        string PassportNumber { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull sector;
        [Export ("sector")]
        string Sector { get; }
    }

    // @interface MBMalaysiaIkadFrontRecognizer : MBRecognizer <NSCopying, MBGlareDetection, MBFaceImage, MBEncodeFaceImage, MBFaceImageDpi, MBFullDocumentImage, MBEncodeFullDocumentImage, MBFullDocumentImageDpi, MBFullDocumentImageExtensionFactors>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizer))]
    interface MBMalaysiaIkadFrontRecognizer : INSCopying, IMBGlareDetection, IMBFaceImage, IMBEncodeFaceImage, IMBFaceImageDpi, IMBFullDocumentImage, IMBEncodeFullDocumentImage, IMBFullDocumentImageDpi, IMBFullDocumentImageExtensionFactors
    {
        // @property (readonly, nonatomic, strong) MBMalaysiaIkadFrontRecognizerResult * _Nonnull result;
        [Export ("result", ArgumentSemantic.Strong)]
        MBMalaysiaIkadFrontRecognizerResult Result { get; }

        // @property (assign, nonatomic) BOOL extractAddress;
        [Export ("extractAddress")]
        bool ExtractAddress { get; set; }

        // @property (assign, nonatomic) BOOL extractDateOfExpiry;
        [Export ("extractDateOfExpiry")]
        bool ExtractDateOfExpiry { get; set; }

        // @property (assign, nonatomic) BOOL extractEmployer;
        [Export ("extractEmployer")]
        bool ExtractEmployer { get; set; }

        // @property (assign, nonatomic) BOOL extractFacultyAddress;
        [Export ("extractFacultyAddress")]
        bool ExtractFacultyAddress { get; set; }

        // @property (assign, nonatomic) BOOL extractGender;
        [Export ("extractGender")]
        bool ExtractGender { get; set; }

        // @property (assign, nonatomic) BOOL extractName;
        [Export ("extractName")]
        bool ExtractName { get; set; }

        // @property (assign, nonatomic) BOOL extractNationality;
        [Export ("extractNationality")]
        bool ExtractNationality { get; set; }

        // @property (assign, nonatomic) BOOL extractPassportNumber;
        [Export ("extractPassportNumber")]
        bool ExtractPassportNumber { get; set; }

        // @property (assign, nonatomic) BOOL extractSector;
        [Export ("extractSector")]
        bool ExtractSector { get; set; }
    }

    // @interface MBMalaysiaMyTenteraFrontRecognizerResult : MBRecognizerResult <NSCopying, MBFaceImageResult, MBEncodedFaceImageResult, MBFullDocumentImageResult, MBEncodedFullDocumentImageResult>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBMalaysiaMyTenteraFrontRecognizerResult : INSCopying, IMBFaceImageResult, IMBEncodedFaceImageResult, IMBFullDocumentImageResult, IMBEncodedFullDocumentImageResult
    {
        // @property (readonly, nonatomic) NSString * _Nonnull armyNumber;
        [Export ("armyNumber")]
        string ArmyNumber { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nonnull birthDate;
        [Export ("birthDate")]
        MBDateResult BirthDate { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull city;
        [Export ("city")]
        string City { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull fullAddress;
        [Export ("fullAddress")]
        string FullAddress { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull fullName;
        [Export ("fullName")]
        string FullName { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull nric;
        [Export ("nric")]
        string Nric { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull ownerState;
        [Export ("ownerState")]
        string OwnerState { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull religion;
        [Export ("religion")]
        string Religion { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull sex;
        [Export ("sex")]
        string Sex { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull street;
        [Export ("street")]
        string Street { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull zipcode;
        [Export ("zipcode")]
        string Zipcode { get; }
    }

    // @interface MBMalaysiaMyTenteraFrontRecognizer : MBRecognizer <NSCopying, MBGlareDetection, MBFaceImage, MBEncodeFaceImage, MBFaceImageDpi, MBFullDocumentImage, MBEncodeFullDocumentImage, MBFullDocumentImageDpi, MBFullDocumentImageExtensionFactors>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizer))]
    interface MBMalaysiaMyTenteraFrontRecognizer : INSCopying, IMBGlareDetection, IMBFaceImage, IMBEncodeFaceImage, IMBFaceImageDpi, IMBFullDocumentImage, IMBEncodeFullDocumentImage, IMBFullDocumentImageDpi, IMBFullDocumentImageExtensionFactors
    {
        // @property (readonly, nonatomic, strong) MBMalaysiaMyTenteraFrontRecognizerResult * _Nonnull result;
        [Export ("result", ArgumentSemantic.Strong)]
        MBMalaysiaMyTenteraFrontRecognizerResult Result { get; }

        // @property (assign, nonatomic) BOOL extractFullNameAndAddress;
        [Export ("extractFullNameAndAddress")]
        bool ExtractFullNameAndAddress { get; set; }

        // @property (assign, nonatomic) BOOL extractReligion;
        [Export ("extractReligion")]
        bool ExtractReligion { get; set; }
    }

    // @interface MBMalaysiaDlFrontRecognizerResult : MBRecognizerResult <NSCopying, MBFaceImageResult, MBEncodedFaceImageResult, MBFullDocumentImageResult, MBEncodedFullDocumentImageResult>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBMalaysiaDlFrontRecognizerResult : INSCopying, IMBFaceImageResult, IMBEncodedFaceImageResult, IMBFullDocumentImageResult, IMBEncodedFullDocumentImageResult
    {
        // @property (readonly, nonatomic) NSString * _Nonnull city;
        [Export ("city")]
        string City { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull dlClass;
        [Export ("dlClass")]
        string DlClass { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull fullAddress;
        [Export ("fullAddress")]
        string FullAddress { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull identityNumber;
        [Export ("identityNumber")]
        string IdentityNumber { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull name;
        [Export ("name")]
        string Name { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull nationality;
        [Export ("nationality")]
        string Nationality { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull ownerState;
        [Export ("ownerState")]
        string OwnerState { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull street;
        [Export ("street")]
        string Street { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nonnull validFrom;
        [Export ("validFrom")]
        MBDateResult ValidFrom { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nonnull validUntil;
        [Export ("validUntil")]
        MBDateResult ValidUntil { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull zipcode;
        [Export ("zipcode")]
        string Zipcode { get; }
    }

    // @interface MBMalaysiaDlFrontRecognizer : MBRecognizer <NSCopying, MBFaceImage, MBEncodeFaceImage, MBFaceImageDpi, MBFullDocumentImage, MBEncodeFullDocumentImage, MBFullDocumentImageDpi, MBGlareDetection, MBFullDocumentImageExtensionFactors>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizer))]
    interface MBMalaysiaDlFrontRecognizer : INSCopying, IMBFaceImage, IMBEncodeFaceImage, IMBFaceImageDpi, IMBFullDocumentImage, IMBEncodeFullDocumentImage, IMBFullDocumentImageDpi, IMBGlareDetection, IMBFullDocumentImageExtensionFactors
    {
        // @property (readonly, nonatomic, strong) MBMalaysiaDlFrontRecognizerResult * _Nonnull result;
        [Export ("result", ArgumentSemantic.Strong)]
        MBMalaysiaDlFrontRecognizerResult Result { get; }

        // @property (assign, nonatomic) BOOL extractAddress;
        [Export ("extractAddress")]
        bool ExtractAddress { get; set; }

        // @property (assign, nonatomic) BOOL extractClass;
        [Export ("extractClass")]
        bool ExtractClass { get; set; }

        // @property (assign, nonatomic) BOOL extractName;
        [Export ("extractName")]
        bool ExtractName { get; set; }

        // @property (assign, nonatomic) BOOL extractNationality;
        [Export ("extractNationality")]
        bool ExtractNationality { get; set; }

        // @property (assign, nonatomic) BOOL extractValidFrom;
        [Export ("extractValidFrom")]
        bool ExtractValidFrom { get; set; }

        // @property (assign, nonatomic) BOOL extractValidUntil;
        [Export ("extractValidUntil")]
        bool ExtractValidUntil { get; set; }
    }

    // @interface MBMalaysiaMyPrFrontRecognizerResult : MBRecognizerResult <NSCopying, MBFaceImageResult, MBEncodedFaceImageResult, MBFullDocumentImageResult, MBEncodedFullDocumentImageResult>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBMalaysiaMyPrFrontRecognizerResult : INSCopying, IMBFaceImageResult, IMBEncodedFaceImageResult, IMBFullDocumentImageResult, IMBEncodedFullDocumentImageResult
    {
        // @property (readonly, nonatomic) MBDateResult * _Nonnull birthDate;
        [Export ("birthDate")]
        MBDateResult BirthDate { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull city;
        [Export ("city")]
        string City { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull countryCode;
        [Export ("countryCode")]
        string CountryCode { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull fullAddress;
        [Export ("fullAddress")]
        string FullAddress { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull fullName;
        [Export ("fullName")]
        string FullName { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull nric;
        [Export ("nric")]
        string Nric { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull ownerState;
        [Export ("ownerState")]
        string OwnerState { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull religion;
        [Export ("religion")]
        string Religion { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull sex;
        [Export ("sex")]
        string Sex { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull street;
        [Export ("street")]
        string Street { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull zipcode;
        [Export ("zipcode")]
        string Zipcode { get; }
    }

    // @interface MBMalaysiaMyPrFrontRecognizer : MBRecognizer <NSCopying, MBGlareDetection, MBFaceImage, MBEncodeFaceImage, MBFaceImageDpi, MBFullDocumentImage, MBEncodeFullDocumentImage, MBFullDocumentImageDpi, MBFullDocumentImageExtensionFactors>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizer))]
    interface MBMalaysiaMyPrFrontRecognizer : INSCopying, IMBGlareDetection, IMBFaceImage, IMBEncodeFaceImage, IMBFaceImageDpi, IMBFullDocumentImage, IMBEncodeFullDocumentImage, IMBFullDocumentImageDpi, IMBFullDocumentImageExtensionFactors
    {
        // @property (readonly, nonatomic, strong) MBMalaysiaMyPrFrontRecognizerResult * _Nonnull result;
        [Export ("result", ArgumentSemantic.Strong)]
        MBMalaysiaMyPrFrontRecognizerResult Result { get; }

        // @property (assign, nonatomic) BOOL extractFullNameAndAddress;
        [Export ("extractFullNameAndAddress")]
        bool ExtractFullNameAndAddress { get; set; }

        // @property (assign, nonatomic) BOOL extractReligion;
        [Export ("extractReligion")]
        bool ExtractReligion { get; set; }

        // @property (assign, nonatomic) BOOL extractSex;
        [Export ("extractSex")]
        bool ExtractSex { get; set; }
    }

    // @interface MBMalaysiaMyKasFrontRecognizerResult : MBRecognizerResult <NSCopying, MBFaceImageResult, MBEncodedFaceImageResult, MBFullDocumentImageResult, MBEncodedFullDocumentImageResult>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBMalaysiaMyKasFrontRecognizerResult : INSCopying, IMBFaceImageResult, IMBEncodedFaceImageResult, IMBFullDocumentImageResult, IMBEncodedFullDocumentImageResult
    {
        // @property (readonly, nonatomic) MBDateResult * _Nonnull birthDate;
        [Export ("birthDate")]
        MBDateResult BirthDate { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull city;
        [Export ("city")]
        string City { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nonnull dateOfExpiry;
        [Export ("dateOfExpiry")]
        MBDateResult DateOfExpiry { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull fullAddress;
        [Export ("fullAddress")]
        string FullAddress { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull fullName;
        [Export ("fullName")]
        string FullName { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull nric;
        [Export ("nric")]
        string Nric { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull ownerState;
        [Export ("ownerState")]
        string OwnerState { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull religion;
        [Export ("religion")]
        string Religion { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull sex;
        [Export ("sex")]
        string Sex { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull street;
        [Export ("street")]
        string Street { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull zipcode;
        [Export ("zipcode")]
        string Zipcode { get; }
    }

    // @interface MBMalaysiaMyKasFrontRecognizer : MBRecognizer <NSCopying, MBGlareDetection, MBFaceImage, MBEncodeFaceImage, MBFaceImageDpi, MBFullDocumentImage, MBEncodeFullDocumentImage, MBFullDocumentImageDpi, MBFullDocumentImageExtensionFactors>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizer))]
    interface MBMalaysiaMyKasFrontRecognizer : INSCopying, IMBGlareDetection, IMBFaceImage, IMBEncodeFaceImage, IMBFaceImageDpi, IMBFullDocumentImage, IMBEncodeFullDocumentImage, IMBFullDocumentImageDpi, IMBFullDocumentImageExtensionFactors
    {
        // @property (readonly, nonatomic, strong) MBMalaysiaMyKasFrontRecognizerResult * _Nonnull result;
        [Export ("result", ArgumentSemantic.Strong)]
        MBMalaysiaMyKasFrontRecognizerResult Result { get; }

        // @property (assign, nonatomic) BOOL extractFullNameAndAddress;
        [Export ("extractFullNameAndAddress")]
        bool ExtractFullNameAndAddress { get; set; }

        // @property (assign, nonatomic) BOOL extractReligion;
        [Export ("extractReligion")]
        bool ExtractReligion { get; set; }

        // @property (assign, nonatomic) BOOL extractSex;
        [Export ("extractSex")]
        bool ExtractSex { get; set; }
    }


    // @interface MBMexicoVoterIdFrontRecognizerResult : MBRecognizerResult <NSCopying, MBFaceImageResult, MBEncodedFaceImageResult, MBFullDocumentImageResult, MBEncodedFullDocumentImageResult, MBSignatureImageResult, MBEncodedSignatureImageResult>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBMexicoVoterIdFrontRecognizerResult : INSCopying, IMBFaceImageResult, IMBEncodedFaceImageResult, IMBFullDocumentImageResult, IMBEncodedFullDocumentImageResult, IMBSignatureImageResult, IMBEncodedSignatureImageResult
    {
        // @property (readonly, nonatomic) NSString * _Nonnull address;
        [Export ("address")]
        string Address { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull curp;
        [Export ("curp")]
        string Curp { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nonnull dateOfBirth;
        [Export ("dateOfBirth")]
        MBDateResult DateOfBirth { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull electorKey;
        [Export ("electorKey")]
        string ElectorKey { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull fullName;
        [Export ("fullName")]
        string FullName { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull sex;
        [Export ("sex")]
        string Sex { get; }
    }

    // @interface MBMexicoVoterIdFrontRecognizer : MBRecognizer <NSCopying, MBGlareDetection, MBFaceImage, MBEncodeFaceImage, MBFaceImageDpi, MBFullDocumentImage, MBEncodeFullDocumentImage, MBFullDocumentImageDpi, MBFullDocumentImageExtensionFactors, MBSignatureImage, MBSignatureImageDpi, MBEncodeSignatureImage>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizer))]
    interface MBMexicoVoterIdFrontRecognizer : INSCopying, IMBGlareDetection, IMBFaceImage, IMBEncodeFaceImage, IMBFaceImageDpi, IMBFullDocumentImage, IMBEncodeFullDocumentImage, IMBFullDocumentImageDpi, IMBFullDocumentImageExtensionFactors, IMBSignatureImage, IMBSignatureImageDpi, IMBEncodeSignatureImage
    {
        // @property (readonly, nonatomic, strong) MBMexicoVoterIdFrontRecognizerResult * _Nonnull result;
        [Export ("result", ArgumentSemantic.Strong)]
        MBMexicoVoterIdFrontRecognizerResult Result { get; }

        // @property (assign, nonatomic) BOOL extractAddress;
        [Export ("extractAddress")]
        bool ExtractAddress { get; set; }

        // @property (assign, nonatomic) BOOL extractCurp;
        [Export ("extractCurp")]
        bool ExtractCurp { get; set; }

        // @property (assign, nonatomic) BOOL extractFullName;
        [Export ("extractFullName")]
        bool ExtractFullName { get; set; }
    }


        // @interface MBMoroccoIdFrontRecognizerResult : MBRecognizerResult <NSCopying, MBFaceImageResult, MBEncodedFaceImageResult, MBSignatureImageResult, MBEncodedSignatureImageResult, MBFullDocumentImageResult, MBEncodedFullDocumentImageResult>
    [iOS (8,0)]
    [BaseType(typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBMoroccoIdFrontRecognizerResult : INSCopying, IMBFaceImageResult, IMBEncodedFaceImageResult, IMBSignatureImageResult, IMBEncodedSignatureImageResult, IMBFullDocumentImageResult, IMBEncodedFullDocumentImageResult
    {
        // @property (readonly, nonatomic) MBDateResult * _Nonnull dateOfBirth;
        [Export("dateOfBirth")]
        MBDateResult DateOfBirth { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nonnull dateOfExpiry;
        [Export("dateOfExpiry")]
        MBDateResult DateOfExpiry { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull documentNumber;
        [Export("documentNumber")]
        string DocumentNumber { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull name;
        [Export("name")]
        string Name { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull placeOfBirth;
        [Export("placeOfBirth")]
        string PlaceOfBirth { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull sex;
        [Export("sex")]
        string Sex { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull surname;
        [Export("surname")]
        string Surname { get; }
    }

    // @interface MBMoroccoIdFrontRecognizer : MBRecognizer <NSCopying, MBFaceImage, MBEncodeFaceImage, MBFaceImageDpi, MBSignatureImage, MBEncodeSignatureImage, MBSignatureImageDpi, MBFullDocumentImage, MBEncodeFullDocumentImage, MBFullDocumentImageDpi, MBGlareDetection, IMBFullDocumentImageExtensionFactors>
    [iOS (8,0)]
    [BaseType(typeof(MBRecognizer))]
    interface MBMoroccoIdFrontRecognizer : INSCopying, IMBFaceImage, IMBEncodeFaceImage, IMBFaceImageDpi, IMBSignatureImage, IMBEncodeSignatureImage, IMBSignatureImageDpi, IMBFullDocumentImage, IMBEncodeFullDocumentImage, IMBFullDocumentImageDpi, IMBGlareDetection, IMBFullDocumentImageExtensionFactors
    {
        // @property (readonly, nonatomic, strong) MBMoroccoIdFrontRecognizerResult * _Nonnull result;
        [Export("result", ArgumentSemantic.Strong)]
        MBMoroccoIdFrontRecognizerResult Result { get; }

        // @property (assign, nonatomic) BOOL extractDateOfBirth;
        [Export("extractDateOfBirth")]
        bool ExtractDateOfBirth { get; set; }

        // @property (assign, nonatomic) BOOL extractDateOfExpiry;
        [Export("extractDateOfExpiry")]
        bool ExtractDateOfExpiry { get; set; }

        // @property (assign, nonatomic) BOOL extractName;
        [Export("extractName")]
        bool ExtractName { get; set; }

        // @property (assign, nonatomic) BOOL extractPlaceOfBirth;
        [Export("extractPlaceOfBirth")]
        bool ExtractPlaceOfBirth { get; set; }

        // @property (assign, nonatomic) BOOL extractSex;
        [Export("extractSex")]
        bool ExtractSex { get; set; }

        // @property (assign, nonatomic) BOOL extractSurname;
        [Export("extractSurname")]
        bool ExtractSurname { get; set; }
    }

    // @interface MBMoroccoIdBackRecognizerResult : MBRecognizerResult <NSCopying, MBFullDocumentImageResult, MBEncodedFullDocumentImageResult>
    [iOS (8,0)]
    [BaseType(typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBMoroccoIdBackRecognizerResult : INSCopying, IMBFullDocumentImageResult, IMBEncodedFullDocumentImageResult
    {
        // @property (readonly, nonatomic) MBDateResult * _Nonnull dateOfExpiry;
        [Export("dateOfExpiry")]
        MBDateResult DateOfExpiry { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull documentNumber;
        [Export("documentNumber")]
        string DocumentNumber { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull fathersName;
        [Export("fathersName")]
        string FathersName { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull mothersName;
        [Export("mothersName")]
        string MothersName { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull sex;
        [Export("sex")]
        string Sex { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull address;
        [Export("address")]
        string Address { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull civilStatusNumber;
        [Export("civilStatusNumber")]
        string CivilStatusNumber { get; }
    }

    // @interface MBMoroccoIdBackRecognizer : MBRecognizer <NSCopying, MBFullDocumentImage, MBEncodeFullDocumentImage, MBFullDocumentImageDpi, MBGlareDetection, IMBFullDocumentImageExtensionFactors>
    [iOS (8,0)]
    [BaseType(typeof(MBRecognizer))]
    interface MBMoroccoIdBackRecognizer : INSCopying, IMBFullDocumentImage, IMBEncodeFullDocumentImage, IMBFullDocumentImageDpi, IMBGlareDetection, IMBFullDocumentImageExtensionFactors
    {
        // @property (readonly, nonatomic, strong) MBMoroccoIdBackRecognizerResult * _Nonnull result;
        [Export("result", ArgumentSemantic.Strong)]
        MBMoroccoIdBackRecognizerResult Result { get; }

        // @property (assign, nonatomic) BOOL extractAddress;
        [Export("extractAddress")]
        bool ExtractAddress { get; set; }

        // @property (assign, nonatomic) BOOL extractDateOfExpiry;
        [Export("extractDateOfExpiry")]
        bool ExtractDateOfExpiry { get; set; }

        // @property (assign, nonatomic) BOOL extractFathersName;
        [Export("extractFathersName")]
        bool ExtractFathersName { get; set; }

        // @property (assign, nonatomic) BOOL extractMothersName;
        [Export("extractMothersName")]
        bool ExtractMothersName { get; set; }

        // @property (assign, nonatomic) BOOL extractSex;
        [Export("extractSex")]
        bool ExtractSex { get; set; }

        // @property (assign, nonatomic) BOOL extractCivilStatusNumber;
        [Export("extractCivilStatusNumber")]
        bool ExtractCivilStatusNumber { get; set; }
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

		// -(void)setMrzFilter:(id<MBMrzFilter> _Nullable)mrzFilter;
		[Export ("setMrzFilter:")]
		void SetMrzFilter ([NullAllowed] MBMrzFilter mrzFilter);
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


    
// @interface MBNewZealandDlFrontRecognizerResult : MBRecognizerResult <NSCopying, MBFaceImageResult, MBEncodedFaceImageResult, MBSignatureImageResult, MBEncodedSignatureImageResult, MBFullDocumentImageResult, MBEncodedFullDocumentImageResult>
    [iOS (8,0)]
    [BaseType(typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBNewZealandDlFrontRecognizerResult : INSCopying, IMBFaceImageResult, IMBEncodedFaceImageResult, IMBSignatureImageResult, IMBEncodedSignatureImageResult, IMBFullDocumentImageResult, IMBEncodedFullDocumentImageResult
    {
        // @property (readonly, nonatomic) NSString * _Nullable firstNames;
        [NullAllowed, Export("firstNames")]
        string FirstNames { get; }

        // @property (readonly, nonatomic) NSString * _Nullable surname;
        [NullAllowed, Export("surname")]
        string Surname { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nullable dateOfBirth;
        [NullAllowed, Export("dateOfBirth")]
        MBDateResult DateOfBirth { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nullable dateOfIssue;
        [NullAllowed, Export("dateOfIssue")]
        MBDateResult DateOfIssue { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nullable dateOfExpiry;
        [NullAllowed, Export("dateOfExpiry")]
        MBDateResult DateOfExpiry { get; }

        // @property (readonly, assign, nonatomic) BOOL donorIndicator;
        [Export("donorIndicator")]
        bool DonorIndicator { get; }

        // @property (readonly, nonatomic) NSString * _Nullable address;
        [NullAllowed, Export("address")]
        string Address { get; }

        // @property (readonly, nonatomic) NSString * _Nullable licenseNumber;
        [NullAllowed, Export("licenseNumber")]
        string LicenseNumber { get; }

        // @property (readonly, nonatomic) NSString * _Nullable cardVersion;
        [NullAllowed, Export("cardVersion")]
        string CardVersion { get; }
    }

    // @interface MBNewZealandDlFrontRecognizer : MBRecognizer <NSCopying, MBFaceImage, MBEncodeFaceImage, MBFaceImageDpi, MBSignatureImage, MBEncodeSignatureImage, MBSignatureImageDpi, MBFullDocumentImage, MBEncodeFullDocumentImage, MBFullDocumentImageDpi, MBGlareDetection, IMBFullDocumentImageExtensionFactors>
    [iOS (8,0)]
    [BaseType(typeof(MBRecognizer))]
    interface MBNewZealandDlFrontRecognizer : INSCopying, IMBFaceImage, IMBEncodeFaceImage, IMBFaceImageDpi, IMBSignatureImage, IMBEncodeSignatureImage, IMBSignatureImageDpi, IMBFullDocumentImage, IMBEncodeFullDocumentImage, IMBFullDocumentImageDpi, IMBGlareDetection, IMBFullDocumentImageExtensionFactors
    {
        // @property (readonly, nonatomic, strong) MBNewZealandDlFrontRecognizerResult * _Nonnull result;
        [Export("result", ArgumentSemantic.Strong)]
        MBNewZealandDlFrontRecognizerResult Result { get; }

        // @property (assign, nonatomic) BOOL extractFirstNames;
        [Export("extractFirstNames")]
        bool ExtractFirstNames { get; set; }

        // @property (assign, nonatomic) BOOL extractSurname;
        [Export("extractSurname")]
        bool ExtractSurname { get; set; }

        // @property (assign, nonatomic) BOOL extractDateOfBirth;
        [Export("extractDateOfBirth")]
        bool ExtractDateOfBirth { get; set; }

        // @property (assign, nonatomic) BOOL extractDateOfIssue;
        [Export("extractDateOfIssue")]
        bool ExtractDateOfIssue { get; set; }

        // @property (assign, nonatomic) BOOL extractDateOfExpiry;
        [Export("extractDateOfExpiry")]
        bool ExtractDateOfExpiry { get; set; }

        // @property (assign, nonatomic) BOOL extractDonorIndicator;
        [Export("extractDonorIndicator")]
        bool ExtractDonorIndicator { get; set; }

        // @property (assign, nonatomic) BOOL extractAddress;
        [Export("extractAddress")]
        bool ExtractAddress { get; set; }
    }

   // @interface MBBlinkCardRecognizerResult : MBRecognizerResult <NSCopying, MBCombinedRecognizerResult, MBDigitalSignatureResult, MBCombinedFullDocumentImageResult, MBEncodedCombinedFullDocumentImageResult>
	[iOS (8,0)]
	[BaseType (typeof(MBRecognizerResult))]
	[DisableDefaultCtor]
	interface MBBlinkCardRecognizerResult : INSCopying, MBCombinedRecognizerResult, IMBDigitalSignatureResult, IMBCombinedFullDocumentImageResult, IMBEncodedCombinedFullDocumentImageResult
	{
		// @property (readonly, nonatomic) NSString * _Nonnull cardNumber;
		[Export ("cardNumber")]
		string CardNumber { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull owner;
		[Export ("owner")]
		string Owner { get; }

		// @property (readonly, nonatomic) MBDateResult * _Nonnull validThru;
		[Export ("validThru")]
		MBDateResult ValidThru { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull cvv;
		[Export ("cvv")]
		string Cvv { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull inventoryNumber;
		[Export ("inventoryNumber")]
		string InventoryNumber { get; }

		// @property (readonly, nonatomic) MBCardIssuer issuer;
		[Export ("issuer")]
		MBCardIssuer Issuer { get; }
	}

	// @interface MBBlinkCardRecognizer : MBRecognizer <NSCopying, MBCombinedRecognizer, MBFullDocumentImage, MBEncodeFullDocumentImage, MBFullDocumentImageDpi, MBGlareDetection, MBDigitalSignature, MBFullDocumentImageExtensionFactors>
	[iOS (8,0)]
	[BaseType (typeof(MBRecognizer))]
	interface MBBlinkCardRecognizer : INSCopying, IMBCombinedRecognizer, IMBFullDocumentImage, IMBEncodeFullDocumentImage, IMBFullDocumentImageDpi, IMBGlareDetection, IMBDigitalSignature, IMBFullDocumentImageExtensionFactors
	{
		// @property (readonly, nonatomic, strong) MBBlinkCardRecognizerResult * _Nonnull result;
		[Export ("result", ArgumentSemantic.Strong)]
		MBBlinkCardRecognizerResult Result { get; }

		// @property (assign, nonatomic) BOOL extractOwner;
		[Export ("extractOwner")]
		bool ExtractOwner { get; set; }

		// @property (assign, nonatomic) BOOL extractValidThru;
		[Export ("extractValidThru")]
		bool ExtractValidThru { get; set; }

		// @property (assign, nonatomic) BOOL extractCvv;
		[Export ("extractCvv")]
		bool ExtractCvv { get; set; }

		// @property (assign, nonatomic) BOOL extractInventoryNumber;
		[Export ("extractInventoryNumber")]
		bool ExtractInventoryNumber { get; set; }

		// @property (assign, nonatomic) BOOL anonymizeCardNumber;
		[Export ("anonymizeCardNumber")]
		bool AnonymizeCardNumber { get; set; }

		// @property (assign, nonatomic) BOOL anonymizeOwner;
		[Export ("anonymizeOwner")]
		bool AnonymizeOwner { get; set; }

		// @property (assign, nonatomic) BOOL anonymizeCvv;
		[Export ("anonymizeCvv")]
		bool AnonymizeCvv { get; set; }
	}

    
	// @interface MBBlinkCardEliteRecognizerResult : MBRecognizerResult <NSCopying, MBCombinedRecognizerResult, MBDigitalSignatureResult, MBCombinedFullDocumentImageResult, MBEncodedCombinedFullDocumentImageResult>
	[iOS (8,0)]
	[BaseType (typeof(MBRecognizerResult))]
	[DisableDefaultCtor]
	interface MBBlinkCardEliteRecognizerResult : INSCopying, MBCombinedRecognizerResult, IMBDigitalSignatureResult, IMBCombinedFullDocumentImageResult, IMBEncodedCombinedFullDocumentImageResult
	{
		// @property (readonly, nonatomic) NSString * _Nonnull cardNumber;
		[Export ("cardNumber")]
		string CardNumber { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull owner;
		[Export ("owner")]
		string Owner { get; }

		// @property (readonly, nonatomic) MBDateResult * _Nonnull validThru;
		[Export ("validThru")]
		MBDateResult ValidThru { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull cvv;
		[Export ("cvv")]
		string Cvv { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull inventoryNumber;
		[Export ("inventoryNumber")]
		string InventoryNumber { get; }
	}

	// @interface MBBlinkCardEliteRecognizer : MBRecognizer <NSCopying, MBCombinedRecognizer, MBFullDocumentImage, MBEncodeFullDocumentImage, MBFullDocumentImageDpi, MBGlareDetection, MBDigitalSignature, MBFullDocumentImageExtensionFactors>
	[iOS (8,0)]
	[BaseType (typeof(MBRecognizer))]
	interface MBBlinkCardEliteRecognizer : INSCopying, IMBCombinedRecognizer, IMBFullDocumentImage, IMBEncodeFullDocumentImage, IMBFullDocumentImageDpi, IMBGlareDetection, IMBDigitalSignature, IMBFullDocumentImageExtensionFactors
	{
		// @property (readonly, nonatomic, strong) MBBlinkCardEliteRecognizerResult * _Nonnull result;
		[Export ("result", ArgumentSemantic.Strong)]
		MBBlinkCardEliteRecognizerResult Result { get; }

		// @property (assign, nonatomic) BOOL extractOwner;
		[Export ("extractOwner")]
		bool ExtractOwner { get; set; }

		// @property (assign, nonatomic) BOOL extractValidThru;
		[Export ("extractValidThru")]
		bool ExtractValidThru { get; set; }

		// @property (assign, nonatomic) BOOL extractInventoryNumber;
		[Export ("extractInventoryNumber")]
		bool ExtractInventoryNumber { get; set; }

		// @property (assign, nonatomic) BOOL anonymizeCardNumber;
		[Export ("anonymizeCardNumber")]
		bool AnonymizeCardNumber { get; set; }

		// @property (assign, nonatomic) BOOL anonymizeOwner;
		[Export ("anonymizeOwner")]
		bool AnonymizeOwner { get; set; }

		// @property (assign, nonatomic) BOOL anonymizeCvv;
		[Export ("anonymizeCvv")]
		bool AnonymizeCvv { get; set; }
	}

    // @interface MBPolandIdBackRecognizerResult : MBRecognizerResult <NSCopying, MBFullDocumentImageResult, MBEncodedFullDocumentImageResult>
	[iOS (8,0)]
	[BaseType (typeof(MBRecognizerResult))]
	[DisableDefaultCtor]
	interface MBPolandIdBackRecognizerResult : INSCopying, IMBFullDocumentImageResult, IMBEncodedFullDocumentImageResult
	{
		// @property (readonly, nonatomic) MBMrzResult * _Nonnull mrzResult;
		[Export ("mrzResult")]
		MBMrzResult MrzResult { get; }
	}

	// @interface MBPolandIdBackRecognizer : MBRecognizer <NSCopying, MBGlareDetection, MBFullDocumentImage, MBEncodeFullDocumentImage, MBFullDocumentImageDpi, MBFullDocumentImageExtensionFactors>
	[iOS (8,0)]
	[BaseType (typeof(MBRecognizer))]
	interface MBPolandIdBackRecognizer : INSCopying, IMBGlareDetection, IMBFullDocumentImage, IMBEncodeFullDocumentImage, IMBFullDocumentImageDpi, IMBFullDocumentImageExtensionFactors
	{
		// @property (readonly, nonatomic, strong) MBPolandIdBackRecognizerResult * _Nonnull result;
		[Export ("result", ArgumentSemantic.Strong)]
		MBPolandIdBackRecognizerResult Result { get; }
	}

	// @interface MBPolandIdFrontRecognizerResult : MBRecognizerResult <NSCopying, MBFaceImageResult, MBEncodedFaceImageResult, MBFullDocumentImageResult, MBEncodedFullDocumentImageResult>
	[iOS (8,0)]
	[BaseType (typeof(MBRecognizerResult))]
	[DisableDefaultCtor]
	interface MBPolandIdFrontRecognizerResult : INSCopying, IMBFaceImageResult, IMBEncodedFaceImageResult, IMBFullDocumentImageResult, IMBEncodedFullDocumentImageResult
	{
		// @property (readonly, nonatomic) MBDateResult * _Nonnull dateOfBirth;
		[Export ("dateOfBirth")]
		MBDateResult DateOfBirth { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull familyName __attribute__((deprecated("")));
		[Export ("familyName")]
		string FamilyName { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull givenNames;
		[Export ("givenNames")]
		string GivenNames { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull parentsGivenNames __attribute__((deprecated("")));
		[Export ("parentsGivenNames")]
		string ParentsGivenNames { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull sex;
		[Export ("sex")]
		string Sex { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull surname;
		[Export ("surname")]
		string Surname { get; }
	}

	// @interface MBPolandIdFrontRecognizer : MBRecognizer <NSCopying, MBGlareDetection, MBFaceImage, MBEncodeFaceImage, MBFaceImageDpi, MBFullDocumentImage, MBEncodeFullDocumentImage, MBFullDocumentImageDpi, MBFullDocumentImageExtensionFactors>
	[iOS (8,0)]
	[BaseType (typeof(MBRecognizer))]
	interface MBPolandIdFrontRecognizer : INSCopying, IMBGlareDetection, IMBFaceImage, IMBEncodeFaceImage, IMBFaceImageDpi, IMBFullDocumentImage, IMBEncodeFullDocumentImage, IMBFullDocumentImageDpi, IMBFullDocumentImageExtensionFactors
	{
		// @property (readonly, nonatomic, strong) MBPolandIdFrontRecognizerResult * _Nonnull result;
		[Export ("result", ArgumentSemantic.Strong)]
		MBPolandIdFrontRecognizerResult Result { get; }

		// @property (assign, nonatomic) BOOL extractDateOfBirth;
		[Export ("extractDateOfBirth")]
		bool ExtractDateOfBirth { get; set; }

		// @property (assign, nonatomic) BOOL extractFamilyName;
		[Export ("extractFamilyName")]
		bool ExtractFamilyName { get; set; }

		// @property (assign, nonatomic) BOOL extractGivenNames;
		[Export ("extractGivenNames")]
		bool ExtractGivenNames { get; set; }

		// @property (assign, nonatomic) BOOL extractParentsGivenNames;
		[Export ("extractParentsGivenNames")]
		bool ExtractParentsGivenNames { get; set; }

		// @property (assign, nonatomic) BOOL extractSex;
		[Export ("extractSex")]
		bool ExtractSex { get; set; }

		// @property (assign, nonatomic) BOOL extractSurname;
		[Export ("extractSurname")]
		bool ExtractSurname { get; set; }
	}

    // @interface MBPolandCombinedRecognizerResult : MBLegacyRecognizerResult <NSCopying, MBCombinedRecognizerResult, MBFaceImageResult, MBCombinedFullDocumentImageResult, MBDigitalSignatureResult, MBEncodedFaceImageResult, MBEncodedCombinedFullDocumentImageResult>
    
    [BaseType(typeof(MBLegacyRecognizerResult))]
    [DisableDefaultCtor]
    interface MBPolandCombinedRecognizerResult : INSCopying, MBCombinedRecognizerResult, IMBFaceImageResult, IMBCombinedFullDocumentImageResult, IMBDigitalSignatureResult, IMBEncodedFaceImageResult, IMBEncodedCombinedFullDocumentImageResult
    {
        // @property (readonly, nonatomic) NSString * _Nullable givenNames;
        [NullAllowed, Export("givenNames")]
        string GivenNames { get; }

        // @property (readonly, nonatomic) NSString * _Nullable surname;
        [NullAllowed, Export("surname")]
        string Surname { get; }

        // @property (readonly, nonatomic) NSString * _Nullable familyName;
        [NullAllowed, Export("familyName")]
        string FamilyName { get; }

        // @property (readonly, nonatomic) NSString * _Nullable parentsGivenNames;
        [NullAllowed, Export("parentsGivenNames")]
        string ParentsGivenNames { get; }

        // @property (readonly, nonatomic) NSString * _Nullable sex;
        [NullAllowed, Export("sex")]
        string Sex { get; }

        // @property (readonly, nonatomic) NSString * _Nullable nationality;
        [NullAllowed, Export("nationality")]
        string Nationality { get; }

        // @property (readonly, nonatomic) NSString * _Nullable issuer;
        [NullAllowed, Export("issuer")]
        string Issuer { get; }

        // @property (readonly, nonatomic) NSString * _Nullable documentNumber;
        [NullAllowed, Export("documentNumber")]
        string DocumentNumber { get; }

        // @property (readonly, nonatomic) NSString * _Nullable personalNumber;
        [NullAllowed, Export("personalNumber")]
        string PersonalNumber { get; }

        // @property (readonly, nonatomic) NSDate * _Nullable dateOfBirth;
        [NullAllowed, Export("dateOfBirth")]
        NSDate DateOfBirth { get; }

        // @property (readonly, nonatomic) NSDate * _Nullable dateOfExpiry;
        [NullAllowed, Export("dateOfExpiry")]
        NSDate DateOfExpiry { get; }

        // @property (readonly, nonatomic) BOOL mrzVerified;
        [Export("mrzVerified")]
        bool MrzVerified { get; }
    }

    // @interface MBPolandCombinedRecognizer : MBLegacyRecognizer <NSCopying, MBCombinedRecognizer, MBGlareDetection, MBFullDocumentImage, MBFaceImage, MBEncodeFaceImage, MBEncodeFullDocumentImage, MBDigitalSignature>
    
    [BaseType(typeof(MBLegacyRecognizer))]
    interface MBPolandCombinedRecognizer : INSCopying, IMBCombinedRecognizer, IMBGlareDetection, IMBFullDocumentImage, IMBFaceImage, IMBEncodeFaceImage, IMBEncodeFullDocumentImage, IMBDigitalSignature
    {
        // @property (readonly, nonatomic, strong) MBPolandCombinedRecognizerResult * result;
        [Export("result", ArgumentSemantic.Strong)]
        MBPolandCombinedRecognizerResult Result { get; }

        // @property (assign, nonatomic) BOOL extractSex;
        [Export("extractSex")]
        bool ExtractSex { get; set; }

        // @property (assign, nonatomic) BOOL extractSurname;
        [Export("extractSurname")]
        bool ExtractSurname { get; set; }

        // @property (assign, nonatomic) BOOL extractGivenNames;
        [Export("extractGivenNames")]
        bool ExtractGivenNames { get; set; }

        // @property (assign, nonatomic) BOOL extractFamilyName;
        [Export("extractFamilyName")]
        bool ExtractFamilyName { get; set; }

        // @property (assign, nonatomic) BOOL extractParentsGivenNames;
        [Export("extractParentsGivenNames")]
        bool ExtractParentsGivenNames { get; set; }

        // @property (assign, nonatomic) BOOL extractDateOfBirth;
        [Export("extractDateOfBirth")]
        bool ExtractDateOfBirth { get; set; }
    }

    // @interface MBRomaniaIdFrontRecognizerResult : MBLegacyMRTDRecognizerResult <NSCopying, MBFaceImageResult, MBFullDocumentImageResult>
    
    [BaseType(typeof(MBLegacyMRTDRecognizerResult))]
    [DisableDefaultCtor]
    interface MBRomaniaIdFrontRecognizerResult : INSCopying, IMBFaceImageResult, IMBFullDocumentImageResult
    {
        // @property (readonly, nonatomic, strong) NSString * _Nullable lastName;
        [NullAllowed, Export("lastName", ArgumentSemantic.Strong)]
        string LastName { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nullable firstName;
        [NullAllowed, Export("firstName", ArgumentSemantic.Strong)]
        string FirstName { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nullable cardNumber;
        [NullAllowed, Export("cardNumber", ArgumentSemantic.Strong)]
        string CardNumber { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nullable idSeries;
        [NullAllowed, Export("idSeries", ArgumentSemantic.Strong)]
        string IdSeries { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nullable cnp;
        [NullAllowed, Export("cnp", ArgumentSemantic.Strong)]
        string Cnp { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nullable parentNames;
        [NullAllowed, Export("parentNames", ArgumentSemantic.Strong)]
        string ParentNames { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nullable nonMRZNationality;
        [NullAllowed, Export("nonMRZNationality", ArgumentSemantic.Strong)]
        string NonMRZNationality { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nullable placeOfBirth;
        [NullAllowed, Export("placeOfBirth", ArgumentSemantic.Strong)]
        string PlaceOfBirth { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nullable address;
        [NullAllowed, Export("address", ArgumentSemantic.Strong)]
        string Address { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nullable issuedBy;
        [NullAllowed, Export("issuedBy", ArgumentSemantic.Strong)]
        string IssuedBy { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nullable nonMRZSex;
        [NullAllowed, Export("nonMRZSex", ArgumentSemantic.Strong)]
        string NonMRZSex { get; }

        // @property (readonly, nonatomic, strong) NSDate * _Nullable validFrom;
        [NullAllowed, Export("validFrom", ArgumentSemantic.Strong)]
        NSDate ValidFrom { get; }

        // @property (readonly, nonatomic) NSString * _Nullable rawValidFrom;
        [NullAllowed, Export("rawValidFrom")]
        string RawValidFrom { get; }

        // @property (readonly, nonatomic, strong) NSDate * _Nullable validUntil;
        [NullAllowed, Export("validUntil", ArgumentSemantic.Strong)]
        NSDate ValidUntil { get; }

        // @property (readonly, nonatomic) NSString * _Nullable rawValidUntil;
        [NullAllowed, Export("rawValidUntil")]
        string RawValidUntil { get; }
    }

    // @interface MBRomaniaIdFrontRecognizer : MBLegacyRecognizer <NSCopying, MBFaceImage, MBFullDocumentImage, MBGlareDetection>
    
    [BaseType(typeof(MBLegacyRecognizer))]
    interface MBRomaniaIdFrontRecognizer : INSCopying, IMBFaceImage, IMBFullDocumentImage, IMBGlareDetection
    {
        // @property (readonly, nonatomic, strong) MBRomaniaIdFrontRecognizerResult * _Nonnull result;
        [Export("result", ArgumentSemantic.Strong)]
        MBRomaniaIdFrontRecognizerResult Result { get; }

        // @property (assign, nonatomic) BOOL extractFirstName;
        [Export("extractFirstName")]
        bool ExtractFirstName { get; set; }

        // @property (assign, nonatomic) BOOL extractLastName;
        [Export("extractLastName")]
        bool ExtractLastName { get; set; }

        // @property (assign, nonatomic) BOOL extractPlaceOfBirth;
        [Export("extractPlaceOfBirth")]
        bool ExtractPlaceOfBirth { get; set; }

        // @property (assign, nonatomic) BOOL extractAddress;
        [Export("extractAddress")]
        bool ExtractAddress { get; set; }

        // @property (assign, nonatomic) BOOL extractIssuedBy;
        [Export("extractIssuedBy")]
        bool ExtractIssuedBy { get; set; }

        // @property (assign, nonatomic) BOOL extractValidFrom;
        [Export("extractValidFrom")]
        bool ExtractValidFrom { get; set; }

        // @property (assign, nonatomic) BOOL extractValidUntil;
        [Export("extractValidUntil")]
        bool ExtractValidUntil { get; set; }

        // @property (assign, nonatomic) BOOL extractNonMRZSex;
        [Export("extractNonMRZSex")]
        bool ExtractNonMRZSex { get; set; }
    }

    // @interface MBSerbiaIdBackRecognizerResult : MBLegacyMRTDRecognizerResult <NSCopying, MBFullDocumentImageResult>
    [Introduced (PlatformName.iOS, 1, 0, 0, message: "Recognizer is deprecated")]
    [Deprecated (PlatformName.iOS, 4, 6, 0, message: "Recognizer is deprecated")]
    [BaseType (typeof(MBLegacyMRTDRecognizerResult))]
    [DisableDefaultCtor]
    interface MBSerbiaIdBackRecognizerResult : INSCopying, IMBFullDocumentImageResult
    {
    }

    // @interface MBSerbiaIdBackRecognizer : MBLegacyRecognizer <NSCopying, MBFullDocumentImage, MBGlareDetection>
    [Introduced (PlatformName.iOS, 1, 0, 0, message: "Recognizer is deprecated")]
    [Deprecated (PlatformName.iOS, 4, 6, 0, message: "Recognizer is deprecated")]
    [BaseType (typeof(MBLegacyRecognizer))]
    interface MBSerbiaIdBackRecognizer : INSCopying, IMBFullDocumentImage, IMBGlareDetection
    {
        // @property (readonly, nonatomic, strong) MBSerbiaIdBackRecognizerResult * _Nonnull result;
        [Export ("result", ArgumentSemantic.Strong)]
        MBSerbiaIdBackRecognizerResult Result { get; }
    }

    // @interface MBSerbiaIdFrontRecognizerResult : MBLegacyRecognizerResult <NSCopying, MBFaceImageResult, MBSignatureImageResult, MBFullDocumentImageResult>
    [Introduced (PlatformName.iOS, 1, 0, 0, message: "Recognizer is deprecated")]
    [Deprecated (PlatformName.iOS, 4, 6, 0, message: "Recognizer is deprecated")]
    [BaseType (typeof(MBLegacyRecognizerResult))]
    [DisableDefaultCtor]
    interface MBSerbiaIdFrontRecognizerResult : INSCopying, IMBFaceImageResult, IMBSignatureImageResult, IMBFullDocumentImageResult
    {
        // @property (readonly, nonatomic) NSDate * _Nullable issuingDate;
        [NullAllowed, Export ("issuingDate")]
        NSDate IssuingDate { get; }

        // @property (readonly, nonatomic) NSDate * _Nullable validUntil;
        [NullAllowed, Export ("validUntil")]
        NSDate ValidUntil { get; }

        // @property (readonly, nonatomic) NSString * _Nullable documentNumber;
        [NullAllowed, Export ("documentNumber")]
        string DocumentNumber { get; }
    }

    // @interface MBSerbiaIdFrontRecognizer : MBLegacyRecognizer <NSCopying, MBFaceImage, MBSignatureImage, MBFullDocumentImage, MBGlareDetection>
    [Introduced (PlatformName.iOS, 1, 0, 0, message: "Recognizer is deprecated")]
    [Deprecated (PlatformName.iOS, 4, 6, 0, message: "Recognizer is deprecated")]
    [BaseType (typeof(MBLegacyRecognizer))]
    interface MBSerbiaIdFrontRecognizer : INSCopying, IMBFaceImage, IMBSignatureImage, IMBFullDocumentImage, IMBGlareDetection
    {
        // @property (readonly, nonatomic, strong) MBSerbiaIdFrontRecognizerResult * _Nonnull result;
        [Export ("result", ArgumentSemantic.Strong)]
        MBSerbiaIdFrontRecognizerResult Result { get; }

        // @property (nonatomic) BOOL extractIssuingDate;
        [Export ("extractIssuingDate")]
        bool ExtractIssuingDate { get; set; }

        // @property (nonatomic) BOOL extractValidUntil;
        [Export ("extractValidUntil")]
        bool ExtractValidUntil { get; set; }
    }

    // @interface MBSerbiaCombinedRecognizerResult : MBLegacyRecognizerResult <NSCopying, MBCombinedRecognizerResult, MBFaceImageResult, MBCombinedFullDocumentImageResult, MBSignatureImageResult, MBDigitalSignatureResult, MBEncodedFaceImageResult, MBEncodedSignatureImageResult, MBEncodedCombinedFullDocumentImageResult>
    [Introduced (PlatformName.iOS, 1, 0, 0, message: "Recognizer is deprecated")]
    [Deprecated (PlatformName.iOS, 4, 6, 0, message: "Recognizer is deprecated")]
    [BaseType (typeof(MBLegacyRecognizerResult))]
    [DisableDefaultCtor]
    interface MBSerbiaCombinedRecognizerResult : INSCopying, MBCombinedRecognizerResult, IMBFaceImageResult, IMBCombinedFullDocumentImageResult, IMBSignatureImageResult, IMBDigitalSignatureResult, IMBEncodedFaceImageResult, IMBEncodedSignatureImageResult, IMBEncodedCombinedFullDocumentImageResult
    {
        // @property (readonly, nonatomic) NSString * _Nullable identityCardNumber;
        [NullAllowed, Export ("identityCardNumber")]
        string IdentityCardNumber { get; }

        // @property (readonly, nonatomic) NSDate * _Nullable dateOfExpiry;
        [NullAllowed, Export ("dateOfExpiry")]
        NSDate DateOfExpiry { get; }

        // @property (readonly, nonatomic) NSDate * _Nullable dateOfIssue;
        [NullAllowed, Export ("dateOfIssue")]
        NSDate DateOfIssue { get; }

        // @property (readonly, nonatomic) NSString * _Nullable jmbg;
        [NullAllowed, Export ("jmbg")]
        string Jmbg { get; }

        // @property (readonly, nonatomic) NSString * _Nullable firstName;
        [NullAllowed, Export ("firstName")]
        string FirstName { get; }

        // @property (readonly, nonatomic) NSString * _Nullable lastName;
        [NullAllowed, Export ("lastName")]
        string LastName { get; }

        // @property (readonly, nonatomic) NSDate * _Nullable dateOfBirth;
        [NullAllowed, Export ("dateOfBirth")]
        NSDate DateOfBirth { get; }

        // @property (readonly, nonatomic) NSString * _Nullable nationality;
        [NullAllowed, Export ("nationality")]
        string Nationality { get; }

        // @property (readonly, nonatomic) NSString * _Nullable issuer;
        [NullAllowed, Export ("issuer")]
        string Issuer { get; }

        // @property (readonly, nonatomic) NSString * _Nullable sex;
        [NullAllowed, Export ("sex")]
        string Sex { get; }

        // @property (readonly, nonatomic) BOOL mrzVerified;
        [Export ("mrzVerified")]
        bool MrzVerified { get; }
    }

    // @interface MBSerbiaCombinedRecognizer : MBLegacyRecognizer <NSCopying, MBCombinedRecognizer, MBGlareDetection, MBFullDocumentImage, MBSignatureImage, MBFaceImage, MBEncodeFaceImage, MBEncodeFullDocumentImage, MBEncodeSignatureImage, MBDigitalSignature>
    [Introduced (PlatformName.iOS, 1, 0, 0, message: "Recognizer is deprecated")]
    [Deprecated (PlatformName.iOS, 4, 6, 0, message: "Recognizer is deprecated")]
    [BaseType (typeof(MBLegacyRecognizer))]
    interface MBSerbiaCombinedRecognizer : INSCopying, IMBCombinedRecognizer, IMBGlareDetection, IMBFullDocumentImage, IMBSignatureImage, IMBFaceImage, IMBEncodeFaceImage, IMBEncodeFullDocumentImage, IMBEncodeSignatureImage, IMBDigitalSignature
    {
        // @property (readonly, nonatomic, strong) MBSerbiaCombinedRecognizerResult * _Nonnull result;
        [Export ("result", ArgumentSemantic.Strong)]
        MBSerbiaCombinedRecognizerResult Result { get; }
    }

  // @interface MBSingaporeIdBackRecognizerResult : MBRecognizerResult <NSCopying, MBFullDocumentImageResult, MBEncodedFullDocumentImageResult>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBSingaporeIdBackRecognizerResult : INSCopying, IMBFullDocumentImageResult, IMBEncodedFullDocumentImageResult
    {
        // @property (readonly, nonatomic) NSString * _Nonnull address;
        [Export ("address")]
        string Address { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nonnull addressChangeDate;
        [Export ("addressChangeDate")]
        MBDateResult AddressChangeDate { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull bloodGroup;
        [Export ("bloodGroup")]
        string BloodGroup { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull cardNumber;
        [Export ("cardNumber")]
        string CardNumber { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nonnull dateOfIssue;
        [Export ("dateOfIssue")]
        MBDateResult DateOfIssue { get; }
    }

    // @interface MBSingaporeIdBackRecognizer : MBRecognizer <NSCopying, MBFullDocumentImage, MBEncodeFullDocumentImage, MBFullDocumentImageDpi, MBGlareDetection, MBFullDocumentImageExtensionFactors>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizer))]
    interface MBSingaporeIdBackRecognizer : INSCopying, IMBFullDocumentImage, IMBEncodeFullDocumentImage, IMBFullDocumentImageDpi, IMBGlareDetection, IMBFullDocumentImageExtensionFactors
    {
        // @property (readonly, nonatomic, strong) MBSingaporeIdBackRecognizerResult * _Nonnull result;
        [Export ("result", ArgumentSemantic.Strong)]
        MBSingaporeIdBackRecognizerResult Result { get; }

        // @property (assign, nonatomic) BOOL extractAddress;
        [Export ("extractAddress")]
        bool ExtractAddress { get; set; }

        // @property (assign, nonatomic) BOOL extractAddressChangeDate;
        [Export ("extractAddressChangeDate")]
        bool ExtractAddressChangeDate { get; set; }

        // @property (assign, nonatomic) BOOL extractBloodGroup;
        [Export ("extractBloodGroup")]
        bool ExtractBloodGroup { get; set; }

        // @property (assign, nonatomic) BOOL extractDateOfIssue;
        [Export ("extractDateOfIssue")]
        bool ExtractDateOfIssue { get; set; }
    }

    // @interface MBSingaporeIdFrontRecognizerResult : MBRecognizerResult <NSCopying, MBFullDocumentImageResult, MBEncodedFullDocumentImageResult, MBFaceImageResult, MBEncodedFaceImageResult>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBSingaporeIdFrontRecognizerResult : INSCopying, IMBFullDocumentImageResult, IMBEncodedFullDocumentImageResult, IMBFaceImageResult, IMBEncodedFaceImageResult
    {
        // @property (readonly, nonatomic) NSString * _Nullable identityCardNumber;
        [NullAllowed, Export ("identityCardNumber")]
        string IdentityCardNumber { get; }

        // @property (readonly, nonatomic) NSString * _Nullable name;
        [NullAllowed, Export ("name")]
        string Name { get; }

        // @property (readonly, nonatomic) NSString * _Nullable race;
        [NullAllowed, Export ("race")]
        string Race { get; }

        // @property (readonly, nonatomic) NSString * _Nullable sex;
        [NullAllowed, Export ("sex")]
        string Sex { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nullable dateOfBirth;
        [NullAllowed, Export ("dateOfBirth")]
        MBDateResult DateOfBirth { get; }

        // @property (readonly, nonatomic) NSString * _Nullable countryOfBirth;
        [NullAllowed, Export ("countryOfBirth")]
        string CountryOfBirth { get; }
    }

    // @interface MBSingaporeIdFrontRecognizer : MBRecognizer <NSCopying, MBFullDocumentImage, MBEncodeFullDocumentImage, MBFullDocumentImageDpi, MBFaceImage, MBEncodeFaceImage, MBFaceImageDpi, MBGlareDetection, MBFullDocumentImageExtensionFactors>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizer))]
    interface MBSingaporeIdFrontRecognizer : INSCopying, IMBFullDocumentImage, IMBEncodeFullDocumentImage, IMBFullDocumentImageDpi, IMBFaceImage, IMBEncodeFaceImage, IMBFaceImageDpi, IMBGlareDetection, IMBFullDocumentImageExtensionFactors
    {
        // @property (readonly, nonatomic, strong) MBSingaporeIdFrontRecognizerResult * _Nonnull result;
        [Export ("result", ArgumentSemantic.Strong)]
        MBSingaporeIdFrontRecognizerResult Result { get; }

        // @property (nonatomic) BOOL extractName;
        [Export ("extractName")]
        bool ExtractName { get; set; }

        // @property (nonatomic) BOOL extractRace;
        [Export ("extractRace")]
        bool ExtractRace { get; set; }

        // @property (nonatomic) BOOL extractDateOfBirth;
        [Export ("extractDateOfBirth")]
        bool ExtractDateOfBirth { get; set; }

        // @property (nonatomic) BOOL extractSex;
        [Export ("extractSex")]
        bool ExtractSex { get; set; }

        // @property (nonatomic) BOOL extractCountryOfBirth;
        [Export ("extractCountryOfBirth")]
        bool ExtractCountryOfBirth { get; set; }
    }

    // @interface MBSingaporeCombinedRecognizerResult : MBRecognizerResult <NSCopying, MBCombinedRecognizerResult, MBDigitalSignatureResult, MBCombinedFullDocumentImageResult, MBEncodedCombinedFullDocumentImageResult, MBFaceImageResult, MBEncodedFaceImageResult>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBSingaporeCombinedRecognizerResult : INSCopying, MBCombinedRecognizerResult, IMBDigitalSignatureResult, IMBCombinedFullDocumentImageResult, IMBEncodedCombinedFullDocumentImageResult, IMBFaceImageResult, IMBEncodedFaceImageResult
    {
        // @property (readonly, nonatomic) NSString * _Nullable identityCardNumber;
        [NullAllowed, Export ("identityCardNumber")]
        string IdentityCardNumber { get; }

        // @property (readonly, nonatomic) NSString * _Nullable name;
        [NullAllowed, Export ("name")]
        string Name { get; }

        // @property (readonly, nonatomic) NSString * _Nullable race;
        [NullAllowed, Export ("race")]
        string Race { get; }

        // @property (readonly, nonatomic) NSString * _Nullable sex;
        [NullAllowed, Export ("sex")]
        string Sex { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nullable dateOfBirth;
        [NullAllowed, Export ("dateOfBirth")]
        MBDateResult DateOfBirth { get; }

        // @property (readonly, nonatomic) NSString * _Nullable countryOfBirth;
        [NullAllowed, Export ("countryOfBirth")]
        string CountryOfBirth { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull address;
        [Export ("address")]
        string Address { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nonnull addressChangeDate;
        [Export ("addressChangeDate")]
        MBDateResult AddressChangeDate { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull bloodGroup;
        [Export ("bloodGroup")]
        string BloodGroup { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nonnull dateOfIssue;
        [Export ("dateOfIssue")]
        MBDateResult DateOfIssue { get; }
    }

    // @interface MBSingaporeCombinedRecognizer : MBRecognizer <NSCopying, MBCombinedRecognizer, MBFullDocumentImage, MBEncodeFullDocumentImage, MBFullDocumentImageDpi, MBFaceImage, MBEncodeFaceImage, MBFaceImageDpi, MBGlareDetection, MBDigitalSignature, MBFullDocumentImageExtensionFactors>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizer))]
    interface MBSingaporeCombinedRecognizer : INSCopying, IMBCombinedRecognizer, IMBFullDocumentImage, IMBEncodeFullDocumentImage, IMBFullDocumentImageDpi, IMBFaceImage, IMBEncodeFaceImage, IMBFaceImageDpi, IMBGlareDetection, IMBDigitalSignature, IMBFullDocumentImageExtensionFactors
    {
        // @property (readonly, nonatomic, strong) MBSingaporeCombinedRecognizerResult * result;
        [Export ("result", ArgumentSemantic.Strong)]
        MBSingaporeCombinedRecognizerResult Result { get; }

        // @property (nonatomic) BOOL extractName;
        [Export ("extractName")]
        bool ExtractName { get; set; }

        // @property (nonatomic) BOOL extractRace;
        [Export ("extractRace")]
        bool ExtractRace { get; set; }

        // @property (nonatomic) BOOL extractDateOfBirth;
        [Export ("extractDateOfBirth")]
        bool ExtractDateOfBirth { get; set; }

        // @property (nonatomic) BOOL extractSex;
        [Export ("extractSex")]
        bool ExtractSex { get; set; }

        // @property (nonatomic) BOOL extractCountryOfBirth;
        [Export ("extractCountryOfBirth")]
        bool ExtractCountryOfBirth { get; set; }

        // @property (assign, nonatomic) BOOL extractAddress;
        [Export ("extractAddress")]
        bool ExtractAddress { get; set; }

        // @property (assign, nonatomic) BOOL extractAddressChangeDate;
        [Export ("extractAddressChangeDate")]
        bool ExtractAddressChangeDate { get; set; }

        // @property (assign, nonatomic) BOOL extractBloodGroup;
        [Export ("extractBloodGroup")]
        bool ExtractBloodGroup { get; set; }

        // @property (assign, nonatomic) BOOL extractDateOfIssue;
        [Export ("extractDateOfIssue")]
        bool ExtractDateOfIssue { get; set; }
    }

    // @interface MBSingaporeDlFrontRecognizerResult : MBRecognizerResult <NSCopying, MBFaceImageResult, MBEncodedFaceImageResult, MBFullDocumentImageResult, MBEncodedFullDocumentImageResult>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBSingaporeDlFrontRecognizerResult : INSCopying, IMBFaceImageResult, IMBEncodedFaceImageResult, IMBFullDocumentImageResult, IMBEncodedFullDocumentImageResult
    {
        // @property (readonly, nonatomic) MBDateResult * _Nonnull birthDate;
        [Export ("birthDate")]
        MBDateResult BirthDate { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nonnull issueDate;
        [Export ("issueDate")]
        MBDateResult IssueDate { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull licenceNumber;
        [Export ("licenceNumber")]
        string LicenceNumber { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull name;
        [Export ("name")]
        string Name { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nonnull validTill;
        [Export ("validTill")]
        MBDateResult ValidTill { get; }
    }

    // @interface MBSingaporeDlFrontRecognizer : MBRecognizer <NSCopying, MBFaceImage, MBEncodeFaceImage, MBFaceImageDpi, MBFullDocumentImage, MBEncodeFullDocumentImage, MBFullDocumentImageDpi, MBGlareDetection, MBFullDocumentImageExtensionFactors>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizer))]
    interface MBSingaporeDlFrontRecognizer : INSCopying, IMBFaceImage, IMBEncodeFaceImage, IMBFaceImageDpi, IMBFullDocumentImage, IMBEncodeFullDocumentImage, IMBFullDocumentImageDpi, IMBGlareDetection, IMBFullDocumentImageExtensionFactors
    {
        // @property (readonly, nonatomic, strong) MBSingaporeDlFrontRecognizerResult * _Nonnull result;
        [Export ("result", ArgumentSemantic.Strong)]
        MBSingaporeDlFrontRecognizerResult Result { get; }

        // @property (assign, nonatomic) BOOL extractBirthDate;
        [Export ("extractBirthDate")]
        bool ExtractBirthDate { get; set; }

        // @property (assign, nonatomic) BOOL extractIssueDate;
        [Export ("extractIssueDate")]
        bool ExtractIssueDate { get; set; }

        // @property (assign, nonatomic) BOOL extractName;
        [Export ("extractName")]
        bool ExtractName { get; set; }

        // @property (assign, nonatomic) BOOL extractValidTill;
        [Export ("extractValidTill")]
        bool ExtractValidTill { get; set; }
    }

    // @interface MBSingaporeChangiEmployeeIdRecognizerResult : MBRecognizerResult <NSCopying, MBFaceImageResult, MBEncodedFaceImageResult, MBFullDocumentImageResult, MBEncodedFullDocumentImageResult>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBSingaporeChangiEmployeeIdRecognizerResult : INSCopying, IMBFaceImageResult, IMBEncodedFaceImageResult, IMBFullDocumentImageResult, IMBEncodedFullDocumentImageResult
    {
        // @property (readonly, nonatomic) MBDateResult * _Nonnull dateOfExpiry;
        [Export ("dateOfExpiry")]
        MBDateResult DateOfExpiry { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull documentNumber;
        [Export ("documentNumber")]
        string DocumentNumber { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull name;
        [Export ("name")]
        string Name { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull companyName;
        [Export ("companyName")]
        string CompanyName { get; }
    }

    // @interface MBSingaporeChangiEmployeeIdRecognizer : MBRecognizer <NSCopying, MBFaceImage, MBEncodeFaceImage, MBFaceImageDpi, MBFullDocumentImage, MBEncodeFullDocumentImage, MBFullDocumentImageDpi, MBGlareDetection, MBFullDocumentImageExtensionFactors>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizer))]
    interface MBSingaporeChangiEmployeeIdRecognizer : INSCopying, IMBFaceImage, IMBEncodeFaceImage, IMBFaceImageDpi, IMBFullDocumentImage, IMBEncodeFullDocumentImage, IMBFullDocumentImageDpi, IMBGlareDetection, IMBFullDocumentImageExtensionFactors
    {
        // @property (readonly, nonatomic, strong) MBSingaporeChangiEmployeeIdRecognizerResult * _Nonnull result;
        [Export ("result", ArgumentSemantic.Strong)]
        MBSingaporeChangiEmployeeIdRecognizerResult Result { get; }

        // @property (assign, nonatomic) BOOL extractName;
        [Export ("extractName")]
        bool ExtractName { get; set; }

        // @property (assign, nonatomic) BOOL extractCompanyName;
        [Export ("extractCompanyName")]
        bool ExtractCompanyName { get; set; }

        // @property (assign, nonatomic) BOOL extractDateOfExpiry;
        [Export ("extractDateOfExpiry")]
        bool ExtractDateOfExpiry { get; set; }
    }

   // @interface MBSlovakiaIdBackRecognizerResult : MBRecognizerResult <NSCopying, MBFullDocumentImageResult, MBEncodedFullDocumentImageResult>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBSlovakiaIdBackRecognizerResult : INSCopying, IMBFullDocumentImageResult, IMBEncodedFullDocumentImageResult
    {
        // @property (readonly, nonatomic) NSString * _Nonnull address;
        [Export ("address")]
        string Address { get; }

        // @property (readonly, nonatomic) MBMrzResult * _Nonnull mrzResult;
        [Export ("mrzResult")]
        MBMrzResult MrzResult { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull placeOfBirth;
        [Export ("placeOfBirth")]
        string PlaceOfBirth { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull specialRemarks __attribute__((deprecated("")));
        [Export ("specialRemarks")]
        string SpecialRemarks { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull surnameAtBirth __attribute__((deprecated("")));
        [Export ("surnameAtBirth")]
        string SurnameAtBirth { get; }
    }

    // @interface MBSlovakiaIdBackRecognizer : MBRecognizer <NSCopying, MBGlareDetection, MBFullDocumentImage, MBEncodeFullDocumentImage, MBFullDocumentImageDpi, MBFullDocumentImageExtensionFactors>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizer))]
    interface MBSlovakiaIdBackRecognizer : INSCopying, IMBGlareDetection, IMBFullDocumentImage, IMBEncodeFullDocumentImage, IMBFullDocumentImageDpi, IMBFullDocumentImageExtensionFactors
    {
        // @property (readonly, nonatomic, strong) MBSlovakiaIdBackRecognizerResult * _Nonnull result;
        [Export ("result", ArgumentSemantic.Strong)]
        MBSlovakiaIdBackRecognizerResult Result { get; }

        // @property (assign, nonatomic) BOOL extractAddress;
        [Export ("extractAddress")]
        bool ExtractAddress { get; set; }

        // @property (assign, nonatomic) BOOL extractPlaceOfBirth;
        [Export ("extractPlaceOfBirth")]
        bool ExtractPlaceOfBirth { get; set; }

        // @property (assign, nonatomic) BOOL extractSpecialRemarks;
        [Export ("extractSpecialRemarks")]
        bool ExtractSpecialRemarks { get; set; }

        // @property (assign, nonatomic) BOOL extractSurnameAtBirth;
        [Export ("extractSurnameAtBirth")]
        bool ExtractSurnameAtBirth { get; set; }
    }

    // @interface MBSlovakiaIdFrontRecognizerResult : MBRecognizerResult <NSCopying, MBFaceImageResult, MBEncodedFaceImageResult, MBFullDocumentImageResult, MBEncodedFullDocumentImageResult, MBSignatureImageResult, MBEncodedSignatureImageResult>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBSlovakiaIdFrontRecognizerResult : INSCopying, IMBFaceImageResult, IMBEncodedFaceImageResult, IMBFullDocumentImageResult, IMBEncodedFullDocumentImageResult, IMBSignatureImageResult, IMBEncodedSignatureImageResult
    {
        // @property (readonly, nonatomic) MBDateResult * _Nonnull dateOfBirth;
        [Export ("dateOfBirth")]
        MBDateResult DateOfBirth { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nonnull dateOfExpiry;
        [Export ("dateOfExpiry")]
        MBDateResult DateOfExpiry { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nonnull dateOfIssue;
        [Export ("dateOfIssue")]
        MBDateResult DateOfIssue { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull documentNumber;
        [Export ("documentNumber")]
        string DocumentNumber { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull firstName;
        [Export ("firstName")]
        string FirstName { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull issuedBy;
        [Export ("issuedBy")]
        string IssuedBy { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull lastName;
        [Export ("lastName")]
        string LastName { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull nationality;
        [Export ("nationality")]
        string Nationality { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull personalNumber;
        [Export ("personalNumber")]
        string PersonalNumber { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull sex;
        [Export ("sex")]
        string Sex { get; }
    }

    // @interface MBSlovakiaIdFrontRecognizer : MBRecognizer <NSCopying, MBGlareDetection, MBFaceImage, MBEncodeFaceImage, MBFaceImageDpi, MBFullDocumentImage, MBEncodeFullDocumentImage, MBFullDocumentImageDpi, MBFullDocumentImageExtensionFactors, MBSignatureImage, MBSignatureImageDpi, MBEncodeSignatureImage>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizer))]
    interface MBSlovakiaIdFrontRecognizer : INSCopying, IMBGlareDetection, IMBFaceImage, IMBEncodeFaceImage, IMBFaceImageDpi, IMBFullDocumentImage, IMBEncodeFullDocumentImage, IMBFullDocumentImageDpi, IMBFullDocumentImageExtensionFactors, IMBSignatureImage, IMBSignatureImageDpi, IMBEncodeSignatureImage
    {
        // @property (readonly, nonatomic, strong) MBSlovakiaIdFrontRecognizerResult * _Nonnull result;
        [Export ("result", ArgumentSemantic.Strong)]
        MBSlovakiaIdFrontRecognizerResult Result { get; }

        // @property (assign, nonatomic) BOOL extractDateOfBirth;
        [Export ("extractDateOfBirth")]
        bool ExtractDateOfBirth { get; set; }

        // @property (assign, nonatomic) BOOL extractDateOfExpiry;
        [Export ("extractDateOfExpiry")]
        bool ExtractDateOfExpiry { get; set; }

        // @property (assign, nonatomic) BOOL extractDateOfIssue;
        [Export ("extractDateOfIssue")]
        bool ExtractDateOfIssue { get; set; }

        // @property (assign, nonatomic) BOOL extractDocumentNumber;
        [Export ("extractDocumentNumber")]
        bool ExtractDocumentNumber { get; set; }

        // @property (assign, nonatomic) BOOL extractFirstName;
        [Export ("extractFirstName")]
        bool ExtractFirstName { get; set; }

        // @property (assign, nonatomic) BOOL extractIssuedBy;
        [Export ("extractIssuedBy")]
        bool ExtractIssuedBy { get; set; }

        // @property (assign, nonatomic) BOOL extractLastName;
        [Export ("extractLastName")]
        bool ExtractLastName { get; set; }

        // @property (assign, nonatomic) BOOL extractNationality;
        [Export ("extractNationality")]
        bool ExtractNationality { get; set; }

        // @property (assign, nonatomic) BOOL extractSex;
        [Export ("extractSex")]
        bool ExtractSex { get; set; }
    }

    // @interface MBSlovakiaCombinedRecognizerResult : MBLegacyRecognizerResult <NSCopying, MBCombinedRecognizerResult, MBFaceImageResult, MBCombinedFullDocumentImageResult, MBSignatureImageResult, MBDigitalSignatureResult, MBEncodedFaceImageResult, MBEncodedSignatureImageResult, MBEncodedCombinedFullDocumentImageResult>
    
    [BaseType(typeof(MBLegacyRecognizerResult))]
    [DisableDefaultCtor]
    interface MBSlovakiaCombinedRecognizerResult : INSCopying, MBCombinedRecognizerResult, IMBFaceImageResult, IMBCombinedFullDocumentImageResult, IMBSignatureImageResult, IMBDigitalSignatureResult, IMBEncodedFaceImageResult, IMBEncodedSignatureImageResult, IMBEncodedCombinedFullDocumentImageResult
    {
        // @property (readonly, nonatomic) NSString * _Nullable firstName;
        [NullAllowed, Export("firstName")]
        string FirstName { get; }

        // @property (readonly, nonatomic) NSString * _Nullable lastName;
        [NullAllowed, Export("lastName")]
        string LastName { get; }

        // @property (readonly, nonatomic) NSString * _Nullable documentNumber;
        [NullAllowed, Export("documentNumber")]
        string DocumentNumber { get; }

        // @property (readonly, nonatomic) NSString * _Nullable sex;
        [NullAllowed, Export("sex")]
        string Sex { get; }

        // @property (readonly, nonatomic) NSString * _Nullable nationality;
        [NullAllowed, Export("nationality")]
        string Nationality { get; }

        // @property (readonly, nonatomic) NSString * _Nullable personalIdentificationNumber;
        [NullAllowed, Export("personalIdentificationNumber")]
        string PersonalIdentificationNumber { get; }

        // @property (readonly, nonatomic) NSDate * _Nullable dateOfBirth;
        [NullAllowed, Export("dateOfBirth")]
        NSDate DateOfBirth { get; }

        // @property (readonly, nonatomic) NSDate * _Nullable dateOfExpiry;
        [NullAllowed, Export("dateOfExpiry")]
        NSDate DateOfExpiry { get; }

        // @property (readonly, nonatomic) NSString * _Nullable address;
        [NullAllowed, Export("address")]
        string Address { get; }

        // @property (readonly, nonatomic) NSString * _Nullable issuingAuthority;
        [NullAllowed, Export("issuingAuthority")]
        string IssuingAuthority { get; }

        // @property (readonly, nonatomic) NSDate * _Nullable dateOfIssue;
        [NullAllowed, Export("dateOfIssue")]
        NSDate DateOfIssue { get; }

        // @property (readonly, nonatomic) NSString * _Nullable surnameAtBirth;
        [NullAllowed, Export("surnameAtBirth")]
        string SurnameAtBirth { get; }

        // @property (readonly, nonatomic) NSString * _Nullable specialRemarks;
        [NullAllowed, Export("specialRemarks")]
        string SpecialRemarks { get; }

        // @property (readonly, nonatomic) NSString * _Nullable placeOfBirth;
        [NullAllowed, Export("placeOfBirth")]
        string PlaceOfBirth { get; }

        // @property (readonly, nonatomic) BOOL mrzVerified;
        [Export("mrzVerified")]
        bool MrzVerified { get; }
    }

    // @interface MBSlovakiaCombinedRecognizer : MBLegacyRecognizer <NSCopying, MBCombinedRecognizer, MBGlareDetection, MBFullDocumentImage, MBSignatureImage, MBFaceImage, MBEncodeFaceImage, MBEncodeFullDocumentImage, MBEncodeSignatureImage, MBDigitalSignature>
    
    [BaseType(typeof(MBLegacyRecognizer))]
    interface MBSlovakiaCombinedRecognizer : INSCopying, IMBCombinedRecognizer, IMBGlareDetection, IMBFullDocumentImage, IMBSignatureImage, IMBFaceImage, IMBEncodeFaceImage, IMBEncodeFullDocumentImage, IMBEncodeSignatureImage, IMBDigitalSignature
    {
        // @property (readonly, nonatomic, strong) MBSlovakiaCombinedRecognizerResult * result;
        [Export("result", ArgumentSemantic.Strong)]
        MBSlovakiaCombinedRecognizerResult Result { get; }

        // @property (assign, nonatomic) BOOL extractSex;
        [Export("extractSex")]
        bool ExtractSex { get; set; }

        // @property (assign, nonatomic) BOOL extractNationality;
        [Export("extractNationality")]
        bool ExtractNationality { get; set; }

        // @property (assign, nonatomic) BOOL extractDateOfBirth;
        [Export("extractDateOfBirth")]
        bool ExtractDateOfBirth { get; set; }

        // @property (assign, nonatomic) BOOL extractDateOfExpiry;
        [Export("extractDateOfExpiry")]
        bool ExtractDateOfExpiry { get; set; }

        // @property (assign, nonatomic) BOOL extractDateOfIssue;
        [Export("extractDateOfIssue")]
        bool ExtractDateOfIssue { get; set; }

        // @property (assign, nonatomic) BOOL extractIssuedBy;
        [Export("extractIssuedBy")]
        bool ExtractIssuedBy { get; set; }

        // @property (assign, nonatomic) BOOL extractDocumentNumber;
        [Export("extractDocumentNumber")]
        bool ExtractDocumentNumber { get; set; }

        // @property (assign, nonatomic) BOOL extractSurnameAtBirth;
        [Export("extractSurnameAtBirth")]
        bool ExtractSurnameAtBirth { get; set; }

        // @property (assign, nonatomic) BOOL extractPlaceOfBirth;
        [Export("extractPlaceOfBirth")]
        bool ExtractPlaceOfBirth { get; set; }

        // @property (assign, nonatomic) BOOL extractSpecialRemarks;
        [Export("extractSpecialRemarks")]
        bool ExtractSpecialRemarks { get; set; }
    }

    // @interface MBSloveniaIdBackRecognizerResult : MBLegacyMRTDRecognizerResult <NSCopying, MBFullDocumentImageResult>
    
    [BaseType(typeof(MBLegacyMRTDRecognizerResult))]
    [DisableDefaultCtor]
    interface MBSloveniaIdBackRecognizerResult : INSCopying, IMBFullDocumentImageResult
    {
        // @property (readonly, nonatomic) NSString * _Nullable address;
        [NullAllowed, Export("address")]
        string Address { get; }

        // @property (readonly, nonatomic) NSString * _Nullable authority;
        [NullAllowed, Export("authority")]
        string Authority { get; }

        // @property (readonly, nonatomic) NSString * _Nullable rawDateOfIssue;
        [NullAllowed, Export("rawDateOfIssue")]
        string RawDateOfIssue { get; }

        // @property (readonly, nonatomic) NSDate * _Nullable dateOfIssue;
        [NullAllowed, Export("dateOfIssue")]
        NSDate DateOfIssue { get; }
    }

    // @interface MBSloveniaIdBackRecognizer : MBLegacyRecognizer <NSCopying, MBFullDocumentImage, MBGlareDetection>
    
    [BaseType(typeof(MBLegacyRecognizer))]
    interface MBSloveniaIdBackRecognizer : INSCopying, IMBFullDocumentImage, IMBGlareDetection
    {
        // @property (readonly, nonatomic, strong) MBSloveniaIdBackRecognizerResult * _Nonnull result;
        [Export("result", ArgumentSemantic.Strong)]
        MBSloveniaIdBackRecognizerResult Result { get; }

        // @property (nonatomic) BOOL extractAuthority;
        [Export("extractAuthority")]
        bool ExtractAuthority { get; set; }

        // @property (nonatomic) BOOL extractDateOfIssue;
        [Export("extractDateOfIssue")]
        bool ExtractDateOfIssue { get; set; }
    }

    // @interface MBSloveniaIdFrontRecognizerResult : MBLegacyRecognizerResult <NSCopying, MBFaceImageResult, MBSignatureImageResult, MBFullDocumentImageResult>
    
    [BaseType(typeof(MBLegacyRecognizerResult))]
    [DisableDefaultCtor]
    interface MBSloveniaIdFrontRecognizerResult : INSCopying, IMBFaceImageResult, IMBSignatureImageResult, IMBFullDocumentImageResult
    {
        // @property (readonly, nonatomic) NSString * _Nullable firstName;
        [NullAllowed, Export("firstName")]
        string FirstName { get; }

        // @property (readonly, nonatomic) NSString * _Nullable lastName;
        [NullAllowed, Export("lastName")]
        string LastName { get; }

        // @property (readonly, nonatomic) NSString * _Nullable sex;
        [NullAllowed, Export("sex")]
        string Sex { get; }

        // @property (readonly, nonatomic) NSString * _Nullable nationality;
        [NullAllowed, Export("nationality")]
        string Nationality { get; }

        // @property (readonly, nonatomic) NSString * _Nullable rawDateOfBirth;
        [NullAllowed, Export("rawDateOfBirth")]
        string RawDateOfBirth { get; }

        // @property (readonly, nonatomic) NSDate * _Nullable dateOfBirth;
        [NullAllowed, Export("dateOfBirth")]
        NSDate DateOfBirth { get; }

        // @property (readonly, nonatomic) NSString * _Nullable rawDateOfExpiry;
        [NullAllowed, Export("rawDateOfExpiry")]
        string RawDateOfExpiry { get; }

        // @property (readonly, nonatomic) NSDate * _Nullable dateOfExpiry;
        [NullAllowed, Export("dateOfExpiry")]
        NSDate DateOfExpiry { get; }
    }

    // @interface MBSloveniaIdFrontRecognizer : MBLegacyRecognizer <NSCopying, MBFaceImage, MBSignatureImage, MBFullDocumentImage, MBGlareDetection>
    
    [BaseType(typeof(MBLegacyRecognizer))]
    interface MBSloveniaIdFrontRecognizer : INSCopying, IMBFaceImage, IMBSignatureImage, IMBFullDocumentImage, IMBGlareDetection
    {
        // @property (readonly, nonatomic, strong) MBSloveniaIdFrontRecognizerResult * _Nonnull result;
        [Export("result", ArgumentSemantic.Strong)]
        MBSloveniaIdFrontRecognizerResult Result { get; }

        // @property (nonatomic) BOOL extractSex;
        [Export("extractSex")]
        bool ExtractSex { get; set; }

        // @property (nonatomic) BOOL extractNationality;
        [Export("extractNationality")]
        bool ExtractNationality { get; set; }

        // @property (nonatomic) BOOL extractDateOfBirth;
        [Export("extractDateOfBirth")]
        bool ExtractDateOfBirth { get; set; }

        // @property (nonatomic) BOOL extractDateOfExpiry;
        [Export("extractDateOfExpiry")]
        bool ExtractDateOfExpiry { get; set; }
    }

    // @interface MBSloveniaCombinedRecognizerResult : MBLegacyRecognizerResult <NSCopying, MBCombinedRecognizerResult, MBFaceImageResult, MBCombinedFullDocumentImageResult, MBSignatureImageResult, MBDigitalSignatureResult, MBEncodedFaceImageResult, MBEncodedSignatureImageResult, MBEncodedCombinedFullDocumentImageResult>
    
    [BaseType(typeof(MBLegacyRecognizerResult))]
    [DisableDefaultCtor]
    interface MBSloveniaCombinedRecognizerResult : INSCopying, MBCombinedRecognizerResult, IMBFaceImageResult, IMBCombinedFullDocumentImageResult, IMBSignatureImageResult, IMBDigitalSignatureResult, IMBEncodedFaceImageResult, IMBEncodedSignatureImageResult, IMBEncodedCombinedFullDocumentImageResult
    {
        // @property (readonly, nonatomic) NSString * _Nullable firstName;
        [NullAllowed, Export("firstName")]
        string FirstName { get; }

        // @property (readonly, nonatomic) NSString * _Nullable lastName;
        [NullAllowed, Export("lastName")]
        string LastName { get; }

        // @property (readonly, nonatomic) NSString * _Nullable identityCardNumber;
        [NullAllowed, Export("identityCardNumber")]
        string IdentityCardNumber { get; }

        // @property (readonly, nonatomic) NSString * _Nullable sex;
        [NullAllowed, Export("sex")]
        string Sex { get; }

        // @property (readonly, nonatomic) NSString * _Nullable citizenship;
        [NullAllowed, Export("citizenship")]
        string Citizenship { get; }

        // @property (readonly, nonatomic) NSDate * _Nullable dateOfBirth;
        [NullAllowed, Export("dateOfBirth")]
        NSDate DateOfBirth { get; }

        // @property (readonly, nonatomic) NSDate * _Nullable dateOfExpiry;
        [NullAllowed, Export("dateOfExpiry")]
        NSDate DateOfExpiry { get; }

        // @property (readonly, nonatomic) NSString * _Nullable address;
        [NullAllowed, Export("address")]
        string Address { get; }

        // @property (readonly, nonatomic) NSString * _Nullable personalIdentificationNumber;
        [NullAllowed, Export("personalIdentificationNumber")]
        string PersonalIdentificationNumber { get; }

        // @property (readonly, nonatomic) NSString * _Nullable issuingAuthority;
        [NullAllowed, Export("issuingAuthority")]
        string IssuingAuthority { get; }

        // @property (readonly, nonatomic) NSDate * _Nullable dateOfIssue;
        [NullAllowed, Export("dateOfIssue")]
        NSDate DateOfIssue { get; }

        // @property (readonly, nonatomic) BOOL mrzVerified;
        [Export("mrzVerified")]
        bool MrzVerified { get; }
    }

    // @interface MBSloveniaCombinedRecognizer : MBLegacyRecognizer <NSCopying, MBCombinedRecognizer, MBGlareDetection, MBFullDocumentImage, MBSignatureImage, MBFaceImage, MBEncodeFaceImage, MBEncodeFullDocumentImage, MBEncodeSignatureImage, MBDigitalSignature>
    
    [BaseType(typeof(MBLegacyRecognizer))]
    interface MBSloveniaCombinedRecognizer : INSCopying, IMBCombinedRecognizer, IMBGlareDetection, IMBFullDocumentImage, IMBSignatureImage, IMBFaceImage, IMBEncodeFaceImage, IMBEncodeFullDocumentImage, IMBEncodeSignatureImage, IMBDigitalSignature
    {
        // @property (readonly, nonatomic, strong) MBSloveniaCombinedRecognizerResult * result;
        [Export("result", ArgumentSemantic.Strong)]
        MBSloveniaCombinedRecognizerResult Result { get; }
    }

    // @interface MBSpainDlFrontRecognizerResult : MBRecognizerResult <NSCopying, MBFaceImageResult, MBEncodedFaceImageResult, MBSignatureImageResult, MBEncodedSignatureImageResult, MBFullDocumentImageResult, MBEncodedFullDocumentImageResult>
    [iOS (8,0)]
    [BaseType(typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBSpainDlFrontRecognizerResult : INSCopying, IMBFaceImageResult, IMBEncodedFaceImageResult, IMBSignatureImageResult, IMBEncodedSignatureImageResult, IMBFullDocumentImageResult, IMBEncodedFullDocumentImageResult
    {
        // @property (readonly, nonatomic) NSString * _Nullable firstName;
        [NullAllowed, Export("firstName")]
        string FirstName { get; }

        // @property (readonly, nonatomic) NSString * _Nullable surname;
        [NullAllowed, Export("surname")]
        string Surname { get; }

        // @property (readonly, nonatomic) NSString * _Nullable number;
        [NullAllowed, Export("number")]
        string Number { get; }

        // @property (readonly, nonatomic) NSString * _Nullable placeOfBirth;
        [NullAllowed, Export("placeOfBirth")]
        string PlaceOfBirth { get; }

        // @property (readonly, nonatomic) NSString * _Nullable issuingAuthority;
        [NullAllowed, Export("issuingAuthority")]
        string IssuingAuthority { get; }

        // @property (readonly, nonatomic) NSString * _Nullable licenceCategories;
        [NullAllowed, Export("licenceCategories")]
        string LicenceCategories { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nullable dateOfBirth;
        [NullAllowed, Export("dateOfBirth")]
        MBDateResult DateOfBirth { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nullable validFrom;
        [NullAllowed, Export("validFrom")]
        MBDateResult ValidFrom { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nullable validUntil;
        [NullAllowed, Export("validUntil")]
        MBDateResult ValidUntil { get; }
    }

    // @interface MBSpainDlFrontRecognizer : MBRecognizer <NSCopying, MBFaceImage, MBEncodeFaceImage, MBFaceImageDpi, MBSignatureImage, MBEncodeSignatureImage, MBSignatureImageDpi, MBFullDocumentImage, MBEncodeFullDocumentImage, MBFullDocumentImageDpi, MBGlareDetection, IMBFullDocumentImageExtensionFactors>
    [iOS (8,0)]
    [BaseType(typeof(MBRecognizer))]
    interface MBSpainDlFrontRecognizer : INSCopying, IMBFaceImage, IMBEncodeFaceImage, IMBFaceImageDpi, IMBSignatureImage, IMBEncodeSignatureImage, IMBSignatureImageDpi, IMBFullDocumentImage, IMBEncodeFullDocumentImage, IMBFullDocumentImageDpi, IMBGlareDetection, IMBFullDocumentImageExtensionFactors
    {
        // @property (readonly, nonatomic, strong) MBSpainDlFrontRecognizerResult * _Nonnull result;
        [Export("result", ArgumentSemantic.Strong)]
        MBSpainDlFrontRecognizerResult Result { get; }

        // @property (assign, nonatomic) BOOL extractFirstName;
        [Export("extractFirstName")]
        bool ExtractFirstName { get; set; }

        // @property (assign, nonatomic) BOOL extractSurname;
        [Export("extractSurname")]
        bool ExtractSurname { get; set; }

        // @property (assign, nonatomic) BOOL extractDateOfBirth;
        [Export("extractDateOfBirth")]
        bool ExtractDateOfBirth { get; set; }

        // @property (assign, nonatomic) BOOL extractPlaceOfBirth;
        [Export("extractPlaceOfBirth")]
        bool ExtractPlaceOfBirth { get; set; }

        // @property (assign, nonatomic) BOOL extractValidFrom;
        [Export("extractValidFrom")]
        bool ExtractValidFrom { get; set; }

        // @property (assign, nonatomic) BOOL extractValidUntil;
        [Export("extractValidUntil")]
        bool ExtractValidUntil { get; set; }

        // @property (assign, nonatomic) BOOL extractIssuingAuthority;
        [Export("extractIssuingAuthority")]
        bool ExtractIssuingAuthority { get; set; }

        // @property (assign, nonatomic) BOOL extractLicenceCategories;
        [Export("extractLicenceCategories")]
        bool ExtractLicenceCategories { get; set; }
    }


    // @interface MBSwedenDlFrontRecognizerResult : MBLegacyRecognizerResult <NSCopying, MBFullDocumentImageResult, MBFaceImageResult, MBSignatureImageResult>
    
    [BaseType(typeof(MBLegacyRecognizerResult))]
    [DisableDefaultCtor]
    interface MBSwedenDlFrontRecognizerResult : INSCopying, IMBFullDocumentImageResult, IMBFaceImageResult, IMBSignatureImageResult
    {
        // @property (readonly, nonatomic) NSString * _Nullable surname;
        [NullAllowed, Export("surname")]
        string Surname { get; }

        // @property (readonly, nonatomic) NSString * _Nullable name;
        [NullAllowed, Export("name")]
        string Name { get; }

        // @property (readonly, nonatomic) NSDate * _Nullable dateOfBirth;
        [NullAllowed, Export("dateOfBirth")]
        NSDate DateOfBirth { get; }

        // @property (readonly, nonatomic) NSDate * _Nullable dateOfIssue;
        [NullAllowed, Export("dateOfIssue")]
        NSDate DateOfIssue { get; }

        // @property (readonly, nonatomic) NSDate * _Nullable dateOfExpiry;
        [NullAllowed, Export("dateOfExpiry")]
        NSDate DateOfExpiry { get; }

        // @property (readonly, nonatomic) NSString * _Nullable issuingAgency;
        [NullAllowed, Export("issuingAgency")]
        string IssuingAgency { get; }

        // @property (readonly, nonatomic) NSString * _Nullable referenceNumber;
        [NullAllowed, Export("referenceNumber")]
        string ReferenceNumber { get; }

        // @property (readonly, nonatomic) NSString * _Nullable licenceCategories;
        [NullAllowed, Export("licenceCategories")]
        string LicenceCategories { get; }

        // @property (readonly, nonatomic) NSString * _Nullable licenceNumber;
        [NullAllowed, Export("licenceNumber")]
        string LicenceNumber { get; }
    }

    // @interface MBSwedenDlFrontRecognizer : MBLegacyRecognizer <NSCopying, MBFullDocumentImage, MBFaceImage, MBSignatureImage, MBFullDocumentImageDpi, MBGlareDetection>
    
    [BaseType(typeof(MBLegacyRecognizer))]
    interface MBSwedenDlFrontRecognizer : INSCopying, IMBFullDocumentImage, IMBFaceImage, IMBSignatureImage, IMBFullDocumentImageDpi, IMBGlareDetection
    {
        // @property (readonly, nonatomic, strong) MBSwedenDlFrontRecognizerResult * _Nonnull result;
        [Export("result", ArgumentSemantic.Strong)]
        MBSwedenDlFrontRecognizerResult Result { get; }

        // @property (assign, nonatomic) BOOL extractSurname;
        [Export("extractSurname")]
        bool ExtractSurname { get; set; }

        // @property (assign, nonatomic) BOOL extractName;
        [Export("extractName")]
        bool ExtractName { get; set; }

        // @property (assign, nonatomic) BOOL extractDateOfBirth;
        [Export("extractDateOfBirth")]
        bool ExtractDateOfBirth { get; set; }

        // @property (assign, nonatomic) BOOL extractDateOfIssue;
        [Export("extractDateOfIssue")]
        bool ExtractDateOfIssue { get; set; }

        // @property (assign, nonatomic) BOOL extractDateOfExpiry;
        [Export("extractDateOfExpiry")]
        bool ExtractDateOfExpiry { get; set; }

        // @property (assign, nonatomic) BOOL extractIssuingAgency;
        [Export("extractIssuingAgency")]
        bool ExtractIssuingAgency { get; set; }

        // @property (assign, nonatomic) BOOL extractReferenceNumber;
        [Export("extractReferenceNumber")]
        bool ExtractReferenceNumber { get; set; }

        // @property (assign, nonatomic) BOOL extractLicenceCategories;
        [Export("extractLicenceCategories")]
        bool ExtractLicenceCategories { get; set; }
    }

    // @interface MBSwitzerlandIdBackRecognizerResult : MBRecognizerResult <NSCopying, MBFullDocumentImageResult, MBEncodedFullDocumentImageResult>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBSwitzerlandIdBackRecognizerResult : INSCopying, IMBFullDocumentImageResult, IMBEncodedFullDocumentImageResult
    {
        // @property (readonly, nonatomic) NSString * _Nonnull authority;
        [Export ("authority")]
        string Authority { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nonnull dateOfExpiry;
        [Export ("dateOfExpiry")]
        MBDateResult DateOfExpiry { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nonnull dateOfIssue;
        [Export ("dateOfIssue")]
        MBDateResult DateOfIssue { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull height;
        [Export ("height")]
        string Height { get; }

        // @property (readonly, nonatomic) MBMrzResult * _Nonnull mrzResult;
        [Export ("mrzResult")]
        MBMrzResult MrzResult { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull placeOfOrigin;
        [Export ("placeOfOrigin")]
        string PlaceOfOrigin { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull sex;
        [Export ("sex")]
        string Sex { get; }
    }

    // @interface MBSwitzerlandIdBackRecognizer : MBRecognizer <NSCopying, MBGlareDetection, MBFullDocumentImage, MBEncodeFullDocumentImage, MBFullDocumentImageDpi, MBFullDocumentImageExtensionFactors>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizer))]
    interface MBSwitzerlandIdBackRecognizer : INSCopying, IMBGlareDetection, IMBFullDocumentImage, IMBEncodeFullDocumentImage, IMBFullDocumentImageDpi, IMBFullDocumentImageExtensionFactors
    {
        // @property (readonly, nonatomic, strong) MBSwitzerlandIdBackRecognizerResult * _Nonnull result;
        [Export ("result", ArgumentSemantic.Strong)]
        MBSwitzerlandIdBackRecognizerResult Result { get; }

        // @property (assign, nonatomic) BOOL extractAuthority;
        [Export ("extractAuthority")]
        bool ExtractAuthority { get; set; }

        // @property (assign, nonatomic) BOOL extractDateOfExpiry;
        [Export ("extractDateOfExpiry")]
        bool ExtractDateOfExpiry { get; set; }

        // @property (assign, nonatomic) BOOL extractDateOfIssue;
        [Export ("extractDateOfIssue")]
        bool ExtractDateOfIssue { get; set; }

        // @property (assign, nonatomic) BOOL extractHeight;
        [Export ("extractHeight")]
        bool ExtractHeight { get; set; }

        // @property (assign, nonatomic) BOOL extractPlaceOfOrigin;
        [Export ("extractPlaceOfOrigin")]
        bool ExtractPlaceOfOrigin { get; set; }

        // @property (assign, nonatomic) BOOL extractSex;
        [Export ("extractSex")]
        bool ExtractSex { get; set; }
    }

    // @interface MBSwitzerlandIdFrontRecognizerResult : MBRecognizerResult <NSCopying, MBFaceImageResult, MBEncodedFaceImageResult, MBFullDocumentImageResult, MBEncodedFullDocumentImageResult, MBSignatureImageResult, MBEncodedSignatureImageResult>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBSwitzerlandIdFrontRecognizerResult : INSCopying, IMBFaceImageResult, IMBEncodedFaceImageResult, IMBFullDocumentImageResult, IMBEncodedFullDocumentImageResult, IMBSignatureImageResult, IMBEncodedSignatureImageResult
    {
        // @property (readonly, nonatomic) MBDateResult * _Nonnull dateOfBirth;
        [Export ("dateOfBirth")]
        MBDateResult DateOfBirth { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull givenName;
        [Export ("givenName")]
        string GivenName { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull surname;
        [Export ("surname")]
        string Surname { get; }
    }

    // @interface MBSwitzerlandIdFrontRecognizer : MBRecognizer <NSCopying, MBGlareDetection, MBFaceImage, MBEncodeFaceImage, MBFaceImageDpi, MBFullDocumentImage, MBEncodeFullDocumentImage, MBFullDocumentImageDpi, MBFullDocumentImageExtensionFactors, MBSignatureImage, MBSignatureImageDpi, MBEncodeSignatureImage>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizer))]
    interface MBSwitzerlandIdFrontRecognizer : INSCopying, IMBGlareDetection, IMBFaceImage, IMBEncodeFaceImage, IMBFaceImageDpi, IMBFullDocumentImage, IMBEncodeFullDocumentImage, IMBFullDocumentImageDpi, IMBFullDocumentImageExtensionFactors, IMBSignatureImage, IMBSignatureImageDpi, IMBEncodeSignatureImage
    {
        // @property (readonly, nonatomic, strong) MBSwitzerlandIdFrontRecognizerResult * _Nonnull result;
        [Export ("result", ArgumentSemantic.Strong)]
        MBSwitzerlandIdFrontRecognizerResult Result { get; }

        // @property (assign, nonatomic) BOOL extractGivenName;
        [Export ("extractGivenName")]
        bool ExtractGivenName { get; set; }

        // @property (assign, nonatomic) BOOL extractSurname;
        [Export ("extractSurname")]
        bool ExtractSurname { get; set; }
    }

    // @interface MBSwitzerlandPassportRecognizerResult : MBRecognizerResult <NSCopying, MBFaceImageResult, MBEncodedFaceImageResult, MBFullDocumentImageResult, MBEncodedFullDocumentImageResult>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBSwitzerlandPassportRecognizerResult : INSCopying, IMBFaceImageResult, IMBEncodedFaceImageResult, IMBFullDocumentImageResult, IMBEncodedFullDocumentImageResult
    {
        // @property (readonly, nonatomic) NSString * _Nonnull authority;
        [Export ("authority")]
        string Authority { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nonnull dateOfBirth;
        [Export ("dateOfBirth")]
        MBDateResult DateOfBirth { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nonnull dateOfExpiry;
        [Export ("dateOfExpiry")]
        MBDateResult DateOfExpiry { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nonnull dateOfIssue;
        [Export ("dateOfIssue")]
        MBDateResult DateOfIssue { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull givenName;
        [Export ("givenName")]
        string GivenName { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull height;
        [Export ("height")]
        string Height { get; }

        // @property (readonly, nonatomic) MBMrzResult * _Nonnull mrzResult;
        [Export ("mrzResult")]
        MBMrzResult MrzResult { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull passportNumber;
        [Export ("passportNumber")]
        string PassportNumber { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull placeOfOrigin;
        [Export ("placeOfOrigin")]
        string PlaceOfOrigin { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull sex;
        [Export ("sex")]
        string Sex { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull surname;
        [Export ("surname")]
        string Surname { get; }
    }

    // @interface MBSwitzerlandPassportRecognizer : MBRecognizer <NSCopying, MBGlareDetection, MBFaceImage, MBEncodeFaceImage, MBFaceImageDpi, MBFullDocumentImage, MBEncodeFullDocumentImage, MBFullDocumentImageDpi, MBFullDocumentImageExtensionFactors>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizer))]
    interface MBSwitzerlandPassportRecognizer : INSCopying, IMBGlareDetection, IMBFaceImage, IMBEncodeFaceImage, IMBFaceImageDpi, IMBFullDocumentImage, IMBEncodeFullDocumentImage, IMBFullDocumentImageDpi, IMBFullDocumentImageExtensionFactors
    {
        // @property (readonly, nonatomic, strong) MBSwitzerlandPassportRecognizerResult * _Nonnull result;
        [Export ("result", ArgumentSemantic.Strong)]
        MBSwitzerlandPassportRecognizerResult Result { get; }

        // @property (assign, nonatomic) BOOL extractAuthority;
        [Export ("extractAuthority")]
        bool ExtractAuthority { get; set; }

        // @property (assign, nonatomic) BOOL extractDateOfBirth;
        [Export ("extractDateOfBirth")]
        bool ExtractDateOfBirth { get; set; }

        // @property (assign, nonatomic) BOOL extractDateOfExpiry;
        [Export ("extractDateOfExpiry")]
        bool ExtractDateOfExpiry { get; set; }

        // @property (assign, nonatomic) BOOL extractDateOfIssue;
        [Export ("extractDateOfIssue")]
        bool ExtractDateOfIssue { get; set; }

        // @property (assign, nonatomic) BOOL extractGivenName;
        [Export ("extractGivenName")]
        bool ExtractGivenName { get; set; }

        // @property (assign, nonatomic) BOOL extractHeight;
        [Export ("extractHeight")]
        bool ExtractHeight { get; set; }

        // @property (assign, nonatomic) BOOL extractPassportNumber;
        [Export ("extractPassportNumber")]
        bool ExtractPassportNumber { get; set; }

        // @property (assign, nonatomic) BOOL extractPlaceOfOrigin;
        [Export ("extractPlaceOfOrigin")]
        bool ExtractPlaceOfOrigin { get; set; }

        // @property (assign, nonatomic) BOOL extractSex;
        [Export ("extractSex")]
        bool ExtractSex { get; set; }

        // @property (assign, nonatomic) BOOL extractSurname;
        [Export ("extractSurname")]
        bool ExtractSurname { get; set; }
    }

    // @interface MBSwitzerlandDlFrontRecognizerResult : MBRecognizerResult <NSCopying, MBFaceImageResult, MBEncodedFaceImageResult, MBFullDocumentImageResult, MBEncodedFullDocumentImageResult, MBSignatureImageResult, MBEncodedSignatureImageResult>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBSwitzerlandDlFrontRecognizerResult : INSCopying, IMBFaceImageResult, IMBEncodedFaceImageResult, IMBFullDocumentImageResult, IMBEncodedFullDocumentImageResult, IMBSignatureImageResult, IMBEncodedSignatureImageResult
    {
        // @property (readonly, nonatomic) MBDateResult * _Nonnull dateOfBirth;
        [Export ("dateOfBirth")]
        MBDateResult DateOfBirth { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nonnull dateOfExpiry;
        [Export ("dateOfExpiry")]
        MBDateResult DateOfExpiry { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nonnull dateOfIssue;
        [Export ("dateOfIssue")]
        MBDateResult DateOfIssue { get; }

        // @property (readonly, nonatomic) BOOL expiryDatePermanent;
        [Export ("expiryDatePermanent")]
        bool ExpiryDatePermanent { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull firstName;
        [Export ("firstName")]
        string FirstName { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull issuingAuthority;
        [Export ("issuingAuthority")]
        string IssuingAuthority { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull lastName;
        [Export ("lastName")]
        string LastName { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull licenseNumber;
        [Export ("licenseNumber")]
        string LicenseNumber { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull placeOfBirth;
        [Export ("placeOfBirth")]
        string PlaceOfBirth { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull vehicleCategories;
        [Export ("vehicleCategories")]
        string VehicleCategories { get; }
    }

    // @interface MBSwitzerlandDlFrontRecognizer : MBRecognizer <NSCopying, MBFaceImage, MBEncodeFaceImage, MBFaceImageDpi, MBFullDocumentImage, MBEncodeFullDocumentImage, MBFullDocumentImageDpi, MBSignatureImage, MBEncodeSignatureImage, MBSignatureImageDpi, MBGlareDetection, MBFullDocumentImageExtensionFactors>
    [iOS (8,0)]
    [BaseType (typeof(MBRecognizer))]
    interface MBSwitzerlandDlFrontRecognizer : INSCopying, IMBFaceImage, IMBEncodeFaceImage, IMBFaceImageDpi, IMBFullDocumentImage, IMBEncodeFullDocumentImage, IMBFullDocumentImageDpi, IMBSignatureImage, IMBEncodeSignatureImage, IMBSignatureImageDpi, IMBGlareDetection, IMBFullDocumentImageExtensionFactors
    {
        // @property (readonly, nonatomic, strong) MBSwitzerlandDlFrontRecognizerResult * _Nonnull result;
        [Export ("result", ArgumentSemantic.Strong)]
        MBSwitzerlandDlFrontRecognizerResult Result { get; }

        // @property (assign, nonatomic) BOOL extractDateOfBirth;
        [Export ("extractDateOfBirth")]
        bool ExtractDateOfBirth { get; set; }

        // @property (assign, nonatomic) BOOL extractDateOfExpiry;
        [Export ("extractDateOfExpiry")]
        bool ExtractDateOfExpiry { get; set; }

        // @property (assign, nonatomic) BOOL extractDateOfIssue;
        [Export ("extractDateOfIssue")]
        bool ExtractDateOfIssue { get; set; }

        // @property (assign, nonatomic) BOOL extractFirstName;
        [Export ("extractFirstName")]
        bool ExtractFirstName { get; set; }

        // @property (assign, nonatomic) BOOL extractIssuingAuthority;
        [Export ("extractIssuingAuthority")]
        bool ExtractIssuingAuthority { get; set; }

        // @property (assign, nonatomic) BOOL extractLastName;
        [Export ("extractLastName")]
        bool ExtractLastName { get; set; }

        // @property (assign, nonatomic) BOOL extractPlaceOfBirth;
        [Export ("extractPlaceOfBirth")]
        bool ExtractPlaceOfBirth { get; set; }

        // @property (assign, nonatomic) BOOL extractVehicleCategories;
        [Export ("extractVehicleCategories")]
        bool ExtractVehicleCategories { get; set; }
    }

    // @interface MBUnitedArabEmiratesIdBackRecognizerResult : MBRecognizerResult <NSCopying, MBFullDocumentImageResult>
    
    [BaseType(typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBUnitedArabEmiratesIdBackRecognizerResult : INSCopying, IMBFullDocumentImageResult
    {
        // @property (readonly, nonatomic) MBMrzResult * _Nonnull mrzResult;
        [Export("mrzResult")]
        MBMrzResult MrzResult { get; }
    }

    // @interface MBUnitedArabEmiratesIdBackRecognizer : MBRecognizer <NSCopying, MBFullDocumentImage, MBFullDocumentImageDpi, MBGlareDetection, IMBFullDocumentImageExtensionFactors>
    
    [BaseType(typeof(MBRecognizer))]
    interface MBUnitedArabEmiratesIdBackRecognizer : INSCopying, IMBFullDocumentImage, IMBFullDocumentImageDpi, IMBGlareDetection, IMBFullDocumentImageExtensionFactors
    {
        // @property (readonly, nonatomic, strong) MBUnitedArabEmiratesIdBackRecognizerResult * _Nonnull result;
        [Export("result", ArgumentSemantic.Strong)]
        MBUnitedArabEmiratesIdBackRecognizerResult Result { get; }
    }

    // @interface MBUnitedArabEmiratesIdFrontRecognizerResult : MBRecognizerResult <NSCopying, MBFaceImageResult, MBFullDocumentImageResult>
    
    [BaseType(typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBUnitedArabEmiratesIdFrontRecognizerResult : INSCopying, IMBFaceImageResult, IMBFullDocumentImageResult
    {
        // @property (readonly, nonatomic) NSString * _Nullable idNumber;
        [NullAllowed, Export("idNumber")]
        string IdNumber { get; }

        // @property (readonly, nonatomic) NSString * _Nullable name;
        [NullAllowed, Export("name")]
        string Name { get; }

        // @property (readonly, nonatomic) NSString * _Nullable nationality;
        [NullAllowed, Export("nationality")]
        string Nationality { get; }
    }

    // @interface MBUnitedArabEmiratesIdFrontRecognizer : MBRecognizer <NSCopying, MBFullDocumentImage, MBFullDocumentImageDpi, MBFaceImage, MBFaceImageDpi, MBGlareDetection, IMBFullDocumentImageExtensionFactors>
    
    [BaseType(typeof(MBRecognizer))]
    interface MBUnitedArabEmiratesIdFrontRecognizer : INSCopying, IMBFullDocumentImage, IMBFullDocumentImageDpi, IMBFaceImage, IMBFaceImageDpi, IMBGlareDetection, IMBFullDocumentImageExtensionFactors
    {
        // @property (readonly, nonatomic, strong) MBUnitedArabEmiratesIdFrontRecognizerResult * _Nonnull result;
        [Export("result", ArgumentSemantic.Strong)]
        MBUnitedArabEmiratesIdFrontRecognizerResult Result { get; }

        // @property (assign, nonatomic) BOOL extractName;
        [Export("extractName")]
        bool ExtractName { get; set; }

        // @property (assign, nonatomic) BOOL extractNationality;
        [Export("extractNationality")]
        bool ExtractNationality { get; set; }
    }

    // @interface MBUnitedArabEmiratesDlFrontRecognizerResult : MBRecognizerResult <NSCopying, MBFaceImageResult, MBEncodedFaceImageResult, MBFullDocumentImageResult, MBEncodedFullDocumentImageResult>
    [iOS (8,0)]
    [BaseType(typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBUnitedArabEmiratesDlFrontRecognizerResult : INSCopying, IMBFaceImageResult, IMBEncodedFaceImageResult, IMBFullDocumentImageResult, IMBEncodedFullDocumentImageResult
    {
        // @property (readonly, nonatomic) MBDateResult * _Nonnull dateOfBirth;
        [Export("dateOfBirth")]
        MBDateResult DateOfBirth { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nonnull expiryDate;
        [Export("expiryDate")]
        MBDateResult ExpiryDate { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nonnull issueDate;
        [Export("issueDate")]
        MBDateResult IssueDate { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull licenseNumber;
        [Export("licenseNumber")]
        string LicenseNumber { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull licensingAuthority;
        [Export("licensingAuthority")]
        string LicensingAuthority { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull name;
        [Export("name")]
        string Name { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull nationality;
        [Export("nationality")]
        string Nationality { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull placeOfIssue;
        [Export("placeOfIssue")]
        string PlaceOfIssue { get; }
    }

    // @interface MBUnitedArabEmiratesDlFrontRecognizer : MBRecognizer <NSCopying, MBFaceImage, MBEncodeFaceImage, MBFaceImageDpi, MBFullDocumentImage, MBEncodeFullDocumentImage, MBFullDocumentImageDpi, MBGlareDetection, IMBFullDocumentImageExtensionFactors>
    [iOS (8,0)]
    [BaseType(typeof(MBRecognizer))]
    interface MBUnitedArabEmiratesDlFrontRecognizer : INSCopying, IMBFaceImage, IMBEncodeFaceImage, IMBFaceImageDpi, IMBFullDocumentImage, IMBEncodeFullDocumentImage, IMBFullDocumentImageDpi, IMBGlareDetection, IMBFullDocumentImageExtensionFactors
    {
        // @property (readonly, nonatomic, strong) MBUnitedArabEmiratesDlFrontRecognizerResult * _Nonnull result;
        [Export("result", ArgumentSemantic.Strong)]
        MBUnitedArabEmiratesDlFrontRecognizerResult Result { get; }

        // @property (assign, nonatomic) BOOL extractDateOfBirth;
        [Export("extractDateOfBirth")]
        bool ExtractDateOfBirth { get; set; }

        // @property (assign, nonatomic) BOOL extractIssueDate;
        [Export("extractIssueDate")]
        bool ExtractIssueDate { get; set; }

        // @property (assign, nonatomic) BOOL extractLicenseNumber;
        [Export("extractLicenseNumber")]
        bool ExtractLicenseNumber { get; set; }

        // @property (assign, nonatomic) BOOL extractLicensingAuthority;
        [Export("extractLicensingAuthority")]
        bool ExtractLicensingAuthority { get; set; }

        // @property (assign, nonatomic) BOOL extractName;
        [Export("extractName")]
        bool ExtractName { get; set; }

        // @property (assign, nonatomic) BOOL extractNationality;
        [Export("extractNationality")]
        bool ExtractNationality { get; set; }

        // @property (assign, nonatomic) BOOL extractPlaceOfIssue;
        [Export("extractPlaceOfIssue")]
        bool ExtractPlaceOfIssue { get; set; }
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

    // @interface MBUsdlCombinedRecognizerResult : MBRecognizerResult <NSCopying, MBCombinedRecognizerResult, MBFaceImageResult, MBFullDocumentImageResult, MBDigitalSignatureResult, MBEncodedFaceImageResult, MBEncodedFullDocumentImageResult>
    
    [BaseType(typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBUsdlCombinedRecognizerResult : INSCopying, MBCombinedRecognizerResult, IMBFaceImageResult, IMBFullDocumentImageResult, IMBDigitalSignatureResult, IMBEncodedFaceImageResult, IMBEncodedFullDocumentImageResult
    {
        // -(NSData * _Nullable)data;
        [NullAllowed, Export("data")]
        NSData Data { get; }

        // -(BOOL)isUncertain;
        [Export("isUncertain")]
        bool IsUncertain { get; }

        // -(NSString * _Nullable)getField:(MBUsdlKeys)usdlKey;
        [Export("getField:")]
        [return: NullAllowed]
        string GetField(MBUsdlKeys usdlKey);

        // -(NSArray<NSString *> * _Nullable)optionalElements;
        [NullAllowed, Export("optionalElements")]
        string[] OptionalElements { get; }
    }

    // @interface MBUsdlCombinedRecognizer : MBRecognizer <NSCopying, MBCombinedRecognizer, MBFullDocumentImage, MBFullDocumentImageDpi, MBFaceImage, MBFaceImageDpi, MBEncodeFaceImage, MBEncodeFullDocumentImage, MBDigitalSignature, MBFullDocumentImageExtensionFactors>
    
    [BaseType(typeof(MBRecognizer))]
    interface MBUsdlCombinedRecognizer : INSCopying, IMBCombinedRecognizer, IMBFullDocumentImage, IMBFullDocumentImageDpi, IMBFaceImage, IMBFaceImageDpi, IMBEncodeFaceImage, IMBEncodeFullDocumentImage, IMBDigitalSignature, IMBFullDocumentImageExtensionFactors
    {
        // @property (readonly, nonatomic, strong) MBUsdlCombinedRecognizerResult * result;
        [Export ("result", ArgumentSemantic.Strong)]
        MBUsdlCombinedRecognizerResult Result { get; }

        // @property (assign, nonatomic) BOOL scanUncertain;
        [Export ("scanUncertain")]
        bool ScanUncertain { get; set; }

        // @property (assign, nonatomic) BOOL allowNullQuietZone;
        [Export ("allowNullQuietZone")]
        bool AllowNullQuietZone { get; set; }

        // @property (assign, nonatomic) MBDocumentFaceDetectorType type;
        [Export ("type", ArgumentSemantic.Assign)]
        MBDocumentFaceDetectorType Type { get; set; }

        // @property (assign, nonatomic) NSUInteger numStableDetectionsThreshold;
        [Export ("numStableDetectionsThreshold")]
        nuint NumStableDetectionsThreshold { get; set; }
    }

    // @interface MBUsdlRecognizerResult : MBRecognizerResult <NSCopying>
    
    [BaseType(typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBUsdlRecognizerResult : INSCopying
    {
        // -(NSData * _Nullable)data;
        [NullAllowed, Export("data")]
        NSData Data { get; }

        // -(BOOL)isUncertain;
        [Export("isUncertain")]
        bool IsUncertain { get; }

        // -(NSString * _Nullable)getField:(MBUsdlKeys)usdlKey;
        [Export("getField:")]
        [return: NullAllowed]
        string GetField(MBUsdlKeys usdlKey);

        // -(NSArray<NSString *> * _Nullable)optionalElements;
        [NullAllowed, Export("optionalElements")]
        string[] OptionalElements { get; }
    }

    // @interface MBUsdlRecognizer : MBRecognizer <NSCopying>
    
    [BaseType(typeof(MBRecognizer))]
    interface MBUsdlRecognizer : INSCopying
    {
        // @property (readonly, nonatomic, strong) MBUsdlRecognizerResult * _Nonnull result;
        [Export("result", ArgumentSemantic.Strong)]
        MBUsdlRecognizerResult Result { get; }

        // @property (assign, nonatomic) BOOL scanUncertain;
        [Export("scanUncertain")]
        bool ScanUncertain { get; set; }

        // @property (assign, nonatomic) BOOL allowNullQuietZone;
        [Export("allowNullQuietZone")]
        bool AllowNullQuietZone { get; set; }
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

    // @interface MBBarcodeOverlaySettings : MBBaseOverlaySettings
    
    [BaseType(typeof(MBBaseOverlaySettings))]
    interface MBBarcodeOverlaySettings
    {
        // @property (assign, nonatomic) BOOL displayBarcodeDots;
        [Export("displayBarcodeDots")]
        bool DisplayBarcodeDots { get; set; }

        // @property (assign, nonatomic) BOOL displayViewfinder;
        [Export("displayViewfinder")]
        bool DisplayViewfinder { get; set; }
    }

    // @interface MBBarcodeOverlayViewController : MBBaseOverlayViewController
    
    [BaseType(typeof(MBBaseOverlayViewController))]
    interface MBBarcodeOverlayViewController
    {
        // @property (readonly, nonatomic, strong) MBBarcodeOverlaySettings * _Nonnull settings;
        [Export("settings", ArgumentSemantic.Strong)]
        MBBarcodeOverlaySettings Settings { get; }

        [Wrap("WeakDelegate")]
        [NullAllowed]
        MBBarcodeOverlayViewControllerDelegate Delegate { get; }

        // @property (readonly, nonatomic, weak) id<MBBarcodeOverlayViewControllerDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; }

        // -(instancetype _Nonnull)initWithSettings:(MBBarcodeOverlaySettings * _Nonnull)settings recognizerCollection:(MBRecognizerCollection * _Nonnull)recognizerCollection delegate:(id<MBBarcodeOverlayViewControllerDelegate> _Nonnull)delegate;
        [Export("initWithSettings:recognizerCollection:delegate:")]
        IntPtr Constructor(MBBarcodeOverlaySettings settings, MBRecognizerCollection recognizerCollection, MBBarcodeOverlayViewControllerDelegate @delegate);
    }

    // @protocol MBBarcodeOverlayViewControllerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface MBBarcodeOverlayViewControllerDelegate
    {
        // @required -(void)barcodeOverlayViewControllerDidFinishScanning:(MBBarcodeOverlayViewController * _Nonnull)barcodeOverlayViewController state:(MBRecognizerResultState)state;
        [Abstract]
        [Export("barcodeOverlayViewControllerDidFinishScanning:state:")]
        void BarcodeOverlayViewControllerDidFinishScanning(MBBarcodeOverlayViewController barcodeOverlayViewController, MBRecognizerResultState state);

        // @required -(void)barcodeOverlayViewControllerDidTapClose:(MBBarcodeOverlayViewController * _Nonnull)barcodeOverlayViewController;
        [Abstract]
        [Export("barcodeOverlayViewControllerDidTapClose:")]
        void BarcodeOverlayViewControllerDidTapClose(MBBarcodeOverlayViewController barcodeOverlayViewController);
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

    // @protocol MBOcrLayoutSubview <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface IMBOcrLayoutSubview
    {
        // @required -(void)ocrLayoutObtained:(MBOcrLayout *)ocrLayout withIdentifier:(NSString *)identifier;
        [Abstract]
        [Export("ocrLayoutObtained:withIdentifier:")]
        void WithIdentifier(MBOcrLayout ocrLayout, string identifier);
    }

    // @interface MBDotsResultSubview : MBSubview <MBPointDetectorSubview, MBOcrLayoutSubview>
    
    [BaseType(typeof(MBSubview))]
    interface MBDotsResultSubview : IMBPointDetectorSubview, IMBOcrLayoutSubview
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

    // @protocol MBQuadDetectorSubview <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface IMBQuadDetectorSubview
    {
        // @required -(void)detectionFinishedWithDisplayableQuad:(MBDisplayableQuadDetection *)displayableQuadDetection;
        [Abstract]
        [Export("detectionFinishedWithDisplayableQuad:")]
        void DetectionFinishedWithDisplayableQuad(MBDisplayableQuadDetection displayableQuadDetection);
    }

    // @interface MBModernViewfinderSubview : MBSubview <MBQuadDetectorSubview>
    
    [BaseType(typeof(MBSubview))]
    interface MBModernViewfinderSubview : IMBQuadDetectorSubview
    {
        // @property (assign, nonatomic) BOOL moveable;
        [Export("moveable")]
        bool Moveable { get; set; }

        // @property (nonatomic) UIEdgeInsets portraitMargins;
        [Export("portraitMargins", ArgumentSemantic.Assign)]
        UIEdgeInsets PortraitMargins { get; set; }

        // @property (nonatomic) UIEdgeInsets landscapeMargins;
        [Export("landscapeMargins", ArgumentSemantic.Assign)]
        UIEdgeInsets LandscapeMargins { get; set; }

        // -(void)resetPositions;
        [Export("resetPositions")]
        void ResetPositions();
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

    // @interface MBScanElement : NSObject
    
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBScanElement
    {
        // -(instancetype _Nonnull)initWithIdentifier:(NSString * _Nonnull)identifier parser:(MBParser * _Nonnull)parser __attribute__((objc_designated_initializer));
        [Export("initWithIdentifier:parser:")]
        [DesignatedInitializer]
        IntPtr Constructor(string identifier, MBParser parser);

        // @property (readonly, nonatomic, strong) NSString * _Nonnull identifier;
        [Export("identifier", ArgumentSemantic.Strong)]
        string Identifier { get; }

        // @property (readonly, nonatomic, strong) MBParser * _Nonnull parser;
        [Export("parser", ArgumentSemantic.Strong)]
        MBParser Parser { get; }

        // @property (nonatomic, strong) NSString * _Nonnull localizedTitle;
        [Export("localizedTitle", ArgumentSemantic.Strong)]
        string LocalizedTitle { get; set; }

        // @property (nonatomic, strong) NSString * _Nonnull localizedTooltip;
        [Export("localizedTooltip", ArgumentSemantic.Strong)]
        string LocalizedTooltip { get; set; }

        // @property (assign, nonatomic) UIKeyboardType keyboardType;
        [Export("keyboardType", ArgumentSemantic.Assign)]
        UIKeyboardType KeyboardType { get; set; }

        // @property (nonatomic) NSString * _Nonnull localizedTextfieldText;
        [Export("localizedTextfieldText")]
        string LocalizedTextfieldText { get; set; }

        // @property (assign, nonatomic) BOOL scanned;
        [Export("scanned")]
        bool Scanned { get; set; }

        // @property (assign, nonatomic) BOOL edited;
        [Export("edited")]
        bool Edited { get; set; }

        // @property (nonatomic, strong) NSString * _Nonnull value;
        [Export("value", ArgumentSemantic.Strong)]
        string Value { get; set; }

        // @property (nonatomic) float scanningRegionWidth;
        [Export("scanningRegionWidth")]
        float ScanningRegionWidth { get; set; }

        // @property (nonatomic) float scanningRegionHeight;
        [Export("scanningRegionHeight")]
        float ScanningRegionHeight { get; set; }

        // @property (nonatomic) MBImage * _Nonnull successfulScanImage;
        [Export("successfulScanImage", ArgumentSemantic.Assign)]
        MBImage SuccessfulScanImage { get; set; }
    }

    // @interface MBFieldByFieldOverlaySettings : MBOverlaySettings
    
    [BaseType(typeof(MBOverlaySettings))]
    [DisableDefaultCtor]
    interface MBFieldByFieldOverlaySettings
    {
        // -(instancetype _Nonnull)initWithScanElements:(NSArray<MBScanElement *> * _Nonnull)scanElements __attribute__((objc_designated_initializer));
        [Export("initWithScanElements:")]
        [DesignatedInitializer]
        IntPtr Constructor(MBScanElement[] scanElements);

        // @property (readonly, nonatomic, strong) NSArray<MBScanElement *> * _Nonnull scanElements;
        [Export("scanElements", ArgumentSemantic.Strong)]
        MBScanElement[] ScanElements { get; }

        // @property (nonatomic) BOOL showOcrDots;
        [Export("showOcrDots")]
        bool ShowOcrDots { get; set; }

        // @property (nonatomic) BOOL outputSuccessfulImages;
        [Export("outputSuccessfulImages")]
        bool OutputSuccessfulImages { get; set; }

        // @property (nonatomic) NSUInteger consecutiveScanThreshold;
        [Export("consecutiveScanThreshold")]
        nuint ConsecutiveScanThreshold { get; set; }
    }

    // @interface MBFieldByFieldOverlayViewController : MBOverlayViewController
    
    [BaseType(typeof(MBOverlayViewController))]
    [DisableDefaultCtor]
    interface MBFieldByFieldOverlayViewController
    {
        // -(instancetype _Nonnull)initWithSettings:(MBFieldByFieldOverlaySettings * _Nonnull)settings delegate:(id<MBFieldByFieldOverlayViewControllerDelegate> _Nonnull)delegate __attribute__((objc_designated_initializer));
        [Export("initWithSettings:delegate:")]
        [DesignatedInitializer]
        IntPtr Constructor(MBFieldByFieldOverlaySettings settings, MBFieldByFieldOverlayViewControllerDelegate @delegate);

        [Wrap("WeakDelegate")]
        [NullAllowed]
        MBFieldByFieldOverlayViewControllerDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<MBFieldByFieldOverlayViewControllerDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }
    }

    // @protocol MBFieldByFieldOverlayViewControllerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface MBFieldByFieldOverlayViewControllerDelegate
    {
        // @required -(void)fieldByFieldOverlayViewControllerWillClose:(MBFieldByFieldOverlayViewController * _Nonnull)fieldByFieldOverlayViewController;
        [Abstract]
        [Export("fieldByFieldOverlayViewControllerWillClose:")]
        void FieldByFieldOverlayViewControllerWillClose(MBFieldByFieldOverlayViewController fieldByFieldOverlayViewController);

        // @required -(void)fieldByFieldOverlayViewController:(MBFieldByFieldOverlayViewController * _Nonnull)fieldByFieldOverlayViewController didFinishScanningWithElements:(NSArray<MBScanElement *> * _Nonnull)scanElements;
        [Abstract]
        [Export("fieldByFieldOverlayViewController:didFinishScanningWithElements:")]
        void FieldByFieldOverlayViewController(MBFieldByFieldOverlayViewController fieldByFieldOverlayViewController, MBScanElement[] scanElements);

        // @optional -(void)fieldByFieldOverlayViewControllerWillPresentHelp:(MBFieldByFieldOverlayViewController * _Nonnull)fieldByFieldOverlayViewController;
        [Export("fieldByFieldOverlayViewControllerWillPresentHelp:")]
        void FieldByFieldOverlayViewControllerWillPresentHelp(MBFieldByFieldOverlayViewController fieldByFieldOverlayViewController);

        // @optional -(void)fieldByFieldOverlayViewController:(MBFieldByFieldOverlayViewController * _Nonnull)fieldByFieldOverlayViewController didOutputCurrentImage:(MBImage * _Nonnull)currentImage;
        [Export("fieldByFieldOverlayViewController:didOutputCurrentImage:")]
        void FieldByFieldOverlayViewController(MBFieldByFieldOverlayViewController fieldByFieldOverlayViewController, MBImage currentImage);
    }

    // @interface MBOcrResultSubview : MBSubview <MBOcrLayoutSubview>
    
    [BaseType(typeof(MBSubview))]
    interface MBOcrResultSubview : IMBOcrLayoutSubview
    {
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

    // @interface MBBlinkCardOverlaySettings : MBBaseOcrOverlaySettings
    [iOS(8, 0)]
    [BaseType(typeof(MBBaseOcrOverlaySettings))]
    interface MBBlinkCardOverlaySettings
    {
        // @property (nonatomic, strong) NSString * _Nonnull glareStatusMessage;
        [Export("glareStatusMessage", ArgumentSemantic.Strong)]
        string GlareStatusMessage { get; set; }
    }

    // @interface MBBlinkCardOverlayViewController : MBBaseOverlayViewController
    [iOS(8, 0)]
    [BaseType(typeof(MBBaseOverlayViewController))]
    interface MBBlinkCardOverlayViewController
    {
        // @property (readonly, nonatomic, strong) MBBlinkCardOverlaySettings * _Nonnull settings;
        [Export("settings", ArgumentSemantic.Strong)]
        MBBlinkCardOverlaySettings Settings { get; }

        [Wrap("WeakDelegate")]
        [NullAllowed]
        MBBlinkCardOverlayViewControllerDelegate Delegate { get; }

        // @property (readonly, nonatomic, weak) id<MBBlinkCardOverlayViewControllerDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; }

        // -(instancetype _Nonnull)initWithSettings:(MBBlinkCardOverlaySettings * _Nonnull)settings recognizerCollection:(MBRecognizerCollection * _Nonnull)recognizerCollection delegate:(id<MBBlinkCardOverlayViewControllerDelegate> _Nonnull)delegate;
        [Export("initWithSettings:recognizerCollection:delegate:")]
        IntPtr Constructor(MBBlinkCardOverlaySettings settings, MBRecognizerCollection recognizerCollection, MBBlinkCardOverlayViewControllerDelegate @delegate);
    }

    // @protocol MBBlinkCardOverlayViewControllerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface MBBlinkCardOverlayViewControllerDelegate
    {
        // @required -(void)blinkCardOverlayViewControllerDidFinishScanning:(MBBlinkCardOverlayViewController * _Nonnull)blinkCardOverlayViewController state:(MBRecognizerResultState)state;
        [Abstract]
        [Export("blinkCardOverlayViewControllerDidFinishScanning:state:")]
        void BlinkCardOverlayViewControllerDidFinishScanning(MBBlinkCardOverlayViewController blinkCardOverlayViewController, MBRecognizerResultState state);

        // @required -(void)blinkCardOverlayViewControllerDidTapClose:(MBBlinkCardOverlayViewController * _Nonnull)blinkCardOverlayViewController;
        [Abstract]
        [Export("blinkCardOverlayViewControllerDidTapClose:")]
        void BlinkCardOverlayViewControllerDidTapClose(MBBlinkCardOverlayViewController blinkCardOverlayViewController);

        // @optional -(void)blinkCardOverlayViewControllerDidFinishScanningFirstSide:(MBBlinkCardOverlayViewController * _Nonnull)blinkCardOverlayViewController;
        [Export("blinkCardOverlayViewControllerDidFinishScanningFirstSide:")]
        void BlinkCardOverlayViewControllerDidFinishScanningFirstSide(MBBlinkCardOverlayViewController blinkCardOverlayViewController);
    }

    // @interface MBRectDocumentSubview : MBSubview
    [iOS(8, 0)]
    [BaseType(typeof(MBSubview))]
    [DisableDefaultCtor]
    interface MBRectDocumentSubview
    {
        // -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
        [Export("initWithFrame:")]
        [DesignatedInitializer]
        IntPtr Constructor(CGRect frame);

        // @property (nonatomic) CGFloat widthToHightAspectRatio;
        [Export("widthToHightAspectRatio")]
        nfloat WidthToHightAspectRatio { get; set; }

        // @property (nonatomic) NSString * _Nonnull titleText;
        [Export("titleText")]
        string TitleText { get; set; }

        // -(void)startScanLineAnimation;
        [Export("startScanLineAnimation")]
        void StartScanLineAnimation();

        // -(void)stopScanLineAnimation;
        [Export("stopScanLineAnimation")]
        void StopScanLineAnimation();

        // -(void)startFlipAnimation;
        [Export("startFlipAnimation")]
        void StartFlipAnimation();
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
