namespace Shelly.ProviderData.ExpressionExtensionSQL
{
     internal class WherePart
    {
        private WherePart(string sql, params ParameterSql[] parameters) : this(sql, parameters.ToList())
        {
        }

        private WherePart(string sql, IEnumerable<ParameterSql> parameters)
        {
            Sql = sql;
            Parameters = new List<ParameterSql>(parameters);
        }

        public string Sql { get; }
        public bool HasSql => !string.IsNullOrEmpty(Sql);

        public List<ParameterSql> Parameters { get; }

        public static WherePart IsSql(string sql)
        {
            return new WherePart(sql);
        }

        public static WherePart IsParameter(int count, object value)
        {
            return new WherePart($"@{count}", new ParameterSql($"{count}", value));
        }

        public static WherePart IsCollection(ref int countStart, IEnumerable values)
        {
            var parameters = new List<ParameterSql>();
            var sql = new StringBuilder("(");
            foreach (var value in values)
            {
                parameters.Add(new ParameterSql(countStart.ToString(), value));
                sql.Append($"@{countStart},");
                countStart++;
            }

            if (sql.Length == 1)
            {
                sql.Append("null,");
            }

            sql[sql.Length - 1] = ')';
            return new WherePart(sql.ToString(), parameters);
        }

        public static WherePart Concat(string @operator, WherePart operand)
        {
            return new WherePart($"({@operator} {operand.Sql})", operand.Parameters);
        }

        public static WherePart Concat(WherePart left, string @operator, WherePart right)
        {
            if (right.Sql.Equals("NULL", StringComparison.InvariantCultureIgnoreCase))
            {
                @operator = @operator == "=" ? "IS" : "IS NOT";
            }

            return new WherePart($"({left.Sql} {@operator} {right.Sql})", left.Parameters.Union(right.Parameters));
        }

        public static WherePart Empty => new WherePart(string.Empty);
    }
}