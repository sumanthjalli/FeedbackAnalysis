using System;
using System.Collections.Generic;
using System.Text;

namespace FBA.DataAL.Entity
{
    public class FeedBack
    {
        public int FeedBackId { get; set; }
        public int FeedBackCategoryId { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public string FeedBackDesc { get; set; }
        public int FeedBackIndex { get; set; }
        public int StarRating { get; set; }
        public int questionId { get; set; }


    }
}
