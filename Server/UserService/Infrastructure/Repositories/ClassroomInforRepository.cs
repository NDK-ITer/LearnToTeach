using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public class ClassroomInforRepository : GenericRepository<ClassroomInfor>, IClassroomInforRepository
    {
        public ClassroomInforRepository(UserServiceDbContext context) : base(context)
        {

        }
        public void AddClassroomInfor(ClassroomInfor classroomInfor) => Add(classroomInfor);
        public List<ClassroomInfor>? GetClassroomInfor(Expression<Func<ClassroomInfor, bool>> properties) => Find(properties);
        public void RemoveClassroomInfor(ClassroomInfor classroomInfor) => Remove(classroomInfor);
        public void RemoveClassroomInforRange(List<ClassroomInfor> listClassroomInfor) => RemoveRange(listClassroomInfor);  
        public void UpdateClassroomInfor(ClassroomInfor classroomInfor) => Update(classroomInfor);
       
    }
}
