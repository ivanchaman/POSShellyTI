
namespace Shelly.ProviderData.GenericRepository.SP
{
     /// <summary>
     /// Clase que contiene las funciones basicas para el manejo de tablas del sistema
     /// Actualmete solo funcion para las tablas que no son de metadatos
     /// </summary>
     [Serializable]     
     public class BaseRepository : DynamicObject, IDynamicMetaObjectProvider
     {
          #region Variables
          private readonly object _lock = new object();
          protected internal DataAccess _DataAccess;
          protected List<string> _ErrorMessage { get; set; }
          protected List<ParameterSql> _sqlParameterList;
          public StringBuilder _fields;
          public int _Count;
          #endregion Variables

          #region Properties
          protected DateTime DefaultDateTime { get { return new DateTime(1900, 1, 1); } }
          public DataAccess Connection { get { return _DataAccess; } }

          public Dictionary<string, Property> Properties { get; set; }

          public string StoreProcedureName { get; set; }
          public string Owner { get; set; }

          public object this[string name]
          {
               get
               {
                    return GetPropertyValue(name);
               }

               set
               {
                    SetPropertyValue(name, value);
               }
          }
          #endregion Properties

          #region Builders

          /// <summary>
          /// Constructor para los Generics, dado que requieren un constructor sin parametros publico
          /// </summary>
          public BaseRepository()
          {
               StoredProcedure();
               Properties = new Dictionary<string, Property>();
               Initialize(this);
               LoadColumnProperties();
          }

          /// <summary>
          /// Constructor sobre cargado para la formula
          /// </summary>
          /// <param name="system">Variable del sistema</param>
          public BaseRepository(DataAccess dataaccess) : this()
          {

               _DataAccess = dataaccess;
               Properties = new Dictionary<string, Property>();
               LoadColumnProperties();
          }

          #endregion Builders
          #region Dynamic property management

          /// <summary>
          /// Initializes the specified instance.
          /// </summary>
          /// <param name="instance">The instance.</param>
          protected virtual void Initialize(object instance)
          {
          }

          /// <summary>
          /// Try to retrieve a member by name first from instance properties
          /// followed by the collection entries.
          /// </summary>
          /// <param name="binder"></param>
          /// <param name="result"></param>
          /// <returns></returns>
          public override bool TryGetMember(GetMemberBinder binder, out object result)
          {
               result = null;
               // first check the Properties collection for member
               if (!ExistsProperty(binder.Name))
               {
                    return false;
               }
               result = GetPropertyValue(binder.Name);
               return true;
          }

          /// <summary>
          /// Property setter implementation tries to retrieve value from instance
          /// first then into this object
          /// </summary>
          /// <param name="binder"></param>
          /// <param name="value"></param>
          /// <returns></returns>
          public override bool TrySetMember(SetMemberBinder binder, object value)
          {
               if (!ExistsProperty(binder.Name))
               {
                    AddPropertyValue(binder.Name, value);
               }
               SetPropertyValue(binder.Name, value);
               return true;
          }

          #endregion Dynamic property management

          #region Methods for managing catalog properties         
          private void StoredProcedure()
          {
               //StoreProcedureName = GetAttributeValue(typeof(BaseRepository),(StoredProcedure dna) => dna.Name);
               //Owner = GetAttributeValue(typeof(BaseRepository), (StoredProcedure dna) => dna.Owner);
          }
          private TValue GetAttributeValue<TAttribute, TValue>(Type type, Func<TAttribute, TValue> valueSelector) where TAttribute : Attribute
          {
               var object1 = type.GetCustomAttributes(typeof(TAttribute), true);
               var att = type.GetCustomAttribute(typeof(TAttribute), true) as TAttribute;
               if (att != null)
               {
                    return valueSelector(att);
               }
               return default(TValue);
          }
          public string GetErrors()
          {
               if (_ErrorMessage == null || _ErrorMessage.Count == 0)
                    return "";
               return string.Join(", ", _ErrorMessage);
          }
          public bool ExistErrors()
          {
               if (_ErrorMessage == null || _ErrorMessage.Count == 0)
                    return false;
               return true;
          }
          /// <summary>
          /// Tables the name.
          /// </summary>
          /// <returns></returns>
          public string TableName()
          {
               return $"[{Owner}].[{StoreProcedureName}]";
          }


          /// <summary>
          /// GetPropertyValue
          /// </summary>
          /// <typeparam name="TValue"></typeparam>
          /// <param name="nameProperty"></param>
          /// <returns></returns>
          protected TValue GetPropertyValue<TValue>(string nameProperty)
          {
               PropertyValue<TValue> property = GetProperty<TValue>(nameProperty);
               if (property != null)
               {
                    return property.Value;
               }
               return default;
          }

          /// <summary>
          /// Obteners the valor propiedad.
          /// </summary>
          /// <param name="nameProperty">Name of the ps.</param>
          /// <returns></returns>
          /// <exception cref="System.Exception"></exception>
          public object GetPropertyValue(string nameProperty)
          {
               nameProperty = nameProperty.ToUpper();
               if (!ExistsProperty(nameProperty))
               {
                    throw new Exception($"E00000070|{nameProperty}|{TableName()}");
               }
               if (Properties[nameProperty] is PropertyValue<bool>)
               {
                    return GetPropertyValue<bool>(nameProperty);
               }
               if (Properties[nameProperty] is PropertyValue<byte>)
               {
                    return GetPropertyValue<byte>(nameProperty);
               }
               if (Properties[nameProperty] is PropertyValue<Int16>)
               {
                    return GetPropertyValue<Int16>(nameProperty);
               }
               if (Properties[nameProperty] is PropertyValue<Int32>)
               {
                    return GetPropertyValue<Int32>(nameProperty);
               }
               if (Properties[nameProperty] is PropertyValue<Int64>)
               {
                    return GetPropertyValue<Int64>(nameProperty);
               }
               if (Properties[nameProperty] is PropertyValue<DateTime>)
               {
                    return GetPropertyValue<DateTime>(nameProperty);
               }
               if (Properties[nameProperty] is PropertyValue<TimeSpan>)
               {
                    return GetPropertyValue<TimeSpan>(nameProperty);
               }
               if (Properties[nameProperty] is PropertyValue<decimal>)
               {
                    return GetPropertyValue<decimal>(nameProperty);
               }
               if (Properties[nameProperty] is PropertyValue<Single>)
               {
                    return GetPropertyValue<Single>(nameProperty);
               }
               if (Properties[nameProperty] is PropertyValue<double>)
               {
                    return GetPropertyValue<double>(nameProperty);
               }
               if (Properties[nameProperty] is PropertyValue<object>)
               {
                    return GetPropertyValue<object>(nameProperty);
               }
               if (Properties[nameProperty] is PropertyValue<byte[]>)
               {
                    return GetPropertyValue<byte[]>(nameProperty);
               }
               if (Properties[nameProperty] is PropertyValue<string>)
               {
                    return GetPropertyValue<string>(nameProperty);
               }
               if (Properties[nameProperty] is PropertyValue<byte?>)
               {
                    return GetPropertyValue<byte?>(nameProperty);
               }
               if (Properties[nameProperty] is PropertyValue<bool?>)
               {
                    return GetPropertyValue<bool?>(nameProperty);
               }
               if (Properties[nameProperty] is PropertyValue<Int16?>)
               {
                    return GetPropertyValue<Int16?>(nameProperty);
               }
               if (Properties[nameProperty] is PropertyValue<Int32?>)
               {
                    return GetPropertyValue<Int32?>(nameProperty);
               }
               if (Properties[nameProperty] is PropertyValue<Int64?>)
               {
                    return GetPropertyValue<Int64?>(nameProperty);
               }
               if (Properties[nameProperty] is PropertyValue<DateTime?>)
               {
                    return GetPropertyValue<DateTime?>(nameProperty);
               }
               if (Properties[nameProperty] is PropertyValue<decimal?>)
               {
                    return GetPropertyValue<decimal?>(nameProperty);
               }
               if (Properties[nameProperty] is PropertyValue<Single?>)
               {
                    return GetPropertyValue<Single?>(nameProperty);
               }
               if (Properties[nameProperty] is PropertyValue<double?>)
               {
                    return GetPropertyValue<double?>(nameProperty);
               }
               return null;
          }

