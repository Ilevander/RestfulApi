using RestfulApi.Features.CORS.Commands.FeeCommands;
using RestfulApi.Interfaces;
using RestfulApi.Models;

namespace RestfulApi.Features.CORS.Handlers.FeeHandlers
{
    public class CreateFeeCommandHandler
    {
        private readonly IRepository<Fee> _repository;

        public CreateFeeCommandHandler(IRepository<Fee> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateFeeCommand command)
        {
            await _repository.CreateAsync(new Fee
            {
                Amount = command.Amount,
                Doctor = command.Doctor,
                DoctorId = command.DoctorId,
            });

        }
    }
}
