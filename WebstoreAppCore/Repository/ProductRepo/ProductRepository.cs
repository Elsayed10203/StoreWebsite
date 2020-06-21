using System.Collections.Generic;
using System.Linq;
using WebStoreAppCore.Models;
namespace WebstoreAppCore.MobileRepository
{
   
  public  interface IProductRepository
    {
        void AddProduct(Products _Product, MobileProperties Mobile, LaptopProperties Laptop);
        void UpdateProduct(Products _Product, MobileProperties Mobile, LaptopProperties Laptop);
        IEnumerable<Products> GetProductys();
        IEnumerable<MobileProperties> GetMobiles();
        IEnumerable<LaptopProperties> GetLaptopss();

        void DeleteProduct(int id);
        Products detail(int? id);
    }
     class ProductRepository: IProductRepository
    {
        readonly private StoreWebsiteContext _Context;
        public ProductRepository(StoreWebsiteContext Context)
        {
            _Context = Context;
        }

        public void AddProduct(Products _Product, MobileProperties Mobile, LaptopProperties Laptop)
        {
            _Product.ProductId = (_Context.Products.Select(x => x.ProductId).Max() + 1);
            _Context.Products.Add(_Product);
            _Context.SaveChanges();
            if (Mobile != null)
            {
                Mobile.ProductId = _Product.ProductId;
                _Context.MobileProperties.Add(Mobile);
                _Context.SaveChanges();
            }
            if (Laptop != null)
            {
                Laptop.ProductId = _Product.ProductId;
                _Context.LaptopProperties.Add(Laptop);
                _Context.SaveChanges();
            }
        }

        public void UpdateProduct(Products _Product, MobileProperties Mobile, LaptopProperties Laptop)
        {
            Products prod = _Context.Products.Where(x => x.ProductId == _Product.ProductId).SingleOrDefault();
            prod.BrandId = _Product.BrandId;
            prod.CategoryId = _Product.CategoryId;
            prod.ProductName = _Product.ProductName;
            prod.ProductDescription = _Product.ProductDescription;
            prod.ProductPrice = _Product.ProductPrice;
            prod.ProductQuantity = _Product.ProductQuantity;
            prod.Discount = _Product.Discount;
            prod.VendorName = _Product.VendorName;
            prod.ProductColor = _Product.ProductColor;
            prod.ProductRate = _Product.ProductRate;
            prod.IsOffer = _Product.IsOffer;
            _Context.SaveChanges();
            if(Mobile!=null)
            {
                UpdateMobile(Mobile, _Product.ProductId);

            }
            if(Laptop != null)
            {
                UpdateLaptop(Laptop, _Product.ProductId);
            }
        }
        void UpdateMobile(MobileProperties Mobile,int prod_Id)
        {
            if(Mobile!=null)
            {
                MobileProperties _Mobi = _Context.MobileProperties.Where(x => x.ProductId == prod_Id).SingleOrDefault();
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
        void UpdateLaptop(LaptopProperties laptop, int prod_Id)
        {
            LaptopProperties _Laptop = _Context.LaptopProperties.Where(x => x.ProductId == prod_Id).SingleOrDefault();
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

        public Products detail(int? id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Products> GetProductys()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<MobileProperties> GetMobiles()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<LaptopProperties> GetLaptopss()
        {
            throw new System.NotImplementedException();
        }
    }
}