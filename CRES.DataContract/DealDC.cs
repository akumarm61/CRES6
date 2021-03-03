using System;
using System.Data;
using System.Collections.Generic;

namespace CRES.DataContract
{
    public class DealDC
    {
        public string CREDealID { get; set; }
        public string DealName { get; set; }
        public DateTime? ClosingDate { get; set; }
        public DateTime? FirstPaymentDate { get; set; }
        public DateTime? InitialMaturityDate { get; set; }
        public DateTime? FullyExtMaturityDate { get; set; }
        public Int32? IOTerm { get; set; }
        public Int32? AmortTerm { get; set; }
        public Int32? InitialFunding { get; set; }
        public Int32? FutureFunding { get; set; }
        public List<ScheduleDC> ListSchedule { get; set; }
    }
}
