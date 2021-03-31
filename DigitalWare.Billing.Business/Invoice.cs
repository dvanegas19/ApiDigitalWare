using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalWare.Billing.Common.Logger;

namespace DigitalWare.Billing.Business
{
    /// <summary>
    /// Currency converter service
    /// </summary>
    /// <history>
    ///    Version      Author              Date         Description
    ///    1.0.0.0      David Vanegas     27/11/2021  Creation
    /// </history>
    public class Invoice : Common.Interface.Business.IInvoice
    {

        private readonly DigitalWare.Billing.Common.Interface.Repository.IInvoice InvoiceService;

        public Invoice(DigitalWare.Billing.Common.Interface.Repository.IInvoice invoiceService) {
            InvoiceService = invoiceService;
        }

        /// <summary>
        /// </summary>
        /// <param name="Invoice"><see cref="Entity.Invoice"/>Invoice</param>
        /// <returns></returns>
        /// <history>
        ///    Version      Author              Date         Description
        ///    1.0.0.0      David Vanegas     27/11/2021  Creation
        /// </history>
        public async Task<Common.Entity.Result<IEnumerable<Common.Entity.Invoice>>> Get()
        {
            Common.Entity.Result<IEnumerable<Common.Entity.Invoice>> result = new Common.Entity.Result<IEnumerable<Common.Entity.Invoice>> { };
            try
            {
                result = await InvoiceService.Get();
            }
            catch (Exception ex)
            {
                result.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                Log.Exception(ex, $"{GetType().FullName}.Convert");
            }
            return await Task.FromResult(result);
        }

        public async Task<Common.Entity.Result<int>> Insert(Common.Entity.Invoice invoice) {
            Common.Entity.Result<int> result = new Common.Entity.Result<int> { };
            try
            {
                result = await InvoiceService.Insert(invoice);
            }
            catch (Exception ex)
            {
                result.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                Log.Exception(ex, $"{GetType().FullName}.Insert");
            }
            return await Task.FromResult(result);
        }
    }
}
