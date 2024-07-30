using Shelly.Abstractions.Constants;
using Shelly.ProviderData.Helper;

namespace Shelly.ProviderData.GenericRepository.Entity
{
    /// <summary>
    /// Clase que proporciana metodos para operar listado de la calse CatalogoFijoElemento
    /// </summary>
    /// <typeparam name="T">Cualquier clase que herede de la clase CatalogoFijoElemento</typeparam>
    [Serializable]
     public class StaticEntityCollection<T> where T : StaticEntity, new()
     {
          #region variables

          /// <summary>
          /// Variables del sistema
          /// </summary>
          protected internal IBaseSystem _System;

          protected internal DataAccess _Connection;

          /// <summary>
          /// The _o catalogo
          /// </summary>
          protected internal T _catalog;


          protected List<T> _List;
          #endregion variables

          #region Properties
          public bool IsImplementation { get; set; }
          /// <summary>
          /// Gets or sets the buffer bitacora.
          /// </summary>
          /// <value>
          /// The buffer bitacora.
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
          /// TmpPath
          /// </summary>
          public string TmpPath { get; set; }

          /// <summary>
          /// Gets or sets the number table.
          /// </summary>
          /// <value>
          /// The number table.
          /// </value>
          public string NumberTable { get; set; }
          /// <summary>
          /// Prefix
          /// </summary>
          public string Prefix { get; set; }
          public int PageNumber { get; set; }
          public int RowsOfPage { get; set; }
          public int Top { get; set; }

          /// <summary>
          /// Gets or sets the filter.
          /// </summary>
          /// <value>
          /// The filter.
          /// </value>
          public string Filter { get; set; }
          /// <summary>
          /// Gets or sets the employees filter.
          /// </summary>
          /// <value>
          /// The employees filter.
          /// </value>
          public string EmployeesFilter { get; set; }
          /// <summary>
          /// FilterIn
          /// </summary>
          public string FilterIn { get; set; }
          /// <summary>
          /// Gets or sets the type of the payroll.
          /// </summary>
          /// <value>
          /// The type of the payroll.
          /// </value>
          public int PayrollType { get; set; }
          /// <summary>
          /// IsSettlement
          /// </summary>
          public bool IsSettlement { get; set; }
          public bool AllEmployees { get; set; }
          public bool IsClose { get; set; }
          public string Currency { get; set; }
          public string FilterInternalNumber { get; set; }
          public string FilterAdditional { get; set; }
          /// <summary>
          /// Gets the data.
          /// </summary>
          /// <value>
          /// The data.
          /// </value>
          public virtual List<T> Data
          {
               get
               {
                    return GetCollectionSearchByField(Filter, FilterAdditional, PageNumber, RowsOfPage).ToList();
               }
          }

          #endregion Properties

          #region Builder

          /// <summary>
          /// Constructor con la variable del sistema
          /// </summary>
          /// <param name="system"></param>
          public StaticEntityCollection(IBaseSystem system)
          {
               _System = system;
               _Connection = (DataAccess)system.Connection;
               _catalog = new T
               {
                    _System = system,
                    _Connection = (DataAccess)system.Connection
               };
               _catalog.CreateStringFieldsComaSeparated();
               _List = new List<T>();
          }

          public StaticEntityCollection(IBaseSystem system, T catalog)
          {
               _System = system;
               _Connection = (DataAccess)system.Connection;
               _catalog = catalog;
               _catalog._System = system;
               _catalog._Connection = (DataAccess)system.Connection;
               _catalog.CreateStringFieldsComaSeparated();
               Prefix = catalog.Prefix;
               NumberTable = catalog.NumberTable;
               _List = new List<T>();
          }

          public StaticEntityCollection()
          {
               _List = new List<T>();
          }

          #endregion Builder

          #region Methods for FixedCatalogElements or object list
          private DataTable GetDataTableForInsert()
          {
               DataTable loTable = new DataTable();
               // columns
               foreach (KeyValuePair<string, Property> property in _catalog.Properties)
               {
                    loTable.Columns.Add(property.Key);
               }
               // row values
               foreach (T loItem in _List)
               {
                    DataRow loRow = loTable.NewRow();
                    foreach (KeyValuePair<string, Property> property in loItem.Properties)
                    {
                         loRow[property.Key] = loItem.GetPropertyValue(property.Key);
                    }
                    loTable.Rows.Add(loRow);
               }
               return loTable;
          }

          public void Add(T data)
          {
               _List.Add(data);
          }
          /// <summary>
          /// Inserta masivamente la informacion de la tabla
          /// TODO: Hacer un bulkcopy sin las bitacoras para cuando se necesita almacenar un conjunto masivo de informacion en la base de datos
          /// </summary>
          /// <param name="inputObject">The po objeto.</param>
          public void MasiveInsert(IEnumerable<T> inputObject)
          {
               _catalog.Prefix = Prefix;
               _catalog.NumberTable = NumberTable;
               _Connection.InsertBulkCopy<T>(inputObject, $"{_catalog.Prefix}{_catalog.Table}{_catalog.NumberTable}");
          }
          public void MasiveInsert()
          {
               _catalog.Prefix = Prefix;
               _catalog.NumberTable = NumberTable;
               _Connection.InsertBulkCopy(GetDataTableForInsert(), $"{_catalog.Prefix}{_catalog.Table}{_catalog.NumberTable}");
          }
          #region DataTable



          /// <summary>
          /// Regresas the data table.
          /// </summary>
          /// <param name="selectFields">The ps select campos.</param>
          /// <param name="filter">The ps filtro.</param>
          /// <returns></returns>
          public DataTable GetDataTable(StringBuilder selectFields, StringBuilder filter)
          {
               return GetDataTable(selectFields, filter, null);
          }

          /// <summary>
          /// Gets the data table.
          /// </summary>
          /// <param name="selectFields">The select fields.</param>
          /// <returns></returns>
          public DataTable GetDataTable(StringBuilder selectFields)
          {
               return GetDataTable(selectFields, new StringBuilder(), null);
          }

