using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IClassroomRepository : IGenericRepository<Classroom>
    {
        
        int UpdateClassroom(Classroom classroom);
        int Register(string idUser);
        bool CheckClassroomIsPrivate(Classroom classroom);
        Classroom GetClassroomById(string id);
        Classroom GetClassroomByName(string name);
        IEnumerable<Classroom> GetAllClassrooms();
        IEnumerable<Classroom> GetClassroomsArePrivate();
        IEnumerable<string> GetIdUserOfClassroom(string idClass);
        IEnumerable<string> GetIdRoleOfUserInClassroom(string idClass);
    }
}
