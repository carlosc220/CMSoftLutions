using BusinessLogic.CustomerBusinessLogic;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMSoftLutions.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerLogic _customerLogic = DependecyFactory.GetInstance<ICustomerLogic>();

        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListCustomers(string search) => Json(_customerLogic.LitsCustomers(search), JsonRequestBehavior.AllowGet);
    }
}