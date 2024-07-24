using System;

namespace Shelly.Abstractions.Controls
{
     /// <summary>
     ///
     /// </summary>
     [Serializable]
     public class Memo : TextBox
     {
          /// <summary>
          /// Gets or sets the columns.
          /// </summary>
          /// <value>
          /// The columns.
          /// </value>
          public int Columns { get; set; }

          /// <summary>
          /// Gets or sets the rows.
          /// </summary>
          /// <value>
          /// The rows.
          /// </value>
          public int Rows { get; set; }
     }
}