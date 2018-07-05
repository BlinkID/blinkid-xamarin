namespace Microblink.Forms.Core.Recognizers
{
    public interface IMyKadFrontRecognizer : IRecognizer
    {
        
        /// <summary>
        /// true if army number of Malaysian MyTentera owner is being extracted 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ExtractArmyNumber { get; set; }
        
        /// <summary>
        /// Defines the DPI (Dots Per Inch) for full document image that should be returned. 
        ///
        /// By default, this is set to '250'
        /// </summary>
        uint FullDocumentImageDpi { get; set; }
        
        /// <summary>
        /// Defines whether face image will be available in result. 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ReturnFaceImage { get; set; }
        
        /// <summary>
        /// Defines whether full document image will be available in result. 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ReturnFullDocumentImage { get; set; }
        

        /// <summary>
        /// Gets the result.
        /// </summary>
        IMyKadFrontRecognizerResult Result { get; }
    }

    public interface IMyKadFrontRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// owner army number if written on MyTentera 
        /// </summary>
        string ArmyNumber { get; }
        
        /// <summary>
        ///  face image from the document 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        ///  image of the full document 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// NRIC number (National Registration Identity Card Number) 
        /// </summary>
        string NricNumber { get; }
        
        /// <summary>
        /// full owner address. 
        /// </summary>
        string OwnerAddress { get; }
        
        /// <summary>
        /// extracted city from the owner address. 
        /// </summary>
        string OwnerAddressCity { get; }
        
        /// <summary>
        /// extracted state from the owner address. 
        /// </summary>
        string OwnerAddressState { get; }
        
        /// <summary>
        /// extracted street from the owner address. 
        /// </summary>
        string OwnerAddressStreet { get; }
        
        /// <summary>
        /// extracted ZIP code from the owner address. 
        /// </summary>
        string OwnerAddressZipCode { get; }
        
        /// <summary>
        /// owner's date of birth if it is successfully converted to {Date} from date format: <code>YYMMDD</code>. 
        /// </summary>
        IDate OwnerBirthDate { get; }
        
        /// <summary>
        /// owner full name 
        /// </summary>
        string OwnerFullName { get; }
        
        /// <summary>
        /// owner religion if written on MyKad 
        /// </summary>
        string OwnerReligion { get; }
        
        /// <summary>
        /// owner sex (M for male, F for female) 
        /// </summary>
        string OwnerSex { get; }
        
    }
}