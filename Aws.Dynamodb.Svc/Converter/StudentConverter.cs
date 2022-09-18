using Aws.Dynamodb.Svc.Models;
using System.Net;

namespace Aws.Dynamodb.Svc.Converter
{
    public static class StudentConverter
    {
        public static StudentResponse SuccessStudent(HttpStatusCode httpStatusCode)
             => new StudentResponse
             {
                 StatusCode = (int)httpStatusCode,
                 Success = true
             };

        public static StudentResponse ExistingStudent()
             => new StudentResponse
             {
                 StatusCode = (int)HttpStatusCode.BadRequest,
                 Success = false,
                 Message = "Student already registered"
             };

        public static StudentResponse StudentNotFound()
             => new StudentResponse
             {
                 StatusCode = (int)HttpStatusCode.BadRequest,
                 Success = false,
                 Message = "Student not found"
             };

        public static StudentResponse StudentException(this string exception)
             => new StudentResponse
             {
                 StatusCode = (int)HttpStatusCode.InternalServerError,
                 Success = false,
                 Message = exception
             };

        public static GetStudentResponse<Student> GetStudentResponse(this Student student)
             => new GetStudentResponse<Student>
             {
                 StatusCode = (int)HttpStatusCode.OK,
                 Success = true,
                 Data = student                 
             };

        public static GetStudentResponse<T> GetStudentException<T>(this string exception)
             => new GetStudentResponse<T>
             {
                 StatusCode = (int)HttpStatusCode.InternalServerError,
                 Success = false,
                 Message = exception
             };

        public static GetStudentResponse<List<Student>> GetStudentListResponse(this List<Student> studentList)
             => new GetStudentResponse<List<Student>>
             {
                 StatusCode = (int)HttpStatusCode.OK,
                 Success = true,
                 Data = studentList
             };        
    }
}
