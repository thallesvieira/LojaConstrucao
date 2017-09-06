﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LojaConstrucao.Domain;
using LojaConstrucao.Domain.Products;
using LojaConstrucao.Web.ViewsModels;

namespace LojaConstrucao.Web.Controllers
{
    [Authorize(Roles = "Admin, Manager")]
    public class ProductController : Controller
    {
        private readonly ProductStore _productStore;
        public readonly IRepository<Product> _productRepository;
        private readonly IRepository<Category> _categoryRepository;

        public ProductController(ProductStore productStore, IRepository<Category> categoryRepository, IRepository<Product> productRepository)
        {
            _productStore = productStore;
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }
        public IActionResult Index()
        {
            var products = _productRepository.All();
            if (products.Any())
            {
                var viewsModels = products.Select(p => new ProductViewModel { Id = p.Id, Name = p.Name, CategoryName = p.Category.Name });

                return View(viewsModels);
            }
            return View();
        }
       
        public IActionResult CreateOrEdit(int id)
        {
            var viewModel = new ProductViewModel();
            var categories = _categoryRepository.All();

            if (categories.Any())
            {
                viewModel.Categories = categories.Select(c => new CategoryViewModel { Id = c.Id, Name = c.Name});
            }

            if (id > 0)
            {
                var product =  _productRepository.GetById(id);
                viewModel.Id = product.Id;
                viewModel.Name = product.Name;
                viewModel.CategoryId = product.Category.Id;
                viewModel.Price = product.Price;
                viewModel.StockQuantity = product.StockQuantity;
                return View(viewModel);
            }
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult CreateOrEdit(ProductViewModel viewModel)
        {
            _productStore.Store(viewModel.Id, viewModel.Name, viewModel.CategoryId, viewModel.Price, viewModel.StockQuantity);
            return RedirectToAction("Index");
        }
    }
}