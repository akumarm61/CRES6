using System;
using System.Linq;
using System.Collections.Generic;
using CRES.DataContract;
using Newtonsoft.Json;

namespace CRES.Analytics
{
    public class CashflowLogic 
    {

        public DealDC GetDealData(string dealJSON)
        {
            DealDC dealobjDC = new DealDC();
            dynamic data = Newtonsoft.Json.Linq.JObject.Parse(dealJSON);
            dealobjDC.CREDealID = data["CREDealID"];
            dealobjDC.DealName = data["DealName"];
            List<ScheduleDC> _listSchedule = new List<ScheduleDC>();

            //Schedule DataContract
            var schedule = data["Funding"];
            for (int ndx = 0; ndx < schedule.Count; ndx++)
            {
                ScheduleDC schDC = new ScheduleDC();
                schDC.Period = Convert.ToInt32(schedule[ndx].Period);
                schDC.Date = schedule[ndx].Date == null ? null : Convert.ToDateTime(schedule[ndx].Date) ;
                schDC.FixedAmort = schedule[ndx].FixedAmort == null ? 0 : Convert.ToDecimal(schedule[ndx].FixedAmort);
                schDC.GlobalCurtailment = schedule[ndx].Global == null? 0 : Convert.ToDecimal(schedule[ndx].Global);
                schDC.FutureFundingStandard = schedule[ndx].StandardLoan == null? 0 : Convert.ToDecimal(schedule[ndx].StandardLoan);
                _listSchedule.Add(schDC);
            }

            dealobjDC.ListSchedule = _listSchedule;
            return dealobjDC;
        }

        #region Cash Flow Logic
        public decimal? GetFundingOrCurtailment(List<ScheduleDC> ListSchedule, DateTime dtFunding)
        {
            decimal? NetFundingAmount = 0.0M;

            NetFundingAmount = ListSchedule.Where(sch => sch.Date == dtFunding).Sum(fn => fn.FutureFundingStandard);

            return NetFundingAmount;
        }

        #endregion
    }
}
