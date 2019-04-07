using System;
using System.Collections.Generic;
using System.Text;

namespace FBA.DataAL.Entity
{
   public class ApiResponse
    {
        public string query { get; set; }
        public List<topScoringIntentAttributes> topScoringIntent { get; set; }
        public List<EntityAttributes> entities { get; set; }
        public List<LabelAttribute> sentimentAnalysis { get; set; }
    }
}
