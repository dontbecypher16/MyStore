using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyStore.Models;
using MyStore.Models.ViewModels;




namespace MyStore.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository _repository;
        public int PageSize = 4;
        public ProductController(IProductRepository repository)
        {

            _repository = repository;




        }

        public ViewResult List(string category, int productPage = 1)

            
            {

                var query = _repository.Products
                            .Where(p => category == null ||
                            p.Category == category)
                           .OrderBy(p => p.ProductID);

              var model = new ProductsListViewModel
                {
                    Products = query
                           .Skip((productPage - 1) * PageSize)
                           .Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = productPage,
                        ItemsPerPage = PageSize,
                        TotalItems = query.Count()
                    },

                    CurrentCategory = category
                };
                      
    
               return View(model);


            }



















    }
}
