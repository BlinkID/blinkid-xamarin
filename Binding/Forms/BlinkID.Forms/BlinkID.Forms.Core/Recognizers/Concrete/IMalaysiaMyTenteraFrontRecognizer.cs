namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Recognizer which can scan front side of Malaysian MyTentera cards.
    /// </summary>
    public interface IMalaysiaMyTenteraFrontRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Defines whether glare detector is enabled. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool DetectGlare { get; set; }
        
        /// <summary>
        /// Defines if full name and address of Malaysian MyTentera owner should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractFullNameAndAddress { get; set; }
        
        /// <summary>
        /// Defines if religion of Malaysian MyTentera owner should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractReligion { get; set; }
        
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
        IMalaysiaMyTenteraFrontRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for IMalaysiaMyTenteraFrontRecognizer.
    /// </summary>
    public interface IMalaysiaMyTenteraFrontRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The army number of Malaysian MyTentera owner. 
        /// </summary>
        string ArmyNumber { get; }
        
        /// <summary>
        /// The birth date of Malaysian MyTentera owner. 
        /// </summary>
        IDate BirthDate { get; }
        
        /// <summary>
        /// The city of Malaysian MyTentera owner. 
        /// </summary>
        string City { get; }
        
        /// <summary>
        /// Face image from the document 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        /// The address of Malaysian MyTentera owner. 
        /// </summary>
        string FullAddress { get; }
        
        /// <summary>
        /// Image of the full document 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// The full name of Malaysian MyTentera owner. 
        /// </summary>
        string FullName { get; }
        
        /// <summary>
        /// The nric of Malaysian MyTentera. 
        /// </summary>
        string Nric { get; }
        
        /// <summary>
        /// The state of Malaysian MyTentera owner. 
        /// </summary>
        string OwnerState { get; }
        
        /// <summary>
        /// The religion of Malaysian MyTentera owner. 
        /// </summary>
        string Religion { get; }
        
        /// <summary>
        /// The sex of Malaysian MyTentera owner. 
        /// </summary>
        string Sex { get; }
        
        /// <summary>
        /// The street of Malaysian MyTentera owner. 
        /// </summary>
        string Street { get; }
        
        /// <summary>
        /// The zipcode of Malaysian MyTentera owner. 
        /// </summary>
        string Zipcode { get; }
        
    }
}