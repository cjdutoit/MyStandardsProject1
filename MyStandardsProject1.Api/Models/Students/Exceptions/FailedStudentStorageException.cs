using System;
using Xeptions;

namespace MyStandardsProject1.Api.Models.Students.Exceptions
{
    public class FailedStudentStorageException : Xeption
    {
        public FailedStudentStorageException(Exception innerException)
            : base(message: "Failed student storage error occurred, contact support.", innerException)
        { }
    }
}