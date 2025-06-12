using RefitSampleAPITest.Models;

namespace RefitSampleAPITest.Services
{
    public class StudentService : IStudentService
    {
        private static readonly List<Student> _students = new();
        private static int _idCounter = 1;

        public Task<List<Student>> GetStudentsAsync() => Task.FromResult(_students.ToList());

        public Task<Student> GetStudentByIdAsync(int id) =>
            Task.FromResult(_students.FirstOrDefault(s => s.Id == id));

        public Task<Student> CreateStudentAsync(Student student)
        {
            student.SetId(_idCounter++);
            _students.Add(student);
            return Task.FromResult(student);
        }

        public Task<Student> UpdateStudentAsync(Student student)
        {
            var existing = _students.FirstOrDefault(s => s.Id == student.Id);
            if (existing != null)
            {
                existing.Name = student.Name;
                existing.DateOfBirth = student.DateOfBirth;
                existing.Course = student.Course;
                existing.Points = student.Points;
            }
            return Task.FromResult(existing);
        }

        public Task DeleteStudentAsync(int id)
        {
            var student = _students.FirstOrDefault(s => s.Id == id);
            if (student != null)
                _students.Remove(student);
            return Task.CompletedTask;
        }
    }
}