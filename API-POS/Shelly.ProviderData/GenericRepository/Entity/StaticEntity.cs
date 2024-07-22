
using Shelly.Abstractions.Constants;
using Shelly.ProviderData.Helper;

namespace Shelly.ProviderData.GenericRepository.Entity
{
    /// <summary>
    /// Clase que contiene las funciones basicas para el manejo de tablas del sistema
    /// Actualmete solo funcion para las tablas que no son de metadatos
    /// </summary>
    [Serializable]
     public class StaticEntity : DynamicObject, IDynamicMetaObjectProvider
     {
          #region Variables
          private readonly object _lock = new object();
          protected internal IBaseSystem _System;
          public bool _isNew;
          private bool _existsLogData;
          private bool _existsChanges;
          private bool _existsChangesField;
          private string _HistoryFields;
          protected List<ParameterSql> _sqlParameterList;
          public StringBuilder _fields;
          private bool _containsIdentityFields;
          private string constMask = "**********";
          public int _Count;
          protected internal DataAccess _Connection;
          #endregion Variables

          #region Properties
          protected DateTime DefaultDateTime
          {
               get
               {
                    return new DateTime(1900, 1, 1);
               }
          }

          public bool IsImplementation { get; set; }
          public IBaseSystem System
          {
               get
               {
                    return _System;
               }
               set
               {
                     _System = value;
               }
          }
          public DataAccess Connection
          {
               get
               {
                    return _Connection;
               }
          }


          public Dictionary<string, Property> Properties { get; set; }


          public Dictionary<string, object> KeyFields { get; set; }

          public Dictionary<int, Dictionary<int, int>> Relations { get; set; }

          public string Table { get; set; }
          public int Level { get; set; }

          public string NumberTable { get; set; }

          public string Prefix { get; set; }

          public string Owner { get; set; }

          public bool EOF { get; set; }

          public bool AddHistory { get; set; }

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

          /// <summary>
          /// Gets or sets the archivo bitacora salida.
          /// </summary>
          /// <value>
          /// The archivo bitacora salida.
          /// </value>
          public byte[] LogDataBuffer { get; set; }

          /// <summary>
          /// Gets or sets the nombre reporte bitacora.
          /// </summary>
          /// <value>
          /// The nombre reporte bitacora.
          /// </value>
          public string LogDataReportName { get; set; }

          /// <summary>
          /// Gets or sets the cultura.
          /// </summary>
          /// <value>
          /// The cultura.
          /// </value>
          public string Culture { get; set; }

          /// <summary>
          /// Gets or sets the modified fields.
          /// </summary>
          /// <value>
          /// The modified fields.
          /// </value>
          public HashSet<string> ModifiedFields { get; set; }

          /// <summary>
          /// Gets or sets the temporary path.
          /// </summary>
          /// <value>
          /// The temporary path.
          /// </value>
          public string TmpPath { get; set; }
          /// <summary>
          /// _externalFilter
          /// </summary>
          public string ExternalFilter { get; set; }
          public int TotalRows { get; set; }
          public int PageNumber { get; set; }
          public int RowsOfPage { get; set; }
          #endregion Properties

          #region Builders

          /// <summary>
          /// Constructor para los Generics, dado que requieren un constructor sin parametros publico
          /// </summary>
          public StaticEntity()
          {
               InternalBuilder("", "");

          }

          /// <summary>
          /// Constructor sobre cargado para la formula
          /// </summary>
          /// <param name="system">Variable del sistema</param>
          public StaticEntity(IBaseSystem system) : this()//invoca el otro constructor
          {
               _System = system;
               _Connection = (DataAccess)system.Connection;
          }
          /// <summary>
          /// StaticCatalogElement
          /// </summary>
          /// <param name="system"></param>
          /// <param name="prefix"></param>
          public StaticEntity(IBaseSystem system, string prefix)
          {
               _System = system;
               _Connection = (DataAccess)system.Connection;
               InternalBuilder(prefix, "");
          }
          /// <summary>
          ///StaticCatalogElement
          /// </summary>
          /// <param name="system"></param>
          /// <param name="prefix"></param>
          /// <param name="numbertable"></param>
          public StaticEntity(IBaseSystem system, string prefix, string numbertable)
          {
               _System = system;
               _Connection = (DataAccess)system.Connection;
               InternalBuilder(prefix, numbertable);
          }

          /// <summary>
          /// Constructo interno de la clase
          /// </summary>
          private void InternalBuilder(string prefix, string numbertable)
          {
               _isNew = false;
               EOF = true;
               _existsLogData = false;
               Owner = "dbo";
               Prefix = prefix;
               NumberTable = numbertable;
               AddHistory = false;
               _sqlParameterList = new List<ParameterSql>();
               _fields = new StringBuilder();
               ModifiedFields = new HashSet<string>();
          }

          #endregion Builders

          #region Methods for managing catalog properties

          /// <summary>
          /// Tables the name.
          /// </summary>
          /// <returns></returns>
          public string TableName()
          {
               return TableName(false, false, true, "");
          }

          /// <summary>
          /// Tables the name.
          /// </summary>
          /// <param name="catalogHistory">if set to <c>true</c> [catalog history].</param>
          /// <returns></returns>
          public string TableName(bool catalogHistory)
          {
               return TableName(catalogHistory, false, true, "");
          }

          /// <summary>
          /// Tables the name.
          /// </summary>
          /// <param name="catalogHistory">if set to <c>true</c> [catalog history].</param>
          /// <param name="isTableHistory">if set to <c>true</c> [is table history].</param>
          /// <returns></returns>
          public string TableName(bool catalogHistory, bool isTableHistory)
          {
               return TableName(catalogHistory, isTableHistory, true, "");
          }

          /// <summary>
          /// Tables the name.
          /// </summary>
          /// <param name="catalogHistory">if set to <c>true</c> [catalog history].</param>
          /// <param name="isTableHistory">if set to <c>true</c> [is table history].</param>
          /// <param name="prefixObject">if set to <c>true</c> [prefix object].</param>
          /// <returns></returns>
          public string TableName(bool catalogHistory, bool isTableHistory, bool prefixObject)
          {
               return TableName(catalogHistory, isTableHistory, prefixObject, "");
          }

