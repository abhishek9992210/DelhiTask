using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using DelhiTask.Entities;
using DelhiTask.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
//using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace DelhiTask.Controllers
{
    // ProductController.cs
    public class ProductController : Controller
    {
        private readonly delhitaskContext _context;
        private readonly IConfiguration _configuration;
        string connection;

        public ProductController(delhitaskContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
            connection = configuration.GetConnectionString("defaultconnections");

        }

        public IActionResult Search()
        {
            ViewBag.products = _context.Products.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Search(ProductSearchModel searchviewmodel)
        {
            // Call the stored procedure using DbContext
            if (searchviewmodel.Conjunction == "AND")
            {
                    ViewBag.results = _context.Products.FromSqlRaw("exec searchproducts {0}, {1}, {2}, {3}, {4}",
                    searchviewmodel.ProductName,
                    searchviewmodel.Size,
                    searchviewmodel.Price,
                    searchviewmodel.MfgDate,
                    searchviewmodel.Category).ToList();
            }
            else
            {
                ViewBag.results = _context.Products.FromSqlRaw("exec SearchProductsWithOR {0}, {1}, {2}, {3}, {4}",
                    searchviewmodel.ProductName,
                    searchviewmodel.Size,
                    searchviewmodel.Price,
                    searchviewmodel.MfgDate,
                    searchviewmodel.Category).ToList();
            }
            ViewBag.products = _context.Products.ToList();
            return View(searchviewmodel);
        }

    }

}
