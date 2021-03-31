using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalWare.Billing;

namespace DigitalWare.Billing.Repository
{
    public class BillingInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<BillingContext>
    {
        protected override void Seed(BillingContext context)
        {

            List<Common.Entity.DocumentType> listDocumentType = new List<Common.Entity.DocumentType> {
                new Common.Entity.DocumentType{ Description="Cedula Ciudadania"},
                new Common.Entity.DocumentType{ Description="Cedula Extrangeria"},
                new Common.Entity.DocumentType{ Description="Pasaporte"}
            };
            listDocumentType.ForEach(x => { context.DocumentType.Add(x); });
            context.SaveChanges();

            List<Common.Entity.Client> listClient = new List<Common.Entity.Client> {
                new Common.Entity.Client{ DocumentType = new Common.Entity.DocumentType{  IdDocument = 1},BirthDate = Convert.ToDateTime("01/01/1980"),
                Document = "1032416211", RegisterDate = DateTime.Now, Names = "David Rodrigo", LastName = "Vanegas"},
                new Common.Entity.Client{ DocumentType = new Common.Entity.DocumentType{  IdDocument = 1},BirthDate = Convert.ToDateTime("01/01/1981"),
                Document = "1032416221", RegisterDate = DateTime.Now, Names = "Carlos", LastName = "Contreras"},
                new Common.Entity.Client{ DocumentType = new Common.Entity.DocumentType{  IdDocument = 1},BirthDate = Convert.ToDateTime("01/01/1982"),
                Document = "1032416231", RegisterDate = DateTime.Now, Names = "Paola", LastName = "Castro"},
                new Common.Entity.Client{ DocumentType = new Common.Entity.DocumentType{  IdDocument = 1},BirthDate = Convert.ToDateTime("01/01/1983"),
                Document = "1032416214", RegisterDate = DateTime.Now, Names = "Edwin", LastName = "Rivera"},
                new Common.Entity.Client{ DocumentType = new Common.Entity.DocumentType{  IdDocument = 1},BirthDate = Convert.ToDateTime("01/01/1984"),
                Document = "1032416230", RegisterDate = DateTime.Now, Names = "Andres", LastName = "Mora"}
            };

            listClient.ForEach(x => { context.Client.Add(x); }) ;
            context.SaveChanges();

            List<Common.Entity.Product> listProduct = new List<Common.Entity.Product> {
                new Common.Entity.Product{ Description="Televisor", Price = 1000000, Unit =4,IVA=19, Activo=true},
                new Common.Entity.Product{ Description="Nevera", Price = 1500000, Unit =15,IVA=19, Activo=true},
                new Common.Entity.Product{ Description="Lavadora", Price = 800000, Unit =3,IVA=19, Activo=true},
                new Common.Entity.Product{ Description="Estufa", Price = 600000, Unit =8,IVA=19, Activo=true},
                new Common.Entity.Product{ Description="Equipo De Sonido", Price = 1200000,IVA=19, Unit =10, Activo=true},
            };
            listProduct.ForEach(x => { context.Product.Add(x); });
            context.SaveChanges();
           
        }
    }
}
