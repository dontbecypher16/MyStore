﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyStore.Models;

namespace MyStore.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {

        private IProductRepository repository;
        public NavigationMenuViewComponent(IProductRepository repo)
        {
            repository = repo;
        }


        public IViewComponentResult Invoke()
        {
            return View(repository.Products
                      .Select(x => x.Category)
                      .Distinct()
                      .OrderBy(x => x));

        }

           




    }
}
