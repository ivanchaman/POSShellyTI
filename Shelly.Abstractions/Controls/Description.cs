using System;

namespace Shelly.Abstractions.Controls
{
     /// <summary>
     ///
     /// </summary>
     [Serializable]
     public class Description : Control
     {
          /// <summary>
          /// Gets or sets the text.
          /// </summary>
          /// <value>
          /// The text.
          /// </value>
          public string Text { get; set; }
     }
}