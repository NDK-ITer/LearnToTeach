using Demo.Models;
using Flurl.Http;
using Flurl.Http.Configuration;

namespace ClienWebDemo.Repository
{
    public class ClassroomRespository : RepositoryBase, IClassroomRepository
    {
        public ClassroomRespository(IFlurlClientFactory flurlClientFactory, 
                                    IHttpContextAccessor httpContextAccessor) : base(flurlClientFactory, httpContextAccessor)
        {
        }

        public async Task<List<Classroom>> GetAllClassroom()
        {
            var n = _flurlClient.Request("/classroom/all").AllowAnyHttpStatus();
            return await _flurlClient.Request("/classroom/all").GetJsonAsync<List<Classroom>>();
        }

        public Task<Classroom> GetClassroomById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
