using System;

namespace Shelly.Abstractions.Controls
{
     /// <summary>
     ///Button
     /// </summary>
     [Serializable]
     public class Button : Control
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
          public string Text { get; set; }

          public string Privilege { get; set; }

          /// <summary>
          /// Initializes a new instance of the <see cref="Button"/> class.
          /// </summary>
          public Button()
          {
               LabelDefinition = new Description();
          }
     }
}