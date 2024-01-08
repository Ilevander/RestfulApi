using RestfulApi.Features.CORS.Results.FeeResult;
using RestfulApi.Features.CORS.Results.UserResult;
using RestfulApi.Interfaces;
using RestfulApi.Models;

namespace RestfulApi.Features.CORS.Handlers.UserHandlers
{
    public class GetUserQueryHandler
    {
        private readonly IRepository<User> _repository;

        public GetUserQueryHandler(IRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetUserQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetUserQueryResult
            {
                Id = x.Id,
                RoleId = x.RoleId,
                Username = x.Username,
                PasswordHash = x.PasswordHash,
                Email = x.Email,
                Date = x.Date,
                Address = x.Address,
                Role = x.Role,
            }).ToList();
        }
    }
}
