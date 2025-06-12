using Refit;
using RefitSampleAPITest.Models;

namespace RefitSampleAPITest.Services
{
    public interface IStudentService
    {
        [Get("/students")]
        Task<List<Student>> GetStudentsAsync();

        [Get("/student/?id={id}")]
        Task<Student> GetStudentByIdAsync(int id);

        [Post("/students")]
        Task<Student> CreateStudentAsync([Body] Student student);

        [Put("/students")]
        Task<Student> UpdateStudentAsync([Body] Student student);

        [Delete("/student/?id={id}")]
        Task DeleteStudentAsync(int id);
    }
}
