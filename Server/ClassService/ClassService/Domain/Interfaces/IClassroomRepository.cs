using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IClassroomRepository : IGenericRepository<Classroom>
    {
        
        void UpdateClassroom(Classroom classroom);
        void RegisterClassroom(Classroom classroom);
        void DeleteClassroom(string idClassroom);
        void AddMember(Classroom classroom, ClassroomDetail member);
        void AddRangeMember(Classroom classroom, IEnumerable<ClassroomDetail> members);
        int CheckClassroomIsPrivate(Classroom classroom);
        Classroom GetClassroomById(string id);
        Classroom GetClassroomByName(string name);
        IEnumerable<Classroom> GetAllClassrooms();
        IEnumerable<Classroom> GetClassroomsArePrivate();
    }
}
