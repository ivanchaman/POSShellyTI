namespace Shelly.Abstractions.Model
{
     public class CardTransactions
     {
          public string Id { get; set; }
          public string Description { get; set; }
          public int Type { get; set; }
          public double Amount { get; set; }
          public DateTime Date { get; set; }
          public string Currency { get; set; }        
     }
}
