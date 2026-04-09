using StudentManagementSystemAPI.Data;
using StudentManagementSystemAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace StudentManagementSystemAPI.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Student>> GetAll()
        {
            return await _context.Students.ToListAsync(); 
        }

        public async Task<Student> GetById(int id) =>
            await _context.Students.FindAsync(id);

        public async Task Add(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var student = await _context.Students.FindAsync(id);
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }
    }
}
