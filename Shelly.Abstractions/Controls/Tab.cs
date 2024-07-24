using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Shelly.Abstractions.Controls
{
     /// <summary>
     /// Tab
     /// </summary>
     [Serializable]
     public class Tab : Control
     {
          /// <summary>
          /// Gets or sets a value indicating whether this <see cref="Tab"/> is expanded.
          /// </summary>
          /// <value>
          ///   <c>true</c> if expanded; otherwise, <c>false</c>.
          /// </value>
          public bool Expanded { get; set; }

          /// <summary>
          /// Gets or sets the text.
          /// </summary>
          /// <value>
          /// The text.
          /// </value>
          public string Text { get; set; }
          /// <summary>
          /// Gets or sets the property.
          /// </summary>
          /// <value>
          /// The property.
          /// </value>
          [JsonIgnore]
          public HashSet<int> Properties { get; set; }
          /// <summary>
          /// Gets or sets the property desc.
          /// </summary>
          /// <value>
          /// The property desc.
          /// </value>
          public string PropertiesDesc { get; set; }
          /// <summary>
          /// Gets or sets the properties UI.
          /// </summary>
          /// <value>
          /// The properties UI.
          /// </value>
          public string PropertiesUI { get; set; }

          /// <summary>
          /// Initializes a new instance of the <see cref="Tab"/> class.
          /// </summary>
          public Tab()
          {
          }
     }
}