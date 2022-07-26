using System.Threading.Tasks;
using MyStandardsProject1.Api.Brokers.DateTimes;
using MyStandardsProject1.Api.Brokers.Loggings;
using MyStandardsProject1.Api.Brokers.Storages;
using MyStandardsProject1.Api.Models.Students;

namespace MyStandardsProject1.Api.Services.Foundations.Students
{
    public partial class StudentService : IStudentService
    {
        private readonly IStorageBroker storageBroker;
        private readonly IDateTimeBroker dateTimeBroker;
        private readonly ILoggingBroker loggingBroker;

        public StudentService(
            IStorageBroker storageBroker,
            IDateTimeBroker dateTimeBroker,
            ILoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.dateTimeBroker = dateTimeBroker;
            this.loggingBroker = loggingBroker;
        }

        public async ValueTask<Student> AddStudentAsync(Student student) =>
            await this.storageBroker.InsertStudentAsync(student);
    }
}