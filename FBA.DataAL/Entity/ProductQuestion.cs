using System;
using System.Collections.Generic;
using System.Text;

namespace FBA.DataAL.Entity
{
    public class ProductQuestion
    {
        public int questionId { get; set; }
        public int ProductId { get; set; }
        public string questionDescription { get; set; }
        public string questionType { get; set; }
        public int FeedBackCategoryId { get; set; }
    }
}
