using System;
using System.CodeDom;
using System.CodeDom.Compiler;

namespace LSharp.CodeDom
{
	
	public class LSharpCodeGenerator : CodeGenerator
	{	
		protected override string CreateEscapedIdentifier(string value)
		{
			return "\\" + value;
		}

		protected override string CreateValidIdentifier(string value)
		{
			if (IsValidIdentifier(value))
				return value;
			else
				return "_" + value + "_";
		}

		protected override void GenerateArgumentReferenceExpression(System.CodeDom.CodeArgumentReferenceExpression e)
		{
            throw new NotImplementedException();
		}

		protected override void GenerateArrayCreateExpression(System.CodeDom.CodeArrayCreateExpression e)
		{
		    this.Output.Write("(= " + "[array] '(");
		    foreach (CodeExpression cd in e.Initializers)
		        this.Output.Write(cd.ToString() + " ");
		    this.Output.WriteLine("))");
		}

		protected override void GenerateArrayIndexerExpression(System.CodeDom.CodeArrayIndexerExpression e)
		{
		    this.Output.WriteLine("(item " + e.TargetObject.ToString() + " " + e.Indices[0].ToString());
		}

		protected override void GenerateAssignStatement(System.CodeDom.CodeAssignStatement e)
		{
			this.Output.WriteLine("(= " + e.Left + " " + e.Right + ")");
		}

		protected override void GenerateAttachEventStatement(System.CodeDom.CodeAttachEventStatement e)
		{
		    this.Output.Write("(defevent " + e.Event.EventName + " " + e.Event.TargetObject + " ");
		    this.Output.Write(e.Listener.ToString());
		    this.Output.WriteLine(")");
            //FIXME
		}

		protected override void GenerateAttributeDeclarationsEnd(System.CodeDom.CodeAttributeDeclarationCollection attributes)
		{
            throw new NotImplementedException();
		}

		protected override void GenerateAttributeDeclarationsStart(System.CodeDom.CodeAttributeDeclarationCollection attributes)
		{
            throw new NotImplementedException();
		}

		protected override void GenerateBaseReferenceExpression(System.CodeDom.CodeBaseReferenceExpression e)
		{
            throw new NotImplementedException();
		}

		protected override void GenerateCastExpression(System.CodeDom.CodeCastExpression e)
		{
			this.Output.WriteLine("(coerce " + e.Expression + " " + e.TargetType + ")");
		}

		protected override void GenerateComment(System.CodeDom.CodeComment e)
		{
			this.Output.WriteLine("; {0}",e.Text);
		}

        protected override void GenerateCommentStatement(CodeCommentStatement e)
        {
            this.Output.WriteLine("; " + e.Comment);
        }
        
        protected override void GenerateCommentStatements(CodeCommentStatementCollection e)
        {
            foreach (CodeCommentStatement ccs in e)
                GenerateCommentStatement(ccs);
        }

		protected override void GenerateConditionStatement(System.CodeDom.CodeConditionStatement e)
		{
		    this.Output.WriteLine(";;; Create an if-then-else statement");
			this.Output.Write("(if " + e.Condition.ToString() + " ");
			GenerateStatements(e.TrueStatements);
			this.Output.Write(" ");
			GenerateStatements(e.FalseStatements);
            throw new NotImplementedException();
		}

		protected override void GenerateConstructor(System.CodeDom.CodeConstructor e, System.CodeDom.CodeTypeDeclaration c)
		{
		    throw new NotImplementedException();
		}

		protected override void GenerateDelegateCreateExpression(System.CodeDom.CodeDelegateCreateExpression e)
		{
            throw new NotImplementedException();
		}

		protected override void GenerateDelegateInvokeExpression(System.CodeDom.CodeDelegateInvokeExpression e)
		{
		    this.Output.WriteLine(";;; Invoke a member");
		    this.Output.Write("(" + e.TargetObject + " ");
		    foreach (CodeExpression cd in e.Parameters)
		        this.Output.Write(cd.ToString() + " ");
		    this.Output.WriteLine(")");
            throw new NotImplementedException();
		}

		protected override void GenerateEntryPointMethod(System.CodeDom.CodeEntryPointMethod e, System.CodeDom.CodeTypeDeclaration c)
		{
		    this.Output.WriteLine(";;; Entry point methods dont matter in L#");
		}

		protected override void GenerateEvent(System.CodeDom.CodeMemberEvent e, System.CodeDom.CodeTypeDeclaration c)
		{
		    this.Output.WriteLine(";;; Define an event handler");
		    this.Output.WriteLine("(defevent " + e.Name + " " + e.Type + " " + "<CODE>" + ")");
		}

		protected override void GenerateEventReferenceExpression(System.CodeDom.CodeEventReferenceExpression e)
		{
            throw new NotImplementedException();
		}

		protected override void GenerateExpressionStatement(System.CodeDom.CodeExpressionStatement e)
		{
			throw new NotImplementedException();
		}

		protected override void GenerateField(System.CodeDom.CodeMemberField e)
		{
			throw new NotImplementedException();
		}

		protected override void GenerateFieldReferenceExpression(System.CodeDom.CodeFieldReferenceExpression e)
		{
			throw new NotImplementedException();
		}

		protected override void GenerateGotoStatement(System.CodeDom.CodeGotoStatement e)
		{
			throw new NotImplementedException();
		}

		protected override void GenerateIndexerExpression(System.CodeDom.CodeIndexerExpression e)
		{
			throw new NotImplementedException();
		}

