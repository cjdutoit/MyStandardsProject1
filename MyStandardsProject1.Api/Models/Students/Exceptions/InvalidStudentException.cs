using Xeptions;

namespace MyStandardsProject1.Api.Models.Students.Exceptions
{
    public class InvalidStudentException : Xeption
    {
        public InvalidStudentException()
            : base(message: "Invalid student. Please correct the errors and try again.")
        { }
    }
}