using BusinessLogic.CustomerBusinessLogic;
using BusinessLogic.InvoiceBusinessLogic;
using BusinessLogic.ProductBusinessLogic;
using Common;
using Microsoft.VisualBasic;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CMSoftLutions.Controllers
{
    public class InvoiceController : Controller
    {


        private readonly IInvoiceLogic _invoiceLogic = DependecyFactory.GetInstance<IInvoiceLogic>();
        // GET: Invoice
        public ActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> SaveInvoce(Invoice Invoice)
        {
            var rm = new ResponseModel();

            if (!ModelState.IsValid)
            {
                rm.message = Utils.Utils.GetErrorsModel(ModelState);
            }

            var validateMessage = ValidateInvoice(Invoice);

            if (validateMessage.Length > 0)
            {
                rm.SetResponse(false, validateMessage);
                return Json(rm);
            }
            rm = await _invoiceLogic.SaveInvoice(Invoice);
            if (rm.response)
            {
                rm.href = "self";
            }
            return Json(rm);
        }



        private string ValidateInvoice(Invoice invoice)
        {
            var errors = new List<string>();
            if (invoice.CustomerId == 0)
            {
                errors.Add("Seleccione un cliente");
            }
            if (!Information.IsDate(invoice.InvoiceDate))
            {
                errors.Add("Fecha de Factura Invalida");
            }

            if (invoice.InvoiceDetail.Count == 0)
            {
                errors.Add("Se debe agregar minimo un detalle a la factura");
            }           


            return string.Join(", ", errors);
        }

    }
}