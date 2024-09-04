using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TestDB.Models
{
    [Table("Doctor")]
    public class Doctor
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FIO { get; set; }

        public int? CabinetId { get; set; }
        [ForeignKey("CabinetId")]
        public virtual Cabinet? Cabinet { get; set; }

        public int? SpecialisationId { get; set; }
        [ForeignKey("SpecialisationId")]
        public virtual Specialisation? Specialisation { get; set; }

        public int? SectorId { get; set; }
        [ForeignKey("SectorId")]
        public virtual Sector? Sector { get; set; }
    }
}