          /// <summary>
          /// Tables the name.
          /// </summary>
          /// <param name="catalogHistory">if set to <c>true</c> [catalog history].</param>
          /// <param name="isTableHistory">if set to <c>true</c> [is table history].</param>
          /// <param name="prefixObject">if set to <c>true</c> [prefix object].</param>
          /// <param name="tableName">Name of the table.</param>
          /// <returns></returns>
          public string TableName(bool catalogHistory, bool isTableHistory, bool prefixObject, string tableName)
          {
               string catalog = Connection.DataBase.Catalog;
               string owner = Connection.DataBase.Owner;
               string auxTableName;
               Connection.DataBase.Owner = Owner;
               switch (Level)
               {
                    case 1:
                         Connection.DataBase.Catalog = "UUMsCore";
                         break;
                    case 2:
                         Connection.DataBase.Catalog = "AccountManagement";
                         break;
               }
               if (string.IsNullOrEmpty(tableName))
                    tableName = $"{Prefix}{Table}{NumberTable}";
               else
                    tableName = $"{Prefix}{tableName}{NumberTable}";
               auxTableName = Connection.TableName(tableName, prefixObject, catalogHistory, isTableHistory);
               Connection.DataBase.Owner = owner;
               Connection.DataBase.Catalog = catalog;
               return auxTableName;
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
          public TValue GetPropertyOldValue<TValue>(string nameProperty)
          {
               PropertyValue<TValue> property = GetProperty<TValue>(nameProperty);
               if (property != null)
               {
                    return property.OldValue;
               }
               return default;
          }
          /// <summary>
          /// Obteners the valor propiedad.
          /// </summary>
          /// <param name="nameProperty">Name of the ps.</param>
          /// <returns></returns>
          /// <exception cref="System.Exception"></exception>
          public object? GetPropertyValue(string nameProperty)
          {
               nameProperty = nameProperty.ToUpper();
               if (!ExistsProperty(nameProperty))
               {
                    throw new CoreException(Errors.E00000070,$"{nameProperty},{TableName()}");
               }
               if (Properties[nameProperty] is PropertyValue<bool>)
               {
                    return GetPropertyValue<bool>(nameProperty);
               }
               if (Properties[nameProperty] is PropertyValue<byte>)
               {
                    return GetPropertyValue<byte>(nameProperty);
               }
               if (Properties[nameProperty] is PropertyValue<short>)
               {
                    return GetPropertyValue<short>(nameProperty);
               }
               if (Properties[nameProperty] is PropertyValue<int>)
               {
                    return GetPropertyValue<int>(nameProperty);
               }
               if (Properties[nameProperty] is PropertyValue<long>)
               {
                    return GetPropertyValue<long>(nameProperty);
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
               if (Properties[nameProperty] is PropertyValue<float>)
               {
                    return GetPropertyValue<float>(nameProperty);
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
               if (Properties[nameProperty] is PropertyValue<short?>)
               {
                    return GetPropertyValue<short?>(nameProperty);
               }
               if (Properties[nameProperty] is PropertyValue<int?>)
               {
                    return GetPropertyValue<int?>(nameProperty);
               }
               if (Properties[nameProperty] is PropertyValue<long?>)
               {
                    return GetPropertyValue<long?>(nameProperty);
               }
               if (Properties[nameProperty] is PropertyValue<DateTime?>)
               {
                    return GetPropertyValue<DateTime?>(nameProperty);
               }
               if (Properties[nameProperty] is PropertyValue<decimal?>)
               {
                    return GetPropertyValue<decimal?>(nameProperty);
               }
               if (Properties[nameProperty] is PropertyValue<float?>)
               {
                    return GetPropertyValue<float?>(nameProperty);
               }
               if (Properties[nameProperty] is PropertyValue<double?>)
               {
                    return GetPropertyValue<double?>(nameProperty);
               }
               return null;
          }

          /// <summary>
          /// Determina si es campo llave
          /// </summary>
          /// <param name="fieldName"></param>
          /// <returns></returns>
          public bool IsKeyField(string fieldName)
          {
               fieldName = fieldName.ToUpper();
               if (!ExistsProperty(fieldName))
               {
                    throw new CoreException(Errors.E00000070,$"{fieldName},{TableName()}");
               }
               return Properties[fieldName].IsPrimaryKey;
          }

          /// <summary>
          /// Sets the property.
          /// </summary>
          /// <typeparam name="TValue">The type of the value.</typeparam>
          /// <param name="propertyName">Name of the property.</param>
          /// <param name="propertyValue">The property value.</param>
          protected void SetPropertyValue<TValue>(string propertyName, TValue propertyValue)
          {
               SetPropertyValue(propertyName, propertyValue, false);
          }

          protected void SetPropertyValue<TValue>(int propertyId, TValue propertyValue)
          {
               SetPropertyValue(GetNameProperty(propertyId), propertyValue, false);
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
                    return;
               }
               propertyColumn.Value = propertyValue;
               if (isLastValue)
               {
                    propertyColumn.OldValue = propertyValue;
               }
               if (propertyValue == null || propertyValue.Equals(default(TValue)) && !propertyColumn.DefaultValue.Equals(default(TValue)))
               {
                    propertyColumn.Value = propertyColumn.DefaultValue;
               }
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
               propertyColumn.Value = propertyColumn.DefaultValue;
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
               short int16Data;
               int int32Data;
               long int64Data;
               DateTime dateTimeData;
               TimeSpan timespanData;
               decimal decimalData;
               double doubleData;
               float isSingle;
               propertyName = propertyName.ToUpper();
               if (!ExistsProperty(propertyName))
               {
                    //WriteLogDataMessage("Error,Can't get property {propertyName} value, because it doesn't exist {TableName()}");
                    throw new CoreException(Errors.E00000070, $"{propertyName},{TableName()}");
               }
               isCorrect = true;
               if (Properties[propertyName] is PropertyValue<bool>)
               {
                    if (!bool.TryParse(Convert.ToString(propertyValue), out booleanData))
                         isCorrect = false;
               }

               if (Properties[propertyName] is PropertyValue<byte>)
               {
                    if (!byte.TryParse(Convert.ToString(propertyValue), out byteData))
                         isCorrect = false;
               }
               if (Properties[propertyName] is PropertyValue<short>)
               {
                    if (!short.TryParse(Convert.ToString(propertyValue), out int16Data))
                         isCorrect = false;
               }
               if (Properties[propertyName] is PropertyValue<int>)
               {
                    if (!int.TryParse(Convert.ToString(propertyValue), out int32Data))
                         isCorrect = false;
               }
               if (Properties[propertyName] is PropertyValue<long>)
               {
                    if (!long.TryParse(Convert.ToString(propertyValue), out int64Data))
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
               if (Properties[propertyName] is PropertyValue<float>)
               {
                    if (!float.TryParse(Convert.ToString(propertyValue), out isSingle))
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
                    if (!Equals(propertyValue, null) && !(Convert.ToString(propertyValue) == ""))
                    {
                         if (!byte.TryParse(Convert.ToString(propertyValue), out byteData))
                              isCorrect = false;
                    }
               }
               if (Properties[propertyName] is PropertyValue<bool?>)
               {
                    if (!Equals(propertyValue, null) && Convert.ToString(propertyValue) != "")
                    {
                         if (!bool.TryParse(Convert.ToString(propertyValue), out booleanData))
                              isCorrect = false;
                    }
               }
               if (Properties[propertyName] is PropertyValue<short?>)
               {
                    if (!Equals(propertyValue, null) && !(Convert.ToString(propertyValue) == ""))
                    {
                         if (!short.TryParse(Convert.ToString(propertyValue), out int16Data))
                              isCorrect = false;
                    }
               }
               if (Properties[propertyName] is PropertyValue<int?>)
               {
                    if (!Equals(propertyValue, null) && !(Convert.ToString(propertyValue) == ""))
                    {
                         if (!int.TryParse(Convert.ToString(propertyValue), out int32Data))
                              isCorrect = false;
                    }
               }
               if (Properties[propertyName] is PropertyValue<long?>)
               {
                    if (!Equals(propertyValue, null) && !(Convert.ToString(propertyValue) == ""))
                    {
                         if (!long.TryParse(Convert.ToString(propertyValue), out int64Data))
                              isCorrect = false;
                    }
               }
               if (Properties[propertyName] is PropertyValue<DateTime?>)
               {
                    if (!Equals(propertyValue, null) && !(Convert.ToString(propertyValue) == ""))
                    {
                         if (!DateTime.TryParse(Convert.ToString(propertyValue), out dateTimeData))
                              isCorrect = false;
                    }
               }
               if (Properties[propertyName] is PropertyValue<decimal?>)
               {
                    if (!Equals(propertyValue, null) && !(Convert.ToString(propertyValue) == ""))
                    {
                         if (!decimal.TryParse(Convert.ToString(propertyValue), out decimalData))
                              isCorrect = false;
                    }
               }
               if (Properties[propertyName] is PropertyValue<float?>)
               {
                    if (!Equals(propertyValue, null))
                    {
                         if (!float.TryParse(Convert.ToString(propertyValue), out isSingle))
                              isCorrect = false;
                    }
               }
               if (Properties[propertyName] is PropertyValue<double?>)
               {
                    if (!Equals(propertyValue, null) && !(Convert.ToString(propertyValue) == ""))
                    {
                         if (!double.TryParse(Convert.ToString(propertyValue), out doubleData))
                              isCorrect = false;
                    }
               }
               if (!isCorrect)
                    throw new CoreException(Errors.E00000070, $"{propertyName}");
               return isCorrect;
          }

          public void SetPropertyValueObject(int propertyId, object propertyValue)
          {
               SetPropertyValue(GetNameProperty(propertyId), propertyValue);
          }

          /// <summary>
          /// Establecers the valor propiedad.
          /// </summary>
          /// <param name="propertyName">Name of the ps.</param>
          /// <param name="propertyValue">The po value.</param>
          /// <exception cref="Exception"></exception>
          public void SetPropertyValue(string propertyName, object propertyValue)
          {
               propertyName = propertyName.ToUpper();
               if (!ExistsProperty(propertyName))
               {
                    throw new CoreException(Errors.E00000070,$"{propertyName},{TableName()}");
               }
               if (Properties[propertyName].IsPrimaryKey)
                    AddKeyField(propertyName, propertyValue);
               if (Properties[propertyName] is PropertyValue<bool>)
               {

                    SetPropertyValue<bool>(propertyName, ExtensionStrings.ToBoolean2(Convert.ToString(propertyValue)));
                    return;
               }
               if (Properties[propertyName] is PropertyValue<byte>)
               {
                    if (!byte.TryParse(Convert.ToString(propertyValue), out byte value))
                         throw new CoreException(Errors.E00000069,$"{Properties[propertyName].Description},{propertyValue}");
                    SetPropertyValue(propertyName, value);
                    return;
               }
               if (Properties[propertyName] is PropertyValue<short>)
               {
                    if (!short.TryParse(Convert.ToString(propertyValue), out short value))
                         throw new CoreException(Errors.E00000069,$"{Properties[propertyName].Description},{propertyValue}");
                    SetPropertyValue(propertyName, value);
                    return;
               }
               if (Properties[propertyName] is PropertyValue<int>)
               {
                    if (!int.TryParse(Convert.ToString(propertyValue), out int value))
                         throw new CoreException(Errors.E00000069,$"{Properties[propertyName].Description},{propertyValue}");
                    SetPropertyValue(propertyName, value);
                    return;
               }
               if (Properties[propertyName] is PropertyValue<long>)
               {
                    if (!long.TryParse(Convert.ToString(propertyValue), out long value))
                         throw new CoreException(Errors.E00000069,$"{Properties[propertyName].Description},{propertyValue}");
                    SetPropertyValue(propertyName, value);
                    return;
               }
               if (Properties[propertyName] is PropertyValue<DateTime>)
               {
                    if (!DateTime.TryParse(Convert.ToString(propertyValue), out DateTime value))
                         throw new CoreException(Errors.E00000069,$"{Properties[propertyName].Description},{propertyValue}");
                    SetPropertyValue(propertyName, value);
                    return;
               }
               if (Properties[propertyName] is PropertyValue<TimeSpan>)
               {
                    if (!TimeSpan.TryParse(Convert.ToString(propertyValue), out TimeSpan value))
                         throw new CoreException(Errors.E00000069,$"{Properties[propertyName].Description},{propertyValue}");
                    SetPropertyValue(propertyName, value);
                    return;
               }
               if (Properties[propertyName] is PropertyValue<decimal>)
               {
                    if (!decimal.TryParse(Convert.ToString(propertyValue), out decimal value))
                         throw new CoreException(Errors.E00000069,$"{Properties[propertyName].Description},{propertyValue}");
                    SetPropertyValue(propertyName, value);
                    return;
               }
               if (Properties[propertyName] is PropertyValue<float>)
               {
                    if (!float.TryParse(Convert.ToString(propertyValue), out float value))
                         throw new CoreException(Errors.E00000069,$"{Properties[propertyName].Description},{propertyValue}");
                    SetPropertyValue(propertyName, value);
                    return;
               }
               if (Properties[propertyName] is PropertyValue<double>)
               {
                    if (!double.TryParse(Convert.ToString(propertyValue), out double value))
                         throw new CoreException(Errors.E00000069,$"{Properties[propertyName].Description},{propertyValue}");
                    SetPropertyValue(propertyName, Convert.ToDouble(propertyValue));
                    return;
               }
               if (Properties[propertyName] is PropertyValue<object>)
               {
                    SetPropertyValue<object>(propertyName, propertyValue);
                    return;
               }
               if (Properties[propertyName] is PropertyValue<byte[]>)
               {
                    if (!string.IsNullOrEmpty(Convert.ToString(propertyValue)))
                    {
                         SetPropertyValue(propertyName, (byte[])propertyValue);
                         return;
                    }
                    else
                    {
                         SetPropertyValue<byte[]>(propertyName, null);
                         return;
                    }
               }
               if (Properties[propertyName] is PropertyValue<string>)
               {
                    if (!Equals(propertyValue, null))
                    {
                         SetPropertyValue<string>(propertyName, Convert.ToString(propertyValue));
                         return;
                    }
                    else
                    {
                         SetPropertyValue<string>(propertyName, null);
                         return;
                    }
               }
               if (Properties[propertyName] is PropertyValue<byte?>)
               {
                    if (!Equals(propertyValue, null) && !(Convert.ToString(propertyValue) == ""))
                    {
                         if (!byte.TryParse(Convert.ToString(propertyValue), out byte value))
                              throw new CoreException(Errors.E00000069,$"{Properties[propertyName].Description},{propertyValue}");
                         SetPropertyValue<byte?>(propertyName, value);
                         return;
                    }
                    else
                    {
                         SetPropertyValue<byte?>(propertyName, null);
                         return;
                    }
               }
               if (Properties[propertyName] is PropertyValue<bool?>)
               {
                    if (!Equals(propertyValue, null) && !(Convert.ToString(propertyValue) == ""))
                    {
                         SetPropertyValue<bool?>(propertyName, ExtensionStrings.ToBoolean2(Convert.ToString(propertyValue)));
                         return;
                    }
                    else
                    {
                         SetPropertyValue<bool?>(propertyName, null);
                         return;
                    }
               }
               if (Properties[propertyName] is PropertyValue<short?>)
               {
                    if (!Equals(propertyValue, null) && !(Convert.ToString(propertyValue) == ""))
                    {
                         if (!short.TryParse(Convert.ToString(propertyValue), out short value))
                              throw new CoreException(Errors.E00000069,$"{Properties[propertyName].Description},{propertyValue}");
                         SetPropertyValue<short?>(propertyName, value);
                         return;
                    }
                    else
                    {
                         SetPropertyValue<short?>(propertyName, null);
                         return;
                    }
               }
               if (Properties[propertyName] is PropertyValue<int?>)
               {
                    if (!Equals(propertyValue, null) && !(Convert.ToString(propertyValue) == ""))
                    {
                         if (!int.TryParse(Convert.ToString(propertyValue), out int value))
                              throw new CoreException(Errors.E00000069,$"{Properties[propertyName].Description},{propertyValue}");
                         SetPropertyValue<int?>(propertyName, value);
                         return;
                    }
                    else
                    {
                         SetPropertyValue<int?>(propertyName, null);
                         return;
                    }
               }
               if (Properties[propertyName] is PropertyValue<long?>)
               {
                    if (!Equals(propertyValue, null) && !(Convert.ToString(propertyValue) == ""))
                    {
                         if (!long.TryParse(Convert.ToString(propertyValue), out long value))
                              throw new CoreException(Errors.E00000069,$"{Properties[propertyName].Description},{propertyValue}");
                         SetPropertyValue<long?>(propertyName, value);
                         return;
                    }
                    else
                    {
                         SetPropertyValue<long?>(propertyName, null);
                         return;
                    }
               }
               if (Properties[propertyName] is PropertyValue<DateTime?>)
               {
                    if (!Equals(propertyValue, null) && !(Convert.ToString(propertyValue) == ""))
                    {
                         if (!DateTime.TryParse(Convert.ToString(propertyValue), out DateTime value))
                              throw new CoreException(Errors.E00000069,$"{Properties[propertyName].Description},{propertyValue}");
                         SetPropertyValue<DateTime?>(propertyName, value);
                         return;
                    }
                    else
                    {
                         SetPropertyValue<DateTime?>(propertyName, null);
                         return;
                    }
               }
               if (Properties[propertyName] is PropertyValue<decimal?>)
               {
                    if (!Equals(propertyValue, null) && !(Convert.ToString(propertyValue) == ""))
                    {
                         if (!decimal.TryParse(Convert.ToString(propertyValue), out decimal value))
                              throw new CoreException(Errors.E00000069,$"{Properties[propertyName].Description},{propertyValue}");
                         SetPropertyValue<decimal?>(propertyName, value);
                    }
                    else
                    {
                         SetPropertyValue<decimal?>(propertyName, null);
                    }
               }
               if (Properties[propertyName] is PropertyValue<float?>)
               {
                    if (!Equals(propertyValue, null) && !(Convert.ToString(propertyValue) == ""))
                    {
                         if (!float.TryParse(Convert.ToString(propertyValue), out float value))
                              throw new CoreException(Errors.E00000069,$"{Properties[propertyName].Description},{propertyValue}");
                         SetPropertyValue<float?>(propertyName, value);
                         return;
                    }
                    else
                    {
                         SetPropertyValue<float?>(propertyName, null);
                         return;
                    }
               }
               if (Properties[propertyName] is PropertyValue<double?>)
               {
                    if (!Equals(propertyValue, null) && !(Convert.ToString(propertyValue) == ""))
                    {
                         if (!double.TryParse(Convert.ToString(propertyValue), out double value))
                              throw new CoreException(Errors.E00000069,$"{Properties[propertyName].Description},{propertyValue}");
                         SetPropertyValue<double?>(propertyName, value);
                         return;
                    }
                    else
                    {
                         SetPropertyValue<double?>(propertyName, null);
                         return;
                    }
               }
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
               if (Equals(Properties, null))
                    Properties = new Dictionary<string, Property>(13);
               if (ExistsProperty(propertyName.ToUpper()))
               {
                    throw new CoreException(Errors.E00000071, $"{propertyName}");
               }
               Properties.Add(propertyName.ToUpper(), propertyColumn);
          }
          protected void AddPropertyValue(string propertyName, object propertyValue)
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
          /// Agregas the campo llave.
          /// </summary>
          /// <param name="keyName">Name of the ps.</param>
          /// <param name="keyValue">The po valor.</param>
          public void AddKeyField(string keyName, object keyValue)
          {
               if (Equals(KeyFields, null))
                    KeyFields = new Dictionary<string, object>();
               KeyFields[keyName.ToUpper()] = keyValue;
          }
          /// <summary>
          /// Adds the relation.
          /// </summary>
          /// <param name="key1">The key1.</param>
          /// <param name="key2">The key2.</param>
          public void AddRelation(int key1, int key2)
          {
               if (Equals(Relations, null))
               {
                    Relations = new Dictionary<int, Dictionary<int, int>>();
                    Relations[0] = new Dictionary<int, int>();
               }
               Relations[0][key1] = key2;
          }
          public object GetKeyFieldValue(string keyName)
          {
               if (!KeyFields.ContainsKey(keyName.ToUpper()))
                    return null;
               return KeyFields[keyName.ToUpper()];
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
                    throw new CoreException(Errors.E00000070,$"{propertyName},{TableName()}");
               }
               propertyColumn = Properties[propertyName.ToUpper()] as PropertyValue<TValue>;
               if (propertyColumn == null)
               {
                    throw new CoreException(Errors.E00000072, $"{typeof(TValue).FullName},{propertyName}");
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
               throw new CoreException(Errors.E00000074, $"{TableName()}");
          }

          public string GetNameProperty(string description)
          {
               foreach (var property in Properties)
               {
                    if (string.Equals(property.Value.Description, description, StringComparison.OrdinalIgnoreCase))
                         return property.Key;
               }
               throw new CoreException(Errors.E00000076, $"{description}");
          }

          public int GetIdProperty(string description)
          {
               foreach (var property in Properties)
               {
                    if (string.Equals(property.Value.Description, description, StringComparison.OrdinalIgnoreCase))
                         return property.Value.FieldId;
               }
               throw new CoreException(Errors.E00000076, $"{description}");
          }

          public Property GetPropertyByDescription(string description)
          {
               foreach (var property in Properties)
               {
                    if (string.Equals(property.Value.Description, description, StringComparison.OrdinalIgnoreCase))
                         return property.Value;
               }
               throw new CoreException(Errors.E00000070,$"{TableName()}");
          }
          public Property GetPropertyById(int id)
          {
               foreach (var property in Properties)
               {
                    if (property.Value.FieldId == id)
                         return property.Value;
               }
               throw new CoreException(Errors.E00000074, $"{TableName()}");
          }

          public Property GetPropertyByName(string key)
          {
               foreach (var property in Properties)
               {
                    if (string.Equals(property.Key, key, StringComparison.OrdinalIgnoreCase))
                         return property.Value;
               }
               throw new CoreException(Errors.E00000075, $"{TableName()}");
          }

          #endregion Methods for managing catalog properties

          #region Functions for custom validations

          #region Prewrite validations

          /// <summary>
          /// Funcion para personal la validacion para un nuevo registro
          /// </summary>
          protected virtual void CustomValidationForNewRegister()
          {
          }

          /// <summary>
          /// Funcion pra personalizar el grabar en una los registros
          /// </summary>
          protected virtual void CustomValidationForNewPreWriteRegister()
          {
          }

          /// <summary>
          /// Funcion para personalr para grabar los cambios en los registros
          /// </summary>
          protected virtual void CustomValidationForPreWriteChanges()
          {
          }

          /// <summary>
          /// Funcion que valida los campos antes de eleimnar n registro
          /// </summary>
          protected virtual void CustomValidationForDeletePreWrite()
          {
          }

          /// <summary>
          /// Loads the new custom values.
          /// </summary>
          protected virtual void LoadNewCustomValues()
          {
          }

          public void ValidationForNewPreWriteRegister()
          {
               LoadNewCustomValues();
               CustomValidationForNewRegister();
               CustomValidationForNewPreWriteRegister();
          }

          public void ValidationForPreWriteChanges()
          {
               CustomValidationForPreWriteChanges();
          }

          public void ValidationForPreDeletePreWrite()
          {
               CustomValidationForDeletePreWrite();
          }

          #endregion Prewrite validations

          #region Postwrite

          /// <summary>
          /// Funcion pra personalizar el grabar en una los registros
          /// </summary>
          protected virtual void CustomValidationForPostWrite()
          {
          }

          /// <summary>
          /// Funcion para personalr para grabar los cambios en los registros
          /// </summary>
          protected virtual void CustomValidationForPosWriteChanges()
          {
          }

          /// <summary>
          /// Funcion que valida los campos antes de eleimnar n registro
          /// </summary>
          protected virtual void CustomValidationForDeletePostWrite()
          {
          }

          public void ValidationForPostWrite()
          {
               CustomValidationForPostWrite();
          }

          public void ValidationForPosWriteChanges()
          {
               CustomValidationForPosWriteChanges();
          }

          public void ValidationForPosDeletePostWrite()
          {
               CustomValidationForDeletePostWrite();
          }
          public void PosLoadDataValuesMetadata()
          {
               PosLoadDataValues();
          }
          public void LoadFieldVirtualValuesMetadata()
          {
               LoadFieldVirtualValues();
          }
          public void SaveVirtualValuesMetadata()
          {
               SaveVirtualValues();
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

          #region Functions for custom validations

          /// <summary>
          /// Validacions the de errros.
          /// </summary>
          /// <param name="fixedCatalog">The po catalogo.</param>
          /// <returns></returns>
          private List<ValidationResult> ValidationError(StaticEntity fixedCatalog)
          {
               List<ValidationResult> validationResults = new List<ValidationResult>();
               ValidationContext context = new ValidationContext(fixedCatalog, null, null);
               Validator.TryValidateObject(fixedCatalog, context, validationResults, true);
               return validationResults;
          }

          #endregion Functions for custom validations

          #region Methods for ABC

          public void CheckAndCreateTableWithNumber()
          {
               if (string.IsNullOrEmpty(NumberTable) || !ExtensionStrings.IsNumeric2(NumberTable))
                    return;
               if (Connection.ExistsObjectInDataBase($"{Connection.DataBase.Prefix}{Prefix}{Table}{NumberTable}"))
                    return;

               Connection.CopyTableStructure($"{Connection.DataBase.Prefix}{Prefix}{Table}", Connection.TableName($"{Prefix}{Table}{NumberTable}"));
          }

          /// <summary>
          ///  Funcion que arma el query para eliminar de un catalogo
          /// </summary>
          /// <param name="includeHours"></param>
          /// <returns></returns>
          protected StringBuilder CreateQueryForDelete(bool includeHours)
          {
               StringBuilder query;
               query = new StringBuilder();
               query.AppendFormat("delete from {0} where {1}", TableName(), CreatekeyFieldsFilterWithLoadData());
               return query;
          }

          /// <summary>
          /// Armas the consulta para delete parametros SQL.
          /// </summary>
          /// <returns></returns>
          protected StringBuilder CreateQueryForDeleteWithSqlParameters()
          {
               StringBuilder query;
               query = new StringBuilder();
               query.AppendFormat("delete from {0} where {1}", TableName(), CreateWhereConditionFromKeyFieldsWithSqlParameters());
               return query;
          }

          /// <summary>
          /// Retorna los campos de la tabla
          /// </summary>
          /// <returns></returns>
          public void CreateStringFieldsComaSeparated()
          {
               StringBuilder campos;
               campos = new StringBuilder();
               if (_fields == null)
               {
                    _fields = new StringBuilder();
               }
               foreach (KeyValuePair<string, Property> loColumna in Properties)
               {
                    if (loColumna.Value.IsVirtualField)
                         continue;
                    campos.AppendFormat("{0},", FieldNameFix(loColumna.Key));
               }
               if (campos.Length != 0)
                    _fields = campos.Remove(campos.Length - 1, 1);
          }
          public void CreateVirtualProperties(Dictionary<string, Property> properties)
          {
               foreach (var property in properties)
               {
                    new Switch(property.Value)
                        .Case<PropertyValue<bool>>(_ =>
                        {
                             AddProperty(property.Key, new PropertyValue<bool>
                             {
                                  Value = default,
                                  IsPrimaryKey = false,
                                  Length = property.Value.Length,
                                  Precision = property.Value.Precision,
                                  IsRequiredInDataBase = property.Value.IsRequiredInDataBase,
                                  FieldId = -1000 + -1 * property.Value.FieldId,
                                  Description = property.Value.Description,
                                  IsIdentity = property.Value.IsIdentity,
                                  IsVirtualField = true,
                                  DataType = property.Value.DataType
                             });
                        })
                        .Case<PropertyValue<byte>>(_ =>
                        {
                             AddProperty(property.Key, new PropertyValue<byte>
                             {
                                  Value = default,
                                  IsPrimaryKey = false,
                                  Length = property.Value.Length,
                                  Precision = property.Value.Precision,
                                  IsRequiredInDataBase = property.Value.IsRequiredInDataBase,
                                  FieldId = -1000 + -1 * property.Value.FieldId,
                                  Description = property.Value.Description,
                                  IsIdentity = property.Value.IsIdentity,
                                  IsVirtualField = true,
                                  DataType = property.Value.DataType
                             });
                        })
                        .Case<PropertyValue<short>>(_ =>
                        {
                             AddProperty(property.Key, new PropertyValue<short>
                             {
                                  Value = default,
                                  IsPrimaryKey = false,
                                  Length = property.Value.Length,
                                  Precision = property.Value.Precision,
                                  IsRequiredInDataBase = property.Value.IsRequiredInDataBase,
                                  FieldId = -1000 + -1 * property.Value.FieldId,
                                  Description = property.Value.Description,
                                  IsIdentity = property.Value.IsIdentity,
                                  IsVirtualField = true,
                                  DataType = property.Value.DataType
                             });
                        })
                        .Case<PropertyValue<int>>(_ =>
                        {
                             AddProperty(property.Key, new PropertyValue<int>
                             {
                                  Value = default,
                                  IsPrimaryKey = false,
                                  Length = property.Value.Length,
                                  Precision = property.Value.Precision,
                                  IsRequiredInDataBase = property.Value.IsRequiredInDataBase,
                                  FieldId = -1000 + -1 * property.Value.FieldId,
                                  Description = property.Value.Description,
                                  IsIdentity = property.Value.IsIdentity,
                                  IsVirtualField = true,
                                  DataType = property.Value.DataType
                             });
                        })
                        .Case<PropertyValue<long>>(_ =>
                        {
                             AddProperty(property.Key, new PropertyValue<long>
                             {
                                  Value = default,
                                  IsPrimaryKey = false,
                                  Length = property.Value.Length,
                                  Precision = property.Value.Precision,
                                  IsRequiredInDataBase = property.Value.IsRequiredInDataBase,
                                  FieldId = -1000 + -1 * property.Value.FieldId,
                                  Description = property.Value.Description,
                                  IsIdentity = property.Value.IsIdentity,
                                  IsVirtualField = true,
                                  DataType = property.Value.DataType
                             });
                        })
                        .Case<PropertyValue<DateTime>>(_ =>
                        {
                             AddProperty(property.Key, new PropertyValue<DateTime>
                             {
                                  Value = DefaultDateTime,
                                  IsPrimaryKey = false,
                                  Length = property.Value.Length,
                                  Precision = property.Value.Precision,
                                  IsRequiredInDataBase = property.Value.IsRequiredInDataBase,
                                  FieldId = -1000 + -1 * property.Value.FieldId,
                                  Description = property.Value.Description,
                                  IsIdentity = property.Value.IsIdentity,
                                  IsVirtualField = true,
                                  DataType = property.Value.DataType
                             });
                        })
                         .Case<PropertyValue<TimeSpan>>(_ =>
                         {
                              AddProperty(property.Key, new PropertyValue<TimeSpan>
                              {
                                   Value = default,
                                   IsPrimaryKey = false,
                                   Length = property.Value.Length,
                                   Precision = property.Value.Precision,
                                   IsRequiredInDataBase = property.Value.IsRequiredInDataBase,
                                   FieldId = -1000 + -1 * property.Value.FieldId,
                                   Description = property.Value.Description,
                                   IsIdentity = property.Value.IsIdentity,
                                   IsVirtualField = true,
                                   DataType = property.Value.DataType
                              });
                         })
                        .Case<PropertyValue<DateTimeOffset>>(_ =>
                        {
                             AddProperty(property.Key, new PropertyValue<DateTimeOffset>
                             {
                                  Value = default,
                                  IsPrimaryKey = false,
                                  Length = property.Value.Length,
                                  Precision = property.Value.Precision,
                                  IsRequiredInDataBase = property.Value.IsRequiredInDataBase,
                                  FieldId = -1000 + -1 * property.Value.FieldId,
                                  Description = property.Value.Description,
                                  IsIdentity = property.Value.IsIdentity,
                                  IsVirtualField = true,
                                  DataType = property.Value.DataType
                             });
                        })
                        .Case<PropertyValue<decimal>>(_ =>
                        {
                             AddProperty(property.Key, new PropertyValue<decimal>
                             {
                                  Value = default,
                                  IsPrimaryKey = false,
                                  Length = property.Value.Length,
                                  Precision = property.Value.Precision,
                                  IsRequiredInDataBase = property.Value.IsRequiredInDataBase,
                                  FieldId = -1000 + -1 * property.Value.FieldId,
                                  Description = property.Value.Description,
                                  IsIdentity = property.Value.IsIdentity,
                                  IsVirtualField = true,
                                  DataType = property.Value.DataType
                             });
                        })
                        .Case<PropertyValue<float>>(_ =>
                        {
                             AddProperty(property.Key, new PropertyValue<float>
                             {
                                  Value = default,
                                  IsPrimaryKey = false,
                                  Length = property.Value.Length,
                                  Precision = property.Value.Precision,
                                  IsRequiredInDataBase = property.Value.IsRequiredInDataBase,
                                  FieldId = -1000 + -1 * property.Value.FieldId,
                                  Description = property.Value.Description,
                                  IsIdentity = property.Value.IsIdentity,
                                  IsVirtualField = true,
                                  DataType = property.Value.DataType
                             });
                        })
                        .Case<PropertyValue<double>>(_ =>
                        {
                             AddProperty(property.Key, new PropertyValue<double>
                             {
                                  Value = default,
                                  IsPrimaryKey = false,
                                  Length = property.Value.Length,
                                  Precision = property.Value.Precision,
                                  IsRequiredInDataBase = property.Value.IsRequiredInDataBase,
                                  FieldId = -1000 + -1 * property.Value.FieldId,
                                  Description = property.Value.Description,
                                  IsIdentity = property.Value.IsIdentity,
                                  IsVirtualField = true,
                                  DataType = property.Value.DataType
                             });
                        })
                        .Case<PropertyValue<object>>(_ =>
                        {
                             AddProperty(property.Key, new PropertyValue<object>
                             {
                                  Value = default,
                                  IsPrimaryKey = false,
                                  Length = property.Value.Length,
                                  Precision = property.Value.Precision,
                                  IsRequiredInDataBase = property.Value.IsRequiredInDataBase,
                                  FieldId = -1000 + -1 * property.Value.FieldId,
                                  Description = property.Value.Description,
                                  IsIdentity = property.Value.IsIdentity,
                                  IsVirtualField = true,
                                  DataType = property.Value.DataType
                             });
                        })
                        .Case<PropertyValue<byte[]>>(_ =>
                        {
                             AddProperty(property.Key, new PropertyValue<byte[]>
                             {
                                  Value = default,
                                  IsPrimaryKey = false,
                                  Length = property.Value.Length,
                                  Precision = property.Value.Precision,
                                  IsRequiredInDataBase = property.Value.IsRequiredInDataBase,
                                  FieldId = -1000 + -1 * property.Value.FieldId,
                                  Description = property.Value.Description,
                                  IsIdentity = property.Value.IsIdentity,
                                  IsVirtualField = true,
                                  DataType = property.Value.DataType
                             });
                        })
                        .Case<PropertyValue<string>>(_ =>
                        {
                             AddProperty(property.Key, new PropertyValue<string>
                             {
                                  Value = default,
                                  IsPrimaryKey = false,
                                  Length = property.Value.Length,
                                  Precision = property.Value.Precision,
                                  IsRequiredInDataBase = property.Value.IsRequiredInDataBase,
                                  FieldId = -1000 + -1 * property.Value.FieldId,
                                  Description = property.Value.Description,
                                  IsIdentity = property.Value.IsIdentity,
                                  IsVirtualField = true,
                                  DataType = property.Value.DataType
                             });
                        })
                        .Case<PropertyValue<byte?>>(_ =>
                        {
                             AddProperty(property.Key, new PropertyValue<byte?>
                             {
                                  Value = default,
                                  IsPrimaryKey = false,
                                  Length = property.Value.Length,
                                  Precision = property.Value.Precision,
                                  IsRequiredInDataBase = property.Value.IsRequiredInDataBase,
                                  FieldId = -1000 + -1 * property.Value.FieldId,
                                  Description = property.Value.Description,
                                  IsIdentity = property.Value.IsIdentity,
                                  IsVirtualField = true,
                                  DataType = property.Value.DataType
                             });
                        })
                        .Case<PropertyValue<bool?>>(_ =>
                        {
                             AddProperty(property.Key, new PropertyValue<bool?>
                             {
                                  Value = default,
                                  IsPrimaryKey = false,
                                  Length = property.Value.Length,
                                  Precision = property.Value.Precision,
                                  IsRequiredInDataBase = property.Value.IsRequiredInDataBase,
                                  FieldId = -1000 + -1 * property.Value.FieldId,
                                  Description = property.Value.Description,
                                  IsIdentity = property.Value.IsIdentity,
                                  IsVirtualField = true,
                                  DataType = property.Value.DataType
                             });
                        })
                        .Case<PropertyValue<short?>>(_ =>
                        {
                             AddProperty(property.Key, new PropertyValue<short?>
                             {
                                  Value = default,
                                  IsPrimaryKey = false,
                                  Length = property.Value.Length,
                                  Precision = property.Value.Precision,
                                  IsRequiredInDataBase = property.Value.IsRequiredInDataBase,
                                  FieldId = -1000 + -1 * property.Value.FieldId,
                                  Description = property.Value.Description,
                                  IsIdentity = property.Value.IsIdentity,
                                  IsVirtualField = true,
                                  DataType = property.Value.DataType
                             });
                        })
                        .Case<PropertyValue<int?>>(_ =>
                        {
                             AddProperty(property.Key, new PropertyValue<int?>
                             {
                                  Value = default,
                                  IsPrimaryKey = false,
                                  Length = property.Value.Length,
                                  Precision = property.Value.Precision,
                                  IsRequiredInDataBase = property.Value.IsRequiredInDataBase,
                                  FieldId = -1000 + -1 * property.Value.FieldId,
                                  Description = property.Value.Description,
                                  IsIdentity = property.Value.IsIdentity,
                                  IsVirtualField = true,
                                  DataType = property.Value.DataType
                             });

                        })
                        .Case<PropertyValue<long?>>(_ =>
                        {
                             AddProperty(property.Key, new PropertyValue<long?>
                             {
                                  Value = default,
                                  IsPrimaryKey = false,
                                  Length = property.Value.Length,
                                  Precision = property.Value.Precision,
                                  IsRequiredInDataBase = property.Value.IsRequiredInDataBase,
                                  FieldId = -1000 + -1 * property.Value.FieldId,
                                  Description = property.Value.Description,
                                  IsIdentity = property.Value.IsIdentity,
                                  IsVirtualField = true,
                                  DataType = property.Value.DataType
                             });
                        })
                        .Case<PropertyValue<DateTime?>>(_ =>
                        {
                             AddProperty(property.Key, new PropertyValue<bool>
                             {
                                  Value = default,
                                  IsPrimaryKey = false,
                                  Length = property.Value.Length,
                                  Precision = property.Value.Precision,
                                  IsRequiredInDataBase = property.Value.IsRequiredInDataBase,
                                  FieldId = -1000 + -1 * property.Value.FieldId,
                                  Description = property.Value.Description,
                                  IsIdentity = property.Value.IsIdentity,
                                  IsVirtualField = true,
                                  DataType = property.Value.DataType
                             });
                        })
                        .Case<PropertyValue<DateTimeOffset?>>(_ =>
                        {
                             AddProperty(property.Key, new PropertyValue<DateTimeOffset?>
                             {
                                  Value = default,
                                  IsPrimaryKey = false,
                                  Length = property.Value.Length,
                                  Precision = property.Value.Precision,
                                  IsRequiredInDataBase = property.Value.IsRequiredInDataBase,
                                  FieldId = -1000 + -1 * property.Value.FieldId,
                                  Description = property.Value.Description,
                                  IsIdentity = property.Value.IsIdentity,
                                  IsVirtualField = true,
                                  DataType = property.Value.DataType
                             });
                        })
                        .Case<PropertyValue<decimal?>>(_ =>
                        {
                             AddProperty(property.Key, new PropertyValue<decimal?>
                             {
                                  Value = default,
                                  IsPrimaryKey = false,
                                  Length = property.Value.Length,
                                  Precision = property.Value.Precision,
                                  IsRequiredInDataBase = property.Value.IsRequiredInDataBase,
                                  FieldId = -1000 + -1 * property.Value.FieldId,
                                  Description = property.Value.Description,
                                  IsIdentity = property.Value.IsIdentity,
                                  IsVirtualField = true,
                                  DataType = property.Value.DataType
                             });

                        })
                        .Case<PropertyValue<float?>>(_ =>
                        {
                             AddProperty(property.Key, new PropertyValue<float?>
                             {
                                  Value = default,
                                  IsPrimaryKey = false,
                                  Length = property.Value.Length,
                                  Precision = property.Value.Precision,
                                  IsRequiredInDataBase = property.Value.IsRequiredInDataBase,
                                  FieldId = -1000 + -1 * property.Value.FieldId,
                                  Description = property.Value.Description,
                                  IsIdentity = property.Value.IsIdentity,
                                  IsVirtualField = true,
                                  DataType = property.Value.DataType
                             });
                        })
                        .Case<PropertyValue<double?>>(_ =>
                        {
                             AddProperty(property.Key, new PropertyValue<double?>
                             {
                                  Value = default,
                                  IsPrimaryKey = false,
                                  Length = property.Value.Length,
                                  Precision = property.Value.Precision,
                                  IsRequiredInDataBase = property.Value.IsRequiredInDataBase,
                                  FieldId = -1000 + -1 * property.Value.FieldId,
                                  Description = property.Value.Description,
                                  IsIdentity = property.Value.IsIdentity,
                                  IsVirtualField = true,
                                  DataType = property.Value.DataType
                             });
                        });
               }
          }
          public void CopyData(StaticEntity data)
          {
               if (_isNew && !IsImplementation)
               {
                    LoadNewCustomValues();

               }
               foreach (var property in data.Properties)
               {
                    SetPropertyValue(property.Key, data.GetPropertyValue(property.Key));
               }
               if (_isNew && !IsImplementation)
               {

                    CustomValidationForNewRegister();
                    CustomValidationForNewPreWriteRegister();
               }
          }

          /// <summary>
          /// Guardar2s the specified pb incluye horas.
          /// </summary>
          public void Save()
          {
               lock (_lock)
               {
                    using (var connection = new ConnectionHandler(Connection))
                    {
                         _HistoryFields = "";
                         if (_isNew)
                         {
                              //Si es un valor nuevo en la base de datos
                              if (!IsImplementation)
                                   CustomValidationForNewPreWriteRegister();
                              //EjecutaConsultaYGrabaBitacora(ValidaYArmaConsultaParaInsert(pbIncluyeHoras), enmMovimientos.Alta);
                              ExecQueryAndWriteLogData(MovementType.Register);
                              if (!IsImplementation)
                                   CustomValidationForPostWrite();
                              _isNew = false;
                              return;
                         }
                         //Solo si se cargaron datos se hace una actualizacion
                         if (EOF)
                              return;
                         if (!IsImplementation)
                              CustomValidationForPreWriteChanges();
                         //EjecutaConsultaYGrabaBitacora(ValidaYArmaConsultaParaUpdate(pbIncluyeHoras), enmMovimientos.Cambio);
                         ExecQueryAndWriteLogData(MovementType.Update);
                         if (!IsImplementation)
                              CustomValidationForPosWriteChanges();
                         SaveVirtualValues();
                    }
               }
          }


          /// <summary>
          /// Carga un nuevo objeto
          /// </summary>
          public void New()
          {
               using (var connection = new ConnectionHandler(Connection))
               {
                    LoadDefaultDataRow();
                    LoadNewCustomValues();
                    CustomValidationForNewRegister();
                    _isNew = true;
                    //Si trae datos pero vacios
                    EOF = true;
               }
          }

          /// <summary>
          /// Elimina una objeto cargado
          /// </summary>
          public void Delete()
          {
               if (EOF || _isNew)
               {
                    return;
               }
               lock (_lock)
               {
                    using (var connection = new ConnectionHandler(Connection))
                    {
                         _HistoryFields = "";
                         if (!IsImplementation)
                              CustomValidationForDeletePreWrite();
                         //Lo tiene que hacer antes de eliminarlo fisicamente para guardar la foto del registro antes de quitarlo
                         WriteLogData(MovementType.Elimination);
                         //_System.Conexion.EjecutaEscalar(ArmaConsultaParaDelete(pbIncluyeHoras));
                         Connection.ExecuteCommand(CreateQueryForDeleteWithSqlParameters(), _sqlParameterList);
                         EOF = true;
                         if (!IsImplementation)
                              CustomValidationForDeletePostWrite();
                    }
               }
          }
          public void LoadFirstOrDefault()
          {
               DataTable dataTable = Connection.GetDataTable(CreateQueryForLoadFirst(), _sqlParameterList);
               EOF = true;
               _isNew = true;
               if (dataTable.Rows.Count == 0)
                    LoadNewCustomValues();
               else
                    LoadRowData(dataTable.Rows[0]);
          }

          private StringBuilder CreateQueryForLoadFirst()
          {
               StringBuilder query;
               query = new StringBuilder();
               if (_fields.Length == 0)
               {
                    CreateStringFieldsComaSeparated();
               }
               query.AppendFormat(" Select Top 1 {0} From {1} ", _fields, TableName());
               query.AppendFormat(" {0} ", CreateFilterByFromCompanyKeyFields());
               query.AppendFormat(" Order by {0}", CreateOrderByFromKeyFields());
               return query;
          }

          /// <summary>
          ///  Carga los datos segun la llave primaria
          /// </summary>
          /// <param name="primarykeys"></param>
          public void Load(params object[] primarykeys)
          {
               PrepareKeyFields(primarykeys.ToList());
               InternalLoadWithSqlParameters();
               LoadFieldVirtualValues();
          }
          public async Task LoadAsync(params object[] primarykeys)
          {
               await Task.Run(() =>
               {
                    PrepareKeyFields(primarykeys.ToList());
                    InternalLoadWithSqlParameters();
                    LoadFieldVirtualValues();
               });
          }
          /// <summary>
          /// Loads the specified primarykeys.
          /// </summary>
          /// <param name="primarykeys">The primarykeys.</param>
          public void Load(Dictionary<string, object> primarykeys)
          {
               KeyFields = primarykeys;
               InternalLoadWithSqlParameters();
               LoadFieldVirtualValues();
          }

          /// <summary>
          /// Cargar los datos segun una lista de valores para la llave primaria.
          /// </summary>
          /// <param name="primarykeys">The po llaves primarias.</param>
          public void Load(List<object> primarykeys)
          {
               PrepareKeyFields(primarykeys);
               InternalLoadWithSqlParameters();
               LoadFieldVirtualValues();
          }

          /// <summary>
          /// Si la coleccion que tiene las llaves ya contiene valores. Podemos usar este metodo para cargar los valores internos
          /// Usa la coleccion de CamposLLave
          /// </summary>
          public void Load()
          {
               InternalLoadWithSqlParameters();
               LoadFieldVirtualValues();
          }

          public void Load(StringBuilder filter, List<ParameterSql> parameters)
          {
               StringBuilder query;
               DataTable dataTable;
               query = new StringBuilder();
               if (_fields.Length == 0)
               {
                    CreateStringFieldsComaSeparated();
               }
               query.AppendFormat(" Select Top 1 {0} From {1} ", _fields, TableName());
               query.AppendFormat("  Where {0}", filter);
               query.AppendFormat("  Order by {0}", CreateOrderByFromKeyFields());
               dataTable = Connection.GetDataTable(query, parameters);
               EOF = true;
               _isNew = true;
               if (dataTable.Rows.Count == 0)
               {
                    return;
               }
               //De la fila cargada del datable llena una estructura de tipo fila
               LoadRowData(dataTable.Rows[0]);
          }

          /// <summary>
          /// Preparas the campos llave.
          /// </summary>
          /// <param name="primarykeys">The po llaves primarias.</param>
          /// <exception cref="Exception">
          /// No hay argumentos de las llaves primarias
          /// or
          /// Las llaves primarias enviadas no coinciden con la definicion de la tabla
          /// </exception>
          private void PrepareKeyFields(List<object> primarykeys)
          {
               int parameter;
               if (primarykeys == null)
               {
                    throw new CoreException(Errors.E00000077);
               }
               if (KeyFields.Count != primarykeys.Count)
               {
                    throw new CoreException(Errors.E00000078);
               }
               parameter = 0;
               foreach (string lsCampo in KeyFields.Keys.ToList())
               {
                    KeyFields[lsCampo] = primarykeys[parameter];
                    parameter++;
               }
          }
          /// <summary>
          /// Arma la consulta para carga los datos conforme a la llave primaria
          /// </summary>
          /// <returns></returns>
          private StringBuilder CreateQueryForLoadData()
          {
               StringBuilder query;
               StringBuilder order;
               query = new StringBuilder();
               order = new StringBuilder();
               if (_fields.Length == 0)
               {
                    CreateStringFieldsComaSeparated();
               }
               query.AppendFormat("Select {0} From {1} where", _fields, TableName());
               foreach (KeyValuePair<string, object> field in KeyFields)
               {
                    if (field.Value.GetType() == Type.GetType("System.DateTime"))
                    {
                         query.AppendFormat(" {0}={1} And ", field.Key, ExtensionSQL.DateSql(Convert.ToDateTime(field.Value)));
                    }
                    else if (field.Value.GetType() == Type.GetType("System.String"))
                    {
                         query.AppendFormat(" {0}='{1}' And ", field.Key, Convert.ToString(field.Value));
                    }
                    else if (field.Value.GetType() == Type.GetType("System.Boolean"))
                    {
                         query.AppendFormat(" {0}={1} And ", field.Key, Convert.ToBoolean(field.Value) ? 1 : 0);
                    }
                    else
                    {
                         query.AppendFormat(" {0}={1} And ", field.Key, field.Value);
                    }
                    order.AppendFormat("{0},", field.Key);
               }
               query.Remove(query.Length - 4, 4); //le quita los ultimos cuatro caracteres del and
               order.Remove(order.Length - 1, 1); //le quita la ultima coma para el order by
               query.AppendFormat("Order by {0}", order);
               return query;
          }

          private void InternalLoadWithSqlParameters()
          {
               StringBuilder query;
               DataTable dataTable;
               lock (_lock)
               {
                    query = CreateQueryForLoadDataWithSqlParameters();
                    dataTable = Connection.GetDataTable(query, _sqlParameterList);
               }
               EOF = true;
               _isNew = true;
               if (dataTable.Rows.Count == 0)
               {
                    return;
               }
               //De la fila cargada del datable llena una estructura de tipo fila
               LoadRowData(dataTable.Rows[0]);
          }

          /// <summary>
          /// Armas the consulta para cargar datos con parametros SQL.
          /// </summary>
          /// <returns></returns>
          private StringBuilder CreateQueryForLoadDataWithSqlParameters()
          {
               StringBuilder query = new StringBuilder();
               if (_fields.Length == 0)
               {
                    CreateStringFieldsComaSeparated();
               }
               query.AppendFormat("Select {0} From {1} ", _fields, TableName());
               query.AppendFormat(" Where ");
               if (string.IsNullOrEmpty(ExternalFilter))
               {
                    query.AppendFormat(" {0} ", CreateWhereConditionFromKeyFieldsWithSqlParameters());
               }
               else
               {
                    query.AppendFormat(" {0} ", ExternalFilter);
               }
               query.AppendFormat(" Order by {0}", CreateOrderByFromKeyFields());
               return query;
          }

          /// <summary>
          /// Armas the where de campos llave.
          /// </summary>
          /// <returns></returns>
          private StringBuilder CreateWhereConditionFromKeyFieldsWithSqlParameters()
          {
               StringBuilder whereCondition = new StringBuilder();
               _sqlParameterList = new List<ParameterSql>(KeyFields.Count);
               foreach (KeyValuePair<string, object> field in KeyFields.CloneDictionaryCloningValues())
               {
                    whereCondition.AppendFormat(" {0}=@{0} And ", field.Key);
                    if (field.Value == null)
                         throw new CoreException(Errors.E00000079);
                    if (!field.Value.ToString().Contains(".") && (field.Value.GetType() == Type.GetType("System.DateTime") || field.Value.ToString().IsDate()) && !string.Equals(field.Key, "CHEQ_NUMDOC", StringComparison.OrdinalIgnoreCase) && !string.Equals(field.Key, "SOLICITUDPAGO", StringComparison.OrdinalIgnoreCase))
                    {
                         _sqlParameterList.Add(new ParameterSql(string.Format("@{0}", field.Key), Convert.ToDateTime(field.Value).DateSqlParameters()));
                    }
                    else
                         _sqlParameterList.Add(new ParameterSql(string.Format("@{0}", field.Key), field.Value));
               }
               whereCondition.Remove(whereCondition.Length - 4, 4);
               return whereCondition;
          }

          /// <summary>
          /// Armas the ordeby de campos l lave.
          /// </summary>
          /// <returns></returns>
          private StringBuilder CreateOrderByFromKeyFields()
          {
               StringBuilder orderBy = new StringBuilder();
               foreach (KeyValuePair<string, object> field in KeyFields.Clone())
               {
                    orderBy.AppendFormat("{0},", field.Key);
               }
               return orderBy.Remove(orderBy.Length - 1, 1); //le quita la ultima coma para el order by
          }
          private string CreateFilterByFromCompanyKeyFields()
          {
               StringBuilder query = new StringBuilder();
               foreach (KeyValuePair<string, Property> field in Properties)
               {
                    if (field.Value.IsCompanyField)
                         query.AppendFormat("{0} = {1}", field.Key, _System.Session.Company.Number);
               }
               if (query.Length > 0)
                    return $" where {query}";
               return "";
          }
          /// <summary>
          /// Limpia los controles cuando se crea un nuevo campo
          /// </summary>
          private void LoadDefaultDataRow()
          {
               foreach (KeyValuePair<string, Property> column in Properties)
               {
                    if (column.Value.IsPrimaryKey)
                    {
                         KeyFields[column.Key] = null;
                    }
                    if (column.Value is PropertyValue<bool>)
                    {
                         SetPropertyValue(column.Key, (column.Value as PropertyValue<bool>).DefaultValue);
                    }
                    if (column.Value is PropertyValue<byte>)
                    {
                         SetPropertyValue(column.Key, (column.Value as PropertyValue<byte>).DefaultValue);
                    }
                    if (column.Value is PropertyValue<short>)
                    {
                         SetPropertyValue(column.Key, (column.Value as PropertyValue<short>).DefaultValue);
                    }
                    if (column.Value is PropertyValue<int>)
                    {
                         SetPropertyValue(column.Key, (column.Value as PropertyValue<int>).DefaultValue);
                    }
                    if (column.Value is PropertyValue<long>)
                    {
                         SetPropertyValue(column.Key, (column.Value as PropertyValue<long>).DefaultValue);
                    }
                    if (column.Value is PropertyValue<DateTime>)
                    {
                         SetPropertyValue(column.Key, (column.Value as PropertyValue<DateTime>).DefaultValue);
                    }
                    if (column.Value is PropertyValue<decimal>)
                    {
                         SetPropertyValue(column.Key, (column.Value as PropertyValue<decimal>).DefaultValue);
                    }
                    if (column.Value is PropertyValue<float>)
                    {
                         SetPropertyValue(column.Key, (column.Value as PropertyValue<float>).DefaultValue);
                    }
                    if (column.Value is PropertyValue<double>)
                    {
                         SetPropertyValue(column.Key, (column.Value as PropertyValue<double>).DefaultValue);
                    }
                    if (column.Value is PropertyValue<object>)
                    {
                         SetPropertyValue<object>(column.Key, (column.Value as PropertyValue<object>).DefaultValue);
                    }
                    if (column.Value is PropertyValue<byte[]>)
                    {
                         SetPropertyValue(column.Key, (column.Value as PropertyValue<byte[]>).DefaultValue);
                    }
                    if (column.Value is PropertyValue<string>)
                    {
                         SetPropertyValue(column.Key, (column.Value as PropertyValue<string>).DefaultValue);
                    }
                    if (column.Value is PropertyValue<byte?>)
                    {
                         SetPropertyValue(column.Key, (column.Value as PropertyValue<byte?>).DefaultValue);
                    }
                    if (column.Value is PropertyValue<bool?>)
                    {
                         SetPropertyValue(column.Key, (column.Value as PropertyValue<bool?>).DefaultValue);
                    }
                    if (column.Value is PropertyValue<short?>)
                    {
                         SetPropertyValue(column.Key, (column.Value as PropertyValue<short?>).DefaultValue);
                    }
                    if (column.Value is PropertyValue<int?>)
                    {
                         SetPropertyValue(column.Key, (column.Value as PropertyValue<int?>).DefaultValue);
                    }
                    if (column.Value is PropertyValue<long?>)
                    {
                         SetPropertyValue(column.Key, (column.Value as PropertyValue<long?>).DefaultValue);
                    }
                    if (column.Value is PropertyValue<DateTime?>)
                    {
                         SetPropertyValue(column.Key, (column.Value as PropertyValue<DateTime?>).DefaultValue);
                    }
                    if (column.Value is PropertyValue<decimal?>)
                    {
                         SetPropertyValue(column.Key, (column.Value as PropertyValue<decimal?>).DefaultValue);
                    }
                    if (column.Value is PropertyValue<float?>)
                    {
                         SetPropertyValue(column.Key, (column.Value as PropertyValue<float?>).DefaultValue);
                    }
                    if (column.Value is PropertyValue<double?>)
                    {
                         SetPropertyValue(column.Key, (column.Value as PropertyValue<double?>).DefaultValue);
                    }
               }
          }

          /// <summary>
          /// Funcion que transforma un datatable en una fila dinamica definida por el catalogo
          /// Siempre asigna el primer registro como el valor de la fila
          /// </summary>
          /// <param name="dataRow">datatable con la fila a convertir</param>
          /// <returns></returns>
          public void LoadRowData(DataRow dataRow)
          {
               EOF = false;
               _isNew = false;
               //Cuando se hace una asignacion de un objeto a otro no hace una copia de valor hace una copia por refrencia
               foreach (KeyValuePair<string, Property> column in Properties)
               {
                    if (column.Value.IsPrimaryKey)
                    {
                         KeyFields[column.Key] = dataRow.GetValue<object>(column.Key);
                    }
                    if (column.Value is PropertyValue<bool>)
                    {
                         SetPropertyValue<bool>(column.Key, dataRow.GetValue<bool>(column.Key), true);
                    }
                    if (column.Value is PropertyValue<byte>)
                    {
                         SetPropertyValue<byte>(column.Key, dataRow.GetValue<byte>(column.Key), true);
                    }
                    if (column.Value is PropertyValue<short>)
                    {
                         SetPropertyValue<short>(column.Key, dataRow.GetValue<short>(column.Key), true);
                    }
                    if (column.Value is PropertyValue<int>)
                    {
                         SetPropertyValue<int>(column.Key, dataRow.GetValue<int>(column.Key), true);
                    }
                    if (column.Value is PropertyValue<long>)
                    {
                         SetPropertyValue<long>(column.Key, dataRow.GetValue<long>(column.Key), true);
                    }
                    if (column.Value is PropertyValue<DateTime>)
                    {
                         SetPropertyValue<DateTime>(column.Key, dataRow.GetValue<DateTime>(column.Key), true);
                    }
                    if (column.Value is PropertyValue<TimeSpan>)
                    {
                         SetPropertyValue<TimeSpan>(column.Key, dataRow.GetValue<TimeSpan>(column.Key), true);
                    }
                    if (column.Value is PropertyValue<decimal>)
                    {
                         SetPropertyValue<decimal>(column.Key, dataRow.GetValue<decimal>(column.Key), true);
                    }
                    if (column.Value is PropertyValue<float>)
                    {
                         SetPropertyValue<float>(column.Key, dataRow.GetValue<float>(column.Key), true);
                    }
                    if (column.Value is PropertyValue<double>)
                    {
                         SetPropertyValue<double>(column.Key, dataRow.GetValue<double>(column.Key), true);
                    }
                    if (column.Value is PropertyValue<object>)
                    {
                         SetPropertyValue<object>(column.Key, dataRow.GetValue<object>(column.Key), true);
                    }
                    if (column.Value is PropertyValue<byte[]>)
                    {
                         SetPropertyValue<byte[]>(column.Key, dataRow.GetValue<byte[]>(column.Key), true);
                    }
                    if (column.Value is PropertyValue<string>)
                    {
                         if (column.Value.IsEncrypted)
                         {
                              SetPropertyValue(column.Key, Cipher.DecryptPEMDataBase(dataRow.GetValue<string>(column.Key)), true);
                              if (!string.IsNullOrEmpty(dataRow.GetValue<string>(column.Key)))
                                   SetPropertyValue(column.Key, constMask, false);
                         }
                         else
                              SetPropertyValue<string>(column.Key, dataRow.GetValue<string>(column.Key), true);
                    }
                    if (column.Value is PropertyValue<byte?>)
                    {
                         if (Convert.IsDBNull(dataRow[column.Key]) || dataRow[column.Key] == null)
                         {
                              SetPropertyValue<byte?>(column.Key, null, true);
                         }
                         else
                         {
                              SetPropertyValue<byte?>(column.Key, dataRow.GetValue<byte>(column.Key), true);
                         }
                    }
                    if (column.Value is PropertyValue<bool?>)
                    {
                         if (Convert.IsDBNull(dataRow[column.Key]) || dataRow[column.Key] == null)
                         {
                              SetPropertyValue<bool?>(column.Key, null, true);
                         }
                         else
                         {
                              SetPropertyValue<bool?>(column.Key, dataRow.GetValue<bool>(column.Key), true);
                         }
                    }
                    if (column.Value is PropertyValue<short?>)
                    {
                         if (Convert.IsDBNull(dataRow[column.Key]) || dataRow[column.Key] == null)
                         {
                              SetPropertyValue<short?>(column.Key, null, true);
                         }
                         else
                         {
                              SetPropertyValue<short?>(column.Key, dataRow.GetValue<short>(column.Key), true);
                         }
                    }
                    if (column.Value is PropertyValue<int?>)
                    {
                         if (Convert.IsDBNull(dataRow[column.Key]) || dataRow[column.Key] == null)
                         {
                              SetPropertyValue<int?>(column.Key, null, true);
                         }
                         else
                         {
                              SetPropertyValue<int?>(column.Key, dataRow.GetValue<int>(column.Key), true);
                         }
                    }
                    if (column.Value is PropertyValue<long?>)
                    {
                         if (Convert.IsDBNull(dataRow[column.Key]) || dataRow[column.Key] == null)
                         {
                              SetPropertyValue<long?>(column.Key, null, true);
                         }
                         else
                         {
                              SetPropertyValue<long?>(column.Key, dataRow.GetValue<long>(column.Key), true);
                         }
                    }
                    if (column.Value is PropertyValue<DateTime?>)
                    {
                         if (Convert.IsDBNull(dataRow[column.Key]) || dataRow[column.Key] == null)
                         {
                              SetPropertyValue<DateTime?>(column.Key, null, true);
                         }
                         else
                         {
                              SetPropertyValue<DateTime?>(column.Key, dataRow.GetValue<DateTime>(column.Key), true);
                         }
                    }
                    if (column.Value is PropertyValue<decimal?>)
                    {
                         if (Convert.IsDBNull(dataRow[column.Key]) || dataRow[column.Key] == null)
                         {
                              SetPropertyValue<decimal?>(column.Key, null, true);
                         }
                         else
                         {
                              SetPropertyValue<decimal?>(column.Key, dataRow.GetValue<decimal>(column.Key), true);
                         }
                    }
                    if (column.Value is PropertyValue<float?>)
                    {
                         if (Convert.IsDBNull(dataRow[column.Key]) || dataRow[column.Key] == null)
                         {
                              SetPropertyValue<float?>(column.Key, null, true);
                         }
                         else
                         {
                              SetPropertyValue<float?>(column.Key, dataRow.GetValue<float>(column.Key), true);
                         }
                    }
                    if (column.Value is PropertyValue<double?>)
                    {
                         if (Convert.IsDBNull(dataRow[column.Key]) || dataRow[column.Key] == null)
                         {
                              SetPropertyValue<double?>(column.Key, null, true);
                         }
                         else
                         {
                              SetPropertyValue<double?>(column.Key, dataRow.GetValue<double>(column.Key), true);
                         }
                    }
               }
               if (!IsImplementation)
                    PosLoadDataValues();
          }


          #endregion Methods for ABC

          #region Methods for log data classes

          /// <summary>
          ///Graba en las tablas de las bitacoras
          /// </summary>
          /// <param name="movement">The pen movimiento.</param>
          protected void WriteLogData(MovementType movement)
          {
               if (!AddHistory)
               {
                    //Si no quiere tener historiales sobre la base la tabla que retorne
                    return;
               }
               if (!_existsLogData)
               {
                    //Verificamos que exista la bitacora
                    if (!Connection.ExistsObjectInDataBase($"{Owner}.{Connection.DataBase.DataBaseObjectPrefixLogData}{$"{Prefix}{Table}"}{NumberTable}", Connection.DataBase.LogData))
                    {
                         //Se arma el query para la tabla de historiales
                         //Utilizamos ejecutab comando pra que el tiempo sea ilimitado, esto es para las tablas que tienen
                         //grandes registrosy consumen demaciado tiempo y se termina el tiempo de espera de la ejecucion del comando
                         StringBuilder query = new StringBuilder();
                         query.AppendFormat(" USE [{0}]", Connection.DataBase.Catalog);
                         Connection.ExecuteCommand(query);
                         Connection.ExecuteCommand(CreateQueryForNewHistoryTable(), null, true);
                         //_System.Conexion.EjecutaEscalar(lsQuery);
                    }
                    _existsLogData = true;
               }
               CreateQueryForLogData(movement, _HistoryFields);
          }

          /// <summary>
          /// Ejecutas the consulta y graba bitacora.
          /// </summary>
          /// <param name="query">The LPS query.</param>
          /// <param name="movement">The pen movimiento.</param>
          private void ExecQueryAndWriteLogData(StringBuilder query, MovementType movement)
          {
               //Insertamos el nuevo registros
               if (!_existsChanges && !_isNew)
               {
                    return;
               }
               if (_sqlParameterList.Count > 0)
               {
                    Connection.ExecuteCommand(query, _sqlParameterList, true);
               }
               else
               {
                    Connection.ExecuteScalar(query);
               }
               //Si se grabo correctamente que grabe en la bitacora
               WriteLogData(movement);
          }

          /// <summary>
          /// Ejecutas the consulta y graba bitacora.
          /// </summary>
          /// <param name="movement">The pen movimiento.</param>
          private void ExecQueryAndWriteLogData(MovementType movement)
          {
               StringBuilder query;
               object idElement;
               //Insertamos el nuevo registros
               query = new StringBuilder();
               if (movement == MovementType.Register)
               {
                    if (!_isNew)
                    {
                         return;
                    }
                    query = ValidateAndCreateQueryForInsertWithSqlParameters();
               }
               if (movement == MovementType.Update)
               {
                    query = ValidateAndCreateQueryForUpdateWitSqlParameters();
                    if (!_existsChanges)
                         return;
               }
               if (query.Length == 0)
                    return;
               if (_isNew && _containsIdentityFields)
               {
                    idElement = Connection.ExecuteScalar(query, _sqlParameterList);
                    foreach (KeyValuePair<string, Property> column in Properties)
                    {
                         if (!column.Value.IsIdentity)
                              continue;
                         SetPropertyValue(column.Key, idElement);
                         KeyFields[column.Key] = idElement;
                         //loColumna.Value.Va
                         break;
                    }
               }
               else
                    Connection.ExecuteCommand(query, _sqlParameterList, true);
               //Si se grabo correctamente que grabe en la bitacora
               WriteLogData(movement);
          }

          #endregion Methods for log data classes

          #region Internal Metodos for validations

          /// <summary>
          /// Agregas the valor.
          /// </summary>
          /// <typeparam name="T"></typeparam>
          /// <param name="name">The ps nombre.</param>
          /// <param name="columnProperty">The po propiedad.</param>
          /// <param name="values">The PSB valores.</param>
          /// <param name="keyFields">The PSB campos llave.</param>
          /// <returns></returns>
          /// <exception cref="Exception"></exception>
          private bool AddValue<T>(string name, PropertyValue<T> columnProperty, ref StringBuilder values, ref StringBuilder keyFields)
          {
               if (columnProperty.IsPrimaryKey)
               {
                    keyFields.AppendFormat("{0}={1} AND ", FieldNameFix(name), columnProperty.OldValue);
               }
               if (Equals(columnProperty.Value, columnProperty.OldValue))
               {
                    return false;
               }
               _existsChanges = true;
               if (columnProperty.IsRequiredInDataBase)
               {
                    if (Equals(columnProperty.Value, null))
                    {
                         throw new CoreException(Errors.E00000080,$"{name}");
                    }
               }
               if (Equals(columnProperty.Value, null))
               {
                    values.AppendFormat("{0}=NULL,", FieldNameFix(name));
               }
               else
               {
                    values.AppendFormat("{0}={1},", FieldNameFix(name), columnProperty.Value);
               }
               return true;
          }

          /// <summary>
          /// Agregas the valor.
          /// </summary>
          /// <typeparam name="T"></typeparam>
          /// <param name="name">The ps nombre.</param>
          /// <param name="columnProperty">The po propiedad.</param>
          /// <param name="values">The PSB valores.</param>
          /// <param name="includeHours">if set to <c>true</c> [pb incluye horas].</param>
          /// <exception cref="Exception"></exception>
          private void AddValue<T>(string name, PropertyValue<T> columnProperty, ref StringBuilder values)
          {
               if (columnProperty.IsPrimaryKey || columnProperty.IsIdentity)
               {
                    if (columnProperty.IsEncrypted)
                         throw new CoreException(Errors.E00000082,$"{columnProperty.Description}");
                    if (columnProperty.IsPassword)
                         throw new CoreException(Errors.E00000082,$"{columnProperty.Description}");
                    if (columnProperty.IsGuid)
                         _sqlParameterList.Add(new ParameterSql(string.Format("{0}key", name), new Guid(Convert.ToString(columnProperty.Value))));
                    else
                         _sqlParameterList.Add(new ParameterSql(string.Format("{0}key", name), columnProperty.Value));
               }
               if (columnProperty.IsPrimaryKey || columnProperty.IsIdentity)
               {
                    return;
               }
               if (Equals(columnProperty.Value, columnProperty.OldValue) && !(columnProperty is PropertyValue<string>))
               {
                    return;
               }
               if (columnProperty is PropertyValue<string>)
               {
                    if (columnProperty.IsPassword || columnProperty.IsEncrypted)
                    {
                         if (Convert.ToString(columnProperty.Value) == constMask || Equals(Convert.ToString(columnProperty.Value), Convert.ToString(columnProperty.OldValue)))
                         {
                              return;
                         }
                    }
                    else
                    {
                         if (Equals(columnProperty.Value, columnProperty.OldValue))
                         {
                              return;
                         }
                    }
               }
               if (columnProperty.IsRequiredInDataBase)
               {
                    if (Equals(columnProperty.Value, null))
                    {
                         throw new CoreException(Errors.E00000080,$"{name}");
                    }
               }
               if (columnProperty is PropertyValue<DateTime> || columnProperty is PropertyValue<DateTime?> || columnProperty is PropertyValue<DateTimeOffset> || columnProperty is PropertyValue<DateTimeOffset?>)
               {
                    if (!Equals(columnProperty, null))
                    {
                         switch (Connection.DataBase.Engine)
                         {
                              case DataBaseType.PostgressSql:
                                   _sqlParameterList.Add(new ParameterSql(string.Format("@{0}", name), Convert.ToDateTime(columnProperty.Value)));
                                   break;
                              default:
                                   _sqlParameterList.Add(new ParameterSql(string.Format("@{0}", name), Convert.ToDateTime(columnProperty.Value)));
                                   break;
                         }

                    }
                    else
                         _sqlParameterList.Add(new ParameterSql(string.Format("@{0}", name), columnProperty.Value));
               }
               else if (columnProperty is PropertyValue<string>)
               {
                    if (columnProperty.IsRequiredInDataBase)
                    {
                         //if (String.IsNullOrEmpty(loPropiedadString.Valor))
                         if (columnProperty.Value == null)
                         {
                              //Vamos a considerar que la cadena vacia es un valor permitido
                              throw new CoreException(Errors.E00000080,$"{columnProperty.Description}");
                         }
                         if (Convert.ToString(columnProperty.Value).Length > columnProperty.Length && columnProperty.Length > -1)
                         {
                              throw new CoreException(Errors.E00000081,$"{columnProperty.Description}");
                         }
                    }

                    if (!string.IsNullOrEmpty(Convert.ToString(columnProperty.Value)) && Convert.ToString(columnProperty.Value).Length > columnProperty.Length && columnProperty.Length > -1)
                    {
                         throw new CoreException(Errors.E00000081,$"{columnProperty.Description}");
                    }
                    if (columnProperty.IsPassword)
                    {
                         (columnProperty as PropertyValue<string>).Value = Cipher.BCryptHashPassword(Convert.ToString(columnProperty.Value));
                    }
                    else if (columnProperty.IsEncrypted && Convert.ToString(columnProperty.Value) != constMask && !string.IsNullOrEmpty(Convert.ToString(columnProperty.Value)))
                    {
                         (columnProperty as PropertyValue<string>).Value = Cipher.EncryptPEMDataBase(Convert.ToString(columnProperty.Value));
                    }
                    if (columnProperty.IsGuid)
                    {
                         _sqlParameterList.Add(new ParameterSql(string.Format("@{0}", name), new Guid(Convert.ToString(columnProperty.Value))));
                    }
                    else
                    {
                         _sqlParameterList.Add(new ParameterSql(string.Format("@{0}", name), columnProperty.Value));
                    }
               }
               else if (columnProperty is PropertyValue<byte[]>)
               {
                    if (columnProperty.Value == null)
                         _sqlParameterList.Add(new ParameterSql(string.Format("@{0}", name), global::System.Data.SqlTypes.SqlBinary.Null));
                    else
                         _sqlParameterList.Add(new ParameterSql(string.Format("@{0}", name), columnProperty.Value));
               }
               else
                    _sqlParameterList.Add(new ParameterSql(string.Format("@{0}", name), columnProperty.Value));
               _existsChangesField = true;
               _existsChanges = true;
               values.AppendFormat("{0}=@{0},", FieldNameFix(name));
          }

          private void AddToValueChange<T>(string name, PropertyValue<T> columnProperties, List<HistoryField> list)
          {
               if (!_existsChangesField)
                    return;
               HistoryField json = new HistoryField()
               {
                    Id = Convert.ToString(columnProperties.FieldId),
                    Name = name
               };
               json.NewValue = Convert.ToString(columnProperties.Value);
               json.PreviousValue = Convert.ToString(columnProperties.OldValue);
               list.Add(json);
          }

          /// <summary>
          /// Este metodo se declara para que las clases que hereden, implementen el metodo con la carga de los metadatos en
          /// otro metodo estatico
          /// Si los metodos no implementan sus propios campos se toman por defaulf la configuracion de la base de datos
          /// </summary>
          protected virtual void LoadColumnProperties()
          {
               if (!Equals(KeyFields, null) && !Equals(Properties, null))
               {
                    return;
               }
          }

          protected virtual void LoadColumnVirtualProperties()
          {
               if (!Equals(KeyFields, null) && !Equals(Properties, null))
               {
                    return;
               }
          }


          private StringBuilder ValidateAndCreateQueryForUpdateWitSqlParameters2()
          {
               StringBuilder keyFields;
               StringBuilder values;
               StringBuilder query;
               PropertyValue<byte> byteProperty;
               PropertyValue<short> int16Property;
               PropertyValue<int> int32Property;
               PropertyValue<long> int64Property;
               PropertyValue<double> doubleProperty;
               PropertyValue<float> singleProperty;
               PropertyValue<bool> boolProperty;
               PropertyValue<byte[]> bytesProperty;
               PropertyValue<string> stringProperty;
               PropertyValue<DateTime> dateTimeProperty;
               PropertyValue<DateTimeOffset> dateTimeOffsetProperty;
               PropertyValue<decimal> decimalProperty;
               PropertyValue<object> objectProperty;
               PropertyValue<byte?> byteNProperty;
               PropertyValue<short?> int16NProperty;
               PropertyValue<int?> inte32NProperty;
               PropertyValue<long?> int64NProperty;
               PropertyValue<double?> doubleNProperty;
               PropertyValue<float?> singleNProperty;
               PropertyValue<bool?> boolNProperty;
               PropertyValue<DateTime?> dateTimeNProperty;
               PropertyValue<DateTimeOffset?> dateTimeOffsetNProperty;
               PropertyValue<decimal?> decimalNProperty;
               List<HistoryField> list;
               query = new StringBuilder();
               keyFields = new StringBuilder();
               values = new StringBuilder();
               _existsChanges = false;
               list = new List<HistoryField>();
               _sqlParameterList = new List<ParameterSql>();
               foreach (KeyValuePair<string, Property> column in Properties)
               {
                    _existsChangesField = false;
                    if (column.Value.IsVirtualField)
                         continue;
                    if (column.Value.IsPrimaryKey)
                    {
                         keyFields.AppendFormat("{0}=@{0}key AND ", FieldNameFix(column.Key));
                    }
                    //obtener el tipo de datos
                    new Switch(column.Value)
                         .Case<PropertyValue<bool>>(_ =>
                         {
                              boolProperty = column.Value as PropertyValue<bool>;
                              AddValue(column.Key, boolProperty, ref values);
                              AddToValueChange(column.Key, boolProperty, list);
                         })
                         .Case<PropertyValue<byte>>(_ =>
                         {
                              byteProperty = column.Value as PropertyValue<byte>;
                              AddValue(column.Key, byteProperty, ref values);
                              AddToValueChange(column.Key, byteProperty, list);
                         })
                         .Case<PropertyValue<short>>(_ =>
                         {
                              int16Property = column.Value as PropertyValue<short>;
                              AddValue(column.Key, int16Property, ref values);
                              AddToValueChange(column.Key, int16Property, list);
                         })
                         .Case<PropertyValue<int>>(_ =>
                         {
                              int32Property = column.Value as PropertyValue<int>;
                              AddValue(column.Key, int32Property, ref values);
                              AddToValueChange(column.Key, int32Property, list);
                         })
                         .Case<PropertyValue<long>>(_ =>
                         {
                              int64Property = column.Value as PropertyValue<long>;
                              AddValue(column.Key, int64Property, ref values);
                              AddToValueChange(column.Key, int64Property, list);
                         })
                         .Case<PropertyValue<DateTime>>(_ =>
                         {
                              dateTimeProperty = column.Value as PropertyValue<DateTime>;
                              AddValue(column.Key, dateTimeProperty, ref values);
                              AddToValueChange(column.Key, dateTimeProperty, list);
                         })
                         .Case<PropertyValue<DateTimeOffset>>(_ =>
                         {
                              dateTimeOffsetProperty = column.Value as PropertyValue<DateTimeOffset>;
                              AddValue(column.Key, dateTimeOffsetProperty, ref values);
                              AddToValueChange(column.Key, dateTimeOffsetProperty, list);
                         })
                         .Case<PropertyValue<decimal>>(_ =>
                         {
                              decimalProperty = column.Value as PropertyValue<decimal>;
                              AddValue(column.Key, decimalProperty, ref values);
                              AddToValueChange(column.Key, decimalProperty, list);
                         })
                         .Case<PropertyValue<float>>(_ =>
                         {
                              singleProperty = column.Value as PropertyValue<float>;
                              AddValue(column.Key, singleProperty, ref values);
                              AddToValueChange(column.Key, singleProperty, list);
                         })
                         .Case<PropertyValue<double>>(_ =>
                         {
                              doubleProperty = column.Value as PropertyValue<double>;
                              AddValue(column.Key, doubleProperty, ref values);
                              AddToValueChange(column.Key, doubleProperty, list);
                         })
                         .Case<PropertyValue<object>>(_ =>
                         {
                              objectProperty = column.Value as PropertyValue<object>;
                              AddValue(column.Key, objectProperty, ref values);
                              AddToValueChange(column.Key, objectProperty, list);
                         })
                         .Case<PropertyValue<byte[]>>(_ =>
                         {
                              bytesProperty = column.Value as PropertyValue<byte[]>;
                              //Ponemos como regla que los byte[] no pueden ser llaves primarias
                              AddValue(column.Key, bytesProperty, ref values);
                              AddToValueChange(column.Key, bytesProperty, list);
                         })
                         .Case<PropertyValue<string>>(_ =>
                         {
                              stringProperty = column.Value as PropertyValue<string>;
                              AddValue(column.Key, stringProperty, ref values);
                              AddToValueChange(column.Key, stringProperty, list);
                         })
                         .Case<PropertyValue<byte?>>(_ =>
                         {
                              byteNProperty = column.Value as PropertyValue<byte?>;
                              AddValue(column.Key, byteNProperty, ref values);
                              AddToValueChange(column.Key, byteNProperty, list);
                         })
                         .Case<PropertyValue<bool?>>(_ =>
                         {
                              boolNProperty = column.Value as PropertyValue<bool?>;
                              AddValue(column.Key, boolNProperty, ref values);
                              AddToValueChange(column.Key, boolNProperty, list);
                         })
                         .Case<PropertyValue<short?>>(_ =>
                         {
                              int16NProperty = column.Value as PropertyValue<short?>;
                              AddValue(column.Key, int16NProperty, ref values);
                              AddToValueChange(column.Key, int16NProperty, list);
                         })
                         .Case<PropertyValue<int?>>(_ =>
                         {
                              inte32NProperty = column.Value as PropertyValue<int?>;
                              AddValue(column.Key, inte32NProperty, ref values);
                              AddToValueChange(column.Key, inte32NProperty, list);
                         })
                         .Case<PropertyValue<long?>>(_ =>
                         {
                              int64NProperty = column.Value as PropertyValue<long?>;
                              AddValue(column.Key, int64NProperty, ref values);
                              AddToValueChange(column.Key, int64NProperty, list);
                         })
                         .Case<PropertyValue<DateTime?>>(_ =>
                         {
                              dateTimeNProperty = column.Value as PropertyValue<DateTime?>;
                              AddValue(column.Key, dateTimeNProperty, ref values);
                              AddToValueChange(column.Key, dateTimeNProperty, list);
                         })
                         .Case<PropertyValue<DateTimeOffset?>>(_ =>
                         {
                              dateTimeOffsetNProperty = column.Value as PropertyValue<DateTimeOffset?>;
                              AddValue(column.Key, dateTimeOffsetNProperty, ref values);
                              AddToValueChange(column.Key, dateTimeOffsetNProperty, list);
                         })
                         .Case<PropertyValue<decimal?>>(_ =>
                         {
                              decimalNProperty = column.Value as PropertyValue<decimal?>;
                              AddValue(column.Key, decimalNProperty, ref values);
                              AddToValueChange(column.Key, decimalNProperty, list);
                         })
                         .Case<PropertyValue<float?>>(_ =>
                         {
                              singleNProperty = column.Value as PropertyValue<float?>;
                              AddValue(column.Key, singleNProperty, ref values);
                              AddToValueChange(column.Key, singleNProperty, list);
                         })
                         .Case<PropertyValue<double?>>(_ =>
                         {
                              doubleNProperty = column.Value as PropertyValue<double?>;
                              AddValue(column.Key, doubleNProperty, ref values);
                              AddToValueChange(column.Key, doubleNProperty, list);
                         });
               }

               if (!_existsChanges)
               {
                    return query;
               }
               _HistoryFields = list.ConvertObjectToJson();
               query.AppendFormat("Update {0} set {1}  where {2}",
                    TableName(),
                    values.Remove(values.Length - 1, 1),
                    keyFields.Remove(keyFields.Length - 5, 5));
               return query;
          }
          private StringBuilder ValidateAndCreateQueryForUpdateWitSqlParameters()
          {
               StringBuilder keyFields;
               StringBuilder values;
               StringBuilder query;
               PropertyValue<byte> byteProperty;
               PropertyValue<short> int16Property;
               PropertyValue<int> int32Property;
               PropertyValue<long> int64Property;
               PropertyValue<double> doubleProperty;
               PropertyValue<float> singleProperty;
               PropertyValue<bool> boolProperty;
               PropertyValue<byte[]> bytesProperty;
               PropertyValue<string> stringProperty;
               PropertyValue<DateTime> dateTimeProperty;
               PropertyValue<DateTimeOffset> dateTimeOffsetProperty;
               PropertyValue<decimal> decimalProperty;
               PropertyValue<object> objectProperty;
               PropertyValue<byte?> byteNProperty;
               PropertyValue<short?> int16NProperty;
               PropertyValue<int?> inte32NProperty;
               PropertyValue<long?> int64NProperty;
               PropertyValue<double?> doubleNProperty;
               PropertyValue<float?> singleNProperty;
               PropertyValue<bool?> boolNProperty;
               PropertyValue<DateTime?> dateTimeNProperty;
               PropertyValue<DateTimeOffset?> dateTimeOffsetNProperty;
               PropertyValue<decimal?> decimalNProperty;
               List<HistoryField> list;
               query = new StringBuilder();
               keyFields = new StringBuilder();
               values = new StringBuilder();
               _existsChanges = false;
               list = new List<HistoryField>();
               _sqlParameterList = new List<ParameterSql>();
               foreach (KeyValuePair<string, Property> column in Properties)
               {
                    _existsChangesField = false;
                    if (column.Value.IsVirtualField)
                         continue;
                    if (column.Value.IsPrimaryKey)
                    {
                         keyFields.AppendFormat("{0}=@{0}key AND ", FieldNameFix(column.Key));
                    }
                    //obtener el tipo de datos
                    switch (column.Value)
                    {
                         case PropertyValue<bool>:

                              boolProperty = column.Value as PropertyValue<bool>;
                              AddValue(column.Key, boolProperty, ref values);
                              AddToValueChange(column.Key, boolProperty, list);
                              break;
                         case PropertyValue<byte>:

                              byteProperty = column.Value as PropertyValue<byte>;
                              AddValue(column.Key, byteProperty, ref values);
                              AddToValueChange(column.Key, byteProperty, list);
                              break;
                         case PropertyValue<short>:

                              int16Property = column.Value as PropertyValue<short>;
                              AddValue(column.Key, int16Property, ref values);
                              AddToValueChange(column.Key, int16Property, list);
                              break;
                         case PropertyValue<int>:

                              int32Property = column.Value as PropertyValue<int>;
                              AddValue(column.Key, int32Property, ref values);
                              AddToValueChange(column.Key, int32Property, list);
                              break;
                         case PropertyValue<long>:

                              int64Property = column.Value as PropertyValue<long>;
                              AddValue(column.Key, int64Property, ref values);
                              AddToValueChange(column.Key, int64Property, list);
                              break;
                         case PropertyValue<DateTime>:

                              dateTimeProperty = column.Value as PropertyValue<DateTime>;
                              AddValue(column.Key, dateTimeProperty, ref values);
                              AddToValueChange(column.Key, dateTimeProperty, list);
                              break;
                         case PropertyValue<DateTimeOffset>:

                              dateTimeOffsetProperty = column.Value as PropertyValue<DateTimeOffset>;
                              AddValue(column.Key, dateTimeOffsetProperty, ref values);
                              AddToValueChange(column.Key, dateTimeOffsetProperty, list);
                              break;
                         case PropertyValue<decimal>:

                              decimalProperty = column.Value as PropertyValue<decimal>;
                              AddValue(column.Key, decimalProperty, ref values);
                              AddToValueChange(column.Key, decimalProperty, list);
                              break;
                         case PropertyValue<float>:

                              singleProperty = column.Value as PropertyValue<float>;
                              AddValue(column.Key, singleProperty, ref values);
                              AddToValueChange(column.Key, singleProperty, list);
                              break;
                         case PropertyValue<double>:

                              doubleProperty = column.Value as PropertyValue<double>;
                              AddValue(column.Key, doubleProperty, ref values);
                              AddToValueChange(column.Key, doubleProperty, list);
                              break;
                         case PropertyValue<object>:

                              objectProperty = column.Value as PropertyValue<object>;
                              AddValue(column.Key, objectProperty, ref values);
                              AddToValueChange(column.Key, objectProperty, list);
                              break;
                         case PropertyValue<byte[]>:

                              bytesProperty = column.Value as PropertyValue<byte[]>;
                              //Ponemos como regla que los byte[] no pueden ser llaves primarias
                              AddValue(column.Key, bytesProperty, ref values);
                              AddToValueChange(column.Key, bytesProperty, list);
                              break;
                         case PropertyValue<string>:

                              stringProperty = column.Value as PropertyValue<string>;
                              AddValue(column.Key, stringProperty, ref values);
                              AddToValueChange(column.Key, stringProperty, list);
                              break;
                         case PropertyValue<byte?>:

                              byteNProperty = column.Value as PropertyValue<byte?>;
                              AddValue(column.Key, byteNProperty, ref values);
                              AddToValueChange(column.Key, byteNProperty, list);
                              break;
                         case PropertyValue<bool?>:

                              boolNProperty = column.Value as PropertyValue<bool?>;
                              AddValue(column.Key, boolNProperty, ref values);
                              AddToValueChange(column.Key, boolNProperty, list);
                              break;
                         case PropertyValue<short?>:

                              int16NProperty = column.Value as PropertyValue<short?>;
                              AddValue(column.Key, int16NProperty, ref values);
                              AddToValueChange(column.Key, int16NProperty, list);
                              break;
                         case PropertyValue<int?>:

                              inte32NProperty = column.Value as PropertyValue<int?>;
                              AddValue(column.Key, inte32NProperty, ref values);
                              AddToValueChange(column.Key, inte32NProperty, list);
                              break;
                         case PropertyValue<long?>:

                              int64NProperty = column.Value as PropertyValue<long?>;
                              AddValue(column.Key, int64NProperty, ref values);
                              AddToValueChange(column.Key, int64NProperty, list);
                              break;
                         case PropertyValue<DateTime?>:

                              dateTimeNProperty = column.Value as PropertyValue<DateTime?>;
                              AddValue(column.Key, dateTimeNProperty, ref values);
                              AddToValueChange(column.Key, dateTimeNProperty, list);
                              break;
                         case PropertyValue<DateTimeOffset?>:

                              dateTimeOffsetNProperty = column.Value as PropertyValue<DateTimeOffset?>;
                              AddValue(column.Key, dateTimeOffsetNProperty, ref values);
                              AddToValueChange(column.Key, dateTimeOffsetNProperty, list);
                              break;
                         case PropertyValue<decimal?>:

                              decimalNProperty = column.Value as PropertyValue<decimal?>;
                              AddValue(column.Key, decimalNProperty, ref values);
                              AddToValueChange(column.Key, decimalNProperty, list);
                              break;
                         case PropertyValue<float?>:

                              singleNProperty = column.Value as PropertyValue<float?>;
                              AddValue(column.Key, singleNProperty, ref values);
                              AddToValueChange(column.Key, singleNProperty, list);
                              break;
                         case PropertyValue<double?>:

                              doubleNProperty = column.Value as PropertyValue<double?>;
                              AddValue(column.Key, doubleNProperty, ref values);
                              AddToValueChange(column.Key, doubleNProperty, list);
                              break;
                    }
               }
               if (!_existsChanges)
               {
                    return query;
               }
               _HistoryFields = list.ConvertObjectToJson();
               query.AppendFormat("Update {0} set {1}  where {2}",
                    TableName(),
                    values.Remove(values.Length - 1, 1),
                    keyFields.Remove(keyFields.Length - 5, 5));
               return query;
          }
          private List<string> _keywords = [ "ADD"
               ,"EXTERNAL","PROCEDURE","ALL","FETCH"
               ,"PUBLIC","ALTER","FILE","RAISERROR"
               ,"AND","FILLFACTOR","READ","ANY","FOR"
               ,"READTEXT","AS","FOREIGN","RECONFIGURE","ASC"
               ,"FREETEXT","REFERENCES","AUTHORIZATION","FREETEXTTABLE"
               ,"REPLICATION","BACKUP","FROM","RESTORE"
               ,"BEGIN"
               ,"FULL"
               ,"RESTRICT"
               ,"BETWEEN"
               ,"FUNCTION"
               ,"RETURN"
               ,"BREAK"
               ,"GOTO"
               ,"REVERT"
               ,"BROWSE"
               ,"GRANT"
               ,"REVOKE"
               ,"BULK"
               ,"GROUP"
               ,"RIGHT"
               ,"BY"
               ,"HAVING"
               ,"ROLLBACK"
               ,"CASCADE"
               ,"HOLDLOCK"
               ,"ROWCOUNT"
               ,"CASE"
               ,"IDENTITY"
               ,"ROWGUIDCOL"
               ,"CHECK"
               ,"IDENTITY_INSERT"
               ,"RULE"
               ,"CHECKPOINT"
               ,"IDENTITYCOL"
               ,"SAVE"
               ,"CLOSE"
               ,"IF"
               ,"SCHEMA"
               ,"CLUSTERED"
               ,"IN"
               ,"SECURITYAUDIT"
               ,"COALESCE"
               ,"INDEX"
               ,"SELECT"
               ,"COLLATE"
               ,"INNER"
               ,"SEMANTICKEYPHRASETABLE"
               ,"COLUMN"
               ,"INSERT"
               ,"SEMANTICSIMILARITYDETAILSTABLE"
               ,"COMMIT"
               ,"INTERSECT"
               ,"SEMANTICSIMILARITYTABL"
               ,"COMPUTE"
               ,"INTO"
               ,"SESSION_USER"
               ,"CONSTRAINT"
               ,"IS"
               ,"SET"
               ,"CONTAINS"
               ,"JOIN"
               ,"SETUSER"
               ,"CONTAINSTABLE"
               ,"KEY"
               ,"SHUTDOWN"
               ,"CONTINUE"
               ,"KILL"
               ,"SOME"
               ,"CONVERT"
               ,"LEFT"
               ,"STATISTICS"
               ,"CREATE"
               ,"LIKE"
               ,"SYSTEM_USER"
               ,"CROSS"
               ,"LINENO"
               ,"TABLE"
               ,"CURRENT"
               ,"LOAD"
               ,"TABLESAMPLE"
               ,"CURRENT_DATE"
               ,"MERGE"
               ,"TEXTSIZE"
               ,"CURRENT_TIME"
               ,"NATIONAL"
               ,"THEN"
               ,"CURRENT_TIMESTAMP"
               ,"NOCHECK"
               ,"TO"
               ,"CURRENT_USER"
               ,"NONCLUSTERED"
               ,"TOP"
               ,"CURSOR"
               ,"NOT"
               ,"TRAN"
               ,"DATABASE"
               ,"NULL"
               ,"TRANSACTION"
               ,"DBCC"
               ,"NULLIF"
               ,"TRIGGER"
               ,"DEALLOCATE"
               ,"OF"
               ,"TRUNCATE"
               ,"DECLARE"
               ,"OFF"
               ,"TRY_CONVERT"
               ,"DEFAULT"
               ,"OFFSETS"
               ,"TSEQUAL"
               ,"DELETE"
               ,"ON"
               ,"UNION"
               ,"DENY"
               ,"OPEN"
               ,"UNIQUE"
               ,"DESC"
               ,"OPENDATASOURCE"
               ,"UNPIVOT"
               ,"DISK"
               ,"OPENQUERY"
               ,"UPDATE"
               ,"DISTINCT"
               ,"OPENROWSET"
               ,"UPDATETEXT"
               ,"DISTRIBUTED"
               ,"OPENXML"
               ,"USE"
               ,"DOUBLE"
               ,"OPTION"
               ,"USER"
               ,"DROP"
               ,"OR"
               ,"VALUES"
               ,"DUMP"
               ,"ORDER"
               ,"VARYING"
               ,"ELSE"
               ,"OUTER"
               ,"VIEW"
               ,"END"
               ,"OVER"
               ,"WAITFOR"
               ,"ERRLVL"
               ,"PERCENT"
               ,"WHEN"
               ,"ESCAPE"
               ,"PIVOT"
               ,"WHERE"
               ,"EXCEPT"
               ,"PLAN"
               ,"WHILE"
               ,"EXEC"
               ,"PRECISION"
               ,"WITH"
               ,"EXECUTE"
               ,"PRIMARY"
               ,"WITHINGROUP"
               ,"EXISTS"
               ,"PRINT"
               ,"WRITETEXT"
               ,"EXIT"
               ,"PROC"];
          private string FieldNameFix(string column)
          {
               if (column.Contains("%") || column.Contains(" ") || _keywords.Contains (column))
               {
                    switch (Connection.DataBase.Engine)
                    {
                         default:
                              return string.Format("[{0}]", column);
                    }
               }
               return column;
          }

          /// <summary>
          /// Valida y arma la consulta para el insert
          /// </summary>
          /// <param name="pbIncluyeHoras">if set to <c>true</c> [pb incluye horas].</param>
          /// <returns></returns>
          /// <exception cref="Exception">
          /// </exception>
          private StringBuilder ValidateQueryForInsert(bool pbIncluyeHoras)
          {
               StringBuilder fields;
               StringBuilder values;
               StringBuilder query;
               string parameterName;
               int parameterCounter;

               PropertyValue<byte> byteProperty;
               PropertyValue<short> int16Property;
               PropertyValue<int> inte32Property;
               PropertyValue<long> int64Property;
               PropertyValue<double> doubleProperty;
               PropertyValue<float> singleProperty;
               PropertyValue<bool> boolProperty;
               PropertyValue<byte[]> bytesProperty;
               PropertyValue<string> stringProperty;
               PropertyValue<DateTime> dateTimeProperty;
               PropertyValue<decimal> decimalProperty;
               PropertyValue<object> objectProperty;
               PropertyValue<byte?> byteNProperty;
               PropertyValue<short?> int16NProperty;
               PropertyValue<int?> int32NProperty;
               PropertyValue<long?> int64NProperty;
               PropertyValue<double?> doubleNProperty;
               PropertyValue<float?> singleNProperty;
               PropertyValue<bool?> boolNProperty;
               PropertyValue<DateTime?> dateTimeNProperty;
               PropertyValue<decimal?> decimalNProperty;
               query = new StringBuilder();
               fields = new StringBuilder();
               values = new StringBuilder();

               _sqlParameterList = new List<ParameterSql>();
               parameterCounter = 0;
               _existsChanges = false;
               foreach (KeyValuePair<string, Property> column in Properties)
               {
                    if (column.Value.IsIdentity)
                    {
                         _existsChanges = true;
                         //Si es un campo identidad que no lo considere para los inserts
                         continue;
                    }
                    fields.AppendFormat("{0},", FieldNameFix(column.Key));
                    //obtener el tipo de datos
                    if (column.Value is PropertyValue<bool>)
                    {
                         boolProperty = column.Value as PropertyValue<bool>;
                         values.AppendFormat("{0},", boolProperty.Value ? "1" : "0");
                    }
                    if (column.Value is PropertyValue<byte>)
                    {
                         byteProperty = column.Value as PropertyValue<byte>;
                         values.AppendFormat("{0},", byteProperty.Value);
                    }
                    if (column.Value is PropertyValue<short>)
                    {
                         int16Property = column.Value as PropertyValue<short>;
                         values.AppendFormat("{0},", int16Property.Value);
                    }
                    if (column.Value is PropertyValue<int>)
                    {
                         inte32Property = column.Value as PropertyValue<int>;
                         values.AppendFormat("{0},", inte32Property.Value);
                    }
                    if (column.Value is PropertyValue<long>)
                    {
                         int64Property = column.Value as PropertyValue<long>;
                         values.AppendFormat("{0},", int64Property.Value);
                    }
                    if (column.Value is PropertyValue<DateTime>)
                    {
                         dateTimeProperty = column.Value as PropertyValue<DateTime>;
                         if (dateTimeProperty.IsRequiredInDataBase)
                         {
                              if (Equals(dateTimeProperty.Value, null) || Equals(dateTimeProperty.Value, default(DateTime)))
                              {
                                   throw new CoreException(Errors.E00000080,$"{dateTimeProperty.Description}");
                              }
                         }
                         values.AppendFormat("{0},", dateTimeProperty.Value.DateSql(pbIncluyeHoras, Connection.DataBase.Engine));
                    }
                    if (column.Value is PropertyValue<decimal>)
                    {
                         decimalProperty = column.Value as PropertyValue<decimal>;
                         values.AppendFormat("{0},", decimalProperty.Value);
                    }
                    if (column.Value is PropertyValue<float>)
                    {
                         singleProperty = column.Value as PropertyValue<float>;
                         values.AppendFormat("{0},", singleProperty.Value);
                    }
                    if (column.Value is PropertyValue<double>)
                    {
                         doubleProperty = column.Value as PropertyValue<double>;
                         values.AppendFormat("{0},", doubleProperty.Value);
                    }
                    if (column.Value is PropertyValue<object>)
                    {
                         objectProperty = column.Value as PropertyValue<object>;
                         if (objectProperty.IsRequiredInDataBase)
                         {
                              if (Equals(objectProperty.Value, null))
                              {
                                   throw new CoreException(Errors.E00000080,$"{objectProperty.Description}");
                              }
                         }
                         values.AppendFormat("'{0}',", objectProperty.Value);
                    }
                    if (column.Value is PropertyValue<byte[]>)
                    {
                         bytesProperty = column.Value as PropertyValue<byte[]>;
                         if (bytesProperty.IsRequiredInDataBase)
                         {
                              if (Equals(bytesProperty.Value, null))
                              {
                                   throw new CoreException(Errors.E00000080,$"{bytesProperty.Description}");
                              }
                         }
                         if (Equals(bytesProperty.Value, null))
                         {
                              values.AppendFormat("null,");
                         }
                         else
                         {
                              parameterName = string.Format("@Parametro{0}", Convert.ToString(parameterCounter));
                              values.AppendFormat("{0},", parameterName);
                              _sqlParameterList.Add(new ParameterSql(parameterName, bytesProperty.Value));
                              parameterCounter++;
                         }
                    }
                    if (column.Value is PropertyValue<string>)
                    {
                         stringProperty = column.Value as PropertyValue<string>;

                         if (stringProperty.IsRequiredInDataBase)
                         {
                              if (string.IsNullOrEmpty(stringProperty.Value))
                              {
                                   throw new CoreException(Errors.E00000080,$"{stringProperty.Description}");
                              }
                              if (stringProperty.Value.Length > stringProperty.Length && stringProperty.Length > -1)
                              {
                                   throw new CoreException(Errors.E00000081,$"{stringProperty.Description}");
                              }
                         }
                         if (Equals(stringProperty.Value, null))
                         {
                              values.AppendFormat("null,");
                         }
                         else
                         {
                              if (stringProperty.Value.Length > stringProperty.Length && stringProperty.Length > -1)
                              {
                                   throw new CoreException(Errors.E00000081,$"{stringProperty.Description}");
                              }
                              values.AppendFormat("'{0}',", stringProperty.Value);
                         }
                    }
                    if (column.Value is PropertyValue<byte?>)
                    {
                         byteNProperty = column.Value as PropertyValue<byte?>;
                         if (byteNProperty.IsRequiredInDataBase)
                         {
                              if (Equals(byteNProperty.Value, null))
                              {
                                   throw new CoreException(Errors.E00000080,$"{byteNProperty.Description}");
                              }
                         }
                         if (Equals(byteNProperty.Value, null))
                         {
                              values.AppendFormat("null,");
                         }
                         else
                         {
                              values.AppendFormat("{0},", byteNProperty.Value);
                         }
                    }
                    if (column.Value is PropertyValue<bool?>)
                    {
                         boolNProperty = column.Value as PropertyValue<bool?>;
                         if (boolNProperty.IsRequiredInDataBase)
                         {
                              if (Equals(boolNProperty.Value, null))
                              {
                                   throw new CoreException(Errors.E00000080,$"{boolNProperty.Description}");
                              }
                         }
                         if (Equals(boolNProperty.Value, null))
                         {
                              values.AppendFormat("null,");
                         }
                         else
                         {
                              values.AppendFormat("{0},", (bool)boolNProperty.Value ? "1" : "0");
                         }
                    }
                    if (column.Value is PropertyValue<short?>)
                    {
                         int16NProperty = column.Value as PropertyValue<short?>;
                         if (int16NProperty.IsRequiredInDataBase)
                         {
                              if (Equals(int16NProperty.Value, null))
                              {
                                   throw new CoreException(Errors.E00000080,$"{int16NProperty.Description}");
                              }
                         }
                         if (Equals(int16NProperty.Value, null))
                         {
                              values.AppendFormat("null,");
                         }
                         else
                         {
                              values.AppendFormat("{0},", int16NProperty.Value);
                         }
                    }
                    if (column.Value is PropertyValue<int?>)
                    {
                         int32NProperty = column.Value as PropertyValue<int?>;
                         if (int32NProperty.IsRequiredInDataBase)
                         {
                              if (Equals(int32NProperty.Value, null))
                              {
                                   throw new CoreException(Errors.E00000080,$"{int32NProperty.Description}");
                              }
                         }
                         if (Equals(int32NProperty.Value, null))
                         {
                              values.AppendFormat("null,");
                         }
                         else
                         {
                              values.AppendFormat("{0},", int32NProperty.Value);
                         }
                    }
                    if (column.Value is PropertyValue<long?>)
                    {
                         int64NProperty = column.Value as PropertyValue<long?>;
                         if (int64NProperty.IsRequiredInDataBase)
                         {
                              if (Equals(int64NProperty.Value, null))
                              {
                                   throw new CoreException(Errors.E00000080,$"{int64NProperty.Description}");
                              }
                         }
                         if (Equals(int64NProperty.Value, null))
                         {
                              values.AppendFormat("null,");
                         }
                         else
                         {
                              values.AppendFormat("{0},", int64NProperty.Value);
                         }
                    }
                    if (column.Value is PropertyValue<DateTime?>)
                    {
                         dateTimeNProperty = column.Value as PropertyValue<DateTime?>;
                         if (dateTimeNProperty.IsRequiredInDataBase)
                         {
                              if (Equals(dateTimeNProperty.Value, null) || Equals(dateTimeNProperty.Value, default(DateTime)))
                              {
                                   throw new CoreException(Errors.E00000080,$"{dateTimeNProperty.Description}");
                              }
                         }
                         if (Equals(dateTimeNProperty.Value, null) || Equals(dateTimeNProperty.Value, default(DateTime)))
                         {
                              values.AppendFormat("null,");
                         }
                         else
                         {
                              values.AppendFormat("{0},", ((DateTime)dateTimeNProperty.Value).DateSql(pbIncluyeHoras, Connection.DataBase.Engine));
                         }
                    }
                    if (column.Value is PropertyValue<decimal?>)
                    {
                         decimalNProperty = column.Value as PropertyValue<decimal?>;
                         if (decimalNProperty.IsRequiredInDataBase)
                         {
                              if (Equals(decimalNProperty.Value, null))
                              {
                                   throw new CoreException(Errors.E00000080,$"{decimalNProperty.Description}");
                              }
                         }
                         if (Equals(decimalNProperty.Value, null))
                         {
                              values.AppendFormat("null,");
                         }
                         else
                         {
                              values.AppendFormat("{0},", decimalNProperty.Value);
                         }
                    }
                    if (column.Value is PropertyValue<float?>)
                    {
                         singleNProperty = column.Value as PropertyValue<float?>;
                         if (singleNProperty.IsRequiredInDataBase)
                         {
                              if (Equals(singleNProperty.Value, null))
                              {
                                   throw new CoreException(Errors.E00000080,$"{singleNProperty.Description}");
                              }
                         }
                         if (Equals(singleNProperty.Value, null))
                         {
                              values.AppendFormat("null,");
                         }
                         else
                         {
                              values.AppendFormat("{0},", singleNProperty.Value);
                         }
                    }
                    if (column.Value is PropertyValue<double?>)
                    {
                         doubleNProperty = column.Value as PropertyValue<double?>;
                         if (doubleNProperty.IsRequiredInDataBase)
                         {
                              if (Equals(doubleNProperty.Value, null))
                              {
                                   throw new CoreException(Errors.E00000080,$"{doubleNProperty.Description}");
                              }
                         }
                         if (Equals(doubleNProperty.Value, null))
                         {
                              values.AppendFormat("null,");
                         }
                         else
                         {
                              values.AppendFormat("{0},", doubleNProperty.Value);
                         }
                    }
               }
               _existsChanges = true;
               query.AppendFormat("Insert into {0} ({1}) values({2});", TableName(),
                    fields.Remove(fields.Length - 1, 1),
                    values.Remove(values.Length - 1, 1));
               if (_existsChanges)
                    query.AppendFormat("select {0};", Connection.FunctionSCOPEIDENTITY());
               return query;
          }

          /// <summary>
          /// Validas the y arma consulta para insert parametros SQL.
          ///
          /// </summary>
          /// <returns></returns>
          /// <exception cref="Exception">
          /// </exception>
          private StringBuilder ValidateAndCreateQueryForInsertWithSqlParameters2()
          {
               // Esta funcion se pone a prueba de desempeño, con el fin de evaluar el uso de switch dinamico
               StringBuilder fields;
               StringBuilder values;
               StringBuilder query;
               PropertyValue<byte> byteProperty;
               PropertyValue<short> int16Property;
               PropertyValue<int> inte32Property;
               PropertyValue<long> int64Property;
               PropertyValue<double> doubleProperty;
               PropertyValue<float> singleProperty;
               PropertyValue<bool> boolProperty;
               PropertyValue<byte[]> bytesProperty;
               PropertyValue<string> stringProperty;
               PropertyValue<DateTime> dateTimeProperty;
               PropertyValue<DateTimeOffset> dateTimeOffsetPropertie;
               PropertyValue<decimal> decimalProperty;
               PropertyValue<object> objectProperty;
               PropertyValue<byte?> byteNProperty;
               PropertyValue<short?> int16NProperty;
               PropertyValue<int?> int32NProperty;
               PropertyValue<long?> int64NProperty;
               PropertyValue<double?> doubleNProperty;
               PropertyValue<float?> singleNProperty;
               PropertyValue<bool?> boolNProperty;
               PropertyValue<DateTime?> dateTimeNProperty;
               PropertyValue<DateTimeOffset?> dateTimeOffsetNPropertie;
               PropertyValue<decimal?> decimalNProperty;
               query = new StringBuilder();
               fields = new StringBuilder();
               values = new StringBuilder();

               string name;
               _sqlParameterList = new List<ParameterSql>();
               _containsIdentityFields = false;
               foreach (KeyValuePair<string, Property> loColumna in Properties)
               {
                    if (loColumna.Value.IsIdentity)
                    {
                         //Si es un campo identidad que no lo considere para los inserts
                         _containsIdentityFields = true;
                         continue;
                    }
                    if (loColumna.Value.IsVirtualField)
                         continue;
                    //Hay campos en la base de datos que contiene espacios o caracteres como %, arreglamos los valores para poder hacer los querys
                    fields.AppendFormat("{0},", FieldNameFix(loColumna.Key));
                    if (loColumna.Key.Contains("%"))
                    {
                         values.AppendFormat("@{0},", loColumna.Key.Replace("%", "_"));
                         name = string.Format("@{0}", loColumna.Key.Replace("%", "_"));
                    }
                    else if (loColumna.Key.Contains(" "))
                    {
                         values.AppendFormat("@{0},", loColumna.Key.Replace(" ", "_"));
                         name = string.Format("@{0}", loColumna.Key.Replace(" ", "_"));
                    }
                    else
                    {
                         values.AppendFormat("@{0},", FieldNameFix(loColumna.Key));
                         name = string.Format("@{0}", loColumna.Key);
                    }
                    new Switch(loColumna.Value)
                         .Case<PropertyValue<bool>>(_ =>
                         {
                              boolProperty = loColumna.Value as PropertyValue<bool>;
                              if (boolProperty.IsPrimaryKey)
                                   KeyFields[loColumna.Key] = boolProperty.Value;
                              _sqlParameterList.Add(new ParameterSql(name, boolProperty.Value));
                         })
                         .Case<PropertyValue<byte>>(_ =>
                         {
                              byteProperty = loColumna.Value as PropertyValue<byte>;
                              if (byteProperty.IsPrimaryKey)
                                   KeyFields[loColumna.Key] = byteProperty.Value;
                              _sqlParameterList.Add(new ParameterSql(name, byteProperty.Value));
                         })
                         .Case<PropertyValue<short>>(_ =>
                         {
                              int16Property = loColumna.Value as PropertyValue<short>;
                              if (int16Property.IsPrimaryKey)
                                   KeyFields[loColumna.Key] = int16Property.Value;
                              _sqlParameterList.Add(new ParameterSql(name, int16Property.Value));
                         })
                         .Case<PropertyValue<int>>(_ =>
                         {
                              inte32Property = loColumna.Value as PropertyValue<int>;
                              if (inte32Property.IsPrimaryKey)
                                   KeyFields[loColumna.Key] = inte32Property.Value;
                              _sqlParameterList.Add(new ParameterSql(name, inte32Property.Value));
                         })
                         .Case<PropertyValue<long>>(_ =>
                         {
                              int64Property = loColumna.Value as PropertyValue<long>;
                              if (int64Property.IsPrimaryKey)
                                   KeyFields[loColumna.Key] = int64Property.Value;
                              _sqlParameterList.Add(new ParameterSql(name, int64Property.Value));
                         })
                         .Case<PropertyValue<DateTime>>(_ =>
                         {
                              dateTimeProperty = loColumna.Value as PropertyValue<DateTime>;
                              if (dateTimeProperty.IsPrimaryKey)
                                   KeyFields[loColumna.Key] = dateTimeProperty.Value;
                              if (dateTimeProperty.IsRequiredInDataBase)
                              {
                                   if (dateTimeProperty.Value == default || dateTimeProperty.Value == DefaultDateTime)
                                   {
                                        throw new CoreException(Errors.E00000080,$"{dateTimeProperty.Description}");
                                   }
                              }
                              if (dateTimeProperty.Value < DefaultDateTime)
                                   throw new CoreException(Errors.E00000080,$"{dateTimeProperty.Description}");
                              switch (Connection.DataBase.Engine)
                              {
                                   case DataBaseType.PostgressSql:
                                        _sqlParameterList.Add(new ParameterSql(name, dateTimeProperty.Value.ToUniversalTime()));
                                        break;
                                   case DataBaseType.MySql:
                                        _sqlParameterList.Add(new ParameterSql(name, dateTimeProperty.Value.ToUniversalTime().DateSqlParameters(dateTimeProperty.IsIncludeHours, "-")));
                                        break;
                                   default:
                                        _sqlParameterList.Add(new ParameterSql(name, dateTimeProperty.Value.ToUniversalTime().DateSqlParameters(dateTimeProperty.IsIncludeHours)));
                                        break;
                              }

                         })
                         .Case<PropertyValue<DateTimeOffset>>(_ =>
                         {
                              dateTimeOffsetPropertie = loColumna.Value as PropertyValue<DateTimeOffset>;
                              if (dateTimeOffsetPropertie.IsPrimaryKey)
                                   KeyFields[loColumna.Key] = dateTimeOffsetPropertie.Value;
                              if (dateTimeOffsetPropertie.IsRequiredInDataBase)
                              {
                                   if (dateTimeOffsetPropertie.Value == default)
                                   {
                                        throw new CoreException(Errors.E00000080,$"{dateTimeOffsetPropertie.Description}");
                                   }
                              }
                              _sqlParameterList.Add(new ParameterSql(name, dateTimeOffsetPropertie.Value.ToUniversalTime().DateSqlParameters(dateTimeOffsetPropertie.IsIncludeHours)));
                         })
                         .Case<PropertyValue<decimal>>(_ =>
                         {
                              decimalProperty = loColumna.Value as PropertyValue<decimal>;
                              if (decimalProperty.IsPrimaryKey)
                                   KeyFields[loColumna.Key] = decimalProperty.Value;
                              _sqlParameterList.Add(new ParameterSql(name, decimalProperty.Value));
                         })
                         .Case<PropertyValue<float>>(_ =>
                         {
                              singleProperty = loColumna.Value as PropertyValue<float>;
                              if (singleProperty.IsPrimaryKey)
                                   KeyFields[loColumna.Key] = singleProperty.Value;
                              _sqlParameterList.Add(new ParameterSql(name, singleProperty.Value));
                         })
                         .Case<PropertyValue<double>>(_ =>
                         {
                              doubleProperty = loColumna.Value as PropertyValue<double>;
                              if (doubleProperty.IsPrimaryKey)
                                   KeyFields[loColumna.Key] = doubleProperty.Value;
                              _sqlParameterList.Add(new ParameterSql(name, doubleProperty.Value));
                         })
                         .Case<PropertyValue<object>>(_ =>
                         {
                              objectProperty = loColumna.Value as PropertyValue<object>;
                              if (objectProperty.IsPrimaryKey)
                                   KeyFields[loColumna.Key] = objectProperty.Value;
                              if (objectProperty.IsRequiredInDataBase)
                              {
                                   if (Equals(objectProperty.Value, null))
                                   {
                                        throw new CoreException(Errors.E00000080,$"{objectProperty.Description}");
                                   }
                              }
                              _sqlParameterList.Add(new ParameterSql(name, objectProperty.Value));
                         })
                         .Case<PropertyValue<byte[]>>(_ =>
                         {
                              bytesProperty = loColumna.Value as PropertyValue<byte[]>;
                              if (bytesProperty.IsPrimaryKey)
                                   KeyFields[loColumna.Key] = bytesProperty.Value;
                              if (bytesProperty.IsRequiredInDataBase)
                              {
                                   if (Equals(bytesProperty.Value, null))
                                   {
                                        throw new CoreException(Errors.E00000080,$"{bytesProperty.Description}");
                                   }
                              }
                              if (bytesProperty.Value == null)
                                   _sqlParameterList.Add(new ParameterSql(name, global::System.Data.SqlTypes.SqlBinary.Null));//new Byte[] { }));
                              else
                                   _sqlParameterList.Add(new ParameterSql(name, bytesProperty.Value));
                         })
                         .Case<PropertyValue<string>>(_ =>
                         {
                              stringProperty = loColumna.Value as PropertyValue<string>;
                              if (stringProperty.IsPrimaryKey)
                              {
                                   if (stringProperty.IsPassword)
                                        throw new CoreException(Errors.E00000082,$"{stringProperty.Description}");
                                   else if (stringProperty.IsEncrypted)
                                        throw new CoreException(Errors.E00000082,$"{stringProperty.Description}");
                                   else
                                        KeyFields[loColumna.Key] = stringProperty.Value;
                              }
                              if (stringProperty.IsRequiredInDataBase)
                              {
                                   //if (String.IsNullOrEmpty(loPropiedadString.Valor))
                                   if (stringProperty.Value == null)
                                   {
                                        //Vamos a considerar que la cadena vacia es un valor permitido
                                        throw new CoreException(Errors.E00000080,$"{stringProperty.Description}");
                                   }
                                   if (stringProperty.Value.Length > stringProperty.Length && stringProperty.Length > -1)
                                   {
                                        throw new CoreException(Errors.E00000081,$"{stringProperty.Description}");
                                   }
                              }

                              if (!string.IsNullOrEmpty(stringProperty.Value) && stringProperty.Value.Length > stringProperty.Length && stringProperty.Length > -1)
                              {
                                   throw new CoreException(Errors.E00000081,$"{stringProperty.Description}");
                              }
                              if (stringProperty.IsPassword)
                              {
                                   stringProperty.Value = Cipher.BCryptHashPassword(stringProperty.Value);
                                   _sqlParameterList.Add(new ParameterSql(name, stringProperty.Value));
                              }
                              else if (stringProperty.IsEncrypted && stringProperty.Value != constMask)
                              {
                                   stringProperty.Value = Cipher.EncryptPEMDataBase(stringProperty.Value);
                                   _sqlParameterList.Add(new ParameterSql(name, stringProperty.Value));
                              }
                              else if (stringProperty.IsGuid)
                              {
                                   _sqlParameterList.Add(new ParameterSql(name, new Guid(stringProperty.Value)));
                              }
                              else
                              {
                                   _sqlParameterList.Add(new ParameterSql(name, stringProperty.Value));
                              }
                         })
                         .Case<PropertyValue<byte?>>(_ =>
                         {
                              byteNProperty = loColumna.Value as PropertyValue<byte?>;
                              if (byteNProperty.IsPrimaryKey)
                                   KeyFields[loColumna.Key] = byteNProperty.Value;
                              if (byteNProperty.IsRequiredInDataBase)
                              {
                                   if (Equals(byteNProperty.Value, null))
                                   {
                                        throw new CoreException(Errors.E00000080,$"{byteNProperty.Description}");
                                   }
                              }
                              _sqlParameterList.Add(new ParameterSql(name, byteNProperty.Value));
                         })
                         .Case<PropertyValue<bool?>>(_ =>
                         {
                              boolNProperty = loColumna.Value as PropertyValue<bool?>;
                              if (boolNProperty.IsPrimaryKey)
                                   KeyFields[loColumna.Key] = boolNProperty.Value;
                              if (boolNProperty.IsRequiredInDataBase)
                              {
                                   if (Equals(boolNProperty.Value, null))
                                   {
                                        throw new CoreException(Errors.E00000080,$"{boolNProperty.Description}");
                                   }
                              }
                              _sqlParameterList.Add(new ParameterSql(name, boolNProperty.Value));
                         })
                         .Case<PropertyValue<short?>>(_ =>
                         {
                              int16NProperty = loColumna.Value as PropertyValue<short?>;
                              if (int16NProperty.IsPrimaryKey)
                                   KeyFields[loColumna.Key] = int16NProperty.Value;
                              if (int16NProperty.IsRequiredInDataBase)
                              {
                                   if (Equals(int16NProperty.Value, null))
                                   {
                                        throw new CoreException(Errors.E00000080,$"{int16NProperty.Description}");
                                   }
                              }
                              _sqlParameterList.Add(new ParameterSql(name, int16NProperty.Value));
                         })
                         .Case<PropertyValue<int?>>(_ =>
                         {
                              int32NProperty = loColumna.Value as PropertyValue<int?>;
                              if (int32NProperty.IsPrimaryKey)
                                   KeyFields[loColumna.Key] = int32NProperty.Value;
                              if (int32NProperty.IsRequiredInDataBase)
                              {
                                   if (Equals(int32NProperty.Value, null))
                                   {
                                        throw new CoreException(Errors.E00000080,$"{int32NProperty.Description}");
                                   }
                              }
                              _sqlParameterList.Add(new ParameterSql(name, int32NProperty.Value));
                         })
                         .Case<PropertyValue<long?>>(_ =>
                         {
                              int64NProperty = loColumna.Value as PropertyValue<long?>;
                              if (int64NProperty.IsPrimaryKey)
                                   KeyFields[loColumna.Key] = int64NProperty.Value;
                              if (int64NProperty.IsRequiredInDataBase)
                              {
                                   if (Equals(int64NProperty.Value, null))
                                   {
                                        throw new CoreException(Errors.E00000080,$"{int64NProperty.Description}");
                                   }
                              }
                              _sqlParameterList.Add(new ParameterSql(name, int64NProperty.Value));
                         })
                         .Case<PropertyValue<DateTime?>>(_ =>
                         {
                              dateTimeNProperty = loColumna.Value as PropertyValue<DateTime?>;
                              if (dateTimeNProperty.IsPrimaryKey)
                                   KeyFields[loColumna.Key] = dateTimeNProperty.Value;
                              if (dateTimeNProperty.IsRequiredInDataBase)
                              {
                                   if (Equals(dateTimeNProperty.Value, null) || Equals(dateTimeNProperty.Value, default(DateTime)))
                                   {
                                        throw new CoreException(Errors.E00000080,$"{dateTimeNProperty.Description}");
                                   }
                              }
                              if (!Equals(dateTimeNProperty.Value, null) && !Equals(dateTimeNProperty.Value, default(DateTime)))
                                   _sqlParameterList.Add(new ParameterSql(name, Convert.ToDateTime(dateTimeNProperty.Value).ToUniversalTime().DateSqlParameters(dateTimeNProperty.IsIncludeHours)));
                              else
                                   _sqlParameterList.Add(new ParameterSql(name, dateTimeNProperty.Value));
                         })
                         .Case<PropertyValue<DateTimeOffset?>>(_ =>
                         {
                              dateTimeOffsetNPropertie = loColumna.Value as PropertyValue<DateTimeOffset?>;
                              if (dateTimeOffsetNPropertie.IsPrimaryKey)
                                   KeyFields[loColumna.Key] = dateTimeOffsetNPropertie.Value;
                              if (dateTimeOffsetNPropertie.IsRequiredInDataBase)
                              {
                                   if (Equals(dateTimeOffsetNPropertie.Value, null) || Equals(dateTimeOffsetNPropertie.Value, default(DateTime)))
                                   {
                                        throw new CoreException(Errors.E00000080,$"{dateTimeOffsetNPropertie.Description}");
                                   }
                              }
                              if (!Equals(dateTimeOffsetNPropertie.Value, null) && !Equals(dateTimeOffsetNPropertie.Value, default(DateTime)))
                                   _sqlParameterList.Add(new ParameterSql(name, Convert.ToDateTime(dateTimeOffsetNPropertie.Value).ToUniversalTime().DateSqlParameters(dateTimeOffsetNPropertie.IsIncludeHours)));
                              else
                                   _sqlParameterList.Add(new ParameterSql(name, dateTimeOffsetNPropertie.Value));
                         })
                         .Case<PropertyValue<decimal?>>(_ =>
                         {
                              decimalNProperty = loColumna.Value as PropertyValue<decimal?>;
                              if (decimalNProperty.IsPrimaryKey)
                                   KeyFields[loColumna.Key] = decimalNProperty.Value;
                              if (decimalNProperty.IsRequiredInDataBase)
                              {
                                   if (Equals(decimalNProperty.Value, null))
                                   {
                                        throw new CoreException(Errors.E00000080,$"{decimalNProperty.Description}");
                                   }
                              }
                              _sqlParameterList.Add(new ParameterSql(name, decimalNProperty.Value));
                         })
                         .Case<PropertyValue<float?>>(_ =>
                         {
                              singleNProperty = loColumna.Value as PropertyValue<float?>;
                              if (singleNProperty.IsPrimaryKey)
                                   KeyFields[loColumna.Key] = singleNProperty.Value;
                              if (singleNProperty.IsRequiredInDataBase)
                              {
                                   if (Equals(singleNProperty.Value, null))
                                   {
                                        throw new CoreException(Errors.E00000080,$"{singleNProperty.Description}");
                                   }
                              }
                              _sqlParameterList.Add(new ParameterSql(name, singleNProperty.Value));
                         })
                         .Case<PropertyValue<double?>>(_ =>
                         {
                              doubleNProperty = loColumna.Value as PropertyValue<double?>;
                              if (doubleNProperty.IsPrimaryKey)
                                   KeyFields[loColumna.Key] = doubleNProperty.Value;
                              if (doubleNProperty.IsRequiredInDataBase)
                              {
                                   if (Equals(doubleNProperty.Value, null))
                                   {
                                        throw new CoreException(Errors.E00000080,$"{doubleNProperty.Description}");
                                   }
                              }
                              _sqlParameterList.Add(new ParameterSql(name, doubleNProperty.Value));
                         });
               }
               _existsChanges = true;
               query.AppendFormat("Insert into {0} ({1}) values({2});", TableName(), fields.Remove(fields.Length - 1, 1), values.Remove(values.Length - 1, 1));
               if (_containsIdentityFields)
               {
                    switch (Connection.DataBase.Engine)
                    {

                         case DataBaseType.PostgressSql:
                              foreach (KeyValuePair<string, Property> column in Properties)
                              {
                                   if (!column.Value.IsIdentity)
                                        continue;
                                   query.AppendFormat(" select {0};", Connection.FunctionSCOPEIDENTITY(column.Key));
                                   break;
                              }
                              break;
                         default:
                              query.AppendFormat(" select {0};", Connection.FunctionSCOPEIDENTITY());
                              break;
                    }
               }
               return query;
          }
          private StringBuilder ValidateAndCreateQueryForInsertWithSqlParameters()
          {
               // Esta funcion se pone a prueba de desempeño, con el fin de evaluar el uso de switch dinamico
               StringBuilder fields;
               StringBuilder values;
               StringBuilder query;
               PropertyValue<byte> byteProperty;
               PropertyValue<short> int16Property;
               PropertyValue<int> inte32Property;
               PropertyValue<long> int64Property;
               PropertyValue<double> doubleProperty;
               PropertyValue<float> singleProperty;
               PropertyValue<bool> boolProperty;
               PropertyValue<byte[]> bytesProperty;
               PropertyValue<string> stringProperty;
               PropertyValue<DateTime> dateTimeProperty;
               PropertyValue<DateTimeOffset> dateTimeOffsetPropertie;
               PropertyValue<decimal> decimalProperty;
               PropertyValue<object> objectProperty;
               PropertyValue<byte?> byteNProperty;
               PropertyValue<short?> int16NProperty;
               PropertyValue<int?> int32NProperty;
               PropertyValue<long?> int64NProperty;
               PropertyValue<double?> doubleNProperty;
               PropertyValue<float?> singleNProperty;
               PropertyValue<bool?> boolNProperty;
               PropertyValue<DateTime?> dateTimeNProperty;
               PropertyValue<DateTimeOffset?> dateTimeOffsetNPropertie;
               PropertyValue<decimal?> decimalNProperty;
               query = new StringBuilder();
               fields = new StringBuilder();
               values = new StringBuilder();

               string name;
               _sqlParameterList = new List<ParameterSql>();
               _containsIdentityFields = false;
               foreach (KeyValuePair<string, Property> loColumna in Properties)
               {
                    if (loColumna.Value.IsIdentity)
                    {
                         //Si es un campo identidad que no lo considere para los inserts
                         _containsIdentityFields = true;
                         continue;
                    }
                    if (loColumna.Value.IsVirtualField)
                         continue;
                    //Hay campos en la base de datos que contiene espacios o caracteres como %, arreglamos los valores para poder hacer los querys
                    fields.AppendFormat("{0},", FieldNameFix(loColumna.Key));
                    if (loColumna.Key.Contains('%'))
                    {
                         values.AppendFormat("@{0},", loColumna.Key.Replace("%", "_"));
                         name = string.Format("@{0}", loColumna.Key.Replace("%", "_"));
                    }
                    else if (loColumna.Key.Contains(" "))
                    {
                         values.AppendFormat("@{0},", loColumna.Key.Replace(" ", "_"));
                         name = string.Format("@{0}", loColumna.Key.Replace(" ", "_"));
                    }
                    else
                    {
                         values.AppendFormat("@{0},", FieldNameFix(loColumna.Key));
                         name = string.Format("@{0}", loColumna.Key);
                    }
                    switch (loColumna.Value)
                    {
                         case PropertyValue<bool>:
                              boolProperty = loColumna.Value as PropertyValue<bool>;
                              if (boolProperty.IsPrimaryKey)
                                   KeyFields[loColumna.Key] = boolProperty.Value;
                              _sqlParameterList.Add(new ParameterSql(name, boolProperty.Value));
                              break;
                         case PropertyValue<byte>:
                              byteProperty = loColumna.Value as PropertyValue<byte>;
                              if (byteProperty.IsPrimaryKey)
                                   KeyFields[loColumna.Key] = byteProperty.Value;
                              _sqlParameterList.Add(new ParameterSql(name, byteProperty.Value));
                              break;
                         case PropertyValue<short>:
                              int16Property = loColumna.Value as PropertyValue<short>;
                              if (int16Property.IsPrimaryKey)
                                   KeyFields[loColumna.Key] = int16Property.Value;
                              _sqlParameterList.Add(new ParameterSql(name, int16Property.Value));
                              break;
                         case PropertyValue<int>:
                              inte32Property = loColumna.Value as PropertyValue<int>;
                              if (inte32Property.IsPrimaryKey)
                                   KeyFields[loColumna.Key] = inte32Property.Value;
                              _sqlParameterList.Add(new ParameterSql(name, inte32Property.Value));
                              break;
                         case PropertyValue<long>:
                              int64Property = loColumna.Value as PropertyValue<long>;
                              if (int64Property.IsPrimaryKey)
                                   KeyFields[loColumna.Key] = int64Property.Value;
                              _sqlParameterList.Add(new ParameterSql(name, int64Property.Value));
                              break;
                         case PropertyValue<DateTime>:
                              dateTimeProperty = loColumna.Value as PropertyValue<DateTime>;
                              if (dateTimeProperty.IsPrimaryKey)
                                   KeyFields[loColumna.Key] = dateTimeProperty.Value;
                              if (dateTimeProperty.IsRequiredInDataBase)
                              {
                                   if (dateTimeProperty.Value == default || dateTimeProperty.Value == DefaultDateTime)
                                   {
                                        throw new CoreException(Errors.E00000080,$"{dateTimeProperty.Description}");
                                   }
                              }
                              if (dateTimeProperty.Value < DefaultDateTime)
                                   throw new CoreException(Errors.E00000080,$"{dateTimeProperty.Description}");
                              switch (Connection.DataBase.Engine)
                              {
                                   case DataBaseType.PostgressSql:
                                        _sqlParameterList.Add(new ParameterSql(name, dateTimeProperty.Value.ToUniversalTime()));
                                        break;
                                   case DataBaseType.MySql:
                                        _sqlParameterList.Add(new ParameterSql(name, dateTimeProperty.Value.ToUniversalTime().DateSqlParameters(dateTimeProperty.IsIncludeHours, "-")));
                                        break;
                                   default:
                                        _sqlParameterList.Add(new ParameterSql(name, dateTimeProperty.Value.ToUniversalTime().DateSqlParameters(dateTimeProperty.IsIncludeHours)));
                                        break;
                              }
                              break;
                         case PropertyValue<DateTimeOffset>:
                              dateTimeOffsetPropertie = loColumna.Value as PropertyValue<DateTimeOffset>;
                              if (dateTimeOffsetPropertie.IsPrimaryKey)
                                   KeyFields[loColumna.Key] = dateTimeOffsetPropertie.Value;
                              if (dateTimeOffsetPropertie.IsRequiredInDataBase)
                              {
                                   if (dateTimeOffsetPropertie.Value == default)
                                   {
                                        throw new CoreException(Errors.E00000080,$"{dateTimeOffsetPropertie.Description}");
                                   }
                              }
                              _sqlParameterList.Add(new ParameterSql(name, dateTimeOffsetPropertie.Value.ToUniversalTime().DateSqlParameters(dateTimeOffsetPropertie.IsIncludeHours)));
                              break;
                         case PropertyValue<decimal>:
                              decimalProperty = loColumna.Value as PropertyValue<decimal>;
                              if (decimalProperty.IsPrimaryKey)
                                   KeyFields[loColumna.Key] = decimalProperty.Value;
                              _sqlParameterList.Add(new ParameterSql(name, decimalProperty.Value));
                              break;
                         case PropertyValue<float>:
                              singleProperty = loColumna.Value as PropertyValue<float>;
                              if (singleProperty.IsPrimaryKey)
                                   KeyFields[loColumna.Key] = singleProperty.Value;
                              _sqlParameterList.Add(new ParameterSql(name, singleProperty.Value));
                              break;
                         case PropertyValue<double>:
                              doubleProperty = loColumna.Value as PropertyValue<double>;
                              if (doubleProperty.IsPrimaryKey)
                                   KeyFields[loColumna.Key] = doubleProperty.Value;
                              _sqlParameterList.Add(new ParameterSql(name, doubleProperty.Value));
                              break;
                         case PropertyValue<object>:
                              objectProperty = loColumna.Value as PropertyValue<object>;
                              if (objectProperty.IsPrimaryKey)
                                   KeyFields[loColumna.Key] = objectProperty.Value;
                              if (objectProperty.IsRequiredInDataBase)
                              {
                                   if (Equals(objectProperty.Value, null))
                                   {
                                        throw new CoreException(Errors.E00000080,$"{objectProperty.Description}");
                                   }
                              }
                              _sqlParameterList.Add(new ParameterSql(name, objectProperty.Value));
                              break;
                         case PropertyValue<byte[]>:
                              bytesProperty = loColumna.Value as PropertyValue<byte[]>;
                              if (bytesProperty.IsPrimaryKey)
                                   KeyFields[loColumna.Key] = bytesProperty.Value;
                              if (bytesProperty.IsRequiredInDataBase)
                              {
                                   if (Equals(bytesProperty.Value, null))
                                   {
                                        throw new CoreException(Errors.E00000080,$"{bytesProperty.Description}");
                                   }
                              }
                              if (bytesProperty.Value == null)
                                   _sqlParameterList.Add(new ParameterSql(name, global::System.Data.SqlTypes.SqlBinary.Null));//new Byte[] { break;);
                              else
                                   _sqlParameterList.Add(new ParameterSql(name, bytesProperty.Value));
                              break;
                         case PropertyValue<string>:
                              stringProperty = loColumna.Value as PropertyValue<string>;
                              if (stringProperty.IsPrimaryKey)
                              {
                                   if (stringProperty.IsPassword)
                                        throw new CoreException(Errors.E00000082,$"{stringProperty.Description}");
                                   else if (stringProperty.IsEncrypted)
                                        throw new CoreException(Errors.E00000082,$"{stringProperty.Description}");
                                   else
                                        KeyFields[loColumna.Key] = stringProperty.Value;
                              }
                              if (stringProperty.IsRequiredInDataBase)
                              {
                                   //if (String.IsNullOrEmpty(loPropiedadString.Valor))
                                   if (stringProperty.Value == null)
                                   {
                                        //Vamos a considerar que la cadena vacia es un valor permitido
                                        throw new CoreException(Errors.E00000080,$"{stringProperty.Description}");
                                   }
                                   if (stringProperty.Value.Length > stringProperty.Length && stringProperty.Length > -1)
                                   {
                                        throw new CoreException(Errors.E00000081,$"{stringProperty.Description}");
                                   }
                              }

                              if (!string.IsNullOrEmpty(stringProperty.Value) && stringProperty.Value.Length > stringProperty.Length && stringProperty.Length > -1)
                              {
                                   throw new CoreException(Errors.E00000081,$"{stringProperty.Description}");
                              }
                              if (stringProperty.IsPassword)
                              {
                                   stringProperty.Value = Cipher.BCryptHashPassword(stringProperty.Value);
                                   _sqlParameterList.Add(new ParameterSql(name, stringProperty.Value));
                              }
                              else if (stringProperty.IsEncrypted && stringProperty.Value != constMask)
                              {
                                   stringProperty.Value = Cipher.EncryptPEMDataBase(stringProperty.Value);
                                   _sqlParameterList.Add(new ParameterSql(name, stringProperty.Value));
                              }
                              else if (stringProperty.IsGuid)
                              {
                                   _sqlParameterList.Add(new ParameterSql(name, new Guid(stringProperty.Value)));
                              }
                              else
                              {
                                   _sqlParameterList.Add(new ParameterSql(name, stringProperty.Value));
                              }
                              break;
                         case PropertyValue<byte?>:
                              byteNProperty = loColumna.Value as PropertyValue<byte?>;
                              if (byteNProperty.IsPrimaryKey)
                                   KeyFields[loColumna.Key] = byteNProperty.Value;
                              if (byteNProperty.IsRequiredInDataBase)
                              {
                                   if (Equals(byteNProperty.Value, null))
                                   {
                                        throw new CoreException(Errors.E00000080,$"{byteNProperty.Description}");
                                   }
                              }
                              _sqlParameterList.Add(new ParameterSql(name, byteNProperty.Value));
                              break;
                         case PropertyValue<bool?>:
                              boolNProperty = loColumna.Value as PropertyValue<bool?>;
                              if (boolNProperty.IsPrimaryKey)
                                   KeyFields[loColumna.Key] = boolNProperty.Value;
                              if (boolNProperty.IsRequiredInDataBase)
                              {
                                   if (Equals(boolNProperty.Value, null))
                                   {
                                        throw new CoreException(Errors.E00000080,$"{boolNProperty.Description}");
                                   }
                              }
                              _sqlParameterList.Add(new ParameterSql(name, boolNProperty.Value));
                              break;
                         case PropertyValue<short?>:
                              int16NProperty = loColumna.Value as PropertyValue<short?>;
                              if (int16NProperty.IsPrimaryKey)
                                   KeyFields[loColumna.Key] = int16NProperty.Value;
                              if (int16NProperty.IsRequiredInDataBase)
                              {
                                   if (Equals(int16NProperty.Value, null))
                                   {
                                        throw new CoreException(Errors.E00000080,$"{int16NProperty.Description}");
                                   }
                              }
                              _sqlParameterList.Add(new ParameterSql(name, int16NProperty.Value));
                              break;
                         case PropertyValue<int?>:
                              int32NProperty = loColumna.Value as PropertyValue<int?>;
                              if (int32NProperty.IsPrimaryKey)
                                   KeyFields[loColumna.Key] = int32NProperty.Value;
                              if (int32NProperty.IsRequiredInDataBase)
                              {
                                   if (Equals(int32NProperty.Value, null))
                                   {
                                        throw new CoreException(Errors.E00000080,$"{int32NProperty.Description}");
                                   }
                              }
                              _sqlParameterList.Add(new ParameterSql(name, int32NProperty.Value));
                              break;
                         case PropertyValue<long?>:
                              int64NProperty = loColumna.Value as PropertyValue<long?>;
                              if (int64NProperty.IsPrimaryKey)
                                   KeyFields[loColumna.Key] = int64NProperty.Value;
                              if (int64NProperty.IsRequiredInDataBase)
                              {
                                   if (Equals(int64NProperty.Value, null))
                                   {
                                        throw new CoreException(Errors.E00000080,$"{int64NProperty.Description}");
                                   }
                              }
                              _sqlParameterList.Add(new ParameterSql(name, int64NProperty.Value));
                              break;
                         case PropertyValue<DateTime?>:
                              dateTimeNProperty = loColumna.Value as PropertyValue<DateTime?>;
                              if (dateTimeNProperty.IsPrimaryKey)
                                   KeyFields[loColumna.Key] = dateTimeNProperty.Value;
                              if (dateTimeNProperty.IsRequiredInDataBase)
                              {
                                   if (Equals(dateTimeNProperty.Value, null) || Equals(dateTimeNProperty.Value, default(DateTime)))
                                   {
                                        throw new CoreException(Errors.E00000080,$"{dateTimeNProperty.Description}");
                                   }
                              }
                              if (!Equals(dateTimeNProperty.Value, null) && !Equals(dateTimeNProperty.Value, default(DateTime)))
                                   _sqlParameterList.Add(new ParameterSql(name, Convert.ToDateTime(dateTimeNProperty.Value).ToUniversalTime().DateSqlParameters(dateTimeNProperty.IsIncludeHours)));
                              else
                                   _sqlParameterList.Add(new ParameterSql(name, dateTimeNProperty.Value));
                              break;
                         case PropertyValue<DateTimeOffset?>:
                              dateTimeOffsetNPropertie = loColumna.Value as PropertyValue<DateTimeOffset?>;
                              if (dateTimeOffsetNPropertie.IsPrimaryKey)
                                   KeyFields[loColumna.Key] = dateTimeOffsetNPropertie.Value;
                              if (dateTimeOffsetNPropertie.IsRequiredInDataBase)
                              {
                                   if (Equals(dateTimeOffsetNPropertie.Value, null) || Equals(dateTimeOffsetNPropertie.Value, default(DateTime)))
                                   {
                                        throw new CoreException(Errors.E00000080,$"{dateTimeOffsetNPropertie.Description}");
                                   }
                              }
                              if (!Equals(dateTimeOffsetNPropertie.Value, null) && !Equals(dateTimeOffsetNPropertie.Value, default(DateTime)))
                                   _sqlParameterList.Add(new ParameterSql(name, Convert.ToDateTime(dateTimeOffsetNPropertie.Value).ToUniversalTime().DateSqlParameters(dateTimeOffsetNPropertie.IsIncludeHours)));
                              else
                                   _sqlParameterList.Add(new ParameterSql(name, dateTimeOffsetNPropertie.Value));
                              break;
                         case PropertyValue<decimal?>:
                              decimalNProperty = loColumna.Value as PropertyValue<decimal?>;
                              if (decimalNProperty.IsPrimaryKey)
                                   KeyFields[loColumna.Key] = decimalNProperty.Value;
                              if (decimalNProperty.IsRequiredInDataBase)
                              {
                                   if (Equals(decimalNProperty.Value, null))
                                   {
                                        throw new CoreException(Errors.E00000080,$"{decimalNProperty.Description}");
                                   }
                              }
                              _sqlParameterList.Add(new ParameterSql(name, decimalNProperty.Value));
                              break;
                         case PropertyValue<float?>:
                              singleNProperty = loColumna.Value as PropertyValue<float?>;
                              if (singleNProperty.IsPrimaryKey)
                                   KeyFields[loColumna.Key] = singleNProperty.Value;
                              if (singleNProperty.IsRequiredInDataBase)
                              {
                                   if (Equals(singleNProperty.Value, null))
                                   {
                                        throw new CoreException(Errors.E00000080,$"{singleNProperty.Description}");
                                   }
                              }
                              _sqlParameterList.Add(new ParameterSql(name, singleNProperty.Value));
                              break;
                         case PropertyValue<double?>:
                              doubleNProperty = loColumna.Value as PropertyValue<double?>;
                              if (doubleNProperty.IsPrimaryKey)
                                   KeyFields[loColumna.Key] = doubleNProperty.Value;
                              if (doubleNProperty.IsRequiredInDataBase)
                              {
                                   if (Equals(doubleNProperty.Value, null))
                                   {
                                        throw new CoreException(Errors.E00000080,$"{doubleNProperty.Description}");
                                   }
                              }
                              _sqlParameterList.Add(new ParameterSql(name, doubleNProperty.Value));
                              break; ;
                    }
               }
               _existsChanges = true;
               query.AppendFormat("Insert into {0} ({1}) values({2});", TableName(), fields.Remove(fields.Length - 1, 1), values.Remove(values.Length - 1, 1));
               if (_containsIdentityFields)
               {
                    switch (Connection.DataBase.Engine)
                    {

                         case DataBaseType.PostgressSql:
                              foreach (KeyValuePair<string, Property> column in Properties)
                              {
                                   if (!column.Value.IsIdentity)
                                        continue;
                                   query.AppendFormat(" select {0};", Connection.FunctionSCOPEIDENTITY(column.Key));
                                   break;
                              }
                              break;
                         default:
                              query.AppendFormat(" select {0};", Connection.FunctionSCOPEIDENTITY());
                              break;
                    }
               }
               return query;
          }

          private StringBuilder ValidaYArmaConsultaParaInsertParametrosSql2()
          {
               StringBuilder fields;
               StringBuilder values;
               StringBuilder query;
               PropertyValue<byte> byteProperty;
               PropertyValue<short> int16Property;
               PropertyValue<int> int32Property;
               PropertyValue<long> int64Property;
               PropertyValue<double> doubleProperty;
               PropertyValue<float> singleProperty;
               PropertyValue<bool> boolProperty;
               PropertyValue<byte[]> bytesProperty;
               PropertyValue<string> stringProperty;
               PropertyValue<DateTime> dateTimeProperty;
               PropertyValue<DateTimeOffset> dateTimeOffsetProperty;
               PropertyValue<decimal> decimalProperty;
               PropertyValue<object> objectProperty;
               PropertyValue<byte?> byteNProperty;
               PropertyValue<short?> int16NProperty;
               PropertyValue<int?> int32NProperty;
               PropertyValue<long?> int64NProperty;
               PropertyValue<double?> doubleNProperty;
               PropertyValue<float?> singleNProperty;
               PropertyValue<bool?> boolNProperty;
               PropertyValue<DateTime?> dateTimeNProperty;
               PropertyValue<DateTimeOffset?> dateTimeOffsetNProperty;
               PropertyValue<decimal?> decimalNProperty;
               string name;
               query = new StringBuilder();
               fields = new StringBuilder();
               values = new StringBuilder();
               _sqlParameterList = new List<ParameterSql>();
               //liContadorParametros = 0;
               foreach (KeyValuePair<string, Property> column in Properties)
               {
                    if (column.Value.IsIdentity)
                    {
                         //Si es un campo identidad que no lo considere para los inserts
                         continue;
                    }
                    fields.AppendFormat("{0},", FieldNameFix(column.Key));
                    if (column.Key.Contains("%"))
                    {
                         values.AppendFormat("@{0},", column.Key.Replace("%", "_"));
                         name = string.Format("@{0}", column.Key.Replace("%", "_"));
                    }
                    else
                    {
                         values.AppendFormat("@{0},", FieldNameFix(column.Key));
                         name = string.Format("@{0}", column.Key);
                    }
                    //obtener el tipo de datos
                    if (column.Value is PropertyValue<bool>)
                    {
                         boolProperty = column.Value as PropertyValue<bool>;
                         if (boolProperty.IsPrimaryKey)
                              KeyFields[column.Key] = boolProperty.Value;
                         _sqlParameterList.Add(new ParameterSql(name, boolProperty.Value));
                         continue;
                    }
                    if (column.Value is PropertyValue<byte>)
                    {
                         byteProperty = column.Value as PropertyValue<byte>;
                         if (byteProperty.IsPrimaryKey)
                              KeyFields[column.Key] = byteProperty.Value;
                         _sqlParameterList.Add(new ParameterSql(name, byteProperty.Value));
                    }
                    if (column.Value is PropertyValue<short>)
                    {
                         int16Property = column.Value as PropertyValue<short>;
                         if (int16Property.IsPrimaryKey)
                              KeyFields[column.Key] = int16Property.Value;
                         _sqlParameterList.Add(new ParameterSql(name, int16Property.Value));
                    }
                    if (column.Value is PropertyValue<int>)
                    {
                         int32Property = column.Value as PropertyValue<int>;
                         if (int32Property.IsPrimaryKey)
                              KeyFields[column.Key] = int32Property.Value;
                         _sqlParameterList.Add(new ParameterSql(name, int32Property.Value));
                    }
                    if (column.Value is PropertyValue<long>)
                    {
                         int64Property = column.Value as PropertyValue<long>;
                         if (int64Property.IsPrimaryKey)
                              KeyFields[column.Key] = int64Property.Value;
                         _sqlParameterList.Add(new ParameterSql(name, int64Property.Value));
                    }
                    if (column.Value is PropertyValue<DateTime>)
                    {
                         dateTimeProperty = column.Value as PropertyValue<DateTime>;
                         if (dateTimeProperty.IsPrimaryKey)
                              KeyFields[column.Key] = dateTimeProperty.Value;
                         if (dateTimeProperty.IsRequiredInDataBase)
                         {
                              if (dateTimeProperty.Value == default)
                              {
                                   throw new CoreException(Errors.E00000080,$"{dateTimeProperty.Description}");
                              }
                         }
                         _sqlParameterList.Add(new ParameterSql(name, dateTimeProperty.Value.DateSqlParameters(dateTimeProperty.IsIncludeHours)));
                    }
                    if (column.Value is PropertyValue<DateTimeOffset>)
                    {
                         dateTimeOffsetProperty = column.Value as PropertyValue<DateTimeOffset>;
                         if (dateTimeOffsetProperty.IsPrimaryKey)
                              KeyFields[column.Key] = dateTimeOffsetProperty.Value;
                         if (dateTimeOffsetProperty.IsRequiredInDataBase)
                         {
                              if (dateTimeOffsetProperty.Value == default)
                              {
                                   throw new CoreException(Errors.E00000080,$"{dateTimeOffsetProperty.Description}");
                              }
                         }
                         _sqlParameterList.Add(new ParameterSql(name, dateTimeOffsetProperty.Value.DateSqlParameters(dateTimeOffsetProperty.IsIncludeHours)));
                    }
                    if (column.Value is PropertyValue<decimal>)
                    {
                         decimalProperty = column.Value as PropertyValue<decimal>;
                         if (decimalProperty.IsPrimaryKey)
                              KeyFields[column.Key] = decimalProperty.Value;
                         _sqlParameterList.Add(new ParameterSql(name, decimalProperty.Value));
                    }
                    if (column.Value is PropertyValue<float>)
                    {
                         singleProperty = column.Value as PropertyValue<float>;
                         if (singleProperty.IsPrimaryKey)
                              KeyFields[column.Key] = singleProperty.Value;
                         _sqlParameterList.Add(new ParameterSql(name, singleProperty.Value));
                    }
                    if (column.Value is PropertyValue<double>)
                    {
                         doubleProperty = column.Value as PropertyValue<double>;
                         if (doubleProperty.IsPrimaryKey)
                              KeyFields[column.Key] = doubleProperty.Value;
                         _sqlParameterList.Add(new ParameterSql(name, doubleProperty.Value));
                    }
                    if (column.Value is PropertyValue<object>)
                    {
                         objectProperty = column.Value as PropertyValue<object>;
                         if (objectProperty.IsPrimaryKey)
                              KeyFields[column.Key] = objectProperty.Value;
                         if (objectProperty.IsRequiredInDataBase)
                         {
                              if (Equals(objectProperty.Value, null))
                              {
                                   throw new CoreException(Errors.E00000080,$"{objectProperty.Description}");
                              }
                         }
                         _sqlParameterList.Add(new ParameterSql(name, objectProperty.Value));
                    }
                    if (column.Value is PropertyValue<byte[]>)
                    {
                         bytesProperty = column.Value as PropertyValue<byte[]>;
                         if (bytesProperty.IsPrimaryKey)
                              KeyFields[column.Key] = bytesProperty.Value;
                         if (bytesProperty.IsRequiredInDataBase)
                         {
                              if (Equals(bytesProperty.Value, null))
                              {
                                   throw new CoreException(Errors.E00000080,$"{bytesProperty.Description}");
                              }
                         }
                         _sqlParameterList.Add(new ParameterSql(name, bytesProperty.Value));
                    }
                    if (column.Value is PropertyValue<string>)
                    {
                         stringProperty = column.Value as PropertyValue<string>;
                         if (stringProperty.IsPrimaryKey)
                              KeyFields[column.Key] = stringProperty.Value;
                         if (stringProperty.IsRequiredInDataBase)
                         {
                              if (string.IsNullOrEmpty(stringProperty.Value))
                              {
                                   throw new CoreException(Errors.E00000080,$"{stringProperty.Description}");
                              }
                              if (stringProperty.Value.Length > stringProperty.Length && stringProperty.Length > -1)
                              {
                                   throw new CoreException(Errors.E00000081,$"{stringProperty.Description}");
                              }
                         }
                         // Daniel
                         // 20/04/2016
                         // Se hace una validacion del valor cuando es null
                         if (!string.IsNullOrEmpty(stringProperty.Value) && stringProperty.Value.Length > stringProperty.Length && stringProperty.Length > -1)
                         {
                              throw new CoreException(Errors.E00000081,$"{stringProperty.Description}");
                         }
                         _sqlParameterList.Add(new ParameterSql(name, stringProperty.Value));
                    }
                    if (column.Value is PropertyValue<byte?>)
                    {
                         byteNProperty = column.Value as PropertyValue<byte?>;
                         if (byteNProperty.IsPrimaryKey)
                              KeyFields[column.Key] = byteNProperty.Value;
                         if (byteNProperty.IsRequiredInDataBase)
                         {
                              if (Equals(byteNProperty.Value, null))
                              {
                                   throw new CoreException(Errors.E00000080,$"{byteNProperty.Description}");
                              }
                         }
                         _sqlParameterList.Add(new ParameterSql(name, byteNProperty.Value));
                    }
                    if (column.Value is PropertyValue<bool?>)
                    {
                         boolNProperty = column.Value as PropertyValue<bool?>;
                         if (boolNProperty.IsPrimaryKey)
                              KeyFields[column.Key] = boolNProperty.Value;
                         if (boolNProperty.IsRequiredInDataBase)
                         {
                              if (Equals(boolNProperty.Value, null))
                              {
                                   throw new CoreException(Errors.E00000080,$"{boolNProperty.Description}");
                              }
                         }
                         _sqlParameterList.Add(new ParameterSql(name, boolNProperty.Value));
                    }
                    if (column.Value is PropertyValue<short?>)
                    {
                         int16NProperty = column.Value as PropertyValue<short?>;
                         if (int16NProperty.IsPrimaryKey)
                              KeyFields[column.Key] = int16NProperty.Value;
                         if (int16NProperty.IsRequiredInDataBase)
                         {
                              if (Equals(int16NProperty.Value, null))
                              {
                                   throw new CoreException(Errors.E00000080,$"{int16NProperty.Description}");
                              }
                         }
                         _sqlParameterList.Add(new ParameterSql(name, int16NProperty.Value));
                    }
                    if (column.Value is PropertyValue<int?>)
                    {
                         int32NProperty = column.Value as PropertyValue<int?>;
                         if (int32NProperty.IsPrimaryKey)
                              KeyFields[column.Key] = int32NProperty.Value;
                         if (int32NProperty.IsRequiredInDataBase)
                         {
                              if (Equals(int32NProperty.Value, null))
                              {
                                   throw new CoreException(Errors.E00000080,$"{int32NProperty.Description}");
                              }
                         }
                         _sqlParameterList.Add(new ParameterSql(name, int32NProperty.Value));
                    }
                    if (column.Value is PropertyValue<long?>)
                    {
                         int64NProperty = column.Value as PropertyValue<long?>;
                         if (int64NProperty.IsPrimaryKey)
                              KeyFields[column.Key] = int64NProperty.Value;
                         if (int64NProperty.IsRequiredInDataBase)
                         {
                              if (Equals(int64NProperty.Value, null))
                              {
                                   throw new CoreException(Errors.E00000080,$"{int64NProperty.Description}");
                              }
                         }
                         _sqlParameterList.Add(new ParameterSql(name, int64NProperty.Value));
                    }
                    if (column.Value is PropertyValue<DateTime?>)
                    {
                         dateTimeNProperty = column.Value as PropertyValue<DateTime?>;
                         if (dateTimeNProperty.IsPrimaryKey)
                              KeyFields[column.Key] = dateTimeNProperty.Value;
                         if (dateTimeNProperty.IsRequiredInDataBase)
                         {
                              if (Equals(dateTimeNProperty.Value, null) || Equals(dateTimeNProperty.Value, default(DateTime)))
                              {
                                   throw new CoreException(Errors.E00000080,$"{dateTimeNProperty.Description}");
                              }
                         }
                         if (!Equals(dateTimeNProperty.Value, null) && !Equals(dateTimeNProperty.Value, default(DateTime)))
                              _sqlParameterList.Add(new ParameterSql(name, Convert.ToDateTime(dateTimeNProperty.Value).DateSqlParameters(dateTimeNProperty.IsIncludeHours)));
                         else
                              _sqlParameterList.Add(new ParameterSql(name, dateTimeNProperty.Value));
                    }
                    if (column.Value is PropertyValue<DateTimeOffset?>)
                    {
                         dateTimeOffsetNProperty = column.Value as PropertyValue<DateTimeOffset?>;
                         if (dateTimeOffsetNProperty.IsPrimaryKey)
                              KeyFields[column.Key] = dateTimeOffsetNProperty.Value;
                         if (dateTimeOffsetNProperty.IsRequiredInDataBase)
                         {
                              if (Equals(dateTimeOffsetNProperty.Value, null) || Equals(dateTimeOffsetNProperty.Value, default(DateTime)))
                              {
                                   throw new CoreException(Errors.E00000080,$"{dateTimeOffsetNProperty.Description}");
                              }
                         }
                         if (!Equals(dateTimeOffsetNProperty.Value, null) && !Equals(dateTimeOffsetNProperty.Value, default(DateTime)))
                              _sqlParameterList.Add(new ParameterSql(name, Convert.ToDateTime(dateTimeOffsetNProperty.Value).DateSqlParameters(dateTimeOffsetNProperty.IsIncludeHours)));
                         else
                              _sqlParameterList.Add(new ParameterSql(name, dateTimeOffsetNProperty.Value));
                    }
                    if (column.Value is PropertyValue<decimal?>)
                    {
                         decimalNProperty = column.Value as PropertyValue<decimal?>;
                         if (decimalNProperty.IsPrimaryKey)
                              KeyFields[column.Key] = decimalNProperty.Value;
                         if (decimalNProperty.IsRequiredInDataBase)
                         {
                              if (Equals(decimalNProperty.Value, null))
                              {
                                   throw new CoreException(Errors.E00000080,$"{decimalNProperty.Description}");
                              }
                         }
                         _sqlParameterList.Add(new ParameterSql(name, decimalNProperty.Value));
                    }
                    if (column.Value is PropertyValue<float?>)
                    {
                         singleNProperty = column.Value as PropertyValue<float?>;
                         if (singleNProperty.IsPrimaryKey)
                              KeyFields[column.Key] = singleNProperty.Value;
                         if (singleNProperty.IsRequiredInDataBase)
                         {
                              if (Equals(singleNProperty.Value, null))
                              {
                                   throw new CoreException(Errors.E00000080,$"{singleNProperty.Description}");
                              }
                         }
                         _sqlParameterList.Add(new ParameterSql(name, singleNProperty.Value));
                    }
                    if (column.Value is PropertyValue<double?>)
                    {
                         doubleNProperty = column.Value as PropertyValue<double?>;
                         if (doubleNProperty.IsPrimaryKey)
                              KeyFields[column.Key] = doubleNProperty.Value;
                         if (doubleNProperty.IsRequiredInDataBase)
                         {
                              if (Equals(doubleNProperty.Value, null))
                              {
                                   throw new CoreException(Errors.E00000080,$"{doubleNProperty.Description}");
                              }
                         }
                         _sqlParameterList.Add(new ParameterSql(name, doubleNProperty.Value));
                    }
               }
               _existsChanges = true;
               query.AppendFormat("Insert into {0} ({1}) values({2});", TableName(), fields.Remove(fields.Length - 1, 1), values.Remove(values.Length - 1, 1));
               return query;
          }

          protected bool ExistsChangeInProperty(string name)
          {
               int modifiedFields;
               PropertyValue<byte> byteProperty;
               PropertyValue<short> int16Property;
               PropertyValue<int> int32Property;
               PropertyValue<long> int64Property;
               PropertyValue<double> doubleProperty;
               PropertyValue<string> stringPropiedadString;
               PropertyValue<float> singleProperty;
               PropertyValue<bool> boolProperty;
               PropertyValue<byte[]> bytesProperty;
               PropertyValue<DateTime> dataTimeProperty;
               PropertyValue<decimal> decimalProperty;
               PropertyValue<object> objectProperty;
               PropertyValue<byte?> byteNProperty;
               PropertyValue<short?> int16NProperty;
               PropertyValue<int?> int32NProperty;
               PropertyValue<long?> int64NProperty;
               PropertyValue<double?> doubleNProperty;
               PropertyValue<float?> singleNProperty;
               PropertyValue<bool?> boolNProperty;
               PropertyValue<DateTime?> dateTimeNProperty;
               PropertyValue<decimal?> decimalNProperty;
               modifiedFields = 0;

               foreach (KeyValuePair<string, Property> column in Properties)
               {
                    if (!string.Equals(column.Key, name, StringComparison.OrdinalIgnoreCase))
                         continue;
                    new Switch(column.Value)
                    .Case<PropertyValue<bool>>(_ =>
                    {
                         boolProperty = column.Value as PropertyValue<bool>;
                         if (!Equals(boolProperty.Value, boolProperty.OldValue))
                         {
                              modifiedFields++;
                         }
                    })
                    .Case<PropertyValue<byte>>(_ =>
                    {
                         byteProperty = column.Value as PropertyValue<byte>;
                         if (!Equals(byteProperty.Value, byteProperty.OldValue))
                         {
                              modifiedFields++;
                         }
                    })
                    .Case<PropertyValue<short>>(_ =>
                    {
                         int16Property = column.Value as PropertyValue<short>;
                         if (!Equals(int16Property.Value, int16Property.OldValue))
                         {
                              modifiedFields++;
                         }
                    })
                    .Case<PropertyValue<int>>(_ =>
                    {
                         int32Property = column.Value as PropertyValue<int>;
                         if (!Equals(int32Property.Value, int32Property.OldValue))
                         {
                              modifiedFields++;
                         }
                    })
                    .Case<PropertyValue<long>>(_ =>
                    {
                         int64Property = column.Value as PropertyValue<long>;
                         if (!Equals(int64Property.Value, int64Property.OldValue))
                         {
                              modifiedFields++;
                         }
                    })
                    .Case<PropertyValue<DateTime>>(_ =>
                    {
                         dataTimeProperty = column.Value as PropertyValue<DateTime>;
                         if (!Equals(dataTimeProperty.Value, dataTimeProperty.OldValue))
                         {
                              modifiedFields++;
                         }
                    })
                    .Case<PropertyValue<decimal>>(_ =>
                    {
                         decimalProperty = column.Value as PropertyValue<decimal>;
                         if (!Equals(decimalProperty.Value, decimalProperty.OldValue))
                         {
                              modifiedFields++;
                         }
                    })
                    .Case<PropertyValue<float>>(_ =>
                    {
                         singleProperty = column.Value as PropertyValue<float>;
                         if (!Equals(singleProperty.Value, singleProperty.OldValue))
                         {
                              modifiedFields++;
                         }
                    })
                    .Case<PropertyValue<double>>(_ =>
                    {
                         doubleProperty = column.Value as PropertyValue<double>;
                         if (!Equals(doubleProperty.Value, doubleProperty.OldValue))
                         {
                              modifiedFields++;
                         }
                    })
                    .Case<PropertyValue<object>>(_ =>
                    {
                         objectProperty = column.Value as PropertyValue<object>;
                         if (!Equals(objectProperty.Value, objectProperty.OldValue))
                         {
                              modifiedFields++;
                         }
                    })
                    .Case<PropertyValue<byte[]>>(_ =>
                    {
                         bytesProperty = column.Value as PropertyValue<byte[]>;
                         if (!Equals(bytesProperty.Value, bytesProperty.OldValue))
                         {
                              modifiedFields++;
                         }
                    })
                    .Case<PropertyValue<string>>(_ =>
                    {
                         stringPropiedadString = column.Value as PropertyValue<string>;
                         if (!Equals(stringPropiedadString.Value, stringPropiedadString.OldValue))
                         {
                              modifiedFields++;
                         }
                    })
                    .Case<PropertyValue<byte?>>(_ =>
                    {
                         byteNProperty = column.Value as PropertyValue<byte?>;
                         if (!Equals(byteNProperty.Value, byteNProperty.OldValue))
                         {
                              modifiedFields++;
                         }
                    })
                    .Case<PropertyValue<bool?>>(_ =>
                    {
                         boolNProperty = column.Value as PropertyValue<bool?>;
                         if (!Equals(boolNProperty.Value, boolNProperty.OldValue))
                         {
                              modifiedFields++;
                         }
                    })
                    .Case<PropertyValue<short?>>(_ =>
                    {
                         int16NProperty = column.Value as PropertyValue<short?>;
                         if (!Equals(int16NProperty.Value, int16NProperty.OldValue))
                         {
                              modifiedFields++;
                         }
                    })
                    .Case<PropertyValue<int?>>(_ =>
                    {
                         int32NProperty = column.Value as PropertyValue<int?>;
                         if (!Equals(int32NProperty.Value, int32NProperty.OldValue))
                         {
                              modifiedFields++;
                         }
                    })
                    .Case<PropertyValue<long?>>(_ =>
                    {
                         int64NProperty = column.Value as PropertyValue<long?>;
                         if (!Equals(int64NProperty.Value, int64NProperty.OldValue))
                         {
                              modifiedFields++;
                         }
                    })
                    .Case<PropertyValue<DateTime?>>(_ =>
                    {
                         dateTimeNProperty = column.Value as PropertyValue<DateTime?>;
                         if (!Equals(dateTimeNProperty.Value, dateTimeNProperty.OldValue))
                         {
                              modifiedFields++;
                         }
                    })

                    .Case<PropertyValue<decimal?>>(_ =>
                    {
                         decimalNProperty = column.Value as PropertyValue<decimal?>;
                         if (!Equals(decimalNProperty.Value, decimalNProperty.OldValue))
                         {
                              modifiedFields++;
                         }
                    })
                    .Case<PropertyValue<float?>>(_ =>
                    {
                         singleNProperty = column.Value as PropertyValue<float?>;
                         if (!Equals(singleNProperty.Value, singleNProperty.OldValue))
                         {
                              modifiedFields++;
                         }
                    })
                    .Case<PropertyValue<double?>>(_ =>
                    {
                         doubleNProperty = column.Value as PropertyValue<double?>;
                         if (!Equals(doubleNProperty.Value, doubleNProperty.OldValue))
                         {
                              modifiedFields++;
                         }
                    });
               }
               return modifiedFields > 0;
          }
          protected int VerifyThatChangeInFieldsExists(bool isFieldVirtual)
          {
               int modifiedFields;
               PropertyValue<byte> byteProperty;
               PropertyValue<short> int16Property;
               PropertyValue<int> int32Property;
               PropertyValue<long> int64Property;
               PropertyValue<double> doubleProperty;
               PropertyValue<string> stringPropiedadString;
               PropertyValue<float> singleProperty;
               PropertyValue<bool> boolProperty;
               PropertyValue<byte[]> bytesProperty;
               PropertyValue<DateTime> dataTimeProperty;
               PropertyValue<decimal> decimalProperty;
               PropertyValue<object> objectProperty;
               PropertyValue<byte?> byteNProperty;
               PropertyValue<short?> int16NProperty;
               PropertyValue<int?> int32NProperty;
               PropertyValue<long?> int64NProperty;
               PropertyValue<double?> doubleNProperty;
               PropertyValue<float?> singleNProperty;
               PropertyValue<bool?> boolNProperty;
               PropertyValue<DateTime?> dateTimeNProperty;
               PropertyValue<decimal?> decimalNProperty;
               modifiedFields = 0;
               ModifiedFields = new HashSet<string>();
               foreach (KeyValuePair<string, Property> column in Properties)
               {
                    if (column.Value.IsVirtualField != isFieldVirtual)
                         continue;
                    switch (column.Value)
                    {
                         case PropertyValue<bool>:

                              boolProperty = column.Value as PropertyValue<bool>;
                              if (!Equals(boolProperty.Value, boolProperty.OldValue))
                              {
                                   ModifiedFields.Add(column.Key);
                                   modifiedFields++;
                              }
                              break;
                         case PropertyValue<byte>:

                              byteProperty = column.Value as PropertyValue<byte>;
                              if (!Equals(byteProperty.Value, byteProperty.OldValue))
                              {
                                   ModifiedFields.Add(column.Key);
                                   modifiedFields++;
                              }
                              break;
                         case PropertyValue<short>:

                              int16Property = column.Value as PropertyValue<short>;
                              if (!Equals(int16Property.Value, int16Property.OldValue))
                              {
                                   ModifiedFields.Add(column.Key);
                                   modifiedFields++;
                              }
                              break;
                         case PropertyValue<int>:

                              int32Property = column.Value as PropertyValue<int>;
                              if (!Equals(int32Property.Value, int32Property.OldValue))
                              {
                                   ModifiedFields.Add(column.Key);
                                   modifiedFields++;
                              }
                              break;
                         case PropertyValue<long>:

                              int64Property = column.Value as PropertyValue<long>;
                              if (!Equals(int64Property.Value, int64Property.OldValue))
                              {
                                   ModifiedFields.Add(column.Key);
                                   modifiedFields++;
                              }
                              break;
                         case PropertyValue<DateTime>:

                              dataTimeProperty = column.Value as PropertyValue<DateTime>;
                              if (!Equals(dataTimeProperty.Value, dataTimeProperty.OldValue))
                              {
                                   ModifiedFields.Add(column.Key);
                                   modifiedFields++;
                              }
                              break;
                         case PropertyValue<decimal>:

                              decimalProperty = column.Value as PropertyValue<decimal>;
                              if (!Equals(decimalProperty.Value, decimalProperty.OldValue))
                              {
                                   ModifiedFields.Add(column.Key);
                                   modifiedFields++;
                              }
                              break;
                         case PropertyValue<float>:

                              singleProperty = column.Value as PropertyValue<float>;
                              if (!Equals(singleProperty.Value, singleProperty.OldValue))
                              {
                                   ModifiedFields.Add(column.Key);
                                   modifiedFields++;
                              }
                              break;
                         case PropertyValue<double>:

                              doubleProperty = column.Value as PropertyValue<double>;
                              if (!Equals(doubleProperty.Value, doubleProperty.OldValue))
                              {
                                   ModifiedFields.Add(column.Key);
                                   modifiedFields++;
                              }
                              break;
                         case PropertyValue<object>:

                              objectProperty = column.Value as PropertyValue<object>;
                              if (!Equals(objectProperty.Value, objectProperty.OldValue))
                              {
                                   ModifiedFields.Add(column.Key);
                                   modifiedFields++;
                              }
                              break;
                         case PropertyValue<byte[]>:

                              bytesProperty = column.Value as PropertyValue<byte[]>;
                              if (!Equals(bytesProperty.Value, bytesProperty.OldValue))
                              {
                                   ModifiedFields.Add(column.Key);
                                   modifiedFields++;
                              }
                              break;
                         case PropertyValue<string>:

                              stringPropiedadString = column.Value as PropertyValue<string>;
                              if (!Equals(stringPropiedadString.Value, stringPropiedadString.OldValue))
                              {
                                   ModifiedFields.Add(column.Key);
                                   modifiedFields++;
                              }
                              break;
                         case PropertyValue<byte?>:

                              byteNProperty = column.Value as PropertyValue<byte?>;
                              if (!Equals(byteNProperty.Value, byteNProperty.OldValue))
                              {
                                   ModifiedFields.Add(column.Key);
                                   modifiedFields++;
                              }
                              break;
                         case PropertyValue<bool?>:

                              boolNProperty = column.Value as PropertyValue<bool?>;
                              if (!Equals(boolNProperty.Value, boolNProperty.OldValue))
                              {
                                   ModifiedFields.Add(column.Key);
                                   modifiedFields++;
                              }
                              break;
                         case PropertyValue<short?>:

                              int16NProperty = column.Value as PropertyValue<short?>;
                              if (!Equals(int16NProperty.Value, int16NProperty.OldValue))
                              {
                                   ModifiedFields.Add(column.Key);
                                   modifiedFields++;
                              }
                              break;
                         case PropertyValue<int?>:

                              int32NProperty = column.Value as PropertyValue<int?>;
                              if (!Equals(int32NProperty.Value, int32NProperty.OldValue))
                              {
                                   ModifiedFields.Add(column.Key);
                                   modifiedFields++;
                              }
                              break;
                         case PropertyValue<long?>:

                              int64NProperty = column.Value as PropertyValue<long?>;
                              if (!Equals(int64NProperty.Value, int64NProperty.OldValue))
                              {
                                   ModifiedFields.Add(column.Key);
                                   modifiedFields++;
                              }
                              break;
                         case PropertyValue<DateTime?>:

                              dateTimeNProperty = column.Value as PropertyValue<DateTime?>;
                              if (!Equals(dateTimeNProperty.Value, dateTimeNProperty.OldValue))
                              {
                                   ModifiedFields.Add(column.Key);
                                   modifiedFields++;
                              }
                              break;

                         case PropertyValue<decimal?>:

                              decimalNProperty = column.Value as PropertyValue<decimal?>;
                              if (!Equals(decimalNProperty.Value, decimalNProperty.OldValue))
                              {
                                   ModifiedFields.Add(column.Key);
                                   modifiedFields++;
                              }
                              break;
                         case PropertyValue<float?>:

                              singleNProperty = column.Value as PropertyValue<float?>;
                              if (!Equals(singleNProperty.Value, singleNProperty.OldValue))
                              {
                                   ModifiedFields.Add(column.Key);
                                   modifiedFields++;
                              }
                              break;
                         case PropertyValue<double?>:

                              doubleNProperty = column.Value as PropertyValue<double?>;
                              if (!Equals(doubleNProperty.Value, doubleNProperty.OldValue))
                              {
                                   ModifiedFields.Add(column.Key);
                                   modifiedFields++;
                              }
                              break; ;
                    }
                    
               }
               return modifiedFields;
          }

          /// <summary>
          /// Funcion que verifica si existen cambios en la fila del catalogo
          /// </summary>
          protected int VerifyThatChangeInFieldsExists2(bool isFieldVirtual)
          {
               int modifiedFields;
               PropertyValue<byte> byteProperty;
               PropertyValue<short> int16Property;
               PropertyValue<int> int32Property;
               PropertyValue<long> int64Property;
               PropertyValue<double> doubleProperty;
               PropertyValue<string> stringPropiedadString;
               PropertyValue<float> singleProperty;
               PropertyValue<bool> boolProperty;
               PropertyValue<byte[]> bytesProperty;
               PropertyValue<DateTime> dataTimeProperty;
               PropertyValue<decimal> decimalProperty;
               PropertyValue<object> objectProperty;
               PropertyValue<byte?> byteNProperty;
               PropertyValue<short?> int16NProperty;
               PropertyValue<int?> int32NProperty;
               PropertyValue<long?> int64NProperty;
               PropertyValue<double?> doubleNProperty;
               PropertyValue<float?> singleNProperty;
               PropertyValue<bool?> boolNProperty;
               PropertyValue<DateTime?> dateTimeNProperty;
               PropertyValue<decimal?> decimalNProperty;
               modifiedFields = 0;
               ModifiedFields = new HashSet<string>();
               foreach (KeyValuePair<string, Property> column in Properties)
               {
                    if (column.Value.IsVirtualField != isFieldVirtual)
                         continue;
                    new Switch(column.Value)
                    .Case<PropertyValue<bool>>(_ =>
                    {
                         boolProperty = column.Value as PropertyValue<bool>;
                         if (!Equals(boolProperty.Value, boolProperty.OldValue))
                         {
                              ModifiedFields.Add(column.Key);
                              modifiedFields++;
                         }
                    })
                    .Case<PropertyValue<byte>>(_ =>
                    {
                         byteProperty = column.Value as PropertyValue<byte>;
                         if (!Equals(byteProperty.Value, byteProperty.OldValue))
                         {
                              ModifiedFields.Add(column.Key);
                              modifiedFields++;
                         }
                    })
                    .Case<PropertyValue<short>>(_ =>
                    {
                         int16Property = column.Value as PropertyValue<short>;
                         if (!Equals(int16Property.Value, int16Property.OldValue))
                         {
                              ModifiedFields.Add(column.Key);
                              modifiedFields++;
                         }
                    })
                    .Case<PropertyValue<int>>(_ =>
                    {
                         int32Property = column.Value as PropertyValue<int>;
                         if (!Equals(int32Property.Value, int32Property.OldValue))
                         {
                              ModifiedFields.Add(column.Key);
                              modifiedFields++;
                         }
                    })
                    .Case<PropertyValue<long>>(_ =>
                    {
                         int64Property = column.Value as PropertyValue<long>;
                         if (!Equals(int64Property.Value, int64Property.OldValue))
                         {
                              ModifiedFields.Add(column.Key);
                              modifiedFields++;
                         }
                    })
                    .Case<PropertyValue<DateTime>>(_ =>
                    {
                         dataTimeProperty = column.Value as PropertyValue<DateTime>;
                         if (!Equals(dataTimeProperty.Value, dataTimeProperty.OldValue))
                         {
                              ModifiedFields.Add(column.Key);
                              modifiedFields++;
                         }
                    })
                    .Case<PropertyValue<decimal>>(_ =>
                    {
                         decimalProperty = column.Value as PropertyValue<decimal>;
                         if (!Equals(decimalProperty.Value, decimalProperty.OldValue))
                         {
                              ModifiedFields.Add(column.Key);
                              modifiedFields++;
                         }
                    })
                    .Case<PropertyValue<float>>(_ =>
                    {
                         singleProperty = column.Value as PropertyValue<float>;
                         if (!Equals(singleProperty.Value, singleProperty.OldValue))
                         {
                              ModifiedFields.Add(column.Key);
                              modifiedFields++;
                         }
                    })
                    .Case<PropertyValue<double>>(_ =>
                    {
                         doubleProperty = column.Value as PropertyValue<double>;
                         if (!Equals(doubleProperty.Value, doubleProperty.OldValue))
                         {
                              ModifiedFields.Add(column.Key);
                              modifiedFields++;
                         }
                    })
                    .Case<PropertyValue<object>>(_ =>
                    {
                         objectProperty = column.Value as PropertyValue<object>;
                         if (!Equals(objectProperty.Value, objectProperty.OldValue))
                         {
                              ModifiedFields.Add(column.Key);
                              modifiedFields++;
                         }
                    })
                    .Case<PropertyValue<byte[]>>(_ =>
                    {
                         bytesProperty = column.Value as PropertyValue<byte[]>;
                         if (!Equals(bytesProperty.Value, bytesProperty.OldValue))
                         {
                              ModifiedFields.Add(column.Key);
                              modifiedFields++;
                         }
                    })
                    .Case<PropertyValue<string>>(_ =>
                    {
                         stringPropiedadString = column.Value as PropertyValue<string>;
                         if (!Equals(stringPropiedadString.Value, stringPropiedadString.OldValue))
                         {
                              ModifiedFields.Add(column.Key);
                              modifiedFields++;
                         }
                    })
                    .Case<PropertyValue<byte?>>(_ =>
                    {
                         byteNProperty = column.Value as PropertyValue<byte?>;
                         if (!Equals(byteNProperty.Value, byteNProperty.OldValue))
                         {
                              ModifiedFields.Add(column.Key);
                              modifiedFields++;
                         }
                    })
                    .Case<PropertyValue<bool?>>(_ =>
                    {
                         boolNProperty = column.Value as PropertyValue<bool?>;
                         if (!Equals(boolNProperty.Value, boolNProperty.OldValue))
                         {
                              ModifiedFields.Add(column.Key);
                              modifiedFields++;
                         }
                    })
                    .Case<PropertyValue<short?>>(_ =>
                    {
                         int16NProperty = column.Value as PropertyValue<short?>;
                         if (!Equals(int16NProperty.Value, int16NProperty.OldValue))
                         {
                              ModifiedFields.Add(column.Key);
                              modifiedFields++;
                         }
                    })
                    .Case<PropertyValue<int?>>(_ =>
                    {
                         int32NProperty = column.Value as PropertyValue<int?>;
                         if (!Equals(int32NProperty.Value, int32NProperty.OldValue))
                         {
                              ModifiedFields.Add(column.Key);
                              modifiedFields++;
                         }
                    })
                    .Case<PropertyValue<long?>>(_ =>
                    {
                         int64NProperty = column.Value as PropertyValue<long?>;
                         if (!Equals(int64NProperty.Value, int64NProperty.OldValue))
                         {
                              ModifiedFields.Add(column.Key);
                              modifiedFields++;
                         }
                    })
                    .Case<PropertyValue<DateTime?>>(_ =>
                    {
                         dateTimeNProperty = column.Value as PropertyValue<DateTime?>;
                         if (!Equals(dateTimeNProperty.Value, dateTimeNProperty.OldValue))
                         {
                              ModifiedFields.Add(column.Key);
                              modifiedFields++;
                         }
                    })

                    .Case<PropertyValue<decimal?>>(_ =>
                    {
                         decimalNProperty = column.Value as PropertyValue<decimal?>;
                         if (!Equals(decimalNProperty.Value, decimalNProperty.OldValue))
                         {
                              ModifiedFields.Add(column.Key);
                              modifiedFields++;
                         }
                    })
                    .Case<PropertyValue<float?>>(_ =>
                    {
                         singleNProperty = column.Value as PropertyValue<float?>;
                         if (!Equals(singleNProperty.Value, singleNProperty.OldValue))
                         {
                              ModifiedFields.Add(column.Key);
                              modifiedFields++;
                         }
                    })
                    .Case<PropertyValue<double?>>(_ =>
                    {
                         doubleNProperty = column.Value as PropertyValue<double?>;
                         if (!Equals(doubleNProperty.Value, doubleNProperty.OldValue))
                         {
                              ModifiedFields.Add(column.Key);
                              modifiedFields++;
                         }
                    });
               }
               return modifiedFields;
          }

          /// <summary>
          /// Funcion que verifica si existen cambios en la fila del catalogo
          /// </summary>
          protected int VerificaQueExistaCambioEnCampos2()
          {
               int modifiedFields;
               PropertyValue<byte> byteProperty;
               PropertyValue<short> int16Property;
               PropertyValue<int> int32Property;
               PropertyValue<long> int64Property;
               PropertyValue<double> doubleProperty;
               PropertyValue<float> singleProperty;
               PropertyValue<bool> boolProperty;
               PropertyValue<byte[]> bytesProperty;
               PropertyValue<string> loPropiedadString;
               PropertyValue<DateTime> dateTimeProperty;
               PropertyValue<decimal> decimalProperty;
               PropertyValue<object> objectProperty;
               PropertyValue<byte?> byteNProperty;
               PropertyValue<short?> int16NProperty;
               PropertyValue<int?> int32NProperty;
               PropertyValue<long?> int64NProperty;
               PropertyValue<double?> doubleNProperty;
               PropertyValue<float?> singleNProperty;
               PropertyValue<bool?> boolNProperty;
               PropertyValue<DateTime?> dateTimeNProperty;
               PropertyValue<decimal?> decimalNProperty;
               modifiedFields = 0;
               foreach (KeyValuePair<string, Property> column in Properties)
               {
                    if (column.Value.IsVirtualField)
                         continue;
                    if (column.Value is PropertyValue<bool>)
                    {
                         boolProperty = column.Value as PropertyValue<bool>;
                         if (!Equals(boolProperty.Value, boolProperty.OldValue))
                         {
                              modifiedFields++;
                         }
                    }
                    if (column.Value is PropertyValue<byte>)
                    {
                         byteProperty = column.Value as PropertyValue<byte>;
                         if (!Equals(byteProperty.Value, byteProperty.OldValue))
                         {
                              modifiedFields++;
                         }
                    }
                    if (column.Value is PropertyValue<short>)
                    {
                         int16Property = column.Value as PropertyValue<short>;
                         if (!Equals(int16Property.Value, int16Property.OldValue))
                         {
                              modifiedFields++;
                         }
                    }
                    if (column.Value is PropertyValue<int>)
                    {
                         int32Property = column.Value as PropertyValue<int>;
                         if (!Equals(int32Property.Value, int32Property.OldValue))
                         {
                              modifiedFields++;
                         }
                    }
                    if (column.Value is PropertyValue<long>)
                    {
                         int64Property = column.Value as PropertyValue<long>;
                         if (!Equals(int64Property.Value, int64Property.OldValue))
                         {
                              modifiedFields++;
                         }
                    }
                    if (column.Value is PropertyValue<DateTime>)
                    {
                         dateTimeProperty = column.Value as PropertyValue<DateTime>;
                         if (!Equals(dateTimeProperty.Value, dateTimeProperty.OldValue))
                         {
                              modifiedFields++;
                         }
                    }
                    if (column.Value is PropertyValue<decimal>)
                    {
                         decimalProperty = column.Value as PropertyValue<decimal>;
                         if (!Equals(decimalProperty.Value, decimalProperty.OldValue))
                         {
                              modifiedFields++;
                         }
                    }
                    if (column.Value is PropertyValue<float>)
                    {
                         singleProperty = column.Value as PropertyValue<float>;
                         if (!Equals(singleProperty.Value, singleProperty.OldValue))
                         {
                              modifiedFields++;
                         }
                    }
                    if (column.Value is PropertyValue<double>)
                    {
                         doubleProperty = column.Value as PropertyValue<double>;
                         if (!Equals(doubleProperty.Value, doubleProperty.OldValue))
                         {
                              modifiedFields++;
                         }
                    }
                    if (column.Value is PropertyValue<object>)
                    {
                         objectProperty = column.Value as PropertyValue<object>;
                         if (!Equals(objectProperty.Value, objectProperty.OldValue))
                         {
                              modifiedFields++;
                         }
                    }
                    if (column.Value is PropertyValue<byte[]>)
                    {
                         bytesProperty = column.Value as PropertyValue<byte[]>;
                         if (!Equals(bytesProperty.Value, bytesProperty.OldValue))
                         {
                              modifiedFields++;
                         }
                    }
                    if (column.Value is PropertyValue<string>)
                    {
                         loPropiedadString = column.Value as PropertyValue<string>;
                         if (!Equals(loPropiedadString.Value, loPropiedadString.OldValue))
                         {
                              modifiedFields++;
                         }
                    }
                    if (column.Value is PropertyValue<byte?>)
                    {
                         byteNProperty = column.Value as PropertyValue<byte?>;
                         if (!Equals(byteNProperty.Value, byteNProperty.OldValue))
                         {
                              modifiedFields++;
                         }
                    }
                    if (column.Value is PropertyValue<bool?>)
                    {
                         boolNProperty = column.Value as PropertyValue<bool?>;
                         if (!Equals(boolNProperty.Value, boolNProperty.OldValue))
                         {
                              modifiedFields++;
                         }
                    }
                    if (column.Value is PropertyValue<short?>)
                    {
                         int16NProperty = column.Value as PropertyValue<short?>;
                         if (!Equals(int16NProperty.Value, int16NProperty.OldValue))
                         {
                              modifiedFields++;
                         }
                    }
                    if (column.Value is PropertyValue<int?>)
                    {
                         int32NProperty = column.Value as PropertyValue<int?>;
                         if (!Equals(int32NProperty.Value, int32NProperty.OldValue))
                         {
                              modifiedFields++;
                         }
                    }
                    if (column.Value is PropertyValue<long?>)
                    {
                         int64NProperty = column.Value as PropertyValue<long?>;
                         if (!Equals(int64NProperty.Value, int64NProperty.OldValue))
                         {
                              modifiedFields++;
                         }
                    }
                    if (column.Value is PropertyValue<DateTime?>)
                    {
                         dateTimeNProperty = column.Value as PropertyValue<DateTime?>;
                         if (!Equals(dateTimeNProperty.Value, dateTimeNProperty.OldValue))
                         {
                              modifiedFields++;
                         }
                    }
                    if (column.Value is PropertyValue<decimal?>)
                    {
                         decimalNProperty = column.Value as PropertyValue<decimal?>;
                         if (!Equals(decimalNProperty.Value, decimalNProperty.OldValue))
                         {
                              modifiedFields++;
                         }
                    }
                    if (column.Value is PropertyValue<float?>)
                    {
                         singleNProperty = column.Value as PropertyValue<float?>;
                         if (!Equals(singleNProperty.Value, singleNProperty.OldValue))
                         {
                              modifiedFields++;
                         }
                    }
                    if (column.Value is PropertyValue<double?>)
                    {
                         doubleNProperty = column.Value as PropertyValue<double?>;
                         if (!Equals(doubleNProperty.Value, doubleNProperty.OldValue))
                         {
                              modifiedFields++;
                         }
                    }
               }
               return modifiedFields;
          }

          /// <summary>
          /// Funcion que deterina si existe cambio en los campos
          /// </summary>
          /// <returns></returns>
          public bool ChangessInFields()
          {
               return VerifyThatChangeInFieldsExists(false) > 0;
          }
          public bool ChangessInVirtualFields()
          {
               return VerifyThatChangeInFieldsExists(true) > 0;
          }
          #endregion Internal Metodos for validations

          #region General methods for catalogs

          /// <summary>
          /// Funcion que regresa los campos llave seprados por comas
          /// </summary>
          /// <returns></returns>
          public string GetKeyFieldsCommaSeparated()
          {
               StringBuilder query;
               query = new StringBuilder();

               foreach (KeyValuePair<string, object> keyField in KeyFields)
               {
                    query.AppendFormat("{0},", FieldNameFix(keyField.Key));
               }
               query.Remove(query.Length - 1, 1);

               return query.ToString();
          }

          /// <summary>
          /// Regresas the lista campos.
          /// </summary>
          /// <returns></returns>
          public List<string> GetFieldsList()
          {
               List<string> fields;
               fields = new List<string>();
               foreach (KeyValuePair<string, Property> column in Properties)
               {
                    if (column.Value.IsVirtualField)
                         continue;
                    fields.Add(column.Key);
               }
               return fields;
          }

          /// <summary>
          /// Armas the filtro campos l lave datos cargados.
          /// </summary>
          /// <returns></returns>
          private string CreatekeyFieldsFilterWithLoadData()
          {
               StringBuilder keyFields;
               keyFields = new StringBuilder();
               PropertyValue<byte> byteProperty;
               PropertyValue<short> int16Property;
               PropertyValue<int> int32Property;
               PropertyValue<long> int64Property;
               PropertyValue<double> doubleProperty;
               PropertyValue<float> singleProperty;
               PropertyValue<bool> boolProperty;
               PropertyValue<byte[]> bytesProperty;
               PropertyValue<string> stringProperty;
               PropertyValue<DateTime> dateTimeProperty;
               PropertyValue<decimal> decimalProperty;
               PropertyValue<object> objectProperty;
               foreach (KeyValuePair<string, Property> column in Properties)
               {
                    if (column.Value.IsVirtualField)
                         continue;
                    if (!column.Value.IsPrimaryKey)
                         continue;
                    if (column.Value is PropertyValue<bool>)
                    {
                         boolProperty = column.Value as PropertyValue<bool>;
                         if (boolProperty.IsPrimaryKey)
                         {
                              keyFields.AppendFormat("{0}={1} AND ", FieldNameFix(FieldNameFix(column.Key)), boolProperty.Value);
                         }
                    }
                    if (column.Value is PropertyValue<byte>)
                    {
                         byteProperty = column.Value as PropertyValue<byte>;
                         if (byteProperty.IsPrimaryKey)
                         {
                              keyFields.AppendFormat("{0}={1} AND ", FieldNameFix(column.Key), byteProperty.Value);
                         }
                    }
                    if (column.Value is PropertyValue<short>)
                    {
                         int16Property = column.Value as PropertyValue<short>;
                         if (int16Property.IsPrimaryKey)
                         {
                              keyFields.AppendFormat("{0}={1} AND ", FieldNameFix(column.Key), int16Property.Value);
                         }
                    }
                    if (column.Value is PropertyValue<int>)
                    {
                         int32Property = column.Value as PropertyValue<int>;
                         if (int32Property.IsPrimaryKey)
                         {
                              keyFields.AppendFormat("{0}={1} AND ", FieldNameFix(column.Key), int32Property.Value);
                         }
                    }
                    if (column.Value is PropertyValue<long>)
                    {
                         int64Property = column.Value as PropertyValue<long>;
                         if (int64Property.IsPrimaryKey)
                         {
                              keyFields.AppendFormat("{0}={1} AND ", FieldNameFix(column.Key), int64Property.Value);
                         }
                    }
                    if (column.Value is PropertyValue<DateTime>)
                    {
                         dateTimeProperty = column.Value as PropertyValue<DateTime>;
                         if (dateTimeProperty.IsPrimaryKey)
                         {
                              keyFields.AppendFormat("{0}={1} AND ", FieldNameFix(column.Key), dateTimeProperty.Value.DateSql(false, Connection.DataBase.Engine));
                         }
                    }
                    if (column.Value is PropertyValue<decimal>)
                    {
                         decimalProperty = column.Value as PropertyValue<decimal>;
                         if (decimalProperty.IsPrimaryKey)
                         {
                              keyFields.AppendFormat("{0}={1} AND ", FieldNameFix(column.Key), decimalProperty.Value);
                         }
                    }
                    if (column.Value is PropertyValue<float>)
                    {
                         singleProperty = column.Value as PropertyValue<float>;
                         if (singleProperty.IsPrimaryKey)
                         {
                              keyFields.AppendFormat("{0}={1} AND ", FieldNameFix(column.Key), singleProperty.Value);
                         }
                    }
                    if (column.Value is PropertyValue<double>)
                    {
                         doubleProperty = column.Value as PropertyValue<double>;
                         if (doubleProperty.IsPrimaryKey)
                         {
                              keyFields.AppendFormat("{0}={1} AND ", FieldNameFix(column.Key), doubleProperty.Value);
                         }
                    }
                    if (column.Value is PropertyValue<object>)
                    {
                         objectProperty = column.Value as PropertyValue<object>;
                         if (objectProperty.IsPrimaryKey)
                         {
                              keyFields.AppendFormat("{0}={1} AND ", FieldNameFix(column.Key), objectProperty.Value);
                         }
                    }
                    if (column.Value is PropertyValue<byte[]>)
                    {
                         bytesProperty = column.Value as PropertyValue<byte[]>;
                         if (bytesProperty.IsPrimaryKey)
                         {
                              keyFields.AppendFormat("{0}='{1}' AND ", FieldNameFix(column.Key), bytesProperty.Value);
                         }
                    }
                    if (column.Value is PropertyValue<string>)
                    {
                         stringProperty = column.Value as PropertyValue<string>;
                         if (stringProperty.IsPrimaryKey)
                         {
                              keyFields.AppendFormat("{0}='{1}' AND ", FieldNameFix(column.Key), stringProperty.Value);
                         }
                    }
               }
               return keyFields.Remove(keyFields.Length - 5, 5).ToString();
          }

          #endregion General methods for catalogs

          #region Queries for history

          private StringBuilder CreateQueryForNewHistoryTable()
          {
               StringBuilder query = new StringBuilder();
               if (string.IsNullOrEmpty(Connection.DataBase.LogData))
               {
                    query.AppendFormat(" Create Table {0}(", TableName(false, true));
               }
               else
               {
                    query.AppendFormat(" Create Table {0}(", TableName(true, true));
               }
               switch (Connection.DataBase.Engine)
               {
                    case DataBaseType.SqlServer:
                         query.AppendFormat(" _Id bigint IDENTITY(1,1) NOT NULL,");
                         query.AppendFormat(" _Abbreviation varchar(50) NOT NULL,");
                         query.AppendFormat(" _Key int NOT NULL,");
                         query.AppendFormat(" _Date datetime NOT NULL DEFAULT (getutcdate()),");
                         query.AppendFormat(" _CRUD int NOT NULL,");
                         query.AppendFormat(" ModifiedField nvarchar(max) NULL,");
                         query.AppendFormat(" {0}", Connection.GetStructureTable(Owner,Table, false));
                         query.AppendFormat(" PRIMARY KEY(	[_Id] ASC));");
                         return query;
                    case DataBaseType.MySql:
                         query.AppendFormat(" _Id bigint AUTO_INCREMENT NOT NULL,");
                         query.AppendFormat(" _Abbreviation varchar(50) NOT NULL,");
                         query.AppendFormat(" _Key int NOT NULL,");
                         query.AppendFormat(" _Date TIMESTAMP NOT NULL DEFAULT UTC_TIMESTAMP,");
                         query.AppendFormat(" _CRUD int NOT NULL,");
                         query.AppendFormat(" ModifiedField TEXT NULL,");
                         query.AppendFormat(" {0}", Connection.GetStructureTable(Owner, Table, false));
                         query.AppendFormat(" PRIMARY KEY(	[_Id] ASC));");
                         return query;
                    case DataBaseType.PostgressSql:
                         query.AppendFormat(" _Id BIGSERIAL,");
                         query.AppendFormat(" _Abbreviation character(50) NOT NULL,");
                         query.AppendFormat(" _Key integer NOT NULL,");
                         query.AppendFormat(" _Date timestamp without time zone default current_timestamp,");
                         query.AppendFormat(" _CRUD integer NOT NULL,");
                         query.AppendFormat(" ModifiedField TEXT NULL,");
                         query.AppendFormat(" {0}", Connection.GetStructureTable(Owner, Table, false));
                         query.AppendFormat(" );");
                         return query;
                    default:
                         if (string.IsNullOrEmpty(Connection.DataBase.LogData))
                         {
                              query.AppendFormat(" Create Table {0}(", TableName(false, true));
                         }
                         else
                         {
                              query.AppendFormat(" Create Table {0}(", TableName(true, true));
                         }
                         query.AppendFormat(" _Id bigint IDENTITY(1,1) NOT NULL,");
                         query.AppendFormat(" _Abbreviation varchar(50) NOT NULL,");
                         query.AppendFormat(" _Key int NOT NULL,");
                         query.AppendFormat(" _Date datetime NOT NULL DEFAULT (getdate()),");
                         query.AppendFormat(" _CRUD int NOT NULL,");
                         query.AppendFormat(" ModifiedField nvarchar(max) NULL,");
                         query.AppendFormat(" {0}", Connection.GetStructureTable(Owner, Table, false));
                         query.AppendFormat(" PRIMARY KEY(	[_Id] ASC));");
                         return query;
               }

          }

          /// <summary>
          /// Funcion que arma la consulta para crear la tabla del historial
          /// </summary>
          /// <returns></returns>
          private StringBuilder CreateQueryForHistoryTable()
          {
               StringBuilder query;
               bool logDataCatalog;
               //List<string> lstCamposLLave;
               query = new StringBuilder();
               query.AppendFormat("Select top 0 ");
               query.AppendFormat(" IDENTITY(INT, 1, 1) AS _Id");
               query.AppendFormat(", convert(varchar(50),'{0}') _Abbreviation", _System.Session.User.Uuid);
               query.AppendFormat(", {0} _Key", _System.Session.User.Number);
               query.AppendFormat(", GETUTCDATE() _Date");
               query.AppendFormat(", {0} _CRUD", (int)MovementType.Register);
               query.AppendFormat(", '' ModifiedField");
               foreach (KeyValuePair<string, Property> column in Properties)
               {
                    if (column.Value.IsVirtualField)
                         continue;
                    if (column.Value.IsIdentity)
                         query.AppendFormat(", cast({0}.[{1}] as int) {1} ", TableName(), FieldNameFix(column.Key));
                    else
                         query.AppendFormat(", {0}.{1} ", TableName(), FieldNameFix(column.Key));
               }
               if (string.IsNullOrEmpty(Connection.DataBase.LogData))
               {
                    query.AppendFormat(" into {0}", TableName(false, true));
               }
               else
               {
                    query.AppendFormat(" into {0}", TableName(true, true));
               }
               query.AppendFormat(" From {0};", TableName());
               logDataCatalog = false;
               if (!string.IsNullOrEmpty(Connection.DataBase.LogData))
                    logDataCatalog = true;
               query.AppendFormat(" Alter table {0} Alter Column {1} int not null;", TableName(logDataCatalog, true), FieldNameFix("_Id"));
               query.AppendFormat(" Alter table {0} Alter Column {1} varchar(50) not null;", TableName(logDataCatalog, true), FieldNameFix("_Abbreviation"));
               query.AppendFormat(" Alter table {0} Alter Column {1} int not null;", TableName(logDataCatalog, true), FieldNameFix("_Key"));
               query.AppendFormat(" Alter table {0} Alter Column {1} datetime not null;", TableName(logDataCatalog, true), FieldNameFix("_Date"));
               query.AppendFormat(" Alter table {0} Alter Column {1} int not null;", TableName(logDataCatalog, true), FieldNameFix("_CRUD"));
               query.AppendFormat(" Alter table {0} Alter Column {1} xml null;", TableName(logDataCatalog, true), FieldNameFix("ModifiedField"));
               query.AppendFormat(" Alter table {0} Add  Constraint [DF_{2}{3}]  DEFAULT (getdate()) FOR {1};", TableName(logDataCatalog, true), FieldNameFix("_Date"), Connection.DataBase.DataBaseObjectPrefixLogData, Table);
               foreach (KeyValuePair<string, Property> column in Properties)
               {
                    if (column.Value.IsVirtualField)
                         continue;
                    if (!column.Value.IsIdentity)
                         continue;
                    query.AppendFormat(" Alter table {0}  Alter Column {1} int not null;", TableName(logDataCatalog, true), column.Key);
               }
               query.AppendFormat(" Alter table {0} ADD CONSTRAINT [PK_{2}{1}] PRIMARY KEY CLUSTERED( ", TableName(logDataCatalog, true), Table, Connection.DataBase.DataBaseObjectPrefixLogData);
               query.AppendFormat(" _Id ASC,");
               query.AppendFormat(" _Abbreviation ASC,");
               query.AppendFormat(" _Key ASC,");
               query.AppendFormat(" _Date ASC,");
               query.AppendFormat(" _CRUD ASC");
               foreach (KeyValuePair<string, object> pkField in KeyFields)
               {
                    query.AppendFormat(", [{0}] ASC", FieldNameFix(pkField.Key));
               }
               query.AppendFormat(" );");
               // Create primary index.
               query.AppendFormat(" CREATE PRIMARY XML INDEX idx_ModifiedField{2}{1} on {0}(ModifiedField)", TableName(logDataCatalog, true), Table, Connection.DataBase.DataBaseObjectPrefixLogData);
               // Create secondary indexes (PATH, VALUE, PROPERTY).
               query.AppendFormat(" CREATE XML INDEX idx_ModifiedField{2}{1}_PATH ON {0}(ModifiedField)", TableName(logDataCatalog, true), Table, Connection.DataBase.DataBaseObjectPrefixLogData);
               query.AppendFormat(" USING XML INDEX idx_ModifiedField{1}{0}", Table, Connection.DataBase.DataBaseObjectPrefixLogData);
               query.AppendFormat(" FOR PATH;");
               query.AppendFormat(" CREATE XML INDEX idx_ModifiedField{2}{1}_VALUE ON {0}(ModifiedField)", TableName(logDataCatalog, true), Table, Connection.DataBase.DataBaseObjectPrefixLogData);
               query.AppendFormat(" USING XML INDEX idx_ModifiedField{1}{0}", Table, Connection.DataBase.DataBaseObjectPrefixLogData);
               query.AppendFormat(" FOR VALUE;");
               query.AppendFormat(" CREATE XML INDEX idx_ModifiedField{2}{1}_PROPERTY ON {0}(ModifiedField)", TableName(logDataCatalog, true), Table, Connection.DataBase.DataBaseObjectPrefixLogData);
               query.AppendFormat(" USING XML INDEX idx_ModifiedField{1}{0}", Table, Connection.DataBase.DataBaseObjectPrefixLogData);
               query.AppendFormat(" FOR PROPERTY;");
               query.AppendFormat(" Update {0} set ModifiedField = NULL;", TableName(logDataCatalog, true));
               return query;
          }

          /// <summary>
          /// Funcion que inserta datos en la tabla de bitacoras
          /// </summary>
          /// <param name="penMovimiento">Tipo de movimiento Alta, Baja, MOdificacion</param>
          /// <param name="psModifiedField">XML que se genero</param>
          /// <returns></returns>
          protected void CreateQueryForLogData(MovementType penMovimiento, string psModifiedField)
          {
               StringBuilder query = new StringBuilder();
               //? ver la manera de quitar el insert into select por un insert into
               if (string.IsNullOrEmpty(Connection.DataBase.LogData))
               {
                    query.AppendFormat("INSERT INTO {0}", TableName(false, true));
               }
               else
               {
                    query.AppendFormat("INSERT INTO {0}", TableName(true, true));
               }
               //Colocamos los nombres de los campos para lo haga por referncia aunque los campos
               //no esten en cierto orden
               query.AppendFormat("( _Abbreviation,_Key,_Date,_CRUD, ModifiedField");
               foreach (KeyValuePair<string, Property> column in Properties)
               {
                    if (column.Value.IsVirtualField)
                         continue;
                    query.AppendFormat(", {0} ", FieldNameFix(column.Key));
               }

               query.AppendFormat(") ");
               query.AppendFormat("Select ");
               query.AppendFormat(" @Abbreviation _Abbreviation");
               query.AppendFormat(",@Number _Key");
               switch (Connection.DataBase.Engine)
               {
                    case DataBaseType.PostgressSql:
                         query.AppendFormat(",current_timestamp _Date");
                         break;
                    default:
                         query.AppendFormat(",GETUTCDATE() _Date");
                         break;
               }

               query.AppendFormat(", @CRUD _CRUD");
               if (!string.IsNullOrEmpty(psModifiedField))
               {
                    _sqlParameterList.Add(new ParameterSql("@ModifiedField", psModifiedField));
                    query.AppendFormat(", @ModifiedField ModifiedField");
               }
               else
               {
                    query.AppendFormat(", NULL ModifiedField");
               }
               foreach (KeyValuePair<string, Property> column in Properties)
               {
                    if (column.Value.IsVirtualField)
                         continue;
                    query.AppendFormat(", {0}.{1} ", TableName(), FieldNameFix(column.Key));
               }
               query.AppendFormat(" From {0}", TableName());
               //lsbQuery.AppendFormat("Where {0}", ArmaFiltroCamposLLaveDatosCargados());
               query.AppendFormat(" Where {0}", CreateWhereConditionFromKeyFieldsWithSqlParameters());
               _sqlParameterList.Add(new ParameterSql("@Abbreviation", _System.Session.User.Uuid));
               _sqlParameterList.Add(new ParameterSql("@Number", _System.Session.User.Number));
               _sqlParameterList.Add(new ParameterSql("@CRUD", (int)penMovimiento));
               if (!string.IsNullOrEmpty(psModifiedField))
                    _sqlParameterList.Add(new ParameterSql("@ModifiedField", psModifiedField));
               Connection.ExecuteScalar(query, _sqlParameterList);
          }

          /// <summary>
          /// Armas the consulta para bitacora en memoria.
          /// </summary>
          /// <param name="movement">The pen movimiento.</param>
          /// <param name="xmlField">The ps XML campo.</param>
          /// <returns></returns>
          protected StringBuilder CreateQueryForLogDataInMemory(MovementType movement, string xmlField)
          {
               PropertyValue<byte> byteProperty;
               PropertyValue<short> int16Property;
               PropertyValue<int> int32Property;
               PropertyValue<long> int64Property;
               PropertyValue<double> doubleProperty;
               PropertyValue<float> singleProperty;
               PropertyValue<bool> boolProperty;
               PropertyValue<byte[]> bytesProperty;
               PropertyValue<string> stringProperty;
               PropertyValue<DateTime> dateTimeProperty;
               PropertyValue<decimal> decimalProperty;
               PropertyValue<object> objectProperty;
               PropertyValue<byte?> byteNProperty;
               PropertyValue<short?> int16NProperty;
               PropertyValue<int?> int32NProperty;
               PropertyValue<long?> int64NProperty;
               PropertyValue<double?> doubleNProperty;
               PropertyValue<float?> songleNProperty;
               PropertyValue<bool?> boolNProperty;
               PropertyValue<DateTime?> dateTimeNProperty;
               PropertyValue<decimal?> decimalNProperty;
               StringBuilder fields;
               StringBuilder oldValues;
               string parameterNames;
               int liContadorParametros;
               StringBuilder lsbQuery;

               fields = new StringBuilder();
               oldValues = new StringBuilder();
               liContadorParametros = 0;
               _sqlParameterList = new List<ParameterSql>();
               lsbQuery = new StringBuilder();
               foreach (KeyValuePair<string, Property> column in Properties)
               {
                    fields.AppendFormat("{0},", FieldNameFix(column.Key));
                    //obtener el tipo de datos
                    if (column.Value is PropertyValue<bool>)
                    {
                         boolProperty = column.Value as PropertyValue<bool>;
                         oldValues.AppendFormat("{0},", boolProperty.OldValue ? "1" : "0");
                    }
                    if (column.Value is PropertyValue<byte>)
                    {
                         byteProperty = column.Value as PropertyValue<byte>;
                         oldValues.AppendFormat("{0},", byteProperty.OldValue);
                    }
                    if (column.Value is PropertyValue<short>)
                    {
                         int16Property = column.Value as PropertyValue<short>;
                         oldValues.AppendFormat("{0},", int16Property.OldValue);
                    }
                    if (column.Value is PropertyValue<int>)
                    {
                         int32Property = column.Value as PropertyValue<int>;
                         oldValues.AppendFormat("{0},", int32Property.OldValue);
                    }
                    if (column.Value is PropertyValue<long>)
                    {
                         int64Property = column.Value as PropertyValue<long>;
                         oldValues.AppendFormat("{0},", int64Property.OldValue);
                    }
                    if (column.Value is PropertyValue<DateTime>)
                    {
                         dateTimeProperty = column.Value as PropertyValue<DateTime>;
                         oldValues.AppendFormat("{0},", dateTimeProperty.OldValue.DateSql(true, Connection.DataBase.Engine));
                    }
                    if (column.Value is PropertyValue<decimal>)
                    {
                         decimalProperty = column.Value as PropertyValue<decimal>;
                         oldValues.AppendFormat("{0},", decimalProperty.OldValue);
                    }
                    if (column.Value is PropertyValue<float>)
                    {
                         singleProperty = column.Value as PropertyValue<float>;
                         oldValues.AppendFormat("{0},", singleProperty.OldValue);
                    }
                    if (column.Value is PropertyValue<double>)
                    {
                         doubleProperty = column.Value as PropertyValue<double>;
                         oldValues.AppendFormat("{0},", doubleProperty.OldValue);
                    }
                    if (column.Value is PropertyValue<object>)
                    {
                         objectProperty = column.Value as PropertyValue<object>;
                         oldValues.AppendFormat("'{0}',", objectProperty.OldValue);
                    }
                    if (column.Value is PropertyValue<byte[]>)
                    {
                         bytesProperty = column.Value as PropertyValue<byte[]>;
                         if (Equals(bytesProperty.OldValue, null))
                         {
                              oldValues.AppendFormat("null,");
                         }
                         else
                         {
                              parameterNames = string.Format("@Parametro{0}", Convert.ToString(liContadorParametros));
                              oldValues.AppendFormat("{0},", parameterNames);
                              _sqlParameterList.Add(new ParameterSql(parameterNames, bytesProperty.OldValue));
                              liContadorParametros++;
                         }
                    }
                    if (column.Value is PropertyValue<string>)
                    {
                         stringProperty = column.Value as PropertyValue<string>;

                         if (Equals(stringProperty.OldValue, null))
                         {
                              oldValues.AppendFormat("null,");
                         }
                         else
                         {
                              oldValues.AppendFormat("'{0}',", stringProperty.OldValue);
                         }
                    }
                    if (column.Value is PropertyValue<byte?>)
                    {
                         byteNProperty = column.Value as PropertyValue<byte?>;
                         if (Equals(byteNProperty.OldValue, null))
                         {
                              oldValues.AppendFormat("null,");
                         }
                         else
                         {
                              oldValues.AppendFormat("{0},", byteNProperty.OldValue);
                         }
                    }
                    if (column.Value is PropertyValue<bool?>)
                    {
                         boolNProperty = column.Value as PropertyValue<bool?>;
                         if (Equals(boolNProperty.OldValue, null))
                         {
                              oldValues.AppendFormat("null,");
                         }
                         else
                         {
                              oldValues.AppendFormat("{0},", (bool)boolNProperty.OldValue ? "1" : "0");
                         }
                    }
                    if (column.Value is PropertyValue<short?>)
                    {
                         int16NProperty = column.Value as PropertyValue<short?>;
                         if (Equals(int16NProperty.OldValue, null))
                         {
                              oldValues.AppendFormat("null,");
                         }
                         else
                         {
                              oldValues.AppendFormat("{0},", int16NProperty.OldValue);
                         }
                    }
                    if (column.Value is PropertyValue<int?>)
                    {
                         int32NProperty = column.Value as PropertyValue<int?>;
                         if (Equals(int32NProperty.OldValue, null))
                         {
                              oldValues.AppendFormat("null,");
                         }
                         else
                         {
                              oldValues.AppendFormat("{0},", int32NProperty.OldValue);
                         }
                    }
                    if (column.Value is PropertyValue<long?>)
                    {
                         int64NProperty = column.Value as PropertyValue<long?>;
                         if (Equals(int64NProperty.OldValue, null))
                         {
                              oldValues.AppendFormat("null,");
                         }
                         else
                         {
                              oldValues.AppendFormat("{0},", int64NProperty.OldValue);
                         }
                    }
                    if (column.Value is PropertyValue<DateTime?>)
                    {
                         dateTimeNProperty = column.Value as PropertyValue<DateTime?>;
                         if (Equals(dateTimeNProperty.OldValue, null) || Equals(dateTimeNProperty.OldValue, default(DateTime)))
                         {
                              oldValues.AppendFormat("null,");
                         }
                         else
                         {
                              oldValues.AppendFormat("{0},", ((DateTime)dateTimeNProperty.OldValue).DateSql(true, Connection.DataBase.Engine));
                         }
                    }
                    if (column.Value is PropertyValue<decimal?>)
                    {
                         decimalNProperty = column.Value as PropertyValue<decimal?>;
                         if (Equals(decimalNProperty.OldValue, null))
                         {
                              oldValues.AppendFormat("null,");
                         }
                         else
                         {
                              oldValues.AppendFormat("{0},", decimalNProperty.OldValue);
                         }
                    }
                    if (column.Value is PropertyValue<float?>)
                    {
                         songleNProperty = column.Value as PropertyValue<float?>;
                         if (Equals(songleNProperty.OldValue, null))
                         {
                              oldValues.AppendFormat("null,");
                         }
                         else
                         {
                              oldValues.AppendFormat("{0},", songleNProperty.OldValue);
                         }
                    }
                    if (column.Value is PropertyValue<double?>)
                    {
                         doubleNProperty = column.Value as PropertyValue<double?>;
                         if (Equals(doubleNProperty.OldValue, null))
                         {
                              oldValues.AppendFormat("null,");
                         }
                         else
                         {
                              oldValues.AppendFormat("{0},", doubleNProperty.OldValue);
                         }
                    }
               }
               fields.Remove(fields.Length - 1, 1);
               oldValues.Remove(oldValues.Length - 1, 1);
               //? ver la manera de quitar el insert into select por un insert into
               if (string.IsNullOrEmpty(Connection.DataBase.LogData))
               {
                    lsbQuery.AppendFormat("INSERT INTO {0}", TableName(false, true));
               }
               else
               {
                    lsbQuery.AppendFormat("INSERT INTO {0}", TableName(true, true));
               }
               lsbQuery.AppendFormat(" (_Abbreviation,_Key,_Date,_CRUD,ModifiedField,{0})", fields);

               lsbQuery.AppendFormat("values( ");
               lsbQuery.AppendFormat("'{0}' _Abbreviation", _System.Session.User.Uuid);
               lsbQuery.AppendFormat(",{0} _Key", _System.Session.User.Number);
               lsbQuery.AppendFormat(",GETDATE() _Date");
               lsbQuery.AppendFormat(", {0} _CRUD", (int)movement);
               if (!string.IsNullOrEmpty(xmlField))
               {
                    lsbQuery.AppendFormat(", '{0}' ModifiedField", xmlField);
               }
               else
               {
                    lsbQuery.AppendFormat(", NULL ModifiedField");
               }
               lsbQuery.AppendFormat("{0}", oldValues);
               lsbQuery.AppendFormat(") ");
               return lsbQuery;
          }

          #endregion Queries for history


     }
}