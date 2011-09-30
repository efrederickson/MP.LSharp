using System;
using System.CodeDom.Compiler;
using System.IO;

namespace LSharp.CodeDom
{
    /// <summary>
    /// Summary description for LSharpCodeProvider.
    /// </summary>
    public class LSharpCodeProvider : CodeDomProvider
    {
        public LSharpCodeProvider()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public override ICodeCompiler CreateCompiler() 
        {
            throw new NotImplementedException();
        }


        public override ICodeGenerator CreateGenerator() 
        {
        	return new LSharpCodeGenerator();
        }

        public override ICodeGenerator CreateGenerator(string s) 
        {
            throw new NotImplementedException();
        }

        public override ICodeGenerator CreateGenerator(TextWriter t) 
        {
            throw new NotImplementedException();
        }
    }
}
