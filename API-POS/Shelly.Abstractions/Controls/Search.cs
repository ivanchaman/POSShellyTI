using System;

namespace Shelly.Abstractions.Controls
{
     /// <summary>
     ///Search
     /// </summary>
     [Serializable]
     public class Search : Control
     {
          /// <summary>
          /// Gets or sets the etiqueta.
          /// </summary>
          /// <value>
          /// The etiqueta.
          /// </value>
          public Description LabelDefinition { get; set; }

          /// <summary>
          /// Obtiene y/o configura la tabla que se usara para la busuqeda generica
          /// </summary>
          public int TablaID { get; set; }

          /// <summary>
          /// Gets or sets the nombre archivo.
          /// </summary>
          /// <value>
          /// The nombre archivo.
          /// </value>
          public string FileName { get; set; }

          /// <summary>
          /// Gets or sets the filtro.
          /// </summary>
          /// <value>
          /// The filtro.
          /// </value>
          public string Filter { get; set; }

          /// <summary>
          /// Initializes a new instance of the <see cref="Search"/> class.
          /// </summary>
          public Search()
          {
               LabelDefinition = new Description();
          }
     }
}