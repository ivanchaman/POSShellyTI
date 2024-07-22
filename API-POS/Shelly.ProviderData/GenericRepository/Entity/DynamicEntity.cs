using Shelly.Abstractions.Constants;
using Shelly.ProviderData.Helper;

namespace Shelly.ProviderData.GenericRepository.Entity
{
    /// <summary>
    /// Clase Metadatos. esta clase nos permite el manejo de los metatados sin la necesidad de intanciar
    /// mas que los campos de la tabla. Algo que se puede hacer es validar o visualizar los campos antes de cargarlos.
    /// Los campos se cargaran desde la tabla de metadatos y se verificaran con la estrucutra de las tablas y si existen alguna diferencia
    /// se hara una validacion. La clase se separara de catalogo fijo elementos ya que la clase base se encargara de generar las bitacora sy
    /// validaciones basicas que s ehace para los catalogos.
    /// </summary>
    [Serializable]
    public class DynamicEntity : StaticEntity
    {
        #region Properties

        /// <summary>
        /// Identificador de la tabla en metadatos
        /// </summary>
        public int TableId { get; set; }

        /// <summary>
        /// descripcion del catalogo
        /// </summary>
        public string TableDescription { get; set; }

        /// <summary>
        /// ContainsCompanyField
        /// </summary>
        public bool ContainsCompanyField { get; set; }

        /// <summary>
        /// CopyInOtherCompanies
        /// </summary>
        public bool CopyInOtherCompanies { get; set; }
        public int PageNumber { get; set; }
        public int RowsOfPage { get; set; }
        #endregion Properties

        #region Properties for the controls manage

        /// <summary>
        /// Propiedades para generar el grid
        /// </summary>
        public Grid GridData { get; set; }

        /// <summary>
        /// Propiedades para el manejo de los controles para la interfaz
        /// </summary>
        public HashSet<Button> Buttons { get; set; }

        /// <summary>
        /// Propiedades para el manejor de las pestañas en la pagina
        /// </summary>
        public Panel PanelData { get; set; }

        /// <summary>
        /// Propieades dinamicas para la interfaz.
        /// </summary>
        public Dictionary<string, Control> PropertiesUI { get; set; }

        /// <summary>
        /// Gets or sets the grid hijos.
        /// </summary>
        /// <value>
        /// The grid hijos.
        /// </value>
        public SubCatalogs SubCatalogsData { get; set; }

        #endregion Properties for the controls manage

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
                AddPropertyValue(binder.Name, default);
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

        #region Function for property management

        /// <summary>
        /// Establecers the valor propiedad.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="property">The ps propiedad.</param>
        /// <param name="value">The po valor.</param>
        public void SetValue<T>(string property, T value)
        {
            SetPropertyValue(property, value);
        }

        /// <summary>
        /// Obteners the valor.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="property">The ps propiedad.</param>
        /// <returns></returns>
        public T GetValue<T>(string property)
        {
            return GetPropertyValue<T>(property);
        }

        #endregion Function for property management

