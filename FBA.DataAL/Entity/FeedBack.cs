using System;
using System.Collections.Generic;
using System.Text;

namespace FBA.DataAL.Entity
{
    public class FeedBack
    {
        public int FeedBackId { get; set; }
        public string CategoryDesc { get; set; }
        public string UserName { get; set; }
        public string ProductName { get; set; }
        public string FeedBackDesc { get; set; }
        public decimal FeedBackIndex { get; set; }

    }
}
