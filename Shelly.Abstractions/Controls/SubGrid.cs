using System;
using System.Collections.Generic;

namespace Shelly.Abstractions.Controls
{
     /// <summary>
     ///
     /// </summary>
     [Serializable]
     public class SubGrid : Control
     {
          /// <summary>
          /// Gets or sets the descripcion grid.
          /// </summary>
          /// <value>
          /// The descripcion grid.
          /// </value>
          public Button SubCatalog { get; set; }

          /// <summary>
          ///esta coleccion es para guardar los valores en la tabla hija con sus respectivos nombres
          ///en las tablas hijas
          /// </summary>
          public Dictionary<string, object> ForeignKeysValue { get; set; }

          /// <summary>
          /// Coleccion que mantiene la relacion entre los campos de las tablas hijas
          ///Esto es para mantener una relacion entre las tablas ya que los campos pueden cambiar
          /// </summary>
          public Dictionary<string, string> KeyRelations { get; set; }

          /// <summary>
          /// Initializes a new instance of the <see cref="SubGrid"/> class.
          /// </summary>
          public SubGrid()
          {
               SubCatalog = new Button();
               KeyRelations = new Dictionary<string, string>();
               ForeignKeysValue = new Dictionary<string, object>();
          }

          /// <summary>
          /// Agregars the campo.
          /// </summary>
          /// <param name="fieldIdP">The ps p campo identifier.</param>
          /// <param name="fieldIdF">The ps f campo identifier.</param>
          public void AgregarCampo(string fieldIdP, string fieldIdF)
          {
               //Creamos las realciones de los campos
               KeyRelations[fieldIdP] = fieldIdF;
               ForeignKeysValue[fieldIdF] = null;
          }

          /// <summary>
          /// Gets or sets the <see cref="System.Object"/> with the specified ps l lave.
          /// </summary>
          /// <value>
          /// The <see cref="System.Object"/>.
          /// </value>
          /// <param name="key">The ps l lave.</param>
          /// <returns></returns>
          public object this[string key]
          {
               //Obtenemos los valores de los campos directamente con las relaciones
               get { return ForeignKeysValue[KeyRelations[key]]; }
               set { ForeignKeysValue[KeyRelations[key]] = value; }
          }
     }
}