namespace Shelly.Abstractions.Enumerations
{
     public enum FeesType
     {
          None = 0,
          #region transactions
          WalletTransaction = 1,
          #endregion

          #region Cards          
          LoadCard = 7,
          #endregion

          #region ACH         
          InternationalWire = 6,
          DomesticalWire = 11,
          ACHDwollaStandar = 12,
          ACHDwollaSameDay = 13,
          RejectedDwollaTransfer = 15,
          #endregion
          
          #region Crypto
          SendExternalCrypto = 16,
          SendSellCrypto = 17,
          SendBuyCrypto = 18,
          SendSwapCrypto = 19,
          SendGlobalCrypto = 20,
          #endregion

          AVIALABLE_0 = 2,
          AVIALABLE_7 = 3,
          AVIALABLE_1 = 4,
          AVIALABLE_2 = 5,
          AVIALABLE_3 = 8,
          AVIALABLE_4 = 9,
          AVIALABLE_5 = 10,
          AVIALABLE_6 = 14,
     }
}
