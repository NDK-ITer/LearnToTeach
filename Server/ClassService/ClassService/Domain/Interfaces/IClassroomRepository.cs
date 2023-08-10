using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IClassroomRepository : IGenericRepository<Classroom>
    {
        
        void UpdateClassroom(Classroom classroom);
        void Register(Classroom classroom);
        int CheckClassroomIsPrivate(Classroom classroom);
        Classroom GetClassroomById(string id);
        Classroom GetClassroomByName(string name);
        IEnumerable<Classroom> GetAllClassrooms();
        IEnumerable<Classroom> GetClassroomsArePrivate();
    }
}
