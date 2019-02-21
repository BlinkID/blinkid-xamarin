﻿namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Recognizer which can scan front side of Brunei Temporary Residence Permit.
    /// </summary>
    public interface IBruneiTemporaryResidencePermitFrontRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Defines whether glare detector is enabled. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool DetectGlare { get; set; }
        
        /// <summary>
        /// Defines if address of Brunei Temporary Residence Permit owner should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractAddress { get; set; }
        
        /// <summary>
        /// Defines if date of birth of Brunei Temporary Residence Permit owner should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfBirth { get; set; }
        
        /// <summary>
        /// Defines if full name of Brunei Temporary Residence Permit owner should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractFullName { get; set; }
        
        /// <summary>
        /// Defines if place of birth of Brunei Temporary Residence Permit owner should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractPlaceOfBirth { get; set; }
        
        /// <summary>
        /// Defines if sex of Brunei Temporary Residence Permit owner should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractSex { get; set; }
        
        /// <summary>
        /// The DPI (Dots Per Inch) for face image that should be returned. 
        ///
        /// By default, this is set to '250'
        /// </summary>
        uint FaceImageDpi { get; set; }
        
        /// <summary>
        /// The DPI (Dots Per Inch) for full document image that should be returned. 
        ///
        /// By default, this is set to '250'
        /// </summary>
        uint FullDocumentImageDpi { get; set; }
        
        /// <summary>
        /// The extension factors for full document image. 
        ///
        /// By default, this is set to '[0.0, 0.0, 0.0, 0.0]'
        /// </summary>
        IImageExtensionFactors FullDocumentImageExtensionFactors { get; set; }
        
        /// <summary>
        /// Defines whether face image will be available in result. 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ReturnFaceImage { get; set; }
        
        /// <summary>
        /// Defines whether full document image will be available in 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ReturnFullDocumentImage { get; set; }
        

        /// <summary>
        /// Gets the result.
        /// </summary>
        IBruneiTemporaryResidencePermitFrontRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for IBruneiTemporaryResidencePermitFrontRecognizer.
    /// </summary>
    public interface IBruneiTemporaryResidencePermitFrontRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The address of Brunei Temporary Residence Permit owner. 
        /// </summary>
        string Address { get; }
        
        /// <summary>
        /// The date of birth of Brunei Temporary Residence Permit owner. 
        /// </summary>
        IDate DateOfBirth { get; }
        
        /// <summary>
        /// The document number of Brunei Temporary Residence Permit. 
        /// </summary>
        string DocumentNumber { get; }
        
        /// <summary>
        /// Face image from the document 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        /// Image of the full document 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// The full name of Brunei Temporary Residence Permit owner. 
        /// </summary>
        string FullName { get; }
        
        /// <summary>
        /// The place of birth of Brunei Temporary Residence Permit owner. 
        /// </summary>
        string PlaceOfBirth { get; }
        
        /// <summary>
        /// The sex of Brunei Temporary Residence Permit owner. 
        /// </summary>
        string Sex { get; }
        
    }
}