          /// <summary>
          /// Regresas the data table.
          /// </summary>
          /// <param name="selectFields">The ps select campos.</param>
          /// <param name="filter">The ps filtro.</param>
          /// <param name="order">The ps orden.</param>
          /// <returns></returns>
          public DataTable GetDataTable(StringBuilder selectFields, StringBuilder filter, StringBuilder order)
          {
               return GetDataTable(selectFields, new StringBuilder(), false, filter, order, null);
          }
          public DataTable GetDataTable(StringBuilder selectFields, StringBuilder specialFilter, bool filterByKeyFields, StringBuilder psFiltroPrincipal, StringBuilder psOrden)
          {
               return GetDataTable(selectFields, specialFilter, filterByKeyFields, psFiltroPrincipal, psOrden, null);
          }
          /// <summary>
          /// Funcion que regresa un data table del catalgo
          /// </summary>
          /// <param name="selectFields">Campos </param>
          /// <param name="specialFilter">Filtro especial</param>
          /// <param name="filterByKeyFields">if set to <c>true</c> [pb filtrarpor campos llave].</param>
          /// <param name="psFiltroPrincipal">The ps filtro principal.</param>
          /// <param name="psOrden">The ps orden.</param>
          /// <returns></returns>
          public DataTable GetDataTable(StringBuilder selectFields, StringBuilder specialFilter, bool filterByKeyFields, StringBuilder mainFilter, StringBuilder orderSelect, List<ParameterSql> parameters)
          {
               StringBuilder lsQuery;
               StringBuilder lsWhere;
               try
               {
                    _catalog.NumberTable = NumberTable;
                    if (selectFields == null) selectFields = new StringBuilder();
                    if (specialFilter == null) specialFilter = new StringBuilder();
                    if (mainFilter == null) mainFilter = new StringBuilder();
                    if (orderSelect == null) orderSelect = new StringBuilder();
                    string select = selectFields.ToString();
                    string filtroPrincipal = mainFilter.ToString();
                    string otherFilter = specialFilter.ToString();
                    string order = orderSelect.ToString();
                    lsQuery = new StringBuilder();
                    lsWhere = new StringBuilder();
                    if (string.IsNullOrEmpty(select))
                         select = _catalog._fields.ToString();
                    lsQuery.AppendFormat("Select {0} from {1} ", select, _catalog.TableName());
                    if (filterByKeyFields)
                    {
                         lsWhere.AppendFormat("  {0} = {1}", _catalog.KeyFields.First().Key, _System.Session.Company.Number);
                         if (!string.IsNullOrEmpty(filtroPrincipal))
                              lsWhere.AppendFormat(" AND  {0}", filtroPrincipal);
                         else if (!string.IsNullOrEmpty(otherFilter))
                              lsWhere.AppendFormat(" AND {0}", otherFilter);
                    }
                    else if (!string.IsNullOrEmpty(otherFilter))
                    {
                         lsWhere.AppendFormat(" {0}", otherFilter);
                         if (!string.IsNullOrEmpty(filtroPrincipal))
                              lsWhere.AppendFormat(" AND {0}", filtroPrincipal);
                    }

                    if (lsWhere.Length > 0)
                         lsQuery.AppendFormat(" where {0}", lsWhere);
                    if (!string.IsNullOrEmpty(order))
                         lsQuery.AppendFormat(" Order by {0}", order);
                    return _Connection.GetDataTable(lsQuery, parameters);
               }
               finally
               {
                    //FuncionesDatos.LiberaObjeto(ref ldtDatos);  //no se libera porque si no se destruye el objeto y luego no se puede hacer un bind
               }
          }

          /// <summary>
          /// Regresas the data table.
          /// </summary>
          /// <returns></returns>
          public DataTable GetDataTable()
          {
               DataTable dataTable = null;
               StringBuilder query;
               string selectFields;
               try
               {
                    _catalog.Prefix = Prefix;
                    _catalog.NumberTable = NumberTable;
                    query = new StringBuilder();
                    selectFields = _catalog._fields.ToString();
                    query.AppendFormat("Select {0} from {1} ", selectFields, _catalog.TableName());
                    dataTable = _Connection.GetDataTable(query, $"{_catalog.Table}{_catalog.NumberTable}");
                    return dataTable;
               }
               finally
               {
                    //FuncionesDatos.LiberaObjeto(ref ldtDatos);  //no se libera porque si no se destruye el objeto y luego no se puede hacer un bind
               }
          }

          /// <summary>
          /// Gets the history data table.
          /// </summary>
          /// <returns></returns>
          public DataTable GetHistoryDataTable()
          {
               return GetHistoryDataTable(null, null, true, null);
          }

          /// <summary>
          /// Gets the history data table.
          /// </summary>
          /// <param name="selectFields">The select fields.</param>
          /// <returns></returns>
          public DataTable GetHistoryDataTable(string selectFields)
          {
               return GetHistoryDataTable(selectFields, null, true, null);
          }

          /// <summary>
          /// Gets the history data table.
          /// </summary>
          /// <param name="selectFields">The select fields.</param>
          /// <param name="specialFilter">The special filter.</param>
          /// <returns></returns>
          public DataTable GetHistoryDataTable(string selectFields, string specialFilter)
          {
               return GetHistoryDataTable(selectFields, specialFilter, true, null);
          }

          /// <summary>
          /// Gets the history data table.
          /// </summary>
          /// <param name="selectFields">The select fields.</param>
          /// <param name="specialFilter">The special filter.</param>
          /// <param name="filterByKeyFields">if set to <c>true</c> [filter by key fields].</param>
          /// <returns></returns>
          public DataTable GetHistoryDataTable(string selectFields, string specialFilter, bool filterByKeyFields)
          {
               return GetHistoryDataTable(selectFields, specialFilter, filterByKeyFields, null);
          }

          /// <summary>
          /// Gets the history data table.
          /// </summary>
          /// <param name="selectFields">The select fields.</param>
          /// <param name="specialFilter">The special filter.</param>
          /// <param name="filterByKeyFields">if set to <c>true</c> [filter by key fields].</param>
          /// <param name="principalFilter">The principal filter.</param>
          /// <returns></returns>
          public DataTable GetHistoryDataTable(string selectFields, string specialFilter, bool filterByKeyFields, string principalFilter)
          {
               DataTable ldtDatos = null;
               StringBuilder lsQuery;
               string lsServidor;
               bool lbHistorial;
               try
               {
                    _catalog.Prefix = Prefix;
                    _catalog.NumberTable = NumberTable;
                    //! Asumimos que existe la tabla de historial
                    lsQuery = new StringBuilder();
                    if (string.IsNullOrEmpty(selectFields))
                         selectFields = _catalog._fields.ToString();
                    if (string.IsNullOrEmpty(_Connection.DataBase.LogData))
                    {
                         lsServidor = _Connection.DataBase.Catalog;
                         lbHistorial = false;
                    }
                    else
                    {
                         lsServidor = _Connection.DataBase.LogData;
                         lbHistorial = true;
                    }
                    lsQuery.AppendFormat("Select {0} from {1} where ", selectFields, _catalog.TableName(lbHistorial, true));
                    if (filterByKeyFields)
                    {
                         lsQuery.AppendFormat(" {0} = {1}", _catalog.KeyFields.First().Key, _System.Session.Company.Number);
                    }
                    else
                    {
                         lsQuery.AppendFormat(principalFilter);
                    }
                    if (!string.IsNullOrEmpty(specialFilter))
                    {
                         lsQuery.AppendFormat(" and {0}", specialFilter);
                    }
                    ldtDatos = _Connection.GetDataTable(lsQuery, $"{_catalog.Table}{_catalog.NumberTable}");
                    return ldtDatos;
               }
               finally
               {
                    //FuncionesDatos.LiberaObjeto(ref ldtDatos);  //no se libera porque si no se destruye el objeto y luego no se puede hacer un bind
               }
          }

          /// <summary>
          /// Gets the generic data table.
          /// </summary>
          /// <param name="selectFields">The select fields.</param>
          /// <param name="fieldsFilter">The fields filter.</param>
          /// <returns></returns>
          public DataTable GetGenericDataTable(string selectFields, string fieldsFilter)
          {
               DataTable dataTable = null;
               StringBuilder query;
               query = new StringBuilder();
               _catalog.Prefix = Prefix;
               _catalog.NumberTable = NumberTable;
               query.AppendFormat("Select {0} from {1}", selectFields, _catalog.TableName());
               query.AppendFormat(" where {0}", fieldsFilter);
               dataTable = _Connection.GetDataTable(query, $"{_catalog.Table}{_catalog.NumberTable}");
               return dataTable;
          }

