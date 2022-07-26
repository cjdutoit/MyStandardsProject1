using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using MyStandardsProject1.Api.Tests.Acceptance.Models.Students;
using Xunit;

namespace MyStandardsProject1.Api.Tests.Acceptance.Apis.Students
{
    public partial class StudentsApiTests
    {
        [Fact]
        public async Task ShouldPostStudentAsync()
        {
            // given
            Student randomStudent = CreateRandomStudent();
            Student inputStudent = randomStudent;
            Student expectedStudent = inputStudent;

            // when 
            await this.apiBroker.PostStudentAsync(inputStudent);

            Student actualStudent =
                await this.apiBroker.GetStudentByIdAsync(inputStudent.Id);

            // then
            actualStudent.Should().BeEquivalentTo(expectedStudent);
            await this.apiBroker.DeleteStudentByIdAsync(actualStudent.Id);
        }

        [Fact]
        public async Task ShouldGetAllStudentsAsync()
        {
            // given
            List<Student> randomStudents = await PostRandomStudentsAsync();
            List<Student> expectedStudents = randomStudents;

            // when
            List<Student> actualStudents = await this.apiBroker.GetAllStudentsAsync();

            // then
            foreach (Student expectedStudent in expectedStudents)
            {
                Student actualStudent = actualStudents.Single(approval => approval.Id == expectedStudent.Id);
                actualStudent.Should().BeEquivalentTo(expectedStudent);
                await this.apiBroker.DeleteStudentByIdAsync(actualStudent.Id);
            }
        }
    }
}