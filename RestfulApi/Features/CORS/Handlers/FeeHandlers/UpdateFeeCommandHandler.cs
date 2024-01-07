using RestfulApi.Features.CORS.Commands.FeeCommands;
using RestfulApi.Interfaces;
using RestfulApi.Models;

namespace RestfulApi.Features.CORS.Handlers.FeeHandlers
{
    public class UpdateFeeCommandHandler
    {
        private readonly IRepository<Fee> _repository;

        public UpdateFeeCommandHandler(IRepository<Fee> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateFeeCommand command)
        {
            var values = await _repository.GetByIdAsync(command.FeeId);
           
            values.Amount = command.Amount;
            values.Doctor = command.Doctor;
            values.DoctorId = command.DoctorId;

            await _repository.UpdateAsync(values);
        }
    }
}
