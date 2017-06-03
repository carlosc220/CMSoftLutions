using BusinessLogic.ProductBusinessLogic;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMSoftLutions.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductLogic _productLogic = DependecyFactory.GetInstance<IProductLogic>();

        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListProducts(string search) => Json(_productLogic.ListProducts(search), JsonRequestBehavior.AllowGet);
    }
}