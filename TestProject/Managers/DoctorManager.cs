using TestDB.Managers;
using TestDB.Models;
using TestServer.Models.DoctorModels;

namespace TestServer.Managers
{
    public class DoctorManager(DoctorDbManager doctorDbManager)
    {
        public List<DoctorListModel> GetDoctorListModels(string orderBy, int page, int pagesize)
        {
            List<Doctor> doctors = doctorDbManager.GetDoctors(orderBy, page, pagesize);
            List<DoctorListModel> doctorList = [];

            foreach (Doctor doctor in doctors)
            {
                doctorList.Add(new DoctorListModel(doctor));
            }

            return doctorList;
        }

        public void AddDoctor(DoctorInsertModel doctor)
        {
            doctorDbManager.InsertDoctor(doctor.ConvertToDoctor());
        }
        public void UpdateDoctor(DoctorUpdateModel doctor)
        {
            doctorDbManager.UpdateDoctor(doctor.ConvertToDoctor());
        }

        public void DeleteDoctor(int id)
        {
            doctorDbManager.DeleteDoctor(id);
        }

        public DoctorUpdateModel? SelectDoctor(int id)
        {
            var doctor = doctorDbManager.SelectDoctor(id);
            return doctor is null ? null : new DoctorUpdateModel(doctor);
        }
    }
}
