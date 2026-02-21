using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementBissuness.SchoolInterfaceService;
using SchoolResitrationDtos;
using SchoolResitrationModel;

namespace ShoolManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        private readonly ISchoolManagementService _schoolManagementService;
        public SchoolController(ISchoolManagementService schoolManagementService)
        {
            _schoolManagementService = schoolManagementService; 
        }

        [HttpGet]
        public async Task<IActionResult> Get() 
        {
            var res = await _schoolManagementService.GetAllData();
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> InsertData(SchoolManagementModelDTO schoolManagementModelDTO)
        {
            await _schoolManagementService.AddSchool(schoolManagementModelDTO);
         
            return Ok("Insert SuccessFully");
        }

        [HttpPut]
        public async Task<IActionResult> Update(int Id, SchoolManagementModelDTO schoolManagementModelDTO)
        {
            await _schoolManagementService.UpdataData(Id , schoolManagementModelDTO);
            return Ok("Update Successfully");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            await _schoolManagementService.DeleteData(Id);
            return Ok("DeleteSuccessfully");
        }
    }
}
