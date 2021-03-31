using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWare.Billing.Common.Interface.Business
{
    /// <summary>
    /// interface for manage the Invoice
    /// </summary>
    /// <history>
    ///    Version      Author              Date         Description
    ///    1.0.0.0      David Vanegas     27/11/2021  Creation
    /// </history>
    public interface IInvoice
    {
        /// <summary>
        /// Get all convertion Invoice
        /// </summary>
        /// <returns><list><see cref="Entity.Invoice"/></list></returns>
        /// <returns><see cref="Entity.Result{T}"/></returns>
        /// <history>
        ///    Version      Author              Date         Description
        ///    1.0.0.0      David Vanegas     27/11/2021  Creation
        /// </history>
        Task<Entity.Result<IEnumerable<Entity.Invoice>>> Get();

        Task<Entity.Result<int>> Insert(Entity.Invoice invoice);
    }
}
