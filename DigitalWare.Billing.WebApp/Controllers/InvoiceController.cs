using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DigitalWare.Billing.Common.Entity;
using DigitalWare.Billing.Common.Util;
using Newtonsoft.Json.Linq;


namespace DigitalWare.Billing.WebApp.Controllers
{

    public class InvoiceController : Controller
    {
        IEnumerable<DigitalWare.Billing.Common.Entity.Invoice> model;
        // GET: Invoice
        public ActionResult Index()
        {
            return View();
        }
     

        // GET: Invoice/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Invoice/SaveInvoice
        [HttpPost]
        public async Task<JsonResult>  SaveInvoice(Invoice invoice)
        {
            //if (ModelState.IsValid)
            //{
                invoice.RegistrationDate = DateTime.Now;
                var request = new WebServiceRequest
                {
                    MediaType = "application/json",
                    Request = invoice,
                    Uri = string.Format("{0}", ConfigurationManager.AppSettings["BillingWebApiUri"] + "invoice")
                };
                var response = await new HttpCustomClient().PostAsync(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var IdInvoice = await Serialization.JsonStringToObject<int>(response.Data.Content.ReadAsStringAsync().Result);
                    return Json(IdInvoice, JsonRequestBehavior.AllowGet);
                    
                }
            //}
            return  Json("Problemas al guardar la factura", JsonRequestBehavior.AllowGet);
        }

        // POST: Invoice/SaveInvoiceDetail
        [HttpPost]
        public async Task<JsonResult> SaveInvoiceDetail(IEnumerable<InvoiceDetail> invoiceDetail)
        {
            if (ModelState.IsValid)
            {

                invoiceDetail.ToList().ForEach(record =>
                {
                    record.RegistrationDate = DateTime.Now;
                });
                var request = new WebServiceRequest
                {
                    MediaType = "application/json",
                    Request = invoiceDetail,
                    Uri = string.Format("{0}", ConfigurationManager.AppSettings["BillingWebApiUri"] + "invoicedetail")
                };
                var response = await new HttpCustomClient().PostAsync(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var IdInvoice = await Serialization.JsonStringToObject<int>(response.Data.Content.ReadAsStringAsync().Result);
                    return Json(IdInvoice, JsonRequestBehavior.AllowGet);

                }
            }
            return Json("Problemas al guardar la factura", JsonRequestBehavior.AllowGet);
        }

        public async  Task<JsonResult> ListClient()
        {
            HttpCustomClient httpCustomClient = new HttpCustomClient();
                var request = new WebServiceRequest
                {
                    MediaType = "application/json",
                    Uri = string.Format("{0}", ConfigurationManager.AppSettings["BillingWebApiUri"]+"client")
                };

            var response = await new HttpCustomClient().GetAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var list = await Serialization.JsonStringToObject<IEnumerable<Client>>(response.Data.Content.ReadAsStringAsync().Result);
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }

        public async  Task<JsonResult> ListProduct()
        {
            HttpCustomClient httpCustomClient = new HttpCustomClient();
            var request = new WebServiceRequest
            {
                MediaType = "application/json",
                Uri = string.Format("{0}", ConfigurationManager.AppSettings["BillingWebApiUri"] + "product")
            };

            var response = await new HttpCustomClient().GetAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {                
                var list = await Serialization.JsonStringToObject<IEnumerable<Product>>(response.Data.Content.ReadAsStringAsync().Result);
                return Json(list, JsonRequestBehavior.AllowGet);

            }
            else {
                return Json("", JsonRequestBehavior.AllowGet);
            }
          
        }

        /*public JsonResult Add(Invoice emp)
        {
            return Json(empDB.Add(emp), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetbyID(int ID)
        {
            var Employee = empDB.ListAll().Find(x => x.EmployeeID.Equals(ID));
            return Json(Employee, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(Invoice emp)
        {
            return Json(empDB.Update(emp), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int ID)
        {
            return Json(empDB.Delete(ID), JsonRequestBehavior.AllowGet);
        }*/
    }
}
