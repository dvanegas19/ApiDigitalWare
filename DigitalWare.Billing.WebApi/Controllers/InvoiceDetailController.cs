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
    [RoutePrefix("api/invoicedetail")]
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class InvoiceDetailController : ApiController
    {
        /// <summary>
        /// Convertion InvoiceDetail service
        /// </summary>
        private readonly Common.Interface.Business.IInvoiceDetail InvoiceDetailService;

        /// <summary>
        /// contructor
        /// </summary>
        ///  <see cref="App_Start.InjectorInitializer.InitializeContainer(Unity.UnityContainer)"/> to inject controller despendencies
        /// <param name="convertionRate"><see cref="Common.Interface.Business.IInvoiceDetail"/></param>
        public InvoiceDetailController(Common.Interface.Business.IInvoiceDetail invoice)
        {
            InvoiceDetailService = invoice;
        }

        // GET: api/InvoiceDetail
        public async Task<IHttpActionResult> Get()
        {
            var response = await InvoiceDetailService.Get();
            return Content(response.StatusCode, response);
        }

        // POST: api/InvoiceDetail
        public async Task<IHttpActionResult> Post(IEnumerable<Common.Entity.InvoiceDetail> invoiceDetails)
        {
            var response = await InvoiceDetailService.Insert(invoiceDetails);
            return Content(response.StatusCode, response);
        }
    }
}
