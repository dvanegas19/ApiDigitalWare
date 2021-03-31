using System.Net.Http;
using System.Threading.Tasks;

namespace DigitalWare.Billing.Common.Interface.Interoperability
{
    /// <summary>
    ///  Interface for manage http custom client
    /// </summary>
    /// <history>
    ///    Version      Author              Date         Description
    ///    1.0.0.0      David Vanegas     27/11/2021  Creation
    /// </history>
    public interface IHttpCustomClient
    {
        /// <summary>
        /// method for send a GET request
        /// </summary>
        /// <param name="webServiceRequest"><see cref="Entity.WebServiceRequest"/></param>
        /// <returns><see cref="Entity.Result{T}"/></returns>
        /// <history>
        ///    Version      Author              Date         Description
        ///    1.0.0.0      David Vanegas     27/11/2021  Creation
        /// </history>
        Task<Entity.Result<HttpResponseMessage>> GetAsync(Entity.WebServiceRequest webServiceRequest);
    }
}
