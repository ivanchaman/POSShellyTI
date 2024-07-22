﻿namespace Shelly.Abstractions.Model
{
     public class TermAndConditionDocument
     {
          public int Id { get; set; }
          public string Name { get; set; }
          public string Description { get; set; }
          public string UrlDocument { get; set; }
          public int Status { get; set; }
          public DateTime CreatedAt { get; set; }
          public DateTime SignatureDate { get; set; }
     }
}
