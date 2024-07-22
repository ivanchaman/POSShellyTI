using System;

namespace Shelly.Abstractions.Controls
{
     /// <summary>
     ///Date
     /// </summary>
     [Serializable]
     public class Date : Control
     {
          /// <summary>
          /// Gets or sets the etiqueta.
          /// </summary>
          /// <value>
          /// The etiqueta.
          /// </value>
          public Description LabelDefinition { get; set; }         

          /// <summary>
          /// Initializes a new instance of the <see cref="Date"/> class.
          /// </summary>
          public Date()
          {
               LabelDefinition = new Description();
          }
     }
}