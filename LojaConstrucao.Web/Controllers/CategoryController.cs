﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LojaConstrucao.Web.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
       
        public IActionResult CreateOrEditGet()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateOrEdit()
        {
            return View();
        }
    }
}
