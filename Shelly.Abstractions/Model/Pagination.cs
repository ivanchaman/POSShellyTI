﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shelly.Abstractions.Model
{
     public class Pagination<T>
     {
          public int TotalRows { get; set; }
          public int PageNumber { get; set; }
          public int RowsOfPage { get; set; }
          public List<T> Data { get; set; }
     }
}
