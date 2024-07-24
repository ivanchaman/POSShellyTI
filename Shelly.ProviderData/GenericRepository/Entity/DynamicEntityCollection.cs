

namespace Shelly.ProviderData.GenericRepository.Entity
{
    /// <summary>
    /// DynamicCatalogElements
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public class DynamicEntityCollection<T> : StaticEntityCollection<T> where T : DynamicEntity, new()
    {
        #region Builders

        /// <summary>
        /// Constructor con la variable del sistema
        /// </summary>
        /// <param name="system"></param>
        public DynamicEntityCollection(IBaseSystem system) : base(system)
        {
            _System = system;
            _Connection = (DataAccess)system.Connection;
            _catalog = new T
            {
                _System = system
            };
            _catalog.LoadProperties();
            _catalog.CreateStringFieldsComaSeparated();
        }
        public DynamicEntityCollection(IBaseSystem system, string prefix) : base(system)
        {
            _System = system;
            _Connection = (DataAccess)system.Connection;
            _catalog = new T
            {
                _System = system,
                Prefix = prefix
            };
            Prefix = prefix;
            _catalog.LoadProperties();
            _catalog.CreateStringFieldsComaSeparated();
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicEntityCollection{T}"/> class.
        /// </summary>
        /// <param name="system">system.</param>
        /// <param name="catalog">pocatalogo.</param>
        public DynamicEntityCollection(IBaseSystem system, T catalog) : base(system, catalog)
        {
            _System = system;
            _catalog.LoadProperties();
            _catalog.CreateStringFieldsComaSeparated();
        }

        /// <summary>
        /// DynamicCatalogElements
        /// </summary>
        public DynamicEntityCollection() : base()
        {
        }

        #endregion Builders

        #region Methods for DynamicCatalogElements or object lists

        /// <summary>
        /// Inserta masivamente la informacion de la tabla
        /// TODO: Hacer un bulkcopy sin las bitacoras para cuando se necesita almacenar un conjunto masivo de informacion en la base de datos
        /// </summary>
        /// <param name="objectEnum">The po objeto.</param>
        public void MassiveInsert(IEnumerable<T> objectEnum)
        {
            _System.Connection.InsertBulkCopy(objectEnum, _catalog.Table);
        }

        /// <summary>
        /// GetDataTable
        /// </summary>
        /// <param name="selectFields"></param>
        /// <returns></returns>
        public DataTable GetDataTable(string selectFields)
        {
            return GetDataTable(selectFields, null, true, null);
        }

        /// <summary>
        /// GetDataTable
        /// </summary>
        /// <param name="selectFields"></param>
        /// <param name="specialFilter"></param>
        /// <returns></returns>
        public DataTable GetDataTable(string selectFields, string specialFilter)
        {
            return GetDataTable(selectFields, specialFilter, true, null);
        }

        /// <summary>
        /// GetDataTable
        /// </summary>
        /// <param name="selectFields"></param>
        /// <param name="specialFilter"></param>
        /// <param name="filterByKeyFields"></param>
        /// <returns></returns>
        public DataTable GetDataTable(string selectFields, string specialFilter, bool filterByKeyFields)
        {
            return GetDataTable(selectFields, specialFilter, filterByKeyFields, null);
        }

        /// <summary>
        /// Funcion que regresa un data table del catalgo
        /// </summary>
        /// <param name="selectFields">Campos </param>
        /// <param name="specialFilter">Filtro especial</param>
        /// <param name="filterByKeyFields">if set to <c>true</c> [pb filtrarpor campos llave].</param>
        /// <param name="principalFilter">The ps filtro principal.</param>
        /// <returns></returns>
        public DataTable GetDataTable(string selectFields, string specialFilter, bool filterByKeyFields, string principalFilter)
        {
            StringBuilder query;

            query = new StringBuilder();
            if (string.IsNullOrEmpty(selectFields))
                selectFields = _catalog._fields.ToString();
            query.AppendFormat("Select {0} from {1}  ", selectFields, _catalog.TableName());
            if (filterByKeyFields)
                query.AppendFormat("where {0} = {1}", _catalog.KeyFields.First().Key, _System.Session.Company.Number);
            else if (!string.IsNullOrEmpty(principalFilter))
                query.AppendFormat("where {0}", principalFilter);
            if (!string.IsNullOrEmpty(specialFilter))
                query.AppendFormat(" and {0}", specialFilter);
            return _Connection.GetDataTable(query, _catalog.Table);

        }

        /// <summary>
        /// Regresas the data table metadatos.
        /// </summary>
        /// <param name="gridCatalog">The po catalogo.</param>
        /// <param name="filter">The po catalogo.</param>
        /// <returns></returns>
        public DataTable GetMetaDatadataDataTable(SubGrid gridCatalog, string filter)
        {
            string selectFields;
            StringBuilder query;
            StringBuilder company;
            StringBuilder yearPeriodAccount;
            StringBuilder order;
            bool containsFilter;
            query = new StringBuilder();
            selectFields = _catalog._fields.ToString();
            query.AppendFormat("Select {0} from {1}  ", selectFields, _catalog.TableName());
            if (gridCatalog != null)
            {
                query.AppendFormat("where ");
                foreach (KeyValuePair<string, object> fields in gridCatalog.ForeignKeysValue)
                {
                    query.AppendFormat(" {0} = '{1}' AND", fields.Key, fields.Value);
                }
                query.Remove(query.Length - 3, 3);
                if (!string.IsNullOrEmpty(filter))
                    query.AppendFormat(" and {0}", filter);
            }
            else
            {
                company = new StringBuilder();
                yearPeriodAccount = new StringBuilder();
                order = new StringBuilder();
                foreach (KeyValuePair<string, Property> property in _catalog.Properties)
                {
                    if (property.Value.IsVirtualField)
                        continue;
                    if (property.Value.IsCompanyField)
                        company.AppendFormat(" {0} = '{1}' ", property.Key, _System.Session.Company.Number);

                }
                containsFilter = false;
                if (company.Length > 0 && yearPeriodAccount.Length > 0)
                {
                    query.AppendFormat(" where {0} and {1}", company, yearPeriodAccount);
                    containsFilter = true;
                }
                else if (company.Length > 0 && yearPeriodAccount.Length == 0)
                {
                    query.AppendFormat(" where {0} ", company, yearPeriodAccount);
                    containsFilter = true;
                }
                else if (company.Length == 0 && yearPeriodAccount.Length > 0)
                {
                    query.AppendFormat(" where {0} ", yearPeriodAccount);
                    containsFilter = true;
                }
                if (containsFilter)
                {
                    if (!string.IsNullOrEmpty(filter))
                        query.AppendFormat(" and {0}", filter);
                }
                else
                {
                    if (!string.IsNullOrEmpty(filter))
                        query.AppendFormat(" Where {0}", filter);
                }
                foreach (KeyValuePair<string, Property> property in _catalog.Properties)
                {
                    if (property.Value.IsVirtualField)
                        continue;
                    if (property.Value.IsOrder)
                    {
                        order.AppendFormat(" {0},", property.Key);
                    }
                }
                if (order.Length > 0)
                    query.AppendFormat(" order by {0}", order.Remove(order.Length - 1, 1));
            }
            return _Connection.GetDataTable(query, _catalog.Table);
        }

        /// <summary>
        /// Gets the data to collection.
        /// </summary>
        /// <returns></returns>
        public List<List<Property>> GetDataToCollection(string filter, int pageNumber, int rowsOfPage)
        {
            Dictionary<int, List<Property>> dictionary;
            List<Property> list;
            DataTable table = GetDataTableSearchByField(filter, pageNumber, rowsOfPage);
            int index = 0;
            dictionary = new Dictionary<int, List<Property>>();
            foreach (DataRow dataRow in table.Rows)
            {
                list = new List<Property>();
                _catalog.LoadRowData(dataRow);
                foreach (KeyValuePair<string, Property> property in _catalog.Properties)
                {
                    if (property.Value.IsVirtualField)
                        continue;
                    list.Add(new Property()
                    {
                        FieldId = property.Value.FieldId,
                        Description = property.Value.Description,
                        NameQl = property.Key,
                        ValueQl = Convert.ToString(dataRow[property.Key])
                    });

                }
                foreach (KeyValuePair<string, Property> property in _catalog.Properties)
                {
                    if (!property.Value.IsVirtualField)
                        continue;
                    _catalog.LoadFieldVirtualValuesMetadata();
                    list.Add(new Property()
                    {
                        FieldId = property.Value.FieldId,
                        Description = property.Value.Description,
                        NameQl = property.Key,
                        ValueQl = Convert.ToString(_catalog.GetPropertyValue(property.Key))
                    });
                }
                dictionary.Add(index, list);
                index++;
            }
            return dictionary.Select(pro => pro.Value).ToList();
        }

        /// <summary>
        /// Gets the collection.
        /// </summary>
        /// <param name="specialFilter">The special filter.</param>
        /// <returns></returns>
        public HashSet<T> GetCollection(StringBuilder specialFilter)
        {
            return GetCollection(GetDataTable(specialFilter.ToString(), true, null));
        }

        /// <summary>
        /// Gets the collection.
        /// </summary>
        /// <param name="specialFilter">The special filter.</param>
        /// <param name="includeInternalFilterByCompany">if set to <c>true</c> [include internal filter by company].</param>
        /// <returns></returns>
        public HashSet<T> GetCollection(StringBuilder specialFilter, bool includeInternalFilterByCompany)
        {
            return GetCollection(GetDataTable(specialFilter.ToString(), includeInternalFilterByCompany, null));
        }

        /// <summary>
        /// Regresas the coleccion.
        /// </summary>
        /// <param name="specialFilter">The ps filtro especial.</param>
        /// <param name="includeInternalFilterByCompany">if set to <c>true</c> [pb incluye filtro internopor empresa].</param>
        /// <param name="order">The ps orden.</param>
        /// <returns></returns>
        public HashSet<T> GetCollection(StringBuilder specialFilter, bool includeInternalFilterByCompany, string order)
        {
            return GetCollection(GetDataTable(specialFilter.ToString(), includeInternalFilterByCompany, order));
        }

        /// <summary>
        /// Gets the drop down collection.
        /// </summary>
        /// <param name="selectFields">The select fields.</param>
        /// <param name="specialFilter">The special filter.</param>
        /// <returns></returns>

        /// <summary>
        /// Armas the consulta para combo.
        /// </summary>
        /// <param name="selectFields">The ps select campos.</param>
        /// <param name="specialFilter">The ps filtro especial.</param>
        /// <param name="filterByKeyFields">if set to <c>true</c> [pb filtrarpor campos llave].</param>
        /// <param name="principalFilter">The ps filtro principal.</param>
        /// <param name="order">The ps orden.</param>
        /// <returns></returns>
        private StringBuilder CreateQueryForDropdownList(string selectFields, string specialFilter, bool filterByKeyFields, string principalFilter, string order)
        {
            StringBuilder query;
            query = new StringBuilder();
            query.AppendFormat("Select {0} from {1}", selectFields, _catalog.TableName());
            if (filterByKeyFields)
                query.AppendFormat(" where {0} = {1}", _catalog.KeyFields.First().Key, _System.Session.Company.Number);
            else if (!string.IsNullOrEmpty(principalFilter))
                query.AppendFormat(" where {0}", principalFilter);
            if (!string.IsNullOrEmpty(specialFilter))
                query.AppendFormat(" and {0}", specialFilter);
            if (!string.IsNullOrEmpty(order))
                query.AppendFormat(" order by {0}", order);
            return query;
        }

        /// <summary>
        /// Regresas the combo metadato.
        /// </summary>
        /// <param name="dropDown">The po combo.</param>
        /// <returns></returns>
        public HashSet<string> GetMetaDataDropDownList(DropDown dropDown)
        {
            DataTable dataTable = null;
            HashSet<string> dropDownList;
            StringBuilder query;
            //T loCatalogo;
            dropDownList = new HashSet<string>();
            query = CreateQueryForDropDownMetadata(dropDown);
            dataTable = _Connection.GetDataTable(query, _catalog.Table);
            foreach (DataRow loFila in dataTable.Rows)
            {
                if (loFila.ItemArray.Length < 2)
                    //Pregunto si por lo menos existen dos elementos en la tabla
                    continue;
                dropDownList.Add(string.Format("{0},{1}", Convert.ToString(loFila[0]), Convert.ToString(loFila[1])));
            }
            return dropDownList;
        }

        /// <summary>
        /// Armas the consulta para combo metadato.
        /// </summary>
        /// <param name="dropDown">The po combo.</param>
        /// <returns></returns>
        private StringBuilder CreateQueryForDropDownMetadata(DropDown dropDown)
        {
            StringBuilder query;
            query = new StringBuilder();
            //TODO:Hacer validaciones sobre los campos para que se arme bien la consulta
            query.AppendFormat("Select distinct {0},{1} from {2}", dropDown.ValueField, dropDown.DescriptionField, _catalog.TableName(false, false, true, dropDown.TableName));
            if (!string.IsNullOrEmpty(dropDown.CompanyField))
            {
                query.AppendFormat(" where {0} in(0, {1})", dropDown.CompanyField, _System.Session.Company.Number);
                if (!string.IsNullOrEmpty(dropDown.Filter))
                    query.AppendFormat("  and {0}", dropDown.Filter);
            }
            else if (!string.IsNullOrEmpty(dropDown.Filter))
            {
                query.AppendFormat("  where {0}", dropDown.Filter);
            }
            if (!string.IsNullOrEmpty(dropDown.Order))
                query.AppendFormat(" order by {0}", dropDown.Order);
            return query;
        }

        #endregion Methods for DynamicCatalogElements or object lists
    }
}