using System.ComponentModel.DataAnnotations.Schema;
using TestDB.Models;

namespace TestServer.Models.DoctorModels
{
    public class DoctorListModel
    {
        public string FIO { get; set; }
        public string? CabinetNumber { get; set; }
        public string? SpecialisationName { get; set; }
        public string? SectorNumber { get; set; }

        public DoctorListModel(Doctor doctor) 
        {
            FIO = doctor.FIO;
            CabinetNumber = doctor.Cabinet?.Number;
            SpecialisationName = doctor.Specialisation?.Name;
            SectorNumber = doctor.Sector?.Number;
        }
    }
}
