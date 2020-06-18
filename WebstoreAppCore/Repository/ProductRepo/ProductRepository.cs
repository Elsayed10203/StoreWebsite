using System.Collections.Generic;
using System.Linq;
using WebstoreAppCore.Models;
namespace WebstoreAppCore.MobileRepository
{
   
  public  interface IProductRepository
    {
        void AddProduct(Product _Product, MobileProperty Mobile, LaptopProperty Laptop);
        void UpdateProduct(Product _Product, MobileProperty Mobile, LaptopProperty Laptop);
        IEnumerable<Product> GetProductys();
        IEnumerable<MobileProperty> GetMobiles();
        IEnumerable<LaptopProperty> GetLaptopss();

        void DeleteProduct(int id);
        Product detail(int? id);
    }
     class ProductRepository: IProductRepository
    {
        readonly private StoreWebsiteContext _Context;
        public ProductRepository(StoreWebsiteContext Context)
        {
            _Context = Context;
        }

        public void AddProduct(Product _Product, MobileProperty Mobile, LaptopProperty Laptop)
        {
            _Product.ProdId = (_Context.Product.Select(x => x.ProdId).Max() + 1);
            _Context.Product.Add(_Product);
            _Context.SaveChanges();
            if (Mobile != null)
            {
                Mobile.ProdId = _Product.ProdId;
                _Context.MobileProperty.Add(Mobile);
                _Context.SaveChanges();
            }
            if (Laptop != null)
            {
                Laptop.ProdId = _Product.ProdId;
                _Context.LaptopProperty.Add(Laptop);
                _Context.SaveChanges();
            }
        }

        public void UpdateProduct(Product _Product, MobileProperty Mobile, LaptopProperty Laptop)
        {
            Product prod = _Context.Product.Where(x => x.ProdId == _Product.ProdId).SingleOrDefault();
            prod.BrandId = _Product.BrandId;
            prod.CatId = _Product.CatId;
            prod.ProdName = _Product.ProdName;
            prod.ProdDescrp = _Product.ProdDescrp;
            prod.Prodprice = _Product.Prodprice;
            prod.ProdQuantity = _Product.ProdQuantity;
            prod.ProductAvailableLocation = _Product.ProductAvailableLocation;
            prod.Discound = _Product.Discound;
            _Context.SaveChanges();
            if(Mobile!=null)
            {
                UpdateMobile(Mobile, _Product.ProdId);

            }
            if(Laptop != null)
            {
                UpdateLaptop(Laptop, _Product.ProdId);
            }
        }
        void UpdateMobile(MobileProperty Mobile,int prod_Id)
        {
            if(Mobile!=null)
            {
                MobileProperty _Mobi = _Context.MobileProperty.Where(x => x.ProdId == prod_Id).SingleOrDefault();
                _Mobi.Ram = Mobile.Ram;
                _Mobi.Battery = Mobile.Battery;
                _Mobi.CameraPropertry = Mobile.CameraPropertry;
                _Mobi.ScreenSize = Mobile.ScreenSize;
                _Mobi.ScreenType = Mobile.ScreenType;
                _Mobi.Battery = Mobile.Battery;
                _Mobi.ModeNo = Mobile.ModeNo;
                _Mobi.FingerPrint = Mobile.FingerPrint;
                _Mobi.WaterResist = Mobile.WaterResist;
                _Mobi.Sim = Mobile.Sim;
                _Mobi.OperatingSystem = Mobile.OperatingSystem;
                _Mobi.Storage = Mobile.Storage;
                _Mobi.ExtraProperty = Mobile.ExtraProperty;
                _Context.SaveChanges();
            }
        }
        void UpdateLaptop(LaptopProperty laptop, int prod_Id)
        {
            LaptopProperty _Laptop = _Context.LaptopProperty.Where(x => x.ProdId == prod_Id).SingleOrDefault();
            _Laptop.ScreenSize = laptop.ScreenSize;
            _Laptop.ScreenType = laptop.ScreenType;
            _Laptop.Ram = laptop.Ram;
            _Laptop.CameraPropertry = laptop.CameraPropertry;
            _Laptop.Battery = laptop.Battery;
            _Laptop.ModeNo = laptop.ModeNo;
            _Laptop.FingerPrint = laptop.FingerPrint;
            _Laptop.WaterResist = laptop.WaterResist;
            _Laptop.Processor = laptop.Processor;
            _Laptop.HardType = laptop.HardType;
            _Laptop.HardStorage = laptop.HardStorage;
            _Laptop.Genaration = laptop.Genaration;
            _Laptop.ExtraProperty = laptop.ExtraProperty;
            _Context.SaveChanges();
        }
        public void DeleteProduct(int id)
        {
            
        }

        public Product detail(int? id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Product> GetProductys()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<MobileProperty> GetMobiles()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<LaptopProperty> GetLaptopss()
        {
            throw new System.NotImplementedException();
        }
    }
}