using ClienWebDemo.Repository;
using Demo.Models;

namespace ClienWebDemo.Services
{
    public class ClassroomService : IClassroomService
    {
        private readonly IClassroomRepository _classroomRepository;

        public ClassroomService(IClassroomRepository classroomRepository)
        {
            _classroomRepository = classroomRepository;
        }
        public async Task<List<Classroom>> GetAllClassroom()
        {
            return await _classroomRepository.GetAllClassroom();
        }

        public Task<Classroom> GetClassroomById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
