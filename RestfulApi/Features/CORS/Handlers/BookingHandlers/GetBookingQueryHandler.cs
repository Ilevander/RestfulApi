using RestfulApi.Features.CORS.Results.BookingResult;
using RestfulApi.Interfaces;
using RestfulApi.Models;

namespace RestfulApi.Features.CORS.Handlers.BookingHandlers
{
    public class GetBookingQueryHandler
    {
        private readonly IRepository<Booking> _repository;

        public GetBookingQueryHandler(IRepository<Booking> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetBookingQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetBookingQueryResult
            {
                Id = x.Id,
                BookingDate = x.BookingDate,
                PatientId = x.PatientId,
                ClinicId = x.ClinicId,
                Patient = x.Patient,
            }).ToList();
        }
    }
}
