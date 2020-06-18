using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebstoreAppCore.Models;
namespace WebstoreAppCore
{
  public  enum OrderCatag
    {
        Descending, Assending
    }
   public interface ICategoriesRepository
    {
            IEnumerable<Category> GetCategorys();
            IEnumerable<Category> GetCategorysOrder(OrderCatag Type);
            void DeleteCategory(int id);
            void UpdateCategory(Category Catag);
            void AddCategory(Category Catag);
            Category detail(int? id);    
    }
    public class CategoriesRepository : ICategoriesRepository
    {
       readonly private  StoreWebsiteContext _Context;
        public CategoriesRepository(StoreWebsiteContext Context)
        {
            _Context = Context;
        }

        public void AddCategory(Category Catag)
        {
            Catag.CatId = (_Context.Category.Select(x => x.CatId).Max() + 1);
            _Context.Category.Add(Catag);
            _Context.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            _Context.Category.Remove(detail(id));
            _Context.SaveChanges();
        }

        public Category detail(int? id)
        {
            if(id!=null)
            {
                return _Context.Category.Where(x => x.CatId == id).FirstOrDefault();
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<Category> GetCategorys()
        {
            return _Context.Category.ToList();
        }

        public IEnumerable<Category> GetCategorysOrder(OrderCatag Type)
        {
            if(Type== OrderCatag.Assending)
            {
                return _Context.Category.OrderBy(x => x.CatName).ToList();
            }
            else
            {
                return _Context.Category.OrderByDescending(x => x.CatName).ToList();
            }

        }

        public void UpdateCategory(Category Catag)
        {
            Category cat = detail(Catag.CatId);
            cat.CatName = Catag.CatName;
            cat.CatDescrp = Catag.CatDescrp;
            cat.CatPicturePath = Catag.CatPicturePath;
            _Context.SaveChanges();
        }
    }
}
