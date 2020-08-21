find . -iname "bin"
find . -iname "obj"
find . -iname "packages"
find . -iname "bin" | xargs rm -rf
find . -iname "obj" | xargs rm -rf
find . -iname "packages" | xargs rm -rf