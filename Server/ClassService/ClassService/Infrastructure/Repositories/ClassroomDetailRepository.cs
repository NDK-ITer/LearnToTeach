using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;

namespace Infrastructure.Repositories
{
    public class ClassroomDetailRepository :GenericRepository<ClassroomDetail> , IClassroomDetailRepository
    {
        public ClassroomDetailRepository(ClassroomDbContext context) : base(context)
        {
        }

        public void AddRangeClassroomDetail(IEnumerable<ClassroomDetail> classroomDetails)
        {
            throw new NotImplementedException();
        }

        public void DeleteRangeClassroomDetail(IEnumerable<ClassroomDetail> classroomDetails)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ClassroomDetail>? GetClassroomDetails(string idClass)
        {
            return Find(c => c.IdClass == idClass);
        }

        public void UpdateClassroomDetail(ClassroomDetail classroomDetail) => Update(classroomDetail);
        

        
    }
}
