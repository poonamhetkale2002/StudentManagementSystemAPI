using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystemAPI.Models;
using StudentManagementSystemAPI.Services;

namespace StudentManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;

        public StudentController(IStudentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _service.GetStudents());

        [HttpPost]
        public async Task<IActionResult> Add(Student student)
        {
            student.Id = 0; // ignore incoming id
            await _service.AddStudent(student);
            return Ok("Student Added");
        }

        [HttpPut]
        public async Task<IActionResult> Update(Student student)
        {
            await _service.UpdateStudent(student);
            return Ok("Updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteStudent(id);
            return Ok("Deleted");
        }
    }
}
