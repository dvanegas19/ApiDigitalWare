using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalWare.Billing.Common.Interface.Repository
{
    /// <summary>
    /// interface to manage the Invoices
    /// </summary>
    /// <history>
    ///    Version      Author              Date         Description
    ///    1.0.0.0      David Vanegas     27/11/2021  Creation
    /// </history>
    public interface IInvoiceDetail
    {
        /// <summary>
        /// Get all Invoices
        /// </summary>
        /// <returns><list><see cref="Entity.Invoice"/></list></returns>
        /// <history>
        ///    Version      Author              Date         Description
        ///    1.0.0.0      David Vanegas     27/11/2021  Creation
        /// </history>
        Task<Entity.Result<IEnumerable<Entity.InvoiceDetail>>> Get();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="commercialTransactions"><see cref="Entity.InvoiceDetail"/></param>
        /// <returns>bool confirmation</returns>
        /// <history>
        ///    Version      Author              Date         Description
        ///    1.0.0.0      David Vanegas     27/11/2021  Creation
        /// </history>
        Task<Entity.Result<bool>> Insert(IEnumerable<Entity.InvoiceDetail> invoiceDetails);

    }
}
