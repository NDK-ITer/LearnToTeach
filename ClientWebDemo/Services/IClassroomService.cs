using Demo.Models;

namespace ClienWebDemo.Services
{
    public interface IClassroomService
    {
        Task<List<Classroom>> GetAllClassroom();
        Task<Classroom> GetClassroomById(Guid id);
    }
}
