using System.Numerics;
using TestDB.Models;

namespace TestServer.Models.PatientModels
{
    public class PatientUpdateModel
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Fisrtname { get; set; }
        public string Patronymic { get; set; }
        public string Adress { get; set; }
        public DateTime Birthday { get; set; }
        public string Sex { get; set; }
        public int? SectorId { get; set; }

        public PatientUpdateModel()
        {
        }

        public PatientUpdateModel(Patient doctor)
        {
            Id = doctor.Id;
            Surname = doctor.Surname;
            Fisrtname = doctor.Fisrtname;
            Patronymic = doctor.Patronymic;
            Adress = doctor.Adress;
            Birthday = doctor.Birthday;
            Sex = doctor.Sex;
            SectorId = doctor.SectorId;
        }

        public Patient ConvertToPatient()
        {
            return new Patient()
            {
                Id = this.Id,
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
}
