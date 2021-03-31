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
    public class Product : Common.Interface.Business.IProduct
    {

        private readonly DigitalWare.Billing.Common.Interface.Repository.IProduct ProductService;
        public Product(Common.Interface.Repository.IProduct productService)
        {
            ProductService = productService;
        }
        /// <summary>
        /// </summary>
        /// <param name="InvoiceDetail"><see cref="Entity.InvoiceDetail"/>convertion rate</param>
        /// <returns></returns>
        /// <history>
        ///    Version      Author              Date         Description
        ///    1.0.0.0      David Vanegas     27/11/2021  Creation
        /// </history>
        public async Task<Common.Entity.Result<IEnumerable<Common.Entity.Product>>> Get()
        {
            Common.Entity.Result<IEnumerable<Common.Entity.Product>> result = new Common.Entity.Result<IEnumerable<Common.Entity.Product>> { };
            try
            {
                result = await ProductService.Get();
            }
            catch (Exception ex)
            {
                result.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                Log.Exception(ex, $"{GetType().FullName}.get");
            }
            return await Task.FromResult(result);
        }
    }
}
