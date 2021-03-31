using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWare.Billing.Common.Entity
{
    /// <summary>
    ///  All soluctions methods return this class
    /// </summary>
    /// <history>
    ///  Version   Author              Date         Description
    ///  1.0.0.0   David Vanegas    27/11/2021  Creation
    /// </history>
    [DefaultMember("Item")]
    public partial class Result<T>
    {
        /// <summary>
        /// Status Code of a logic process.
        /// </summary>
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
        /// <summary>
        /// Message of a logic process.
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Data of a logic process.
        /// </summary>
        public T Data { get; set; }
    }
}
