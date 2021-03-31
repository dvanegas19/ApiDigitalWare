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
    /// class to manage Client
    /// </summary>
    /// <history>
    ///    Version      Author              Date         Description
    ///    1.0.0.0      David Vanegas     29/03/2021   Creation
    /// </history>
    public class BillingClient : Common.Interface.Repository.IClient
    {
        public Task<Common.Entity.Result<IEnumerable<Common.Entity.Client>>> Get()
        {
            Common.Entity.Result<IEnumerable<Common.Entity.Client>> result = new Common.Entity.Result<IEnumerable<Common.Entity.Client>> { };
            using (var context = new BillingContext())
            {
                result.Data = context.Client.ToList();
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
        public Task<Common.Entity.Result<int>> Insert(Common.Entity.Client client)
        {
            Common.Entity.Result<int> result = new Common.Entity.Result<int> { };
            try
            {
                using (var context = new BillingContext())
                {
                    ////truncate table
                    context.Invoice.RemoveRange(context.Invoice);
                    Log.Info($"Commercial transactions have been deleted in the database....");
                    client.RegisterDate = DateTime.Now;
                    ////insert new values
                    context.Client.Add(client);
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

        public Task<Common.Entity.Result<int>> Update(Common.Entity.Client client)
        {
            Common.Entity.Result<int> result = new Common.Entity.Result<int> { };
            try
            {
                using (var context = new BillingContext())
                {
                    ////truncate table
                    context.Client.RemoveRange(context.Client);
                    Log.Info($"Commercial transactions have been deleted in the database....");

                    ////insert new values
                    context.Client.Add(client);
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
