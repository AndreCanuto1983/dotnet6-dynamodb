using Amazon.DynamoDBv2.DataModel;
using Aws.Dynamodb.Svc.Converter;
using Aws.Dynamodb.Svc.Interfaces;
using Aws.Dynamodb.Svc.Models;
using System.Net;

namespace Aws.Dynamodb.Svc.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IDynamoDBContext _context;
        private readonly ILogger<StudentRepository> _logger;

        public StudentRepository(
            IDynamoDBContext context,
            ILogger<StudentRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<StudentResponse> CreateStudentAsync(Student student)
        {
            try
            {
                var response = await _context.LoadAsync<Student>(student.Id);

                if (response != null)
                    return StudentConverter.ExistingStudent();

                await _context.SaveAsync(student);

                return StudentConverter.SuccessStudent(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                _logger.LogError("[StudentRepository][CreateStudent] => EXCEPTION: {ex}", ex.Message);
                
                return ex.Message.StudentException();
            }
        }

        public async Task<StudentResponse> UpdateStudentAsync(Student student)
        {
            try
            {
                var response = await _context.LoadAsync<Student>(student.Id);

                if (response == null)
                    return StudentConverter.StudentNotFound();

                await _context.SaveAsync(student);

                return StudentConverter.SuccessStudent(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                _logger.LogError("[StudentRepository][UpdateStudent] => EXCEPTION: {ex}", ex.Message);

                return ex.Message.StudentException();
            }
        }

        public async Task<GetStudentResponse<Student>> GetByIdAsync(int studentId)
        {
            try
            {
                var student = await _context.LoadAsync<Student>(studentId);

                return student.GetStudentResponse();
            }
            catch (Exception ex)
            {
                _logger.LogError("[StudentRepository][GetByIdAsync] => EXCEPTION: {ex}", ex.Message);
                
                return ex.Message.GetStudentException<Student>();
            }
        }

        public async Task<GetStudentResponse<List<Student>>> GetAllStudentsAsync()
        {
            try
            {
                var studentList = await _context.ScanAsync<Student>(default).GetRemainingAsync();
                return studentList.GetStudentListResponse();
            }
            catch (Exception ex)
            {
                _logger.LogError("[StudentRepository][GetAllStudents] => EXCEPTION: {ex}", ex.Message);
                
                return ex.Message.GetStudentException<List<Student>>();
            }
        }

        public async Task<StudentResponse> DeleteStudentAsync(int studentId)
        {
            try
            {
                var student = await _context.LoadAsync<Student>(studentId);

                if (student == null)
                    return StudentConverter.StudentNotFound();

                await _context.DeleteAsync(student);

                return StudentConverter.SuccessStudent(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                _logger.LogError("[StudentRepository][DeleteStudent] => EXCEPTION: {ex}", ex.Message);

                return ex.Message.StudentException();
            }
        }
    }
}
