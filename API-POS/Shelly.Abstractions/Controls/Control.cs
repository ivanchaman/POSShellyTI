using Newtonsoft.Json;
using Shelly.Abstractions.Enumerations;

namespace Shelly.Abstractions.Controls
{
     /// <summary>
     /// Control
     /// </summary>
     [Serializable]
     public class Control
     {
          public int Id { get; set; }
          /// <summary>
          /// Gets or sets the value.
          /// </summary>
          /// <value>
          /// The value.
          /// </value>
          public string Value { get; set; }
        
          //public HashSet<Control> Controls { get; }
          /// <summary>
          /// Gets or sets the identifier.
          /// </summary>
          /// <value>
          /// The identifier.
          /// </value>
          [JsonIgnore]
          public string ControlID { get; set; }

          /// <summary>
          /// Gets or sets a value indicating whether this <see cref="Control"/> is visible.
          /// </summary>
          /// <value>
          ///   <c>true</c> if visible; otherwise, <c>false</c>.
          /// </value>
          public bool Visible { get; set; }

          /// <summary>
          /// Gets or sets a value indicating whether this <see cref="Control"/> is habilitado.
          /// </summary>
          /// <value>
          ///   <c>true</c> if habilitado; otherwise, <c>false</c>.
          /// </value>
          public bool Enabled { get; set; }

          /// <summary>
          /// Gets or sets the index of the tab.
          /// </summary>
          /// <value>
          /// The index of the tab.
          /// </value>
          [JsonIgnore]
          public int TabIndex { get; set; }

          /// <summary>
          /// Gets or sets the tool tip.
          /// </summary>
          /// <value>
          /// The tool tip.
          /// </value>
          public string ToolTip { get; set; }

          /// <summary>
          /// Gets or sets the tab identifier.
          /// </summary>
          /// <value>
          /// The tab identifier.
          /// </value>
          [JsonIgnore]
          public int TabId { get; set; }

          /// <summary>
          /// Gets or sets the tipo control.
          /// </summary>
          /// <value>
          /// The tipo control.
          /// </value>
          public ControlType ControlType { get; set; }

          /// <summary>
          /// Gets or sets a value indicating whether this <see cref="Control"/> is required.
          /// </summary>
          /// <value>
          ///   <c>true</c> if required; otherwise, <c>false</c>.
          /// </value>
          public bool Required { get; set; }

          
          /// <summary>
          /// Gets or sets a value indicating whether [user permission].
          /// </summary>
          /// <value>
          ///   <c>true</c> if [user permission]; otherwise, <c>false</c>.
          /// </value>
          [JsonIgnore ]
          public bool UserPermission { get; set; }

          /// <summary>
          /// Gets or sets the validation.
          /// </summary>
          /// <value>
          /// The validation.
          /// </value>
          public string Validation { get; set; }

          /// <summary>
          /// Gets or sets the description.
          /// </summary>
          /// <value>
          /// The description.
          /// </value>
          public string Description { get; set; }
          /// <summary>
          /// OrdenNivel
          /// </summary>
          [JsonIgnore]
          public int OrdenNivel{get;set;}

          /// <summary>
          /// ToUpper
          /// </summary>
          public bool ToUpper { get; set; }

          public bool Imprime { get; set; }

          public bool Virtual { get; set; }

          public bool IsCompanyField { get; set; }

          public string NombreLayout { get; set; }
     }
}