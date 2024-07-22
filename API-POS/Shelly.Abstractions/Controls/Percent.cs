using System;

namespace Shelly.Abstractions.Controls
{
     /// <summary>
     ///Percent
     /// </summary>
     [Serializable]
     public class Percent : TextBox
     {         

          /// <summary>
          /// Gets or sets the numero digitos.
          /// </summary>
          /// <value>
          /// The numero digitos.
          /// </value>
          public int NumberOfDigits { get; set; }

          /// <summary>
          /// Gets or sets the valor minimo.
          /// </summary>
          /// <value>
          /// The valor minimo.
          /// </value>
          public int MinValue { get; set; }

          /// <summary>
          /// Gets or sets the valor maximo.
          /// </summary>
          /// <value>
          /// The valor maximo.
          /// </value>
          public int MaxValue { get; set; }
     }
}