          /// <summary>
          /// Sets the property.
          /// </summary>
          /// <typeparam name="TValue">The type of the value.</typeparam>
          /// <param name="propertyName">Name of the property.</param>
          /// <param name="propertyValue">The property value.</param>
          protected void SetPropertyValue<TValue>(string propertyName, TValue propertyValue)
          {
               SetPropertyValue<TValue>(propertyName, propertyValue, false);
          }

          protected void SetPropertyValue<TValue>(int propertyId, TValue propertyValue)
          {
               SetPropertyValue<TValue>(GetNameProperty(propertyId), propertyValue, false);
          }

          /// <summary>
          /// Sets the property.
          /// </summary>
          /// <typeparam name="TValue">The type of the value.</typeparam>
          /// <param name="propertyName">Name of the property.</param>
          /// <param name="propertyValue">The property value.</param>
          /// <param name="isLastValue">if set to <c>true</c> [is last value].</param>
          protected void SetPropertyValue<TValue>(string propertyName, TValue propertyValue, bool isLastValue)
          {
               PropertyValue<TValue> propertyColumn = GetProperty<TValue>(propertyName);
               if (propertyColumn == null)
               {
                    if (propertyValue == null)
                         return;
                    AddPropertyValue<TValue>(propertyName, propertyValue);
                    propertyColumn = GetProperty<TValue>(propertyName);
               }
               propertyColumn.Value = propertyValue;
          }

          /// <summary>
          /// Sets the property.
          /// </summary>
          /// <typeparam name="TValue">The type of the value.</typeparam>
          /// <param name="propertyName">Name of the property.</param>
          protected void SetPropertyValue<TValue>(string propertyName)
          {
               PropertyValue<TValue> propertyColumn = GetProperty<TValue>(propertyName);
               if (propertyColumn == null)
               {
                    return;
               }
               propertyColumn.Value = default;
          }

          /// <summary>
          /// Validas the valor propiedad.
          /// </summary>
          /// <param name="propertyName">Name of the ps.</param>
          /// <param name="propertyValue">The po value.</param>
          /// <returns></returns>
          public bool ValidatePropertyValue(string propertyName, object propertyValue)
          {
               bool isCorrect;
               byte byteData;
               bool booleanData;
               Int16 int16Data;
               Int32 int32Data;
               Int64 int64Data;
               DateTime dateTimeData;
               TimeSpan timespanData;
               decimal decimalData;
               double doubleData;
               Single isSingle;
               propertyName = propertyName.ToUpper();
               if (!ExistsProperty(propertyName))
               {
                    return false;
               }
               isCorrect = true;
               if (Properties[propertyName] is PropertyValue<bool>)
               {
                    if (!Boolean.TryParse(Convert.ToString(propertyValue), out booleanData))
                         isCorrect = false;
               }

               if (Properties[propertyName] is PropertyValue<byte>)
               {
                    if (!Byte.TryParse(Convert.ToString(propertyValue), out byteData))
                         isCorrect = false;
               }
               if (Properties[propertyName] is PropertyValue<Int16>)
               {
                    if (!Int16.TryParse(Convert.ToString(propertyValue), out int16Data))
                         isCorrect = false;
               }
               if (Properties[propertyName] is PropertyValue<Int32>)
               {
                    if (!Int32.TryParse(Convert.ToString(propertyValue), out int32Data))
                         isCorrect = false;
               }
               if (Properties[propertyName] is PropertyValue<Int64>)
               {
                    if (!Int64.TryParse(Convert.ToString(propertyValue), out int64Data))
                         isCorrect = false;
               }
               if (Properties[propertyName] is PropertyValue<DateTime>)
               {
                    if (!DateTime.TryParse(Convert.ToString(propertyValue), out dateTimeData))
                         isCorrect = false;
               }
               if (Properties[propertyName] is PropertyValue<TimeSpan>)
               {
                    if (!TimeSpan.TryParse(Convert.ToString(propertyValue), out timespanData))
                         isCorrect = false;
               }
               if (Properties[propertyName] is PropertyValue<decimal>)
               {
                    if (!decimal.TryParse(Convert.ToString(propertyValue), out decimalData))
                         isCorrect = false;
               }
               if (Properties[propertyName] is PropertyValue<Single>)
               {
                    if (!Single.TryParse(Convert.ToString(propertyValue), out isSingle))
                         isCorrect = false;
               }
               if (Properties[propertyName] is PropertyValue<double>)
               {
                    if (!double.TryParse(Convert.ToString(propertyValue), out doubleData))
                         isCorrect = false;
               }

               if (Properties[propertyName] is PropertyValue<byte[]>)
               {
                    isCorrect = false;
               }

               if (Properties[propertyName] is PropertyValue<byte?>)
               {
                    if (!Object.Equals(propertyValue, null) && !(Convert.ToString(propertyValue) == ""))
                    {
                         if (!Byte.TryParse(Convert.ToString(propertyValue), out byteData))
                              isCorrect = false;
                    }
               }
               if (Properties[propertyName] is PropertyValue<bool?>)
               {
                    if (!Object.Equals(propertyValue, null) && Convert.ToString(propertyValue) != "")
                    {
                         if (!Boolean.TryParse(Convert.ToString(propertyValue), out booleanData))
                              isCorrect = false;
                    }
               }
               if (Properties[propertyName] is PropertyValue<Int16?>)
               {
                    if (!Object.Equals(propertyValue, null) && !(Convert.ToString(propertyValue) == ""))
                    {
                         if (!Int16.TryParse(Convert.ToString(propertyValue), out int16Data))
                              isCorrect = false;
                    }
               }
               if (Properties[propertyName] is PropertyValue<Int32?>)
               {
                    if (!Object.Equals(propertyValue, null) && !(Convert.ToString(propertyValue) == ""))
                    {
                         if (!Int32.TryParse(Convert.ToString(propertyValue), out int32Data))
                              isCorrect = false;
                    }
               }
               if (Properties[propertyName] is PropertyValue<Int64?>)
               {
                    if (!Object.Equals(propertyValue, null) && !(Convert.ToString(propertyValue) == ""))
                    {
                         if (!Int64.TryParse(Convert.ToString(propertyValue), out int64Data))
                              isCorrect = false;
                    }
               }
               if (Properties[propertyName] is PropertyValue<DateTime?>)
               {
                    if (!Object.Equals(propertyValue, null) && !(Convert.ToString(propertyValue) == ""))
                    {
                         if (!DateTime.TryParse(Convert.ToString(propertyValue), out dateTimeData))
                              isCorrect = false;
                    }
               }
               if (Properties[propertyName] is PropertyValue<decimal?>)
               {
                    if (!Object.Equals(propertyValue, null) && !(Convert.ToString(propertyValue) == ""))
                    {
                         if (!decimal.TryParse(Convert.ToString(propertyValue), out decimalData))
                              isCorrect = false;
                    }
               }
               if (Properties[propertyName] is PropertyValue<Single?>)
               {
                    if (!Object.Equals(propertyValue, null))
                    {
                         if (!Single.TryParse(Convert.ToString(propertyValue), out isSingle))
                              isCorrect = false;
                    }
               }
               if (Properties[propertyName] is PropertyValue<double?>)
               {
                    if (!Object.Equals(propertyValue, null) && !(Convert.ToString(propertyValue) == ""))
                    {
                         if (!double.TryParse(Convert.ToString(propertyValue), out doubleData))
                              isCorrect = false;
                    }
               }

               return isCorrect;
          }