          /// <summary>
          /// Regresas the data table.
          /// </summary>
          /// <param name="specialFilter">The ps filtro especial.</param>
          /// <param name="includeInternalfilterByCompany">if set to <c>true</c> [pb incluye filtro internopor empresa].</param>
          /// <param name="order">The ps orden.</param>
          /// <returns></returns>
          public DataTable GetDataTable(StringBuilder specialFilter, bool includeInternalfilterByCompany, string order, List<ParameterSql> parameters)
          {
               return GetDataTable(specialFilter.ToString(), includeInternalfilterByCompany, order, parameters);
          }
          public DataTable GetDataTable(StringBuilder specialFilter, bool includeInternalfilterByCompany, string order)
          {
               return GetDataTable(specialFilter.ToString(), includeInternalfilterByCompany, order, null);
          }
          public DataTable GetDataTable(string specialFilter, bool includeInternalfilterByCompany, string order)
          {
               return GetDataTable(specialFilter, includeInternalfilterByCompany, order, null);
          }
          /// <summary>
          /// Regresas the data table datos.
          /// </summary>
          /// <param name="specialFilter">The ps filtro especial.</param>
          /// <param name="includeInternalfilterByCompany">if set to <c>true</c> [pb incluye filtro internopor empresa].</param>
          /// <param name="order">The ps orden.</param>
          /// <returns></returns>
          public DataTable GetDataTable(string specialFilter, bool includeInternalfilterByCompany, string order, List<ParameterSql> parameters)
          {
               StringBuilder query;
               string select;
               // T loCatalogo;
               query = new StringBuilder();
               select = _catalog._fields.ToString();
               _catalog.Prefix = Prefix;
               _catalog.NumberTable = NumberTable;
               if (Top != 0)
                    query.AppendFormat("Select TOP {2} {0} from {1}", select, _catalog.TableName(), Top);
               else
                    query.AppendFormat("Select {0} from {1}", select, _catalog.TableName());
               if (includeInternalfilterByCompany)
               {
                    query.AppendFormat(" where {0} = {1} ", _catalog.KeyFields.First().Key, _System.Session.Company.Number);
                    if (!string.IsNullOrEmpty(specialFilter))
                    {
                         query.AppendFormat(" and {0}", specialFilter);
                    }
               }
               else
               {
                    if (!string.IsNullOrEmpty(specialFilter))
                    {
                         query.AppendFormat(" where {0}", specialFilter);
                    }
               }
               if (!string.IsNullOrEmpty(order))
                    query.AppendFormat(" Order by {0}", order);
               return _Connection.GetDataTable(query, parameters);
          }

          public DataTable GetDataTable(string specialFilter, int pageNumber, int rowsOfPage)
          {
               StringBuilder query;
               string select;
               // T loCatalogo;
               query = new StringBuilder();
               select = _catalog._fields.ToString();
               _catalog.Prefix = Prefix;
               _catalog.NumberTable = NumberTable;
               query.AppendFormat("Select {0} from {1}", select, _catalog.TableName());
               if (!string.IsNullOrEmpty(specialFilter))
               {
                    query.AppendFormat(" where {0}", specialFilter);
               }
               query.AppendFormat(" order by");
               foreach (var key in _catalog.KeyFields)
                    query.AppendFormat(" {0},", key.Key);
               query.Remove(query.Length - 1, 1);
               if (pageNumber > 0 && rowsOfPage > 0)
               {
                    query.AppendFormat(" OFFSET ({0}-1)*{1} ROWS", pageNumber, rowsOfPage);
                    query.AppendFormat(" FETCH NEXT {0} ROWS ONLY", rowsOfPage);
               }
               return _Connection.GetDataTable(query);
          }
          public DataTable GetDataTablePagination(string specialFilter, int pageNumber, int rowsOfPage)
          {
               StringBuilder query = new StringBuilder();
               string select = _catalog._fields.ToString();
               _catalog.Prefix = Prefix;
               _catalog.NumberTable = NumberTable;
               if (pageNumber <= 0)
                    pageNumber = 1;
               if (rowsOfPage <= 0)
                    rowsOfPage = 20;
               query.AppendFormat(" with ranked as( ");
               query.AppendFormat(" Select");
               query.AppendFormat(" row_number() over (order by ");
               foreach (var key in _catalog.KeyFields)
                    query.AppendFormat(" {0},", key.Key);
               query.Remove(query.Length - 1, 1);
               query.AppendFormat(" ) RowNum");
               query.AppendFormat(",{0} from {1}", select, _catalog.TableName());
               if (!string.IsNullOrEmpty(specialFilter))
                    query.AppendFormat(" where {0}", specialFilter);               
               query.AppendFormat(" ) select (select count(RowNum) from ranked) TotalRows");
               query.AppendFormat(" ,{0} pageNumber", pageNumber);
               query.AppendFormat(" ,{0} rowsOfPage", rowsOfPage);
               query.AppendFormat(" ,{0}", select);
               query.AppendFormat(" from ranked");
               query.AppendFormat(" order by");
               foreach (var key in _catalog.KeyFields)
                    query.AppendFormat(" {0},", key.Key);
               query.Remove(query.Length - 1, 1);
               query.AppendFormat(" OFFSET ({0}-1)*{1} ROWS", pageNumber, rowsOfPage);
               query.AppendFormat(" FETCH NEXT {0} ROWS ONLY", rowsOfPage);               
               return _Connection.GetDataTable(query);
          }
          public DataTable GetDataTable(string specialFilter, List<ParameterSql> parameters, int pageNumber, int rowsOfPage)
          {
               StringBuilder query;
               string select;
               // T loCatalogo;
               query = new StringBuilder();
               select = _catalog._fields.ToString();
               _catalog.Prefix = Prefix;
               _catalog.NumberTable = NumberTable;
               query.AppendFormat("Select {0} from {1}", select, _catalog.TableName());
               if (!string.IsNullOrEmpty(specialFilter))
               {
                    query.AppendFormat(" where {0}", specialFilter);
               }
               query.AppendFormat(" order by");
               foreach (var key in _catalog.KeyFields)
                    query.AppendFormat(" {0},", key.Key);
               query.Remove(query.Length - 1, 1);
               if (pageNumber > 0 && rowsOfPage > 0)
               {
                    query.AppendFormat(" OFFSET ({0}-1)*{1} ROWS", pageNumber, rowsOfPage);
                    query.AppendFormat(" FETCH NEXT {0} ROWS ONLY", rowsOfPage);
               }
               return _Connection.GetDataTable(query, parameters);
          }
          public DataTable GetDataTablePagination(string specialFilter, List<ParameterSql> parameters, int pageNumber, long rowsOfPage)
          {
               StringBuilder query;
               string select = _catalog._fields.ToString();
               _catalog.Prefix = Prefix;
               _catalog.NumberTable = NumberTable;
            if (pageNumber == 0)
                pageNumber = 1;
            if (rowsOfPage == 0)
            {
                query = new StringBuilder();
                query.AppendFormat(" Select count({0}) from {1}", _catalog.KeyFields.First().Key,_catalog.TableName());
                rowsOfPage = _Connection.ExecuteScalar <long>(query);
            }
            query = new StringBuilder();
            query.AppendFormat(" with ranked as( ");
               query.AppendFormat(" Select");
               query.AppendFormat(" row_number() over (order by ");
               foreach (var key in _catalog.KeyFields)
                    query.AppendFormat(" {0},", key.Key);
               query.Remove(query.Length - 1, 1);
               query.AppendFormat(" ) RowNum");
               query.AppendFormat(",{0} from {1}", select, _catalog.TableName());
               if (!string.IsNullOrEmpty(specialFilter))
                    query.AppendFormat(" where {0}", specialFilter);
               query.AppendFormat(" ) select (select count(RowNum) from ranked) TotalRows");
               query.AppendFormat(" ,{0} pageNumber", pageNumber);
               query.AppendFormat(" ,{0} rowsOfPage", rowsOfPage);
               query.AppendFormat(" ,{0}", select);
               query.AppendFormat(" from ranked");
               query.AppendFormat(" order by");
               foreach (var key in _catalog.KeyFields)
                    query.AppendFormat(" {0},", key.Key);
               query.Remove(query.Length - 1, 1);
               if (pageNumber > 0 && rowsOfPage > 0)
               {
                    query.AppendFormat(" OFFSET ({0}-1)*{1} ROWS", pageNumber, rowsOfPage);
                    query.AppendFormat(" FETCH NEXT {0} ROWS ONLY", rowsOfPage);
               }
               return _Connection.GetDataTable(query, parameters);
          }
          public DataTable GetDataTable(int pageNumber, int rowsOfPage)
          {
               StringBuilder query;
               string select;
               // T loCatalogo;
               query = new StringBuilder();
               select = _catalog._fields.ToString();
               _catalog.Prefix = Prefix;
               _catalog.NumberTable = NumberTable;
               query.AppendFormat("Select {0} from {1}", select, _catalog.TableName());
               query.AppendFormat(" Order by ");
               foreach (var key in _catalog.KeyFields)
                    query.AppendFormat(" {0},", key.Key);
               query.Remove(query.Length - 1, 1);
               if (pageNumber > 0 && rowsOfPage > 0)
               {
                    query.AppendFormat(" OFFSET ({0}-1)*{1} ROWS", pageNumber, rowsOfPage);
                    query.AppendFormat(" FETCH NEXT {0} ROWS ONLY", rowsOfPage);
               }
               return _Connection.GetDataTable(query);
          }

