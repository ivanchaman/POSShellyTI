﻿namespace Shelly.Abstractions.Model
{
     public class NewUser
     {
          public string UserName { get; set; }
          public int Company { get; set; }
          public string Email { get; set; }
          public string Password { get; set; }
          public string FirstName { get; set; }          
          public string LastName { get; set; }          
          public int PhoneCode { get; set; }
          public string PhoneNumber { get; set; }
          public int Type { get; set; }
     }
}