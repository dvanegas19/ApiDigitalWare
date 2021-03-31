using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWare.Billing.Common.Entity
{
    /// <summary>
    ///  Enumerators
    /// </summary>
    /// <history>
    ///  Version   Author              Date         Description
    ///  1.0.0.0   David Vanegas    27/11/2021  Creation
    /// </history>
    public partial class Enumerator
    {
        /// <summary>
        ///  Web service request method
        /// </summary>
        /// <history>
        ///  Version   Author              Date         Description
        ///  1.0.0.0   David Vanegas    27/11/2021  Creation
        /// </history>
        public enum WebServiceMethod {
            GET = 1,
            POST = 2,
            PUT = 3,
            DELETE = 4,
            PATH = 5
        };
    }
}
