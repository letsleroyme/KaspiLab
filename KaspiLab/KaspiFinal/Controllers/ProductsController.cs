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
            
            var products = productRepository.GetList();
            ViewBag.InfoProducts = GetAllPhotos();
            
            return View(/*"~/Views/ProductsView/ViewProducts.chstml"*/);
        }

        public ActionResult Buy (int id)
        {
            return View();
        }



        public List<ProductInfo> GetAllPhotos()
        {
            var products = productRepository.GetList();
            var link = ppPhoto.GetList();
            var photo = pPhoto.GetList();

            var linktable = ppPhoto.GetList().Select(x => x).ToList();

            var IDs = (from l in linktable
                       join p in pPhoto.GetList() on l.ProductPhotoID equals p.ProductPhotoID
                      select new { Id = l.ProductID, Thumbnail = p.ThumbNailPhoto}).ToList();

            var ProductsWithPhotos = (from pr in productRepository.GetList()
                                      join id in IDs on pr.ProductID equals id.Id
                                      select new ProductInfo { Name = pr.Name, Price = pr.ListPrice, ProductID = pr.ProductID, Thumbnail = id.Thumbnail });

            /*var all = from pr in products
                      join links in link on pr.ProductID equals links.ProductID
                      join photos in photo on links.ProductPhotoID equals photos.ProductPhotoID
                      select new { Name = pr.Name, Price = pr.ListPrice, Thumbnail = photos.ThumbNailPhoto, Id = pr.ProductID };*/

            return ProductsWithPhotos.ToList();

        }





    }

    public class ProductInfo
    {
        public string Name;
        public decimal Price;
        public int ProductID;
        public byte[] Thumbnail;
    }



}