          public DataTable GetDataTableSearchByField(string select, string filter, string filteradditional, string order)
          {
               return GetDataTableSearchByField(select, filter, filteradditional, order, true, 0, 0);
          }
          public DataTable GetDataTableSearchByField(string filter)
          {
               return GetDataTableSearchByField("", filter, "", "", true, 0, 0);
          }

          public DataTable GetDataTableSearchByField(string filter, int pageNumber, int rowsOfPage)
          {
               return GetDataTableSearchByField("", filter, "", "", true, pageNumber, rowsOfPage);
          }
          public DataTable GetDataTableSearchByField(string filter, int pageNumber, int rowsOfPage, string order)
          {
               return GetDataTableSearchByField("", filter, "", order, true, pageNumber, rowsOfPage);
          }
          /// <summary>
          /// Gets the data table search by field.
          /// </summary>
          /// <param name="filter">The filter.</param>
          /// <param name="filteradditional">The filteradditional.</param>
          /// <param name="order">The order.</param>
          /// <returns></returns>
          public DataTable GetDataTableSearchByField(string select, string filter, string filteradditional, string order, bool pbFilterUser, int pageNumber, int rowsOfPage)
          {
               StringBuilder query;
               StringBuilder filter1;
               StringBuilder filter2;
               StringBuilder filter3;
               List<ParameterSql> parameters;
               bool existCompanyFilter;
               bool existFieldFilter;
               bool existfilteradditional;
               bool existfilterEmployee;
               //string select;
               // T loCatalogo;
               query = new StringBuilder();
               filter1 = new StringBuilder();
               filter2 = new StringBuilder();
               parameters = new List<ParameterSql>();
               if (string.IsNullOrEmpty(select))
                    select = _catalog._fields.ToString();
               _catalog.Prefix = Prefix;
               _catalog.NumberTable = NumberTable;
               query.AppendFormat("Select {0} from {1} ", select, _catalog.TableName());
               filter3 = new StringBuilder();
               if (!string.IsNullOrEmpty(filter))
                    filter = "";
               filter = filter.ToLower();
               parameters.Add(new ParameterSql("@filter", filter));

               foreach (KeyValuePair<string, Property> property in _catalog.Properties)
               {
                    if (property.Value.IsVirtualField)
                         continue;
                    if (property.Value.IsCompanyField)
                    {
                         switch (_catalog.Table.ToUpper())
                         {
                              case "XSPARAMETER":                                                                      
                                   if (_System.Session.User.IsSuperUser)
                                        filter1.AppendFormat(" {0} in (0,{1}) ", property.Key, _System.Session.Company.Number);
                                   else
                                        filter1.AppendFormat(" {0} = {1} ", property.Key, _System.Session.Company.Number);                                   
                                   break;
                              default:
                                   filter1.AppendFormat(" {0} = {1} ", property.Key, _System.Session.Company.Number);
                                   break;
                         }

                         continue;
                    }
                    if (string.IsNullOrEmpty(filter))
                         continue;

                    switch (_catalog.Table.ToUpper())
                    {

                         default:
                              if (property.Value is PropertyValue<DateTime>)
                              {
                                   filter2.AppendFormat(" (lower(convert ( varchar,{0},23)) like '%' + cast (@filter as varchar) + '%') or", property.Key);
                              }
                              else if (property.Value is PropertyValue<bool>)
                              {
                                   filter2.AppendFormat(" ((lower( case {0} when 0 then 'false' else 'true' end)) like '%' + cast (@filter as varchar) + '%') or", property.Key);
                              }
                              else
                              {
                                   filter2.AppendFormat(" (lower(cast ({0} as varchar)) like '%' + cast (@filter as varchar) + '%') or", property.Key);
                              }
                              break;
                    }
               }
               filter3 = new StringBuilder();
               switch (_catalog.Table.ToUpper())
               {
                    case "XTSMD_PERFIL":
                         filter3.AppendFormat(" PERFIL >= 0 AND ");
                         break;
                    case "XTSPRIVILEGIOSE":
                         filter3.AppendFormat(" CLAVE >= 0 AND ");
                         break;
                    default:
                         break;
               }
               existCompanyFilter = filter1.Length > 0;
               existFieldFilter = filter2.Length > 0;
               existfilteradditional = !string.IsNullOrEmpty(filteradditional);
               existfilterEmployee = filter3.Length > 0;
               if (existCompanyFilter || existFieldFilter || existfilteradditional || existfilterEmployee)
                    query.AppendFormat(" where ");
               if (existfilterEmployee)
                    query.AppendFormat(" {0} AND", filter3.Remove(filter3.Length - 4, 4));
               if (existCompanyFilter)
                    query.AppendFormat(" {0} AND", filter1);
               if (existfilteradditional)
                    query.AppendFormat(" {0} AND", filteradditional);
               if (existFieldFilter)
                    query.AppendFormat(" ({0}) AND", filter2.Remove(filter2.Length - 2, 2));
               if (existCompanyFilter || existFieldFilter || existfilteradditional || existfilterEmployee)
                    query.Remove(query.Length - 4, 4);
               if (select.IndexOf("distinct", StringComparison.OrdinalIgnoreCase) < 0)
               {
                    if (!string.IsNullOrEmpty(order))
                    {
                         query.AppendFormat(" Order by {0}", order);
                    }
                    else
                    {
                         query.AppendFormat(" Order by ");
                         foreach (var key in _catalog.KeyFields)
                              query.AppendFormat(" {0},", key.Key);
                         query.Remove(query.Length - 1, 1);
                    }
                    if (pageNumber > 0 && rowsOfPage > 0)
                    {
                         query.AppendFormat(" OFFSET ({0}-1)*{1} ROWS", pageNumber, rowsOfPage);
                         query.AppendFormat(" FETCH NEXT {0} ROWS ONLY", rowsOfPage);
                    }
               }
               return _Connection.GetDataTable(query, parameters);
          }

