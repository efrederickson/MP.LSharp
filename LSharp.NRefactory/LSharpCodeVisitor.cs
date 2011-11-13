/*
 * Created by SharpDevelop.
 * User: elijah
 * Date: 9/26/2011
 * Time: 1:27 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using ICSharpCode.NRefactory.CSharp;
//using Mono.CSharp;

namespace LSharp.NRefactory
{
    public class LSharpCodeVisitor : IAstVisitor<object, object>
    {
        public StringBuilder Output;
        
        public LSharpCodeVisitor()
        {
            Output = new StringBuilder();
        }
        
        public object VisitAnonymousMethodExpression(AnonymousMethodExpression anonymousMethodExpression, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitUndocumentedExpression(UndocumentedExpression undocumentedExpression, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitArrayCreateExpression(ArrayCreateExpression arrayCreateExpression, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitArrayInitializerExpression(ArrayInitializerExpression arrayInitializerExpression, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitAsExpression(AsExpression asExpression, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitAssignmentExpression(AssignmentExpression assignmentExpression, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitBaseReferenceExpression(BaseReferenceExpression baseReferenceExpression, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitBinaryOperatorExpression(BinaryOperatorExpression binaryOperatorExpression, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitCastExpression(CastExpression castExpression, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitCheckedExpression(CheckedExpression checkedExpression, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitConditionalExpression(ConditionalExpression conditionalExpression, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitDefaultValueExpression(DefaultValueExpression defaultValueExpression, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitDirectionExpression(DirectionExpression directionExpression, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitIdentifierExpression(IdentifierExpression identifierExpression, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitIndexerExpression(IndexerExpression indexerExpression, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitInvocationExpression(InvocationExpression invocationExpression, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitIsExpression(IsExpression isExpression, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitLambdaExpression(LambdaExpression lambdaExpression, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitMemberReferenceExpression(MemberReferenceExpression memberReferenceExpression, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitNamedArgumentExpression(NamedArgumentExpression namedArgumentExpression, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitNullReferenceExpression(NullReferenceExpression nullReferenceExpression, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitObjectCreateExpression(ObjectCreateExpression objectCreateExpression, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitAnonymousTypeCreateExpression(AnonymousTypeCreateExpression anonymousTypeCreateExpression, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitParenthesizedExpression(ParenthesizedExpression parenthesizedExpression, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitPointerReferenceExpression(PointerReferenceExpression pointerReferenceExpression, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitPrimitiveExpression(PrimitiveExpression primitiveExpression, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitSizeOfExpression(SizeOfExpression sizeOfExpression, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitStackAllocExpression(StackAllocExpression stackAllocExpression, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitThisReferenceExpression(ThisReferenceExpression thisReferenceExpression, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitTypeOfExpression(TypeOfExpression typeOfExpression, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitTypeReferenceExpression(TypeReferenceExpression typeReferenceExpression, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitUnaryOperatorExpression(UnaryOperatorExpression unaryOperatorExpression, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitUncheckedExpression(UncheckedExpression uncheckedExpression, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitEmptyExpression(EmptyExpression emptyExpression, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitQueryExpression(QueryExpression queryExpression, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitQueryContinuationClause(QueryContinuationClause queryContinuationClause, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitQueryFromClause(QueryFromClause queryFromClause, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitQueryLetClause(QueryLetClause queryLetClause, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitQueryWhereClause(QueryWhereClause queryWhereClause, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitQueryJoinClause(QueryJoinClause queryJoinClause, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitQueryOrderClause(QueryOrderClause queryOrderClause, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitQueryOrdering(QueryOrdering queryOrdering, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitQuerySelectClause(QuerySelectClause querySelectClause, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitQueryGroupClause(QueryGroupClause queryGroupClause, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitAttribute(ICSharpCode.NRefactory.CSharp.Attribute attribute, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitAttributeSection(AttributeSection attributeSection, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitDelegateDeclaration(DelegateDeclaration delegateDeclaration, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitNamespaceDeclaration(NamespaceDeclaration namespaceDeclaration, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitTypeDeclaration(TypeDeclaration typeDeclaration, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitUsingAliasDeclaration(UsingAliasDeclaration usingAliasDeclaration, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitUsingDeclaration(UsingDeclaration usingDeclaration, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitExternAliasDeclaration(ExternAliasDeclaration externAliasDeclaration, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitBlockStatement(BlockStatement blockStatement, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitBreakStatement(BreakStatement breakStatement, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitCheckedStatement(CheckedStatement checkedStatement, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitContinueStatement(ContinueStatement continueStatement, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitDoWhileStatement(DoWhileStatement doWhileStatement, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitEmptyStatement(EmptyStatement emptyStatement, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitExpressionStatement(ExpressionStatement expressionStatement, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitFixedStatement(FixedStatement fixedStatement, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitForeachStatement(ForeachStatement foreachStatement, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitForStatement(ForStatement forStatement, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitGotoCaseStatement(GotoCaseStatement gotoCaseStatement, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitGotoDefaultStatement(GotoDefaultStatement gotoDefaultStatement, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitGotoStatement(GotoStatement gotoStatement, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitIfElseStatement(IfElseStatement ifElseStatement, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitLabelStatement(LabelStatement labelStatement, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitLockStatement(LockStatement lockStatement, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitReturnStatement(ReturnStatement returnStatement, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitSwitchStatement(SwitchStatement switchStatement, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitSwitchSection(SwitchSection switchSection, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitCaseLabel(CaseLabel caseLabel, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitThrowStatement(ThrowStatement throwStatement, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitTryCatchStatement(TryCatchStatement tryCatchStatement, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitCatchClause(CatchClause catchClause, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitUncheckedStatement(UncheckedStatement uncheckedStatement, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitUnsafeStatement(UnsafeStatement unsafeStatement, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitUsingStatement(UsingStatement usingStatement, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitVariableDeclarationStatement(VariableDeclarationStatement variableDeclarationStatement, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitWhileStatement(WhileStatement whileStatement, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitYieldBreakStatement(YieldBreakStatement yieldBreakStatement, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitYieldStatement(Mono.CSharp.YieldStatement<Mono.CSharp.StateMachineInitializer> yieldStatement, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitAccessor(Accessor accessor, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitConstructorDeclaration(ConstructorDeclaration constructorDeclaration, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitConstructorInitializer(ConstructorInitializer constructorInitializer, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitDestructorDeclaration(DestructorDeclaration destructorDeclaration, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitEnumMemberDeclaration(EnumMemberDeclaration enumMemberDeclaration, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitEventDeclaration(EventDeclaration eventDeclaration, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitCustomEventDeclaration(CustomEventDeclaration customEventDeclaration, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitFieldDeclaration(FieldDeclaration fieldDeclaration, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitIndexerDeclaration(IndexerDeclaration indexerDeclaration, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitMethodDeclaration(MethodDeclaration methodDeclaration, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitOperatorDeclaration(OperatorDeclaration operatorDeclaration, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitParameterDeclaration(ParameterDeclaration parameterDeclaration, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitPropertyDeclaration(PropertyDeclaration propertyDeclaration, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitVariableInitializer(VariableInitializer variableInitializer, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitFixedFieldDeclaration(FixedFieldDeclaration fixedFieldDeclaration, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitFixedVariableInitializer(FixedVariableInitializer fixedVariableInitializer, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitCompilationUnit(CompilationUnit compilationUnit, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitSimpleType(SimpleType simpleType, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitMemberType(MemberType memberType, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitComposedType(ComposedType composedType, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitArraySpecifier(ArraySpecifier arraySpecifier, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitPrimitiveType(PrimitiveType primitiveType, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitComment(Comment comment, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitTypeParameterDeclaration(TypeParameterDeclaration typeParameterDeclaration, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitConstraint(Constraint constraint, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitCSharpTokenNode(CSharpTokenNode cSharpTokenNode, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitIdentifier(Identifier identifier, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitPatternPlaceholder(AstNode placeholder, ICSharpCode.NRefactory.PatternMatching.Pattern pattern, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitNamedExpression(NamedExpression namedExpression, object data)
        {
            throw new NotImplementedException();
        }
        
        public object VisitYieldReturnStatement(YieldReturnStatement yieldReturnStatement, object data)
        {
            throw new NotImplementedException();
        }
    }
}