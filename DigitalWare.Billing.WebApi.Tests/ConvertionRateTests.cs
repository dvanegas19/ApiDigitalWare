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
    public class ConvertionRateTests
    {
        private  Common.Interface.Interoperability.IHttpCustomClient HttpCustomClient = new Interoperability.HttpCustomClient();

        [TestMethod()]
        public async Task GetTest()
        {
            var result = await new Business.ConvertionRate(HttpCustomClient).Get();
            Assert.IsTrue(result.StatusCode == System.Net.HttpStatusCode.OK);
        }
    }
}