          #endregion DataTable

          #region Combos

          /// <summary>
          /// Gets the drop down.
          /// </summary>
          /// <param name="selectFields">The select fields.</param>
          /// <returns></returns>
          public ArrayList GetDropDown(string selectFields)
          {
               return GetDropDown(selectFields, "", true, "", "");
          }

          /// <summary>
          /// Gets the drop down.
          /// </summary>
          /// <param name="selectFields">The select fields.</param>
          /// <param name="specialFilter">The special filter.</param>
          /// <returns></returns>
          public ArrayList GetDropDown(string selectFields, string specialFilter)
          {
               return GetDropDown(selectFields, specialFilter, true, "", "");
          }

          /// <summary>
          /// Gets the drop down.
          /// </summary>
          /// <param name="selectFields">The select fields.</param>
          /// <param name="specialFilter">The special filter.</param>
          /// <param name="filterByKeyFields">if set to <c>true</c> [filter by key fields].</param>
          /// <returns></returns>
          public ArrayList GetDropDown(string selectFields, string specialFilter, bool filterByKeyFields)
          {
               return GetDropDown(selectFields, specialFilter, filterByKeyFields, "", "");
          }

          /// <summary>
          /// Gets the drop down.
          /// </summary>
          /// <param name="selectFields">The select fields.</param>
          /// <param name="specialFilter">The special filter.</param>
          /// <param name="filterByKeyFields">if set to <c>true</c> [filter by key fields].</param>
          /// <param name="principalFilter">The principal filter.</param>
          /// <returns></returns>
          public ArrayList GetDropDown(string selectFields, string specialFilter, bool filterByKeyFields, string principalFilter)
          {
               return GetDropDown(selectFields, specialFilter, filterByKeyFields, principalFilter, "");
          }

          /// <summary>
          /// Gets the drop down.
          /// </summary>
          /// <param name="selectFields">The select fields.</param>
          /// <param name="specialFilter">The special filter.</param>
          /// <param name="filterByKeyFields">if set to <c>true</c> [filter by key fields].</param>
          /// <param name="principalFilter">The principal filter.</param>
          /// <param name="order">The order.</param>
          /// <returns></returns>
          public ArrayList GetDropDown(string selectFields, string specialFilter, bool filterByKeyFields, string principalFilter, string order)
          {
               DataTable ldtDatos = GetDropDownValue(selectFields, specialFilter, filterByKeyFields, principalFilter, order);
               return CreateArrayList(ldtDatos);
          }

          /// <summary>
          /// Creates the array list.
          /// </summary>
          /// <param name="dataTable">The data table.</param>
          /// <returns></returns>
          protected ArrayList CreateArrayList(DataTable dataTable)
          {
               ArrayList lisDataDropDown = new ArrayList();
               foreach (DataRow row in dataTable.Rows)
               {
                    if (row.ItemArray.Length < 2)
                    {
                         //Pregunto si por lo menos existen dos elementos en la tabla
                         continue;
                    }
                    lisDataDropDown.Add(string.Format("{0},{1}", row[0].ToString(), row[1].ToString()));
               }
               return lisDataDropDown;
          }

          /// <summary>
          /// Gets the drop down value.
          /// </summary>
          /// <param name="selectFields">The select fields.</param>
          /// <param name="specialFilter">The special filter.</param>
          /// <param name="filterBykeyFields">if set to <c>true</c> [filter bykey fields].</param>
          /// <param name="principalFilter">The principal filter.</param>
          /// <param name="order">The order.</param>
          /// <returns></returns>
          public DataTable GetDropDownValue(string selectFields, string specialFilter, bool filterBykeyFields, string principalFilter, string order)
          {
               StringBuilder query;
               _catalog.Prefix = Prefix;
               _catalog.NumberTable = NumberTable;
               query = CreateQueryForDropDown(selectFields, specialFilter, filterBykeyFields, principalFilter, order);
               return _Connection.GetDataTable(query, $"{_catalog.Table}{_catalog.NumberTable}");
          }

          /// <summary>
          /// Gets the drop down collection.
          /// </summary>
          /// <param name="selectFields">The select fields.</param>
          /// <param name="specialFilter">The special filter.</param>
          /// <param name="filterByKeyFields">if set to <c>true</c> [filter by key fields].</param>
          /// <param name="principalFilter">The principal filter.</param>
          /// <param name="order">The order.</param>
          /// <returns></returns>
          public HashSet<string> GetDropDownCollection(string selectFields, string specialFilter, bool filterByKeyFields, string principalFilter, string order)
          {
               DataTable dataTable = null;
               HashSet<string> hashDropDown;
               //T loCatalogo;
               hashDropDown = new HashSet<string>();
               dataTable = GetDropDownValue(selectFields, specialFilter, filterByKeyFields, principalFilter, order);
               foreach (DataRow row in dataTable.Rows)
               {
                    if (row.ItemArray.Length < 2)
                         //Pregunto si por lo menos existen dos elementos en la tabla
                         continue;
                    hashDropDown.Add(string.Format("{0},{1}", row[0].ToString(), row[1].ToString()));
               }
               return hashDropDown;
          }
          //public List<xtsCombos> GetXtsCombo(string selectFields)
          //{
          //    return GetXtsCombo(selectFields, "", false, "", "");
          //}
          //public List<xtsCombos> GetXtsCombo(string selectFields, string specialFilter)
          //{
          //    return GetXtsCombo(selectFields, specialFilter, false, "", "");
          //}
          //public List<xtsCombos> GetXtsCombo(string selectFields, string specialFilter, bool filterByKeyFields)
          //{
          //    return GetXtsCombo(selectFields, specialFilter, filterByKeyFields, "", "");
          //}
          //public List<xtsCombos> GetXtsCombo(string selectFields, string specialFilter, bool filterByKeyFields, string principalFilter)
          //{
          //    return GetXtsCombo(selectFields, specialFilter, filterByKeyFields, principalFilter, "");
          //}

