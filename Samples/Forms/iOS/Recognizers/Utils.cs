using UIKit;
using Xamarin.Forms;
namespace BlinkIDFormsSample.iOS.Recognizers
{
    public abstract class Utils
    {
        public static ImageSource ConvertUIImage(UIImage uiImage) 
        {
            // TODO: find a more efficient way to convert bitmap without compressing to and decompressing from PNG
            return ImageSource.FromStream(() => uiImage.AsPNG().AsStream());
        }
    }
}