          public void SetPropertyValueObject(int propertyId, object propertyValue)
          {
               SetPropertyValue(GetNameProperty(propertyId), propertyValue);
          }
          private void AddPropertyValue(string propertyName, object propertyValue)
          {
               if (Properties == null)
                    Properties = new Dictionary<string, Property>();
               if (propertyValue == null)
               {
                    AddProperty<object>(propertyName, new PropertyValue<object>() { Name = propertyName, DataType = typeof(System.Object), Value = propertyValue });
                    return;
               }
               var property = propertyValue.GetType();
               switch (property.FullName)
               {
                    case "System.Boolean":
                         AddProperty<bool>(propertyName, new PropertyValue<bool>() { Name = propertyName, DataType = property, Value = Convert.ToBoolean(propertyValue) });
                         break;
                    case "System.Byte":

                         if (byte.TryParse(Convert.ToString(propertyValue), out byte value))
                              AddProperty<byte>(propertyName, new PropertyValue<byte>() { Name = propertyName, DataType = property, Value = value });
                         else
                              AddProperty<byte>(propertyName, new PropertyValue<byte>() { Name = propertyName, DataType = property, Value = 0 });
                         break;
                    case "System.Byte[]":
                         AddProperty<byte[]>(propertyName, new PropertyValue<byte[]>() { Name = propertyName, DataType = property, Value = (byte[])propertyValue });
                         break;
                    case "System.Int32":
                         AddProperty<int>(propertyName, new PropertyValue<int>() { Name = propertyName, DataType = property, Value = Convert.ToInt32(propertyValue) });
                         break;
                    case "System.String":
                         AddProperty<string>(propertyName, new PropertyValue<string>() { Name = propertyName, DataType = property, Value = propertyValue == null ? String.Empty : Convert.ToString(propertyValue) });
                         break;
                    case "System.DateTime":
                         AddProperty<DateTime>(propertyName, new PropertyValue<DateTime>() { Name = propertyName, DataType = property, Value = Convert.ToDateTime(propertyValue) });
                         break;
                    case "System.Decimal":
                         AddProperty<decimal>(propertyName, new PropertyValue<decimal>() { Name = propertyName, DataType = property, Value = Convert.ToDecimal(propertyValue) });
                         break;
                    case "System.Double":
                         AddProperty<double>(propertyName, new PropertyValue<double>() { Name = propertyName, DataType = property, Value = Convert.ToDouble(propertyValue) });
                         break;
                    case "System.Single":
                         AddProperty<Single>(propertyName, new PropertyValue<Single>() { Name = propertyName, DataType = property, Value = Convert.ToInt16(propertyValue) });
                         break;
                    case "System.Int64":
                         AddProperty<Int64>(propertyName, new PropertyValue<Int64>() { Name = propertyName, DataType = property, Value = Convert.ToInt64(propertyValue) });
                         break;
               }
               if (property.BaseType != null && property.BaseType.FullName == "System.Enum")
                    AddProperty<int>(propertyName, new PropertyValue<int>() { Name = propertyName, DataType = property, Value = Convert.ToInt32(propertyValue) });
          }

