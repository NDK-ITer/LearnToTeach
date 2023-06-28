using Demo.Models;
using System.Threading.Tasks;
namespace ClienWebDemo.Repository
{
    public interface IClassroomRepository
    {
        Task<List<Classroom>> GetAllClassroom();
        Task<Classroom> GetClassroomById(Guid id);
    }
}