        #region Builders

        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicEntity"/> class.
        /// </summary>
        /// <param name="system">Variable del sistema</param>
        public DynamicEntity(IBaseSystem system) : base(system)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicEntity"/> class.
        /// </summary>
        /// <param name="system">Variable del sistema</param>
        /// <param name="prefix">prefix</param>
        public DynamicEntity(IBaseSystem system, string prefix) : base(system, prefix)
        {
        }
        /// <summary>
        ///  Initializes a new instance of the <see cref="DynamicEntity"/> class.
        /// </summary>
        /// <param name="system"></param>
        /// <param name="prefix"></param>
        /// <param name="numbertable"></param>
        public DynamicEntity(IBaseSystem system, string prefix, string numbertable) : base(system, prefix, numbertable)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicEntity"/> class.
        /// </summary>
        /// <param name="catalog">The ps catalogo.</param>
        /// <param name="system">The po sistema.</param>
        /// <param name="loadInterface">if set to <c>true</c> [pb carga interfaz].</param>
        public DynamicEntity(string catalog, IBaseSystem system, bool loadInterface) : base(system)
        {
            //Estos se debe de cargar dinamicamente
            using (var connection = new ConnectionHandler(Connection))
            {
                InternalBuilder(catalog, -1, loadInterface);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicEntity"/> class.
        /// </summary>
        /// <param name="catalog">The catalog.</param>
        /// <param name="system">The base system.</param>
        public DynamicEntity(string catalog, IBaseSystem system) : base(system)
        {
            //Estos se debe de cargar dinamicamente
            using (var connection = new ConnectionHandler(Connection))
            {
                InternalBuilder(catalog, -1, false);

            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicEntity"/> class.
        /// </summary>
        /// <param name="tableId">The pi tabla identifier.</param>
        /// <param name="system">The po sistema.</param>
        public DynamicEntity(int tableId, IBaseSystem system) : base(system)
        {
            using (var connection = new ConnectionHandler(Connection))
            {
                InternalBuilder("", tableId, false);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicEntity"/> class.
        /// </summary>
        /// <param name="tableId">The pi tabla identifier.</param>
        /// <param name="system">The po sistema.</param>
        /// <param name="loadInterface">if set to <c>true</c> [pb carga interfaz].</param>
        public DynamicEntity(int tableId, IBaseSystem system, bool loadInterface) : base(system)
        {
            using (var connection = new ConnectionHandler(Connection))
            {
                InternalBuilder("", tableId, loadInterface);
            }
        }

        /// <summary>
        /// This constructor just works off the internal dictionary and any
        /// public properties of this object.
        ///
        /// Note you can subclass Expando.
        /// </summary>
        public DynamicEntity()
        {
            Initialize(this);
        }

        #endregion Builders

        #region Funciones

        /// <summary>
        /// Cargas the controles metadatos.
        /// </summary>
        private void LoadMetadataControls()
        {
            LoadGridColumns();
            LoadButtons();
            LoadTabs();
            LoadControls();
            LoadSubTables();
            LoadControlByTab();
        }

        /// <summary>
        /// Constructors the interno.
        /// </summary>
        /// <param name="catalog">The ps catalogo.</param>
        /// <param name="tableId">The pi tabla identifier.</param>
        /// <param name="loadInterface">if set to <c>true</c> [pb carga interfaz].</param>
        protected void InternalBuilder(string catalog, int tableId, bool loadInterface)
        {
            if (tableId == -1)
            {
                if (string.IsNullOrEmpty(catalog))
                    throw new CoreException(Errors.E00000067);
                Table = catalog;
                TableId = tableId;
                DetermineTableId();
            }
            else
            {
                Table = "";
                TableId = tableId;
                DetermineTableName();
            }
            LoadColumnProperties();
            LoadColumnRelations();
            if (!loadInterface)
            {
                return;
            }
            DetermineCatalogDescription();
            DetermineCatalogLevel();
            LoadMetadataControls();
            Initialize(this);
        }
        private void LoadColumnRelations()
        {
            StringBuilder query = new StringBuilder();
            query.AppendFormat(" select FTablaId, PCampoID,FCampoID from {0}", Connection.TableName("xtsMD_Relaciones"));
            query.AppendFormat("  where PTablaId = {0}", TableId);
            DataTable foreignKey = Connection.GetDataTable(query, "Tabla");
            Relations = new Dictionary<int, Dictionary<int, int>>();
            foreach (DataRow key in foreignKey.Rows)
            {
                if (!Relations.ContainsKey(key.GetValue<int>("FTablaId")))
                {
                    Relations.Add(key.GetValue<int>("FTablaId"), new Dictionary<int, int>());
                }
                Relations[key.GetValue<int>("FTablaId")][key.GetValue<int>("PCampoID")] = key.GetValue<int>("FCampoID");
            }
        }
        /// <summary>
        /// Cargas the propiedades.
        /// </summary>
        public void LoadProperties()
        {
            LoadColumnProperties();
        }

        /// <summary>
        /// Este metodo se declara para que las clases que hereden, implementen el metodo con la carga de los metadatos en
        /// otro metodo estatico
        /// Si los metodos no implementan sus propios campos se toman por defaulf la configuracion de la base de datos
        /// </summary>
        protected override void LoadColumnProperties()
        {
            if (string.IsNullOrEmpty(Owner))
                Owner = Connection.GetTableSchema(Table);
            CreateDataCollection();
        }

        #endregion Funciones

        #region Methods for metadata

        /// <summary>
        /// Arma la cadena de los valores de los campos llave.
        /// </summary>
        /// <returns></returns>
        public string GetStringValuesForKeyFields()
        {
            StringBuilder fields;
            fields = new StringBuilder();
            foreach (KeyValuePair<string, object> loLlave in KeyFields)
            {
                fields.AppendFormat("{0}|", loLlave.Value);
            }
            return fields.Remove(fields.Length - 1, 1).ToString();
        }

        private HashSet<ColumnDefinition> CreateMetadataQuery()
        {
            StringBuilder query;
            query = new StringBuilder();
            query.AppendFormat("SELECT TablaID");
            query.AppendFormat(",CampoID FieldId");
            query.AppendFormat(",Nombre Name");
            query.AppendFormat(",TipoDato  CSharpType");
            query.AppendFormat(",TipoNativo NativeType");
            query.AppendFormat(",Longitud Length");
            query.AppendFormat(",Precision");
            query.AppendFormat(",Orden");
            query.AppendFormat(",LLavePrimaria PrimaryKey");
            query.AppendFormat(",Requerido IsRequiredInDataBase");
            query.AppendFormat(",ValorPredeterminado DefaultValue");
            query.AppendFormat(",Descripcion Description");
            query.AppendFormat(",Identidad EsIdentity");
            query.AppendFormat(",EsCampoEmpresa CompanyField");
            query.AppendFormat(",EsCampoEjercicio YearPeriodField");
            query.AppendFormat(",Ordenar UserOrder");
            query.AppendFormat(",Virtual IsVirtual");
            query.AppendFormat(",Cifrado Encrypted");
            query.AppendFormat(",Password Password, IncluyeHoras IncludeHours");
            query.AppendFormat(" FROM {0}", Connection.TableName("xtsMD_Campos"));
            query.AppendFormat(" where TablaId = {0}", TableId);
            return Connection.GetGenericCollectionData<ColumnDefinition>(query);
        }

        private void ConfigureProperties(ColumnDefinition columnProperty)
        {
            PropertyValue<byte> byteProperty;
            PropertyValue<short> int16Property;
            PropertyValue<int> int32Property;
            PropertyValue<long> int64Property;
            PropertyValue<double> doubleProperty;
            PropertyValue<float> singlePorperty;
            PropertyValue<bool> boolPorperty;
            PropertyValue<byte[]> bytesPorperty;
            PropertyValue<string> stringPorperty;
            PropertyValue<DateTime> dateTinmePorperty;
            PropertyValue<DateTimeOffset> timeOffsetPorperty;

            PropertyValue<object> objectPorperty;
            PropertyValue<byte?> byteNPorperty;
            PropertyValue<short?> int16NPorperty;
            PropertyValue<int?> int32NPorperty;
            PropertyValue<long?> int64NPorperty;
            PropertyValue<double?> doubleNPorperty;
            PropertyValue<float?> singleNPorperty;
            PropertyValue<bool?> boolNPorperty;
            PropertyValue<DateTime?> dateTimeNPorperty;
            PropertyValue<DateTimeOffset?> dateTimeOffsetNPorperty;
            switch (columnProperty.CSharpType.ToLower())
            {
                case "boolean":
                    if (columnProperty.IsRequiredInDataBase)
                    {
                        boolPorperty = new PropertyValue<bool>
                        {
                            IsPrimaryKey = Convert.ToBoolean(columnProperty.PrimaryKey),
                            Length = columnProperty.Length,
                            Precision = columnProperty.Precision,
                            IsRequiredInDataBase = columnProperty.IsRequiredInDataBase,
                            FieldId = columnProperty.FieldId,
                            Description = columnProperty.Description,
                            IsIdentity = columnProperty.EsIdentity,
                            IsCompanyField = columnProperty.CompanyField,
                            IsPeriodYearField = columnProperty.YearPeriodField,
                            IsOrder = columnProperty.UserOrder,
                            IsVirtualField = columnProperty.IsVirtual,
                            IsEncrypted = columnProperty.Encrypted,
                            IsPassword = columnProperty.Password,
                            DataType = typeof(bool),
                            DefaultValue = columnProperty.DefaultValue.ToBoolean()
                        };
                        AddProperty(columnProperty.Name, boolPorperty);
                    }
                    else
                    {
                        boolNPorperty = new PropertyValue<bool?>
                        {
                            IsPrimaryKey = Convert.ToBoolean(columnProperty.PrimaryKey),
                            Length = columnProperty.Length,
                            Precision = columnProperty.Precision,
                            IsRequiredInDataBase = columnProperty.IsRequiredInDataBase,
                            FieldId = columnProperty.FieldId,
                            Description = columnProperty.Description,
                            IsIdentity = columnProperty.EsIdentity,
                            IsCompanyField = columnProperty.CompanyField,
                            IsPeriodYearField = columnProperty.YearPeriodField,
                            IsOrder = columnProperty.UserOrder,
                            IsVirtualField = columnProperty.IsVirtual,
                            IsEncrypted = columnProperty.Encrypted,
                            IsPassword = columnProperty.Password,
                            DataType = typeof(bool?),
                            DefaultValue = columnProperty.DefaultValue.ToBoolean()
                        };
                        AddProperty(columnProperty.Name, boolNPorperty);
                    }
                    break;

                case "byte":
                    if (columnProperty.IsRequiredInDataBase)
                    {
                        byteProperty = new PropertyValue<byte>
                        {
                            IsPrimaryKey = Convert.ToBoolean(columnProperty.PrimaryKey),
                            Length = columnProperty.Length,
                            Precision = columnProperty.Precision,
                            IsRequiredInDataBase = columnProperty.IsRequiredInDataBase,
                            FieldId = columnProperty.FieldId,
                            Description = columnProperty.Description,
                            IsIdentity = columnProperty.EsIdentity,
                            IsCompanyField = columnProperty.CompanyField,
                            IsPeriodYearField = columnProperty.YearPeriodField,
                            IsOrder = columnProperty.UserOrder,
                            IsVirtualField = columnProperty.IsVirtual,
                            IsEncrypted = columnProperty.Encrypted,
                            IsPassword = columnProperty.Password,
                            DataType = typeof(byte),
                            DefaultValue = columnProperty.DefaultValue.IsNumeric() ? Convert.ToByte(columnProperty.DefaultValue) : default
                        };
                        AddProperty(columnProperty.Name, byteProperty);
                    }
                    else
                    {
                        byteNPorperty = new PropertyValue<byte?>
                        {
                            IsPrimaryKey = Convert.ToBoolean(columnProperty.PrimaryKey),
                            Length = columnProperty.Length,
                            Precision = columnProperty.Precision,
                            IsRequiredInDataBase = columnProperty.IsRequiredInDataBase,
                            FieldId = columnProperty.FieldId,
                            Description = columnProperty.Description,
                            IsIdentity = columnProperty.EsIdentity,
                            IsCompanyField = columnProperty.CompanyField,
                            IsPeriodYearField = columnProperty.YearPeriodField,
                            IsOrder = columnProperty.UserOrder,
                            IsVirtualField = columnProperty.IsVirtual,
                            IsEncrypted = columnProperty.Encrypted,
                            IsPassword = columnProperty.Password,
                            DataType = typeof(byte?),
                            DefaultValue = columnProperty.DefaultValue.IsNumeric() ? Convert.ToByte(columnProperty.DefaultValue) : default(byte?)
                        };
                        AddProperty(columnProperty.Name, byteNPorperty);
                    }
                    break;

                case "int16":
                    if (columnProperty.IsRequiredInDataBase)
                    {
                        int16Property = new PropertyValue<short>
                        {
                            IsPrimaryKey = Convert.ToBoolean(columnProperty.PrimaryKey),
                            Length = columnProperty.Length,
                            Precision = columnProperty.Precision,
                            IsRequiredInDataBase = columnProperty.IsRequiredInDataBase,
                            FieldId = columnProperty.FieldId,
                            Description = columnProperty.Description,
                            IsIdentity = columnProperty.EsIdentity,
                            IsCompanyField = columnProperty.CompanyField,
                            IsPeriodYearField = columnProperty.YearPeriodField,
                            IsOrder = columnProperty.UserOrder,
                            IsVirtualField = columnProperty.IsVirtual,
                            IsEncrypted = columnProperty.Encrypted,
                            IsPassword = columnProperty.Password,
                            DataType = typeof(short),
                            DefaultValue = columnProperty.DefaultValue.IsNumeric() ? Convert.ToInt16(columnProperty.DefaultValue) : default
                        };
                        AddProperty(columnProperty.Name, int16Property);
                    }
                    else
                    {
                        int16NPorperty = new PropertyValue<short?>
                        {
                            IsPrimaryKey = Convert.ToBoolean(columnProperty.PrimaryKey),
                            Length = columnProperty.Length,
                            Precision = columnProperty.Precision,
                            IsRequiredInDataBase = columnProperty.IsRequiredInDataBase,
                            FieldId = columnProperty.FieldId,
                            Description = columnProperty.Description,
                            IsIdentity = columnProperty.EsIdentity,
                            IsCompanyField = columnProperty.CompanyField,
                            IsPeriodYearField = columnProperty.YearPeriodField,
                            IsOrder = columnProperty.UserOrder,
                            IsVirtualField = columnProperty.IsVirtual,
                            IsEncrypted = columnProperty.Encrypted,
                            IsPassword = columnProperty.Password,
                            DataType = typeof(short?),
                            DefaultValue = columnProperty.DefaultValue.IsNumeric() ? Convert.ToInt16(columnProperty.DefaultValue) : default(short?)
                        };
                        AddProperty(columnProperty.Name, int16NPorperty);
                    }
                    break;

                case "int32":
                    if (columnProperty.IsRequiredInDataBase)
                    {
                        int32Property = new PropertyValue<int>
                        {
                            IsPrimaryKey = Convert.ToBoolean(columnProperty.PrimaryKey),
                            Length = columnProperty.Length,
                            Precision = columnProperty.Precision,
                            IsRequiredInDataBase = columnProperty.IsRequiredInDataBase,
                            FieldId = columnProperty.FieldId,
                            Description = columnProperty.Description,
                            IsIdentity = columnProperty.EsIdentity,
                            IsCompanyField = columnProperty.CompanyField,
                            IsPeriodYearField = columnProperty.YearPeriodField,
                            IsOrder = columnProperty.UserOrder,
                            IsVirtualField = columnProperty.IsVirtual,
                            IsEncrypted = columnProperty.Encrypted,
                            IsPassword = columnProperty.Password,
                            DataType = typeof(int),
                            DefaultValue = columnProperty.DefaultValue.IsNumeric() ? Convert.ToInt32(columnProperty.DefaultValue) : default
                        };
                        AddProperty(columnProperty.Name, int32Property);
                    }
                    else
                    {
                        int32NPorperty = new PropertyValue<int?>
                        {
                            IsPrimaryKey = Convert.ToBoolean(columnProperty.PrimaryKey),
                            Length = columnProperty.Length,
                            Precision = columnProperty.Precision,
                            IsRequiredInDataBase = columnProperty.IsRequiredInDataBase,
                            FieldId = columnProperty.FieldId,
                            Description = columnProperty.Description,
                            IsIdentity = columnProperty.EsIdentity,
                            IsCompanyField = columnProperty.CompanyField,
                            IsPeriodYearField = columnProperty.YearPeriodField,
                            IsOrder = columnProperty.UserOrder,
                            IsVirtualField = columnProperty.IsVirtual,
                            IsEncrypted = columnProperty.Encrypted,
                            IsPassword = columnProperty.Password,
                            DataType = typeof(int?),
                            DefaultValue = columnProperty.DefaultValue.IsNumeric() ? Convert.ToInt32(columnProperty.DefaultValue) : default(int?)
                        };
                        AddProperty(columnProperty.Name, int32NPorperty);
                    }
                    break;

                case "double":
                    if (columnProperty.IsRequiredInDataBase)
                    {
                        doubleProperty = new PropertyValue<double>
                        {
                            IsPrimaryKey = Convert.ToBoolean(columnProperty.PrimaryKey),
                            Length = columnProperty.Length,
                            Precision = columnProperty.Precision,
                            IsRequiredInDataBase = columnProperty.IsRequiredInDataBase,
                            FieldId = columnProperty.FieldId,
                            Description = columnProperty.Description,
                            IsIdentity = columnProperty.EsIdentity,
                            IsCompanyField = columnProperty.CompanyField,
                            IsPeriodYearField = columnProperty.YearPeriodField,
                            IsOrder = columnProperty.UserOrder,
                            IsVirtualField = columnProperty.IsVirtual,
                            IsEncrypted = columnProperty.Encrypted,
                            IsPassword = columnProperty.Password,
                            DataType = typeof(double),
                            DefaultValue = columnProperty.DefaultValue.IsNumeric() ? Convert.ToDouble(columnProperty.DefaultValue) : default
                        };
                        AddProperty(columnProperty.Name, doubleProperty);
                    }
                    else
                    {
                        doubleNPorperty = new PropertyValue<double?>
                        {
                            IsPrimaryKey = Convert.ToBoolean(columnProperty.PrimaryKey),
                            Length = columnProperty.Length,
                            Precision = columnProperty.Precision,
                            IsRequiredInDataBase = columnProperty.IsRequiredInDataBase,
                            FieldId = columnProperty.FieldId,
                            Description = columnProperty.Description,
                            IsIdentity = columnProperty.EsIdentity,
                            IsCompanyField = columnProperty.CompanyField,
                            IsPeriodYearField = columnProperty.YearPeriodField,
                            IsOrder = columnProperty.UserOrder,
                            IsVirtualField = columnProperty.IsVirtual,
                            IsEncrypted = columnProperty.Encrypted,
                            IsPassword = columnProperty.Password,
                            DataType = typeof(double?),
                            DefaultValue = columnProperty.DefaultValue.IsNumeric() ? Convert.ToDouble(columnProperty.DefaultValue) : default(double?)
                        };
                        AddProperty(columnProperty.Name, doubleNPorperty);
                    }
                    break;

                case "single":
                    if (columnProperty.IsRequiredInDataBase)
                    {
                        singlePorperty = new PropertyValue<float>
                        {
                            IsPrimaryKey = Convert.ToBoolean(columnProperty.PrimaryKey),
                            Length = columnProperty.Length,
                            Precision = columnProperty.Precision,
                            IsRequiredInDataBase = columnProperty.IsRequiredInDataBase,
                            FieldId = columnProperty.FieldId,
                            Description = columnProperty.Description,
                            IsIdentity = columnProperty.EsIdentity,
                            IsCompanyField = columnProperty.CompanyField,
                            IsPeriodYearField = columnProperty.YearPeriodField,
                            IsOrder = columnProperty.UserOrder,
                            IsVirtualField = columnProperty.IsVirtual,
                            IsEncrypted = columnProperty.Encrypted,
                            IsPassword = columnProperty.Password,
                            DataType = typeof(float),
                            DefaultValue = columnProperty.DefaultValue.IsNumeric() ? Convert.ToSingle(columnProperty.DefaultValue) : default
                        };
                        AddProperty(columnProperty.Name, singlePorperty);
                    }
                    else
                    {
                        singleNPorperty = new PropertyValue<float?>
                        {
                            IsPrimaryKey = Convert.ToBoolean(columnProperty.PrimaryKey),
                            Length = columnProperty.Length,
                            Precision = columnProperty.Precision,
                            IsRequiredInDataBase = columnProperty.IsRequiredInDataBase,
                            FieldId = columnProperty.FieldId,
                            Description = columnProperty.Description,
                            IsIdentity = columnProperty.EsIdentity,
                            IsCompanyField = columnProperty.CompanyField,
                            IsPeriodYearField = columnProperty.YearPeriodField,
                            IsOrder = columnProperty.UserOrder,
                            IsVirtualField = columnProperty.IsVirtual,
                            IsEncrypted = columnProperty.Encrypted,
                            IsPassword = columnProperty.Password,
                            DataType = typeof(float?),
                            DefaultValue = columnProperty.DefaultValue.IsNumeric() ? Convert.ToSingle(columnProperty.DefaultValue) : default(float?)
                        };
                        AddProperty(columnProperty.Name, singleNPorperty);
                    }
                    break;

                case "int64":
                    if (columnProperty.IsRequiredInDataBase)
                    {
                        int64Property = new PropertyValue<long>
                        {
                            IsPrimaryKey = Convert.ToBoolean(columnProperty.PrimaryKey),
                            Length = columnProperty.Length,
                            Precision = columnProperty.Precision,
                            IsRequiredInDataBase = columnProperty.IsRequiredInDataBase,
                            FieldId = columnProperty.FieldId,
                            Description = columnProperty.Description,
                            IsIdentity = columnProperty.EsIdentity,
                            IsCompanyField = columnProperty.CompanyField,
                            IsPeriodYearField = columnProperty.YearPeriodField,
                            IsOrder = columnProperty.UserOrder,
                            IsVirtualField = columnProperty.IsVirtual,
                            IsEncrypted = columnProperty.Encrypted,
                            IsPassword = columnProperty.Password,
                            DataType = typeof(long?),
                            DefaultValue = columnProperty.DefaultValue.IsNumeric() ? Convert.ToInt64(columnProperty.DefaultValue) : default
                        };
                        AddProperty(columnProperty.Name, int64Property);
                    }
                    else
                    {
                        int64NPorperty = new PropertyValue<long?>
                        {
                            IsPrimaryKey = Convert.ToBoolean(columnProperty.PrimaryKey),
                            Length = columnProperty.Length,
                            Precision = columnProperty.Precision,
                            IsRequiredInDataBase = columnProperty.IsRequiredInDataBase,
                            FieldId = columnProperty.FieldId,
                            Description = columnProperty.Description,
                            IsIdentity = columnProperty.EsIdentity,
                            IsCompanyField = columnProperty.CompanyField,
                            IsPeriodYearField = columnProperty.YearPeriodField,
                            IsOrder = columnProperty.UserOrder,
                            IsVirtualField = columnProperty.IsVirtual,
                            IsEncrypted = columnProperty.Encrypted,
                            IsPassword = columnProperty.Password,
                            DataType = typeof(long?),
                            DefaultValue = columnProperty.DefaultValue.IsNumeric() ? Convert.ToInt64(columnProperty.DefaultValue) : default(long?)
                        };
                        AddProperty(columnProperty.Name, int64NPorperty);
                    }
                    break;

                case "byte[]":
                    bytesPorperty = new PropertyValue<byte[]>
                    {
                        IsPrimaryKey = Convert.ToBoolean(columnProperty.PrimaryKey),
                        Length = columnProperty.Length,
                        Precision = columnProperty.Precision,
                        IsRequiredInDataBase = columnProperty.IsRequiredInDataBase,
                        FieldId = columnProperty.FieldId,
                        Description = columnProperty.Description,
                        IsIdentity = columnProperty.EsIdentity,
                        IsCompanyField = columnProperty.CompanyField,
                        IsPeriodYearField = columnProperty.YearPeriodField,
                        IsOrder = columnProperty.UserOrder,
                        IsVirtualField = columnProperty.IsVirtual,
                        IsEncrypted = columnProperty.Encrypted,
                        IsPassword = columnProperty.Password,
                        DataType = typeof(byte[]),
                        DefaultValue = null
                    };
                    AddProperty(columnProperty.Name, bytesPorperty);
                    break;

                case "string":
                    stringPorperty = new PropertyValue<string>
                    {
                        IsPrimaryKey = Convert.ToBoolean(columnProperty.PrimaryKey),
                        Length = columnProperty.Length,
                        Precision = columnProperty.Precision,
                        IsRequiredInDataBase = columnProperty.IsRequiredInDataBase,
                        FieldId = columnProperty.FieldId,
                        Description = columnProperty.Description,
                        IsCompanyField = columnProperty.CompanyField,
                        IsPeriodYearField = columnProperty.YearPeriodField,
                        IsOrder = columnProperty.UserOrder,
                        IsVirtualField = columnProperty.IsVirtual,
                        IsEncrypted = columnProperty.Encrypted,
                        IsPassword = columnProperty.Password,
                        DataType = typeof(string),
                        DefaultValue = columnProperty.DefaultValue
                    };
                    AddProperty(columnProperty.Name, stringPorperty);
                    break;

                case "object":
                    objectPorperty = new PropertyValue<object>
                    {
                        IsPrimaryKey = Convert.ToBoolean(columnProperty.PrimaryKey),
                        Length = columnProperty.Length,
                        Precision = columnProperty.Precision,
                        IsRequiredInDataBase = columnProperty.IsRequiredInDataBase,
                        FieldId = columnProperty.FieldId,
                        Description = columnProperty.Description,
                        IsIdentity = columnProperty.EsIdentity,
                        IsCompanyField = columnProperty.CompanyField,
                        IsPeriodYearField = columnProperty.YearPeriodField,
                        IsOrder = columnProperty.UserOrder,
                        IsVirtualField = columnProperty.IsVirtual,
                        IsEncrypted = columnProperty.Encrypted,
                        IsPassword = columnProperty.Password,
                        DataType = typeof(object),
                        DefaultValue = columnProperty.DefaultValue
                    };
                    AddProperty(columnProperty.Name, objectPorperty);
                    break;

                case "datetime":
                case "time":
                case "datetime2":
                case "smalldatetime":
                    if (columnProperty.IsRequiredInDataBase)
                    {
                        dateTinmePorperty = new PropertyValue<DateTime>
                        {
                            IsPrimaryKey = Convert.ToBoolean(columnProperty.PrimaryKey),
                            Length = columnProperty.Length,
                            Precision = columnProperty.Precision,
                            IsRequiredInDataBase = columnProperty.IsRequiredInDataBase,
                            FieldId = columnProperty.FieldId,
                            Description = columnProperty.Description,
                            IsIdentity = columnProperty.EsIdentity,
                            IsCompanyField = columnProperty.CompanyField,
                            IsPeriodYearField = columnProperty.YearPeriodField,
                            IsOrder = columnProperty.UserOrder,
                            IsVirtualField = columnProperty.IsVirtual,
                            IsEncrypted = columnProperty.Encrypted,
                            IsPassword = columnProperty.Password,
                            DataType = typeof(DateTime),
                            DefaultValue = columnProperty.DefaultValue.IsDate() ? Convert.ToDateTime(columnProperty.DefaultValue) : default
                        };
                        if (string.Equals(columnProperty.CSharpType, "smalldatetime", StringComparison.OrdinalIgnoreCase))
                            dateTinmePorperty.IsIncludeHours = false;
                        else
                            dateTinmePorperty.IsIncludeHours = true;
                        AddProperty(columnProperty.Name, dateTinmePorperty);
                    }
                    else
                    {
                        dateTimeNPorperty = new PropertyValue<DateTime?>
                        {
                            IsPrimaryKey = Convert.ToBoolean(columnProperty.PrimaryKey),
                            Length = columnProperty.Length,
                            Precision = columnProperty.Precision,
                            IsRequiredInDataBase = columnProperty.IsRequiredInDataBase,
                            FieldId = columnProperty.FieldId,
                            Description = columnProperty.Description,
                            IsIdentity = columnProperty.EsIdentity,
                            IsCompanyField = columnProperty.CompanyField,
                            IsPeriodYearField = columnProperty.YearPeriodField,
                            IsOrder = columnProperty.UserOrder,
                            IsVirtualField = columnProperty.IsVirtual,
                            IsEncrypted = columnProperty.Encrypted,
                            IsPassword = columnProperty.Password,
                            DataType = typeof(DateTime?),
                            DefaultValue = columnProperty.DefaultValue.IsDate() ? Convert.ToDateTime(columnProperty.DefaultValue) : default(DateTime?)
                        };
                        if (string.Equals(columnProperty.CSharpType, "smalldatetime", StringComparison.OrdinalIgnoreCase))
                            dateTimeNPorperty.IsIncludeHours = false;
                        else
                            dateTimeNPorperty.IsIncludeHours = true;
                        AddProperty(columnProperty.Name, dateTimeNPorperty);
                    }
                    break;

                case "datetimeoffset":
                    if (columnProperty.IsRequiredInDataBase)
                    {
                        timeOffsetPorperty = new PropertyValue<DateTimeOffset>
                        {
                            IsPrimaryKey = Convert.ToBoolean(columnProperty.PrimaryKey),
                            Length = columnProperty.Length,
                            Precision = columnProperty.Precision,
                            IsRequiredInDataBase = columnProperty.IsRequiredInDataBase,
                            FieldId = columnProperty.FieldId,
                            Description = columnProperty.Description,
                            IsIdentity = columnProperty.EsIdentity,
                            DataType = typeof(DateTimeOffset?),
                            IsIncludeHours = true,
                            IsCompanyField = columnProperty.CompanyField,
                            IsPeriodYearField = columnProperty.YearPeriodField,
                            IsOrder = columnProperty.UserOrder,
                            IsEncrypted = columnProperty.Encrypted,
                            IsVirtualField = columnProperty.IsVirtual,
                            IsPassword = columnProperty.Password,
                            DefaultValue = columnProperty.DefaultValue.IsDate() ? Convert.ToDateTime(columnProperty.DefaultValue) : default
                        };
                        AddProperty(columnProperty.Name, timeOffsetPorperty);
                    }
                    else
                    {
                        dateTimeOffsetNPorperty = new PropertyValue<DateTimeOffset?>
                        {
                            IsPrimaryKey = Convert.ToBoolean(columnProperty.PrimaryKey),
                            Length = columnProperty.Length,
                            Precision = columnProperty.Precision,
                            IsRequiredInDataBase = columnProperty.IsRequiredInDataBase,
                            FieldId = columnProperty.FieldId,
                            Description = columnProperty.Description,
                            IsIdentity = columnProperty.EsIdentity,
                            DataType = typeof(DateTimeOffset?),
                            IsIncludeHours = true,
                            IsCompanyField = columnProperty.CompanyField,
                            IsPeriodYearField = columnProperty.YearPeriodField,
                            IsOrder = columnProperty.UserOrder,
                            IsVirtualField = columnProperty.IsVirtual,
                            IsEncrypted = columnProperty.Encrypted,
                            IsPassword = columnProperty.Password,
                            DefaultValue = columnProperty.DefaultValue.IsDate() ? Convert.ToDateTime(columnProperty.DefaultValue) : default(DateTime?)
                        };
                        AddProperty(columnProperty.Name, dateTimeOffsetNPorperty);
                    }
                    break;

                default:
                    break;
            }
        }

        private void ConfigurePropertiesGraphQl(ColumnDefinition columnProperty)
        {
            switch (columnProperty.CSharpType.ToLower())
            {
                case "boolean":
                    AddProperty(columnProperty.Name, new PropertyValue<bool>
                    {
                        IsPrimaryKey = Convert.ToBoolean(columnProperty.PrimaryKey),
                        Length = columnProperty.Length,
                        Precision = columnProperty.Precision,
                        IsRequiredInDataBase = columnProperty.IsRequiredInDataBase,
                        FieldId = columnProperty.FieldId,
                        Description = columnProperty.Description,
                        IsIdentity = columnProperty.EsIdentity,
                        IsCompanyField = columnProperty.CompanyField,
                        IsPeriodYearField = columnProperty.YearPeriodField,
                        IsOrder = columnProperty.UserOrder,
                        IsVirtualField = columnProperty.IsVirtual,
                        IsEncrypted = columnProperty.Encrypted,
                        IsPassword = columnProperty.Password,
                        DataType = typeof(bool),
                        DefaultValue = columnProperty.DefaultValue.ToBoolean()
                    });
                    break;
                case "int64":
                case "long":
                    AddProperty(columnProperty.Name, new PropertyValue<long>
                    {
                        IsPrimaryKey = Convert.ToBoolean(columnProperty.PrimaryKey),
                        Length = columnProperty.Length,
                        Precision = columnProperty.Precision,
                        IsRequiredInDataBase = columnProperty.IsRequiredInDataBase,
                        FieldId = columnProperty.FieldId,
                        Description = columnProperty.Description,
                        IsIdentity = columnProperty.EsIdentity,
                        IsCompanyField = columnProperty.CompanyField,
                        IsPeriodYearField = columnProperty.YearPeriodField,
                        IsOrder = columnProperty.UserOrder,
                        IsVirtualField = columnProperty.IsVirtual,
                        IsEncrypted = columnProperty.Encrypted,
                        IsPassword = columnProperty.Password,
                        DataType = typeof(long),
                        DefaultValue = columnProperty.DefaultValue.IsNumeric() ? Convert.ToInt64(columnProperty.DefaultValue) : default
                    });
                    break;
                case "byte":
                case "int":
                case "tinyint":
                case "int16":
                case "int32":
                    AddProperty(columnProperty.Name, new PropertyValue<int>
                    {
                        IsPrimaryKey = Convert.ToBoolean(columnProperty.PrimaryKey),
                        Length = columnProperty.Length,
                        Precision = columnProperty.Precision,
                        IsRequiredInDataBase = columnProperty.IsRequiredInDataBase,
                        FieldId = columnProperty.FieldId,
                        Description = columnProperty.Description,
                        IsIdentity = columnProperty.EsIdentity,
                        IsCompanyField = columnProperty.CompanyField,
                        IsPeriodYearField = columnProperty.YearPeriodField,
                        IsOrder = columnProperty.UserOrder,
                        IsVirtualField = columnProperty.IsVirtual,
                        IsEncrypted = columnProperty.Encrypted,
                        IsPassword = columnProperty.Password,
                        DataType = typeof(int),
                        DefaultValue = columnProperty.DefaultValue.IsNumeric() ? Convert.ToInt32(columnProperty.DefaultValue) : default
                    });
                    break;
                case "double":
                case "single":
                    AddProperty(columnProperty.Name, new PropertyValue<double>
                    {
                        IsPrimaryKey = Convert.ToBoolean(columnProperty.PrimaryKey),
                        Length = columnProperty.Length,
                        Precision = columnProperty.Precision,
                        IsRequiredInDataBase = columnProperty.IsRequiredInDataBase,
                        FieldId = columnProperty.FieldId,
                        Description = columnProperty.Description,
                        IsIdentity = columnProperty.EsIdentity,
                        IsCompanyField = columnProperty.CompanyField,
                        IsPeriodYearField = columnProperty.YearPeriodField,
                        IsOrder = columnProperty.UserOrder,
                        IsVirtualField = columnProperty.IsVirtual,
                        IsEncrypted = columnProperty.Encrypted,
                        IsPassword = columnProperty.Password,
                        DataType = typeof(double),
                        DefaultValue = columnProperty.DefaultValue.IsNumeric() ? Convert.ToDouble(columnProperty.DefaultValue) : default
                    });
                    break;
                case "byte[]":
                    AddProperty(columnProperty.Name, new PropertyValue<byte[]>
                    {
                        IsPrimaryKey = Convert.ToBoolean(columnProperty.PrimaryKey),
                        Length = columnProperty.Length,
                        Precision = columnProperty.Precision,
                        IsRequiredInDataBase = columnProperty.IsRequiredInDataBase,
                        FieldId = columnProperty.FieldId,
                        Description = columnProperty.Description,
                        IsIdentity = columnProperty.EsIdentity,
                        IsCompanyField = columnProperty.CompanyField,
                        IsPeriodYearField = columnProperty.YearPeriodField,
                        IsOrder = columnProperty.UserOrder,
                        IsVirtualField = columnProperty.IsVirtual,
                        IsEncrypted = columnProperty.Encrypted,
                        IsPassword = columnProperty.Password,
                        DataType = typeof(byte[]),
                        DefaultValue = string.IsNullOrEmpty(columnProperty.DefaultValue) ? null : Encoding.ASCII.GetBytes(columnProperty.DefaultValue)
                    });
                    break;
                case "string":
                case "char":
                    AddProperty(columnProperty.Name, new PropertyValue<string>
                    {
                        IsPrimaryKey = Convert.ToBoolean(columnProperty.PrimaryKey),
                        Length = columnProperty.Length,
                        Precision = columnProperty.Precision,
                        IsRequiredInDataBase = columnProperty.IsRequiredInDataBase,
                        FieldId = columnProperty.FieldId,
                        Description = columnProperty.Description,
                        IsCompanyField = columnProperty.CompanyField,
                        IsPeriodYearField = columnProperty.YearPeriodField,
                        IsOrder = columnProperty.UserOrder,
                        IsVirtualField = columnProperty.IsVirtual,
                        IsEncrypted = columnProperty.Encrypted,
                        IsPassword = columnProperty.Password,
                        DataType = typeof(string),
                        DefaultValue = string.IsNullOrEmpty(columnProperty.DefaultValue) ? string.Empty : columnProperty.DefaultValue
                    });
                    break;
                case "object":
                    AddProperty(columnProperty.Name, new PropertyValue<object>
                    {
                        IsPrimaryKey = Convert.ToBoolean(columnProperty.PrimaryKey),
                        Length = columnProperty.Length,
                        Precision = columnProperty.Precision,
                        IsRequiredInDataBase = columnProperty.IsRequiredInDataBase,
                        FieldId = columnProperty.FieldId,
                        Description = columnProperty.Description,
                        IsIdentity = columnProperty.EsIdentity,
                        IsCompanyField = columnProperty.CompanyField,
                        IsPeriodYearField = columnProperty.YearPeriodField,
                        IsOrder = columnProperty.UserOrder,
                        IsVirtualField = columnProperty.IsVirtual,
                        IsEncrypted = columnProperty.Encrypted,
                        IsPassword = columnProperty.Password,
                        DataType = typeof(object),
                        DefaultValue = columnProperty.DefaultValue
                    });
                    break;
                case "datetime":
                case "time":
                case "datetime2":
                case "smalldatetime":
                case "datetimeoffset":
                    AddProperty(columnProperty.Name, new PropertyValue<DateTime>
                    {
                        IsPrimaryKey = Convert.ToBoolean(columnProperty.PrimaryKey),
                        Length = columnProperty.Length,
                        Precision = columnProperty.Precision,
                        IsRequiredInDataBase = columnProperty.IsRequiredInDataBase,
                        FieldId = columnProperty.FieldId,
                        Description = columnProperty.Description,
                        IsIdentity = columnProperty.EsIdentity,
                        IsCompanyField = columnProperty.CompanyField,
                        IsPeriodYearField = columnProperty.YearPeriodField,
                        IsOrder = columnProperty.UserOrder,
                        IsVirtualField = columnProperty.IsVirtual,
                        IsEncrypted = columnProperty.Encrypted,
                        IsPassword = columnProperty.Password,
                        DataType = typeof(DateTime),
                        IsIncludeHours = columnProperty.IncludeHours,
                        DefaultValue = columnProperty.DefaultValue.IsDate() ? Convert.ToDateTime(columnProperty.DefaultValue) : DefaultDateTime
                    });
                    break;
                default:
                    AddProperty(columnProperty.Name, new PropertyValue<string>
                    {
                        IsPrimaryKey = Convert.ToBoolean(columnProperty.PrimaryKey),
                        Length = columnProperty.Length,
                        Precision = columnProperty.Precision,
                        IsRequiredInDataBase = columnProperty.IsRequiredInDataBase,
                        FieldId = columnProperty.FieldId,
                        Description = columnProperty.Description,
                        IsCompanyField = columnProperty.CompanyField,
                        IsPeriodYearField = columnProperty.YearPeriodField,
                        IsOrder = columnProperty.UserOrder,
                        IsVirtualField = columnProperty.IsVirtual,
                        IsEncrypted = columnProperty.Encrypted,
                        IsPassword = columnProperty.Password,
                        DataType = typeof(string),
                        DefaultValue = string.IsNullOrEmpty(columnProperty.DefaultValue) ? string.Empty : columnProperty.DefaultValue
                    });
                    break;
            }
        }

        /// <summary>
        /// Esta funcion llena la coleccion de las propiedades dinamicamicas
        /// del catalogo que se considere dinamico
        /// </summary>
        private void CreateDataCollection()
        {
            HashSet<ColumnDefinition> propertiesColumn;
            if (!Equals(KeyFields, null) && !Equals(Properties, null))
                return;
            //Usamos los campos
            if (TableId > -1)
                propertiesColumn = CreateMetadataQuery();
            else
                propertiesColumn = Connection.GetColumnDefinitionFromTable(Owner, Table);
            KeyFields = new Dictionary<string, object>();
            Properties = new Dictionary<string, Property>(propertiesColumn.Count);
            ContainsCompanyField = false;
            foreach (ColumnDefinition columnProperty in propertiesColumn)
            {
                if (Convert.ToBoolean(columnProperty.PrimaryKey))
                    AddKeyField(columnProperty.Name, null);
                if (columnProperty.CompanyField)
                    ContainsCompanyField = true;
                //ConfigureProperties(columnProperty);
                ConfigurePropertiesGraphQl(columnProperty);
            }
        }

        /// <summary>
        /// Regresas the tabla identifier.
        /// </summary>
        /// <returns></returns>
        private void DetermineTableId()
        {
            StringBuilder query;
            if (TableId != -1)
                return;
            query = new StringBuilder();
            List<ParameterSql> parameter = new List<ParameterSql>() { new ParameterSql("@Table", Table) };
            query.AppendFormat("Select {1}(TablaID,-1) from {0} where Nombre = @Table", Connection.TableName("xtsMD_TABLAS"), Connection.FunctionIsNull());
            TableId = Connection.ExecuteScalar<int>(query, parameter);
        }

        /// <summary>
        /// Determinas the nombre tabla.
        /// </summary>
        private void DetermineTableName()
        {
            StringBuilder query;
            if (!string.IsNullOrEmpty(Table))
                return;
            query = new StringBuilder();
            query.AppendFormat("Select {2}(Nombre,'') from {1} where TablaId = {0}", TableId, Connection.TableName("xtsMD_TABLAS"), Connection.FunctionIsNull());
            Table = Connection.ExecuteScalar<string>(query);
        }

        /// <summary>
        /// Determinas the descripcion catalogo.
        /// </summary>
        private void DetermineCatalogDescription()
        {
            StringBuilder query = new StringBuilder();
            query.AppendFormat("Select {2}(Descripcion,'') from {1} where TablaId = {0}", TableId, Connection.TableName("xtsMD_TABLAS"), Connection.FunctionIsNull());
            TableDescription = Connection.ExecuteScalar<string>(query);
        }
        private void DetermineCatalogLevel()
        {
            StringBuilder query = new StringBuilder();
            query.AppendFormat("Select {2}(Level,0) from {1} where TablaId = {0}", TableId, Connection.TableName("xtsMD_TABLAS"), Connection.FunctionIsNull());
            Level = Connection.ExecuteScalar<int>(query);
        }
        /// <summary>
        /// Cargas the columnas grid.
        /// </summary>
        private void LoadGridColumns()
        {
            StringBuilder query = new StringBuilder();
            GridData = new Grid();
            query.AppendFormat(" SELECT upper(B.Nombre) Name,C.Etiqueta Description , A.Grid IsVisible,A.Mascara Mask,LLavePrimaria PrimaryKey, B.CampoID Id");
            query.AppendFormat(",B.TipoDato DataType,A.GridAnchoColumna WidthColumn,A.GridAlineacion Alignment, A.GridAgrupa IsGroup");
            query.AppendFormat(",A.TipoControl ControlType,A.UsuPermiso UserPermission");
            query.AppendFormat(" FROM {0}  A", Connection.TableName("xtsMD_Campos_Perfil"));
            query.AppendFormat(" inner join {0} B on (A.TablaID = B.TablaID and A.CampoID = B.CampoID )", Connection.TableName("xtsMD_Campos"));
            query.AppendFormat(" inner join {0} C on (B.TablaID = C.TablaID and B.CampoID = C.CampoID )", Connection.TableName("xtsMD_Campos_Idioma"));
            query.AppendFormat(" where A.Empresa = {0} ", _System.Session.Company.Number);
            query.AppendFormat("   and A.Perfil = {0}", _System.Session.User.Profile);
            query.AppendFormat("   and A.TablaID = {0}", TableId);
            //query.AppendFormat("   and C.IdiomaID = {0}", Convert.ToInt32(_System.Session.User.Language));
            query.AppendFormat("   and B.TipoDato <> 'Byte[]'");
            query.AppendFormat(" order by A.TabID,A.TabIndice");
            GridData.Columns = Connection.GetGenericCollectionData<GridColumn>(query);
        }

        /// <summary>
        /// Cargas the botones.
        /// </summary>
        private void LoadButtons()
        {
            DataTable buttonsData;
            Button newButton;
            Buttons = new HashSet<Button>();
            StringBuilder query = new StringBuilder();
            query.AppendFormat("  SELECT B.BotonID,upper(B.Nombre) Nombre,C.Descripcion,A.Visible,A.Habilitado,A.TabIndice,C.ToolTip,A.Privilege ");
            query.AppendFormat(" FROM {0}  A ", Connection.TableName("xtsMD_Botones_Perfil"));
            query.AppendFormat(" inner join {0} B on (A.BotonID = B.BotonID )", Connection.TableName("xtsMD_Botones"));
            query.AppendFormat(" inner join {0} C on (B.BotonID = C.BotonID)", Connection.TableName("xtsMD_Botones_Idioma"));
            query.AppendFormat(" where A.Empresa = {0}", _System.Session.Company.Number);
            query.AppendFormat("   and A.Perfil = {0}", _System.Session.User.Profile);
            query.AppendFormat("   and A.TablaID = {0}", TableId);
            //query.AppendFormat("   and C.IdiomaID = {0}", Convert.ToInt32(_System.Session.User.Language));

            buttonsData = Connection.GetDataTable(query, "Botones");
            foreach (DataRow buttonData in buttonsData.Rows)
            {
                newButton = new Button
                {
                    Id = buttonData.GetValue<int>("BotonID"),
                    Text = buttonData.GetValue<string>("Nombre"),
                    ControlID = string.Format("btn{0}", buttonData.GetValue<string>("Nombre")),
                    TabIndex = buttonData.GetValue<int>("TabIndice"),
                    ToolTip = buttonData.GetValue<string>("ToolTip"),
                    Visible = buttonData.GetValue<string>("Visible").ToBoolean(),
                    Enabled = buttonData.GetValue<string>("Habilitado").ToBoolean(),
                    Privilege = buttonData.GetValue<string>("Privilege"),
                };
                Buttons.Add(newButton);
            }
        }

        /// <summary>
        /// Cargas the tabs.
        /// </summary>
        private void LoadTabs()
        {
            StringBuilder query;
            DataTable tabsData;
            Control newControl;
            PanelData = new Panel();
            query = new StringBuilder();
            query.AppendFormat("  SELECT distinct B.TabID, upper(B.Nombre) Nombre,C.Descripcion,A.Visible,A.Habilitado,A.TabIndice,C.ToolTip");
            query.AppendFormat(" FROM {0}  A ", Connection.TableName("xtsMD_Tabs_Perfil"));
            query.AppendFormat(" inner join {0} B on (A.TabID = B.TabID )", Connection.TableName("xtsMD_Tabs"));
            query.AppendFormat("  inner join {0} C on (B.TabID = C.TabID)", Connection.TableName("xtsMD_Tabs_Idiomas"));
            query.AppendFormat("  inner join {0} D on (A.Empresa = D.Empresa and B.TabID = D.TabID and A.TablaId = D.TablaID )", Connection.TableName("xtsMD_Campos_Perfil"));
            query.AppendFormat(" where A.Empresa = {0}", _System.Session.Company.Number);
            query.AppendFormat("    and A.Perfil = {0}", _System.Session.User.Profile);
            query.AppendFormat("    and A.TablaID = {0}", TableId);
            //query.AppendFormat("    and C.IdiomaID = {0}", Convert.ToInt32(_System.Session.User.Language));
            query.AppendFormat(" order by B.TabID,A.TabIndice");
            tabsData = Connection.GetDataTable(query, "Tabs");
            PanelData.ControlID = string.Format("rdp{0}", Table);
            PanelData.Visible = true;
            PanelData.Enabled = true;
            foreach (DataRow tabData in tabsData.Rows)
            {
                newControl = new Tab();
                CreateTab(ref newControl, tabData);
                PanelData.Tabs.Add(newControl as Tab);
            }
        }
        private HashSet<int> LoadPropertiesByTab(int tabid)
        {
            StringBuilder query = new StringBuilder();
            query.AppendFormat("  SELECT A.CampoId");
            query.AppendFormat(" FROM {0}  A ", Connection.TableName("XTSMD_TABS_PERFIL_CAMPOS"));
            query.AppendFormat(" inner join {0} B on (A.Empresa = B.Empresa and A.TablaId = B.TablaId and A.TabId = B.TabId and A.Perfil = B.Perfil)", Connection.TableName("xtsMD_Tabs_Perfil"));
            query.AppendFormat(" inner join {0} C on (B.TabID = C.TabID )", Connection.TableName("xtsMD_Tabs"));
            query.AppendFormat("  inner join {0} D on (C.TabID = D.TabID)", Connection.TableName("xtsMD_Tabs_Idiomas"));
            query.AppendFormat("  inner join {0} E on (A.Empresa = E.Empresa and A.TabID = E.TabID and A.TablaId = E.TablaID )", Connection.TableName("xtsMD_Campos_Perfil"));
            query.AppendFormat(" where B.Empresa = {0}", _System.Session.Company.Number);
            query.AppendFormat("    and B.Perfil = {0}", _System.Session.User.Profile);
            query.AppendFormat("    and B.TablaID = {0}", TableId);
            query.AppendFormat("    and A.TabID = {0}", tabid);
            return Connection.GetGenericFieldBasedCollection<int>(query, "CampoId");
        }
        /// <summary>
        /// Cargas the controles.
        /// </summary>
        private void LoadControls()
        {
            StringBuilder query;
            DataTable controlsData;
            Control newControl;
            query = new StringBuilder();
            query.AppendFormat("SELECT A.CampoID,A.TabID , A.Visible,A.Habilitado,A.TabIndice,A.TipoControl,A.Mascara,A.UsuPermiso,A.Validacion,A.ToUpper ");
            query.AppendFormat(",Upper(B.Nombre) Nombre, B.TipoDato, C.Etiqueta,C.ToolTip,C.Descripcion,B.ValorPredeterminado");
            query.AppendFormat(",A.Grid,A.GridAnchoColumna,A.GridAlineacion, A.GridAgrupa");
            query.AppendFormat(",A.RelNombreTabla,A.RelCampoEmpresa,A.RelCampoLlave,A.RelCampoLlaveVisible,A.RelCampoDescripcion,A.RelFiltro,A.RelOrden");
            query.AppendFormat(",A.TextoNumeroDigitos,A.TextoValorMinimo,A.TextoValorMaximo,A.TextoColumnas,A.TextoFilas,A.OrdenNivel,A.AvailableFiles");
            query.AppendFormat(",A.BusquedaTablaId,A.BusquedaNombreArchivo,B.Requerido, A.Imprime, B.Virtual, B.Descripcion NombreLayout, B.EsCampoEmpresa");
            query.AppendFormat(" FROM {0}  A", Connection.TableName("xtsMD_Campos_Perfil"));
            query.AppendFormat(" inner join {0} B on (A.TablaID = B.TablaID and A.CampoID = B.CampoID )", Connection.TableName("xtsMD_Campos"));
            query.AppendFormat(" inner join {0} C on (B.TablaID = C.TablaID and B.CampoID = C.CampoID )", Connection.TableName("xtsMD_Campos_Idioma"));
            //por ahora los cargaremos en español
            query.AppendFormat(" where A.Empresa = {0}", _System.Session.Company.Number);
            query.AppendFormat("   and A.Perfil = {0}", _System.Session.User.Profile);
            query.AppendFormat("   and A.TablaID = {0}", TableId);
            //query.AppendFormat("   and C.IdiomaID = {0}", Convert.ToInt32(_System.Session.User.Language));
            query.AppendFormat(" order by A.TabID,A.TabIndice");
            controlsData = Connection.GetDataTable(query, "Controles");
            PropertiesUI = new Dictionary<string, Control>();
            foreach (DataRow controlData in controlsData.Rows)
            {
                //Instanciamos el nuevo control por default como un texto sin valores
                newControl = new Text();
                switch ((ControlType)controlData.GetValue<int>("TipoControl"))
                {
                    //Textos
                    case ControlType.Text:
                        CreateText(ref newControl, controlData);
                        break;

                    case ControlType.Number:
                        CreteNumber(ref newControl, controlData);
                        break;

                    case ControlType.Percent:
                        CreatePercent(ref newControl, controlData);
                        break;

                    case ControlType.Password:
                        CreatePassword(ref newControl, controlData);
                        break;

                    case ControlType.Memo:
                        CreateMemo(ref newControl, controlData);
                        break;
                    //Botones
                    case ControlType.Button:
                        CreateButton(ref newControl, controlData);
                        break;

                    case ControlType.Checkbox:
                        CreateCheck(ref newControl, controlData);
                        break;

                    case ControlType.Option:
                        CreateOption(ref newControl, controlData);
                        break;
                    //Etiquetas
                    case ControlType.Label:
                        CreateLabel(ref newControl, controlData);
                        break;
                    //Listas
                    case ControlType.Combo:
                        CreateDropDown(ref newControl, controlData);
                        break;
                    //Otros
                    case ControlType.UploadFile:
                        CreateImage(ref newControl, controlData);
                        break;

                    case ControlType.GenericSearch:
                        CreateSerch(ref newControl, controlData);
                        break;

                    case ControlType.Date:
                        CreateDate(ref newControl, controlData);
                        break;

                    default:
                        CreateText(ref newControl, controlData);
                        break;
                }
                newControl.Required = controlData.GetValue<string>("Requerido").ToBoolean();
                newControl.ToUpper = controlData.GetValue<string>("ToUpper").ToBoolean();
                newControl.Imprime = controlData.GetValue<string>("Imprime").ToBoolean();
                newControl.Virtual = controlData.GetValue<string>("Virtual").ToBoolean();
                newControl.IsCompanyField = controlData.GetValue<string>("EsCampoEmpresa").ToBoolean();
                newControl.NombreLayout = controlData.GetValue<string>("NombreLayout");
                if (!PropertiesUI.ContainsKey(controlData.GetValue<string>("Nombre")))
                    PropertiesUI.Add(controlData.GetValue<string>("Nombre"), newControl);
            }
        }

        protected void LoadControlByTab()
        {
            foreach (Tab tab in PanelData.Tabs)
            {
                tab.PropertiesDesc = PropertiesUI
                                    .Select(loControl => new KeyValuePair<string, Control>(loControl.Key, loControl.Value))
                                    .Where(loControl => loControl.Value.TabId == tab.TabId && tab.Properties.Contains(loControl.Value.Id))
                                    .ToDictionary(loControl => loControl.Key, loControl => loControl.Value).Select(prop => prop.Value.Value).ConvertObjectToJson();

                tab.PropertiesUI = PropertiesUI
                                    .Select(loControl => new KeyValuePair<string, Control>(loControl.Key, loControl.Value))
                                    .Where(loControl => loControl.Value.TabId == tab.TabId)
                                    .ToDictionary(loControl => loControl.Key, loControl => loControl.Value).Select(prop => prop.Value).ConvertObjectToJson();
            }
        }





        /// <summary>
        /// Cargas the tablas hijas.
        /// </summary>
        private void LoadSubTables()
        {
            HashSet<int> relatedTables;
            StringBuilder query = new StringBuilder();
            //Iniciamos la coleccion para poder determinar si creamos controles
            SubCatalogsData = new SubCatalogs
            {
                TableId = TableId
            };
            query.AppendFormat(" select FTablaId from {1} A inner join {2} B on (A.PTablaId = B.TablaID) where A.PTablaId = {0}", TableId, Connection.TableName("xtsMD_Relaciones"), Connection.TableName("xtsMD_Campos"));
            relatedTables = Connection.GetGenericFieldBasedCollection<int>(query, "FTablaId");
            foreach (int liTablaHija in relatedTables)
            {
                SubCatalogsData[liTablaHija] = CreateSubGrid(liTablaHija);
            }
            if (SubCatalogsData.SubGrid.Count > 0)
            {
                SubCatalogsData.SubTableId = SubCatalogsData.SubGrid.Keys.First();
            }
        }

        /// <summary>
        /// Regresas the descripcion tabla.
        /// </summary>
        /// <param name="tableId">The pi tabla.</param>
        /// <returns></returns>
        private string GetTableDescription(int tableId)
        {
            StringBuilder query = new StringBuilder();
            query.AppendFormat(" select Descripcion from {1} where tablaid = {0}", tableId, Connection.TableName("xtsMD_Tablas"));
            return Connection.ExecuteScalar<string>(query);
        }



        #region Create controls

        /// <summary>
        /// Armas the grid hijo.
        /// </summary>
        /// <param name="tableIdF">The pi tabla.</param>
        /// <returns></returns>
        private SubGrid CreateSubGrid(int tableIdF)
        {
            SubGrid newGrid;
            DataTable foreignKey;
            newGrid = new SubGrid();
            StringBuilder query = new StringBuilder();
            query.AppendFormat(" select (select nombre from {0} where TablaID = PTablaId and CampoId = PCampoID) PCampoID", Connection.TableName("xtsMD_Campos"));
            query.AppendFormat(" ,(select nombre from {0} where TablaID = FTablaId and CampoId = FCampoID) FCampoID", Connection.TableName("xtsMD_Campos"));
            query.AppendFormat(" from {0}", Connection.TableName("xtsMD_Relaciones"));
            query.AppendFormat("  where PTablaId = {0} and FTablaId = {1}", TableId, tableIdF);
            foreignKey = Connection.GetDataTable(query, "Tabla");
            foreach (DataRow loLlave in foreignKey.Rows)
            {
                newGrid.AgregarCampo(loLlave.GetValue<string>("PCampoID").ToUpper(), loLlave.GetValue<string>("FCampoID").ToUpper());
            }
            //Creamos el nombre de los botones con el id de la tabla hija
            newGrid.SubCatalog.ControlID = string.Format("btn_{0}", tableIdF);
            newGrid.SubCatalog.Enabled = true;
            newGrid.SubCatalog.ControlType = ControlType.ChildTableGrid;
            newGrid.SubCatalog.Visible = true;
            newGrid.SubCatalog.Text = GetTableDescription(tableIdF);
            newGrid.SubCatalog.ToolTip = newGrid.SubCatalog.Text;
            return newGrid;
        }

        /// <summary>
        /// Armas the fecha.
        /// </summary>
        /// <param name="newControl">The po nueva etiqueta.</param>
        /// <param name="dataRow">The po control.</param>
        private void CreateDate(ref Control newControl, DataRow dataRow)
        {
            newControl = new Date();
            (newControl as Date).LabelDefinition.ControlID = string.Format("lbl{0}", dataRow.GetValue<string>("Nombre"));
            (newControl as Date).LabelDefinition.Text = dataRow.GetValue<string>("Etiqueta");
            newControl.ControlID = string.Format("rdp{0}", dataRow.GetValue<string>("Nombre"));
            newControl.ControlType = ControlType.Date;
            CreateControl(ref newControl, dataRow);
        }

        /// <summary>
        /// Armas the busqueda.
        /// </summary>
        /// <param name="newControl">The po nuevo combo.</param>
        /// <param name="dataRow">The po control.</param>
        private void CreateSerch(ref Control newControl, DataRow dataRow)
        {
            newControl = new Search();
            (newControl as Search).LabelDefinition.ControlID = string.Format("lbl{0}", dataRow.GetValue<string>("Nombre"));
            (newControl as Search).LabelDefinition.Text = dataRow.GetValue<string>("Etiqueta");
            (newControl as Search).FileName = dataRow.GetValue<string>("BusquedaNombreArchivo");
            (newControl as Search).TablaID = dataRow.GetValue<int>("BusquedaTablaId");
            (newControl as Search).Filter = dataRow.GetValue<string>("RelFiltro");
            newControl.ControlID = string.Format("cc{0}", dataRow.GetValue<string>("Nombre"));
            newControl.ControlType = ControlType.GenericSearch;
            CreateControl(ref newControl, dataRow);
        }

        /// <summary>
        /// Armas the etiqueta.
        /// </summary>
        /// <param name="newControl">The po n ueva etiqueta.</param>
        /// <param name="dataRow">The po control.</param>
        private void CreateLabel(ref Control newControl, DataRow dataRow)
        {
            newControl = new Label();
            (newControl as Label).LabelDefinition.ControlID = string.Format("lbl{0}", dataRow.GetValue<string>("Nombre"));
            (newControl as Label).LabelDefinition.Text = dataRow.GetValue<string>("Etiqueta");
            newControl.ControlID = string.Format("lbl{0}", dataRow.GetValue<string>("Nombre"));
            newControl.ControlType = ControlType.Label;
            CreateControl(ref newControl, dataRow);
        }

        /// <summary>
        /// Armas the imagen.
        /// </summary>
        /// <param name="newControl">The po n ueva imagen.</param>
        /// <param name="dataRow">The po control.</param>
        private void CreateImage(ref Control newControl, DataRow dataRow)
        {
            newControl = new UploadFile();
            (newControl as UploadFile).LabelDefinition.ControlID = string.Format("lbl{0}", dataRow.GetValue<string>("Nombre"));
            (newControl as UploadFile).LabelDefinition.Text = dataRow.GetValue<string>("Etiqueta");
            (newControl as UploadFile).AvailableFiles = dataRow.GetValue<string>("AvailableFiles");
            newControl.ControlID = string.Format("img{0}", dataRow.GetValue<string>("Nombre"));
            newControl.ControlType = ControlType.UploadFile;

            CreateControl(ref newControl, dataRow);
        }

        /// <summary>
        /// Armas the boton.
        /// </summary>
        /// <param name="newControl">The po nuevo boton.</param>
        /// <param name="dataRow">The po control.</param>
        private void CreateButton(ref Control newControl, DataRow dataRow)
        {
            //Boton loNuevoBoton;
            newControl = new Button();
            (newControl as Button).LabelDefinition.ControlID = string.Format("lbl{0}", dataRow.GetValue<string>("Nombre"));
            (newControl as Button).LabelDefinition.Text = dataRow.GetValue<string>("Etiqueta");
            (newControl as Button).Text = dataRow.GetValue<string>("Nombre");
            newControl.ControlID = string.Format("btn{0}", dataRow.GetValue<string>("Nombre"));
            newControl.ControlType = ControlType.Button;
            CreateControl(ref newControl, dataRow);
            //return loNuevoBoton;
        }

        /// <summary>
        /// Armas the chequeo.
        /// </summary>
        /// <param name="newControl">The po nuevo boton.</param>
        /// <param name="dataRow">The po boton.</param>
        private void CreateCheck(ref Control newControl, DataRow dataRow)
        {
            //Boton loNuevoBoton;
            newControl = new Check();
            (newControl as Check).LabelDefinition.ControlID = string.Format("lbl{0}", dataRow.GetValue<string>("Nombre"));
            (newControl as Check).LabelDefinition.Text = dataRow.GetValue<string>("Etiqueta");
            (newControl as Check).Text = dataRow.GetValue<string>("Nombre");
            newControl.ControlID = string.Format("btn{0}", dataRow.GetValue<string>("Nombre"));
            newControl.ControlType = ControlType.Checkbox;
            CreateControl(ref newControl, dataRow);
            //return loNuevoBoton;
        }

        /// <summary>
        /// Armas the opcion.
        /// </summary>
        /// <param name="newControl">The po nuevo boton.</param>
        /// <param name="dataRow">The po boton.</param>
        private void CreateOption(ref Control newControl, DataRow dataRow)
        {
            //Boton loNuevoBoton;
            newControl = new Option();
            (newControl as Option).LabelDefinition.ControlID = string.Format("lbl{0}", dataRow.GetValue<string>("Nombre"));
            (newControl as Option).LabelDefinition.Text = dataRow.GetValue<string>("Etiqueta");
            (newControl as Option).Text = dataRow.GetValue<string>("Nombre");
            newControl.ControlID = string.Format("btn{0}", dataRow.GetValue<string>("Nombre"));
            newControl.ControlType = ControlType.Option;
            CreateControl(ref newControl, dataRow);
            //return loNuevoBoton;
        }

        /// <summary>
        /// Armas the texto.
        /// </summary>
        /// <param name="newControl">The lo nuevo texto.</param>
        /// <param name="dataRow">The po texto.</param>
        private void CreateText(ref Control newControl, DataRow dataRow)
        {
            newControl = new Text();
            (newControl as Text).LabelDefinition.ControlID = string.Format("lbl{0}", dataRow.GetValue<string>("Nombre"));
            (newControl as Text).LabelDefinition.Text = dataRow.GetValue<string>("Etiqueta");
            (newControl as Text).EmptyMessage = dataRow.GetValue<string>("Descripcion");
            newControl.ControlID = string.Format("txt{0}", dataRow.GetValue<string>("Nombre"));
            newControl.ControlType = ControlType.Text;
            CreateControl(ref newControl, dataRow);
        }

        /// <summary>
        /// Armas the porcentaje.
        /// </summary>
        /// <param name="newControl">The po nuevo porcentaje.</param>
        /// <param name="dataRow">The po texto.</param>
        private void CreatePercent(ref Control newControl, DataRow dataRow)
        {
            newControl = new Percent();
            (newControl as Percent).LabelDefinition.ControlID = string.Format("lbl{0}", dataRow.GetValue<string>("Nombre"));
            (newControl as Percent).LabelDefinition.Text = dataRow.GetValue<string>("Etiqueta");
            (newControl as Percent).EmptyMessage = dataRow.GetValue<string>("Descripcion");
            (newControl as Percent).NumberOfDigits = dataRow.GetValue<int>("TextoNumeroDigitos");
            (newControl as Percent).MinValue = dataRow.GetValue<int>("TextoValorMinimo");
            (newControl as Percent).MaxValue = dataRow.GetValue<int>("TextoValorMaximo");
            newControl.ControlID = string.Format("txt{0}", dataRow.GetValue<string>("Nombre"));
            newControl.ControlType = ControlType.Percent;
            CreateControl(ref newControl, dataRow);
        }

        /// <summary>
        /// Armas the contraseña.
        /// </summary>
        /// <param name="newControl">The po nuevo porcentaje.</param>
        /// <param name="dataRow">The po texto.</param>
        private void CreatePassword(ref Control newControl, DataRow dataRow)
        {
            newControl = new Shelly.Abstractions.Controls.Password();
            (newControl as Shelly.Abstractions.Controls.Password).LabelDefinition.ControlID = string.Format("lbl{0}", dataRow.GetValue<string>("Nombre"));
            (newControl as Shelly.Abstractions.Controls.Password).LabelDefinition.Text = dataRow.GetValue<string>("Etiqueta");
            (newControl as Shelly.Abstractions.Controls.Password).EmptyMessage = dataRow.GetValue<string>("Descripcion");
            newControl.ControlID = string.Format("txt{0}", dataRow.GetValue<string>("Nombre"));
            newControl.ControlType = ControlType.Password;
            CreateControl(ref newControl, dataRow);
        }

        /// <summary>
        /// Armas the memo.
        /// </summary>
        /// <param name="newControl">The po nuevo porcentaje.</param>
        /// <param name="dataRow">The po texto.</param>
        private void CreateMemo(ref Control newControl, DataRow dataRow)
        {
            newControl = new Memo();
            (newControl as Memo).LabelDefinition.ControlID = string.Format("lbl{0}", dataRow.GetValue<string>("Nombre"));
            (newControl as Memo).LabelDefinition.Text = dataRow.GetValue<string>("Etiqueta");
            (newControl as Memo).EmptyMessage = dataRow.GetValue<string>("Descripcion");
            (newControl as Memo).Columns = dataRow.GetValue<int>("TextoColumnas");
            (newControl as Memo).Rows = dataRow.GetValue<int>("TextoFilas");
            newControl.ControlID = string.Format("txt{0}", dataRow.GetValue<string>("Nombre"));
            newControl.ControlType = ControlType.Memo;
            CreateControl(ref newControl, dataRow);
        }

        /// <summary>
        /// Armas the numero.
        /// </summary>
        /// <param name="newControl">The lo nuevo texto.</param>
        /// <param name="dataRow">The po texto.</param>
        private void CreteNumber(ref Control newControl, DataRow dataRow)
        {
            newControl = new Number();
            (newControl as Number).LabelDefinition.ControlID = string.Format("lbl{0}", dataRow.GetValue<string>("Nombre"));
            (newControl as Number).LabelDefinition.Text = dataRow.GetValue<string>("Etiqueta");
            (newControl as Number).EmptyMessage = dataRow.GetValue<string>("Descripcion");
            (newControl as Number).NumberOfDigits = dataRow.GetValue<int>("TextoNumeroDigitos");
            newControl.ControlID = string.Format("txt{0}", dataRow.GetValue<string>("Nombre"));
            newControl.ControlType = ControlType.Number;
            CreateControl(ref newControl, dataRow);
        }

        /// <summary>
        /// Armas the combo.
        /// </summary>
        /// <param name="newControl">The po nuevo combo.</param>
        /// <param name="dataRow">The po control.</param>
        private void CreateDropDown(ref Control newControl, DataRow dataRow)
        {
            newControl = new DropDown();
            (newControl as DropDown).LabelDefinition.ControlID = string.Format("lbl{0}", dataRow.GetValue<string>("Nombre"));
            (newControl as DropDown).LabelDefinition.Text = dataRow.GetValue<string>("Etiqueta");
            (newControl as DropDown).ValueField = dataRow.GetValue<string>("RelCampoLlave");
            (newControl as DropDown).DescriptionField = dataRow.GetValue<string>("RelCampoDescripcion");
            (newControl as DropDown).TableName = dataRow.GetValue<string>("RelNombreTabla");
            (newControl as DropDown).Filter = dataRow.GetValue<string>("RelFiltro");
            (newControl as DropDown).Order = dataRow.GetValue<string>("RelOrden");
            (newControl as DropDown).VisibleValueField = dataRow.GetValue<bool>("RelCampoLlaveVisible");
            (newControl as DropDown).CompanyField = dataRow.GetValue<string>("RelCampoEmpresa");
            newControl.ControlType = ControlType.Combo;
            (newControl as DropDown).Values = GetListMetaDataDropDownList(newControl as DropDown);
            CreateControl(ref newControl, dataRow);
        }

        private List<DropDownValue> GetListMetaDataDropDownList(DropDown dropDown)
        {
            DataView data;
            List<DropDownValue> dropDownList;
            StringBuilder query;
            dropDownList = new List<DropDownValue>();
            query = CreateQueryForDropDownMetadata(dropDown);
            data = Connection.GetDataView(query);
            if (data.Table.Rows.Count == 0)
            {
                dropDownList.Add(new DropDownValue() { Value = "0", Description = "" });
                return dropDownList;
            }
            data.RowFilter = " Valor = '0'";
            if (data.Count == 0)
            {
                dropDownList.Add(new DropDownValue() { Value = "0", Description = "" });
            }
            data.RowFilter = "";
            foreach (DataRow loFila in data.Table.Rows)
            {
                if (loFila.ItemArray.Length < 2)
                {
                    continue;
                }
                dropDownList.Add(new DropDownValue() { Value = Convert.ToString(loFila[0]), Description = Convert.ToString(loFila[1]) });
            }
            return dropDownList;
        }

        private StringBuilder CreateQueryForDropDownMetadata(DropDown dropDown)
        {
            StringBuilder query = new StringBuilder();
            //TODO:Hacer validaciones sobre los campos para que se arme bien la consulta
            query.AppendFormat("Select distinct {0} as Valor,{1} as Descripcion from {2}", dropDown.ValueField, dropDown.DescriptionField, Connection.TableName(dropDown.TableName));
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
            //if (string.Equals(dropDown.TableName, "xtscombos", StringComparison.OrdinalIgnoreCase))
            //query.AppendFormat("  and IdiomaID = {0}", (int)_System.Session.User.Language);
            if (!string.IsNullOrEmpty(dropDown.Order))
                query.AppendFormat(" order by {0}", dropDown.Order);
            return query;
        }

        /// <summary>
        /// Armas the tab.
        /// </summary>
        /// <param name="newControl">The po nuevo tab.</param>
        /// <param name="dataRow">The po control.</param>
        private void CreateTab(ref Control newControl, DataRow dataRow)
        {
            newControl = new Tab();
            (newControl as Tab).Expanded = true;
            (newControl as Tab).Text = dataRow.GetValue<string>("Nombre");
            (newControl as Tab).Properties = LoadPropertiesByTab(dataRow.GetValue<int>("TabID"));
            newControl.ControlID = string.Format("rpi{0}", dataRow.GetValue<string>("Nombre"));
            newControl.ControlType = ControlType.Tab;
            CreateControl(ref newControl, dataRow);
        }

        /// <summary>
        /// Armas the control.
        /// </summary>
        /// <param name="newControl">The po control.</param>
        /// <param name="dataRow">The PDT control.</param>
        private void CreateControl(ref Control newControl, DataRow dataRow)
        {
            newControl.Id = dataRow.GetValue<int>("CampoID");
            newControl.TabId = dataRow.GetValue<int>("TabID");
            newControl.TabIndex = dataRow.GetValue<int>("TabIndice");
            newControl.ToolTip = dataRow.GetValue<string>("ToolTip");
            newControl.Visible = dataRow.GetValue<bool>("Visible");
            newControl.Enabled = dataRow.GetValue<bool>("Habilitado");
            newControl.UserPermission = dataRow.GetValue<bool>("UsuPermiso");
            newControl.Validation = dataRow.GetValue<string>("Validacion");
            newControl.Description = dataRow.GetValue<string>("Descripcion");
            newControl.OrdenNivel = dataRow.GetValue<int>("OrdenNivel");
        }

        #endregion Create controls

        #endregion Methods for metadata
    }
}