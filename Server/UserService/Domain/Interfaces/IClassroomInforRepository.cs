using Domain.Entities;
using System.Linq.Expressions;

namespace Domain.Interfaces
{
    public interface IClassroomInforRepository : IGenericRepository<ClassroomInfor>
    {
        void AddClassroomInfor(ClassroomInfor classroomInfor);
        void UpdateClassroomInfor (ClassroomInfor classroomInfor);
        void RemoveClassroomInfor (ClassroomInfor classroomInfor);
        void RemoveClassroomInforRange(List<ClassroomInfor> listClassroomInfor);
        List<ClassroomInfor> GetClassroomInfor(Expression<Func<ClassroomInfor, bool>> properties);
    }
}