          private void AddPropertyValue<T>(string propertyName, T propertyValue)
          {
               if (Properties == null)
                    Properties = new Dictionary<string, Property>();
               var property = propertyValue.GetType();
               if (property.BaseType != null && property.BaseType.FullName == "System.Enum")
               {
                    AddProperty<T>(propertyName, new PropertyValue<T>() { Name = propertyName, DataType = property, Value = propertyValue, TypeName = "System.Enum" });
                    return;
               }
               if (property.BaseType != null && property.BaseType.FullName.Contains("List"))
               {
                    AddProperty<T>(propertyName, new PropertyValue<T>() { Name = propertyName, DataType = property, Value = propertyValue, TypeName = "" });
                    return;
               }
               AddProperty<T>(propertyName, new PropertyValue<T>() { Name = propertyName, DataType = propertyValue.GetType(), Value = propertyValue, TypeName = property.FullName });
               return;
          }
          /// <summary>
          /// Establecers the valor propiedad.
          /// </summary>
          /// <param name="propertyName">Name of the ps.</param>
          /// <param name="propertyValue">The po value.</param>
          /// <exception cref="Exception"></exception>
          public bool SetPropertyValue(string propertyName, object propertyValue)
          {
               propertyName = propertyName.ToUpper();
               if (!ExistsProperty(propertyName))
               {
                    return false;
               }
               if (Properties[propertyName] is PropertyValue<bool>)
               {
                    SetPropertyValue<bool>(propertyName, Convert.ToString(propertyValue).ToBoolean());
               }
               if (Properties[propertyName] is PropertyValue<byte>)
               {
                    if (!byte.TryParse(Convert.ToString(propertyValue), out byte value))
                         return false;
                    SetPropertyValue<byte>(propertyName, value);
               }
               if (Properties[propertyName] is PropertyValue<Int16>)
               {
                    if (!short.TryParse(Convert.ToString(propertyValue), out short value))
                         return false;
                    SetPropertyValue<Int16>(propertyName, value);
               }
               if (Properties[propertyName] is PropertyValue<Int32>)
               {
                    if (!int.TryParse(Convert.ToString(propertyValue), out int value))
                         return false;
                    SetPropertyValue<Int32>(propertyName, value);
               }
               if (Properties[propertyName] is PropertyValue<Int64>)
               {
                    if (!long.TryParse(Convert.ToString(propertyValue), out long value))
                         return false;
                    SetPropertyValue<Int64>(propertyName, value);
               }
               if (Properties[propertyName] is PropertyValue<DateTime>)
               {
                    if (!DateTime.TryParse(Convert.ToString(propertyValue), out DateTime value))
                         return false;
                    SetPropertyValue<DateTime>(propertyName, value);
               }
               if (Properties[propertyName] is PropertyValue<TimeSpan>)
               {
                    if (!TimeSpan.TryParse(Convert.ToString(propertyValue), out TimeSpan value))
                         return false;
                    SetPropertyValue<TimeSpan>(propertyName, value);
               }
               if (Properties[propertyName] is PropertyValue<decimal>)
               {
                    if (!decimal.TryParse(Convert.ToString(propertyValue), out decimal value))
                         return false;
                    SetPropertyValue<decimal>(propertyName, value);
               }
               if (Properties[propertyName] is PropertyValue<Single>)
               {
                    if (!Single.TryParse(Convert.ToString(propertyValue), out Single value))
                         return false;
                    SetPropertyValue<Single>(propertyName, value);
               }
               if (Properties[propertyName] is PropertyValue<double>)
               {
                    if (!double.TryParse(Convert.ToString(propertyValue), out double value))
                         return false;
                    SetPropertyValue<double>(propertyName, Convert.ToDouble(propertyValue));
               }
               if (Properties[propertyName] is PropertyValue<object>)
               {
                    SetPropertyValue<object>(propertyName, propertyValue);
               }
               if (Properties[propertyName] is PropertyValue<byte[]>)
               {
                    if (!String.IsNullOrEmpty(Convert.ToString(propertyValue)))
                    {
                         SetPropertyValue<byte[]>(propertyName, (byte[])propertyValue);
                    }
                    else
                    {
                         SetPropertyValue<byte[]>(propertyName, null);
                    }
               }
               if (Properties[propertyName] is PropertyValue<string>)
               {
                    if (!Object.Equals(propertyValue, null))
                    {
                         SetPropertyValue<string>(propertyName, Convert.ToString(propertyValue));
                    }
                    else
                    {
                         SetPropertyValue<string>(propertyName, null);
                    }
               }
               if (Properties[propertyName] is PropertyValue<byte?>)
               {
                    if (!Object.Equals(propertyValue, null) && !(Convert.ToString(propertyValue) == ""))
                    {
                         if (!byte.TryParse(Convert.ToString(propertyValue), out byte value))
                              return false;
                         SetPropertyValue<byte?>(propertyName, value);
                    }
                    else
                    {
                         SetPropertyValue<byte?>(propertyName, null);
                    }
               }
               if (Properties[propertyName] is PropertyValue<bool?>)
               {
                    if (!Object.Equals(propertyValue, null) && !(Convert.ToString(propertyValue) == ""))
                    {
                         SetPropertyValue<bool?>(propertyName, Convert.ToString(propertyValue).ToBoolean());
                    }
                    else
                    {
                         SetPropertyValue<bool?>(propertyName, null);
                    }
               }
               if (Properties[propertyName] is PropertyValue<Int16?>)
               {
                    if (!Object.Equals(propertyValue, null) && !(Convert.ToString(propertyValue) == ""))
                    {
                         if (!short.TryParse(Convert.ToString(propertyValue), out short value))
                              return false;
                         SetPropertyValue<Int16?>(propertyName, value);
                    }
                    else
                    {
                         SetPropertyValue<Int16?>(propertyName, null);
                    }
               }
               if (Properties[propertyName] is PropertyValue<Int32?>)
               {
                    if (!Object.Equals(propertyValue, null) && !(Convert.ToString(propertyValue) == ""))
                    {
                         if (!int.TryParse(Convert.ToString(propertyValue), out int value))
                              return false;
                         SetPropertyValue<Int32?>(propertyName, value);
                    }
                    else
                    {
                         SetPropertyValue<Int32?>(propertyName, null);
                    }
               }
               if (Properties[propertyName] is PropertyValue<Int64?>)
               {
                    if (!Object.Equals(propertyValue, null) && !(Convert.ToString(propertyValue) == ""))
                    {
                         if (!long.TryParse(Convert.ToString(propertyValue), out long value))
                              return false;
                         SetPropertyValue<Int64?>(propertyName, value);
                    }
                    else
                    {
                         SetPropertyValue<Int64?>(propertyName, null);
                    }
               }
               if (Properties[propertyName] is PropertyValue<DateTime?>)
               {
                    if (!Object.Equals(propertyValue, null) && !(Convert.ToString(propertyValue) == ""))
                    {
                         if (!DateTime.TryParse(Convert.ToString(propertyValue), out DateTime value))
                              return false;
                         SetPropertyValue<DateTime?>(propertyName, value);
                    }
                    else
                    {
                         SetPropertyValue<DateTime?>(propertyName, null);
                    }
               }
               if (Properties[propertyName] is PropertyValue<decimal?>)
               {
                    if (!Object.Equals(propertyValue, null) && !(Convert.ToString(propertyValue) == ""))
                    {
                         if (!decimal.TryParse(Convert.ToString(propertyValue), out decimal value))
                              return false;
                         SetPropertyValue<decimal?>(propertyName, value);
                    }
                    else
                    {
                         SetPropertyValue<decimal?>(propertyName, null);
                    }
               }
               if (Properties[propertyName] is PropertyValue<Single?>)
               {
                    if (!Object.Equals(propertyValue, null) && !(Convert.ToString(propertyValue) == ""))
                    {
                         if (!Single.TryParse(Convert.ToString(propertyValue), out Single value))
                              return false;
                         SetPropertyValue<Single?>(propertyName, value);
                    }
                    else
                    {
                         SetPropertyValue<Single?>(propertyName, null);
                    }
               }
               if (Properties[propertyName] is PropertyValue<double?>)
               {
                    if (!Object.Equals(propertyValue, null) && !(Convert.ToString(propertyValue) == ""))
                    {
                         if (!double.TryParse(Convert.ToString(propertyValue), out double value))
                              return false;
                         SetPropertyValue<double?>(propertyName, value);
                    }
                    else
                    {
                         SetPropertyValue<double?>(propertyName, null);
                    }
               }
               return true;
          }

