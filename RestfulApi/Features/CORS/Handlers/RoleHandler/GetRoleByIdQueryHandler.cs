using RestfulApi.Features.CORS.Queries.FeeQueries;
using RestfulApi.Features.CORS.Queries.RoleQueries;
using RestfulApi.Features.CORS.Results.FeeResult;
using RestfulApi.Features.CORS.Results.RoleResult;
using RestfulApi.Interfaces;
using RestfulApi.Models;

namespace RestfulApi.Features.CORS.Handlers.RoleHandler
{
    public class GetRoleByIdQueryHandler
    {
        private readonly IRepository <Role> _repository;

        public GetRoleByIdQueryHandler(IRepository<Role> repository)
        {
            _repository = repository;
        }
        public async Task<GetRoleByIdQueryResult> Handle(GetRoleByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetRoleByIdQueryResult
            {
                Id = values.Id,
                Title = values.Title,
                Description = values.Description,
                Permissions = values.Permissions,
                Users = values.Users,
            };
        }
    }
}
