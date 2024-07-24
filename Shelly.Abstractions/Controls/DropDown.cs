using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Shelly.Abstractions.Controls
{
     /// <summary>
     ///DropDown
     /// </summary>
     [Serializable]
     public class DropDown : Control
     {
          /// <summary>
          /// Gets or sets the etiqueta.
          /// </summary>
          /// <value>
          /// The etiqueta.
          /// </value>

          public Description LabelDefinition { get; set; }

          /// <summary>
          /// Gets or sets the valor.
          /// </summary>
          /// <value>
          /// The valor.
          /// </value>
          [JsonIgnore]
          public string ValueField { get; set; }

          /// <summary>
          /// Gets or sets the campo empresa.
          /// </summary>
          /// <value>
          /// The campo empresa.
          /// </value>
          [JsonIgnore]
          public string CompanyField { get; set; }

          /// <summary>
          /// Gets or sets the descripcion.
          /// </summary>
          /// <value>
          /// The descripcion.
          /// </value>
          [JsonIgnore]
          public string DescriptionField { get; set; }

          /// <summary>
          /// Gets or sets the tabla.
          /// </summary>
          /// <value>
          /// The tabla.
          /// </value>
          [JsonIgnore]
          public string TableName { get; set; }

          /// <summary>
          /// Gets or sets the filtro.
          /// </summary>
          /// <value>
          /// The filtro.
          /// </value>
          [JsonIgnore]
          public string Filter { get; set; }

          /// <summary>
          /// Gets or sets the orden.
          /// </summary>
          /// <value>
          /// The orden.
          /// </value>
          [JsonIgnore]
          public string Order { get; set; }

          /// <summary>
          /// Gets or sets a value indicating whether [campo valor visble].
          /// </summary>
          /// <value>
          ///   <c>true</c> if [campo valor visble]; otherwise, <c>false</c>.
          /// </value>
          [JsonIgnore]
          public bool VisibleValueField { get; set; }

          /// <summary>
          /// Gets or sets the values.
          /// </summary>
          /// <value>
          /// The values.
          /// </value>
          public List<DropDownValue> Values { get; set; }

          /// <summary>
          /// Initializes a new instance of the <see cref="DropDown"/> class.
          /// </summary>
          public DropDown()
          {
               LabelDefinition = new Description();
               Values = new List<DropDownValue>();
          }
     }
}