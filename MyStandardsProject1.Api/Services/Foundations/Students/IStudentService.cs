using System.Threading.Tasks;
using MyStandardsProject1.Api.Models.Students;

namespace MyStandardsProject1.Api.Services.Foundations.Students
{
    public interface IStudentService
    {
        ValueTask<Student> AddStudentAsync(Student student);
    }
}