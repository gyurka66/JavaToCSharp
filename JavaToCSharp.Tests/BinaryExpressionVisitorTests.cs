using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.github.javaparser;
using com.github.javaparser.ast.expr;
using JavaToCSharp.Expressions;
using Microsoft.CodeAnalysis.CSharp;

namespace JavaToCSharp.Tests
{
    public class BinaryExpressionVisitorTests
    {
        [Fact]
        public void ShouldConvertBooleanAnd()
        {
            BinaryExpressionVisitor visitor = new BinaryExpressionVisitor();
            var options = new JavaConversionOptions
            {
                IncludeUsings = false,
                IncludeNamespace = false,
            };
            var c = new ConversionContext(options);
            Expression left = new BooleanLiteralExpr(false);
            Expression right = new BooleanLiteralExpr(true);
            BinaryExpr expr = new BinaryExpr(left, right, BinaryExpr.Operator.AND);
            var actual = BinaryExpressionVisitor.VisitExpression(c, expr);

            var expected = SyntaxFactory.BinaryExpression(SyntaxKind.LogicalAndExpression, SyntaxFactory.LiteralExpression(SyntaxKind.FalseLiteralExpression), SyntaxFactory.LiteralExpression(SyntaxKind.TrueLiteralExpression));
            Assert.Equal(expected.ToFullString(), actual!.ToFullString());
        }
    }
}
