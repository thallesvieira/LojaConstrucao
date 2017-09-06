using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LojaConstrucao.Domain;
using LojaConstrucao.Web.ViewsModels;
using Microsoft.AspNetCore.Authorization;

namespace LojaConstrucao.Web.Controllers
{
    [Authorize(Roles = "Admin, Manager")]
    public class CategoryController : Controller
    {
        private readonly CategorytStore _categoryStore;
        private readonly IRepository<Category> _categoryRepository;

        public CategoryController(CategorytStore categoryStore, IRepository<Category> categoryRepository)
        {
            _categoryStore = categoryStore;
            _categoryRepository = categoryRepository;
        }
        public IActionResult Index()
        {
            var categories = _categoryRepository.All();
            var viewsModels = categories.Select(c => new CategoryViewModel { Id = c.Id, Name = c.Name });
            return View(viewsModels);
        }
       
        public IActionResult CreateOrEdit(int id)
        {
            if ( id > 0) {
                var category = _categoryRepository.GetById(id);
                var categoryviewModel = new CategoryViewModel { Id = category.Id, Name = category.Name };
                return View(categoryviewModel);
            }
            return View();
        }

        [HttpPost]
        public IActionResult CreateOrEdit(CategoryViewModel viewModel)
        {
            _categoryStore.Store(viewModel.Id, viewModel.Name);
            return RedirectToAction("Index");
        }
    }
}
