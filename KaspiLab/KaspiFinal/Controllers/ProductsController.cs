using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KaspiFinal.Repository;
using AdventureWorksModel;

namespace KaspiFinal.Controllers
{
    public class ProductsController : Controller
    {

        GenericRepository<Product> productRepository = new GenericRepository<Product>();
        GenericRepository<ProductProductPhoto> ppPhoto = new GenericRepository<ProductProductPhoto>();
        GenericRepository<ProductPhoto> pPhoto = new GenericRepository<ProductPhoto>();

        // GET: Products
        public ActionResult ViewProducts()
        {
            ViewBag.InfoProducts = GetAllPhotos();
            
            return View(/*"~/Views/ProductsView/ViewProducts.chstml"*/);
        }
        [HttpGet]
        public ActionResult About (int id)
        {
            ViewBag.Desc = GetDescriptionAboutProduct(id);
            return View();
        }

        public ProductDesc GetDescriptionAboutProduct(int id)
        {
            var products = productRepository.GetList().ToList();
            var link = ppPhoto.GetList().ToList();
            var photo = pPhoto.GetList().ToList();

            var res = from pr in products
                      join links in link on pr.ProductID equals links.ProductID
                      join photos in photo on links.ProductPhotoID equals photos.ProductPhotoID
                      where pr.ProductID == id
                      select new ProductDesc
                      {
                          Name = pr.Name,
                          Price = pr.ListPrice,
                          Photo = photos.LargePhoto,
                          ProductID = pr.ProductID,
                          MakeFlag = pr.MakeFlag,
                          ProductNumber = pr.ProductNumber,
                          Color = pr.Color,
                          Weight = pr.Weight,
                          Style = pr.Style

                      }; 

            return res.ToList()[0];


        }

        public List<ProductInfo> GetAllPhotos()
        {
            
            var products = productRepository.GetList().ToList();
            var link = ppPhoto.GetList().ToList();
            var photo = pPhoto.GetList().ToList();

            var all = from pr in products
                      join links in link on pr.ProductID equals links.ProductID
                      join photos in photo on links.ProductPhotoID equals photos.ProductPhotoID
                      select new ProductInfo { Name = pr.Name, Price = pr.ListPrice, Thumbnail = photos.ThumbNailPhoto, ProductID = pr.ProductID };

            return all.ToList();

        }





    }

    public class ProductInfo
    {
        public string Name;
        public decimal Price;
        public int ProductID;
        public byte[] Thumbnail;
    }

    
    public class ProductDesc 
    {
        public string Name;
        public decimal Price;
        public int ProductID;
        public byte[] Photo;
        public bool MakeFlag;


        public string ProductNumber { get; set; }


        public bool FinishedGoodsFlag { get; set; }

        public string Color { get; set; }

        public short SafetyStockLevel { get; set; }

        public short ReorderPoint { get; set; }

        public decimal StandardCost { get; set; }


        public decimal? Weight { get; set; }

        public int DaysToManufacture { get; set; }
        public string ProductLine { get; set; }
        public string Class { get; set; }
        public string Style { get; set; }
    }
}