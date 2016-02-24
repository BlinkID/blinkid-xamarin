using ObjCRuntime;

[assembly: LinkWith ("BlinkID.a", SmartLink = true, ForceLoad = true, IsCxx = true, Frameworks = "AVFoundation QuartzCore CoreVideo AudioToolbox Accelerate CoreMedia OpenGLES")]
