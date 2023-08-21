using CaseEntity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using TestCaseWebApp.Models;
using TestCaseWebApp.Utils;

namespace TestCaseWebApp.Controllers
{
    public class ProductController : Controller
    {
        GlobalService globalService;


        public ProductController(GlobalService _globalService)
        {
            globalService = _globalService;
        }

        public async Task<IActionResult> Index()
        {
            ProductViewModel productViewModel = new ProductViewModel();
            

            productViewModel.Products = await globalService.GetAllProducts();
            productViewModel.Categories = await globalService.GetAllCategories();
            
            return View(productViewModel);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            bool isCreated =await globalService.CreateProduct(product);

            if (isCreated)
            {
                return Redirect("Index");
            }

            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            
            Product product =await globalService.GetProductById(id);
            
            return View(product);

        }
        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            bool isUpdated = await globalService.UpdateProduct(product);

            if (isUpdated)
            {
                return RedirectToAction("Index");
            }

            return View(product);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            _ = await globalService.DeleteProduct(id);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Filter(string category, string sortOrder = "price_asc")
        {
           
            ProductViewModel productViewModel = new ProductViewModel();

            productViewModel.Products = await globalService.FilterProducts(sortOrder, category ?? "all");
            productViewModel.Categories = await globalService.GetAllCategories();
            return View("Index",productViewModel);
        }

    }
}