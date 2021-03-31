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
    public class InvoiceDetail : Common.Interface.Business.IInvoiceDetail
    {

        private readonly DigitalWare.Billing.Common.Interface.Repository.IInvoiceDetail InvoiceDetailService;
        public InvoiceDetail(Common.Interface.Repository.IInvoiceDetail invoiceDetailService)
        {
            InvoiceDetailService = invoiceDetailService;
        }
        /// <summary>
        /// </summary>
        /// <param name="InvoiceDetail"><see cref="Entity.InvoiceDetail"/>convertion rate</param>
        /// <returns></returns>
        /// <history>
        ///    Version      Author              Date         Description
        ///    1.0.0.0      David Vanegas     27/11/2021  Creation
        /// </history>
        public async Task<Common.Entity.Result<IEnumerable<Common.Entity.InvoiceDetail>>> Get()
        {
            Common.Entity.Result<IEnumerable<Common.Entity.InvoiceDetail>> result = new Common.Entity.Result<IEnumerable<Common.Entity.InvoiceDetail>> { };
            try
            {
                result = await InvoiceDetailService.Get();
            }
            catch (Exception ex)
            {
                result.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                Log.Exception(ex, $"{GetType().FullName}.Convert");
            }
            return await Task.FromResult(result);
        }

        public async Task<Common.Entity.Result<bool>> Insert(IEnumerable<Common.Entity.InvoiceDetail> invoices) {
            Common.Entity.Result<bool> result = new Common.Entity.Result<bool> { };
            try
            {
                result = await InvoiceDetailService.Insert(invoices);
            }
            catch (Exception ex)
            {
                result.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                Log.Exception(ex, $"{GetType().FullName}.Convert");
            }
            return await Task.FromResult(result);
        }
    }
}
