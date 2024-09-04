using System.ComponentModel.DataAnnotations.Schema;
using TestDB.Models;

namespace TestServer.Models.DoctorModels
{
    public class DoctorInsertModel
    {
        public string FIO { get; set; }
        public int? CabinetId { get; set; }
        public int? SpecialisationId { get; set; }
        public int? SectorId { get; set; }

        public Doctor ConvertToDoctor() => new Doctor
        {
            FIO = this.FIO,
            CabinetId = this.CabinetId,
            SpecialisationId = this.SpecialisationId,
            SectorId = this.SectorId
        };
    }
}
