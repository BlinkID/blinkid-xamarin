find . -iname "bin"
find . -iname "obj"
find . -iname "bin" | xargs rm -rf
find . -iname "obj" | xargs rm -rf