using Shelly.Abstractions.Repository.Entity;
using Shelly.Abstractions.Settings;
using Shelly.ManagementExcel.Solve;
using Shelly.ProviderData.Repository.SP;

namespace Shelly.GraphQLCore.GraphQL.Resolvers
{
     internal class FeeTransactions
     {
          BaseSystem _System;

          public FeeTransactions(BaseSystem system)
          {
               _System = system;
          }
         
          public double GetTotalFee(double amount, long withdrawalAccount, FeesType feeId)
          {
               return GetTotalFee(amount, withdrawalAccount, feeId,-1);
          }
          public double GetTotalFee(double amount, long withdrawalAccount, FeesType feeId, int currencyId)
          {
               double totalConstantFee = 0;
               double totalPercetajeFee = 0;
               double totalFormulaFee = 0;
               if (feeId == 0)
                    return 0;
               if (withdrawalAccount == 0)
                    withdrawalAccount = _System.Session.User.WalletId;
               if (_System.Session.User.LevelFee == 0)
                    _System.Session.User.LevelFee = GetClientLevel(withdrawalAccount);

               List<CompaniesTransactionsFeeTypeD> detailsConstantFees = GetFees(feeId, DetailFeeType.Constant, currencyId);
               totalConstantFee = detailsConstantFees.Select(x => Convert.ToDouble(x.AmountFormula)).Sum();
               List<CompaniesTransactionsFeeTypeD> detailsPercetajeFees = GetFees(feeId, DetailFeeType.Percetaje, currencyId);
               totalPercetajeFee = detailsPercetajeFees.Select(x => (amount * Convert.ToDouble(x.AmountFormula) / 100)).Sum();
               List<CompaniesTransactionsFeeTypeD> detailsFormulaFees = GetFees(feeId, DetailFeeType.Formula, currencyId);
               SolveData solveFormula = new SolveData();
               solveFormula.AddParameter("AMOUNT", amount);
               totalFormulaFee = detailsFormulaFees.Select(x => solveFormula.Solve<double>(x.AmountFormula)).Sum();
               return totalConstantFee + totalPercetajeFee + totalFormulaFee;
          }
          private List<CompaniesTransactionsFeeTypeD> GetFees(FeesType feeId, DetailFeeType type, int currencyId)
          {
               string filter = "";
               switch (type)
               {
                    case DetailFeeType.Constant:
                    case DetailFeeType.Percetaje:
                         filter = " and isnumeric(AmountFormula) = 1 and cast(AmountFormula as float) > 0";
                         break;
                    case DetailFeeType.Formula:
                         break;
               }
               //fee companies
               List<CompaniesTransactionsFeeTypeD> fees;
               if (currencyId != -1)
               {
                    fees = new CompaniesTransactionsFeeTypeDCollection(_System).GetCollection($"Company = {_System.Session.Company.Number} and isenabled = 1 and isfiat = 1 and feeid = {(int)feeId} and CurrencyId in (-1,-2) and AmountType = {(int)type} {filter}", false).ToList();
                    if (fees.Count == 0)
                         fees = new CompaniesTransactionsFeeTypeDCollection(_System).GetCollection($"Company = 0 and isenabled = 1 and isfiat = 1 and feeid = {(int)feeId} and CurrencyId in(-1,-2) and AmountType = {(int)type} {filter}", false).ToList();                    
               }
               else
               {
                    fees = new CompaniesTransactionsFeeTypeDCollection(_System).GetCollection($"Company = {_System.Session.Company.Number} and isenabled = 1 and isfiat = 0 and feeid = {(int)feeId} and CurrencyId  = {currencyId} and AmountType = {(int)type} {filter}", false).ToList();
                    if (fees.Count == 0)
                         fees = new CompaniesTransactionsFeeTypeDCollection(_System).GetCollection($"Company = 0 and isenabled = 1 and isfiat = 0 and feeid = {(int)feeId} and CurrencyId  = {currencyId} and AmountType = {(int)type} {filter}", false).ToList();
                    if (fees.Count == 0)
                         fees = new CompaniesTransactionsFeeTypeDCollection(_System).GetCollection($"Company = {_System.Session.Company.Number} and isenabled = 1 and isfiat = 0 and feeid = {(int)feeId} and CurrencyId  = -2 and AmountType = {(int)type} {filter}", false).ToList();
                    if (fees.Count == 0)
                         fees = new CompaniesTransactionsFeeTypeDCollection(_System).GetCollection($"Company = 0 and isenabled = 1 and isfiat = 0 and feeid = {(int)feeId} and CurrencyId  = -2 and AmountType = {(int)type} {filter}", false).ToList();
               }
               CompaniesTransactionsFeeTypeDLevel levelFee = new CompaniesTransactionsFeeTypeDLevel(_System);
               foreach (CompaniesTransactionsFeeTypeD fee in fees)
               {
                    SetLevelFee(levelFee, fee);
               }
               return fees;
          }
          private void SetLevelFee(CompaniesTransactionsFeeTypeDLevel levelFee, CompaniesTransactionsFeeTypeD fee)
          {
               if (_System.Session.User.LevelFee == 0)
                    return;
               levelFee.Load(_System.Session.Company.Number, fee.FeeId, _System.Session.User.LevelFee, fee.Id);
               if (levelFee.EOF)
               {
                    levelFee.Load(0, fee.FeeId, _System.Session.User.LevelFee, fee.Id);
                    if (levelFee.EOF)
                         return;
               }
               fee.AmountFormula = levelFee.AmountFormula;
          }
          private int GetClientLevel(long account)
          {
               //spGetUsersMaxTier maxTier = new spGetUsersMaxTier(_System.Connection)
               //{
               //     WalletId = account
               //};
               //return maxTier.ExecuteScalar<int>();
               return 0;
          }
          public void TransactionsFees(ref double amount, FeesType feeId, DateTime transactionDate, long transactionId)
          {
               if (transactionId == 0)
                    return;
               if (feeId == 0)
                    return;
               double total = amount;
               SetTransactionFee(ref amount, feeId, DetailFeeType.Constant, transactionDate, transactionId, 0);
               SetTransactionFee(ref amount, feeId, DetailFeeType.Percetaje, transactionDate, transactionId, total);
               SetTransactionFee(ref amount, feeId, DetailFeeType.Formula, transactionDate, transactionId, total);
          }
          private void SetTransactionFee(ref double amount, FeesType feeId, DetailFeeType feeType, DateTime transactionDate, long transactionId, double total)
          {
               if (amount <= 0)
                    return;
               if (feeId == 0)
                    return;
               SolveData solveFormula = new SolveData();
               double feeAmount = 0;
               List<CompaniesTransactionsFeeTypeD> detailsFees = GetFees(feeId, feeType,-1);
               //Transactions transaction = new Transactions(_System);
               //foreach (CompaniesTransactionsFeeTypeD fee in detailsFees)
               //{
               //     if (fee.FiatWalletId == 0)
               //          throw new CoreException($"E00000151", "FiatSavingsAccount");
               //     switch ((DetailFeeType)fee.AmountType)
               //     {
               //          case DetailFeeType.Percetaje:
               //               feeAmount = total * (Convert.ToDouble(fee.AmountFormula) / 100);
               //               break;
               //          case DetailFeeType.Constant:
               //               feeAmount = Convert.ToDouble(fee.AmountFormula);
               //               break;
               //          case DetailFeeType.Formula:
               //               solveFormula.AddParameter("AMOUNT", total);
               //               feeAmount = solveFormula.Solve<double>(fee.AmountFormula);
               //               if (feeAmount < 0)
               //                    throw new CoreException($"E00000277",$"{fee.AmountFormula}");
               //               break;
               //     }
               //     transaction.CreateTransactionWallet(fee.FiatWalletId, transactionDate, feeAmount, $"[fee commision] {fee.Description}", Shelly.Abstractions.Enumerations.TransactionType.DEPOSIT, WalletTransactionPoolType.Wallet, transactionId, feeId);
               //     amount -= feeAmount;
               //}
          }
     }
}
