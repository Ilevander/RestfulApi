using RestfulApi.Features.CORS.Queries.FeeQueries;
using RestfulApi.Features.CORS.Queries.UserQueries;
using RestfulApi.Features.CORS.Results.FeeResult;
using RestfulApi.Features.CORS.Results.UserResult;
using RestfulApi.Interfaces;
using RestfulApi.Models;

namespace RestfulApi.Features.CORS.Handlers.UserHandlers
{
    public class GetUserByIdQueryHandler
    {
        private readonly IRepository<User> _repository;

        public GetUserByIdQueryHandler(IRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task<GetUserByIdQueryResult> Handle(GetUserByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetUserByIdQueryResult
            {
                Id = values.Id,
                Role = values.Role,
                RoleId = values.RoleId,
                Username = values.Username,
                PasswordHash = values.PasswordHash,
                Email = values.Email,
                Date = values.Date,
                Address = values.Address,
            };
        }
    }
}
