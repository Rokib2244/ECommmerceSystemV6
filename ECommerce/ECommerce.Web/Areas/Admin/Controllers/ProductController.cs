using Autofac;
using ECommerce.Infrastructure;
using ECommerce.Infrastructure.Features.Exceptions;
using ECommerce.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        ILifetimeScope _scope;
        ILogger<ProductController> _logger;
        public ProductController(ILifetimeScope scope, ILogger<ProductController> logger)
        {
            _scope = scope;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = _scope.Resolve<ProductListModel>();
            return View(model);
        }
        public async Task<JsonResult> GetProducts()
        {
            var dataTableModel = new DataTablesAjaxRequestUtility(Request);
            var model = _scope.Resolve<ProductListModel>();

            var data = await model.GetPagedProductAsync(dataTableModel);

            return Json(data);
        }



        public IActionResult Create()
        {
            var model = _scope.Resolve<ProductCreateModel>();

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductCreateModel model)
        {
            model.ResolveDependency(_scope);
            if (ModelState.IsValid)
            {
                try
                {
                    model.CreateProduct();
                }
                catch(DuplicateNameException ex)
                { 
                    _logger.LogError(ex, ex.Message);
                }
                catch(Exception e)
                {
                    _logger.LogError(e, "servcer error");
                }
            }

            return RedirectToAction("Index");
        }
        public IActionResult Update(Guid id)
        {
            var model = _scope.Resolve<ProductUpdateModel>();
            model.Load(id);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(ProductUpdateModel model)
        {
            model.ResolveDependency(_scope);
            if (ModelState.IsValid)
            {
                try
                {
                    model.UpdateProduct();
                }
                catch (DuplicateNameException ex)
                {
                    _logger.LogError(ex, ex.Message);
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "servcer error");
                }
            }

            return RedirectToAction("Index");
        }
        

        public IActionResult Delete(Guid id)
        {
            var model = _scope.Resolve<ProductListModel>();
            if (ModelState.IsValid)
            {
                try
                {
                    model.DeleteProduct(id);
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "servcer error");
                }
            }

            return RedirectToAction("Index");
        }
    }

    
}
