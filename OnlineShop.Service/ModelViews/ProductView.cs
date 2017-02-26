using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Service.ModelViews
{
    public class ProductView
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Price required")]
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Invalid price")]
        public decimal Price { get; set; }
        public string PriceInDollar
        {
            get
            {
                return string.Format(new CultureInfo("en-SG", false), "{0:c0}", this.Price);
            }
        }
        [Required(ErrorMessage = "Category required")]
        public int CategoryId { get; set; }
        public IEnumerable<SelectListItem> CategorySelectItems { get; set; }
        public string ProductImagePath { get; set; }
        [DataType(DataType.Upload)]
        public HttpPostedFileBase ImageUpload { get; set; }
        public int ProductRating { get; set; }

        public CategoryView Category { get; set; }
        public IEnumerable<ProductReviewView> ProductReviews { get; set; }
        public ProductView()
        {
            ProductReviews = Enumerable.Empty<ProductReviewView>();
        }
    }
}
