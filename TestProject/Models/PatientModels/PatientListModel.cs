using System.ComponentModel.DataAnnotations.Schema;
using TestDB.Models;

namespace TestServer.Models.PatientModels
{
    public class PatientListModel
    {
        public string Surname { get; set; }
        public string Fisrtname { get; set; }
        public string Patronymic { get; set; }
        public string Adress { get; set; }
        public DateTime Birthday { get; set; }
        public string Sex { get; set; }
        public string? SectorNumber { get; set; }

        public PatientListModel(Patient patient)
        {
            Surname = patient.Surname;
            Fisrtname = patient.Fisrtname;
            Patronymic = patient.Patronymic;
            Adress = patient.Adress;
            Birthday = patient.Birthday;
            Sex = patient.Sex;
            SectorNumber = patient.Sector?.Number;
        }
    }
}
