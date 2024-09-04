using System.ComponentModel.DataAnnotations.Schema;
using TestDB.Models;

namespace TestServer.Models.DoctorModels
{
    public class DoctorUpdateModel
    {
        public int Id { get; set; }
        public string FIO { get; set; }
        public int? CabinetId { get; set; }
        public int? SpecialisationId { get; set; }
        public int? SectorId { get; set; }

        public DoctorUpdateModel()
        {
        }

        public DoctorUpdateModel(Doctor doctor) 
        {
            Id = doctor.Id;
            FIO = doctor.FIO;
            CabinetId = doctor.CabinetId;
            SpecialisationId = doctor.SpecialisationId;
            SectorId = doctor.SectorId;
        }

        public Doctor ConvertToDoctor()
        {
            return new Doctor()
            { 
                Id = this.Id,
                FIO = this.FIO,
                CabinetId = this.CabinetId,
                SpecialisationId = this.SpecialisationId,
                SectorId = this.SectorId,
            };
        }
    }
}
