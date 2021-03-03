using System;
using System.Numerics;
using System.Collections.Generic;
using Newtonsoft.Json;
using CRES.Analytics;
using CRES.DataContract;

namespace CRES.Cashflow
{
    public class CashflowEngine
    {
        #region Propertiers
        public List<CashflowDC> DealCashFlow = new List<DataContract.CashflowDC>();
        #endregion


        public string Status()
        {
            return "Running...";
        }

        public void GenerateCashFlow(string dealjson)
        {
            int ndx = 0;
            CashflowLogic cfLogic = new CashflowLogic();
            DealDC dealDC = cfLogic.GetDealData(dealjson);
            TimeSpan sp = (dealDC.FullyExtMaturityDate - dealDC.ClosingDate).GetValueOrDefault();

            for(ndx=0;ndx<sp.TotalDays;ndx++)
            {
                CashflowDC periodCF = new CashflowDC();
                periodCF.Period = ndx;
                periodCF.Date = dealDC.ClosingDate.Value.Date.AddDays(ndx);

                periodCF.BeginningBalance = ndx == 0 ? dealDC.InitialFunding.GetValueOrDefault(0) : DealCashFlow[ndx - 1].EndingBalance.GetValueOrDefault(0);
                periodCF.FundingAndCurtailment = cfLogic.GetFundingOrCurtailment(dealDC.ListSchedule, periodCF.Date);
            }

            
        }
        public Vector<ulong> GetEndingBalance()
        {
            ulong LoanTerm = 1800;
            double sum = 0.0;

            List<ulong> Balance = new List<ulong>();
            for (ulong i = 0; i < LoanTerm; i++)
                Balance.Add(i);

            ulong[] arrBalance = Balance.ToArray();
            Vector<ulong> vBalance = new Vector<ulong>(arrBalance);
            //Vector<double> EndingBalance = new Vector<double>(LoanTerm);
            for (int i = 0; i <Vector<ulong>.Count; i++)
                Console.WriteLine(vBalance[i]);

            return vBalance;
        }
    }
}
