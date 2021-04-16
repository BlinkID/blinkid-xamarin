using BlinkID.Forms.iOS.Recognizers;
using BlinkID.Forms.Core.Recognizers;
using BlinkID;

[assembly: Xamarin.Forms.Dependency(typeof(RecognizerCollectionFactory))]
namespace BlinkID.Forms.iOS.Recognizers
{
    public class RecognizerCollection : IRecognizerCollection
    {
        public MBRecognizerCollection NativeRecognizerCollection { get; }

        IRecognizer[] recognizers;

        public RecognizerCollection(IRecognizer[] recognizers)
        {
            this.recognizers = recognizers;
            MBRecognizer[] nativeRecognizers = new MBRecognizer[recognizers.Length];
            for (int i = 0; i < recognizers.Length; ++i)
            {
                nativeRecognizers[i] = ((Recognizer)recognizers[i]).NativeRecognizer;
            }
            NativeRecognizerCollection = new MBRecognizerCollection(nativeRecognizers);
        }

        public bool AllowMultipleResults
        {
            get => NativeRecognizerCollection.AllowMultipleResults;
            set => NativeRecognizerCollection.AllowMultipleResults = value;
        }

        public uint MilisecondsBeforeTimeout 
        {
            get => (uint) (NativeRecognizerCollection.PartialRecognitionTimeout * 1000.0);
            set => NativeRecognizerCollection.PartialRecognitionTimeout = (double) value/1000.0;
        }

        public IRecognizer[] Recognizers => recognizers;
    }

    public class RecognizerCollectionFactory : IRecognizerCollectionFactory
    {
        public IRecognizerCollection CreateRecognizerCollection(params IRecognizer[] recognizers)
        {
            return new RecognizerCollection(recognizers);
        }
    }
}