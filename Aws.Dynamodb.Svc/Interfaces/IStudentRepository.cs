using Aws.Dynamodb.Svc.Models;

namespace Aws.Dynamodb.Svc.Interfaces
{
    public interface IStudentRepository
    {
        Task<StudentResponse> CreateStudentAsync(Student student);
        Task<StudentResponse> UpdateStudentAsync(Student student);
        Task<GetStudentResponse<Student>> GetByIdAsync(int studentId);
        Task<GetStudentResponse<List<Student>>> GetAllStudentsAsync();
        Task<StudentResponse> DeleteStudentAsync(int studentId);
    }
}
