using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using DigitalWare.Billing.Common.Util;

namespace DigitalWare.Billing.WebApp
{
    /// <summary>
    /// Http custom client
    /// </summary>
    /// <history>
    ///    Version      Author             Date         Description
    ///    1.0.0.0      David Vanegas    24/04/2019   Creation
    /// </history>
    public class HttpCustomClient 
    {
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
                    result.Data = response;
                };
            }
            catch (Exception ex)
            {
                result.StatusCode = HttpStatusCode.InternalServerError;
                result.Message = ex.Message;
            }
            return result;
        }

        public async Task<Common.Entity.Result<HttpResponseMessage>> PostAsync(Common.Entity.WebServiceRequest webServiceRequest)
        {
            Common.Entity.Result<HttpResponseMessage> result = new Common.Entity.Result<HttpResponseMessage> { };

            string json = await Task.Run(() => JsonConvert.SerializeObject(webServiceRequest.Request));
            try
            {
                using (HttpClient client = new HttpClient(new HttpClientHandler
                {
                    UseDefaultCredentials = false
                }))
                {
                    ////base address
                       var httpContent = new StringContent(json, Encoding.UTF8, webServiceRequest.MediaType);                 
                        
                        client.BaseAddress = new Uri(webServiceRequest.Uri);

                        // Update port # in the following line.
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(webServiceRequest.MediaType));

                        HttpResponseMessage response = new HttpResponseMessage();
                        ////execute get request
                        response = await client.PostAsync(webServiceRequest.Uri, httpContent);
                        response.EnsureSuccessStatusCode();
                        result.Data = response;
                    
                };
            }
            catch (Exception ex)
            {
                result.StatusCode = HttpStatusCode.InternalServerError;
                result.Message = ex.Message;
            }
            return result;
        }


    }
}
