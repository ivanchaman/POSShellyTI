using System;

namespace Shelly.Abstractions.Controls
{
     /// <summary>
     ///Label
     /// </summary>
     [Serializable]
     public class Label : Control
     {
          /// <summary>
          /// Gets or sets the etiqueta.
          /// </summary>
          /// <value>
          /// The etiqueta.
          /// </value>
          public Description LabelDefinition { get; set; }

          /// <summary>
          /// Gets or sets the text.
          /// </summary>
          /// <value>
          /// The text.
          /// </value>
          ///
          public string Text { get; set; }

          /// <summary>
          /// Initializes a new instance of the <see cref="Label"/> class.
          /// </summary>
          public Label()
          {
               LabelDefinition = new Description();
          }
     }
}