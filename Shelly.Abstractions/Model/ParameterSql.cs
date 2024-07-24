using System;

namespace Shelly.Abstractions.Model
{
     /// <summary>
     /// Clase para los parametros de una consulta en SQL
     /// </summary>
     [Serializable]
     public class ParameterSql
     {
          /// <summary>
          /// NOmbre del parametro
          /// </summary>
          public string Parameter { get; set; }

          /// <summary>
          /// Valor del parametro
          /// </summary>
          public object Value { get; set; }

          public string TypeName { get; set; }

          /// <summary>
          /// Crea una nueva instancia para los parametros
          /// </summary>
          /// <param name="parameter">NOmbre del parametro</param>
          /// <param name="value">Valor del parametro</param>
          public ParameterSql(string parameter, object value)
          {
               Parameter = parameter;
               Value = value;
          }

          public ParameterSql(string parameter, object value, string typeName)
          {
               Parameter = parameter;
               Value = value;
               TypeName = typeName;
          }
     }
}