using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDB.Models
{
    [Table("Sector")]
    public class Sector
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //Текст, потому что зачастую номер участка может быть формата: 12Б
        public string Number { get; set; }
    }
}
