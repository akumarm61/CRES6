using System;
using System.Collections.Generic;
using System.Text;

namespace CRES.DataContract
{
     public class CashflowDC
    {
        public int? Period { get; set; }
        public DateTime? Date { get; set; }
        public int? AccrualPeriodEndDateFlag { get; set; }
        public int? PaymentDateFlag { get; set; }
        public decimal? BeginningBalance { get; set; }
        public decimal? FundingAndCurtailment { get; set; }
        public decimal? PIKInterest { get; set; }
        public decimal? ScheduledPrincipal { get; set; }

        public decimal? Coupon { get; set; }

        public decimal? Balloon { get; set; }
        public decimal? EndingBalance { get; set; }
    }
}
