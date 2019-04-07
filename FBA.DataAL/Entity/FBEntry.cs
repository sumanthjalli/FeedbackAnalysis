using System;
using System.Collections.Generic;
using System.Text;

namespace FBA.DataAL.Entity
{
    public class FBEntry
    {
        public int FeedBackCategoryId { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public string FeedBackDesc { get; set; }
        public float FeedBackIndex { get; set; }

    }
}
