using IkMeKursaDarbs.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IkMeKursaDarbs
{
    public static class Utils
    {
        public static string ToSHA256(this string text)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(text);
                byte[] passwordHash = sha256.ComputeHash(passwordBytes);
                return BitConverter.ToString(passwordHash).Replace("-", string.Empty).ToLower();
            }
        }
        public static string GetMemberName(Expression expression)
        {
            if (expression.NodeType == ExpressionType.Lambda)
            {
                var lambda = (LambdaExpression)expression;
                if (lambda.Body.NodeType == ExpressionType.MemberAccess)
                {
                    var memberExpr = (MemberExpression)lambda.Body;
                    return memberExpr.Member.Name;
                }
                else if (lambda.Body.NodeType == ExpressionType.Convert)
                {
                    var convertExpr = (UnaryExpression)lambda.Body;
                    if (convertExpr.Operand.NodeType == ExpressionType.MemberAccess)
                    {
                        var memberExpr = (MemberExpression)convertExpr.Operand;
                        return memberExpr.Member.Name;
                    }
                }
            }
            throw new ArgumentException("Invalid expression");
        }
    }
}
