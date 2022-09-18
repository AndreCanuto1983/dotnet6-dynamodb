using Amazon.DynamoDBv2.DataModel;
using Aws.Dynamodb.Svc.Interfaces;
using Aws.Dynamodb.Svc.Models;
using Microsoft.AspNetCore.Mvc;

namespace Aws.Dynamodb.Svc.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentsController : BaseController
{
    private readonly IDynamoDBContext _context;
    private readonly IStudentRepository _studentRepository;

    public StudentsController(IDynamoDBContext context, IStudentRepository studentRepository)
    {
        _context = context;
        _studentRepository = studentRepository;
    }

    [HttpPost]
    [ProducesResponseType(typeof(IActionResult), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(IResponseBase), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(IActionResult), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(IResponseBase), StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(IActionResult), StatusCodes.Status502BadGateway)]
    [ProducesResponseType(typeof(IActionResult), StatusCodes.Status503ServiceUnavailable)]
    public async Task<IActionResult> CreateStudent(Student student)
    {
        return ProcessResponse(
            await _studentRepository.CreateStudentAsync(student));
    }

    [HttpPut]
    [ProducesResponseType(typeof(IResponseBase), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(IResponseBase), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(IActionResult), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(IResponseBase), StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(IActionResult), StatusCodes.Status502BadGateway)]
    [ProducesResponseType(typeof(IActionResult), StatusCodes.Status503ServiceUnavailable)]
    public async Task<IActionResult> UpdateStudent(Student student)
    {
        return ProcessResponse(
            await _studentRepository.UpdateStudentAsync(student));
    }

    [HttpGet("{studentId}")]
    [ProducesResponseType(typeof(GetStudentResponse<Student>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(IResponseBase), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(IActionResult), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(IResponseBase), StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(IActionResult), StatusCodes.Status502BadGateway)]
    [ProducesResponseType(typeof(IActionResult), StatusCodes.Status503ServiceUnavailable)]
    public async Task<IActionResult> GetById(int studentId)
    {
        return ProcessResponse(
            await _studentRepository.GetByIdAsync(studentId));
    }

    [HttpGet]
    [ProducesResponseType(typeof(GetStudentResponse<List<Student>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(IResponseBase), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(IActionResult), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(IResponseBase), StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(IActionResult), StatusCodes.Status502BadGateway)]
    [ProducesResponseType(typeof(IActionResult), StatusCodes.Status503ServiceUnavailable)]
    public async Task<IActionResult> GetAllStudents()
    {
        return ProcessResponse(
            await _studentRepository.GetAllStudentsAsync());
    }

    [HttpDelete("{studentId}")]
    [ProducesResponseType(typeof(IResponseBase), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(IResponseBase), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(IActionResult), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(IResponseBase), StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(IActionResult), StatusCodes.Status502BadGateway)]
    [ProducesResponseType(typeof(IActionResult), StatusCodes.Status503ServiceUnavailable)]
    public async Task<IActionResult> DeleteStudent(int studentId)
    {
        return ProcessResponse(
            await _studentRepository.DeleteStudentAsync(studentId));
    }
}
