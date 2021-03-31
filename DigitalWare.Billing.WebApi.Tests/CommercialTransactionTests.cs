using Microsoft.VisualStudio.TestTools.UnitTesting;
using DigitalWare.Billing.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWare.Billing.Business.Tests
{
    [TestClass()]
    public class CommercialTransactionTests
    {
        private static readonly Common.Interface.Interoperability.IHttpCustomClient HttpCustomClient = new Interoperability.HttpCustomClient();
        //private readonly Common.Interface.Business. CurrencyConverterService = new Business.CurrencyConverter();
        private readonly Common.Interface.Business.IConvertionRate ConvertionRateService = new Business.ConvertionRate(HttpCustomClient);
        //private readonly Common.Interface.Repository.ICommercialTransaction CommercialTransactionRepository = new Repository.BillingTransaction();

       /* [TestMethod()]
        public async Task GetTest()
        {
            var result = await new Business.CommercialTransaction(HttpCustomClient, CurrencyConverterService, ConvertionRateService, CommercialTransactionRepository).Get();
            Assert.IsTrue(result.StatusCode == System.Net.HttpStatusCode.OK);
        }*/

        /*[TestMethod()]
        public async Task GetConvertionTest()
        {
            var result = await new Business.CommercialTransaction(HttpCustomClient, CurrencyConverterService, ConvertionRateService, CommercialTransactionRepository).Get("S1955", "EUR");
            Assert.IsTrue(result.StatusCode == System.Net.HttpStatusCode.OK);
        }*/
    }
}