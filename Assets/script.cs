/*using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.Loader;
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Emit;
using Microsoft.CodeAnalysis.Scripting;

using UnityEngine;

public class script : MonoBehaviour {

    static void test() {
        // From http://www.tugberkugurlu.com/archive/compiling-c-sharp-code-into-memory-and-executing-it-with-roslyn

        SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(@"
using System;
using UnityEngine;

namespace RoslynCompileSample {
    public class Writer {
        public void Write(string message) {
            Debug.Log(message);
                var objToSpawn = new GameObject(""New GameObject created from interpreted code"");
        }
    }
}");
        // Name of the assembly. Should be different if you have to load several ones
        string assemblyName = "assembly";
        // References the needed packages (System, UnityEngine)
        MetadataReference[] references = new MetadataReference[] {
            MetadataReference.CreateFromFile(typeof(object).Assembly.Location),
            MetadataReference.CreateFromFile(typeof(GameObject).Assembly.Location)
        };

        // Compile code
        CSharpCompilation compilation = CSharpCompilation.Create(assemblyName,
                                                                 syntaxTrees: new[] { syntaxTree },
                                                                 references: references,
                                                                 options: new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

        // Emit the compilation to an assembly object
        using (var ms = new System.IO.MemoryStream())
        {
            EmitResult result = compilation.Emit(ms);

            if (!result.Success)
            {
                Debug.Log("Got an Error");
                IEnumerable<Diagnostic> failures = result.Diagnostics;
                foreach (Diagnostic diagnostic in failures)
                {
                    Debug.Log(System.String.Format("ERROR : {0}: {1}", diagnostic.Id, diagnostic.GetMessage()));
                }
            } else {
                ms.Seek(0, System.IO.SeekOrigin.Begin);
                Assembly assembly = Assembly.Load(ms.ToArray());

                Type type = assembly.GetType("RoslynCompileSample.Writer"); // Get the class in assembly
                object obj = Activator.CreateInstance(type); // Create an instance of Writer
                type.InvokeMember("Write",  // Function to call
                                  BindingFlags.Default | BindingFlags.InvokeMethod,
                                  null,
                                  obj,
                                  new object[] { "Hello World" }); // Parameter
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        test();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