		protected override void GenerateIterationStatement(System.CodeDom.CodeIterationStatement e)
		{
			throw new NotImplementedException();
		}

		protected override void GenerateLabeledStatement(System.CodeDom.CodeLabeledStatement e)
		{
			throw new NotImplementedException();
		}

		protected override void GenerateLinePragmaEnd(System.CodeDom.CodeLinePragma e)
		{
			throw new NotImplementedException();
		}

		protected override void GenerateLinePragmaStart(System.CodeDom.CodeLinePragma e)
		{
			throw new NotImplementedException();
		}

		protected override void GenerateMethod(System.CodeDom.CodeMemberMethod e, System.CodeDom.CodeTypeDeclaration c)
		{
            GenerateCommentStatements(e.Comments);
            this.Output.Write("(defun " + e.Name + " (");
            foreach (CodeParameterDeclarationExpression p in e.Parameters)
            	this.Output.Write(p.Name + " ");
            this.Output.Write(") ");
            foreach (CodeStatement s in e.Statements)
            	GenerateStatement(s);
            this.Output.WriteLine(")");
		}

		protected override void GenerateMethodInvokeExpression(System.CodeDom.CodeMethodInvokeExpression e)
		{
			throw new NotImplementedException();
		}

		protected override void GenerateMethodReferenceExpression(System.CodeDom.CodeMethodReferenceExpression e)
		{
			throw new NotImplementedException();
		}

		protected override void GenerateMethodReturnStatement(System.CodeDom.CodeMethodReturnStatement e)
		{
			throw new NotImplementedException();
		}

		protected override void GenerateNamespaceEnd(System.CodeDom.CodeNamespace e)
		{
			throw new NotImplementedException();
		}

		protected override void GenerateNamespaceImport(System.CodeDom.CodeNamespaceImport e)
		{
            this.Output.WriteLine("(using \"" + e.Namespace + "\")");
		}

		protected override void GenerateNamespaceStart(System.CodeDom.CodeNamespace e)
		{
			throw new NotImplementedException();
		}

		protected override void GenerateObjectCreateExpression(System.CodeDom.CodeObjectCreateExpression e)
		{
			throw new NotImplementedException();
		}

		protected override void GenerateProperty(System.CodeDom.CodeMemberProperty e, System.CodeDom.CodeTypeDeclaration c)
		{
			throw new NotImplementedException();
		}

		protected override void GeneratePropertyReferenceExpression(System.CodeDom.CodePropertyReferenceExpression e)
		{
			throw new NotImplementedException();
		}

		protected override void GeneratePropertySetValueReferenceExpression(System.CodeDom.CodePropertySetValueReferenceExpression e)
		{
			throw new NotImplementedException();
		}

		protected override void GenerateRemoveEventStatement(System.CodeDom.CodeRemoveEventStatement e)
		{
			throw new NotImplementedException();
		}

		protected override void GenerateSnippetExpression(System.CodeDom.CodeSnippetExpression e)
		{
			throw new NotImplementedException();
		}

		protected override void GenerateSnippetMember(System.CodeDom.CodeSnippetTypeMember e)
		{
			throw new NotImplementedException();
		}
		
		protected override void GenerateThisReferenceExpression(System.CodeDom.CodeThisReferenceExpression e)
		{
			throw new NotImplementedException();
		}

		protected override void GenerateThrowExceptionStatement(System.CodeDom.CodeThrowExceptionStatement e)
		{
			throw new NotImplementedException();
		}

		protected override void GenerateTryCatchFinallyStatement(System.CodeDom.CodeTryCatchFinallyStatement e)
		{
			throw new NotImplementedException();
		}

		protected override void GenerateTypeConstructor(System.CodeDom.CodeTypeConstructor e)
		{
			throw new NotImplementedException();
		}

		protected override void GenerateTypeEnd(System.CodeDom.CodeTypeDeclaration e)
		{
			throw new NotImplementedException();
		}

		protected override void GenerateTypeStart(System.CodeDom.CodeTypeDeclaration e)
		{
			throw new NotImplementedException();
		}

		protected override void GenerateVariableDeclarationStatement(System.CodeDom.CodeVariableDeclarationStatement e)
		{
            // TODO 
            // This just creates a variable 'Name' and assigns it nil
            this.Output.Write("(= " + e.Name + " ");
            this.Output.Write(e.InitExpression.ToString());
            this.Output.WriteLine(")");
		}

		protected override void GenerateVariableReferenceExpression(System.CodeDom.CodeVariableReferenceExpression e)
		{
		    this.Output.Write(" " + e.VariableName + " ");
			throw new NotImplementedException();
		}

		protected override string GetTypeOutput(System.CodeDom.CodeTypeReference value)
		{
			throw new NotImplementedException();
		}

		protected override bool IsValidIdentifier(string value)
		{
		    // All methods can be ovveriden, so it IS possible to 
		    // redefine true, false, nil, etc.
            return true;
		}

		protected override string NullToken
		{
            get
            {
                return ((char)0).ToString();
            }
		}

		protected override void OutputType(System.CodeDom.CodeTypeReference typeRef)
		{
			throw new NotImplementedException();
		}

		protected override string QuoteSnippetString(string value)
		{
			throw new NotImplementedException();
		}

		protected override bool Supports(System.CodeDom.Compiler.GeneratorSupport support)
		{
			return true;
		}
	}
}
