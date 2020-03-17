using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using WebApplication14.Models;

//using WebApplication14.Models;

namespace WebApplication14.Controllers
{
    public class NorthwindController : Controller
    {
        public IActionResult SearchProducts()
        {
            return View();
        }

        public IActionResult SearchResults(int minStock, int maxStock)
        {
            NorthwindDb db = new NorthwindDb(@"Data Source=.\sqlexpress;Initial Catalog=Northwnd;Integrated Security=True;");
            List<Product> products = db.SearchProducts(minStock, maxStock);
            SearchProductsViewModel vm = new SearchProductsViewModel
            {
                Products = products,
                MinStock = minStock,
                MaxStock = maxStock
            };
            return View(vm);
        }
    }
}