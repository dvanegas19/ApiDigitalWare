using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalWare.Billing.Common.Interface.Repository
{
    /// <summary>
    /// interface to manage the Product
    /// </summary>
    /// <history>
    ///    Version      Author              Date         Description
    ///    1.0.0.0      David Vanegas     27/11/2021  Creation
    /// </history>
    public interface IProduct
    {
        /// <summary>
        /// Get all Invoices
        /// </summary>
        /// <returns><list><see cref="Entity.Product"/></list></returns>
        /// <history>
        ///    Version      Author              Date         Description
        ///    1.0.0.0      David Vanegas     27/11/2021  Creation
        /// </history>
        Task<Entity.Result<IEnumerable<Entity.Product>>> Get();
    }
}
