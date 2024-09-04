using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;
using TestDB;
using TestProject.Models;
using TestServer.Managers;
using TestServer.Models.DoctorModels;

namespace TestProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController(DoctorManager doctorManager) : BaseController
    {
        public readonly DoctorManager _doctorManager = doctorManager;

        [HttpGet]
        [Route("GetDoctors")]
        public ActionResult<BaseResponseModel> GetDoctors(string orderBy, int page, int pageSize)
        {
            try
            {
                List<DoctorListModel> cards = _doctorManager.GetDoctorListModels(orderBy, page, pageSize);
                return GenerateJson(0, "Запрос выполнен успешно", cards);

            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message + '\n' + ex.InnerException);
                return GenerateJson(-1, "Что-то пошло не так, проверьте запрос, повторите позже или обратитесь к администратору системы");
            }
        }

        [HttpPost]
        [Route("AddDoctor")]
        public ActionResult<BaseResponseModel> AddDoctor(DoctorInsertModel doctor)
        {
            try
            {
                _doctorManager.AddDoctor(doctor);

                return GenerateJson(0, "Запрос выполнен успешно");
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message + '\n' + ex.InnerException);
                return GenerateJson(-1, "Что-то пошло не так, проверьте запрос, повторите позже или обратитесь к администратору системы");
            }
        }

        [HttpGet]
        [Route("SelectDoctorToUpdate")]
        public ActionResult<BaseResponseModel> SelectDoctorToUpdate(int id)
        {
            try
            {
                DoctorUpdateModel? doctor = _doctorManager.SelectDoctor(id);

                if (doctor == null)
                    return GenerateJson(-1, "Доктор с заданным id не найден");

                return GenerateJson(0, "Запрос выполнен успешно", doctor);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message + '\n' + ex.InnerException);
                return GenerateJson(-1, "Что-то пошло не так, проверьте запрос, повторите позже или обратитесь к администратору системы");
            }
        }

        [HttpPut]
        [Route("UpdateDoctor")]
        public ActionResult<BaseResponseModel> UpdateDoctor(DoctorUpdateModel doctor)
        {
            try
            {
                _doctorManager.UpdateDoctor(doctor);
                return GenerateJson(0, "Запрос выполнен успешно");
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message + '\n' + ex.InnerException);
                return GenerateJson(-1, "Что-то пошло не так, проверьте запрос, повторите позже или обратитесь к администратору системы");
            }
        }

        [HttpDelete]
        [Route("DeleteDoctor")]
        public ActionResult<BaseResponseModel> DeleteDoctor(int id)
        {
            try
            {
                _doctorManager.DeleteDoctor(id);
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