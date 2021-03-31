using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalWare.Billing.Common.Entity
{
    public class Invoice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdInvoice { get; set; }        
        
        public Client Client { get; set; }
        public DateTime RegistrationDate { get ; set; }

        public decimal Total { get; set; }

        public double Iva { get; set; }

        public ICollection<InvoiceDetail> InvoiceDetail { get; set; }

        


    }
}
