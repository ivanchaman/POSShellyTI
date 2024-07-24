using System;
using System.Collections.Generic;

namespace Shelly.Abstractions.Controls
{
     /// <summary>
     /// Panel
     /// </summary>
     [Serializable]
     public class Panel : Control
     {
          /// <summary>
          /// Gets or sets the tabs.
          /// </summary>
          /// <value>
          /// The tabs.
          /// </value>
          public HashSet<Tab> Tabs { get; set; }

          /// <summary>
          /// Initializes a new instance of the <see cref="Panel"/> class.
          /// </summary>
          public Panel()
          {
               Tabs = new HashSet<Tab>();
          }
     }
}