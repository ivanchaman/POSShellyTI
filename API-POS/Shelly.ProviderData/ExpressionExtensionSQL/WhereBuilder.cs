using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace Shelly.ProviderData.ExpressionExtensionSQL
{
     public static class WhereBuilder
     {
          public static void Load<T>(this T source, Expression<Func<T, bool>> expression) where T : StaticEntity
          {
               StaticEntity? catalog = source as StaticEntity;
               WherePart wherePart = expression.ToSql();
               catalog?.Load(new StringBuilder(wherePart.Sql), wherePart.Parameters);
          }
          public static Pagination<T> Where<T>(this StaticEntityCollection<T> source, Expression<Func<T, bool>> expression, int pageNumber, int rowsOfPage) where T : StaticEntity, new()
          {               
               WherePart wherePart = expression.ToSql();
               return source.GetCollectionPagination(wherePart.Sql, wherePart.Parameters, pageNumber, rowsOfPage);
          }
          public static Pagination<T> Where<T>(this StaticEntityCollection<T> source, int pageNumber, int rowsOfPage) where T : StaticEntity, new()
          {             
               return source.GetCollectionPagination(pageNumber, rowsOfPage);
          }
          public static HashSet<T> GetCollection<T>(this StaticEntityCollection<T> source, Expression<Func<T, bool>> expression, int pageNumber, int rowsOfPage) where T : StaticEntity, new()
          {
               WherePart wherePart = expression.ToSql();
               return source.GetCollection(wherePart.Sql, wherePart.Parameters, pageNumber, rowsOfPage);
          }
          private static readonly Dictionary<ExpressionType, string> nodeTypeMappings = new Dictionary<ExpressionType, string>
             {
                 {ExpressionType.Add, "+"},
                 {ExpressionType.And, "AND"},
                 {ExpressionType.AndAlso, "AND"},
                 {ExpressionType.Divide, "/"},
                 {ExpressionType.Equal, "="},
                 {ExpressionType.ExclusiveOr, "^"},
                 {ExpressionType.GreaterThan, ">"},
                 {ExpressionType.GreaterThanOrEqual, ">="},
                 {ExpressionType.LessThan, "<"},
                 {ExpressionType.LessThanOrEqual, "<="},
                 {ExpressionType.Modulo, "%"},
                 {ExpressionType.Multiply, "*"},
                 {ExpressionType.Negate, "-"},
                 {ExpressionType.Not, "NOT"},
                 {ExpressionType.NotEqual, "<>"},
                 {ExpressionType.Or, "OR"},
                 {ExpressionType.OrElse, "OR"},
                 {ExpressionType.Subtract, "-"}
             };
         
          private static WherePart ToSql<T>(this Expression<Func<T, bool>> expression)
          {
               int parameter = 1;
               var result = Recurse<T>(ref parameter, expression.Body, isUnary: true);
               return result;
          }

          private static WherePart Recurse<T>(ref int parameter, Expression expression, bool isUnary = false, string? prefix = null, string? postfix = null, bool left = true)
          {
               switch (expression)
               {
                    case UnaryExpression unary: return UnaryExpressionExtract<T>(ref parameter, unary);
                    case BinaryExpression binary: return BinaryExpressionExtract<T>(ref parameter, binary);
                    case ConstantExpression constant: return ConstantExpressionExtract(ref parameter, constant, isUnary, prefix, postfix, left);
                    case MemberExpression member: return MemberExpressionExtract<T>(ref parameter, member, isUnary, prefix, postfix, left);
                    case MethodCallExpression method: return MethodCallExpressionExtract<T>(ref parameter, method);
                    case InvocationExpression invocation: return InvocationExpressionExtract<T>(ref parameter, invocation, left);
                    default: throw new Exception($"Unsupported expression: {expression.GetType().Name}");
               }
          }

          private static WherePart InvocationExpressionExtract<T>(ref int parameter, InvocationExpression expression, bool left)
          {
               return Recurse<T>(ref parameter, ((Expression<Func<T, bool>>)expression.Expression).Body, left: left);
          }

          private static WherePart MethodCallExpressionExtract<T>(ref int parameter, MethodCallExpression expression)
          {
               // LIKE queries:
               if (expression.Method == typeof(string).GetMethod("Contains", new[] { typeof(string) }))
                    return WherePart.Concat(Recurse<T>(ref parameter, expression.Object), "LIKE", Recurse<T>(ref parameter, expression.Arguments[0], prefix: "%", postfix: "%"));
               if (expression.Method == typeof(string).GetMethod("StartsWith", new[] { typeof(string) }))
                    return WherePart.Concat(Recurse<T>(ref parameter, expression.Object), "LIKE", Recurse<T>(ref parameter, expression.Arguments[0], postfix: "%"));
               if (expression.Method == typeof(string).GetMethod("EndsWith", new[] { typeof(string) }))
                    return WherePart.Concat(Recurse<T>(ref parameter, expression.Object), "LIKE", Recurse<T>(ref parameter, expression.Arguments[0], prefix: "%"));
               if (expression.Method == typeof(string).GetMethod("Equals", new[] { typeof(string) }))
                    return WherePart.Concat(Recurse<T>(ref parameter, expression.Object), "=", Recurse<T>(ref parameter, expression.Arguments[0], left: false));
               // IN queries:
               if (expression.Method.Name == "Contains")
               {
                    Expression collection;
                    Expression property;
                    if (expression.Method.IsDefined(typeof(ExtensionAttribute)) && expression.Arguments.Count == 2)
                    {
                         collection = expression.Arguments[0];
                         property = expression.Arguments[1];
                    }
                    else if (!expression.Method.IsDefined(typeof(ExtensionAttribute)) && expression.Arguments.Count == 1)
                    {
                         collection = expression.Object;
                         property = expression.Arguments[0];
                    }
                    else
                    {
                         throw new Exception("Unsupported method call: " + expression.Method.Name);
                    }

                    var values = (IEnumerable)GetValue(collection);
                    return WherePart.Concat(Recurse<T>(ref parameter, property), "IN", WherePart.IsCollection(ref parameter, values));
               }

               throw new Exception("Unsupported method call: " + expression.Method.Name);
          }

          private static WherePart MemberExpressionExtract<T>(ref int parameter, MemberExpression expression, bool isUnary, string? prefix, string? postfix, bool left)
          {
               if (isUnary && expression.Type == typeof(bool))
               {
                    return WherePart.Concat(Recurse<T>(ref parameter, expression), "=", WherePart.IsSql("1"));
               }

               if (expression.Member is PropertyInfo property)
               {
                    if (left)
                    {
                         var colName = GetName<ColumnName>(property);
                         return WherePart.IsSql($"[{colName}]");
                    }
                    if (property.PropertyType == typeof(bool))
                    {
                         var colName = GetName<ColumnName>(property);
                         return WherePart.IsSql($"[{colName}]=1");
                    }
               }

               if (expression.Member is FieldInfo || left == false)
               {
                    var value = GetValue(expression);
                    if (value is string textValue)                    
                         value = $"{prefix}{textValue}{postfix}";                    
                    return WherePart.IsParameter(parameter++, value);
               }

               throw new Exception($"Expression does not refer to a property or field: {expression}");
          }

          private static string GetName<T>(PropertyInfo popropertyInfo) where T : IAttributeName
          {
               if (Configuration.GetInstance().Properties() != null)
               {
                    var result = Configuration.GetInstance().Properties().FirstOrDefault(p => p.Type() == popropertyInfo);
                    if (result != null)
                         return result.GetColumnName();
               }

               var attributes = popropertyInfo.GetCustomAttributes(typeof(T), false).AsList();
               if (attributes.Count != 1) return popropertyInfo.Name;

               var attributeName = (T)attributes[0];
               return attributeName.GetName();
          }
         
          private static WherePart ConstantExpressionExtract(ref int parameter, ConstantExpression expression, bool isUnary, string? prefix, string? postfix, bool left)
          {
               var value = expression.Value;

               switch (value)
               {
                    case null:
                         return WherePart.IsSql("NULL");
                    case int _:
                         return WherePart.IsSql(value.ToString());
                    case string text:
                         value = prefix + text + postfix;
                         break;
               }

               if (value is not bool boolValue || isUnary) return WherePart.IsParameter(parameter++, value);

               string result;
               if (left)
                    result = boolValue ? "1=1" : "0=1";
               else
                    result = boolValue ? "1" : "0";

               return WherePart.IsSql(result);
          }

          private static WherePart BinaryExpressionExtract<T>(ref int parameter, BinaryExpression expression)
          {
               return WherePart.Concat(Recurse<T>(ref parameter, expression.Left), NodeTypeToString(expression.NodeType),Recurse<T>(ref parameter, expression.Right, left: false));
          }

          private static WherePart UnaryExpressionExtract<T>(ref int parameter, UnaryExpression expression)
          {
               return WherePart.Concat(NodeTypeToString(expression.NodeType), Recurse<T>(ref parameter, expression.Operand, true));
          }

          private static object GetValue(Expression member)
          {
               var objectMember = Expression.Convert(member, typeof(object));
               var getterLambda = Expression.Lambda<Func<object>>(objectMember);
               var getter = getterLambda.Compile();
               return getter();
          }

          private static string NodeTypeToString(ExpressionType nodeType)
          {
               return nodeTypeMappings.TryGetValue(nodeType, out var value)
                   ? value
                   : string.Empty;
          }

          private static List<T>? AsList<T>(this IEnumerable<T> source) => (source == null || source is List<T>) ? source as List<T> : source.ToList();
     }
}