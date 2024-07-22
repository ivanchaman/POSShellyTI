
namespace Shelly.POSProviderData.Repository.Entity
{
	/// <summary>
	/// Class PromotionsProduct 
	/// </summary>
	[Serializable]
	public partial class PromotionsProduct:StaticEntity
	{
		#region Contructor
		/// <summary>
		///  Initializes a new instance of the <see cref="PromotionsProduct"/> class..
		/// </summary>
		public PromotionsProduct():base()
		{
			Table = "PromotionsProduct";
			Owner= "POS";
			LoadColumnProperties();

		}
		/// <summary>
		///  Initializes a new instance of the <see cref="PromotionsProduct"/> class..
		/// </summary>
		/// <param name="IBaseSystem">base system</param>
		public PromotionsProduct(IBaseSystem IBaseSystem):base (IBaseSystem)
		{
			Table = "PromotionsProduct";
			Owner= "POS";
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
		[ColumnName("PromotionId")]
		public long PromotionId
		{
			get => GetPropertyValue<long>("PromotionId");
			set => SetPropertyValue<long>("PromotionId", value);
		}
		[ColumnName("ProductId")]
		public long ProductId
		{
			get => GetPropertyValue<long>("ProductId");
			set => SetPropertyValue<long>("ProductId", value);
		}
		#endregion
		#region Funciones
		/// <summary>
		/// Load row of the PromotionsProduct.		/// </summary>
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
			if (!Object.Equals(KeyFields,null) && !Object.Equals(Properties,null)) 
			  return;

			KeyFields= new Dictionary<string,object>(1);
			Properties = new Dictionary<string, Property>(3);

			 AddKeyField("Id",null);
			 AddProperty<long>("Id", new PropertyValue<long> {
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
			 AddProperty<long>("PromotionId", new PropertyValue<long> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 8,
			 Precision = 19,
			 IsRequiredInDataBase = true,
			 FieldId = 1,
			 Description = "No description PromotionId",
			 IsIdentity = false,
			 DataType = typeof(long)
			});
			 AddProperty<long>("ProductId", new PropertyValue<long> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 8,
			 Precision = 19,
			 IsRequiredInDataBase = true,
			 FieldId = 2,
			 Description = "No description ProductId",
			 IsIdentity = false,
			 DataType = typeof(long)
			});
			}
			#endregion

		}
	}
