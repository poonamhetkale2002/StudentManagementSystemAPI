using StudentManagementSystemAPI.Models;

namespace StudentManagementSystemAPI.Services
{
    public interface IStudentService
    {
        Task<List<Student>> GetStudents();
        Task<Student> GetStudent(int id);
        Task AddStudent(Student student);
        Task UpdateStudent(Student student);
        Task DeleteStudent(int id);
    }
}
