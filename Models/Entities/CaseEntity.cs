using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorReportApp_Console.Models.Entities
{
    internal class CaseEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime RegDate { get; set; } = DateTime.Now;
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Status { get; set; } = "Ej påbörjad";


        public int CustomerId { get; set; }
        public CustomerEntity Customer { get; set; } = null!;
    }
}
