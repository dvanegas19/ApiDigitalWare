using Microsoft.VisualStudio.TestTools.UnitTesting;
using DigitalWare.Billing.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWare.Billing.WebApi.Tests
{
    

    [TestClass()]
    public class BillingInvoiceTest
    {
        private Common.Interface.Interoperability.IHttpCustomClient HttpCustomClient = new Interoperability.HttpCustomClient();
        //private readonly Common.Interface.Business. CurrencyConverterService = new Business.CurrencyConverter();
        private readonly Common.Interface.Business.IInvoice ConvertionRateService = new Business.Invoice();

           [TestMethod()]
        public async Task GetTest()
        {
            var result = await new Business.Invoice().Get();
            Assert.IsTrue(result.StatusCode == System.Net.HttpStatusCode.OK);
        }

    }
}
