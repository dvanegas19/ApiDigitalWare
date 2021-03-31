using Unity;
using Unity.Extension;

namespace DigitalWare.Billing.Business
{
    public class DependencyOfDependencyExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<Common.Interface.Interoperability.IHttpCustomClient, Interoperability.HttpCustomClient>();
            Container.RegisterType<Common.Interface.Repository.IInvoice, Repository.BillingInvoice>();
            Container.RegisterType<Common.Interface.Repository.IInvoiceDetail, Repository.BillingInvoiceDetail>();
            Container.RegisterType<Common.Interface.Repository.IProduct, Repository.BillingProduct>();
            Container.RegisterType<Common.Interface.Repository.IClient, Repository.BillingClient>();
            new Repository.BillingContext();
        }
    }
}
