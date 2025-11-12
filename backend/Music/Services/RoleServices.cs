using Music.Models.Auth.Role;
using Music.Repositories;
using Music.Utils;
using System.Net;

namespace Music.Services
{
    public class RoleServices
    {
        private readonly IRoleRepository _repo;

        public RoleServices(IRoleRepository repo)
        {
            _repo = repo;
        }

        public async Task<Role> GetOneByName(string name)
        {
            var role = await _repo.GetOneAsync(x => x.Name == name);

            if (role == null)
            {
                throw new HttpResponseError(
                    HttpStatusCode.NotFound,
                    $"Role with name '{name}' doesn't exist"
                );
            }

            return role;
        }
    }
}
