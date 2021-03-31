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
    public class BillingInvoice : Common.Interface.Repository.IInvoice
    {
        public Task<Common.Entity.Result<IEnumerable<Common.Entity.Invoice>>> Get()
        {
            Common.Entity.Result<IEnumerable<Common.Entity.Invoice>> result = new Common.Entity.Result<IEnumerable<Common.Entity.Invoice>> { };
            using (var context = new BillingContext())
            {
                result.Data = context.Invoice.ToList();
            }
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
        public Task<Common.Entity.Result<int>> Insert(Common.Entity.Invoice invoices)
        {
            Common.Entity.Result<int> result = new Common.Entity.Result<int> { };
            try
            {
                using (var context = new BillingContext())
                {
                    result.Data = context.Database.SqlQuery<int>("exec sp_InsertInvoice @RegistrationDate , @Total , @Iva , @IdClient",
                    new SqlParameter("@RegistrationDate", DateTime.Now),
                    new SqlParameter("@Total", invoices.Total),
                    new SqlParameter("@Iva", invoices.Iva),
                    new SqlParameter("@IdClient", invoices.Client.IdClient)).SingleOrDefault();
                    result.StatusCode = System.Net.HttpStatusCode.OK;
                    Log.Info($"new transactions were inserted....");
                }
            }
            catch (Exception ex)
            {
                result.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                Log.Exception(ex, $"{GetType().FullName}.Insert");
            }
            return Task.FromResult(result); 
        }

        public Task<Common.Entity.Result<bool>> Update(Common.Entity.Invoice invoice)
        {
            Common.Entity.Result<bool> result = new Common.Entity.Result<bool> { };
            try
            {
                using (var context = new BillingContext())
                {
                    ////truncate table
                    context.Invoice.RemoveRange(context.Invoice);
                    Log.Info($"Commercial transactions have been deleted in the database....");

                    ////insert new values
                    context.Invoice.Add(invoice);
                    context.SaveChanges();
                    Log.Info($"new transactions were inserted....");

                }
            }
            catch (Exception ex)
            {
                result.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                Log.Exception(ex, $"{GetType().FullName}.Update");
            }
            return Task.FromResult(result);
        }
    }
}
