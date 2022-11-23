using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webdemofinal.Models;

namespace webdemofinal.Controllers
{
    public class OrderDetailsCusController : Controller
    {
        // GET: OrderDetailsCus
       AdminC database = new AdminC();
        public ActionResult GroupByTop5()
        {
            List<OrderDetail> orderD = database.OrderDetails.ToList();
            List<Product> proList = database.Products.ToList();
            var query = from od in orderD
                        join p in proList on od.IDProduct equals p.ProductID into tbl
                        group od by new
                        {
                            idPro = od.IDProduct,
                            namePro = od.Product.NamePro,
                            imagePro = od.Product.ImagePro,
                            price = od.Product.Price
                        } into gr
                        orderby gr.Sum(s => s.Quantity) descending
                        select new Viewmodel
                        {
                            IDPro = gr.Key.idPro,
                            NamePro = gr.Key.namePro,
                            ImagePro = gr.Key.imagePro,
                            pricePro = (decimal)gr.Key.price,
                            Sum_Quantity = gr.Sum(s => s.Quantity)
                        };
            return View(query.Take(10).ToList());
        }

        public ActionResult GroupByTopSale()
        {
            List<OrderDetail> orderD = database.OrderDetails.ToList();
            List<Product> proList = database.Products.ToList();
            var query = from od in orderD
                        join p in proList on od.IDProduct equals p.ProductID into tbl
                        group od by new
                        {
                            idPro = od.IDProduct,
                            namePro = od.Product.NamePro,
                            imagePro = od.Product.ImagePro,
                            price = od.Product.Price,
                            dateTime = od.Product.datetime,
                        } into gr
                        orderby gr.OrderByDescending(s => s.datetime.ToString()) descending
                        select new Viewmodel
                        {
                            IDPro = gr.Key.idPro,
                            NamePro = gr.Key.namePro,
                            ImagePro = gr.Key.imagePro,
                            pricePro = (decimal)gr.Key.price,
                            desdatetime = gr.Key.dateTime.ToString(),

                        };

            return View(query.Take(10).ToList());
        }
        // GET: OrderDetail
        public ActionResult Index()
        {
            return View();
        }
    }
}