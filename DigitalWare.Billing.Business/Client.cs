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
    public class Client : Common.Interface.Business.IClient
    {

        private readonly DigitalWare.Billing.Common.Interface.Repository.IClient ClientService;
        public Client(Common.Interface.Repository.IClient clientService)
        {
            ClientService = clientService;
        }
        /// <summary>
        /// </summary>
        /// <param name="InvoiceDetail"><see cref="Entity.InvoiceDetail"/>convertion rate</param>
        /// <returns></returns>
        /// <history>
        ///    Version      Author              Date         Description
        ///    1.0.0.0      David Vanegas     27/11/2021  Creation
        /// </history>
        public async Task<Common.Entity.Result<IEnumerable<Common.Entity.Client>>> Get()
        {
            Common.Entity.Result<IEnumerable<Common.Entity.Client>> result = new Common.Entity.Result<IEnumerable<Common.Entity.Client>> { };
            try
            {
                result = await ClientService.Get();
            }
            catch (Exception ex)
            {
                result.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                Log.Exception(ex, $"{GetType().FullName}.Convert");
            }
            return await Task.FromResult(result);
        }

        public async Task<Common.Entity.Result<int>> Insert(Common.Entity.Client client)
        {
            Common.Entity.Result<int> result = new Common.Entity.Result<int> { };
            try
            {
                result = await ClientService.Insert(client);
            }
            catch (Exception ex)
            {
                result.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                Log.Exception(ex, $"{GetType().FullName}.Insert");
            }
            return await Task.FromResult(result);
        }

        public async Task<Common.Entity.Result<int>> Update(Common.Entity.Client client)
        {
            Common.Entity.Result<int> result = new Common.Entity.Result<int> { };
            try
            {
                result = await ClientService.Update(client);
            }
            catch (Exception ex)
            {
                result.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                Log.Exception(ex, $"{GetType().FullName}.Update");
            }
            return await Task.FromResult(result);
        }
    }
}
