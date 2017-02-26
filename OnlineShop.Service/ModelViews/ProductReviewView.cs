using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Service.ModelViews
{
    public class ProductReviewView
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string AspNetUserId { get; set; }
        public int Rating { get; set; }
        public string Review { get; set; }
        public DateTime ReviewDate { get; set; }
        public string ReviewDateFormated { get { return ReviewDate.ToString("dd/M/yyyy", CultureInfo.InvariantCulture); } }
        public string  ReviewOwner { get; set; }
    }
}
