using System;
using System.Collections.Generic;
using System.Text;

namespace CRES.DataContract
{
    public class ScheduleDC
    {
        public int? Period { get; set; }
        public DateTime? Date { get; set; }
        public decimal? FixedAmort { get; set; }
        public decimal? GlobalCurtailment { get; set; }
        public decimal? Curtailment12 { get; set; }
        public decimal? Curtailment24 { get; set; }
        public decimal? Curtailment30 { get; set; }
        public decimal? Curtailment36 { get; set; }
        public decimal? Curtailment48 { get; set; }
        public decimal? Curtailment60 { get; set; }
        public decimal? FutureFundingStandard { get; set; }
        public decimal? FutureFundingNYConstruction { get; set; }
        public decimal? FutureFundingNYProject { get; set; }

    } 
}
