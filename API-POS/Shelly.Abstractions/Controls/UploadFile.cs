using System;

namespace Shelly.Abstractions.Controls
{
     /// <summary>
     /// Image
     /// </summary>
     [Serializable]
     public class UploadFile : Control
     {
          /// <summary>
          /// Gets or sets the etiqueta.
          /// </summary>
          /// <value>
          /// The etiqueta.
          /// </value>
          public Description LabelDefinition { get; set; }
          /// <summary>
          /// AvailableFiles
          /// </summary>
          public string AvailableFiles { get; set; }

          /// <summary>
          /// Initializes a new instance of the <see cref="UploadFile"/> class.
          /// </summary>
          public UploadFile()
          {
               LabelDefinition = new Description();
          }
     }
}