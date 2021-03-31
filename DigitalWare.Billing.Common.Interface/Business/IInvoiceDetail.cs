using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWare.Billing.Common.Interface.Business
{
    /// <summary>
    /// interface for manage Invoice
    /// </summary>
    /// <history>
    ///    Version      Author              Date         Description
    ///    1.0.0.0      David Vanegas     27/11/2021  Creation
    /// </history>
    public interface IInvoiceDetail
    {
        /// <summary>
        /// </summary>
        /// <returns><list><see cref="Entity.Invoice"/></list></returns>
        /// <returns><see cref="Entity.Result{T}"/></returns>
        /// <history>
        ///    Version      Author              Date         Description
        ///    1.0.0.0      David Vanegas     27/11/2021  Creation
        /// </history>
        Task<Entity.Result<IEnumerable<Entity.InvoiceDetail>>> Get();

        Task<Entity.Result<bool>> Insert(IEnumerable<Entity.InvoiceDetail> invoices);
    }
}
