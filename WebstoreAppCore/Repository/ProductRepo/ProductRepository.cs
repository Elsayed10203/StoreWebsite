using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebStoreAppCore.Models;
namespace WebstoreAppCore.MobileRepository
{
   
  public  interface IProductRepository
    {
        void AddProduct(Products _Product, MobileProperties Mobile, LaptopProperties Laptop);
        void UpdateProduct(Products _Product, MobileProperties Mobile, LaptopProperties Laptop);
        void DeleteProduct(int id);
        IEnumerable<Products> GetProducts();
        IEnumerable<MobileProperties> GetMobiles();
        IEnumerable<LaptopProperties> GetLaptopss();
        IEnumerable<Products> getDiscountedProducts();
        IEnumerable<ProductPictures> getProductPictures(int id);
        public Products getProductByID(int id);
        public void addToFavorites(int productid, int userid);



        Products detail(int? id);
    }
     public class ProductRepository: IProductRepository
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

        public  IEnumerable<Products> GetProducts()
        {
            return  _Context.Products.ToList();
        }

        public IEnumerable<MobileProperties> GetMobiles()
        {
            return _Context.MobileProperties.Include(p => p.Product);
        }

        public IEnumerable<LaptopProperties> GetLaptopss()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Products> getDiscountedProducts()
        {
            //IEnumerable<Products> discountedProducts= _Context.Products.Where(p => p.IsOffer == true);
            IEnumerable<Products> discountedProducts = (from discountedProduct in _Context.Products
                                          where discountedProduct.IsOffer==true
                                          select discountedProduct).ToList();
            return discountedProducts;
        }
        public IEnumerable<ProductPictures> getProductPictures(int id)
        {
            //IEnumerable<ProductPictures> pics = _Context.ProductPictures.Where(p => p.ProductId == id);
           List<ProductPictures> pics = (from pictures in _Context.ProductPictures
                                                 where pictures.ProductId == id
                                                 select pictures).ToList();
            return pics;
        }

        public Products getProductByID(int id)
        {
            //Products productID = _Context.Products.FirstOrDefault(p => p.ProductId == id);

            Products productByID =(Products)(from product in _Context.Products
                                   where product.ProductId == id
                                   select product);
            return productByID;
        }

        public void addToFavorites(int productid, int userid)
        {
            
            UserFavorites userFavorite = new UserFavorites() { ProductId = productid, UserId = userid };
            _Context.UserFavorites.Add(userFavorite);
            _Context.SaveChanges();
        }

    }
}