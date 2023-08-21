using CaseEntity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using TestCaseWebApp.Models;
using TestCaseWebApp.Utils;

namespace TestCaseWebApp.Controllers
{
    public class CategoryController : Controller
    {
        GlobalService globalService;



        public CategoryController(GlobalService _globalService)
        {

            globalService = _globalService;
        }
        public async Task<IActionResult> Index()
        {
            
            CategoryViewModel categoryViewModel = new CategoryViewModel();

            categoryViewModel.Categories = await globalService.GetAllCategories();
            return View(categoryViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            Category category = await globalService.GetCategoryById(id);            
            return View(category);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Category category)
        {
            var isUpdated = await globalService.UpdateCategory(category);
            if (isUpdated)
            {
                return RedirectToAction("Index");
            }

            return View(category);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View(new Category());
        }
        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            
            
            bool isCreated = await globalService.CreateCategory(category);

            if (isCreated)
            {
                return RedirectToAction("Index");
            }

            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            
            _= await globalService.DeleteCategory(id);
            return RedirectToAction("Index");
        }
    }
}
