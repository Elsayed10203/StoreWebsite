using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStoreAppCore.Models;
namespace WebstoreAppCore
{
  public  enum OrderCatag
    {
        Descending, Assending
    }
   public interface ICategoriesRepository
    {
            IEnumerable<Categories> GetCategorys();
            IEnumerable<Categories> GetCategorysOrder(OrderCatag Type);
            void DeleteCategory(int id);
            void UpdateCategory(Categories Catag);
            void AddCategory(Categories Catag);
        Categories detail(int? id);    
    }
    public class CategoriesRepository : ICategoriesRepository
    {
       readonly private  StoreWebsiteContext _Context;
        public CategoriesRepository(StoreWebsiteContext Context)
        {
            _Context = Context;
        }

        public void AddCategory(Categories Catag)
        {
            int CatId = 1;
            if(_Context.Categories.Count()>0)
            {
                CatId = (_Context.Categories.Select(x => x.CategoryId).Max() + 1);
            }
            Catag.CategoryId = CatId;
            _Context.Categories.Add(Catag);
            _Context.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            _Context.Categories.Remove(detail(id));
            _Context.SaveChanges();
        }

        public Categories detail(int? id)
        {
            if(id!=null)
            {
                return _Context.Categories.Where(x => x.CategoryId == id).FirstOrDefault();
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<Categories> GetCategorys()
        {
            return _Context.Categories.ToList();
        }

        public IEnumerable<Categories> GetCategorysOrder(OrderCatag Type)
        {
            if(Type== OrderCatag.Assending)
            {
                return _Context.Categories.OrderBy(x => x.CategoryName).ToList();
            }
            else
            {
                return _Context.Categories.OrderByDescending(x => x.CategoryName).ToList();
            }

        }

        public void UpdateCategory(Categories Catag)
        {
            Categories cat = detail(Catag.CategoryId);
            cat.CategoryName = Catag.CategoryName;
            cat.CategoryDescription = Catag.CategoryDescription;
            cat.CategoryPicturePath = Catag.CategoryPicturePath;
            _Context.SaveChanges();
        }
    }
}
