using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalWare.Billing.Common.Entity
{
    public class InvoiceDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdDetailInvoice { get; set; }

        public int IdInvoice { get; set; }

        public DateTime RegistrationDate { get; set; }

        public Product Product { get; set; }

        public double Unit { get; set; }

        


    }
}
