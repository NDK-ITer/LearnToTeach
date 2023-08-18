using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IClassroomRepository : IGenericRepository<Classroom>
    {
        
        void UpdateClassroom(Classroom classroom);
        void RegisterClassroom(Classroom classroom);
        void DeleteClassroom(string idClassroom);
        int CheckClassroomIsPrivate(Classroom classroom);
        Classroom GetClassroomById(string id);
        Classroom GetClassroomByName(string name);
        List<Classroom> GetAllClassrooms();
        List<Classroom> GetClassroomsArePublic();
        List<Classroom>? GetClassroomsArePrivate();
    }
}
