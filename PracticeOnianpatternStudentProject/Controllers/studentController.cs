using BussinessLogic.RepositoryFolder.ServiceFolder;
using Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PracticeOnianpatternStudentProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class studentController : ControllerBase
    {
        private readonly IStudentServicecs _studentServicecs;
        public studentController(IStudentServicecs studentServicecs)
        {
            _studentServicecs = studentServicecs;
        }

        [HttpGet]
        public async Task<IActionResult> GetData() 
        {
            var result = await _studentServicecs.ShowStudentData();
            return Ok ( result);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(StudentDto studentDto) 
        {
            await _studentServicecs.InsertData(studentDto);
            return Ok("InsertSuccessfully");

        }

        [HttpPut]
        public async Task<IActionResult> Update(int Id , StudentDto studentDto) 
        {
            await _studentServicecs.UpdateData(Id , studentDto);
            return Ok("Update Successfully");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int Id) 
        {
            await _studentServicecs.DeleteData(Id);
            return Ok("Delete Succesfully");
        }
    }
}
