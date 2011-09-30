using System;
using ICSharpCode.SharpDevelop.Dom;
using ICSharpCode.SharpDevelop.Dom.Refactoring;

namespace LSharp.SharpDevelop.AddIn
{
	public class LSharpLanguageProperties : LanguageProperties
	{
		public readonly static LSharpLanguageProperties Instance = new LSharpLanguageProperties();
		
		public LSharpLanguageProperties() : base(StringComparer.InvariantCulture) {}
		
		public override bool SupportsExtensionMethods {
			get {
				return true;
			}
		}
		
		public override bool ImportNamespaces {
			get {
				return true;
			}
		}
		
		public override bool ImportModules {
			get {
				return true;
			}
		}
		
		public override bool CanImportClasses {
			get {
				return true;
			}
		}
		
		public override bool AllowObjectConstructionOutsideContext {
			get {
				return true;
			}
		}
		
		public override bool SupportsImplicitInterfaceImplementation {
			get {
				return false;
			}
		}
		
		public override System.CodeDom.Compiler.CodeDomProvider CodeDomProvider {
			get {
				return new LSharp.CodeDom.LSharpCodeProvider();
			}
		}
	}
}
