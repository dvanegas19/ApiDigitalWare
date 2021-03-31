using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWare.Billing.Common.Entity
{
    /// <summary>
    /// Rates convertion 
    /// </summary>
    /// <history>
    ///    Version   Autor              Date         Description
    ///    1.0.0.0   David Vanegas    27/11/2021  Creation
    /// </history>
    /// <example>{ "IdClient": "", "Names": "", "LastName": "" }</example>
    public class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdClient { get; set; }
        /// <summary>
        ///  Names
        /// </summary>
        /// <example>Names</example>
        public string Names { get; set; }
        /// <summary>
        ///  LastName
        /// </summary>
        /// <example>LastName</example>
        public string LastName { get; set; }
        /// <summary>
        ///  Document
        /// </summary>
        /// <example>1032416237</example>
        public string Document { get; set; }
        /// <summary>
        ///  DocumentType
        /// </summary>
        /// <example>DocumentType</example>
        public DocumentType DocumentType { get; set; }
        /// <summary>
        ///  RegisterDate
        /// </summary>
        /// <example>RegisterDate</example> 
        public DateTime RegisterDate { get; set; }
        /// <summary>
        ///  BirthDate
        /// </summary>
        /// <example>BirthDate</example>
        public DateTime BirthDate { get; set; }
    }
}