          //public List<xtsCombos> GetXtsCombo(string selectFields, string specialFilter, bool filterByKeyFields, string principalFilter, string order)
          //{
          //    StringBuilder query;
          //    _catalog.Prefix = Prefix;
          //    _catalog.NumberTable = NumberTable;
          //    query = CreateQueryForDropDown(selectFields, specialFilter, filterByKeyFields, principalFilter, order);
          //    return _Connection.GetGenericCollectionData<xtsCombos>(query).ToList();
          //}

          //public List<Parameters> GetCombo(string selectFields)
          //{
          //    return GetCombo(selectFields, "", false, "", "");
          //}
          //public List<Parameters> GetCombo(string selectFields, string specialFilter)
          //{
          //    return GetCombo(selectFields, specialFilter, false, "", "");
          //}
          //public List<Parameters> GetCombo(string selectFields, string specialFilter, bool filterByKeyFields)
          //{
          //    return GetCombo(selectFields, specialFilter, filterByKeyFields, "", "");
          //}
          //public List<Parameters> GetCombo(string selectFields, string specialFilter, bool filterByKeyFields, string principalFilter)
          //{
          //    return GetCombo(selectFields, specialFilter, filterByKeyFields, principalFilter, "");
          //}

          //public List<Parameters> GetCombo(string selectFields, string specialFilter, bool filterByKeyFields, string principalFilter, string order)
          //{
          //    StringBuilder query;
          //    _catalog.Prefix = Prefix;
          //    _catalog.NumberTable = NumberTable;
          //    query = CreateQueryForDropDown(selectFields, specialFilter, filterByKeyFields, principalFilter, order);
          //    return _Connection.GetGenericCollectionData<Parameters>(query).ToList();
          //}

          #endregion Combos

          #region Collections

          /// <summary>
          /// Regresa la lista de los elementos segun  el catalogo
          /// </summary>
          /// <param name="dataTable">El datatable debe contener los campos PK de la tabla para que pueda cargar los elementos</param>
          /// <returns></returns>
          public List<T> GetList(DataTable dataTable)
          {
               //Limitamos el tamaño de la lista
               T fixedCatalogelement;
               List<T> fixedCatalogElementsList;
               fixedCatalogElementsList = new List<T>(dataTable.Rows.Count);//Se estable el capacity para hacer mas eficiente la lista al crear los elementos              
               foreach (DataRow dataRow in dataTable.Rows)
               {
                    fixedCatalogelement = new T
                    {
                         _System = _System,
                         _Connection = (DataAccess)_System.Connection
                    };
                    fixedCatalogelement.EOF = true;
                    fixedCatalogelement._isNew = true;
                    fixedCatalogelement.Prefix = Prefix;
                    fixedCatalogelement.IsImplementation = IsImplementation;
                    fixedCatalogelement.LoadRowData(dataRow);
                    //Esto se pude mejorar solo recorriendo el datatable
                    //ya no es necesario hacer mas consultas a la base de datos
                    //for (liContador = 0; liContador < loCatalogoFijoElemento.ListaCamposLlave.Count; liContador++)
                    //     lasArgumentoCarga[liContador] = loRow[loCatalogoFijoElemento.ListaCamposLlave[liContador]];
                    //loCatalogoFijoElemento.Cargar(lasArgumentoCarga);
                    //if (!loCatalogoFijoElemento.EOF)
                    fixedCatalogElementsList.Add(fixedCatalogelement);
               }
               return fixedCatalogElementsList;
          }

          /// <summary>
          /// Gets the collection.
          /// </summary>
          /// <param name="dataTable">The data table.</param>
          /// <returns></returns>
          public virtual HashSet<T> GetCollection(DataTable dataTable)
          {
               //Limitamos el tamaño de la lista
               T fixedCatalogelement;
               HashSet<T> fixedCatalogElementsList = new HashSet<T>();//Se estable el capacity para hacer mas eficiente la lista al crear los elementos
               foreach (DataRow dataRow in dataTable.Rows)
               {
                    fixedCatalogelement = new T
                    {
                         _System = _System,
                         _Connection = (DataAccess)_System.Connection
                    };
                    if (string.IsNullOrEmpty(fixedCatalogelement.Table))
                    {
                         fixedCatalogelement.Level = _catalog.Level;
                         fixedCatalogelement.Table = _catalog.Table;
                         fixedCatalogelement.Properties = new Dictionary<string, Property>(_catalog.Properties);
                         fixedCatalogelement.KeyFields = new Dictionary<string, object>(_catalog.KeyFields);
                       
                    }
                    fixedCatalogelement.IsImplementation = IsImplementation;
                    fixedCatalogelement.Prefix = Prefix;
                    fixedCatalogelement.EOF = true;
                    fixedCatalogelement._isNew = true;
                    fixedCatalogelement.LoadRowData(dataRow);
                   
                    fixedCatalogElementsList.Add(fixedCatalogelement);
               }
               return fixedCatalogElementsList;
          }
          public virtual Pagination<T> GetCollectionPagination(DataTable dataTable)
          {
               //Limitamos el tamaño de la lista
               T fixedCatalogelement;
               HashSet<T> fixedCatalogElementsList = new HashSet<T>();//Se estable el capacity para hacer mas eficiente la lista al crear los elementos
               foreach (DataRow dataRow in dataTable.Rows)
               {
                    fixedCatalogelement = new T
                    {
                         _System = _System,
                         _Connection = (DataAccess)_System.Connection
                    };
                    if (string.IsNullOrEmpty(fixedCatalogelement.Table))
                    {
                         fixedCatalogelement.Level = _catalog.Level;
                         fixedCatalogelement.Table = _catalog.Table;
                         fixedCatalogelement.Properties = new Dictionary<string, Property>(_catalog.Properties);
                         fixedCatalogelement.KeyFields = new Dictionary<string, object>(_catalog.KeyFields);                       
                    }
                    fixedCatalogelement.IsImplementation = IsImplementation;
                    fixedCatalogelement.Prefix = Prefix;
                    fixedCatalogelement.EOF = true;
                    fixedCatalogelement._isNew = true;
                    fixedCatalogelement.LoadRowData(dataRow);
                  
                    fixedCatalogElementsList.Add(fixedCatalogelement);
               }
               return new Pagination<T>() { PageNumber = dataTable.GetValue<int>("PageNumber"), RowsOfPage = dataTable.GetValue<int>("RowsOfPage"), TotalRows = dataTable.GetValue<int>("TotalRows"), Data = fixedCatalogElementsList.ToList() };
          }


          /// <summary>
          /// Gets the list.
          /// </summary>
          /// <param name="specialFilter">The special filter.</param>
          /// <returns></returns>
          public List<T> GetList(StringBuilder specialFilter)
          {
               return GetList(specialFilter, true, null);
          }

          /// <summary>
          /// Gets the list.
          /// </summary>
          /// <param name="specialFilter">The special filter.</param>
          /// <param name="includeInsternalFilterByCompany">if set to <c>true</c> [include insternal filter by company].</param>
          /// <returns></returns>
          public List<T> GetList(StringBuilder specialFilter, bool includeInsternalFilterByCompany)
          {
               return GetList(specialFilter, includeInsternalFilterByCompany, null);
          }

