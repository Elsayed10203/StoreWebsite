using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStoreAppCore.Models;

namespace WebStoreAppCore.Repository
{
    public interface IShopRepository
    {


        public Adminshop getShopData();


    }
    public class ShopRepository : IShopRepository
    {
        readonly private StoreWebsiteContext _Context;

        public ShopRepository(StoreWebsiteContext Context)
        {
            _Context = Context;
        }
        public Adminshop getShopData()
        {
            Adminshop adminshop = (from shop in _Context.Adminshop
                                   select shop).First();
            return adminshop;
        }
    }
}
