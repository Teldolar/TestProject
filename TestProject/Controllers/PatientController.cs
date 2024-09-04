using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TestDB;
using TestDB.Models;
using TestProject.Models;
using TestServer.Managers;
using TestServer.Models.DoctorModels;
using TestServer.Models.PatientModels;

namespace TestProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController(PatientManager patientManager) : BaseController
    {
        public readonly PatientManager _patientManager = patientManager;

        [HttpGet]
        [Route("GetPatients")]
        public ActionResult<BaseResponseModel> GetPatient(string orderBy, int page, int pageSize)
        {
            try
            {
                List<PatientListModel> cards = _patientManager.GetPatientListModels(orderBy, page, pageSize);
                return GenerateJson(0, "Запрос выполнен успешно", cards);

            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message + '\n' + ex.InnerException);
                return GenerateJson(-1, "Что-то пошло не так, проверьте запрос, повторите позже или обратитесь к администратору системы");
            }
        }

        [HttpPost]
        [Route("AddPatient")]
        public ActionResult<BaseResponseModel> AddPatient(PatientInsertModel patient)
        {
            try
            {
                _patientManager.AddPatient(patient);

                return GenerateJson(0, "Запрос выполнен успешно");
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message + '\n' + ex.InnerException);
                return GenerateJson(-1, "Что-то пошло не так, проверьте запрос, повторите позже или обратитесь к администратору системы");
            }
        }

        [HttpGet]
        [Route("SelectPatientToUpdate")]
        public ActionResult<BaseResponseModel> SelectPatientToUpdate(int id)
        {
            try
            {
                var patient = _patientManager.SelectPatient(id);

                if (patient == null)
                    return GenerateJson(-1, "Доктор с заданным id не найден");

                return GenerateJson(0, "Запрос выполнен успешно", patient);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message + '\n' + ex.InnerException);
                return GenerateJson(-1, "Что-то пошло не так, проверьте запрос, повторите позже или обратитесь к администратору системы");
            }
        }

        [HttpPut]
        [Route("UpdatePatient")]
        public ActionResult<BaseResponseModel> UpdatePatient(PatientUpdateModel patient)
        {
            try
            {
                _patientManager.UpdatePatient(patient);
                return GenerateJson(0, "Запрос выполнен успешно");
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message + '\n' + ex.InnerException);
                return GenerateJson(-1, "Что-то пошло не так, проверьте запрос, повторите позже или обратитесь к администратору системы");
            }
        }

        [HttpDelete]
        [Route("DeletePatient")]
        public ActionResult<BaseResponseModel> DeletePatient(int id)
        {
            try
            {
                _patientManager.DeletePatient(id);
                return GenerateJson(0, "Запрос выполнен успешно");
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message + '\n' + ex.InnerException);
                return GenerateJson(-1, "Что-то пошло не так, проверьте запрос, повторите позже или обратитесь к администратору системы");
            }
        }
    }
}