          /// <summary>
          /// Funcion que regresa una lista de T (Catalogo)
          /// </summary>
          /// <param name="specialFilter">Filtro espaecial</param>
          /// <param name="includeInsternalFilterByCompany">Habilita si filtra por empresa o no</param>
          /// <param name="order">The ps orden.</param>
          /// <returns></returns>
          public List<T> GetList(StringBuilder specialFilter, bool includeInsternalFilterByCompany, string order)
          {
               return GetList(specialFilter.ToString(), includeInsternalFilterByCompany, order, null);
          }

          /// <summary>
          /// Gets the list.
          /// </summary>
          /// <param name="specialFilter">The special filter.</param>
          /// <returns></returns>
          public List<T> GetList(string specialFilter)
          {
               return GetList(specialFilter, true, null, null);
          }

          /// <summary>
          /// Gets the list.
          /// </summary>
          /// <param name="specialFilter">The special filter.</param>
          /// <param name="includeInsternalFilterByCompany">if set to <c>true</c> [include insternal filter by company].</param>
          /// <returns></returns>
          public List<T> GetList(string specialFilter, bool includeInsternalFilterByCompany)
          {
               return GetList(specialFilter, includeInsternalFilterByCompany, null, null);
          }

          /// <summary>
          /// Funcion que regresa una lista de T (Catalogo)
          /// </summary>
          /// <param name="specialFilter">Filtro espaecial</param>
          /// <param name="includeInsternalFilterByCompany">Habilita si filtra por empresa o no</param>
          /// <param name="order">The ps orden.</param>
          /// <returns></returns>
          public List<T> GetList(string specialFilter, bool includeInsternalFilterByCompany, string order, List<ParameterSql> parameters)
          {
               return GetList(GetDataTable(specialFilter, includeInsternalFilterByCompany, order, parameters));
          }

          /// <summary>
          /// Gets the collection.
          /// </summary>
          /// <param name="pageNumber">The page number.</param>
          /// <param name="pageSize">Size of the page.</param>
          /// <returns></returns>
          public List<T> GetCollection(int pageNumber, int rowsOfPage) => GetCollection(GetDataTable(pageNumber, rowsOfPage)).ToList();

          /// <summary>
          /// Gets the collection.
          /// </summary>
          /// <returns></returns>
          public HashSet<T> GetCollection() => GetCollection(GetDataTable("", true, null, null));

          /// <summary>
          /// Gets the collection.
          /// </summary>
          /// <param name="filter">The ps filtro especial.</param>
          /// <returns></returns>
          public HashSet<T> GetCollection(string filter) => GetCollection(GetDataTable(filter, true, null, null));

          /// <summary>
          /// Gets the collection search by field.
          /// </summary>
          /// <param name="filter">The filter.</param>
          /// <returns></returns>
          public HashSet<T> GetCollectionSearchByField(string filter) => GetCollection(GetDataTableSearchByField("", filter, "", ""));
          public HashSet<T> GetCollectionSearchByField(string filter, int pageNumber, int rowsOfPage) => GetCollection(GetDataTableSearchByField(filter, pageNumber, rowsOfPage));
          public HashSet<T> GetCollectionSearchByField(string filter, int pageNumber, int rowsOfPage, string order) => GetCollection(GetDataTableSearchByField(filter, pageNumber, rowsOfPage, order));
          public HashSet<T> GetCollectionSearchByField(string filter, string filteradditional) => GetCollection(GetDataTableSearchByField("", filter, filteradditional, ""));
          public HashSet<T> GetCollectionSearchByField(string filter, string filteradditional, int pageNumber, int rowsOfPage) => GetCollection(GetDataTableSearchByField("", filter, filteradditional, "", false, pageNumber, rowsOfPage));
          public HashSet<T> GetCollectionSearchByField(string filter, string filteradditional, bool pbFilterUser, int pageNumber, int rowsOfPage) => GetCollection(GetDataTableSearchByField("", filter, filteradditional, "", pbFilterUser, pageNumber, rowsOfPage));
          public HashSet<T> GetCollectionSearchByField(string filter, string filteradditional, string order) => GetCollection(GetDataTableSearchByField("", filter, filteradditional, order));
          public HashSet<T> GetCollectionSearchByField(string filter, string filteradditional, string order, int pageNumber, int rowsOfPage) => GetCollection(GetDataTableSearchByField("", filter, filteradditional, order, false, pageNumber, rowsOfPage));
          public HashSet<T> GetCollectionSearchByField(string select, string filter, string filteradditional, string order) => GetCollection(GetDataTableSearchByField(select, filter, filteradditional, order));
          public HashSet<T> GetCollectionSearchByField(string select, string filter, string filteradditional, string order, int pageNumber, int rowsOfPage) => GetCollection(GetDataTableSearchByField(select, filter, filteradditional, order, false, pageNumber, rowsOfPage));

          public HashSet<T> GetCollection(string field, string value)
          {
               StringBuilder query;
               string select;

               if (!_catalog.Properties.ContainsKey(field.ToUpper()))
                    throw new CoreException(Errors.E00000086);
               List<ParameterSql> parameter = new List<ParameterSql>() { new ParameterSql($"@{field}", value) };
               query = new StringBuilder();
               select = _catalog._fields.ToString();
               _catalog.Prefix = Prefix;
               _catalog.NumberTable = NumberTable;
               query.AppendFormat("Select {0} from {1}", select, _catalog.TableName());
               query.AppendFormat(" where cast({0} as varchar) = cast(@{0} as varchar)", field);
               return GetCollection(_Connection.GetDataTable(query, parameter));
          }


          public HashSet<T> GetCollectionPagination(string field, string value, int pageNumber, int rowsOfPage)
          {
               StringBuilder query;
               string select;

               if (!_catalog.Properties.ContainsKey(field.ToUpper()))
                    throw new CoreException(Errors.E00000086);
               List<ParameterSql> parameter = new List<ParameterSql>() { new ParameterSql($"@{field}", value) };
               query = new StringBuilder();
               select = _catalog._fields.ToString();
               _catalog.Prefix = Prefix;
               _catalog.NumberTable = NumberTable;
               query.AppendFormat("Select {0} from {1}", select, _catalog.TableName());
               query.AppendFormat(" where cast({0} as varchar) = cast(@{0} as varchar) ", field);
               query.AppendFormat(" order by");
               foreach (var key in _catalog.KeyFields)
                    query.AppendFormat(" {0},", key.Key);
               query.Remove(query.Length - 1, 1);
               if (pageNumber > 0 && rowsOfPage > 0)
               {
                    query.AppendFormat(" OFFSET ({0}-1)*{1} ROWS", pageNumber, rowsOfPage);
                    query.AppendFormat(" FETCH NEXT {0} ROWS ONLY", rowsOfPage);
               }
               return GetCollection(_Connection.GetDataTable(query, parameter));
          }

          /// <summary>
          /// Gets the collection.
          /// </summary>
          /// <param name="filter">The ps filtro especial.</param>
          /// <param name="isByCompany">if set to <c>true</c> [pb incluye filtro internopor empresa].</param>
          /// <returns></returns>
          public HashSet<T> GetCollection(string filter, bool isByCompany) => GetCollection(GetDataTable(filter, isByCompany, null, null));

