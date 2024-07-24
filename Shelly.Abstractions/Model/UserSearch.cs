using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shelly.Abstractions.Model
{
     public class UserSearch
     {
          public int TotalRows { get; set; }
          public int PageNumber { get; set; }
          public int RowsOfPage { get; set; }
          public long Company { get; set; }
          public string CompanyName { get; set; }
          public long WalletId { get; set; }
          public string AvatarImage { get; set; }
          public string FirstName { get; set; }
          public string LastName { get; set; }
          public string Email { get; set; }
          public string PhoneCode { get; set; }
          public string PhoneNumber { get; set; }
     }
}
