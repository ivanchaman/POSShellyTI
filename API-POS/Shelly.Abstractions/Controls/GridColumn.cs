using System;

namespace Shelly.Abstractions.Controls
{
     /// <summary>
     /// GridColumn
     /// </summary>
     [Serializable]
     public class GridColumn
     {
          /// <summary>
          /// Gets or sets the nombre.
          /// </summary>
          /// <value>
          /// The nombre.
          /// </value>
          public string Name { get; set; }

          /// <summary>
          /// Gets or sets the descripcion.
          /// </summary>
          /// <value>
          /// The descripcion.
          /// </value>
          public string Description { get; set; }

          /// <summary>
          /// Gets or sets a value indicating whether [es visible].
          /// </summary>
          /// <value>
          ///   <c>true</c> if [es visible]; otherwise, <c>false</c>.
          /// </value>
          public bool IsVisible { get; set; }

          /// <summary>
          /// Gets or sets the mascara.
          /// </summary>
          /// <value>
          /// The mascara.
          /// </value>
          public string Mask { get; set; }

          /// <summary>
          /// Gets or sets the ancho columna.
          /// </summary>
          /// <value>
          /// The ancho columna.
          /// </value>
          public int WidthColumn { get; set; }

          /// <summary>
          /// Gets or sets the alineacion.
          /// </summary>
          /// <value>
          /// The alineacion.
          /// </value>
          public string Alignment { get; set; }

          /// <summary>
          /// Gets or sets a value indicating whether this <see cref="GridColumn"/> is agrupa.
          /// </summary>
          /// <value>
          ///   <c>true</c> if agrupa; otherwise, <c>false</c>.
          /// </value>
          public bool IsGroup { get; set; }

          /// <summary>
          /// Gets or sets the tipo dato.
          /// </summary>
          /// <value>
          /// The tipo dato.
          /// </value>
          public string DataType { get; set; }

          /// <summary>
          /// Gets or sets the type of the control.
          /// </summary>
          /// <value>
          /// The type of the control.
          /// </value>
          public int ControlType { get; set; }

          /// <summary>
          /// Gets or sets a value indicating whether [user permission].
          /// </summary>
          /// <value>
          ///   <c>true</c> if [user permission]; otherwise, <c>false</c>.
          /// </value>
          public bool UserPermission { get; set; }
          /// <summary>
          ///  Gets or sets a value indicating if the field is prymary key.
          ///  </summary>
          ///  <value>
          ///   <c>true</c> if [user field is primary key]; otherwise, <c>false</c>.
          /// </value>
          /// 
          public bool PrimaryKey { get; set; }

          /// <summary>
          /// Id
          /// </summary>
          public int Id { get; set; }
     }
}