#!/bin/sh
#
# Usage: ./BindingSource/Android/updateAndroidBindingLibraryFromLibRecognizer.aar.sh PATH_TO_ANDROID_BINDING_PROJECT_DIRECTORY URL_TO_LIBRECOGNIZER
# Example: ./BindingSource/Android/updateAndroidBindingLibraryFromLibRecognizer.aar.sh ./Binding/Android/ https://github.com/BlinkID/blinkid-android/blob/master/LibRecognizer.aar?raw=true

# First parameter should be path to the Android Binding Library project
ANDROID_BINDING_PROJECT_DIRECTORY=$1
# Remove trailling slash
ANDROID_BINDING_PROJECT_DIRECTORY=${ANDROID_BINDING_PROJECT_DIRECTORY%/}

URL_TO_LIBRECOGNIZER=$2

pwd=$(pwd)
tempDir="LibRecognizerTemp"

echo "Clean before"
rm -rf LibRecognizer.aar
rm -rf $tempDir

echo "Download"
wget $URL_TO_LIBRECOGNIZER

# Extract to directory
echo "Extract"
unzip LibRecognizer.aar -d $tempDir

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
rm -rf LibRecognizer.aar
rm -rf $tempDir