          /// <summary>
          /// Agregars the propiedad.
          /// </summary>
          /// <typeparam name="TValue">The type of the value.</typeparam>
          /// <param name="propertyName">Name of the ps.</param>
          /// <param name="propertyColumn">The po property.</param>
          /// <exception cref="Exception"></exception>
          protected void AddProperty<TValue>(string propertyName, PropertyValue<TValue> propertyColumn)
          {
               if (Object.Equals(Properties, null))
                    Properties = new Dictionary<string, Property>();
               if (ExistsProperty(propertyName.ToUpper()))
               {
                    throw new Exception($"E00000071|{propertyName}");
               }
               Properties.Add(propertyName.ToUpper(), propertyColumn);
          }

          /// <summary>
          /// Gets the property.
          /// </summary>
          /// <typeparam name="TValue">The type of the value.</typeparam>
          /// <param name="propertyName">Name of the ps.</param>
          /// <returns></returns>
          /// <exception cref="System.Exception">
          /// </exception>
          protected PropertyValue<TValue> GetProperty<TValue>(string propertyName)
          {
               PropertyValue<TValue> propertyColumn;
               if (!ExistsProperty(propertyName))
               {
                    return default;
               }
               propertyColumn = Properties[propertyName.ToUpper()] as PropertyValue<TValue>;
               if (propertyColumn == null)
               {
                    return default;
               }
               return propertyColumn;
          }

          protected PropertyValue<TValue> GetProperty<TValue>(int propertyId)
          {
               return GetProperty<TValue>(GetNameProperty(propertyId));
          }

          /// <summary>
          /// Determines whether the specified ps name has property.
          /// </summary>
          /// <param name="propertyName">Name of the ps.</param>
          /// <returns></returns>
          protected bool ExistsProperty(string propertyName)
          {
               return Properties?.ContainsKey(propertyName.ToUpper()) ?? false;
          }

          /// <summary>
          /// Gets the name property.
          /// </summary>
          /// <param name="id">The identifier.</param>
          /// <returns></returns>
          public string GetNameProperty(int id)
          {
               foreach (var property in Properties)
               {
                    if (property.Value.FieldId == id)
                         return property.Key;
               }
               throw new Exception($"E00000074|{TableName()}");
          }

          public Property GetPropertyById(int id)
          {
               foreach (var property in Properties)
               {
                    if (property.Value.FieldId == id)
                         return property.Value;
               }
               throw new Exception($"E00000074|{TableName()}");
          }

          public Property GetPropertyByName(string key)
          {
               foreach (var property in Properties)
               {
                    if (string.Equals(property.Key, key, StringComparison.OrdinalIgnoreCase))
                         return property.Value;
               }
               throw new Exception($"E00000075|{TableName()}");
          }

          #endregion Methods for managing catalog properties

          #region Functions for custom validations

          #region Prewrite validations        
          /// <summary>
          /// Funcion pra personalizar el grabar en una los registros
          /// </summary>
          protected virtual void CustomValidationForNewPreWriteRegister()
          {
          }
          #endregion Prewrite validations

          #region Postwrite

          /// <summary>
          /// Funcion pra personalizar el grabar en una los registros
          /// </summary>
          protected virtual void CustomValidationForPostWrite()
          {
          }
          protected virtual void LoadColumnProperties()
          {

          }
          #endregion Postwrite

          #region Extrenal Constructor

          protected virtual void PosLoadDataValues()
          {
          }
          protected virtual void LoadFieldVirtualValues()
          {

          }
          protected virtual void SaveVirtualValues()
          {

          }

          #endregion Extrenal Constructor

          #endregion Functions for custom validations

          #region Methods for ABC                    

          public T? Execute<T>() where T : class, new()
          {
               if (_DataAccess == null)
                    return default;
               lock (_lock)
               {
                    using (var connection = new ConnectionHandler(_DataAccess))
                    {
                         try
                         {
                              _ErrorMessage = new List<string>();
                              //Validaciones previas sobre el procedimiento
                              CustomValidationForNewPreWriteRegister();
                              if (ExistErrors())
                                   return default;
                              ValidateAndCreateQueryForInsertWithSqlParameters();
                              var response = _DataAccess.GetGenericCollectionDataReaderWithSP<T>(TableName(), _sqlParameterList).FirstOrDefault();
                              //Validaciones posteriores sobre el procedimiento
                              CustomValidationForPostWrite();
                              return response;
                         }
                         catch (Exception ex)
                         {
                              _ErrorMessage.Add(ex.ToString());
                         }
                    }
               }
               return default;
          }
          public T? ExecuteScalar<T>()
          {
               if (_DataAccess == null)
                    return default;
               using (var connection = new ConnectionHandler(_DataAccess))
               {
                    try
                    {
                         _ErrorMessage = new List<string>();
                         ValidateAndCreateQueryForInsertWithSqlParameters();
                         return _DataAccess.StoreProcedureExecuteScalar<T>(TableName(), _sqlParameterList);
                    }
                    catch (Exception ex)
                    {
                         //Manejo de exceptiones
                         _ErrorMessage.Add(ex.ToString());
                         return default;
                    }
               }
          }
          public Pagination<T>? GetPagination<T>() where T : class, new()
          {
               List<T>? list = GetList<T>();               
               return new Pagination<T>() { PageNumber = list.GetValue<int,T>("PageNumber"), RowsOfPage = list.GetValue<int,T>("RowsOfPage"), TotalRows = list.GetValue<int,T>("TotalRows"), Data =list };
          }
          public List<T>? GetList<T>() where T : class, new()
          {
               if (_DataAccess == null)
                    return default;
               using (var connection = new ConnectionHandler(_DataAccess))
               {
                    try
                    {
                         _ErrorMessage = new List<string>();
                         ValidateAndCreateQueryForInsertWithSqlParameters();
                         return _DataAccess.GetGenericCollectionDataReaderWithSP<T>(TableName(), _sqlParameterList).ToList();
                    }
                    catch (Exception ex)
                    {
                         _ErrorMessage.Add(ex.ToString());
                         //Manejo de exceptiones
                         return default;
                    }
               }
          }

