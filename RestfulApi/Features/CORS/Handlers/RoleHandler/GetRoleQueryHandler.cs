using RestfulApi.Features.CORS.Results.RoleResult;
using RestfulApi.Interfaces;
using RestfulApi.Models;

namespace RestfulApi.Features.CORS.Handlers.RoleHandler
{
    public class GetRoleQueryHandler
    {
        private readonly IRepository<Role> _repository;

        public GetRoleQueryHandler(IRepository<Role> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetRoleQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetRoleQueryResult
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                Permissions = x.Permissions,
                Users = x.Users,
            }).ToList();
        }
    }
}
