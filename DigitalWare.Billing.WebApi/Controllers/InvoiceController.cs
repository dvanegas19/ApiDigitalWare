using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DigitalWare.Billing.WebApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <history>
    ///    Version      Autor              Date         Description
    ///    1.0.0.0      David Vanegas    27/11/2021  Creation
    /// </history>
    [RoutePrefix("api/invoice")]
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class InvoiceController : ApiController
    {
        /// <summary>
        /// Convertion Invoice service
        /// </summary>
        private readonly Common.Interface.Business.IInvoice InvoiceService;

        /// <summary>
        /// contructor
        /// </summary>
        ///  <see cref="App_Start.InjectorInitializer.InitializeContainer(Unity.UnityContainer)"/> to inject controller despendencies
        /// <param name="convertionRate"><see cref="Common.Interface.Business.IInvoice"/></param>
        public InvoiceController(Common.Interface.Business.IInvoice invoice)
        {
            InvoiceService = invoice;
        }

        // GET: api/invoice
        public async Task<IHttpActionResult> Get()
        {
            var response = await InvoiceService.Get();
            return Content(response.StatusCode, response);
        }

        // POST: api/invoice
        public async Task<IHttpActionResult> Post(Common.Entity.Invoice invoice)
        {
            var response = await InvoiceService.Insert(invoice);
            return Content(response.StatusCode, response.Data);
        }
    }
}
