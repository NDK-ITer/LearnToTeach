using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IClassroomDetailRepository : IGenericRepository<ClassroomDetail>
    {
        IEnumerable<ClassroomDetail> GetClassroomDetails(string idClass);
        void UpdateClassroomDetail(ClassroomDetail classroomDetail);
        void AddClassroomDetail(ClassroomDetail classroomDetail);
        void AddRangeClassroomDetail(IEnumerable<ClassroomDetail> classroomDetails);
        void DeleteRangeClassroomDetail(IEnumerable<ClassroomDetail> classroomDetails);
    }
}
