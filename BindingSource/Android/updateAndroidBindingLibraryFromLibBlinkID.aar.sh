#!/bin/sh
#
# Usage: ./BindingSource/Android/updateAndroidBindingLibraryFromLibBlinkID.aar.sh PATH_TO_ANDROID_BINDING_PROJECT_DIRECTORY URL_TO_LIBBLINKID_AAR_FILE
#
# Example: FROM specific release TAG
# ./BindingSource/Android/updateAndroidBindingLibraryFromLibBlinkID.aar.sh ./Binding/Android/ https://github.com/BlinkID/blinkid-android/blob/v3.2.0/LibBlinkID.aar?raw=true
#
# Example: FROM master branch
# ./BindingSource/Android/updateAndroidBindingLibraryFromLibBlinkID.aar.sh ./Binding/Android/ https://github.com/BlinkID/blinkid-android/blob/master/LibBlinkID.aar?raw=true
#
# Example: FROM specific commit
# ./BindingSource/Android/updateAndroidBindingLibraryFromLibBlinkID.aar.sh ./Binding/Android/ https://github.com/BlinkID/blinkid-android/blob/555fef6b277ffba49b2c90934b14b076a051baf8/LibBlinkID.aar?raw=true

# First parameter should be path to the Android Binding Library project
ANDROID_BINDING_PROJECT_DIRECTORY=$1
# Remove trailling slash
ANDROID_BINDING_PROJECT_DIRECTORY=${ANDROID_BINDING_PROJECT_DIRECTORY%/}

URL_TO_LIBBLINKID_AAR_FILE=$2

pwd=$(pwd)
tempDir="LibBlinkIDTemp"

echo "Clean before"
rm -rf LibBlinkID.aar
rm -rf $tempDir

echo "Download"
wget $URL_TO_LIBBLINKID_AAR_FILE

# Extract to directory
echo "Extract"
unzip LibBlinkID.aar -d $tempDir

echo "Update with new files"
if [ "${ANDROID_BINDING_PROJECT_DIRECTORY:0:1}" = "/" ]; then
  path="$ANDROID_BINDING_PROJECT_DIRECTORY"
else
  path="$pwd/$ANDROID_BINDING_PROJECT_DIRECTORY"
fi

cp -Rv "$tempDir/jni" "$path/lib"
mkdir -p "$path/Jars"
cp -Rv "$tempDir/classes.jar" "$path/Jars/classes.jar"

echo "Clean after"
rm -rf LibBlinkID.aar
rm -rf $tempDir

