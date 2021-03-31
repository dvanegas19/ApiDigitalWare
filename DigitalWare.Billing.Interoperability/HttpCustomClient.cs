using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;

using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;
using System.Xml.Linq;

using System.IO;
using DigitalWare.Billing.Common.Logger;

namespace DigitalWare.Billing.Interoperability
{
    /// <summary>
    /// Http custom client
    /// </summary>
    /// <history>
    ///    Version      Author             Date         Description
    ///    1.0.0.0      David Vanegas    29/03/2021   Creation
    /// </history>
    public class HttpCustomClient : Common.Interface.Interoperability.IHttpCustomClient
    {
        /// <summary>
        /// Log service
        /// </summary>
        //private readonly Common.Interface.Business.ILog LogService;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="log"><see cref="Common.Interface.Business.ILog"/></param>
        //public HttpCustomClient(Common.Interface.Business.ILog log)
        public HttpCustomClient()
        {
        }

        /// <summary>
        /// method for send a GET request
        /// </summary>
        /// <param name="webServiceRequest"><see cref="Common.Entity.WebServiceRequest"/></param>
        /// <returns><see cref="Entity.Result{T}"/></returns>
        /// <history>
        ///    Version      Author              Date         Description
        ///    1.0.0.0      David Vanegas     27/11/2021  Creation
        /// </history>
        public async Task<Common.Entity.Result<HttpResponseMessage>> GetAsync(Common.Entity.WebServiceRequest webServiceRequest)
        {
            Common.Entity.Result<HttpResponseMessage> result = new Common.Entity.Result<HttpResponseMessage> { };
            try
            {
                using (HttpClient client = new HttpClient(new HttpClientHandler
                {
                    UseDefaultCredentials = false
                }))
                {
                    ////base address
                    client.BaseAddress = new Uri(webServiceRequest.Uri);

                    // Update port # in the following line.
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(webServiceRequest.MediaType));

                    HttpResponseMessage response = new HttpResponseMessage();
                    
                    ////execute get request
                    response = await client.GetAsync(webServiceRequest.Uri);
                    response.EnsureSuccessStatusCode();
                    Log.Info($"web service uri: {webServiceRequest.Uri} called succefully, status code: {response.StatusCode}");
                    result.Data = response;
                };
            }
            catch (Exception ex)
            {
                result.StatusCode = HttpStatusCode.InternalServerError;
                result.Message = ex.Message;
                Log.Exception(ex, $"{GetType().FullName}.Insert");
            }
            return result;
        }


    }
}
