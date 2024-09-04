using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDB.Models
{
    [Table("Patient")]
    public class Patient
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Fisrtname { get; set; }
        public string Patronymic { get; set; }
        public string Adress { get; set; }
        public DateTime Birthday { get; set; }
        public string Sex { get; set; }
        public int? SectorId { get; set; }
        [ForeignKey("SectorId")]
        public virtual Sector? Sector { get; set; }

    }
}
