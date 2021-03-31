using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWare.Billing.Repository
{
    /// <summary>
    /// Database context
    /// </summary>
    /// <history>
    ///    Version      Author              Date         Description
    ///    1.0.0.0      David Vanegas     27/11/2021  Creation
    /// </history>
    public class BillingContext : DbContext
    {
        /// <summary>
        /// constructor
        /// </summary>
        public BillingContext() : base("BillingContext")
        {
            InitializeDatabase();
        }

        public DbSet<Common.Entity.Client> Client { get; set; }
        public DbSet<Common.Entity.Product> Product { get; set; }
        public DbSet<Common.Entity.Invoice> Invoice { get; set; }
        public DbSet<Common.Entity.InvoiceDetail> InvoiceDetail { get; set; }
        public DbSet<Common.Entity.DocumentType> DocumentType { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Common.Entity.Client>()
           .HasRequired(w => w.DocumentType)
           .WithMany()
           .Map(m => m.MapKey("IdDocumentType"));

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Common.Entity.InvoiceDetail>()
             .HasRequired(w => w.Product)
             .WithMany()
             .Map(m => m.MapKey("IdProduct"));
           
             modelBuilder.Entity<Common.Entity.Invoice>()
            .HasRequired(w => w.Client)
            .WithMany()
            .Map(m => m.MapKey("IdClient"));

            modelBuilder.Entity<Common.Entity.Invoice>().MapToStoredProcedures(p => p.Insert(sp => sp.HasName("sp_InsertInvoice").
            Parameter(IIV => IIV.Iva , "Iva")
            .Parameter(IIV => IIV.RegistrationDate, "RegistrationDate")
            .Parameter(IIV => IIV.Total , "Total")
            .Parameter(IIV => IIV.Client.IdClient, "IdClient").
            Result(rs => rs.IdInvoice, "IdInvoice")));

            modelBuilder.Entity<Common.Entity.InvoiceDetail>().MapToStoredProcedures(p => p.Insert(sp => sp.HasName("sp_InsertInvoiceDetail").
           Parameter(IIV => IIV.IdInvoice, "IdInvoice")
           .Parameter(IIV => IIV.Product.IdProduct, "IdProduct")
           .Parameter(IIV => IIV.RegistrationDate, "RegistrationDate")
           .Parameter(IIV => IIV.Unit, "Unit").
           Result(rs => rs.IdDetailInvoice, "IdDetailInvoice")));

            modelBuilder.Entity<Common.Entity.Client>().MapToStoredProcedures(p => p.Insert(sp => sp.HasName("sp_InsertClient").
           Parameter(IIV => IIV.Names, "Names")
           .Parameter(IIV => IIV.LastName, "LastName")
           .Parameter(IIV => IIV.RegisterDate, "RegisterDate")
           .Parameter(IIV => IIV.Document, "Document")
           .Parameter(IIV => IIV.DocumentType.IdDocument, "IdDocument")
           .Parameter(IIV => IIV.BirthDate, "BirthDate").
           Result(rs => rs.IdClient, "IdDetailInvoice")));


        }

        /// <summary>
        /// Initialize database
        /// </summary>
        private void InitializeDatabase()
        {
            Database.SetInitializer(new BillingInitializer());
            if (!Database.Exists())
            {
                Database.Initialize(true);
            }
        }
    }
}
