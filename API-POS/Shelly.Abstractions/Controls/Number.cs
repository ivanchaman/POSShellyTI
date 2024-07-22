using System;

namespace Shelly.Abstractions.Controls
{
     /// <summary>
     ///Number
     /// </summary>
     [Serializable]
     public class Number : TextBox
     {
         

          /// <summary>
          /// Gets or sets the numero digitos.
          /// </summary>
          /// <value>
          /// The numero digitos.
          /// </value>
          public int NumberOfDigits { get; set; }
     }
}