using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWare.Billing.Common.Logger
{
    public class DatabaseWriter : LogConfigurator
    {
        public override void Exception(Exception ex, string location)
        {
            throw new NotImplementedException();
        }

        public override void Info(string Message)
        {
            throw new NotImplementedException();
        }
    }
}
