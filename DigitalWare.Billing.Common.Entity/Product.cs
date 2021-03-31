using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalWare.Billing.Common.Entity
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProduct { get; set; }

        public string Description { get; set; }
        public decimal Price { get; set; }
        public double Unit { get; set; }
        public double IVA { get; set; }
        public bool Activo { get; set; }


    }
}
