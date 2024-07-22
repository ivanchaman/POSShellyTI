using System;

namespace Shelly.Abstractions.Controls
{
     /// <summary>
     ///
     /// </summary>
     [Serializable]
     public class TextBox : Control
     {
          /// <summary>
          /// Gets or sets the etiqueta.
          /// </summary>
          /// <value>
          /// The etiqueta.
          /// </value>
          public Description LabelDefinition { get; set; }

          /// <summary>
          /// Gets or sets the empty message.
          /// </summary>
          /// <value>
          /// The empty message.
          /// </value>
          public string EmptyMessage { get; set; }

          /// <summary>
          /// Gets or sets the text.
          /// </summary>
          /// <value>
          /// The text.
          /// </value>
          public string Text { get; set; }

          /// <summary>
          /// Initializes a new instance of the <see cref="TextBox"/> class.
          /// </summary>
          public TextBox()
          {
               LabelDefinition = new Description();
          }
     }
}