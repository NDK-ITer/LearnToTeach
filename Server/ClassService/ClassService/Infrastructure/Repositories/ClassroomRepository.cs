using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;

namespace Infrastructure.Repositories
{
    public class ClassroomRepository : GenericRepository<Classroom> , IClassroomRepository
    {
        public ClassroomRepository(ClassroomDbContext context) : base(context)
        {
        }
        public void UpdateClassroom(Classroom classroom) => Update(classroom);
        public void Register(Classroom classroom) => Add(classroom);
        public int CheckClassroomIsPrivate(Classroom classroom)
        {
            if (classroom == null) return -1;
            if (classroom.IsPrivate == true) return 1;
            else return 0;
        }
        public Classroom? GetClassroomById(string id)
        {
            Classroom? classroom;
            classroom = Find(c => c.Id == id).FirstOrDefault() as Classroom;
            if (classroom == null) return null;
            return classroom;
        }
        public Classroom? GetClassroomByName(string name)
        {
            Classroom? classroom;
            classroom = Find(c => c.Name == name).FirstOrDefault() as Classroom;
            if (classroom == null) return null;
            return classroom;
        }
        public IEnumerable<Classroom> GetAllClassrooms() => GetAll();
        public IEnumerable<Classroom>? GetClassroomsArePrivate()
        {
            return Find(c => c.IsPrivate == true);
        }
    }
}
