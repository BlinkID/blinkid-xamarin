## 1.3

### Android

Unchanged since 1.0, same features like iOS 1.3 will be in upcoming release

### iOS

- iOS wrapper upgrade to blinkid-ios [2.15.0](https://github.com/BlinkID/blinkid-ios/releases/tag/v2.15.0)

- Updates and additions
    - added support for reading Malaysian MyTentera documents - use `AddMyTenteraRecognizer`
    - added support for reading Indonesian ID documents - use `AddIndonesianIDFrontRecognizer`
    - added support for reading Polish ID documents - use `AddPolishIDFrontRecognizer` and `AddPolishIDBackRecognizer`
    - added support for reading Australian Drivers License - use `AddAustraliaDLFrontRecognizer` and `AddAustraliaDLBackRecognizer`
    - added support for Combined recognizers - use `AddMrtdCombinedRecognizer`, `AddCroCombinedRecognizer`, `AddCzCombinedRecognizer`, `AddGerCombinedRecognizer`, `AddAusIDCombinedRecognizer`, `AddSerbIDCombinedRecognizer`, `AddSlovakCombinedRecognizer`, `AddPolishIDCombinedRecognizer`, `AddSingaporeCombinedRecognizer`, `AddSlovenianCombinedRecognizer`

- Bugfixes
    - fixed crash in `AddIdCardDetector`

## 1.2

- iOS wrapper upgrade to blinkid-ios [2.13.0](https://github.com/BlinkID/blinkid-ios/releases/tag/v2.13.0)

### Fixes

- Barcode recognizers: `BarDecoder`, `ZXing` and `Barcode` has settings for barcodes recognizing.

## 1.1

- iOS wrapper upgrade to blinkid-ios [2.11.0](https://github.com/BlinkID/blinkid-ios/releases/tag/v2.11.0)

### API changes

- Removed: `AddGerMrzRecognizer`
- Deprecated: `AddBarDecoderRecognizer`, `AddZXingRecognizer`
- Added: `AddAusPassportRecognizer`, `AddBarcodeRecognizer`, `AddGerIDOldRecognizer`, `AddGerPassportRecognizer`, `AddSwissPassportRecognizer`, `AddVinRecognizer`

### Fixes

- MRTD result - returned old items: `DateOfBirth` and `DateOfExpiry` as RAW OCR string

## 1.0

- First official version. 
- BlinkID-xamarin wraps BlinkID-ios native SDK at version [2.7.1](https://github.com/BlinkID/blinkid-ios/releases/tag/v2.7.1), and BlinkID-android at version [3.2.0](https://github.com/BlinkID/blinkid-android/releases/tag/v3.2.0)
