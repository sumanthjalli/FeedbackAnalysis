using System;
using System.Collections.Generic;
using System.Text;

namespace FBA.DataAL.Entity
{
    public class ProductFeedbackAnalysis
    {
        public string ProductName { get; set; }
        public string CategoryDesc { get; set; }
        public double PosCnt { get; set; }
        public double NegCnt { get; set; }
        public double TotalCnt { get; set; }
    }
}
