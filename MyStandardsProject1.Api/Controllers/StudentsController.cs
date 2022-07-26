using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;
using MyStandardsProject1.Api.Models.Students;
using MyStandardsProject1.Api.Models.Students.Exceptions;
using MyStandardsProject1.Api.Services.Foundations.Students;

namespace MyStandardsProject1.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : RESTFulController
    {
        private readonly IStudentService studentService;

        public StudentsController(IStudentService studentService) =>
            this.studentService = studentService;

        [HttpPost]
        public async ValueTask<ActionResult<Student>> PostStudentAsync(Student student)
        {
            try
            {
                Student addedStudent =
                    await this.studentService.AddStudentAsync(student);

                return Created(addedStudent);
            }
            catch (StudentValidationException studentValidationException)
            {
                return BadRequest(studentValidationException.InnerException);
            }
            catch (StudentDependencyValidationException studentValidationException)
                when (studentValidationException.InnerException is InvalidStudentReferenceException)
            {
                return FailedDependency(studentValidationException.InnerException);
            }
            catch (StudentDependencyValidationException studentDependencyValidationException)
               when (studentDependencyValidationException.InnerException is AlreadyExistsStudentException)
            {
                return Conflict(studentDependencyValidationException.InnerException);
            }
            catch (StudentDependencyException studentDependencyException)
            {
                return InternalServerError(studentDependencyException);
            }
            catch (StudentServiceException studentServiceException)
            {
                return InternalServerError(studentServiceException);
            }
        }
    }
}