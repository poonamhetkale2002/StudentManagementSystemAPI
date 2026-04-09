using StudentManagementSystemAPI.Models;

namespace StudentManagementSystemAPI.Repositories
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAll();
        Task<Student> GetById(int id);
        Task Add(Student student);
        Task Update(Student student);
        Task Delete(int id);
    }
}
