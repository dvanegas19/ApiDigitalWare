using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using DigitalWare.Billing.Common.Logger;

namespace DigitalWare.Billing.Common.Util
{
    /// <summary>
    /// class for serializations
    /// </summary>
    /// <history>
    ///    Version      Author              Date         Description
    ///    1.0.0.0      David Vanegas     27/11/2021  Creation
    /// </history>
    public static class Serialization
    {
        /// <summary>
        ///   Json HttpResponse to object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="httpResponseMessage"></param>
        /// <returns><typeparam name="T"></typeparam></returns>
        /// <history>
        ///    Version      Author              Date         Description
        ///    1.0.0.0      David Vanegas     27/11/2021  Creation
        /// </history>
        public static async Task<Entity.Result<T>> JsonHttpResponseToObject<T>(System.Net.Http.HttpResponseMessage httpResponseMessage)
        {
            Entity.Result<T> result = new Entity.Result<T> { };
            try
            {
                var responseString = await httpResponseMessage.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(responseString))
                {
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    result.Data = serializer.Deserialize<T>(responseString);
                }
            }
            catch (Exception ex)
            {
                result.StatusCode = System.Net.HttpStatusCode.OK;
                Log.Exception(ex, "DigitalWare.Billing.Common.Util.Serialization.JsonHttpResponseToObject");
            }
            return result;
        }

        public static async Task<Entity.Result<T>> JsonStringToObject<T>(string responseString)
        {
            Entity.Result<T> result = new Entity.Result<T> { };
            try
            {
                if (!string.IsNullOrEmpty(responseString))
                {
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    result.Data = serializer.Deserialize<T>(responseString);
                }
            }
            catch (Exception ex)
            {
                result.StatusCode = System.Net.HttpStatusCode.OK;
                Log.Exception(ex, "DigitalWare.Billing.Common.Util.Serialization.JsonStringToObject");
            }
            return result;
        }
    }
}
