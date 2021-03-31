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
    [RoutePrefix("api/product")]
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class ProductController : ApiController
    {
        /// <summary>
        /// Convertion InvoiceDetail service
        /// </summary>
        private readonly Common.Interface.Business.IProduct ProductService;

        /// <summary>
        /// contructor
        /// </summary>
        ///  <see cref="App_Start.InjectorInitializer.InitializeContainer(Unity.UnityContainer)"/> to inject controller despendencies
        /// <param name="convertionRate"><see cref="Common.Interface.Business.IProduct"/></param>
        public ProductController(Common.Interface.Business.IProduct product)
        {
            ProductService = product;
        }

        // GET: api/client
        public async Task<IHttpActionResult> Get()
        {
            var response = await ProductService.Get();
            return Content(response.StatusCode, response.Data);
        }
    }
}
