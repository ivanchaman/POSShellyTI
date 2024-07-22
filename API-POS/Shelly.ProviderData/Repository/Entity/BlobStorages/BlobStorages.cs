using Shelly.Abstractions.Settings;
using Shelly.ProviderData.Helper;

namespace Shelly.ProviderData.Repository.Entity
{
	/// <summary>
	/// Class xsBlobStorages 
	/// </summary>
	[Serializable]
	public partial class BlobStorages : StaticEntity
	{
		#region Contructor
		/// <summary>
		///  Initializes a new instance of the <see cref="BlobStorages"/> class..
		/// </summary>
		public BlobStorages() : base()
		{
			Table = "BlobStorages";
			Owner = "dbo";
			LoadColumnProperties();

		}
		/// <summary>
		///  Initializes a new instance of the <see cref="BlobStorages"/> class..
		/// </summary>
		/// <param name="IBaseSystem">base system</param>
		public BlobStorages(IBaseSystem IBaseSystem) : base(IBaseSystem)
		{
			Table = "BlobStorages";
			Owner = "dbo";
			LoadColumnProperties();

		}
		#endregion
		#region Propiedades
		[ColumnName("Id")]
		public long Id
		{
			get => GetPropertyValue<long>("Id");
			set => SetPropertyValue<long>("Id", value);
		}
		[ColumnName("UserNumber")]
		public long UserNumber
		{
			get => GetPropertyValue<long>("UserNumber");
			set => SetPropertyValue<long>("UserNumber", value);
		}
		[ColumnName("FileName")]
		public string FileName
		{
			get => GetPropertyValue<string>("FileName");
			set => SetPropertyValue<string>("FileName", value);
		}
		[ColumnName("FileExtension")]
		public string FileExtension
		{
			get => GetPropertyValue<string>("FileExtension");
			set => SetPropertyValue<string>("FileExtension", value);
		}
		[ColumnName("FileUrl")]
		public string FileUrl
		{
			get => GetPropertyValue<string>("FileUrl");
			set => SetPropertyValue<string>("FileUrl", value);
		}
		[ColumnName("BlobStorageName")]
		public string BlobStorageName
		{
			get => GetPropertyValue<string>("BlobStorageName");
			set => SetPropertyValue<string>("BlobStorageName", value);
		}
		[ColumnName("CreateAt")]
		public DateTime CreateAt
		{
			get => GetPropertyValue<DateTime>("CreateAt");
			set => SetPropertyValue<DateTime>("CreateAt", value);
		}
		#endregion
		#region Funciones
		/// <summary>
		/// Load row of the xsBlobStorages.		/// </summary>
		/// <param name="poId">Id</param>
		public void Load(long id)
		{
			base.Load(id);
		}
		/// <summary>
		/// LoadColumnProperties
		/// </summary>
		protected override void LoadColumnProperties()
		{
			if (!Object.Equals(KeyFields, null) && !Object.Equals(Properties, null))
				return;

			KeyFields = new Dictionary<string, object>(1);
			Properties = new Dictionary<string, Property>(7);

			AddKeyField("Id", null);
			AddProperty<long>("Id", new PropertyValue<long>
			{
				Value = default,
				IsPrimaryKey = true,
				Length = 8,
				Precision = 19,
				IsRequiredInDataBase = true,
				FieldId = 0,
				Description = "No description Id",
				IsIdentity = true,
				DataType = typeof(long)
			});
			AddProperty<long>("UserNumber", new PropertyValue<long>
			{
				Value = default,
				IsPrimaryKey = false,
				Length = 8,
				Precision = 19,
				IsRequiredInDataBase = true,
				FieldId = 1,
				Description = "No description UserNumber",
				IsIdentity = false,
				DataType = typeof(long)
			});
			AddProperty<string>("FileName", new PropertyValue<string>
			{
				Value = String.Empty,
				IsPrimaryKey = false,
				Length = 100,
				Precision = 0,
				IsRequiredInDataBase = true,
				FieldId = 2,
				Description = "No description FileName",
				IsIdentity = false,
				DataType = typeof(string)
			});
			AddProperty<string>("FileExtension", new PropertyValue<string>
			{
				Value = String.Empty,
				IsPrimaryKey = false,
				Length = 100,
				Precision = 0,
				IsRequiredInDataBase = true,
				FieldId = 3,
				Description = "No description FileExtension",
				IsIdentity = false,
				DataType = typeof(string)
			});
			AddProperty<string>("FileUrl", new PropertyValue<string>
			{
				Value = String.Empty,
				IsPrimaryKey = false,
				Length = -1,
				Precision = 0,
				IsRequiredInDataBase = true,
				FieldId = 4,
				Description = "No description FileUrl",
				IsIdentity = false,
				DataType = typeof(string)
			});
			AddProperty<string>("BlobStorageName", new PropertyValue<string>
			{
				Value = String.Empty,
				IsPrimaryKey = false,
				Length = 100,
				Precision = 0,
				IsRequiredInDataBase = true,
				FieldId = 5,
				Description = "No description BlobStorageName",
				IsIdentity = false,
				DataType = typeof(string)
			});
			AddProperty<DateTime>("CreateAt", new PropertyValue<DateTime>
			{
				Value = DefaultDateTime,
				IsIncludeHours = true,
				IsPrimaryKey = false,
				Length = 8,
				Precision = 23,
				IsRequiredInDataBase = true,
				FieldId = 6,
				Description = "No description CreateAt",
				IsIdentity = false,
				DataType = typeof(DateTime)
			});
		}
		#endregion

	}
}
