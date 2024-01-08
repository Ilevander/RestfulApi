using RestfulApi.Models;

namespace RestfulApi.Features.CORS.Commands.ScheduleCommands
{
    public class UpdateScheduleCommand
    {
        public int Id { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int? DoctorId { get; set; }

        public virtual Doctor? Doctor { get; set; }
    }
}
