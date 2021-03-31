namespace DigitalWare.Billing.Common.Entity
{
    /// <summary>
    /// web service request features
    /// </summary>
    /// <history>
    ///  Version   Author              Date         Description
    ///  1.0.0.0   David Vanegas     27/11/2021  Creation
    /// </history>
    public class WebServiceRequest
    {
        /// <summary>
        /// URI
        /// </summary>
        public string Uri { get; set; }
        /// <summary>
        /// Media Type
        /// </summary>
        public string MediaType { get; set; }
        /// <summary>
        /// request object
        /// </summary>
        public object Request { get; set; }
    }
}
