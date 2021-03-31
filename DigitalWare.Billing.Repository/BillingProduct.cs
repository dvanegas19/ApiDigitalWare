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
    /// class to manage Product
    /// </summary>
    /// <history>
    ///    Version      Author              Date         Description
    ///    1.0.0.0      David Vanegas     29/03/2021   Creation
    /// </history>
    public class BillingProduct : Common.Interface.Repository.IProduct
    {
        public Task<Common.Entity.Result<IEnumerable<Common.Entity.Product>>> Get()
        {
            Common.Entity.Result<IEnumerable<Common.Entity.Product>> result = new Common.Entity.Result<IEnumerable<Common.Entity.Product>> { };
            using (var context = new BillingContext())
            {
                result.Data = context.Product.ToList();
            }
            return Task.FromResult(result);
        }
    }
}
