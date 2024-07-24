using System;
using System.Collections.Generic;

namespace Shelly.Abstractions.Controls
{
     /// <summary>
     /// Grid
     /// </summary>
     /// <seealso cref="Shelly.Abstractions.Controls.Control" />
     [Serializable]
     public class Grid : Control
     {
          /// <summary>
          /// Gets or sets the columnasñ.
          /// </summary>
          /// <value>
          /// The columnasñ.
          /// </value>
          public HashSet<GridColumn> Columns { get; set; }
     }
}