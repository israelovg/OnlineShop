using OnlineShop.Service.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Service.Interfaces
{
    public interface ICategoryService
    {
        IEnumerable<CategoryView> GetCategories();
        void UpsertCategory(CategoryView category);
        void RemoveCategory(int id);
        CategoryView GetCategoryById(int id);
    }
}
