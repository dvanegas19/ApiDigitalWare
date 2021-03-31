using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalWare.Billing.Common.Logger;

namespace DigitalWare.Billing.Repository
{
    /// <summary>
    /// class to manage Invoice
    /// </summary>
    /// <history>
    ///    Version      Author              Date         Description
    ///    1.0.0.0      David Vanegas     27/11/2021  Creation
    /// </history>
    public class BillingInvoiceDetail : Common.Interface.Repository.IInvoiceDetail
    {
        public Task<Common.Entity.Result<IEnumerable<Common.Entity.InvoiceDetail>>> Get()
        {
            Common.Entity.Result<IEnumerable<Common.Entity.InvoiceDetail>> result = new Common.Entity.Result<IEnumerable<Common.Entity.InvoiceDetail>> { };
            return Task.FromResult(result);
        }

        /// <summary>
        /// Save commercial transactions to repository
        /// </summary>
        /// <param name="commercialTransactions"><see cref="Common.Entity.Invoice"/></param>
        /// <returns>bool confirmation</returns>
        /// <history>
        ///    Version      Author              Date         Description
        ///    1.0.0.0      David Vanegas     27/11/2021  Creation
        /// </history>
        public Task<Common.Entity.Result<bool>> Insert(IEnumerable<Common.Entity.InvoiceDetail> invoiceDetail)
        {
            Common.Entity.Result<bool> result = new Common.Entity.Result<bool> { };
            try
            {


                invoiceDetail.ToList().ForEach(detail =>
                {
                    using (var context = new BillingContext())
                        {
                            //var IdInvoice = new System.Data.SqlClient.SqlParameter("@IdInvoice", 1);
                            //var RegistrationDate = new System.Data.SqlClient.SqlParameter("@RegistrationDate", DateTime.Now);
                            //var Unit = new System.Data.SqlClient.SqlParameter("@Unit", 1);
                            //var IdProduct = new System.Data.SqlClient.SqlParameter("@IdProduct",1);
                            var res = context.Database.SqlQuery<int>("exec sp_InsertInvoiceDetail @IdInvoice , @RegistrationDate , @Unit , @IdProduct",
                                new System.Data.SqlClient.SqlParameter("@IdInvoice", detail.IdInvoice),
                                new System.Data.SqlClient.SqlParameter("@RegistrationDate", detail.RegistrationDate),
                                new System.Data.SqlClient.SqlParameter("@Unit", detail.Unit),
                                new System.Data.SqlClient.SqlParameter("@IdProduct", detail.Product.IdProduct)
                                ).SingleOrDefault();
                        }
                });

                result.StatusCode = System.Net.HttpStatusCode.OK;
                    result.Data = true;;
                    Log.Info($"new transactions were inserted....");

                
            }
            catch (Exception ex)
            {
                result.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                Log.Exception(ex, $"{GetType().FullName}.Insert");
            }
            return Task.FromResult(result); 
        }
    }
}
