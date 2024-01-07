using RestfulApi.Features.CORS.Queries.BookingQueries;
using RestfulApi.Features.CORS.Results.BookingResult;
using RestfulApi.Interfaces;
using RestfulApi.Models;

namespace RestfulApi.Features.CORS.Handlers.BookingHandlers
{
    public class GetBookingByIdQueryHandler
    {
        private readonly IRepository<Booking> _repository;

        public GetBookingByIdQueryHandler(IRepository<Booking> repository)
        {
            _repository = repository;
        }
        public async Task<GetBookingByIdQueryResult> Handle(GetBookingByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetBookingByIdQueryResult
            {
                Id = values.Id,
                BookingDate = values.BookingDate,
                PatientId = values.PatientId,
                Patient = values.Patient,
                ClinicId = values.ClinicId,
            };
        }
    }
}
