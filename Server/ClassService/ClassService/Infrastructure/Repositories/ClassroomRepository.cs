using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using XAct;

namespace Infrastructure.Repositories
{
    public class ClassroomRepository : GenericRepository<Classroom>, IClassroomRepository
    {
        public IClassroomDetailRepository _classroomDetail;
        public ClassroomRepository(ClassroomDbContext context) : base(context)
        {
            _dbSet.Include(c => c.ListUserId).Load();
            _classroomDetail = new ClassroomDetailRepository(context);
        }
        public void UpdateClassroom(Classroom classroom) => Update(classroom);
        public void RegisterClassroom(Classroom classroom) => Add(classroom);
        public void DeleteClassroom(string idClassroom)
        {
            if (idClassroom == null) return;
            var classroomDelete = Find(c => c.Id == idClassroom).FirstOrDefault() as Classroom;
            if (classroomDelete == null) { return; }
            Remove(classroomDelete);
        }
        public int CheckClassroomIsPrivate(Classroom classroom)
        {
            if (classroom == null) return -1;
            if (classroom.IsPrivate == true) return 1;
            else return 0;
        }
        public Classroom? GetClassroomById(string id)
        {
            Classroom? classroom;
            classroom = GetById(id);
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
