using TestDB.Managers;
using TestDB.Models;
using TestServer.Models.PatientModels;

namespace TestServer.Managers
{
    public class PatientManager(PatientDbManager patientDbManager)
    {
        public List<PatientListModel> GetPatientListModels(string orderBy, int page, int pagesize)
        {
            List<Patient> Patients = patientDbManager.GetPatients(orderBy, page, pagesize);
            List<PatientListModel> PatientList = [];

            foreach (Patient Patient in Patients)
            {
                PatientList.Add(new PatientListModel(Patient));
            }

            return PatientList;
        }

        public void AddPatient(PatientInsertModel Patient)
        {
            patientDbManager.InsertPatient(Patient.ConvertToPatient());
        }
        public void UpdatePatient(PatientUpdateModel Patient)
        {
            patientDbManager.UpdatePatient(Patient.ConvertToPatient());
        }

        public void DeletePatient(int id)
        {
            patientDbManager.DeletePatient(id);
        }

        public PatientUpdateModel SelectPatient(int id)
        {
            return new PatientUpdateModel(patientDbManager.SelectPatient(id));
        }
    }
}
