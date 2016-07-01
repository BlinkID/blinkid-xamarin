set -e
set +u

LIB_TARGET_NAME=$1
LIB_PRODUCT_NAME=$2

LIB_FRAMEWORK_NAME="$LIB_PRODUCT_NAME.framework"
LIB_PRODUCT_PATH="${LIB_FRAMEWORK_NAME}/${LIB_PRODUCT_NAME}"

if [[ "$SDK_NAME" =~ ([A-Za-z]+) ]]
then
SF_SDK_PLATFORM=${BASH_REMATCH[1]}
else
echo "Could not find platform name from SDK_NAME: $SDK_NAME"
exit 1
fi

if [[ "$SDK_NAME" =~ ([0-9]+.*$) ]]
then
SF_SDK_VERSION=${BASH_REMATCH[1]}
else
echo "Could not find sdk version from SDK_NAME: $SDK_NAME"
exit 1
fi

if [[ "$SF_SDK_PLATFORM" = "iphoneos" ]]
then
SF_OTHER_PLATFORM=iphonesimulator
else
SF_OTHER_PLATFORM=iphoneos
fi

if [[ "$BUILT_PRODUCTS_DIR" =~ (.*)$SF_SDK_PLATFORM$ ]]
then
SF_OTHER_BUILT_PRODUCTS_DIR="${BASH_REMATCH[1]}${SF_OTHER_PLATFORM}"
else
echo "Could not find platform name from build products directory: $BUILT_PRODUCTS_DIR"
exit 1
fi

PROD="${BUILT_PRODUCTS_DIR}/${LIB_PRODUCT_PATH}"
OTHER_PROD="${SF_OTHER_BUILT_PRODUCTS_DIR}/${LIB_PRODUCT_PATH}"

echo "BUILD_DIR: ${BUILD_DIR}"
echo "OBJROOT: ${OBJROOT}"
echo "BUILD_ROOT: ${BUILD_ROOT}"
echo "SYMROOT: ${SYMROOT}"

echo "Build started"

# Build the other platform.
xcrun xcodebuild -project "${PROJECT_FILE_PATH}" -target "${LIB_TARGET_NAME}" -configuration "${CONFIGURATION}" -sdk ${SF_OTHER_PLATFORM}${SF_SDK_VERSION} BUILD_DIR="${BUILD_DIR}" OBJROOT="${OBJROOT}" BUILD_ROOT="${BUILD_ROOT}" SYMROOT="${SYMROOT}" $ACTION

echo "Build completed"

echo "Smashing two architectures together"

set +e

xcrun lipo "$PROD" -verify_arch i386

if [ $? == 0 ] ; then
    
    xcrun lipo "$PROD" -verify_arch armv7
    
    if [ $? == 0 ] ; then
        echo "Built previously"
    else
        
        echo "Missing ARM build"
        
        # Smash the two static libraries into one fat binary and store it in the .framework
        xcrun lipo -create "$PROD" "$OTHER_PROD" -output "$PROD"
    fi
else
    
    echo "Missing Simulator build"
    
    # Smash the two static libraries into one fat binary and store it in the .framework
    xcrun lipo -create "$PROD" "$OTHER_PROD" -output "$PROD"
fi

set -e

# Copy the binary to the other architecture folder to have a complete framework in both.
cp -a "$PROD" "$OTHER_PROD"