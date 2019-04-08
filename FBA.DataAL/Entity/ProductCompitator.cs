using System;
using System.Collections.Generic;
using System.Text;

namespace FBA.DataAL.Entity
{
    public class ProductCompitator
    {
        public int FeedbackCategoryid { get; set; }
        public string CategoryDesc { get; set; }
        public int featureID { get; set; }
        public string FeatureName { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string feedbackDesc { get; set; }
        public double rating { get; set; }

        //public int ranking { get; set; }
        public double AvgVal { get; set; }
    }
}
