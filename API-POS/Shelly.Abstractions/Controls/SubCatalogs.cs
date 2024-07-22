using System;
using System.Collections.Generic;

namespace Shelly.Abstractions.Controls
{
     /// <summary>
     ///SubCatalogs
     /// </summary>
     [Serializable]
     public class SubCatalogs
     {
          /// <summary>
          /// Gets or sets the table identifier.
          /// </summary>
          /// <value>
          /// The table identifier.
          /// </value>
          public int TableId { get; set; }

          /// <summary>
          /// Gets or sets the sub table identifier.
          /// </summary>
          /// <value>
          /// The sub table identifier.
          /// </value>
          public int SubTableId { get; set; }

          /// <summary>
          /// Gets or sets the sub grid.
          /// </summary>
          /// <value>
          /// The sub grid.
          /// </value>
          public Dictionary<int, SubGrid> SubGrid { get; set; }

          /// <summary>
          /// Initializes a new instance of the <see cref="SubCatalogs"/> class.
          /// </summary>
          public SubCatalogs()
          {
               SubGrid = new Dictionary<int, SubGrid>();
          }

          /// <summary>
          /// Gets or sets the <see cref="SubGrid"/> with the specified sub catalog.
          /// </summary>
          /// <value>
          /// The <see cref="SubGrid"/>.
          /// </value>
          /// <param name="subCatalog">The sub catalog.</param>
          /// <returns></returns>
          public SubGrid this[int subCatalog]
          {
               get { return SubGrid[subCatalog]; }
               set { SubGrid[subCatalog] = value; }
          }
     }
}