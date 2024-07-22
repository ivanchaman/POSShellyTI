using System;
using System.Reflection;

namespace Shelly.ProviderData.ExpressionExtensionSQL
{
     internal interface IEntityMap
    {
        void SetTableName(string tableName);
        Type Type();
        string GetTableName();
        string Name();
    }

     internal interface IPropertyMap
    {
        void SetColumnName(string columnName);
        PropertyInfo Type();
        string GetColumnName();
    }
}