namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Class for configuring My Kad Front Recognizer.
    /// 
    /// My Kad Front recognizer is used for scanning front side of My Kad.
    /// </summary>
    public interface IMyKadFrontRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Defines if army number should be extracted from MyTentera documents with MyKadRecognizer
        /// 
        ///  
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ExtractArmyNumber { get; set; }
        
        /// <summary>
        /// Property for setting DPI for full document images
        /// Valid ranges are [100,400]. Setting DPI out of valid ranges throws an exception
        /// 
        ///  
        ///
        /// By default, this is set to '250'
        /// </summary>
        uint FullDocumentImageDpi { get; set; }
        
        /// <summary>
        /// Sets whether face image from ID card should be extracted
        /// 
        ///  
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ReturnFaceImage { get; set; }
        
        /// <summary>
        /// Sets whether full document image of ID card should be extracted.
        /// 
        ///  
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ReturnFullDocumentImage { get; set; }
        

        /// <summary>
        /// Gets the result.
        /// </summary>
        IMyKadFrontRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for IMyKadFrontRecognizer.
    /// </summary>
    public interface IMyKadFrontRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// Owner army number on MyTentera documents 
        /// </summary>
        string ArmyNumber { get; }
        
        /// <summary>
        /// face image from the document if enabled with returnFaceImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        /// full document image if enabled with returnFullDocumentImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// NRIC number (National Registration Identity Card Number)
        /// 
        ///  @see https://en.wikipedia.org/wiki/Malaysian_identity_card#Structure_of_the_National_Registration_Identity_Card_Number_.28NRIC.29 
        /// </summary>
        string NricNumber { get; }
        
        /// <summary>
        /// Owner address 
        /// </summary>
        string OwnerAddress { get; }
        
        /// <summary>
        /// Owner address city. Determined from owner address. 
        /// </summary>
        string OwnerAddressCity { get; }
        
        /// <summary>
        /// Owner address state. Determined from owner address. 
        /// </summary>
        string OwnerAddressState { get; }
        
        /// <summary>
        /// Owner street. Determined from owner address. 
        /// </summary>
        string OwnerAddressStreet { get; }
        
        /// <summary>
        /// Owner address Zip code. Determined from owner address. 
        /// </summary>
        string OwnerAddressZipCode { get; }
        
        /// <summary>
        /// Owner birth date converted in NSDate object 
        /// </summary>
        IDate OwnerBirthDate { get; }
        
        /// <summary>
        /// Owner full name 
        /// </summary>
        string OwnerFullName { get; }
        
        /// <summary>
        /// Owner religion if written on MyKad 
        /// </summary>
        string OwnerReligion { get; }
        
        /// <summary>
        /// Owner sex (M for male, F for female) 
        /// </summary>
        string OwnerSex { get; }
        
    }
}