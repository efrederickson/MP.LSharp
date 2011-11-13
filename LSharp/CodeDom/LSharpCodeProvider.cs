using System;
using System.CodeDom.Compiler;
using System.IO;

namespace LSharp.CodeDom
{
    /// <summary>
    /// Basic wrapper for LSharpCodeDom. Not yet finished
    /// </summary>
    public class LSharpCodeProvider : CodeDomProvider
    {
        public LSharpCodeProvider()
        {
        }

        public override ICodeCompiler CreateCompiler() 
        {
            return new LSharpCodeCompiler();
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