          public List<T1>? GetList<T1, T2>() where T1 : class, new()
          {
               if (_DataAccess == null)
                    return default;
               lock (_lock)
               {
                    using (var connection = new ConnectionHandler(_DataAccess))
                    {
                         try
                         {
                              _ErrorMessage = new List<string>();
                              //Validaciones previas sobre el procedimiento
                              CustomValidationForNewPreWriteRegister();
                              if (ExistErrors())
                                   return default;
                              ValidateAndCreateQueryForInsertWithSqlParameters<T2>();
                              var response = _DataAccess.GetGenericCollectionDataReaderWithSP<T1>(TableName(), _sqlParameterList).ToList();
                              //Validaciones posteriores sobre el procedimiento
                              CustomValidationForPostWrite();
                              return response;
                         }
                         catch (Exception ex)
                         {
                              _ErrorMessage.Add(ex.ToString());
                         }
                    }
               }
               return default;
          }


          #endregion Methods for ABC

          #region Internal Metodos for validations
          private bool ValidateAndCreateQueryForInsertWithSqlParameters()
          {
               // Esta funcion se pone a prueba de desempeño, con el fin de evaluar el uso de switch dinamico
               StringBuilder query;
               PropertyValue<byte> byteProperty;
               PropertyValue<Int16> int16Property;
               PropertyValue<Int32> inte32Property;
               PropertyValue<Int64> int64Property;
               PropertyValue<double> doubleProperty;
               PropertyValue<Single> singleProperty;
               PropertyValue<bool> boolProperty;
               PropertyValue<byte[]> bytesProperty;
               PropertyValue<string> stringProperty;
               PropertyValue<Guid> guidProperty;
               PropertyValue<DateTime> dateTimeProperty;
               PropertyValue<DateTimeOffset> dateTimeOffsetPropertie;
               PropertyValue<decimal> decimalProperty;
               PropertyValue<object> objectProperty;
               PropertyValue<byte?> byteNProperty;
               PropertyValue<Int16?> int16NProperty;
               PropertyValue<Int32?> int32NProperty;
               PropertyValue<Int64?> int64NProperty;
               PropertyValue<double?> doubleNProperty;
               PropertyValue<Single?> singleNProperty;
               PropertyValue<bool?> boolNProperty;
               PropertyValue<DateTime?> dateTimeNProperty;
               PropertyValue<DateTimeOffset?> dateTimeOffsetNPropertie;
               PropertyValue<decimal?> decimalNProperty;

               string name;
               _sqlParameterList = new List<ParameterSql>();
               foreach (KeyValuePair<string, Property> loColumna in Properties)
               {
                    //Hay campos en la base de datos que contiene espacios o caracteres como %, arreglamos los valores para poder hacer los querys
                    if (loColumna.Key.Contains("%"))
                         name = string.Format("@{0}", loColumna.Key.Replace("%", "_"));
                    else if (loColumna.Key.Contains(" "))
                         name = string.Format("@{0}", loColumna.Key.Replace(" ", "_"));
                    else
                         name = string.Format("@{0}", loColumna.Key);
                    new Switch(loColumna.Value)
                         .Case<PropertyValue<bool>>(_ =>
                         {
                              boolProperty = loColumna.Value as PropertyValue<bool>;
                              _sqlParameterList.Add(new ParameterSql(name, boolProperty.Value));
                         })
                         .Case<PropertyValue<byte>>(_ =>
                         {
                              byteProperty = loColumna.Value as PropertyValue<byte>;
                              _sqlParameterList.Add(new ParameterSql(name, byteProperty.Value));
                         })
                         .Case<PropertyValue<Int16>>(_ =>
                         {
                              int16Property = loColumna.Value as PropertyValue<Int16>;
                              _sqlParameterList.Add(new ParameterSql(name, int16Property.Value));
                         })
                         .Case<PropertyValue<Int32>>(_ =>
                         {
                              inte32Property = loColumna.Value as PropertyValue<Int32>;
                              _sqlParameterList.Add(new ParameterSql(name, inte32Property.Value));
                         })
                         .Case<PropertyValue<Int64>>(_ =>
                         {
                              int64Property = loColumna.Value as PropertyValue<Int64>;
                              _sqlParameterList.Add(new ParameterSql(name, int64Property.Value));
                         })
                         .Case<PropertyValue<DateTime>>(_ =>
                         {
                              dateTimeProperty = loColumna.Value as PropertyValue<DateTime>;
                              _sqlParameterList.Add(new ParameterSql(name, dateTimeProperty.Value.DateSqlParameters(true)));


                         })
                         .Case<PropertyValue<DateTimeOffset>>(_ =>
                         {
                              dateTimeOffsetPropertie = loColumna.Value as PropertyValue<DateTimeOffset>;
                              _sqlParameterList.Add(new ParameterSql(name, dateTimeOffsetPropertie.Value.DateSqlParameters(true)));
                         })
                         .Case<PropertyValue<decimal>>(_ =>
                         {
                              decimalProperty = loColumna.Value as PropertyValue<decimal>;
                              _sqlParameterList.Add(new ParameterSql(name, decimalProperty.Value));
                         })
                         .Case<PropertyValue<Single>>(_ =>
                         {
                              singleProperty = loColumna.Value as PropertyValue<Single>;
                              _sqlParameterList.Add(new ParameterSql(name, singleProperty.Value));
                         })
                         .Case<PropertyValue<double>>(_ =>
                         {
                              doubleProperty = loColumna.Value as PropertyValue<double>;
                              _sqlParameterList.Add(new ParameterSql(name, doubleProperty.Value));
                         })
                         .Case<PropertyValue<object>>(_ =>
                         {
                              objectProperty = loColumna.Value as PropertyValue<object>;
                              _sqlParameterList.Add(new ParameterSql(name, objectProperty.Value));
                         })
                         .Case<PropertyValue<byte[]>>(_ =>
                         {
                              bytesProperty = loColumna.Value as PropertyValue<byte[]>;
                              if (bytesProperty.Value == null)
                                   _sqlParameterList.Add(new ParameterSql(name, global::System.Data.SqlTypes.SqlBinary.Null));//new Byte[] { }));
                              else
                                   _sqlParameterList.Add(new ParameterSql(name, bytesProperty.Value));
                         })
                         .Case<PropertyValue<string>>(_ =>
                         {
                              stringProperty = loColumna.Value as PropertyValue<string>;
                              _sqlParameterList.Add(new ParameterSql(name, stringProperty.Value));
                         })
                          .Case<PropertyValue<Guid>>(_ =>
                          {
                               guidProperty = loColumna.Value as PropertyValue<Guid>;
                               _sqlParameterList.Add(new ParameterSql(name, guidProperty.Value));

                          })
                         .Case<PropertyValue<byte?>>(_ =>
                         {
                              byteNProperty = loColumna.Value as PropertyValue<byte?>;
                              _sqlParameterList.Add(new ParameterSql(name, byteNProperty.Value));
                         })
                         .Case<PropertyValue<bool?>>(_ =>
                         {
                              boolNProperty = loColumna.Value as PropertyValue<bool?>;
                              _sqlParameterList.Add(new ParameterSql(name, boolNProperty.Value));
                         })
                         .Case<PropertyValue<Int16?>>(_ =>
                         {
                              int16NProperty = loColumna.Value as PropertyValue<Int16?>;
                              _sqlParameterList.Add(new ParameterSql(name, int16NProperty.Value));
                         })
                         .Case<PropertyValue<Int32?>>(_ =>
                         {
                              int32NProperty = loColumna.Value as PropertyValue<Int32?>;
                              _sqlParameterList.Add(new ParameterSql(name, int32NProperty.Value));
                         })
                         .Case<PropertyValue<Int64?>>(_ =>
                         {
                              int64NProperty = loColumna.Value as PropertyValue<Int64?>;
                              _sqlParameterList.Add(new ParameterSql(name, int64NProperty.Value));
                         })
                         .Case<PropertyValue<DateTime?>>(_ =>
                         {
                              dateTimeNProperty = loColumna.Value as PropertyValue<DateTime?>;
                              if (!Object.Equals(dateTimeNProperty.Value, null) && !Object.Equals(dateTimeNProperty.Value, default(DateTime)))
                                   _sqlParameterList.Add(new ParameterSql(name, Convert.ToDateTime(dateTimeNProperty.Value).DateSqlParameters(true)));
                              else
                                   _sqlParameterList.Add(new ParameterSql(name, dateTimeNProperty.Value));
                         })
                         .Case<PropertyValue<DateTimeOffset?>>(_ =>
                         {
                              dateTimeOffsetNPropertie = loColumna.Value as PropertyValue<DateTimeOffset?>;
                              if (!Object.Equals(dateTimeOffsetNPropertie.Value, null) && !Object.Equals(dateTimeOffsetNPropertie.Value, default(DateTime)))
                                   _sqlParameterList.Add(new ParameterSql(name, Convert.ToDateTime(dateTimeOffsetNPropertie.Value).DateSqlParameters(true)));
                              else
                                   _sqlParameterList.Add(new ParameterSql(name, dateTimeOffsetNPropertie.Value));
                         })
                         .Case<PropertyValue<decimal?>>(_ =>
                         {
                              decimalNProperty = loColumna.Value as PropertyValue<decimal?>;
                              _sqlParameterList.Add(new ParameterSql(name, decimalNProperty.Value));
                         })
                         .Case<PropertyValue<Single?>>(_ =>
                         {
                              singleNProperty = loColumna.Value as PropertyValue<Single?>;
                              _sqlParameterList.Add(new ParameterSql(name, singleNProperty.Value));
                         })
                         .Case<PropertyValue<double?>>(_ =>
                         {
                              doubleNProperty = loColumna.Value as PropertyValue<double?>;

                              _sqlParameterList.Add(new ParameterSql(name, doubleNProperty.Value));
                         });
               }

               return true;
          }

