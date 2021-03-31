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
    /// Rates, service for manage the Convertion Rates
    /// </summary>
    /// <history>
    ///    Version      Autor              Date         Description
    ///    1.0.0.0      David Vanegas    27/11/2021  Creation
    /// </history>
    /// 
    
    [RoutePrefix("api/client")]
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class ClientController : ApiController
    {
        /// <summary>
        /// Convertion InvoiceDetail service
        /// </summary>
        private readonly Common.Interface.Business.IClient ClientService;

        /// <summary>
        /// contructor
        /// </summary>
        ///  <see cref="App_Start.InjectorInitializer.InitializeContainer(Unity.UnityContainer)"/> to inject controller despendencies
        /// <param name="convertionRate"><see cref="Common.Interface.Business.IClient"/></param>
        public ClientController(Common.Interface.Business.IClient client)
        {
            ClientService = client;
        }

        // GET: api/client
        public async Task<IHttpActionResult> Get()
        {
            var response = await ClientService.Get();
            return Content(response.StatusCode, response.Data);
        }

        // POST: api/client
        public async Task<IHttpActionResult> Post(Common.Entity.Client client)
        {       
            var response = await ClientService.Insert(client);
            return Content(response.StatusCode, response.Data);
        }

        // PUT: api/client
        public async Task<IHttpActionResult> Put(Common.Entity.Client client)
        {
            var response = await ClientService.Update(client);
            return Content(response.StatusCode, response.Data);
        }
    }
}
