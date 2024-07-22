using Shelly.ProviderData.GenericRepository;
using Shelly.Abstractions.Settings;
using System.Text;

namespace Shelly.ProviderData.Repository.Entity
{
	/// <summary>
	/// Class xsCountriesCollection  
	/// </summary>
	public partial class CountriesCollection
	{
          #region variables
          #endregion
          #region Propiedades
          #endregion
          #region Contructor
          #endregion
          #region Metodos/Funciones
          #endregion
          public List<Countries> GetCountries(List<int> filter)
          {
               if (filter == null || filter.Count == 0 )
                    return GetCollection("", false).ToList();
               StringBuilder filterCountries = new StringBuilder(" not Id in (");
               List<ParameterSql> parameters = new List<ParameterSql>();
               int count = 0;
               foreach (int country in filter)
               {
                    filterCountries.AppendFormat("@country{0},", count);
                    parameters.Add(new ParameterSql($"@country{count}", $"{country}"));
                    count++;
               }
               filterCountries.Remove(filterCountries.Length - 1, 1);
               filterCountries.AppendFormat(")");
               return GetCollection(filterCountries.ToString(), false, parameters).ToList();
          }
     }
	}
