using System.ComponentModel.DataAnnotations.Schema;
using TestDB.Models;

namespace TestServer.Models.PatientModels
{
    public class PatientInsertModel
    {
        public string Surname { get; set; }
        public string Fisrtname { get; set; }
        public string Patronymic { get; set; }
        public string Adress { get; set; }
        public DateTime Birthday { get; set; }
        public string Sex { get; set; }
        public int? SectorId { get; set; }

        public Patient ConvertToPatient() => new Patient
        {
            Surname = this.Surname,
            Fisrtname = this.Fisrtname,
            Patronymic = this.Patronymic,
            Adress = this.Adress,
            Birthday = this.Birthday,
            Sex = this.Sex,
            SectorId = this.SectorId
        };
    }
}