          private bool ValidateAndCreateQueryForInsertWithSqlParameters<T>()
          {
               // Esta funcion se pone a prueba de desempeño, con el fin de evaluar el uso de switch dinamico
               StringBuilder query;
               PropertyValue<byte> byteProperty;
               PropertyValue<Int16> int16Property;
               PropertyValue<Int32> inte32Property;
               PropertyValue<Int64> int64Property;
               PropertyValue<double> doubleProperty;
               PropertyValue<Single> singleProperty;
               PropertyValue<bool> boolProperty;
               PropertyValue<byte[]> bytesProperty;
               PropertyValue<string> stringProperty;
               PropertyValue<Guid> guidProperty;
               PropertyValue<DateTime> dateTimeProperty;
               PropertyValue<DateTimeOffset> dateTimeOffsetPropertie;
               PropertyValue<decimal> decimalProperty;
               PropertyValue<object> objectProperty;
               PropertyValue<byte?> byteNProperty;
               PropertyValue<Int16?> int16NProperty;
               PropertyValue<Int32?> int32NProperty;
               PropertyValue<Int64?> int64NProperty;
               PropertyValue<double?> doubleNProperty;
               PropertyValue<Single?> singleNProperty;
               PropertyValue<bool?> boolNProperty;
               PropertyValue<DateTime?> dateTimeNProperty;
               PropertyValue<DateTimeOffset?> dateTimeOffsetNPropertie;
               PropertyValue<decimal?> decimalNProperty;
               PropertyValue<List<T>> listProperty;

               string name;
               _sqlParameterList = new List<ParameterSql>();
               foreach (KeyValuePair<string, Property> loColumna in Properties)
               {
                    //Hay campos en la base de datos que contiene espacios o caracteres como %, arreglamos los valores para poder hacer los querys
                    if (loColumna.Key.Contains("%"))
                         name = string.Format("@{0}", loColumna.Key.Replace("%", "_"));
                    else if (loColumna.Key.Contains(" "))
                         name = string.Format("@{0}", loColumna.Key.Replace(" ", "_"));
                    else
                         name = string.Format("@{0}", loColumna.Key);
                    new Switch(loColumna.Value)
                         .Case<PropertyValue<bool>>(_ =>
                         {
                              boolProperty = loColumna.Value as PropertyValue<bool>;
                              _sqlParameterList.Add(new ParameterSql(name, boolProperty.Value));
                         })
                         .Case<PropertyValue<byte>>(_ =>
                         {
                              byteProperty = loColumna.Value as PropertyValue<byte>;
                              _sqlParameterList.Add(new ParameterSql(name, byteProperty.Value));
                         })
                         .Case<PropertyValue<Int16>>(_ =>
                         {
                              int16Property = loColumna.Value as PropertyValue<Int16>;
                              _sqlParameterList.Add(new ParameterSql(name, int16Property.Value));
                         })
                         .Case<PropertyValue<Int32>>(_ =>
                         {
                              inte32Property = loColumna.Value as PropertyValue<Int32>;
                              _sqlParameterList.Add(new ParameterSql(name, inte32Property.Value));
                         })
                         .Case<PropertyValue<Int64>>(_ =>
                         {
                              int64Property = loColumna.Value as PropertyValue<Int64>;
                              _sqlParameterList.Add(new ParameterSql(name, int64Property.Value));
                         })
                         .Case<PropertyValue<DateTime>>(_ =>
                         {
                              dateTimeProperty = loColumna.Value as PropertyValue<DateTime>;
                              _sqlParameterList.Add(new ParameterSql(name, dateTimeProperty.Value.DateSqlParameters(true)));


                         })
                         .Case<PropertyValue<DateTimeOffset>>(_ =>
                         {
                              dateTimeOffsetPropertie = loColumna.Value as PropertyValue<DateTimeOffset>;
                              _sqlParameterList.Add(new ParameterSql(name, dateTimeOffsetPropertie.Value.DateSqlParameters(true)));
                         })
                         .Case<PropertyValue<decimal>>(_ =>
                         {
                              decimalProperty = loColumna.Value as PropertyValue<decimal>;
                              _sqlParameterList.Add(new ParameterSql(name, decimalProperty.Value));
                         })
                         .Case<PropertyValue<Single>>(_ =>
                         {
                              singleProperty = loColumna.Value as PropertyValue<Single>;
                              _sqlParameterList.Add(new ParameterSql(name, singleProperty.Value));
                         })
                         .Case<PropertyValue<double>>(_ =>
                         {
                              doubleProperty = loColumna.Value as PropertyValue<double>;
                              _sqlParameterList.Add(new ParameterSql(name, doubleProperty.Value));
                         })
                         .Case<PropertyValue<object>>(_ =>
                         {
                              objectProperty = loColumna.Value as PropertyValue<object>;
                              _sqlParameterList.Add(new ParameterSql(name, objectProperty.Value));
                         })
                         .Case<PropertyValue<byte[]>>(_ =>
                         {
                              bytesProperty = loColumna.Value as PropertyValue<byte[]>;
                              if (bytesProperty.Value == null)
                                   _sqlParameterList.Add(new ParameterSql(name, global::System.Data.SqlTypes.SqlBinary.Null));//new Byte[] { }));
                              else
                                   _sqlParameterList.Add(new ParameterSql(name, bytesProperty.Value));
                         })
                         .Case<PropertyValue<string>>(_ =>
                         {
                              stringProperty = loColumna.Value as PropertyValue<string>;
                              _sqlParameterList.Add(new ParameterSql(name, stringProperty.Value));
                         })
                          .Case<PropertyValue<Guid>>(_ =>
                          {
                               guidProperty = loColumna.Value as PropertyValue<Guid>;
                               _sqlParameterList.Add(new ParameterSql(name, guidProperty.Value));

                          })
                         .Case<PropertyValue<byte?>>(_ =>
                         {
                              byteNProperty = loColumna.Value as PropertyValue<byte?>;
                              _sqlParameterList.Add(new ParameterSql(name, byteNProperty.Value));
                         })
                         .Case<PropertyValue<bool?>>(_ =>
                         {
                              boolNProperty = loColumna.Value as PropertyValue<bool?>;
                              _sqlParameterList.Add(new ParameterSql(name, boolNProperty.Value));
                         })
                         .Case<PropertyValue<Int16?>>(_ =>
                         {
                              int16NProperty = loColumna.Value as PropertyValue<Int16?>;
                              _sqlParameterList.Add(new ParameterSql(name, int16NProperty.Value));
                         })
                         .Case<PropertyValue<Int32?>>(_ =>
                         {
                              int32NProperty = loColumna.Value as PropertyValue<Int32?>;
                              _sqlParameterList.Add(new ParameterSql(name, int32NProperty.Value));
                         })
                         .Case<PropertyValue<Int64?>>(_ =>
                         {
                              int64NProperty = loColumna.Value as PropertyValue<Int64?>;
                              _sqlParameterList.Add(new ParameterSql(name, int64NProperty.Value));
                         })
                         .Case<PropertyValue<DateTime?>>(_ =>
                         {
                              dateTimeNProperty = loColumna.Value as PropertyValue<DateTime?>;
                              if (!Object.Equals(dateTimeNProperty.Value, null) && !Object.Equals(dateTimeNProperty.Value, default(DateTime)))
                                   _sqlParameterList.Add(new ParameterSql(name, Convert.ToDateTime(dateTimeNProperty.Value).DateSqlParameters(true)));
                              else
                                   _sqlParameterList.Add(new ParameterSql(name, dateTimeNProperty.Value));
                         })
                         .Case<PropertyValue<DateTimeOffset?>>(_ =>
                         {
                              dateTimeOffsetNPropertie = loColumna.Value as PropertyValue<DateTimeOffset?>;
                              if (!Object.Equals(dateTimeOffsetNPropertie.Value, null) && !Object.Equals(dateTimeOffsetNPropertie.Value, default(DateTime)))
                                   _sqlParameterList.Add(new ParameterSql(name, Convert.ToDateTime(dateTimeOffsetNPropertie.Value).DateSqlParameters(true)));
                              else
                                   _sqlParameterList.Add(new ParameterSql(name, dateTimeOffsetNPropertie.Value));
                         })
                         .Case<PropertyValue<decimal?>>(_ =>
                         {
                              decimalNProperty = loColumna.Value as PropertyValue<decimal?>;
                              _sqlParameterList.Add(new ParameterSql(name, decimalNProperty.Value));
                         })
                         .Case<PropertyValue<Single?>>(_ =>
                         {
                              singleNProperty = loColumna.Value as PropertyValue<Single?>;
                              _sqlParameterList.Add(new ParameterSql(name, singleNProperty.Value));
                         })
                         .Case<PropertyValue<double?>>(_ =>
                         {
                              doubleNProperty = loColumna.Value as PropertyValue<double?>;

                              _sqlParameterList.Add(new ParameterSql(name, doubleNProperty.Value));
                         })
                         .Case<PropertyValue<List<T>>>(_ =>
                         {
                              listProperty = loColumna.Value as PropertyValue<List<T>>;
                              _sqlParameterList.Add(new ParameterSql(name, listProperty.Value.ToDataTable(), listProperty.TypeName));
                         }
                         );
                    ;
               }

               return true;
          }

          #endregion Internal Metodos for validations




     }
}
