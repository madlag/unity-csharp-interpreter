SRC=/Applications/Unity/Hub/Editor/2019.1.0a9/Unity.app/Contents/MonoBleedingEdge/lib/mono/
DEST=./Assets/dlls

cp $SRC/4.5/Microsoft.CodeAnalysis.Scripting.dll $DEST
cp $SRC/4.5/Microsoft.CodeAnalysis.dll $DEST
cp $SRC/4.5/System.Reflection.Metadata.dll $DEST
cp $SRC/4.5/Microsoft.CodeAnalysis.CSharp.dll $DEST
cp $SRC/4.5/System.Collections.Immutable.dll $DEST
cp $SRC/4.5/Microsoft.CodeAnalysis.CSharp.Scripting.dll $DEST
cp $SRC/unityaot/Facades/System.Runtime.Loader.dll $DEST
cp $SRC/unityjit/Microsoft.CSharp.dll $DEST
