using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

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
            }
            throw new ArgumentException("Invalid expression");
        }
    }
}
