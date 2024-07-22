using System;

namespace Shelly.Abstractions.Controls
{
     /// <summary>
     ///
     /// </summary>
     [Serializable]
     public class Text : TextBox
     {
          /// <summary>
          /// Gets or sets the type of the input.
          /// </summary>
          /// <value>
          /// The type of the input.
          /// </value>
          public int InputType { get; set; }

          /// <summary>
          /// Gets or sets the text mode.
          /// </summary>
          /// <value>
          /// The text mode.
          /// </value>
          public int TextMode { get; set; }
     }
}