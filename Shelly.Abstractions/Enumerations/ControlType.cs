namespace Shelly.Abstractions.Enumerations
{
     /// <summary>
     /// ControlsType
     /// </summary>
     public enum ControlType
     {
          /// <summary>
          /// Etiqueta
          /// </summary>
          Label = 0,

          /// <summary>
          /// Texto
          /// </summary>
          Text = 1,

          /// <summary>
          /// Combo
          /// </summary>
          Combo = 2,

          /// <summary>
          /// Lista
          /// </summary>
          List = 3,

          /// <summary>
          /// Chequeo
          /// </summary>
          Checkbox = 4,

          /// <summary>
          /// Opcion
          /// </summary>
          Option = 5,

          /// <summary>
          /// Boton
          /// </summary>
          Button = 6,

          /// <summary>
          /// Etiqueta
          /// </summary>
          Link = 7,

          /// <summary>
          /// Imagen
          /// </summary>
          UploadFile = 8,

          /// <summary>
          /// Texto Amplio
          /// </summary>
          Memo = 9,

          /// <summary>
          /// Frame o cuadro: Si se soporta la llave de la tabla_perfil no debe ser el nombre
          /// </summary>
          Marco = 10,

          /// <summary>
          /// Pestaña: Si se soporta la llave de la tabla_perfil no debe ser el nombre, porque en el caso de estos objetos no habria campo fisico de por medio
          /// </summary>
          Tab = 11,

          /// <summary>
          /// Ahora los grids con pop ups van a estar en cualquier posicion
          /// </summary>
          ChildTableGrid = 12,

          /// <summary>
          /// Carga archivo
          /// </summary>
          Number = 13,

          /// <summary>
          /// Porcentaje
          /// </summary>
          Percent = 14,

          /// <summary>
          /// The Password
          /// </summary>
          Password = 15,

          /// <summary>
          /// The fecha
          /// </summary>
          Date = 16,

          /// <summary>
          /// Busqueda generica
          /// </summary>
          GenericSearch = 20
     }
}