          public HashSet<T> GetCollection(string filter, int pageNumber, int rowsOfPage) => GetCollection(GetDataTable(filter, pageNumber, rowsOfPage));
          public HashSet<T> GetCollection(string filter, List<ParameterSql> parameters, int pageNumber, int rowsOfPage) => GetCollection(GetDataTable(filter, parameters, pageNumber, rowsOfPage));
          public Pagination<T> GetCollectionPagination(string filter, int pageNumber, int rowsOfPage) => GetCollectionPagination(GetDataTablePagination(filter, pageNumber, rowsOfPage));
          public Pagination<T> GetCollectionPagination(string filter, List<ParameterSql> parameters, int pageNumber, int rowsOfPage) => GetCollectionPagination(GetDataTablePagination(filter, parameters, pageNumber, rowsOfPage));
          public Pagination<T> GetCollectionPagination(int pageNumber, int rowsOfPage) => GetCollectionPagination(GetDataTablePagination(null, null, pageNumber, rowsOfPage));

          /// <summary>
          /// GetCollection
          /// </summary>
          /// <param name="filter"></param>
          /// <param name="isByCompany"></param>
          /// <param name="parameters"></param>
          /// <returns></returns>
          public HashSet<T> GetCollection(string filter, bool isByCompany, List<ParameterSql> parameters) => GetCollection(GetDataTable(filter, isByCompany, null, parameters));
          /// <summary>
          /// GetCollection
          /// </summary>
          /// <param name="filter"></param>
          /// <param name="isByCompany"></param>
          /// <param name="order"></param>
          /// <returns></returns>
          public HashSet<T> GetCollection(string filter, bool isByCompany, string order) => GetCollection(GetDataTable(filter, isByCompany, order, null));

          /// <summary>
          /// Gets the collection.
          /// </summary>
          /// <param name="filter">The filter.</param>
          /// <param name="isByCompany">if set to <c>true</c> [is by company].</param>
          /// <param name="order">The order.</param>
          /// <returns></returns>
          public HashSet<T> GetCollection(string filter, bool isByCompany, string order, List<ParameterSql> parameters) => GetCollection(GetDataTable(filter, isByCompany, order, parameters));

          /// <summary>
          /// GetCollection
          /// </summary>
          /// <param name="select"></param>
          /// <param name="filter"></param>
          /// <param name="isByCompany"></param>
          /// <param name="order"></param>
          /// <returns></returns>
          public HashSet<T> GetCollection(string select, string filter, bool isByCompany, string order) => GetCollection(GetDataTable(new StringBuilder(select), new StringBuilder(filter), isByCompany, new StringBuilder(order), null));

          public HashSet<T> GetCollection(StringBuilder select, StringBuilder filter, bool isByCompany, StringBuilder order) => GetCollection(GetDataTable(select, filter, isByCompany, order, null));

          public HashSet<T> GetCollection(StringBuilder select, StringBuilder filter, bool isByCompany, StringBuilder order, List<ParameterSql> parameters) => GetCollection(GetDataTable(select, filter, isByCompany, null, order, parameters));
          /// <summary>
          /// GetCollection
          /// </summary>
          /// <param name="select"></param>
          /// <param name="filter"></param>
          /// <param name="isByCompany"></param>
          /// <param name="order"></param>
          /// <param name="parameters"></param>
          /// <returns></returns>
          public HashSet<T> GetCollection(string select, string filter, bool isByCompany, string order, List<ParameterSql> parameters) => GetCollection(GetDataTable(new StringBuilder(select), new StringBuilder(filter), isByCompany, new StringBuilder(), new StringBuilder(order), parameters));
          /// <summary>
          /// Gets the generic table.
          /// </summary>
          /// <returns></returns>


          /// <summary>
          /// Regresas the coleccion en base a campo.
          /// </summary>
          /// <param name="fields">The ps campos.</param>
          /// <param name="specialFilter">The ps filtro especial.</param>
          /// <returns></returns>
          public HashSet<string> GetFieldBasedCollection(string fields, StringBuilder specialFilter)
          {
               return GetFieldBasedCollection(fields, specialFilter.ToString());
          }

          /// <summary>
          /// Regresas the coleccion en base a campo.
          /// </summary>
          /// <param name="fields">The ps campos.</param>
          /// <param name="specialFilter">The ps filtro especial.</param>
          /// <returns></returns>
          public HashSet<string> GetFieldBasedCollection(string fields, string specialFilter)
          {
               DataTable dataTable = null;
               HashSet<string> hashDropDown;
               StringBuilder query;
               hashDropDown = new HashSet<string>();
               query = new StringBuilder();
               _catalog.Prefix = Prefix;
               _catalog.NumberTable = NumberTable;
               if (string.IsNullOrEmpty(fields))
               {
                    fields = _catalog.KeyFields.First().Key;
               }
               query.AppendFormat("Select {0} from {1} where {2} = {3}", fields, _catalog.TableName(), _catalog.KeyFields.First().Key, _System.Session.Company.Number);
               if (!string.IsNullOrEmpty(specialFilter))
               {
                    query.AppendFormat(" and {0}", specialFilter);
               }
               dataTable = _Connection.GetDataTable(query, $"{_catalog.Table}{_catalog.NumberTable}");
               foreach (DataRow loFila in dataTable.Rows)
               {
                    hashDropDown.Add(Convert.ToString(loFila[fields]));
               }
               return hashDropDown;
          }

          #endregion Collections

          /// <summary>
          /// Armas the consulta para combo.
          /// </summary>
          /// <param name="selectFields">The ps select campos.</param>
          /// <param name="specialFilter">The ps filtro especial.</param>
          /// <param name="filterByKeyFields">if set to <c>true</c> [pb filtrarpor campos llave].</param>
          /// <param name="principalFilter">The ps filtro principal.</param>
          /// <param name="order">The ps orden.</param>
          /// <returns></returns>
          private StringBuilder CreateQueryForDropDown(string selectFields, string specialFilter, bool filterByKeyFields, string principalFilter, string order)
          {
               StringBuilder query;
               query = new StringBuilder();
               query.AppendFormat("Select {0} from {1} ", selectFields, _catalog.TableName());

               if (filterByKeyFields || !string.IsNullOrEmpty(principalFilter) || !string.IsNullOrEmpty(specialFilter))
               {
                    query.AppendFormat(" where ");
                    if (filterByKeyFields)
                         query.AppendFormat(" {0} = {1}", _catalog.KeyFields.First().Key, _System.Session.Company.Number);
                    else if (!string.IsNullOrEmpty(principalFilter))
                         query.AppendFormat(" {0}", principalFilter);
                    if (!filterByKeyFields && string.IsNullOrEmpty(principalFilter))
                         query.AppendFormat(" {0}", specialFilter);
                    if (!string.IsNullOrEmpty(specialFilter))
                         query.AppendFormat(" and {0}", specialFilter);
               }
               if (!string.IsNullOrEmpty(order))
                    query.AppendFormat(" order by {0}", order);
               return query;
          }

          #endregion Methods for FixedCatalogElements or object list
     }
}