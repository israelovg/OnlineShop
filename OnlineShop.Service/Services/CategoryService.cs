using OnlineShop.EF;
using OnlineShop.Service.Interfaces;
using OnlineShop.Service.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Service.Services
{
    public class CategoryService : ICategoryService
    {
        public IEnumerable<CategoryView> GetCategories()
        {
            using (var onlineShopContext = new OnlineShopWebEntities())
            {
                return AutoMapper.Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryView>>(onlineShopContext.Category);
            }
        }
        public void UpsertCategory(CategoryView category)
        {

            if (category.Id > 0)
                this.UpdateCategory(category);
            else
                this.AddCategory(category);

            
        }
        public void RemoveCategory(int id)
        {
            using (var onlineShopContext = new OnlineShopWebEntities())
            {
                var category=onlineShopContext.Category.Find(id);
                if(category!=null)
                {
                    onlineShopContext.Category.Remove(category);
                    onlineShopContext.SaveChanges();
                }
            }
         }
        public CategoryView GetCategoryById(int id)
        {
            using (var onlineShopContext = new OnlineShopWebEntities())
            {
                var category = onlineShopContext.Category.Find(id);
                return AutoMapper.Mapper.Map<Category, CategoryView>(category);
            }
        }
        private void AddCategory(CategoryView category)
        {
            var categoryAdd = AutoMapper.Mapper.Map<CategoryView, Category>(category);
            using (var onlineShopContext = new OnlineShopWebEntities())
            {
                onlineShopContext.Category.Add(categoryAdd);
                onlineShopContext.SaveChanges();
            }
        }
        private void UpdateCategory(CategoryView category)
        {
            var categoryUpdate = AutoMapper.Mapper.Map<CategoryView, Category>(category);
            using (var onlineShopContext = new OnlineShopWebEntities())
            {
                var categoryOriginal = onlineShopContext.Category.Find(category.Id);
                if (category != null)
                {
                    onlineShopContext.Entry(categoryOriginal).CurrentValues.SetValues(categoryUpdate);
                    onlineShopContext.SaveChanges();
                }
            }
        }
    }
}
