using DigitalWare.Billing.Common.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DigitalWare.Billing.WebApp.Controllers
{
    public class InvoiceDetailController : Controller
    {
        // GET: InvoiceDetail
        public ActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> List()
        {
            var request = new WebServiceRequest
            {
                MediaType = "application/json",
                Uri = string.Format("{0}", ConfigurationManager.AppSettings["BillingWebApiUri"])
            };
            var response = await new HttpCustomClient().GetAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return Json(response, JsonRequestBehavior.AllowGet);
            }
            return Json("Problemas al cargar el detalle", JsonRequestBehavior.AllowGet);
        }

        // POST: InvoiceDetail/Create
        [HttpPost]
        public async Task<JsonResult> Create([Bind(Include = "IdInvoice,RegistrationDate,Total,Iva, IdClient")] Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                //Pendiente por cargar lista y trael el dato
                invoice.Client = new Client { IdClient = 1 };
                var request = new WebServiceRequest
                {
                    MediaType = "application/json",
                    Request = invoice,
                    Uri = string.Format("{0}", ConfigurationManager.AppSettings["BillingWebApiUri"])
                };
                var response = await new HttpCustomClient().PostAsync(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return Json(response, JsonRequestBehavior.AllowGet);

                }
            }
            return Json("Problemas al guardar la factura", JsonRequestBehavior.AllowGet);
        }
    }
}